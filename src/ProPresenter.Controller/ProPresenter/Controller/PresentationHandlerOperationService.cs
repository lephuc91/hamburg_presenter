using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller;

public class PresentationHandlerOperationService : IPresentationHandlerOperationService
{
	[CompilerGenerated]
	private sealed class _003CSerialize_003Ed__0 : IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide>, IEnumerable, IEnumerator<API_v1_Presentation.Types.SlideGroup.Types.Slide>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private API_v1_Presentation.Types.SlideGroup.Types.Slide _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<SlideCue> cues;

		public IEnumerable<SlideCue> _003C_003E3__cues;

		private IEnumerator<SlideCue> _003C_003E7__wrap1;

		API_v1_Presentation.Types.SlideGroup.Types.Slide IEnumerator<API_v1_Presentation.Types.SlideGroup.Types.Slide>.Current
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
		public _003CSerialize_003Ed__0(int _003C_003E1__state)
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
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = cues.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap1.MoveNext())
				{
					SlideCue current = _003C_003E7__wrap1.Current;
					CustomSlide customSlide = current?.SlideAction?.Slide as CustomSlide;
					_003C_003E2__current = new API_v1_Presentation.Types.SlideGroup.Types.Slide
					{
						Enabled = (current?.IsEnabled ?? false),
						Label = (current?.SlideAction?.Label?.Text ?? string.Empty),
						Notes = (customSlide?.Note?.AllText ?? string.Empty),
						Text = ((customSlide == null) ? string.Empty : string.Join("\r", customSlide.GetAllText())),
						Size = ((customSlide == null) ? null : new API_v1_Size
						{
							Width = (uint)customSlide.Size.X,
							Height = (uint)customSlide.Size.Y
						})
					};
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
		IEnumerator<API_v1_Presentation.Types.SlideGroup.Types.Slide> IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide>.GetEnumerator()
		{
			_003CSerialize_003Ed__0 _003CSerialize_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CSerialize_003Ed__ = this;
			}
			else
			{
				_003CSerialize_003Ed__ = new _003CSerialize_003Ed__0(0);
			}
			_003CSerialize_003Ed__.cues = _003C_003E3__cues;
			return _003CSerialize_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide>)this).GetEnumerator();
		}
	}

	[IteratorStateMachine(typeof(_003CSerialize_003Ed__0))]
	public IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide> Serialize(IEnumerable<SlideCue> cues)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSerialize_003Ed__0(-2)
		{
			_003C_003E3__cues = cues
		};
	}
}
