using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using Pro.Common.Collections.Concurrency.Locking;
using Pro.Common.Utility;
using Pro.Entity.Collections;
using Pro.Entity.Merged.Entities;

namespace Pro.Entity.Merged.Collections;

public sealed class MergedCollection<TRemote, TLocal, TMerged> : IMergedCollection<TMerged>, Pro.Entity.Collections.ICollection<TMerged>, IDisposable where TRemote : notnull where TLocal : notnull where TMerged : TRemote, TLocal, IDisposable
{
	[CompilerGenerated]
	private sealed class _003CInitializeMerged_003Ed__34 : IEnumerable<TMerged>, IEnumerable, IEnumerator<TMerged>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private TMerged _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IComplexCollection<TRemote> remote;

		public IComplexCollection<TRemote> _003C_003E3__remote;

		private IComplexCollection<TLocal> local;

		public IComplexCollection<TLocal> _003C_003E3__local;

		private Func<TRemote, TLocal, bool> equal;

		public Func<TRemote, TLocal, bool> _003C_003E3__equal;

		private Action<TRemote, TLocal, SyncDirection> initializeSync;

		public Action<TRemote, TLocal, SyncDirection> _003C_003E3__initializeSync;

		private Func<TRemote, TLocal, TMerged> createMerged;

		public Func<TRemote, TLocal, TMerged> _003C_003E3__createMerged;

		private Func<TRemote, TLocal> createLocal;

		public Func<TRemote, TLocal> _003C_003E3__createLocal;

		private int _003CremoteIndex_003E5__2;

		TMerged IEnumerator<TMerged>.Current
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
		public _003CInitializeMerged_003Ed__34(int _003C_003E1__state)
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
				_003CremoteIndex_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				goto IL_00f9;
			case 2:
				{
					_003C_003E1__state = -1;
					goto IL_00f9;
				}
				IL_00f9:
				_003CremoteIndex_003E5__2++;
				break;
			}
			if (_003CremoteIndex_003E5__2 < remote.Items.Count)
			{
				TRemote val = remote.Items[_003CremoteIndex_003E5__2];
				if (MergedCollection<TRemote, TLocal, TMerged>.TryFindValue(val, local, equal, _003CremoteIndex_003E5__2, out TLocal found))
				{
					initializeSync(val, found, SyncDirection.RemoteToLocal);
					_003C_003E2__current = createMerged(val, found);
					_003C_003E1__state = 1;
					return true;
				}
				TLocal val2 = createLocal(remote.Items[_003CremoteIndex_003E5__2]);
				local.Insert(_003CremoteIndex_003E5__2, val2);
				initializeSync(val, val2, SyncDirection.RemoteToLocal);
				_003C_003E2__current = createMerged(val, val2);
				_003C_003E1__state = 2;
				return true;
			}
			for (int num = local.Items.Count - 1; num >= remote.Items.Count; num--)
			{
				local.RemoveAt(num);
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
		IEnumerator<TMerged> IEnumerable<TMerged>.GetEnumerator()
		{
			_003CInitializeMerged_003Ed__34 _003CInitializeMerged_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CInitializeMerged_003Ed__ = this;
			}
			else
			{
				_003CInitializeMerged_003Ed__ = new _003CInitializeMerged_003Ed__34(0);
			}
			_003CInitializeMerged_003Ed__.remote = _003C_003E3__remote;
			_003CInitializeMerged_003Ed__.local = _003C_003E3__local;
			_003CInitializeMerged_003Ed__.createMerged = _003C_003E3__createMerged;
			_003CInitializeMerged_003Ed__.equal = _003C_003E3__equal;
			_003CInitializeMerged_003Ed__.createLocal = _003C_003E3__createLocal;
			_003CInitializeMerged_003Ed__.initializeSync = _003C_003E3__initializeSync;
			return _003CInitializeMerged_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<TMerged>)this).GetEnumerator();
		}
	}

	private readonly IComplexCollection<TRemote> _remote;

	private readonly IComplexCollection<TLocal> _local;

	private readonly Func<TRemote, TLocal, TMerged> _merge;

	private readonly Func<TRemote, TLocal, bool> _equal;

	private readonly Func<TRemote, TLocal> _createLocal;

	private readonly Func<TLocal, TRemote> _createRemote;

	private readonly Func<TMerged, TRemote> _getRemote;

	private readonly Func<TMerged, TLocal> _getLocal;

	private readonly Action<TRemote, TLocal, SyncDirection> _initializeSync;

	private readonly LockingList<TMerged> _merged;

	private readonly BehaviorSubject<IReadOnlyList<TMerged>> _mergedSubject;

	private readonly CompositeDisposable _disposables = new CompositeDisposable();

	private bool _isSynchronizing;

	public IObservable<Unit> WhenAnyValueChanges => _local.WhenAnyValueChanges.Merge(_remote.WhenAnyValueChanges);

	public IObservable<IReadOnlyList<TMerged>> WhenCollectionChanges => _mergedSubject;

	public IReadOnlyList<TMerged> Items => _merged;

	public MergedCollection(IComplexCollection<TRemote> remote, IComplexCollection<TLocal> local, Func<TRemote, TLocal, TMerged> merge, Func<TRemote, TLocal, bool> equal, Func<TRemote, TLocal> createLocal, Func<TLocal, TRemote> createRemote, Action<TRemote, TLocal, SyncDirection> initializeSync, Func<TMerged, TRemote> getRemote, Func<TMerged, TLocal> getLocal)
	{
		_remote = remote;
		_local = local;
		_merge = merge;
		_equal = equal;
		_createLocal = createLocal;
		_createRemote = createRemote;
		_initializeSync = initializeSync;
		_getRemote = getRemote;
		_getLocal = getLocal;
		_merged = new LockingList<TMerged>(InitializeMerged(remote, local, merge, equal, createLocal, initializeSync));
		_mergedSubject = new BehaviorSubject<IReadOnlyList<TMerged>>(_merged);
		_mergedSubject.DisposeWith(_disposables);
		_remote.WhenCollectionChanges.Subscribe(OnRemoteChanged).DisposeWith(_disposables);
		_local.WhenCollectionChanges.Subscribe(OnLocalChanged).DisposeWith(_disposables);
	}

	public void Add(TMerged item)
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.Add(_getRemote(item));
			_local.Add(_getLocal(item));
			_merged.Insert(_merged.Count, item);
			_mergedSubject.OnNext(_merged);
		});
	}

	public void AddRange(IEnumerable<TMerged> items)
	{
		ExecuteWithBounceProtection(delegate
		{
			List<TMerged> list = items.ToList();
			_remote.AddRange(list.Select(_getRemote));
			_local.AddRange(list.Select(_getLocal));
			foreach (TMerged item in list)
			{
				_merged.Insert(_merged.Count, item);
			}
			_mergedSubject.OnNext(_merged);
		});
	}

	public void Clear()
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.Clear();
			_local.Clear();
			foreach (TMerged item in _merged.RemoveAll((TMerged _) => true))
			{
				item.Dispose();
			}
			_mergedSubject.OnNext(_merged);
		});
	}

	public void Insert(int index, TMerged item)
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.Insert(index, _getRemote(item));
			_local.Insert(index, _getLocal(item));
			_merged.Insert(index, item);
			_mergedSubject.OnNext(_merged);
		});
	}

	public void Move(int fromIndex, int toIndex)
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.Move(fromIndex, toIndex);
			_local.Move(fromIndex, toIndex);
			_merged.Move(fromIndex, toIndex);
			_mergedSubject.OnNext(_merged);
		});
	}

	public void MoveMany(int fromIndex, int numberOfItemsToMove, int toIndex)
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.MoveMany(fromIndex, numberOfItemsToMove, toIndex);
			_local.MoveMany(fromIndex, numberOfItemsToMove, toIndex);
			if (fromIndex > toIndex)
			{
				for (int i = 0; i < numberOfItemsToMove; i++)
				{
					_merged.Move(fromIndex + i, toIndex + i);
				}
			}
			else if (fromIndex < toIndex)
			{
				for (int num = numberOfItemsToMove - 1; num >= 0; num--)
				{
					_merged.Move(fromIndex + num, toIndex + num);
				}
			}
			_mergedSubject.OnNext(_merged);
		});
	}

	public void RemoveAt(int index)
	{
		ExecuteWithBounceProtection(delegate
		{
			_remote.RemoveAt(index);
			_local.RemoveAt(index);
			_merged.RemoveAtWithValue(index).Dispose();
			_mergedSubject.OnNext(_merged);
		});
	}

	public void Replace(int index, TMerged item)
	{
		if ((object)_merged[index] != (object)item)
		{
			ExecuteWithBounceProtection(delegate
			{
				_remote.Replace(index, _getRemote(item));
				_local.Replace(index, _getLocal(item));
				_merged.Replace(index, item).Dispose();
				_mergedSubject.OnNext(_merged);
			});
		}
	}

	public void Reset(IEnumerable<TMerged> items)
	{
		Clear();
		AddRange(items);
	}

	public void SynchronizeFrom<TSource>(IEnumerable<TSource> source, Func<TSource, TMerged, bool> equal, Func<TSource, TMerged> create)
	{
		ExecuteWithBounceProtection(delegate
		{
			bool changed = false;
			IComplexCollection<TLocal>.ISynchronizationScope localSyncContext = _local.EnterSyncContext();
			try
			{
				IComplexCollection<TRemote>.ISynchronizationScope remoteSyncContext = _remote.EnterSyncContext();
				try
				{
					_merged.SynchronizeFrom(source, equal, create, delegate(TMerged value, int index)
					{
						_remote.ScopedInsert(index, _getRemote(value), remoteSyncContext);
						_local.ScopedInsert(index, _getLocal(value), localSyncContext);
						changed = true;
					}, delegate(int from, int to)
					{
						_remote.ScopedMove(from, to, remoteSyncContext);
						_local.ScopedMove(from, to, localSyncContext);
						changed = true;
					}, delegate(TMerged value, int index)
					{
						_remote.ScopedRemoveAt(index, remoteSyncContext);
						_local.ScopedRemoveAt(index, localSyncContext);
						changed = true;
					});
				}
				finally
				{
					if (remoteSyncContext != null)
					{
						remoteSyncContext.Dispose();
					}
				}
			}
			finally
			{
				if (localSyncContext != null)
				{
					localSyncContext.Dispose();
				}
			}
			if (changed)
			{
				_mergedSubject.OnNext(_merged);
			}
		});
	}

	public void Dispose()
	{
		foreach (TMerged item in _merged.RemoveAll((TMerged _) => true))
		{
			item.Dispose();
		}
		_disposables.Dispose();
	}

	private void OnRemoteChanged(IReadOnlyList<TRemote> newRemote)
	{
		ExecuteWithBounceProtection(delegate
		{
			bool changed = false;
			IComplexCollection<TLocal>.ISynchronizationScope localContext = _local.EnterSyncContext();
			try
			{
				_merged.SynchronizeFrom(newRemote, (TRemote remote, TMerged merged) => _equal(remote, _getLocal(merged)), delegate(TRemote remote)
				{
					TLocal arg = _createLocal(remote);
					_initializeSync(remote, arg, SyncDirection.RemoteToLocal);
					return _merge(remote, arg);
				}, delegate(TMerged value, int index)
				{
					_local.ScopedInsert(index, _getLocal(value), localContext);
					changed = true;
				}, delegate(int from, int to)
				{
					_local.ScopedMove(from, to, localContext);
					changed = true;
				}, delegate(TMerged value, int index)
				{
					_local.ScopedRemoveAt(index, localContext);
					changed = true;
				});
			}
			finally
			{
				if (localContext != null)
				{
					localContext.Dispose();
				}
			}
			if (changed)
			{
				_mergedSubject.OnNext(_merged);
			}
		});
	}

	private void OnLocalChanged(IReadOnlyList<TLocal> newLocal)
	{
		ExecuteWithBounceProtection(delegate
		{
			bool changed = false;
			IComplexCollection<TRemote>.ISynchronizationScope remoteContext = _remote.EnterSyncContext();
			try
			{
				_merged.SynchronizeFrom(newLocal, (TLocal local, TMerged merged) => _equal(_getRemote(merged), local), delegate(TLocal local)
				{
					TRemote arg = _createRemote(local);
					_initializeSync(arg, local, SyncDirection.LocalToRemote);
					return _merge(arg, local);
				}, delegate(TMerged value, int index)
				{
					_remote.ScopedInsert(index, _getRemote(value), remoteContext);
					changed = true;
				}, delegate(int from, int to)
				{
					_remote.ScopedMove(from, to, remoteContext);
					changed = true;
				}, delegate(TMerged value, int index)
				{
					_remote.ScopedRemoveAt(index, remoteContext);
					changed = true;
				});
			}
			finally
			{
				if (remoteContext != null)
				{
					remoteContext.Dispose();
				}
			}
			if (changed)
			{
				_mergedSubject.OnNext(_merged);
			}
		});
	}

	private void ExecuteWithBounceProtection(System.Action action)
	{
		if (!Interlocked.CompareExchange(ref _isSynchronizing, value: true, comparand: false))
		{
			try
			{
				action();
			}
			finally
			{
				Interlocked.Exchange(ref _isSynchronizing, value: false);
			}
		}
	}

	[IteratorStateMachine(typeof(MergedCollection<, , >._003CInitializeMerged_003Ed__34))]
	private static IEnumerable<TMerged> InitializeMerged(IComplexCollection<TRemote> remote, IComplexCollection<TLocal> local, Func<TRemote, TLocal, TMerged> createMerged, Func<TRemote, TLocal, bool> equal, Func<TRemote, TLocal> createLocal, Action<TRemote, TLocal, SyncDirection> initializeSync)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CInitializeMerged_003Ed__34(-2)
		{
			_003C_003E3__remote = remote,
			_003C_003E3__local = local,
			_003C_003E3__createMerged = createMerged,
			_003C_003E3__equal = equal,
			_003C_003E3__createLocal = createLocal,
			_003C_003E3__initializeSync = initializeSync
		};
	}

	private static bool TryFindValue<TSource, TDestination>(TSource source, IComplexCollection<TDestination> destination, Func<TSource, TDestination, bool> equal, int searchIndexStart, [NotNullWhen(true)] out TDestination? found) where TDestination : notnull
	{
		for (int i = searchIndexStart; i < destination.Items.Count; i++)
		{
			TDestination val = destination.Items[i];
			if (equal(source, val))
			{
				if (i != searchIndexStart)
				{
					destination.Move(i, searchIndexStart);
				}
				found = val;
				return true;
			}
		}
		found = default(TDestination);
		return false;
	}
}
