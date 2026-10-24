using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ProPresenterCore.ProCore.Interop;

public sealed class NativeFixedArray<M, N> : IReadOnlyList<M>, IEnumerable<M>, IEnumerable, IReadOnlyCollection<M> where M : class where N : struct
{
	[CompilerGenerated]
	private sealed class _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CM_003E_002DGetEnumerator_003Ed__8 : IEnumerator<M>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private M _003C_003E2__current;

		public NativeFixedArray<M, N> _003C_003E4__this;

		private int _003Ci_003E5__2;

		M IEnumerator<M>.Current
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
		public _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CM_003E_002DGetEnumerator_003Ed__8(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			NativeFixedArray<M, N> nativeFixedArray = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ci_003E5__2 = 0;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ci_003E5__2++;
				break;
			}
			if (_003Ci_003E5__2 < nativeFixedArray._count)
			{
				_003C_003E2__current = nativeFixedArray[_003Ci_003E5__2];
				_003C_003E1__state = 1;
				return true;
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
	}

	private readonly Func<nint, bool, M> _createFunc;

	private readonly nint _ptr;

	private readonly int _count;

	public M this[int index] => _createFunc(_ptr + Marshal.SizeOf<N>() * index, arg2: false);

	public int Count => _count;

	internal NativeFixedArray(Func<nint, bool, M> createFunc, nint ptr, int count)
	{
		_createFunc = createFunc;
		_ptr = ptr;
		_count = count;
	}

	[IteratorStateMachine(typeof(NativeFixedArray<, >._003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CM_003E_002DGetEnumerator_003Ed__8))]
	IEnumerator<M> IEnumerable<M>.GetEnumerator()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CSystem_002DCollections_002DGeneric_002DIEnumerable_003CM_003E_002DGetEnumerator_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable<M>)this).GetEnumerator();
	}
}
