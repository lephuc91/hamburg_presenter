using System;
using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceOnPop
{
	private static _UniFFILib.UniffiCallbackInterfaceOnPopMethod0 _m0 = OnPop;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceOnPop _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceOnPop
	{
		onPop = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnPop(ulong uniffiHandle, RustBuffer undoOrRedo, RustBuffer span, RustBuffer undoMeta, IntPtr uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeOnPop.INSTANCE.handleMap.TryGet(uniffiHandle, out OnPop result))
		{
			result.OnPop(FfiConverterTypeUndoOrRedo.INSTANCE.Lift(undoOrRedo), FfiConverterTypeCounterSpan.INSTANCE.Lift(span), FfiConverterTypeUndoItemMeta.INSTANCE.Lift(undoMeta));
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeOnPop.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_onpop(ref _vtable);
	}
}
