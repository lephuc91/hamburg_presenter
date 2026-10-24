using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceLocalEphemeralListener
{
	private static _UniFFILib.UniffiCallbackInterfaceLocalEphemeralListenerMethod0 _m0 = OnEphemeralUpdate;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceLocalEphemeralListener _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceLocalEphemeralListener
	{
		onEphemeralUpdate = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnEphemeralUpdate(ulong uniffiHandle, RustBuffer update, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeLocalEphemeralListener.INSTANCE.handleMap.TryGet(uniffiHandle, out LocalEphemeralListener result))
		{
			result.OnEphemeralUpdate(FfiConverterByteArray.INSTANCE.Lift(update));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeLocalEphemeralListener.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_localephemerallistener(ref _vtable);
	}
}
