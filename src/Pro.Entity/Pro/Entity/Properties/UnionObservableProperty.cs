using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class UnionObservableProperty<T> : IInternalObservableProperty<T>, IObservableProperty<T>, IDiffReceiver, IWhenChangeHappensSource, IComplexObservableProperty<T>, IReceiveMapUpdates, IDisposable where T : class
{
	private readonly BehaviorSubject<T> _valueSubject;

	private readonly BehaviorSubject<Unit> _valueChildSubject;

	private readonly string _key;

	private readonly IUnionValueFactory<T> _valueFactory;

	private IDisposable _valueChildSubscription;

	private LoroMap _map;

	private bool _isDisposed;

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges.ToUnit();

	public IObservable<T> WhenValueChanges => _valueSubject;

	public IObservable<T> WhenAnyValueChanges => from v in _valueSubject.CombineLatest(_valueChildSubject)
		select v.First;

	public T Value => _valueSubject.Value;

	public UnionObservableProperty(string key, LoroMap map, IUnionValueFactory<T> valueFactory)
	{
		_key = key;
		_map = map;
		_valueFactory = valueFactory;
		LoroMap map2 = map.Get(_key)?.AsLoroMap() ?? map.InsertMapContainer(_key, new LoroMap());
		_valueSubject = new BehaviorSubject<T>(Deserialize(map2));
		_valueChildSubject = new BehaviorSubject<Unit>(Unit.Default);
		if (!(Value is IInternalEntity internalEntity))
		{
			throw new InvalidOperationException($"{"Value"} is {Value?.GetType().FullName ?? "null"} and does not implement {"IInternalEntity"}");
		}
		_valueChildSubscription = internalEntity.WhenChangeHappens.Select((Unit _) => Unit.Default).Subscribe(_valueChildSubject);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Set(T value)
	{
		if (value != Value && value is IInternalEntity internalEntity)
		{
			if (_valueSubject.Value is IInternalEntity internalEntity2)
			{
				internalEntity2.Dispose();
			}
			_valueChildSubscription.Dispose();
			_valueChildSubscription = internalEntity.WhenChangeHappens.Select((Unit _) => Unit.Default).Subscribe(_valueChildSubject);
			_valueSubject.OnNext(value);
			internalEntity.UpdateMapOnInternalMapUpdate(_map.InsertMapContainer(_key, internalEntity.LoroMap));
			_map.Doc()?.Commit();
		}
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length > 0 && updatedPaths[0].index is Pro.Loro.Index.Key key && key.key == _key)
		{
			OnDiffAffectingMe(updatedPaths.Slice(1), diff);
		}
	}

	public void UpdateMap(LoroMap map)
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

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
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

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				_valueChildSubscription.Dispose();
				_valueChildSubject.Dispose();
				(Value as IDisposable)?.Dispose();
				_valueSubject.Dispose();
			}
			_isDisposed = true;
		}
	}

	private void OnDiffAffectingMe(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.IsEmpty || (updatedPaths[0].index is Pro.Loro.Index.Key key && key.key == _valueFactory.SelectionKey))
		{
			LoroMap loroMap = _map.Get(_key)?.AsLoroMap() ?? _map.InsertMapContainer(_key, new LoroMap());
			if (Value is IInternalEntity internalEntity)
			{
				if (internalEntity.LoroMap.Id() == loroMap.Id())
				{
					internalEntity.OnDiff(updatedPaths, diff);
					return;
				}
				internalEntity.Dispose();
			}
			T val = _valueFactory.CreateInstance(loroMap);
			val.ThrowWhenNull("newValue");
			_valueChildSubscription.Dispose();
			_valueChildSubscription = ((val is IInternalEntity internalEntity2) ? internalEntity2.WhenChangeHappens.Subscribe(delegate
			{
				_valueChildSubject.OnNext(Unit.Default);
			}) : Disposable.Empty);
			_valueSubject.OnNext(val);
		}
		else if (Value is IInternalEntity internalEntity3)
		{
			LoroMap loroMap2 = _map.Get(_key)?.AsLoroMap() ?? _map.InsertMapContainer(_key, new LoroMap());
			if (loroMap2.Id() != internalEntity3.LoroMap.Id())
			{
				internalEntity3.UpdateMap(loroMap2);
			}
			internalEntity3.OnDiff(updatedPaths, diff);
		}
	}

	private T Deserialize(LoroMap map)
	{
		return _valueFactory.CreateInstance(map) ?? _valueFactory.CreateDefault(map);
	}
}
