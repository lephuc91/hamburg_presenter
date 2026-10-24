using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Pro.Common.Collections;

namespace Pro.Common.Utility;

public static class SelectionHelper<T> where T : class
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public IEnumerable<T> selectedItems;

		public T anchorItem;

		public Func<T, bool> _003C_003E9__2;

		internal bool _003CFindSelectedItems_003Eb__0(T i)
		{
			return selectedItems.Contains(i);
		}

		internal bool _003CFindSelectedItems_003Eb__1(T[] g)
		{
			return g.Contains(anchorItem);
		}

		internal bool _003CFindSelectedItems_003Eb__2(T i)
		{
			return i != anchorItem;
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindSelectedItems_003Ed__1 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> selectedItems;

		public IEnumerable<T> _003C_003E3__selectedItems;

		private IEnumerable<T> sourceCollection;

		public IEnumerable<T> _003C_003E3__sourceCollection;

		private bool isRangeSelection;

		public bool _003C_003E3__isRangeSelection;

		private bool isToggleSelection;

		public bool _003C_003E3__isToggleSelection;

		private T targetItem;

		public T _003C_003E3__targetItem;

		private T _003CanchorItem_003E5__2;

		private List<T> _003CreturnedItems_003E5__3;

		private IEnumerator<T> _003C_003E7__wrap3;

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
		public _003CFindSelectedItems_003Ed__1(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (_003C_003E1__state)
			{
			case -3:
			case 1:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
				break;
			case -4:
			case 2:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally2();
				}
				break;
			case -5:
			case 4:
				try
				{
				}
				finally
				{
					_003C_003Em__Finally3();
				}
				break;
			}
			_003CanchorItem_003E5__2 = null;
			_003CreturnedItems_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					IEnumerable<T> enumerable = selectedItems;
					object obj = ((enumerable != null) ? enumerable.FirstOrDefault() : null);
					if (obj == null)
					{
						IEnumerable<T> enumerable2 = sourceCollection;
						obj = ((enumerable2 != null) ? enumerable2.FirstOrDefault() : null);
					}
					_003CanchorItem_003E5__2 = (T)obj;
					if (_003CanchorItem_003E5__2 == null)
					{
						return false;
					}
					if (isRangeSelection)
					{
						_003CreturnedItems_003E5__3 = null;
						if (isToggleSelection)
						{
							_003CreturnedItems_003E5__3 = new List<T>();
							if (selectedItems != null)
							{
								_003C_003E7__wrap3 = selectedItems.GetEnumerator();
								_003C_003E1__state = -3;
								goto IL_0102;
							}
						}
						goto IL_012d;
					}
					if (isToggleSelection)
					{
						if (selectedItems != null)
						{
							if (!selectedItems.Contains(targetItem))
							{
								_003C_003E2__current = targetItem;
								_003C_003E1__state = 3;
								return true;
							}
							goto IL_0228;
						}
						_003C_003E2__current = targetItem;
						_003C_003E1__state = 5;
						return true;
					}
					_003C_003E2__current = targetItem;
					_003C_003E1__state = 6;
					return true;
				}
				case 1:
					_003C_003E1__state = -3;
					goto IL_0102;
				case 2:
					_003C_003E1__state = -4;
					goto IL_01b8;
				case 3:
					_003C_003E1__state = -1;
					goto IL_0228;
				case 4:
					_003C_003E1__state = -5;
					goto IL_027f;
				case 5:
					_003C_003E1__state = -1;
					break;
				case 6:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_012d:
					if (sourceCollection != null)
					{
						_003C_003E7__wrap3 = sourceCollection.RangeBetween(_003CanchorItem_003E5__2, targetItem).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_01b8;
					}
					goto IL_01d2;
					IL_0228:
					_003C_003E7__wrap3 = selectedItems.GetEnumerator();
					_003C_003E1__state = -5;
					goto IL_027f;
					IL_01d2:
					_003CreturnedItems_003E5__3 = null;
					break;
					IL_0102:
					if (_003C_003E7__wrap3.MoveNext())
					{
						T current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap3 = null;
					_003CreturnedItems_003E5__3.AddRange(selectedItems);
					goto IL_012d;
					IL_027f:
					while (_003C_003E7__wrap3.MoveNext())
					{
						T current2 = _003C_003E7__wrap3.Current;
						if (current2 != targetItem)
						{
							_003C_003E2__current = current2;
							_003C_003E1__state = 4;
							return true;
						}
					}
					_003C_003Em__Finally3();
					_003C_003E7__wrap3 = null;
					break;
					IL_01b8:
					while (_003C_003E7__wrap3.MoveNext())
					{
						T current3 = _003C_003E7__wrap3.Current;
						List<T> list = _003CreturnedItems_003E5__3;
						if (list == null || !list.Contains(current3))
						{
							_003CreturnedItems_003E5__3?.Add(current3);
							_003C_003E2__current = current3;
							_003C_003E1__state = 2;
							return true;
						}
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					goto IL_01d2;
				}
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
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		private void _003C_003Em__Finally3()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CFindSelectedItems_003Ed__1 _003CFindSelectedItems_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindSelectedItems_003Ed__ = this;
			}
			else
			{
				_003CFindSelectedItems_003Ed__ = new _003CFindSelectedItems_003Ed__1(0);
			}
			_003CFindSelectedItems_003Ed__.sourceCollection = _003C_003E3__sourceCollection;
			_003CFindSelectedItems_003Ed__.selectedItems = _003C_003E3__selectedItems;
			_003CFindSelectedItems_003Ed__.targetItem = _003C_003E3__targetItem;
			_003CFindSelectedItems_003Ed__.isRangeSelection = _003C_003E3__isRangeSelection;
			_003CFindSelectedItems_003Ed__.isToggleSelection = _003C_003E3__isToggleSelection;
			return _003CFindSelectedItems_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFindSelectedItems_003Ed__3 : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private T _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<T> selectedItems;

		public IEnumerable<T> _003C_003E3__selectedItems;

		private IEnumerable<T> sourceCollection;

		public IEnumerable<T> _003C_003E3__sourceCollection;

		private bool selectNext;

		public bool _003C_003E3__selectNext;

		private bool isRangeSelection;

		public bool _003C_003E3__isRangeSelection;

		private _003C_003Ec__DisplayClass3_0 _003C_003E8__1;

		private T[] _003Csource_003E5__2;

		private T _003CtargetItem_003E5__3;

		private IEnumerator<T> _003C_003E7__wrap3;

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
		public _003CFindSelectedItems_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E8__1 = null;
			_003Csource_003E5__2 = null;
			_003CtargetItem_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					_003C_003E8__1 = new _003C_003Ec__DisplayClass3_0();
					_003C_003E8__1.selectedItems = selectedItems;
					_003Csource_003E5__2 = (sourceCollection as T[]) ?? sourceCollection.ToArray();
					_003C_003E8__1.anchorItem = _003C_003E8__1.selectedItems.FirstOrDefault() ?? sourceCollection.FirstOrDefault();
					int num = _003Csource_003E5__2.IndexOf(_003C_003E8__1.anchorItem);
					if (_003C_003E8__1.anchorItem == null || num < 0)
					{
						return false;
					}
					T[] array = _003Csource_003E5__2.ContiguousGroups((T i) => _003C_003E8__1.selectedItems.Contains(i)).FirstOrDefault((T[] g) => g.Contains(_003C_003E8__1.anchorItem));
					if (array == null)
					{
						return false;
					}
					int num2 = -1;
					num2 = (selectNext ? ((array.Last() != _003C_003E8__1.anchorItem) ? (_003Csource_003E5__2.IndexOf(array.Last()) + 1) : (_003Csource_003E5__2.IndexOf(array.First()) + 1)) : ((array.First() != _003C_003E8__1.anchorItem) ? (_003Csource_003E5__2.IndexOf(array.First()) - 1) : (_003Csource_003E5__2.IndexOf(array.Last()) - 1)));
					_003CtargetItem_003E5__3 = _003Csource_003E5__2[_003Csource_003E5__2.ClampIndex(num2)];
					if (isRangeSelection)
					{
						_003C_003E2__current = _003C_003E8__1.anchorItem;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E2__current = _003CtargetItem_003E5__3;
					_003C_003E1__state = 3;
					return true;
				}
				case 1:
					_003C_003E1__state = -1;
					_003C_003E7__wrap3 = (from i in _003Csource_003E5__2.RangeBetween(_003C_003E8__1.anchorItem, _003CtargetItem_003E5__3)
						where i != _003C_003E8__1.anchorItem
						select i).GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_0283;
				case 2:
					_003C_003E1__state = -3;
					goto IL_0283;
				case 3:
					{
						_003C_003E1__state = -1;
						break;
					}
					IL_0283:
					if (_003C_003E7__wrap3.MoveNext())
					{
						T current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap3 = null;
					break;
				}
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
			if (_003C_003E7__wrap3 != null)
			{
				_003C_003E7__wrap3.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			_003CFindSelectedItems_003Ed__3 _003CFindSelectedItems_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFindSelectedItems_003Ed__ = this;
			}
			else
			{
				_003CFindSelectedItems_003Ed__ = new _003CFindSelectedItems_003Ed__3(0);
			}
			_003CFindSelectedItems_003Ed__.sourceCollection = _003C_003E3__sourceCollection;
			_003CFindSelectedItems_003Ed__.selectedItems = _003C_003E3__selectedItems;
			_003CFindSelectedItems_003Ed__.selectNext = _003C_003E3__selectNext;
			_003CFindSelectedItems_003Ed__.isRangeSelection = _003C_003E3__isRangeSelection;
			return _003CFindSelectedItems_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}
	}

	public static IEnumerable<T> FindSelectedItems(IEnumerable<T> sourceCollection, IEnumerable<T> selectedItems, T targetItem, ModifierKeys modifierKeys)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return FindSelectedItems(sourceCollection, selectedItems, targetItem, ((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4), ((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)2));
	}

	[IteratorStateMachine(typeof(SelectionHelper<>._003CFindSelectedItems_003Ed__1))]
	public static IEnumerable<T> FindSelectedItems(IEnumerable<T>? sourceCollection, IEnumerable<T>? selectedItems, T targetItem, bool isRangeSelection, bool isToggleSelection)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindSelectedItems_003Ed__1(-2)
		{
			_003C_003E3__sourceCollection = sourceCollection,
			_003C_003E3__selectedItems = selectedItems,
			_003C_003E3__targetItem = targetItem,
			_003C_003E3__isRangeSelection = isRangeSelection,
			_003C_003E3__isToggleSelection = isToggleSelection
		};
	}

	public static IEnumerable<T> FindSelectedItems(IEnumerable<T> sourceCollection, IEnumerable<T> selectedItems, bool selectNext, ModifierKeys modifierKeys)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		return FindSelectedItems(sourceCollection, selectedItems, selectNext, ((Enum)modifierKeys).HasFlag((Enum)(object)(ModifierKeys)4));
	}

	[IteratorStateMachine(typeof(SelectionHelper<>._003CFindSelectedItems_003Ed__3))]
	public static IEnumerable<T> FindSelectedItems(IEnumerable<T> sourceCollection, IEnumerable<T> selectedItems, bool selectNext, bool isRangeSelection)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFindSelectedItems_003Ed__3(-2)
		{
			_003C_003E3__sourceCollection = sourceCollection,
			_003C_003E3__selectedItems = selectedItems,
			_003C_003E3__selectNext = selectNext,
			_003C_003E3__isRangeSelection = isRangeSelection
		};
	}
}
