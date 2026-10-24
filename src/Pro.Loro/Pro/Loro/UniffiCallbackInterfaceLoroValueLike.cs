using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceLoroValueLike
{
	private static _UniFFILib.UniffiCallbackInterfaceLoroValueLikeMethod0 _m0 = AsLoroValue;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceLoroValueLike _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceLoroValueLike
	{
		asLoroValue = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void AsLoroValue(ulong uniffiHandle, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeLoroValueLike.INSTANCE.handleMap.TryGet(uniffiHandle, out LoroValueLike result))
		{
			LoroValue value = result.AsLoroValue();
			uniffiOutReturn = FfiConverterTypeLoroValue.INSTANCE.Lower(value);
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeLoroValueLike.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_lorovaluelike(ref _vtable);
	}
}
