using System;
using System.IO;

namespace Pro.Loro;

internal struct RustBuffer
{
	public ulong capacity;

	public ulong len;

	public IntPtr data;

	public static RustBuffer Alloc(int size)
	{
		return _UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			RustBuffer result = _UniFFILib.ffi_loro_ffi_rustbuffer_alloc(Convert.ToUInt64(size), ref status);
			if (result.data == IntPtr.Zero)
			{
				throw new AllocationException($"RustBuffer.Alloc() returned null data pointer (size={size})");
			}
			return result;
		});
	}

	public static void Free(RustBuffer buffer)
	{
		_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus status)
		{
			_UniFFILib.ffi_loro_ffi_rustbuffer_free(buffer, ref status);
		});
	}

	public unsafe static BigEndianStream MemoryStream(IntPtr data, long length)
	{
		return new BigEndianStream(new UnmanagedMemoryStream((byte*)data.ToPointer(), length));
	}

	public unsafe BigEndianStream AsStream()
	{
		return new BigEndianStream(new UnmanagedMemoryStream((byte*)data.ToPointer(), Convert.ToInt64(len)));
	}

	public unsafe BigEndianStream AsWriteableStream()
	{
		return new BigEndianStream(new UnmanagedMemoryStream((byte*)data.ToPointer(), Convert.ToInt64(capacity), Convert.ToInt64(capacity), FileAccess.Write));
	}
}
