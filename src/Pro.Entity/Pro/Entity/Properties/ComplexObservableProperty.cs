using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Common.Utility;
using Pro.Entity.Factory;
using Pro.Loro;

namespace Pro.Entity.Properties;

internal class ComplexObservableProperty<T> : IInternalObservableProperty<T>, IObservableProperty<T>, IDiffReceiver, IWhenChangeHappensSource, IComplexObservableProperty<T>, IReceiveMapUpdates, IDisposable where T : class
{
	private readonly string _key;

	private readonly Func<LoroMap, T> _deserialize;

	private readonly BehaviorSubject<T> _valueSubject;

	private readonly BehaviorSubject<Unit> _valueChildSubject;

	private readonly object _lock = new object();

	private IDisposable _valueChildSubscription;

	private bool _isDisposed;

	private LoroMap _map;

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges.ToUnit();

	public IObservable<T> WhenValueChanges => _valueSubject;

	public IObservable<T> WhenAnyValueChanges => from v in _valueSubject.CombineLatest(_valueChildSubject)
		select v.First;

	public T Value => _valueSubject.Value;

	public ComplexObservableProperty(string key, LoroMap map, IValueFactory<T> valueFactory)
		: this(key, map, (Func<LoroMap, T>)valueFactory.CreateInstance)
	{
	}

	public ComplexObservableProperty(string key, LoroMap map, Func<LoroMap, T> createNew)
	{
		_key = key;
		_map = map;
		_deserialize = createNew;
		_valueSubject = new BehaviorSubject<T>(Deserialize());
		_valueChildSubject = new BehaviorSubject<Unit>(Unit.Default);
		if (!(Value is IInternalEntity internalEntity))
		{
			throw new InvalidOperationException($"{"Value"} is {Value?.GetType().FullName ?? "null"} and does not implement {"IInternalEntity"}");
		}
		_valueChildSubscription = internalEntity.WhenChangeHappens.Subscribe(delegate
		{
			_valueChildSubject.OnNext(Unit.Default);
		});
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public void Set(T value)
	{
		lock (_lock)
		{
			if (Value != value)
			{
				if (!(value is IInternalEntity internalEntity))
				{
					throw new InvalidOperationException($"{"value"} is {value?.GetType().FullName ?? "null"} and does not implement {"IInternalEntity"}");
				}
				_valueChildSubscription.Dispose();
				IDisposable obj = Value as IDisposable;
				_valueChildSubscription = internalEntity.WhenChangeHappens.Subscribe(delegate
				{
					_valueChildSubject.OnNext(Unit.Default);
				});
				internalEntity.UpdateMapOnInternalMapUpdate(_map.InsertMapContainer(_key, internalEntity.LoroMap));
				_valueSubject.OnNext(value);
				obj?.Dispose();
				_map.Doc()?.Commit();
			}
		}
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		lock (_lock)
		{
			if (updatedPaths.Length > 0 && Value is IInternalEntity internalEntity && updatedPaths[0].index is Pro.Loro.Index.Key key && key.key == _key)
			{
				LoroMap loroMap = _map.Get(_key)?.AsLoroMap() ?? _map.InsertMapContainer(_key, new LoroMap());
				if (loroMap.Id() != internalEntity.LoroMap.Id())
				{
					internalEntity.UpdateMap(loroMap);
				}
				internalEntity.OnDiff(updatedPaths.Slice(1), diff);
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

	private T Deserialize()
	{
		return _deserialize(_map.Get(_key)?.AsLoroMap() ?? _map.InsertMapContainer(_key, new LoroMap()));
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed && disposing)
		{
			if (Value is IDisposable disposable)
			{
				disposable.Dispose();
			}
			_valueChildSubscription.Dispose();
			_valueChildSubject.Dispose();
			_valueSubject.Dispose();
			_isDisposed = true;
		}
	}
}
