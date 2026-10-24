using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.Localization.Services;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Search;

public class SettingsSearchFactory : ISettingsSearchFactory
{
	[CompilerGenerated]
	private sealed class _003CGetFields_003Ed__4 : IEnumerable<ISettingsSearchPageField>, IEnumerable, IEnumerator<ISettingsSearchPageField>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private ISettingsSearchPageField _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private ISettingsSearchPageField linkedField;

		public ISettingsSearchPageField _003C_003E3__linkedField;

		public SettingsSearchFactory _003C_003E4__this;

		private string key;

		public string _003C_003E3__key;

		private ISettingsItemVM page;

		public ISettingsItemVM _003C_003E3__page;

		private bool isComponent;

		public bool _003C_003E3__isComponent;

		private string _003CaltStringKey_003E5__2;

		private string[] _003C_003E7__wrap2;

		private int _003C_003E7__wrap3;

		ISettingsSearchPageField IEnumerator<ISettingsSearchPageField>.Current
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
		public _003CGetFields_003Ed__4(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CaltStringKey_003E5__2 = null;
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SettingsSearchFactory settingsSearchFactory = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (linkedField == null)
				{
					linkedField = new PageSearchField(settingsSearchFactory._localization.Get(key), page, isComponent);
				}
				_003C_003E2__current = linkedField;
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				_003CaltStringKey_003E5__2 = key + "_alternate";
				_003C_003E7__wrap2 = settingsSearchFactory._localization.Get(_003CaltStringKey_003E5__2).Split(',');
				_003C_003E7__wrap3 = 0;
				goto IL_0116;
			case 2:
				{
					_003C_003E1__state = -1;
					goto IL_0108;
				}
				IL_0116:
				if (_003C_003E7__wrap3 < _003C_003E7__wrap2.Length)
				{
					string text = _003C_003E7__wrap2[_003C_003E7__wrap3];
					if (!(text == _003CaltStringKey_003E5__2))
					{
						_003C_003E2__current = new PageSearchField(text, page, isComponent, linkedField);
						_003C_003E1__state = 2;
						return true;
					}
					goto IL_0108;
				}
				_003C_003E7__wrap2 = null;
				return false;
				IL_0108:
				_003C_003E7__wrap3++;
				goto IL_0116;
			}
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
		IEnumerator<ISettingsSearchPageField> IEnumerable<ISettingsSearchPageField>.GetEnumerator()
		{
			_003CGetFields_003Ed__4 _003CGetFields_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGetFields_003Ed__ = this;
			}
			else
			{
				_003CGetFields_003Ed__ = new _003CGetFields_003Ed__4(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CGetFields_003Ed__.key = _003C_003E3__key;
			_003CGetFields_003Ed__.page = _003C_003E3__page;
			_003CGetFields_003Ed__.isComponent = _003C_003E3__isComponent;
			_003CGetFields_003Ed__.linkedField = _003C_003E3__linkedField;
			return _003CGetFields_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ISettingsSearchPageField>)this).GetEnumerator();
		}
	}

	private readonly ILocalization _localization;

	public SettingsSearchFactory(ILocalization localization)
	{
		_localization = localization;
	}

	public ISettingsSearchResultItemVM Create(ISettingsSearchPageField searchResult)
	{
		return new SettingsSearchResultItemVM(searchResult);
	}

	public ISettingsSearchPageField CreatePageField(string value, ISettingsItemVM page)
	{
		return new PageSearchField(value, page);
	}

	[IteratorStateMachine(typeof(_003CGetFields_003Ed__4))]
	public IEnumerable<ISettingsSearchPageField> GetFields(string key, ISettingsItemVM page, bool isComponent = false, ISettingsSearchPageField? linkedField = null)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetFields_003Ed__4(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__key = key,
			_003C_003E3__page = page,
			_003C_003E3__isComponent = isComponent,
			_003C_003E3__linkedField = linkedField
		};
	}
}
