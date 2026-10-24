using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels.Presentation;

public class PresentationMediaActionRepositoryProvider : IActionRepositoryProvider
{
	[CompilerGenerated]
	private sealed class _003CGenerateRepos_003Ed__3 : IEnumerable<IActionRepository>, IEnumerable, IEnumerator<IActionRepository>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IActionRepository _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IActionRepository targetRepo;

		public IActionRepository _003C_003E3__targetRepo;

		private IEnumerable<IAction> actions;

		public IEnumerable<IAction> _003C_003E3__actions;

		public PresentationMediaActionRepositoryProvider _003C_003E4__this;

		private IEnumerator<(SlideCue, IAction)> _003C_003E7__wrap1;

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
		public _003CGenerateRepos_003Ed__3(int _003C_003E1__state)
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
				PresentationMediaActionRepositoryProvider CS_0024_003C_003E8__locals4 = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					_003C_003E1__state = -1;
					IEnumerable<(SlideCue, IAction)> enumerable2;
					if (!(targetRepo is SlideCue item))
					{
						IEnumerable<(SlideCue, IAction)> enumerable = actions.Select((IAction a) => (new SlideCue(CS_0024_003C_003E8__locals4._factoryProvider, new CustomSlide(CS_0024_003C_003E8__locals4._factoryProvider, CS_0024_003C_003E8__locals4._transitioNDescriptions), CS_0024_003C_003E8__locals4._transitioNDescriptions), a: a));
						enumerable2 = enumerable;
					}
					else
					{
						IEnumerable<(SlideCue, IAction)> enumerable = (item, actions.Last()).ToEnumerable();
						enumerable2 = enumerable;
					}
					IEnumerable<(SlideCue, IAction)> enumerable3 = enumerable2;
					_003C_003E7__wrap1 = enumerable3.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				}
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					var (slideCue, action) = _003C_003E7__wrap1.Current;
					if (slideCue.CanReplace(action))
					{
						slideCue.AddAction(action, addMediaReferences: true);
					}
					UpdateLabel(slideCue, action);
					_003C_003E2__current = slideCue;
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
			_003CGenerateRepos_003Ed__3 _003CGenerateRepos_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CGenerateRepos_003Ed__ = this;
			}
			else
			{
				_003CGenerateRepos_003Ed__ = new _003CGenerateRepos_003Ed__3(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
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

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitioNDescriptions;

	public PresentationMediaActionRepositoryProvider(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		_factoryProvider = factoryProvider;
		_transitioNDescriptions = transitionDescriptions;
	}

	[IteratorStateMachine(typeof(_003CGenerateRepos_003Ed__3))]
	public IEnumerable<IActionRepository> GenerateRepos(IActionRepository? targetRepo, IEnumerable<IAction> actions)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGenerateRepos_003Ed__3(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__targetRepo = targetRepo,
			_003C_003E3__actions = actions
		};
	}

	private static void UpdateLabel(IActionRepository repo, IAction action)
	{
		SlideCue targetCue = repo as SlideCue;
		if (targetCue != null && action is MediaAction mediaAction)
		{
			IEnumerable<MediaAction> source = targetCue.Actions.OfType<MediaAction>();
			if (string.IsNullOrEmpty(targetCue.SlideAction?.Label?.Text))
			{
				targetCue.SlideAction.ThrowWhenNull("targetCue.SlideAction");
				targetCue.SlideAction.Label = new ActionLabel(mediaAction.Name);
			}
			else if (source.Any((MediaAction a) => a.Name == targetCue.SlideAction?.Label?.Text) && (mediaAction.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video, MediaType.LiveVideo) || (mediaAction.Media.MediaType == MediaType.Audio && source.Where((MediaAction a) => a.Media.MediaType.IsAnyOf(MediaType.Audio)).Any((MediaAction a) => a.Name == targetCue.SlideAction?.Label?.Text))))
			{
				targetCue.SlideAction.ThrowWhenNull("targetCue.SlideAction");
				targetCue.SlideAction.Label = new ActionLabel(mediaAction.Name);
			}
		}
	}
}
