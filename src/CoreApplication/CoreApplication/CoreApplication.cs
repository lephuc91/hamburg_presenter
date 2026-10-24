using System;
using System.Runtime.CompilerServices;
using CoreApplication.Registration;

namespace CoreApplication;

public abstract class CoreApplication
{
	private unsafe UnmanagedRegistrationReceiver* _coreRegistrationCommuncationReceiver = null;

	private unsafe UnmanagedNativeCallbackReceiver* _loggingCallbackReceiver;

	private unsafe UnmanagedNativeCallbackReceiver* _errorCallbackReceiver;

	protected unsafe void Start(byte[] @params, IManagedNativeCallbackReceiver callbackReceiver, IManagedNativeCallbackReceiver loggingCallbackReceiver, IManagedNativeCallbackReceiver errorCallbackReceiver)
	{
		//IL_002c: Expected I, but got I8
		//IL_0058: Expected I, but got I8
		//IL_0088: Expected I, but got I8
		//IL_00a6: Expected I4, but got I8
		//IL_00ab: Expected I8, but got I
		//IL_00b1: Expected I8, but got I
		//IL_00c2: Expected I4, but got I8
		//IL_00cb: Expected I8, but got I
		//IL_00dc: Expected I4, but got I8
		//IL_00e0: Expected I8, but got I
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
			UnmanagedNativeCallbackReceiver* ptr3 = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* loggingCallbackReceiver2;
			try
			{
				loggingCallbackReceiver2 = ((ptr3 == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr3, loggingCallbackReceiver, false));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr3, 16uL);
				throw;
			}
			_loggingCallbackReceiver = loggingCallbackReceiver2;
			UnmanagedNativeCallbackReceiver* ptr4 = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
			UnmanagedNativeCallbackReceiver* ptr5;
			try
			{
				ptr5 = ((ptr4 == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr4, errorCallbackReceiver, false));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr4, 16uL);
				throw;
			}
			_errorCallbackReceiver = ptr5;
			Unsafe.SkipInit(out Closure closure);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure, 0, 16);
			*(long*)(&closure) = (nint)ptr2;
			long num = (Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z);
			Unsafe.SkipInit(out Closure closure2);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure2, 0, 16);
			*(long*)(&closure2) = (nint)_loggingCallbackReceiver;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure2, 8)) = num;
			Unsafe.SkipInit(out Closure closure3);
			// IL initblk instruction
			Unsafe.InitBlockUnaligned(ref closure3, 0, 16);
			*(long*)(&closure3) = (nint)ptr5;
			Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure3, 8)) = num;
			global::_003CModule_003E.RegisterErrorCallbacks(closure3);
			global::_003CModule_003E.RegisterLogging(closure2);
			ulong num2 = (ulong)obj.Length();
			global::_003CModule_003E.ApplicationStart(obj.Get(), num2, closure);
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

	protected unsafe void Shutdown(nint application, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_001a: Expected I, but got I8
		//IL_0031: Expected I4, but got I8
		//IL_0035: Expected I8, but got I
		//IL_003f: Expected I8, but got I
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
		global::_003CModule_003E.ApplicationShutdown((Application*)((IntPtr)application).ToPointer(), closure);
		GC.KeepAlive(this);
	}

	protected unsafe nint GetMediaServiceV1(nint application)
	{
		MediaServiceV1* value = global::_003CModule_003E.ApplicationGetMediaServiceV1((Application*)((IntPtr)application).ToPointer());
		nint result = new IntPtr(value);
		GC.KeepAlive(this);
		return result;
	}

	protected unsafe nint GetMediaServiceV2(nint application)
	{
		MediaService* value = global::_003CModule_003E.ApplicationGetMediaService((Application*)((IntPtr)application).ToPointer());
		nint result = new IntPtr(value);
		GC.KeepAlive(this);
		return result;
	}

	protected unsafe nint GetFeatureFlagService(nint application)
	{
		FeatureFlagsService* value = global::_003CModule_003E.ApplicationGetFeatureFlagService((Application*)((IntPtr)application).ToPointer());
		nint result = new IntPtr(value);
		GC.KeepAlive(this);
		return result;
	}

	protected unsafe nint GetWorkspaceService(nint application)
	{
		WorkspaceService* value = global::_003CModule_003E.ApplicationGetWorkspaceService((Application*)((IntPtr)application).ToPointer());
		nint result = new IntPtr(value);
		GC.KeepAlive(this);
		return result;
	}

	protected unsafe nint GetDocumentService(nint application)
	{
		DocumentService* value = global::_003CModule_003E.ApplicationGetDocumentService((Application*)((IntPtr)application).ToPointer());
		nint result = new IntPtr(value);
		GC.KeepAlive(this);
		return result;
	}

	protected unsafe nint GetRegistrationService(nint application, byte[] @params, IManagedNativeCallbackReceiver callbackReceiver)
	{
		//IL_0025: Expected I, but got I8
		//IL_003f: Expected I8, but got I
		//IL_0045: Expected I8, but got I
		//IL_0051: Expected I8, but got I
		PinnedArray_003Cunsigned_0020char_003E obj = null;
		PinnedArray_003Cunsigned_0020char_003E obj2 = new PinnedArray_003Cunsigned_0020char_003E(@params);
		nint result;
		try
		{
			obj = obj2;
			UnmanagedRegistrationReceiver* ptr = (UnmanagedRegistrationReceiver*)global::_003CModule_003E.@new(8uL);
			UnmanagedRegistrationReceiver* ptr2;
			try
			{
				ptr2 = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002ERegistration_002EUnmanagedRegistrationReceiver_002E_007Bctor_007D(ptr, callbackReceiver));
			}
			catch
			{
				//try-fault
				global::_003CModule_003E.delete(ptr, 8uL);
				throw;
			}
			_coreRegistrationCommuncationReceiver = ptr2;
			Unsafe.SkipInit(out CreateOptions createOptions);
			*(long*)(&createOptions) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedRegistrationReceiver_0040Registration_0040CoreApplication_0040_0040_0024_0024FSAXPEAXPEBE_K_0040Z;
			Unsafe.As<CreateOptions, long>(ref Unsafe.AddByteOffset(ref createOptions, 8)) = (nint)ptr2;
			Unsafe.As<CreateOptions, long>(ref Unsafe.AddByteOffset(ref createOptions, 16)) = (nint)obj.Get();
			Unsafe.As<CreateOptions, long>(ref Unsafe.AddByteOffset(ref createOptions, 24)) = obj.Length();
			RegistrationService* value = global::_003CModule_003E.ApplicationGetRegistrationService((Application*)((IntPtr)application).ToPointer(), &createOptions);
			nint num = new IntPtr(value);
			result = num;
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

	protected unsafe void OnShutdownComplete()
	{
		//IL_0020: Expected I, but got I8
		//IL_0046: Expected I, but got I8
		//IL_006d: Expected I, but got I8
		UnmanagedRegistrationReceiver* coreRegistrationCommuncationReceiver = _coreRegistrationCommuncationReceiver;
		if (coreRegistrationCommuncationReceiver != null)
		{
			global::_003CModule_003E.gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E*)coreRegistrationCommuncationReceiver);
			global::_003CModule_003E.delete(coreRegistrationCommuncationReceiver, 8uL);
		}
		_coreRegistrationCommuncationReceiver = null;
		global::_003CModule_003E.UnregisterLogging();
		UnmanagedNativeCallbackReceiver* loggingCallbackReceiver = _loggingCallbackReceiver;
		if (loggingCallbackReceiver != null)
		{
			global::_003CModule_003E.gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E*)loggingCallbackReceiver);
			global::_003CModule_003E.delete(loggingCallbackReceiver, 16uL);
		}
		_loggingCallbackReceiver = null;
		global::_003CModule_003E.UnregisterErrorCallbacks();
		UnmanagedNativeCallbackReceiver* errorCallbackReceiver = _errorCallbackReceiver;
		if (errorCallbackReceiver != null)
		{
			global::_003CModule_003E.gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E*)errorCallbackReceiver);
			global::_003CModule_003E.delete(errorCallbackReceiver, 16uL);
		}
		_errorCallbackReceiver = null;
	}

	public unsafe CoreApplication()
	{
	}//IL_0008: Expected I, but got I8

}
