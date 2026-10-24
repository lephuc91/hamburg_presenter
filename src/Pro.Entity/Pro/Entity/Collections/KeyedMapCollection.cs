using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Pro.Entity.CrdtKeySerializers;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class KeyedMapCollection<TKey, TValue> : IDiffReceiver, IReceiveMapUpdates, IKeyedCollection<TKey, TValue>, IDisposable, IWhenChangeHappensSource where TKey : notnull where TValue : notnull
{
	private LoroMap _innerMap;

	private readonly string _containerKey;

	private readonly IValueFactory<TValue> _valueFactory;

	private readonly ICrdtKeySerializer<TKey> _keySerializer;

	private readonly BehaviorSubject<IReadOnlyDictionary<TKey, TValue>> _valueSubject;

	private readonly Subject<Unit> _anyChangeSubject = new Subject<Unit>();

	private readonly ConcurrentDictionary<IInternalEntity, IDisposable> _itemChangeSubscriptions = new ConcurrentDictionary<IInternalEntity, IDisposable>(ReferenceEqualityComparer.Instance);

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges;

	public IObservable<IReadOnlyDictionary<TKey, TValue>> WhenCollectionChanges => _valueSubject;

	public IObservable<Unit> WhenAnyValueChanges { get; }

	public IReadOnlyDictionary<TKey, TValue> Items => _valueSubject.Value;

	public KeyedMapCollection(LoroMap containingMap, string containerKey, IValueFactory<TValue> valueFactory, ICrdtKeySerializer<TKey> keySerializer)
	{
		_containerKey = containerKey;
		_valueFactory = valueFactory;
		_keySerializer = keySerializer;
		_innerMap = containingMap.Get(containerKey)?.AsLoroMap() ?? containingMap.InsertMapContainer(containerKey, new LoroMap());
		IReadOnlyDictionary<TKey, TValue> readOnlyDictionary = Deserialize(_innerMap, valueFactory, keySerializer);
		_valueSubject = new BehaviorSubject<IReadOnlyDictionary<TKey, TValue>>(readOnlyDictionary);
		WhenAnyValueChanges = _valueSubject.Select((IReadOnlyDictionary<TKey, TValue> _) => Unit.Default).Merge(_anyChangeSubject);
		foreach (IInternalEntity item in readOnlyDictionary.Values.OfType<IInternalEntity>())
		{
			SubscribeToItemChanges(item);
		}
	}

	public void UpdateMap(LoroMap map)
	{
		_innerMap = map.Get(_containerKey)?.AsLoroMap() ?? map.InsertMapContainer(_containerKey, new LoroMap());
		IReadOnlyDictionary<TKey, TValue> readOnlyDictionary = Deserialize(_innerMap, _valueFactory, _keySerializer);
		if (!DictionaryEqual(_valueSubject.Value, readOnlyDictionary))
		{
			foreach (IInternalEntity item in _valueSubject.Value.Values.OfType<IInternalEntity>())
			{
				DisposeItemSubscription(item);
				item.Dispose();
			}
			foreach (IInternalEntity item2 in readOnlyDictionary.Values.OfType<IInternalEntity>())
			{
				SubscribeToItemChanges(item2);
			}
			_valueSubject.OnNext(readOnlyDictionary);
			return;
		}
		foreach (KeyValuePair<TKey, TValue> item3 in readOnlyDictionary)
		{
			string key = _keySerializer.Serialize(item3.Key);
			if (item3.Value is IInternalEntity internalEntity)
			{
				LoroMap loroMap = _innerMap.Get(key)?.AsLoroMap();
				if (loroMap != null)
				{
					internalEntity.UpdateMap(loroMap);
				}
			}
		}
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
	{
		_innerMap = map.Get(_containerKey)?.AsLoroMap() ?? map.InsertMapContainer(_containerKey, new LoroMap());
		foreach (KeyValuePair<TKey, TValue> item in _valueSubject.Value)
		{
			string key = _keySerializer.Serialize(item.Key);
			if (item.Value is IInternalEntity internalEntity)
			{
				LoroMap loroMap = _innerMap.Get(key)?.AsLoroMap();
				if (loroMap != null)
				{
					internalEntity.UpdateMapOnInternalMapUpdate(loroMap);
				}
			}
		}
	}

	public void Add(TKey key, TValue item)
	{
		string crdtKey = _keySerializer.Serialize(key);
		InsertItem(key, crdtKey, item);
		_innerMap.Doc()?.Commit();
	}

	public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
	{
		bool flag = false;
		foreach (KeyValuePair<TKey, TValue> item in items)
		{
			string crdtKey = _keySerializer.Serialize(item.Key);
			InsertItem(item.Key, crdtKey, item.Value);
			flag = true;
		}
		if (flag)
		{
			_innerMap.Doc()?.Commit();
		}
	}

	public void Remove(TKey key)
	{
		if (_valueSubject.Value.TryGetValue(key, out var value))
		{
			if (value is IInternalEntity internalEntity)
			{
				DisposeItemSubscription(internalEntity);
				internalEntity.Dispose();
			}
			string key2 = _keySerializer.Serialize(key);
			_innerMap.Delete(key2);
			Dictionary<TKey, TValue> dictionary = CopyDict(_valueSubject.Value);
			dictionary.Remove(key);
			_valueSubject.OnNext(dictionary);
			_innerMap.Doc()?.Commit();
		}
	}

	public void Clear()
	{
		if (_valueSubject.Value.Count == 0)
		{
			return;
		}
		foreach (IInternalEntity item in _valueSubject.Value.Values.OfType<IInternalEntity>())
		{
			DisposeItemSubscription(item);
			item.Dispose();
		}
		foreach (TKey item2 in _valueSubject.Value.Keys.ToList())
		{
			_innerMap.Delete(_keySerializer.Serialize(item2));
		}
		_valueSubject.OnNext(new Dictionary<TKey, TValue>());
		_innerMap.Doc()?.Commit();
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length == 0 || !(updatedPaths[0].index is Pro.Loro.Index.Key key) || !(key.key == _containerKey))
		{
			return;
		}
		ReadOnlySpan<PathItem> readOnlySpan = updatedPaths.Slice(1);
		TKey result2;
		TValue value3;
		if (readOnlySpan.Length == 0)
		{
			IReadOnlyDictionary<TKey, TValue> value = _valueSubject.Value;
			Dictionary<TKey, TValue> dictionary = CopyDict(value);
			bool flag = false;
			if (_innerMap.GetDeepValue() is LoroValue.Map map)
			{
				HashSet<string> hashSet = new HashSet<string>(map.value.Keys);
				foreach (KeyValuePair<TKey, TValue> item in value)
				{
					if (!hashSet.Contains(_keySerializer.Serialize(item.Key)))
					{
						dictionary.Remove(item.Key);
						if (item.Value is IInternalEntity internalEntity)
						{
							DisposeItemSubscription(internalEntity);
							internalEntity.Dispose();
						}
						flag = true;
					}
				}
				foreach (string item2 in hashSet)
				{
					if (!_keySerializer.TryDeserialize(item2, out var result))
					{
						continue;
					}
					if (value.TryGetValue(result, out var value2))
					{
						if (value2 is IInternalEntity internalEntity2)
						{
							LoroMap loroMap = _innerMap.Get(item2)?.AsLoroMap();
							if (loroMap != null)
							{
								internalEntity2.UpdateMap(loroMap);
							}
						}
						continue;
					}
					LoroMap loroMap2 = _innerMap.Get(item2)?.AsLoroMap();
					if (loroMap2 != null)
					{
						TValue val2 = (dictionary[result] = _valueFactory.CreateInstance(loroMap2));
						if (val2 is IInternalEntity entity)
						{
							SubscribeToItemChanges(entity);
						}
						flag = true;
					}
				}
			}
			else if (value.Count > 0)
			{
				foreach (IInternalEntity item3 in value.Values.OfType<IInternalEntity>())
				{
					DisposeItemSubscription(item3);
					item3.Dispose();
				}
				dictionary.Clear();
				flag = true;
			}
			if (flag)
			{
				_valueSubject.OnNext(dictionary);
			}
		}
		else if (readOnlySpan[0].index is Pro.Loro.Index.Key key2 && _keySerializer.TryDeserialize(key2.key, out result2) && _valueSubject.Value.TryGetValue(result2, out value3) && value3 is IInternalEntity internalEntity3)
		{
			internalEntity3.OnDiff(readOnlySpan.Slice(1), diff);
		}
	}

	public void Dispose()
	{
		foreach (IInternalEntity item in _valueSubject.Value.Values.OfType<IInternalEntity>())
		{
			DisposeItemSubscription(item);
			item.Dispose();
		}
		_valueSubject.Dispose();
		_anyChangeSubject.Dispose();
		_innerMap.Dispose();
	}

	private void InsertItem(TKey key, string crdtKey, TValue item)
	{
		if (_valueSubject.Value.TryGetValue(key, out var value) && value is IInternalEntity internalEntity)
		{
			DisposeItemSubscription(internalEntity);
			internalEntity.Dispose();
		}
		if (item is IInternalEntity internalEntity2)
		{
			SubscribeToItemChanges(internalEntity2);
			internalEntity2.UpdateMapOnInternalMapUpdate(_innerMap.InsertMapContainer(crdtKey, internalEntity2.LoroMap));
		}
		Dictionary<TKey, TValue> dictionary = CopyDict(_valueSubject.Value);
		dictionary[key] = item;
		_valueSubject.OnNext(dictionary);
	}

	private void SubscribeToItemChanges(IInternalEntity entity)
	{
		IDisposable value = entity.WhenChangeHappens.Subscribe(delegate
		{
			_anyChangeSubject.OnNext(Unit.Default);
		});
		_itemChangeSubscriptions.TryAdd(entity, value);
	}

	private void DisposeItemSubscription(IInternalEntity entity)
	{
		if (_itemChangeSubscriptions.TryRemove(entity, out IDisposable value))
		{
			value.Dispose();
		}
	}

	private static IReadOnlyDictionary<TKey, TValue> Deserialize(LoroMap innerMap, IValueFactory<TValue> factory, ICrdtKeySerializer<TKey> keySerializer)
	{
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
		if (innerMap.GetDeepValue() is LoroValue.Map map)
		{
			foreach (string key in map.value.Keys)
			{
				LoroMap loroMap = innerMap.Get(key)?.AsLoroMap();
				if (loroMap != null && keySerializer.TryDeserialize(key, out TKey result))
				{
					dictionary[result] = factory.CreateInstance(loroMap);
				}
			}
		}
		return dictionary;
	}

	private static bool DictionaryEqual(IReadOnlyDictionary<TKey, TValue> a, IReadOnlyDictionary<TKey, TValue> b)
	{
		if (a.Count != b.Count)
		{
			return false;
		}
		foreach (KeyValuePair<TKey, TValue> item in a)
		{
			if (!b.TryGetValue(item.Key, out TValue value) || (object)item.Value != (object)value)
			{
				return false;
			}
		}
		return true;
	}

	private static Dictionary<TKey, TValue> CopyDict(IReadOnlyDictionary<TKey, TValue> source)
	{
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(source.Count);
		foreach (KeyValuePair<TKey, TValue> item in source)
		{
			dictionary[item.Key] = item.Value;
		}
		return dictionary;
	}
}
