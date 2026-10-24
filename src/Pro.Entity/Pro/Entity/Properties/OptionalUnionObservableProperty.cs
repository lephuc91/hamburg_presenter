using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Utility;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalUnionObservableProperty<T> : IInternalObservableProperty<T?>, IObservableProperty<T?>, IDiffReceiver, IWhenChangeHappensSource, IComplexObservableProperty<T?>, IReceiveMapUpdates, IDisposable where T : class
{
	private readonly string _key;

	private readonly BehaviorSubject<T?> _valueSubject;

	private readonly BehaviorSubject<Unit> _valueChildSubject;

	private readonly IUnionValueFactory<T> _valueFactory;

	private readonly object _lock = new object();

	private IDisposable _valueChildSubscription;

	private bool _isDisposed;

	private LoroMap _map;

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges.ToUnit();

	public IObservable<T?> WhenValueChanges => _valueSubject;

	public IObservable<T?> WhenAnyValueChanges => from v in _valueSubject.CombineLatest(_valueChildSubject)
		select v.First;

	public T? Value => _valueSubject.Value;

	public OptionalUnionObservableProperty(string key, LoroMap map, IUnionValueFactory<T> valueFactory)
	{
		_key = key;
		_map = map;
		_valueFactory = valueFactory;
		_valueSubject = new BehaviorSubject<T>(Deserialize(_map.Get(_key)?.AsLoroMap()));
		_valueChildSubject = new BehaviorSubject<Unit>(Unit.Default);
		_valueChildSubscription = ((Value is IInternalEntity internalEntity) ? internalEntity.WhenChangeHappens.Subscribe(delegate
		{
			_valueChildSubject.OnNext(Unit.Default);
		}) : Disposable.Empty);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Set(T? value)
	{
		lock (_lock)
		{
			if (Value == value)
			{
				return;
			}
			_valueChildSubscription.Dispose();
			IDisposable obj = Value as IDisposable;
			if (value is IInternalEntity internalEntity)
			{
				internalEntity.UpdateMapOnInternalMapUpdate(_map.InsertMapContainer(_key, internalEntity.LoroMap));
				_valueChildSubscription = internalEntity.WhenChangeHappens.Subscribe(delegate
				{
					_valueChildSubject.OnNext(Unit.Default);
				});
				_valueSubject.OnNext(value);
			}
			else
			{
				_valueChildSubscription = Disposable.Empty;
				_map.Delete(_key);
				_valueSubject.OnNext(null);
			}
			obj?.Dispose();
			_map.Doc()?.Commit();
		}
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length <= 0)
		{
			if (diff is Diff.Map map && map.diff.updated.ContainsKey(_key))
			{
				ApplyMapUpdate(ReadOnlySpan<PathItem>.Empty, diff);
			}
		}
		else if (updatedPaths[0].index is Pro.Loro.Index.Key key && key.key == _key)
		{
			ApplyMapUpdate(updatedPaths.Slice(1), diff);
		}
	}

	private void ApplyMapUpdate(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		lock (_lock)
		{
			LoroMap loroMap = _map.Get(_key)?.AsLoroMap();
			if (loroMap == null)
			{
				if (Value != null)
				{
					ClearValue();
				}
				return;
			}
			if (!updatedPaths.IsEmpty && (!(updatedPaths[0].index is Pro.Loro.Index.Key key) || !(key.key == _valueFactory.SelectionKey)) && Value is IInternalEntity internalEntity)
			{
				if (internalEntity.LoroMap.Id() != loroMap.Id())
				{
					internalEntity.UpdateMap(loroMap);
				}
				internalEntity.OnDiff(updatedPaths, diff);
				return;
			}
			if (Value is IInternalEntity internalEntity2 && internalEntity2.LoroMap.Id() == loroMap.Id())
			{
				internalEntity2.OnDiff(updatedPaths, diff);
				return;
			}
			T val = _valueFactory.CreateInstance(loroMap);
			if (val == null)
			{
				if (Value != null)
				{
					ClearValue();
				}
				return;
			}
			_valueChildSubscription.Dispose();
			IDisposable obj = Value as IDisposable;
			_valueChildSubscription = ((val is IInternalEntity internalEntity3) ? internalEntity3.WhenChangeHappens.Subscribe(delegate
			{
				_valueChildSubject.OnNext(Unit.Default);
			}) : Disposable.Empty);
			_valueSubject.OnNext(val);
			(val as IInternalEntity)?.OnDiff(updatedPaths, diff);
			obj?.Dispose();
		}
	}

	private void ClearValue()
	{
		_valueChildSubscription.Dispose();
		IDisposable obj = Value as IDisposable;
		_valueChildSubscription = Disposable.Empty;
		_valueSubject.OnNext(null);
		obj?.Dispose();
	}

	public void UpdateMap(LoroMap map)
	{
		lock (_lock)
		{
			_map = map;
			if (Value is IInternalEntity internalEntity)
			{
				LoroMap loroMap = _map.Get(_key)?.AsLoroMap();
				if (loroMap != null)
				{
					internalEntity.UpdateMap(loroMap);
				}
			}
		}
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
	{
		lock (_lock)
		{
			_map = map;
			if (Value is IInternalEntity internalEntity)
			{
				LoroMap loroMap = _map.Get(_key)?.AsLoroMap();
				if (loroMap != null)
				{
					internalEntity.UpdateMapOnInternalMapUpdate(loroMap);
				}
			}
		}
	}

	private T? Deserialize(LoroMap? map)
	{
		if (map != null)
		{
			return _valueFactory.CreateInstance(map);
		}
		return null;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_isDisposed)
		{
			return;
		}
		if (disposing)
		{
			if (Value is IDisposable disposable)
			{
				disposable.Dispose();
			}
			_valueChildSubscription.Dispose();
			_valueChildSubject.Dispose();
			_valueSubject.Dispose();
		}
		_isDisposed = true;
	}
}
