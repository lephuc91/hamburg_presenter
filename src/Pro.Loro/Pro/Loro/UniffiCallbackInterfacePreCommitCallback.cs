using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfacePreCommitCallback
{
	private static _UniFFILib.UniffiCallbackInterfacePreCommitCallbackMethod0 _m0 = OnPreCommit;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfacePreCommitCallback _vtable = new _UniFFILib.UniffiVTableCallbackInterfacePreCommitCallback
	{
		onPreCommit = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnPreCommit(ulong uniffiHandle, RustBuffer payload, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypePreCommitCallback.INSTANCE.handleMap.TryGet(uniffiHandle, out PreCommitCallback result))
		{
			result.OnPreCommit(FfiConverterTypePreCommitCallbackPayload.INSTANCE.Lift(payload));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypePreCommitCallback.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_precommitcallback(ref _vtable);
	}
}
