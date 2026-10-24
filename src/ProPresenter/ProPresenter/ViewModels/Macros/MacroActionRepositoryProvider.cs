using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Macros;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels.Macros;

public class MacroActionRepositoryProvider : IActionRepositoryProvider
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
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				IActionRepository actionRepository = targetRepo ?? new ProPresenterMacro();
				foreach (IAction item in actions)
				{
					if (actionRepository.CanReplace(item))
					{
						actionRepository.AddAction(item);
					}
				}
				_003C_003E2__current = actionRepository;
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				return false;
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
}
