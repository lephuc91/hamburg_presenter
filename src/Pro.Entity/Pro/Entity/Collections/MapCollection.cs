using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.Utility;
using Pro.Entity.Factory;
using Pro.Entity.Properties;
using Pro.Loro;

namespace Pro.Entity.Collections;

internal sealed class MapCollection<T> : IDiffReceiver, IReceiveMapUpdates, IComplexCollection<T>, ICollection<T>, IWhenChangeHappensSource, IInternalCollection<T>, IDisposable where T : notnull
{
	private sealed class MapTransactionScope : IComplexCollection<T>.ISynchronizationScope, IDisposable
	{
		private bool _commitRequested;

		public ISynchronizationContext InnerScope { get; }

		public MapTransactionScope(ISynchronizationContext innerScope, MapCollection<T> collection)
		{
			InnerScope = innerScope;
			base._002Ector();
		}

		public void RequestCommit()
		{
			_commitRequested = true;
		}

		public void Dispose()
		{
			InnerScope.Dispose();
			if (_commitRequested)
			{
				_003Ccollection_003EP.Commit();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003CDeserializeInitial_003Ed__37 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ILoroMovableList values;

		public ILoroMovableList _003C_003E3__values;

		private IValueFactory<T> valueFactory;

		public IValueFactory<T> _003C_003E3__valueFactory;

		private uint _003Ci_003E5__2;

		T IEnumerator<T>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CDeserializeInitial_003Ed__37(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = 0u;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < values.Len())
			{
				LoroMap loroMap = values.Get(_003Ci_003E5__2)?.AsLoroMap();
				_003C_003E2__current = ((loroMap == null) ? valueFactory.CreateInstance() : valueFactory.CreateInstance(loroMap));
				_003C_003E1__state = 1;
				return true;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CDeserializeInitial_003Ed__37 _003CDeserializeInitial_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CDeserializeInitial_003Ed__ = this;
			}
			else
			{
				_003CDeserializeInitial_003Ed__ = new _003CDeserializeInitial_003Ed__37(0);
			}
			_003CDeserializeInitial_003Ed__.values = _003C_003E3__values;
			_003CDeserializeInitial_003Ed__.valueFactory = _003C_003E3__valueFactory;
			return _003CDeserializeInitial_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	private LoroMovableList _list;

	private readonly LockingList<T> _values;

	private readonly BehaviorSubject<IReadOnlyList<T>> _valueSubject;

	private readonly Subject<Unit> _anyChangeSubject = new Subject<Unit>();

	private readonly string _key;

	private readonly IValueFactory<T> _valueFactory;

	private readonly ConcurrentDictionary<IInternalEntity, IDisposable> _itemChangeSubscriptions = new ConcurrentDictionary<IInternalEntity, IDisposable>(ReferenceEqualityComparer.Instance);

	public IObservable<Unit> WhenChangeHappens => WhenAnyValueChanges;

	public IObservable<IReadOnlyList<T>> WhenCollectionChanges => _valueSubject;

	public IObservable<Unit> WhenAnyValueChanges { get; }

	public IReadOnlyList<T> Items => _values;

	public MapCollection(LoroMap containingMap, string key, IValueFactory<T> valueFactory)
	{
		_list = containingMap.Get(key)?.AsLoroMovableList() ?? containingMap.InsertMovableListContainer(key, new LoroMovableList());
		_key = key;
		_valueFactory = valueFactory;
		LockingList<T> lockingList = new LockingList<T>();
		foreach (T item in DeserializeInitial(_list, valueFactory))
		{
			lockingList.Add(item);
		}
		_values = lockingList;
		_valueSubject = new BehaviorSubject<IReadOnlyList<T>>(_values);
		WhenAnyValueChanges = _valueSubject.ToUnit().Merge(_anyChangeSubject);
		foreach (IInternalEntity item2 in _values.OfType<IInternalEntity>())
		{
			SubscribeToItemChanges(item2);
		}
	}

	public void UpdateMap(LoroMap map)
	{
		_list = map.Get(_key)?.AsLoroMovableList() ?? map.InsertMovableListContainer(_key, new LoroMovableList());
		if (_list.Len() != _values.Count)
		{
			ReconcileWithLoroList();
		}
		bool flag = false;
		for (int i = 0; i < _values.Count; i++)
		{
			LoroMap loroMap = _list.Get((uint)i)?.AsLoroMap();
			ContainerId containerId = loroMap?.Id();
			bool flag2 = false;
			for (int j = 0; j < _values.Count; j++)
			{
				if (_values[j] is IInternalEntity internalEntity && internalEntity.LoroMap.Id() == containerId)
				{
					if (j != i)
					{
						_values.Move(j, i);
						flag = true;
					}
					internalEntity.UpdateMap(loroMap);
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				LoroMap value = loroMap ?? _list.SetMapContainer((uint)i, new LoroMap());
				T val = Deserialize(value);
				if (_values.Replace(i, val) is IInternalEntity internalEntity2)
				{
					DisposeOfItemSubscription(internalEntity2);
					internalEntity2.Dispose();
				}
				if (val is IInternalEntity entity)
				{
					SubscribeToItemChanges(entity);
				}
				flag = true;
			}
		}
		if (flag)
		{
			_valueSubject.OnNext(_values);
		}
	}

	public void UpdateMapOnInternalMapUpdate(LoroMap map)
	{
		_list = map.Get(_key)?.AsLoroMovableList() ?? map.InsertMovableListContainer(_key, new LoroMovableList());
		if (_list.Len() != _values.Count)
		{
			ReconcileWithLoroList();
			return;
		}
		for (int i = 0; i < _values.Count; i++)
		{
			if (_values[i] is IInternalEntity internalEntity)
			{
				internalEntity.UpdateMapOnInternalMapUpdate(_list.Get((uint)i).AsLoroMap());
			}
		}
	}

	public void Add(T item)
	{
		InternalInsert((int)_list.Len(), item, Commit);
	}

	public void AddRange(IEnumerable<T> items)
	{
		bool hasAdditions = false;
		foreach (T item in items)
		{
			InternalInsert((int)_list.Len(), item, delegate
			{
				hasAdditions = true;
			});
		}
		if (hasAdditions)
		{
			Commit();
		}
	}

	public void Insert(int index, T item)
	{
		InternalInsert(index, item, Commit);
	}

	public void ScopedInsert(int index, T item, IComplexCollection<T>.ISynchronizationScope scope)
	{
		if (!(scope is MapTransactionScope mapTransactionScope))
		{
			throw new ArgumentException("Invalid lock scope type.", "scope");
		}
		if (item is IInternalEntity internalEntity)
		{
			SubscribeToItemChanges(internalEntity);
			_values.ScopedInsert(index, item, mapTransactionScope.InnerScope);
			internalEntity.UpdateMapOnInternalMapUpdate(_list.InsertMapContainer((uint)index, internalEntity.LoroMap));
			mapTransactionScope.RequestCommit();
		}
	}

	public void Replace(int index, T item)
	{
		if ((object)_values[index] != (object)item && item is IInternalEntity internalEntity)
		{
			if (_values.Replace(index, item) is IInternalEntity internalEntity2)
			{
				DisposeOfItemSubscription(internalEntity2);
				internalEntity2.Dispose();
			}
			SubscribeToItemChanges(internalEntity);
			internalEntity.UpdateMapOnInternalMapUpdate(_list.SetMapContainer((uint)index, internalEntity.LoroMap));
			Commit();
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void InternalInsert(int index, T item, System.Action onComplete)
	{
		if (item is IInternalEntity internalEntity)
		{
			SubscribeToItemChanges(internalEntity);
			_values.Insert(index, item);
			internalEntity.UpdateMapOnInternalMapUpdate(_list.InsertMapContainer((uint)index, internalEntity.LoroMap));
			onComplete();
		}
	}

	private void Commit()
	{
		_valueSubject.OnNext(_values);
		_list.Doc()?.Commit();
	}

	public void RemoveAt(int index)
	{
		if (_values.RemoveAtWithValue(index) is IInternalEntity internalEntity)
		{
			DisposeOfItemSubscription(internalEntity);
			internalEntity.Dispose();
		}
		_list.Delete((uint)index, 1u);
		Commit();
	}

	public void ScopedRemoveAt(int index, IComplexCollection<T>.ISynchronizationScope scope)
	{
		if (!(scope is MapTransactionScope mapTransactionScope))
		{
			throw new ArgumentException("Invalid lock scope type.", "scope");
		}
		if (_values.ScopedRemoveAtWithValue(index, mapTransactionScope.InnerScope) is IInternalEntity internalEntity)
		{
			DisposeOfItemSubscription(internalEntity);
			internalEntity.Dispose();
		}
		_list.Delete((uint)index, 1u);
		mapTransactionScope.RequestCommit();
	}

	public void Move(int fromIndex, int toIndex)
	{
		if (fromIndex != toIndex)
		{
			_values.Move(fromIndex, toIndex);
			_list.Mov((uint)fromIndex, (uint)toIndex);
			Commit();
		}
	}

	public void ScopedMove(int fromIndex, int toIndex, IComplexCollection<T>.ISynchronizationScope scope)
	{
		if (!(scope is MapTransactionScope mapTransactionScope))
		{
			throw new ArgumentException("Invalid lock scope type.", "scope");
		}
		if (fromIndex != toIndex)
		{
			_values.ScopedMove(fromIndex, toIndex, mapTransactionScope.InnerScope);
			_list.Mov((uint)fromIndex, (uint)toIndex);
			mapTransactionScope.RequestCommit();
		}
	}

	public void MoveMany(int fromIndex, int numberOfItemsToMove, int toIndex)
	{
		if (fromIndex > toIndex)
		{
			for (int i = 0; i < numberOfItemsToMove; i++)
			{
				_values.Move(fromIndex + i, toIndex + i);
				_list.Mov((uint)(fromIndex + i), (uint)(toIndex + i));
			}
			Commit();
		}
		else if (fromIndex < toIndex)
		{
			for (int num = numberOfItemsToMove - 1; num >= 0; num--)
			{
				_values.Move(fromIndex + num, toIndex + num);
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

	private void InternalClear()
	{
		foreach (IInternalEntity item in _values.RemoveAll((T _) => true).OfType<IInternalEntity>())
		{
			DisposeOfItemSubscription(item);
			item.Dispose();
		}
		_itemChangeSubscriptions.Clear();
		_list.Clear();
	}

	public void OnDiff(ReadOnlySpan<PathItem> updatedPaths, Diff diff)
	{
		if (updatedPaths.Length == 0 || !(updatedPaths[0].index is Pro.Loro.Index.Key key) || !(key.key == _key))
		{
			return;
		}
		ReadOnlySpan<PathItem> updatedPaths2 = updatedPaths.Slice(1);
		if (updatedPaths2.Length == 0)
		{
			if (!(diff is Diff.List))
			{
				throw new InvalidOperationException("Unexpected diff type " + diff.GetType().Name + " for a LoroMovableList container.");
			}
			ReconcileWithLoroList();
		}
		else
		{
			if (!(updatedPaths2[0].index is Pro.Loro.Index.Seq seq))
			{
				return;
			}
			updatedPaths2 = updatedPaths2.Slice(1);
			if (_values.Count == _list.Len())
			{
				uint index = seq.index;
				if (index < _values.Count && _values[(int)index] is IInternalEntity internalEntity)
				{
					internalEntity.OnDiff(updatedPaths2, diff);
				}
			}
			else
			{
				ReconcileWithLoroList();
			}
		}
	}

	public void SynchronizeFrom<TSource>(IEnumerable<TSource> source, Func<TSource, T, bool> equal, Func<TSource, T> create)
	{
		_values.SynchronizeFrom(source, equal, create, onInsert, delegate(int from, int to)
		{
			_list.Mov((uint)from, (uint)to);
		}, onRemove);
		Commit();
		void onInsert(T item, int index)
		{
			if (item is IInternalEntity internalEntity)
			{
				SubscribeToItemChanges(internalEntity);
				internalEntity.UpdateMapOnInternalMapUpdate(_list.InsertMapContainer((uint)index, internalEntity.LoroMap));
			}
		}
		void onRemove(T item, int index)
		{
			if (item is IInternalEntity internalEntity2)
			{
				DisposeOfItemSubscription(internalEntity2);
				internalEntity2.Dispose();
			}
			_list.Delete((uint)index, 1u);
		}
	}

	public IComplexCollection<T>.ISynchronizationScope EnterSyncContext()
	{
		return new MapTransactionScope(_values.EnterSyncContext(), this);
	}

	[IteratorStateMachine(typeof(MapCollection<>._003CDeserializeInitial_003Ed__37))]
	private static IEnumerable<T> DeserializeInitial(ILoroMovableList values, IValueFactory<T> valueFactory)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CDeserializeInitial_003Ed__37(-2)
		{
			_003C_003E3__values = values,
			_003C_003E3__valueFactory = valueFactory
		};
	}

	private void ReconcileWithLoroList()
	{
		int num = (int)_list.Len();
		List<T> list = new List<T>(num);
		HashSet<int> hashSet = new HashSet<int>();
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			LoroMap loroMap = _list.Get((uint)i)?.AsLoroMap();
			ContainerId containerId = loroMap?.Id();
			int num2 = -1;
			for (int j = 0; j < _values.Count; j++)
			{
				if (!hashSet.Contains(j) && _values[j] is IInternalEntity internalEntity && internalEntity.LoroMap.Id() == containerId)
				{
					num2 = j;
					break;
				}
			}
			if (num2 >= 0)
			{
				if (num2 != list.Count)
				{
					flag = true;
				}
				list.Add(_values[num2]);
				hashSet.Add(num2);
				continue;
			}
			LoroMap value = loroMap ?? _list.SetMapContainer((uint)i, new LoroMap());
			T val = Deserialize(value);
			if (val is IInternalEntity entity)
			{
				SubscribeToItemChanges(entity);
			}
			list.Add(val);
			flag = true;
		}
		for (int k = 0; k < _values.Count; k++)
		{
			if (!hashSet.Contains(k))
			{
				if (_values[k] is IInternalEntity internalEntity2)
				{
					DisposeOfItemSubscription(internalEntity2);
					internalEntity2.Dispose();
				}
				flag = true;
			}
		}
		if (flag)
		{
			_values.Reset(list);
			_valueSubject.OnNext(_values);
		}
	}

	private T Deserialize(LoroMap? value)
	{
		if (value != null)
		{
			return _valueFactory.CreateInstance(value);
		}
		return _valueFactory.CreateInstance();
	}

	private void SubscribeToItemChanges(IInternalEntity entity)
	{
		if (!_itemChangeSubscriptions.TryAdd(entity, entity.WhenChangeHappens.Subscribe(_anyChangeSubject)))
		{
			throw new InvalidOperationException("We should never have duplicate entities in the list, so TryAdd should always succeed");
		}
	}

	private void DisposeOfItemSubscription(IInternalEntity entity)
	{
		if (_itemChangeSubscriptions.TryRemove(entity, out IDisposable value))
		{
			value.Dispose();
		}
	}

	public void Dispose()
	{
		foreach (IInternalEntity item in _values.RemoveAll((T _) => true).OfType<IInternalEntity>())
		{
			DisposeOfItemSubscription(item);
			item.Dispose();
		}
		_itemChangeSubscriptions.Clear();
		_valueSubject.Dispose();
		_anyChangeSubject.Dispose();
		_list.Dispose();
	}
}
