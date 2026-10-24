using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Utility;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class OptionalComplexObservableProperty<T> : IInternalObservableProperty<T?>, IObservableProperty<T?>, IDiffReceiver, IWhenChangeHappensSource, IComplexObservableProperty<T?>, IReceiveMapUpdates, IDisposable where T : class
{
	private readonly string _key;

	private readonly BehaviorSubject<T?> _valueSubject;

	private readonly BehaviorSubject<Unit> _valueChildSubject;

	private readonly Func<LoroMap, T?> _valueFactory;

	private readonly object _lock = new object();

	private IDisposable _valueChildSubscription;

	private bool _isDisposed;

	private LoroMap _map;

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges.ToUnit();

	public IObservable<T?> WhenValueChanges => _valueSubject;

	public IObservable<T?> WhenAnyValueChanges => from v in _valueSubject.CombineLatest(_valueChildSubject)
		select v.First;

	public T? Value => _valueSubject.Value;

	public OptionalComplexObservableProperty(string key, LoroMap map, IValueFactory<T> valueFactory)
		: this(key, map, (Func<LoroMap, T?>)valueFactory.CreateInstance)
	{
	}

	public OptionalComplexObservableProperty(string key, LoroMap map, Func<LoroMap, T?> valueFactory)
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
			if (!(diff is Diff.Map map) || !map.diff.updated.ContainsKey(_key))
			{
				return;
			}
			lock (_lock)
			{
				LoroMap loroMap = _map.Get(_key)?.AsLoroMap();
				if (loroMap == null && Value == null)
				{
					return;
				}
				if (_valueSubject.Value == null)
				{
					_valueChildSubscription.Dispose();
					_valueSubject.OnNext(Deserialize(loroMap));
					_valueChildSubscription = ((Value is IInternalEntity internalEntity) ? internalEntity.WhenChangeHappens.Subscribe(delegate
					{
						_valueChildSubject.OnNext(Unit.Default);
					}) : Disposable.Empty);
				}
				else if (loroMap == null)
				{
					_valueChildSubscription.Dispose();
					IDisposable obj = Value as IDisposable;
					_valueChildSubscription = Disposable.Empty;
					_valueSubject.OnNext(null);
					obj?.Dispose();
				}
				else if (Value is IInternalEntity internalEntity2 && internalEntity2.LoroMap.Id() != loroMap.Id())
				{
					internalEntity2.UpdateMap(loroMap);
				}
				return;
			}
		}
		if (!(updatedPaths[0].index is Pro.Loro.Index.Key key) || !(key.key == _key))
		{
			return;
		}
		lock (_lock)
		{
			LoroMap loroMap2 = _map.Get(_key)?.AsLoroMap();
			if (loroMap2 == null && Value == null)
			{
				return;
			}
			if (_valueSubject.Value == null)
			{
				_valueChildSubscription.Dispose();
				_valueSubject.OnNext(Deserialize(loroMap2));
				_valueChildSubscription = ((Value is IInternalEntity internalEntity3) ? internalEntity3.WhenChangeHappens.Subscribe(delegate
				{
					_valueChildSubject.OnNext(Unit.Default);
				}) : Disposable.Empty);
				(_valueSubject.Value as IInternalEntity)?.OnDiff(updatedPaths.Slice(1), diff);
			}
			else if (loroMap2 == null)
			{
				_valueChildSubscription.Dispose();
				IDisposable obj2 = Value as IDisposable;
				_valueChildSubscription = Disposable.Empty;
				_valueSubject.OnNext(null);
				obj2?.Dispose();
			}
			else if (_valueSubject.Value is IInternalEntity internalEntity4)
			{
				if (loroMap2.Id() != internalEntity4.LoroMap.Id())
				{
					internalEntity4.UpdateMap(loroMap2);
				}
				internalEntity4.OnDiff(updatedPaths.Slice(1), diff);
			}
		}
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
			return _valueFactory(map);
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
