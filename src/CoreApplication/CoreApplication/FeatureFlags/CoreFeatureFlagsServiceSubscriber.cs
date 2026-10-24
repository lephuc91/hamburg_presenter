using System;
using System.Runtime.CompilerServices;

namespace CoreApplication.FeatureFlags;

public abstract class CoreFeatureFlagsServiceSubscriber : IManagedNativeCallbackReceiver
{
	private unsafe UnmanagedNativeCallbackReceiver* _unmanagedReceiver;

	private unsafe FeatureFlagsService* _service;

	protected unsafe CoreFeatureFlagsServiceSubscriber(nint featureFlagService)
	{
		//IL_001a: Expected I, but got I8
		//IL_004b: Expected I4, but got I8
		//IL_0054: Expected I8, but got I
		//IL_005e: Expected I8, but got I
		UnmanagedNativeCallbackReceiver* ptr = (UnmanagedNativeCallbackReceiver*)global::_003CModule_003E.@new(16uL);
		UnmanagedNativeCallbackReceiver* unmanagedReceiver;
		try
		{
			unmanagedReceiver = ((ptr == null) ? null : global::_003CModule_003E.CoreApplication_002EUnmanagedNativeCallbackReceiver_002E_007Bctor_007D(ptr, this, false));
		}
		catch
		{
			//try-fault
			global::_003CModule_003E.delete(ptr, 16uL);
			throw;
		}
		_unmanagedReceiver = unmanagedReceiver;
		_service = (FeatureFlagsService*)((IntPtr)featureFlagService).ToPointer();
		base._002Ector();
		Unsafe.SkipInit(out Closure closure);
		// IL initblk instruction
		Unsafe.InitBlockUnaligned(ref closure, 0, 16);
		*(long*)(&closure) = (nint)_unmanagedReceiver;
		Unsafe.As<Closure, long>(ref Unsafe.AddByteOffset(ref closure, 8)) = (nint)global::_003CModule_003E.__unep_0040_003FNativeCallback_0040UnmanagedNativeCallbackReceiver_0040CoreApplication_0040_0040_0024_0024FSAXPEBX0_K_0040Z;
		global::_003CModule_003E.FeatureFlagsServiceSubscribe(_service, closure);
		GC.KeepAlive(this);
	}

	protected unsafe void CoreUnsubscribe()
	{
		global::_003CModule_003E.FeatureFlagsServiceUnsubscribe(_service);
		GC.KeepAlive(this);
	}

	protected unsafe void Cleanup()
	{
		UnmanagedNativeCallbackReceiver* unmanagedReceiver = _unmanagedReceiver;
		if (unmanagedReceiver != null)
		{
			global::_003CModule_003E.gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E_002E_007Bdtor_007D((gcroot_003CCoreApplication_003A_003AIManagedNativeCallbackReceiver_0020_005E_003E*)unmanagedReceiver);
			global::_003CModule_003E.delete(unmanagedReceiver, 16uL);
		}
		GC.KeepAlive(this);
	}

	public abstract void NativeCallback(nint instancePointer);

	public abstract void NativeCallback(byte[] protoData);

	public abstract void NativeErrorCallback();
}
