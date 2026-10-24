using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceOnPush
{
	private static _UniFFILib.UniffiCallbackInterfaceOnPushMethod0 _m0 = OnPush;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceOnPush _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceOnPush
	{
		onPush = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void OnPush(ulong uniffiHandle, RustBuffer undoOrRedo, RustBuffer span, RustBuffer diffEvent, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeOnPush.INSTANCE.handleMap.TryGet(uniffiHandle, out OnPush result))
		{
			UndoItemMeta value = result.OnPush(FfiConverterTypeUndoOrRedo.INSTANCE.Lift(undoOrRedo), FfiConverterTypeCounterSpan.INSTANCE.Lift(span), FfiConverterOptionalTypeDiffEvent.INSTANCE.Lift(diffEvent));
			uniffiOutReturn = FfiConverterTypeUndoItemMeta.INSTANCE.Lower(value);
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeOnPush.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_onpush(ref _vtable);
	}
}
