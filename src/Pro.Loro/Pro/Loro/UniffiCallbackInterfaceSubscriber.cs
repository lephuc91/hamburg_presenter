using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceSubscriber
{
	private static _UniFFILib.UniffiCallbackInterfaceSubscriberMethod0 _m0 = OnDiff;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceSubscriber _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceSubscriber
	{
		onDiff = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnDiff(ulong uniffiHandle, RustBuffer diff, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeSubscriber.INSTANCE.handleMap.TryGet(uniffiHandle, out Subscriber result))
		{
			result.OnDiff(FfiConverterTypeDiffEvent.INSTANCE.Lift(diff));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeSubscriber.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_subscriber(ref _vtable);
	}
}
