using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Logging;

namespace Pro.Common.Collections;

public class PairedCollection<C, S, T> : ImmutableObservableCollection<T> where C : class, INotifyEnumerableChanged<S>
{
	public delegate T GenerateTargetDelegate(S sourceItem);

	public delegate void TeardownTargetDelegate(T targetItem);

	[CompilerGenerated]
	private sealed class _003CMapEnumerable_003Ed__17 : IEnumerable<S>, IEnumerable, IEnumerator<S>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private S _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> items;

		public IEnumerable<T> _003C_003E3__items;

		public PairedCollection<C, S, T> _003C_003E4__this;

		private IEnumerable<S> source;

		public IEnumerable<S> _003C_003E3__source;

		private IEnumerator<T> _003C_003E7__wrap1;

		private int _003Cindex_003E5__3;

		private IEnumerator<S> _003Cenumerator_003E5__4;

		S IEnumerator<S>.Current
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
		public _003CMapEnumerable_003Ed__17(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Cenumerator_003E5__4 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PairedCollection<C, S, T> pairedCollection = _003C_003E4__this;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					_003C_003E1__state = -3;
					goto IL_0096;
				}
				_003C_003E1__state = -1;
				_003C_003E7__wrap1 = items.GetEnumerator();
				_003C_003E1__state = -3;
				goto IL_00bc;
				IL_00a8:
				if (_003Cenumerator_003E5__4.MoveNext())
				{
					if (_003Cindex_003E5__3 == 0)
					{
						_003C_003E2__current = _003Cenumerator_003E5__4.Current;
						_003C_003E1__state = 1;
						return true;
					}
					goto IL_0096;
				}
				_003Cenumerator_003E5__4 = null;
				goto IL_00bc;
				IL_0096:
				_003Cindex_003E5__3--;
				goto IL_00a8;
				IL_00bc:
				if (_003C_003E7__wrap1.MoveNext())
				{
					T current = _003C_003E7__wrap1.Current;
					_003Cindex_003E5__3 = pairedCollection.IndexOf(current);
					_003Cenumerator_003E5__4 = source.GetEnumerator();
					goto IL_00a8;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<S> IEnumerable<S>.GetEnumerator()
		{
			_003CMapEnumerable_003Ed__17 _003CMapEnumerable_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CMapEnumerable_003Ed__ = this;
			}
			else
			{
				_003CMapEnumerable_003Ed__ = new _003CMapEnumerable_003Ed__17(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CMapEnumerable_003Ed__.source = _003C_003E3__source;
			_003CMapEnumerable_003Ed__.items = _003C_003E3__items;
			return _003CMapEnumerable_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<S>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CMapList_003Ed__16 : IEnumerable<S>, IEnumerable, IEnumerator<S>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private S _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> items;

		public IEnumerable<T> _003C_003E3__items;

		public PairedCollection<C, S, T> _003C_003E4__this;

		private IList<S> source;

		public IList<S> _003C_003E3__source;

		private IEnumerator<T> _003C_003E7__wrap1;

		S IEnumerator<S>.Current
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
		public _003CMapList_003Ed__16(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PairedCollection<C, S, T> pairedCollection = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = items.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					T current = _003C_003E7__wrap1.Current;
					int num2 = pairedCollection.IndexOf(current);
					if (num2 >= 0 && num2 < source.Count)
					{
						_003C_003E2__current = source[num2];
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<S> IEnumerable<S>.GetEnumerator()
		{
			_003CMapList_003Ed__16 _003CMapList_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CMapList_003Ed__ = this;
			}
			else
			{
				_003CMapList_003Ed__ = new _003CMapList_003Ed__16(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CMapList_003Ed__.source = _003C_003E3__source;
			_003CMapList_003Ed__.items = _003C_003E3__items;
			return _003CMapList_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<S>)this).GetEnumerator();
		}
	}

	private readonly GenerateTargetDelegate _generateTarget;

	private readonly TeardownTargetDelegate? _teardownTarget;

	protected C? SourceCollection { get; private set; }

	public PairedCollection(C? sourceCollection, GenerateTargetDelegate generateTarget, TeardownTargetDelegate? teardownTarget = null)
	{
		_generateTarget = generateTarget;
		_teardownTarget = teardownTarget;
		ChangeSource(sourceCollection);
	}

	public void Refresh()
	{
		if (_teardownTarget != null)
		{
			base.Collection.ForEach(delegate(T t)
			{
				_teardownTarget(t);
			});
		}
		base.Collection.Clear();
		GenerateTargets();
	}

	public void Refresh(S item)
	{
		int num = SourceCollection?.IndexOf(item) ?? (-1);
		if (num >= 0)
		{
			_teardownTarget?.Invoke(base.Collection[num]);
			base.Collection[num] = _generateTarget(item);
		}
	}

	public void ClearSource()
	{
		ChangeSource(null);
	}

	public void ChangeSource(C? sourceCollection)
	{
		if (SourceCollection != null)
		{
			SourceCollection.CollectionChanged -= OnSourceCollectionChanged;
			if (_teardownTarget != null)
			{
				base.Collection.ForEach(delegate(T t)
				{
					_teardownTarget(t);
				});
			}
			base.Collection.Clear();
		}
		SourceCollection = sourceCollection;
		GenerateTargets();
		if (SourceCollection != null)
		{
			SourceCollection.CollectionChanged += OnSourceCollectionChanged;
		}
	}

	public T? GetTargetForSource(S sourceItem)
	{
		return base.Collection.ElementAtOrDefault(SourceCollection?.IndexOf(sourceItem) ?? (-1));
	}

	public S? GetSourceForTarget(T targetItem)
	{
		if (SourceCollection == null)
		{
			return default(S);
		}
		return SourceCollection.ElementAtOrDefault(base.Collection.IndexOf(targetItem));
	}

	protected IEnumerable<S> Map(IEnumerable<T> items)
	{
		C sourceCollection = SourceCollection;
		if (!(sourceCollection is IList<S> source))
		{
			IEnumerable<S> enumerable = sourceCollection;
			if (enumerable != null)
			{
				return MapEnumerable(enumerable, items);
			}
			return Enumerable.Empty<S>();
		}
		return MapList(source, items);
	}

	[IteratorStateMachine(typeof(PairedCollection<, , >._003CMapList_003Ed__16))]
	private IEnumerable<S> MapList(IList<S> source, IEnumerable<T> items)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CMapList_003Ed__16(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__source = source,
			_003C_003E3__items = items
		};
	}

	[IteratorStateMachine(typeof(PairedCollection<, , >._003CMapEnumerable_003Ed__17))]
	private IEnumerable<S> MapEnumerable(IEnumerable<S> source, IEnumerable<T> items)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CMapEnumerable_003Ed__17(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__source = source,
			_003C_003E3__items = items
		};
	}

	private void GenerateTargets()
	{
		SourceCollection?.Select((S s) => _generateTarget(s)).ForEach(base.Collection.Add);
	}

	private void OnSourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (IsOutOfSync(e))
		{
			Log.Error("PairedCollection target ({0} items) is out of sync with its source for a {1} change; regenerating targets.", base.Collection.Count, e.Action);
			Refresh();
			return;
		}
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			(from s in e.NewItems.Cast<S>().Reverse()
				select _generateTarget(s)).ForEach(delegate(T t)
			{
				base.Collection.Insert(e.NewStartingIndex, t);
			});
			break;
		case NotifyCollectionChangedAction.Remove:
			if (_teardownTarget != null)
			{
				base.Collection.Skip(e.OldStartingIndex).Take(e.OldItems.Count).ForEach(delegate(T t)
				{
					_teardownTarget(t);
				});
			}
			base.Collection.RemoveAtRange(e.OldStartingIndex, e.OldItems.Count);
			break;
		case NotifyCollectionChangedAction.Move:
			base.Collection.Move(e.OldStartingIndex, e.NewStartingIndex);
			break;
		case NotifyCollectionChangedAction.Replace:
		{
			if (_teardownTarget != null)
			{
				base.Collection.Skip(e.OldStartingIndex).Take(e.OldItems.Count).ForEach(delegate(T t)
				{
					_teardownTarget(t);
				});
			}
			int index = e.NewStartingIndex;
			e.NewItems.Cast<S>().ForEach(delegate(S s)
			{
				base.Collection[index++] = _generateTarget(s);
			});
			break;
		}
		case NotifyCollectionChangedAction.Reset:
			Refresh();
			break;
		}
	}

	private bool IsOutOfSync(NotifyCollectionChangedEventArgs e)
	{
		return e.Action switch
		{
			NotifyCollectionChangedAction.Add => e.NewStartingIndex < 0 || e.NewStartingIndex > base.Collection.Count, 
			NotifyCollectionChangedAction.Remove => e.OldStartingIndex < 0 || e.OldStartingIndex + e.OldItems.Count > base.Collection.Count, 
			NotifyCollectionChangedAction.Move => e.OldStartingIndex < 0 || e.NewStartingIndex < 0 || e.OldStartingIndex >= base.Collection.Count || e.NewStartingIndex >= base.Collection.Count, 
			NotifyCollectionChangedAction.Replace => e.OldStartingIndex < 0 || e.NewStartingIndex < 0 || e.OldStartingIndex != e.NewStartingIndex || e.OldItems.Count != e.NewItems.Count || e.NewStartingIndex + e.NewItems.Count > base.Collection.Count, 
			_ => false, 
		};
	}
}
public class PairedCollection<S, T> : PairedCollection<INotifyEnumerableChanged<S>, S, T>
{
	public PairedCollection(INotifyEnumerableChanged<S>? sourceCollection, GenerateTargetDelegate generateTarget, TeardownTargetDelegate? teardownTarget = null)
		: base(sourceCollection, generateTarget, teardownTarget)
	{
	}
}
