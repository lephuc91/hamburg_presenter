using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceJsonPathSubscriber
{
	private static _UniFFILib.UniffiCallbackInterfaceJsonPathSubscriberMethod0 _m0 = OnJsonpathChanged;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceJsonPathSubscriber _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceJsonPathSubscriber
	{
		onJsonpathChanged = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnJsonpathChanged(ulong uniffiHandle, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeJsonPathSubscriber.INSTANCE.handleMap.TryGet(uniffiHandle, out JsonPathSubscriber result))
		{
			result.OnJsonpathChanged();
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeJsonPathSubscriber.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_jsonpathsubscriber(ref _vtable);
	}
}
