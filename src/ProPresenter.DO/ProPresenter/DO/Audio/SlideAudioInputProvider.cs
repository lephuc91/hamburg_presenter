using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Audio;

public class SlideAudioInputProvider : IAudioInputProvider
{
	[CompilerGenerated]
	private sealed class _003CGetAvailableInputs_003Ed__3 : IEnumerable<AudioInput>, IEnumerable, IEnumerator<AudioInput>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private AudioInput _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public SlideAudioInputProvider _003C_003E4__this;

		private int[] _003CinputActionIndices_003E5__2;

		private int _003Ci_003E5__3;

		AudioInput IEnumerator<AudioInput>.Current
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
		public _003CGetAvailableInputs_003Ed__3(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003CinputActionIndices_003E5__2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			SlideAudioInputProvider slideAudioInputProvider = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_00ba;
			}
			_003C_003E1__state = -1;
			_003CinputActionIndices_003E5__2 = (from a in slideAudioInputProvider._getActions?.Invoke()?.OfType<AudioInputAction>()
				select a.Index).ToArray() ?? Array.Empty<int>();
			_003Ci_003E5__3 = 0;
			goto IL_00ca;
			IL_00ba:
			_003Ci_003E5__3++;
			goto IL_00ca;
			IL_00ca:
			if (_003Ci_003E5__3 < slideAudioInputProvider._inputs.Count())
			{
				if (!_003CinputActionIndices_003E5__2.Contains(_003Ci_003E5__3))
				{
					_003C_003E2__current = slideAudioInputProvider._inputs.ElementAt(_003Ci_003E5__3);
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00ba;
			}
			return false;
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
		IEnumerator<AudioInput> IEnumerable<AudioInput>.GetEnumerator()
		{
			_003CGetAvailableInputs_003Ed__3 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetAvailableInputs_003Ed__3(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<AudioInput>)this).GetEnumerator();
		}
	}

	private readonly IEnumerable<AudioInput> _inputs;

	private readonly Func<IEnumerable<IAction>>? _getActions;

	public SlideAudioInputProvider(IEnumerable<AudioInput>? inputs = null, Func<IEnumerable<IAction>>? getActions = null)
	{
		object obj = inputs ?? OutputVault.AvailableAudioInputs;
		if (obj == null)
		{
			obj = Array.Empty<AudioInput>();
		}
		_inputs = (IEnumerable<AudioInput>)obj;
		_getActions = getActions;
	}

	[IteratorStateMachine(typeof(_003CGetAvailableInputs_003Ed__3))]
	public IEnumerable<AudioInput> GetAvailableInputs()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAvailableInputs_003Ed__3(-2)
		{
			_003C_003E4__this = this
		};
	}
}
