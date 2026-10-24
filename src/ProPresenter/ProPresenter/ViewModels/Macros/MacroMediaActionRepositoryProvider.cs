using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Macros;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels.Macros;

public class MacroMediaActionRepositoryProvider : IActionRepositoryProvider
{
	[CompilerGenerated]
	private sealed class _003CGenerateRepos_003Ed__0 : IEnumerable<IActionRepository>, IEnumerable, IEnumerator<IActionRepository>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IActionRepository _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IActionRepository targetRepo;

		public IActionRepository _003C_003E3__targetRepo;

		private IEnumerable<IAction> actions;

		public IEnumerable<IAction> _003C_003E3__actions;

		private IEnumerator<(ProPresenterMacro, IAction)> _003C_003E7__wrap1;

		IActionRepository IEnumerator<IActionRepository>.Current
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
		public _003CGenerateRepos_003Ed__0(int _003C_003E1__state)
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
				switch (_003C_003E1__state)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					IEnumerable<(ProPresenterMacro, IAction)> enumerable = ((targetRepo != null) ? Combine((ProPresenterMacro)targetRepo, actions.LastOrDefault()).ToEnumerable() : actions.Select((IAction a) => Combine(new ProPresenterMacro(), a)));
					_003C_003E7__wrap1 = enumerable.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					var (proPresenterMacro, action) = _003C_003E7__wrap1.Current;
					if (proPresenterMacro.CanAddAction(action))
					{
						proPresenterMacro.AddAction(action);
					}
					_003C_003E2__current = proPresenterMacro;
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
		IEnumerator<IActionRepository> IEnumerable<IActionRepository>.GetEnumerator()
		{
			_003CGenerateRepos_003Ed__0 _003CGenerateRepos_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGenerateRepos_003Ed__ = this;
			}
			else
			{
				_003CGenerateRepos_003Ed__ = new _003CGenerateRepos_003Ed__0(0);
			}
			_003CGenerateRepos_003Ed__.targetRepo = _003C_003E3__targetRepo;
			_003CGenerateRepos_003Ed__.actions = _003C_003E3__actions;
			return _003CGenerateRepos_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IActionRepository>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CGenerateRepos_003Ed__0))]
	public IEnumerable<IActionRepository> GenerateRepos(IActionRepository? targetRepo, IEnumerable<IAction> actions)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGenerateRepos_003Ed__0(-2)
		{
			_003C_003E3__targetRepo = targetRepo,
			_003C_003E3__actions = actions
		};
	}

	private static (ProPresenterMacro, IAction?) Combine(ProPresenterMacro macro, IAction? action)
	{
		return (macro, action);
	}
}
