using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceLocalUpdateCallback
{
	private static _UniFFILib.UniffiCallbackInterfaceLocalUpdateCallbackMethod0 _m0 = OnLocalUpdate;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceLocalUpdateCallback _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceLocalUpdateCallback
	{
		onLocalUpdate = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnLocalUpdate(ulong uniffiHandle, RustBuffer update, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeLocalUpdateCallback.INSTANCE.handleMap.TryGet(uniffiHandle, out LocalUpdateCallback result))
		{
			result.OnLocalUpdate(FfiConverterByteArray.INSTANCE.Lift(update));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeLocalUpdateCallback.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_localupdatecallback(ref _vtable);
	}
}
