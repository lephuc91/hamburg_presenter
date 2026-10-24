using System;
using System.Runtime.CompilerServices;

namespace CoreApplication.Document;

public abstract class CoreDocumentService
{
	protected unsafe void Patch(nint service, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0027: Expected I, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_0042: Expected I8, but got I
		//IL_004c: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, callbackReceiver, true));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16uL);
				throw;
			}
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
			ulong num = (ulong)obj.Length();
			byte* ptr3 = obj.Get();
			global::_003CModule_003E.DocumentServicePatch((DocumentService*)((IntPtr)service).ToPointer(), ptr3, num, closure);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	protected unsafe void Load(nint service, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0027: Expected I, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_0042: Expected I8, but got I
		//IL_004c: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, callbackReceiver, true));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16uL);
				throw;
			}
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
			ulong num = (ulong)obj.Length();
			byte* ptr3 = obj.Get();
			global::_003CModule_003E.DocumentServiceLoad((DocumentService*)((IntPtr)service).ToPointer(), ptr3, num, closure);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	protected unsafe void Add(nint service, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0027: Expected I, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_0042: Expected I8, but got I
		//IL_004c: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, callbackReceiver, true));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16uL);
				throw;
			}
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
			ulong num = (ulong)obj.Length();
			byte* ptr3 = obj.Get();
			global::_003CModule_003E.DocumentServiceAdd((DocumentService*)((IntPtr)service).ToPointer(), ptr3, num, closure);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	protected unsafe void Relocate(nint service, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0027: Expected I, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_0042: Expected I8, but got I
		//IL_004c: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, callbackReceiver, true));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16uL);
				throw;
			}
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
			ulong num = (ulong)obj.Length();
			byte* ptr3 = obj.Get();
			global::_003CModule_003E.DocumentServiceRelocate((DocumentService*)((IntPtr)service).ToPointer(), ptr3, num, closure);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	protected unsafe void Remove(nint service, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0027: Expected I, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_0042: Expected I8, but got I
		//IL_004c: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		try
		{
			obj = obj2;
			UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, callbackReceiver, true));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 16uL);
				throw;
			}
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
			ulong num = (ulong)obj.Length();
			byte* ptr3 = obj.Get();
			global::_003CModule_003E.DocumentServiceRemove((DocumentService*)((IntPtr)service).ToPointer(), ptr3, num, closure);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
	}

	public CoreDocumentService()
	{
	}
}
