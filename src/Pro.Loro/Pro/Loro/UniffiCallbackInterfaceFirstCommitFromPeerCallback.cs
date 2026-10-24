using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceFirstCommitFromPeerCallback
{
	private static _UniFFILib.UniffiCallbackInterfaceFirstCommitFromPeerCallbackMethod0 _m0 = OnFirstCommitFromPeer;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceFirstCommitFromPeerCallback _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceFirstCommitFromPeerCallback
	{
		onFirstCommitFromPeer = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnFirstCommitFromPeer(ulong uniffiHandle, RustBuffer payload, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeFirstCommitFromPeerCallback.INSTANCE.handleMap.TryGet(uniffiHandle, out FirstCommitFromPeerCallback result))
		{
			result.OnFirstCommitFromPeer(FfiConverterTypeFirstCommitFromPeerPayload.INSTANCE.Lift(payload));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeFirstCommitFromPeerCallback.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_firstcommitfrompeercallback(ref _vtable);
	}
}
