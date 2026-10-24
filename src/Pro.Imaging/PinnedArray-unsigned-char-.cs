using System;
using System.Runtime.InteropServices;

public class PinnedArray_003Cunsigned_0020char_003E(byte[] array) : IDisposable
{
	private byte[] managedArray = array;

	private GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);

	private unsafe byte* pinnedPtr = (byte*)(void*)handle.AddrOfPinnedObject();

	private void _007EPinnedArray_003Cunsigned_0020char_003E()
	{
		_0021PinnedArray_003Cunsigned_0020char_003E();
	}

	private void _0021PinnedArray_003Cunsigned_0020char_003E()
	{
		if (handle.IsAllocated)
		{
			handle.Free();
		}
		GC.KeepAlive(this);
	}

	public unsafe byte* Get()
	{
		return pinnedPtr;
	}

	public int Length()
	{
		return array.Length;
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_0021PinnedArray_003Cunsigned_0020char_003E();
			return;
		}
		try
		{
			_0021PinnedArray_003Cunsigned_0020char_003E();
		}
		finally
		{
			base.Finalize();
		}
	}

	public virtual sealed void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}

	~PinnedArray_003Cunsigned_0020char_003E()
	{
		Dispose(A_0: false);
	}
}
