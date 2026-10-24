using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pro.Common.Collections;
using ProPresenterCore.ProCore.Interop;

namespace Pro.ssAPI.Devices;

public class VideoModeCollection : ImmutableObservableCollection<IVideoMode>
{
	[CompilerGenerated]
	private sealed class _003CNativeToManaged_003Ed__5 : IEnumerable<VideoMode>, IEnumerable, IEnumerator<VideoMode>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private VideoMode _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		private IEnumerable<ProVideoMode> nativeModes;

		public IEnumerable<ProVideoMode> _003C_003E3__nativeModes;

		private int modeCount;

		public int _003C_003E3__modeCount;

		private int _003CmodeIndex_003E5__2;

		private IEnumerator<ProVideoMode> _003C_003E7__wrap2;

		VideoMode IEnumerator<VideoMode>.Current
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
		public _003CNativeToManaged_003Ed__5(int _003C_003E1__state)
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
			_003C_003E7__wrap2 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			bool result;
			try
			{
				switch (_003C_003E1__state)
				{
				default:
					result = false;
					goto end_IL_0000;
				case 0:
					_003C_003E1__state = -1;
					_003CmodeIndex_003E5__2 = 0;
					_003C_003E7__wrap2 = nativeModes.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				if (_003C_003E7__wrap2.MoveNext())
				{
					ProVideoMode current = _003C_003E7__wrap2.Current;
					if (_003CmodeIndex_003E5__2 == modeCount)
					{
						result = false;
						_003C_003Em__Finally1();
					}
					else
					{
						_003C_003E2__current = new VideoMode(current, _003CmodeIndex_003E5__2++);
						_003C_003E1__state = 1;
						result = true;
					}
				}
				else
				{
					_003C_003Em__Finally1();
					_003C_003E7__wrap2 = null;
					result = false;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
			return result;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap2 != null)
			{
				_003C_003E7__wrap2.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<VideoMode> IEnumerable<VideoMode>.GetEnumerator()
		{
			_003CNativeToManaged_003Ed__5 _003CNativeToManaged_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CNativeToManaged_003Ed__ = this;
			}
			else
			{
				_003CNativeToManaged_003Ed__ = new _003CNativeToManaged_003Ed__5(0);
			}
			_003CNativeToManaged_003Ed__.nativeModes = _003C_003E3__nativeModes;
			_003CNativeToManaged_003Ed__.modeCount = _003C_003E3__modeCount;
			return _003CNativeToManaged_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<VideoMode>)this).GetEnumerator();
		}
	}

	protected internal VideoModeCollection()
	{
	}

	internal VideoModeCollection(IEnumerable<ProVideoMode> nativeModes, int modeCount)
	{
		base.Collection.AddRange(NativeToManaged(nativeModes, modeCount));
	}

	internal void AddMode(ProVideoMode nativeMode)
	{
		base.Collection.Add(new VideoMode(nativeMode, base.Collection.Count));
	}

	internal void AddMode(ProVideoMode nativeMode, int modeIndex)
	{
		base.Collection.Add(new VideoMode(nativeMode, modeIndex));
	}

	internal void Clear()
	{
		base.Collection.Clear();
	}

	[IteratorStateMachine(typeof(_003CNativeToManaged_003Ed__5))]
	private static IEnumerable<VideoMode> NativeToManaged(IEnumerable<ProVideoMode> nativeModes, int modeCount)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CNativeToManaged_003Ed__5(-2)
		{
			_003C_003E3__nativeModes = nativeModes,
			_003C_003E3__modeCount = modeCount
		};
	}
}
