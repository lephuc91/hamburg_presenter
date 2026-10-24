using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceUnsubscriber
{
	private static _UniFFILib.UniffiCallbackInterfaceUnsubscriberMethod0 _m0 = OnUnsubscribe;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceUnsubscriber _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceUnsubscriber
	{
		onUnsubscribe = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnUnsubscribe(ulong uniffiHandle, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeUnsubscriber.INSTANCE.handleMap.TryGet(uniffiHandle, out Unsubscriber result))
		{
			result.OnUnsubscribe();
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeUnsubscriber.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_unsubscriber(ref _vtable);
	}
}
