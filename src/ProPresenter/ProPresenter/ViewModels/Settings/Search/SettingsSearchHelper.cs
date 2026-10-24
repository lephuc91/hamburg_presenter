using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public static class SettingsSearchHelper
{
	[CompilerGenerated]
	private sealed class _003CGetAllPages_003Ed__0 : IEnumerable<ISettingsSearchPage>, IEnumerable, IEnumerator<ISettingsSearchPage>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ISettingsSearchPage _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<ISettingsSearchPage> pages;

		public IEnumerable<ISettingsSearchPage> _003C_003E3__pages;

		private IEnumerator<ISettingsSearchPage> _003C_003E7__wrap1;

		private ISettingsSearchPage _003Cpage_003E5__3;

		private IEnumerator<ISettingsSearchPage> _003C_003E7__wrap3;

		ISettingsSearchPage IEnumerator<ISettingsSearchPage>.Current
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
		public _003CGetAllPages_003Ed__0(int _003C_003E1__state)
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
			_003Cpage_003E5__3 = null;
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
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = pages.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					_003C_003E7__wrap3 = _003Cpage_003E5__3.SubPages.GetEnumerator();
					_003C_003E1__state = -4;
					goto IL_00be;
				case 2:
					{
						_003C_003E1__state = -4;
						goto IL_00be;
					}
					IL_00be:
					if (_003C_003E7__wrap3.MoveNext())
					{
						ISettingsSearchPage current = _003C_003E7__wrap3.Current;
						_003C_003E2__current = current;
						_003C_003E1__state = 2;
						return true;
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = null;
					_003Cpage_003E5__3 = null;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					_003Cpage_003E5__3 = _003C_003E7__wrap1.Current;
					_003C_003E2__current = _003Cpage_003E5__3;
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
		IEnumerator<ISettingsSearchPage> IEnumerable<ISettingsSearchPage>.GetEnumerator()
		{
			_003CGetAllPages_003Ed__0 _003CGetAllPages_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetAllPages_003Ed__ = this;
			}
			else
			{
				_003CGetAllPages_003Ed__ = new _003CGetAllPages_003Ed__0(0);
			}
			_003CGetAllPages_003Ed__.pages = _003C_003E3__pages;
			return _003CGetAllPages_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ISettingsSearchPage>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CGetAllPages_003Ed__0))]
	public static IEnumerable<ISettingsSearchPage> GetAllPages(this IEnumerable<ISettingsSearchPage> pages)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAllPages_003Ed__0(-2)
		{
			_003C_003E3__pages = pages
		};
	}
}
