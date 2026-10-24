using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.ViewModels.Actions;

namespace ProPresenter.ViewModels;

public class PresentationMediaCueProvider : IMediaActionProvider
{
	[CompilerGenerated]
	private sealed class _003CGetActions_003Ed__3 : IEnumerable<MediaAction>, IEnumerable, IEnumerator<MediaAction>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private MediaAction _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PresentationMediaCueProvider _003C_003E4__this;

		private IEnumerator<MediaCue> _003C_003E7__wrap1;

		MediaAction IEnumerator<MediaAction>.Current
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
		public _003CGetActions_003Ed__3(int _003C_003E1__state)
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
				PresentationMediaCueProvider presentationMediaCueProvider = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = presentationMediaCueProvider._mediaCues.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					MediaCue current = _003C_003E7__wrap1.Current;
					MediaAction mediaAction = (presentationMediaCueProvider._shouldCloneAction ? (current.MediaAction?.Clone() as MediaAction) : current.MediaAction);
					if (mediaAction?.Media is ITransportMedia transportMedia && current.CompletionTarget.Type != 0)
					{
						transportMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
					}
					if (mediaAction != null)
					{
						_003C_003E2__current = mediaAction;
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
		IEnumerator<MediaAction> IEnumerable<MediaAction>.GetEnumerator()
		{
			_003CGetActions_003Ed__3 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetActions_003Ed__3(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<MediaAction>)this).GetEnumerator();
		}
	}

	private readonly IEnumerable<MediaCue> _mediaCues;

	private readonly bool _shouldCloneAction;

	public PresentationMediaCueProvider(IEnumerable<MediaCue> mediaCues, bool shouldCloneAction)
	{
		_mediaCues = mediaCues;
		_shouldCloneAction = shouldCloneAction;
	}

	[IteratorStateMachine(typeof(_003CGetActions_003Ed__3))]
	public IEnumerable<MediaAction> GetActions()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetActions_003Ed__3(-2)
		{
			_003C_003E4__this = this
		};
	}

	public IEnumerable<(string, IEnumerable<MediaAction>)> GetGroupedActions()
	{
		throw new NotSupportedException();
	}
}
