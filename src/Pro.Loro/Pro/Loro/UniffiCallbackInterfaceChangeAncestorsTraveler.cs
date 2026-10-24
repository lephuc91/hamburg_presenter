using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceChangeAncestorsTraveler
{
	private static _UniFFILib.UniffiCallbackInterfaceChangeAncestorsTravelerMethod0 _m0 = Travel;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceChangeAncestorsTraveler _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceChangeAncestorsTraveler
	{
		travel = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void Travel(ulong uniffiHandle, RustBuffer change, ref sbyte uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeChangeAncestorsTraveler.INSTANCE.handleMap.TryGet(uniffiHandle, out ChangeAncestorsTraveler result))
		{
			bool value = result.Travel(FfiConverterTypeChangeMeta.INSTANCE.Lift(change));
			uniffiOutReturn = FfiConverterBoolean.INSTANCE.Lower(value);
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeChangeAncestorsTraveler.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_changeancestorstraveler(ref _vtable);
	}
}
