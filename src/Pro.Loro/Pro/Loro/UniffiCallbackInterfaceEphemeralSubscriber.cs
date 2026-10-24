using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceEphemeralSubscriber
{
	private static _UniFFILib.UniffiCallbackInterfaceEphemeralSubscriberMethod0 _m0 = OnEphemeralEvent;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceEphemeralSubscriber _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceEphemeralSubscriber
	{
		onEphemeralEvent = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnEphemeralEvent(ulong uniffiHandle, RustBuffer @event, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeEphemeralSubscriber.INSTANCE.handleMap.TryGet(uniffiHandle, out EphemeralSubscriber result))
		{
			result.OnEphemeralEvent(FfiConverterTypeEphemeralStoreEvent.INSTANCE.Lift(@event));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeEphemeralSubscriber.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_ephemeralsubscriber(ref _vtable);
	}
}
