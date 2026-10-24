using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Pro.UI;
using Pro.UI.Controls;
using ProPresenter.DO.PCO;

namespace ProPresenter.UI.PCOLive;

public class PCOTreeView : TreeViewBase<PCOObject, Pro.UI.Controls.TreeViewItem>
{
	[CompilerGenerated]
	private sealed class _003CFlattenGroup_003Ed__2 : IEnumerable<PCOObject>, IEnumerable, IEnumerator<PCOObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PCOObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<PCOObject> root;

		public IEnumerable<PCOObject> _003C_003E3__root;

		public PCOTreeView _003C_003E4__this;

		private IEnumerator<PCOObject> _003C_003E7__wrap1;

		private PCOObject _003Citem_003E5__3;

		private IEnumerator<PCOObject> _003C_003E7__wrap3;

		PCOObject IEnumerator<PCOObject>.Current
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
		public _003CFlattenGroup_003Ed__2(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
			{
				try
				{
					if (num == -4 || num == 2)
					{
						try
						{
						}
						finally
						{
							_003C_003Em__Finally2();
						}
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003Citem_003E5__3 = null;
			_003C_003E7__wrap3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PCOTreeView pCOTreeView = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = root.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					if (_003Citem_003E5__3 is PCOFolder pCOFolder)
					{
						_003C_003E7__wrap3 = pCOTreeView.FlattenGroup(pCOFolder.Folders.Cast<PCOObject>().Concat(pCOFolder.ServiceTypes)).GetEnumerator();
						_003C_003E1__state = -4;
						goto IL_00e7;
					}
					goto IL_0101;
				case 2:
					{
						_003C_003E1__state = -4;
						goto IL_00e7;
					}
					IL_0101:
					_003Citem_003E5__3 = null;
					break;
					IL_00e7:
					if (_003C_003E7__wrap3.MoveNext())
					{
						PCOObject current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					goto IL_0101;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003Citem_003E5__3 = _003C_003E7__wrap1.Current;
					_003C_003E2__current = _003Citem_003E5__3;
					_003C_003E1__state = 1;
					return true;
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

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -3;
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
		IEnumerator<PCOObject> IEnumerable<PCOObject>.GetEnumerator()
		{
			_003CFlattenGroup_003Ed__2 _003CFlattenGroup_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CFlattenGroup_003Ed__ = this;
			}
			else
			{
				_003CFlattenGroup_003Ed__ = new _003CFlattenGroup_003Ed__2(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CFlattenGroup_003Ed__.root = _003C_003E3__root;
			return _003CFlattenGroup_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<PCOObject>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003CFlattenItemSource_003Ed__1 : IEnumerable<PCOObject>, IEnumerable, IEnumerator<PCOObject>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private PCOObject _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PCOTreeView _003C_003E4__this;

		private IEnumerator<PCOObject> _003C_003E7__wrap1;

		PCOObject IEnumerator<PCOObject>.Current
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
		public _003CFlattenItemSource_003Ed__1(int _003C_003E1__state)
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
				PCOTreeView pCOTreeView = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					IEnumerable<PCOObject> enumerable = (IEnumerable<PCOObject>)pCOTreeView.ItemsSource;
					if (enumerable == null)
					{
						return false;
					}
					_003C_003E7__wrap1 = pCOTreeView.FlattenGroup(enumerable).GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					PCOObject current = _003C_003E7__wrap1.Current;
					_003C_003E2__current = current;
					_003C_003E1__state = 1;
					return true;
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
		IEnumerator<PCOObject> IEnumerable<PCOObject>.GetEnumerator()
		{
			_003CFlattenItemSource_003Ed__1 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CFlattenItemSource_003Ed__1(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<PCOObject>)this).GetEnumerator();
		}
	}

	public PCOTreeView()
	{
		base.Resources = new SharedResourceDictionary
		{
			Source = new Uri("pack://application:,,,/ProPresenter.UI;component/PCOLive/PCOTreeViewResources.xaml")
		};
		ScrollViewer.SetHorizontalScrollBarVisibility((DependencyObject)(object)this, ScrollBarVisibility.Disabled);
		AddHandler(System.Windows.Controls.TreeViewItem.ExpandedEvent, new RoutedEventHandler(OnTreeViewItemExpanded));
	}

	[IteratorStateMachine(typeof(_003CFlattenItemSource_003Ed__1))]
	protected override IEnumerable<PCOObject> FlattenItemSource()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFlattenItemSource_003Ed__1(-2)
		{
			_003C_003E4__this = this
		};
	}

	[IteratorStateMachine(typeof(_003CFlattenGroup_003Ed__2))]
	private IEnumerable<PCOObject> FlattenGroup(IEnumerable<PCOObject> root)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CFlattenGroup_003Ed__2(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__root = root
		};
	}

	private void OnTreeViewItemExpanded(object? sender, RoutedEventArgs e)
	{
		((e.OriginalSource as FrameworkElement)?.DataContext as PCOServiceType)?.LoadPlans();
	}
}
