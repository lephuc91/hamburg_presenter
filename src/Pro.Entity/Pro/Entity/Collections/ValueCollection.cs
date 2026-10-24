using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using Pro.Common.Utility;
using Pro.Entity.Extensions;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal abstract class ValueCollection<T> : IInternalCollection<T>, ICollection<T>, IDisposable, IDiffReceiver, IReceiveMapUpdates, IWhenChangeHappensSource where T : notnull
{
	private LoroMovableList _list;

	private readonly BehaviorSubject<IReadOnlyList<T>> _valueSubject;

	private readonly string _key;

	private readonly Func<T, LoroValue> _serialize;

	private readonly Func<ValueOrContainer?, T> _deserialize;

	public IObservable<Unit> WhenChangeHappens => WhenCollectionChanges.ToUnit();

	public IObservable<IReadOnlyList<T>> WhenCollectionChanges => _valueSubject;

	public IReadOnlyList<T> Items => _valueSubject.Value;

	protected ValueCollection(LoroMap containingMap, string key, Func<T, LoroValue> serialize, Func<ValueOrContainer?, T> deserialize)
	{
		_key = key;
		_serialize = serialize;
		_deserialize = deserialize;
		_list = GetList(containingMap, key);
		_valueSubject = new BehaviorSubject<IReadOnlyList<T>>(DeserializeList(_list, deserialize));
	}

	public void UpdateMap(LoroMap map)
	{
		_list = GetList(map, _key);
		NotifyIfChanged(DeserializeList(_list, _deserialize));
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
	{
		_list = GetList(map, _key);
	}

	public void Add(T item)
	{
		InternalAdd(item);
		Commit();
	}

	public void AddRange(IEnumerable<T> items)
	{
		bool flag = false;
		foreach (T item in items)
		{
			InternalAdd(item);
			flag = true;
		}
		if (flag)
		{
			Commit();
		}
	}

	public void Replace(int index, T item)
	{
		_list.Set((uint)index, _serialize(item).AsValueLike());
		Commit();
	}

	public void Insert(int index, T item)
	{
		_list.Insert((uint)index, _serialize(item).AsValueLike());
		Commit();
	}

	public void RemoveAt(int index)
	{
		_list.Delete((uint)index, 1u);
		Commit();
	}

	public void Move(int fromIndex, int toIndex)
	{
		if (fromIndex != toIndex)
		{
			_list.Mov((uint)fromIndex, (uint)toIndex);
			Commit();
		}
	}

	public void MoveMany(int fromIndex, int numberOfItemsToMove, int toIndex)
	{
		if (fromIndex > toIndex)
		{
			for (int i = 0; i < numberOfItemsToMove; i++)
			{
				_list.Mov((uint)(fromIndex + i), (uint)(toIndex + i));
			}
			Commit();
		}
		else if (fromIndex < toIndex)
		{
			for (int num = numberOfItemsToMove - 1; num >= 0; num--)
			{
				_list.Mov((uint)(fromIndex + num), (uint)(toIndex + num));
			}
			Commit();
		}
	}

	public void Clear()
	{
		if (Items.Count != 0)
		{
			InternalClear();
			Commit();
		}
	}

	public void Reset(IEnumerable<T> items)
	{
		InternalClear();
		AddRange(items);
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length != 0 && updatedPaths[0].index is Pro.Loro.Index.Key key && key.key == _key && updatedPaths.Slice(1).Length == 0)
		{
			NotifyIfChanged(DeserializeList(_list, _deserialize));
		}
	}

	private void InternalAdd(T item)
	{
		_list.Push(_serialize(item).AsValueLike());
	}

	private void InternalClear()
	{
		_list.Clear();
	}

	private void Commit()
	{
		_valueSubject.OnNext(DeserializeList(_list, _deserialize));
		_list.Doc()?.Commit();
	}

	private void NotifyIfChanged(IReadOnlyList<T> newValues)
	{
		if (!Equal(_valueSubject.Value, newValues))
		{
			_valueSubject.OnNext(newValues);
		}
	}

	private static IReadOnlyList<T> DeserializeList(ILoroMovableList list, Func<ValueOrContainer?, T> deserialize)
	{
		List<T> list2 = new List<T>();
		for (uint num = 0u; num < list.Len(); num++)
		{
			ValueOrContainer arg = list.Get(num);
			list2.Add(deserialize(arg));
		}
		return list2;
	}

	private static LoroMovableList GetList(ILoroMap map, string key)
	{
		return map.Get(key)?.AsLoroMovableList() ?? map.InsertMovableListContainer(key, new LoroMovableList());
	}

	protected virtual bool Equal(IReadOnlyList<T> a, IReadOnlyList<T> b)
	{
		if (a.Count == b.Count)
		{
			return a.SequenceEqual(b);
		}
		return false;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_valueSubject.Dispose();
			_list.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
