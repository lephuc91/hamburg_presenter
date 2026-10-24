using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using std;

namespace CoreRegistrationClient;

public class RegistrationInteractor : IRegistrationInteractor, IManagedNativeCallbackReceiver
{
	private unsafe RegistrationInteractorUnmanaged* unmanagedInteractor_;

	private IRegistrationInteractorCallbackReceiver callbacks_;

	public unsafe RegistrationInteractor(IRegistrationInteractorCallbackReceiver callbacks)
	{
		//IL_0020: Expected I, but got I8
		//IL_0013: Expected I4, but got I8
		RegistrationInteractorUnmanaged* ptr = (RegistrationInteractorUnmanaged*)global::_003CModule_003E.@new(24uL);
		RegistrationInteractorUnmanaged* ptr2;
		try
		{
			if (ptr != null)
			{
				// IL initblk instruction
				Unsafe.InitBlock(ptr, 0, 24);
				ptr2 = global::_003CModule_003E.CoreRegistrationClient_002ERegistrationInteractorUnmanaged_002E_007Bctor_007D(ptr, this);
			}
			else
			{
				ptr2 = null;
			}
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr, 24uL);
			throw;
		}
		unmanagedInteractor_ = ptr2;
		callbacks_ = callbacks;
		base._002Ector();
	}

	private unsafe void _007ERegistrationInteractor()
	{
		//IL_0016: Expected I, but got I8
		RegistrationInteractorUnmanaged* ptr = unmanagedInteractor_;
		if (ptr != null)
		{
			long num = *(long*)(*(ulong*)ptr);
			((delegate* unmanaged[Cdecl, Cdecl]<nint, uint, void*>)num)((nint)ptr, 1u);
		}
		GC.KeepAlive(this);
	}

	public unsafe virtual void Start(byte[] startupConfig)
	{
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(startupConfig);
		try
		{
			obj = obj2;
			RegistrationInteractorUnmanaged* intPtr = unmanagedInteractor_;
			ulong size = (ulong)obj.Length();
			byte* buf = obj.Get();
			global::_003CModule_003E.CoreRegistrationClient_002ERegistrationInteractorUnmanaged_002EStartup(intPtr, buf, size);
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe virtual bool Send(byte[] serializedData)
	{
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(serializedData);
		bool result;
		try
		{
			obj = obj2;
			RegistrationInteractorUnmanaged* intPtr = unmanagedInteractor_;
			ulong size = (ulong)obj.Length();
			byte* buf = obj.Get();
			Unsafe.SkipInit(out UnmanagedSendResult unmanagedSendResult);
			global::_003CModule_003E.CoreRegistrationClient_002ERegistrationInteractorUnmanaged_002ESend(intPtr, &unmanagedSendResult, buf, size);
			try
			{
				if (!global::_003CModule_003E.CoreRegistrationClient_002EUnmanagedSendResult_002EIsSuccess(&unmanagedSendResult))
				{
					object[] array = new object[2];
					string name = GetType().Name;
					array[0] = name;
					Unsafe.SkipInit(out basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E obj3);
					basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* ptr = global::_003CModule_003E.CoreRegistrationClient_002EUnmanagedSendResult_002EGetErrorMessage(&unmanagedSendResult, &obj3);
					try
					{
						string text = new string(global::_003CModule_003E.std_002E_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002E_Myptr((_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E*)ptr));
						array[1] = text;
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*, void>)(&global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_007Bdtor_007D), &obj3);
						throw;
					}
					try
					{
						global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate(&obj3);
					}
					catch
					{
						//try-fault
						global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), &obj3);
						throw;
					}
					callbacks_.LogError("[{0}] {1}", array);
				}
				result = global::_003CModule_003E.CoreRegistrationClient_002EUnmanagedSendResult_002EIsSuccess(&unmanagedSendResult);
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<UnmanagedSendResult*, void>)(&global::_003CModule_003E.CoreRegistrationClient_002EUnmanagedSendResult_002E_007Bdtor_007D), &unmanagedSendResult);
				throw;
			}
			basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E* pThis = (basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref unmanagedSendResult, 8));
			try
			{
				global::_003CModule_003E.std_002Ebasic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E_002E_Tidy_deallocate((basic_string_003Cchar_002Cstd_003A_003Achar_traits_003Cchar_003E_002Cstd_003A_003Aallocator_003Cchar_003E_0020_003E*)Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref unmanagedSendResult, 8)));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.___CxxCallUnwindDtor((delegate*<void*, void>)(delegate*<_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E*, void>)(&global::_003CModule_003E.std_002E_Compressed_pair_003Cstd_003A_003Aallocator_003Cchar_003E_002Cstd_003A_003A_String_val_003Cstd_003A_003A_Simple_types_003Cchar_003E_0020_003E_002C1_003E_002E_007Bdtor_007D), pThis);
				throw;
			}
		}
		catch
		{
			//try-fault
			((IDisposable)obj).Dispose();
			throw;
		}
		((IDisposable)obj).Dispose();
		GC.KeepAlive(this);
		return result;
	}

	public unsafe virtual void NativeCallback(byte* buf, ulong size)
	{
		int num = (int)size;
		byte[] array = new byte[num];
		nint source = new IntPtr(buf);
		Marshal.Copy(source, array, 0, num);
		callbacks_.OnRegistrationCallback(array);
		GC.KeepAlive(this);
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			_007ERegistrationInteractor();
		}
		else
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
}
