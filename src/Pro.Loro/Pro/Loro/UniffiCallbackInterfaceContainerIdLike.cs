using System.Runtime.InteropServices;

namespace Pro.Loro;

internal class UniffiCallbackInterfaceContainerIdLike
{
	private static _UniFFILib.UniffiCallbackInterfaceContainerIdLikeMethod0 _m0 = AsContainerId;

	private static _UniFFILib.UniffiCallbackInterfaceFree _callback_interface_free = UniffiFree;

	public static _UniFFILib.UniffiVTableCallbackInterfaceContainerIdLike _vtable = new _UniFFILib.UniffiVTableCallbackInterfaceContainerIdLike
	{
		asContainerId = Marshal.GetFunctionPointerForDelegate(_m0),
		uniffiFree = Marshal.GetFunctionPointerForDelegate(_callback_interface_free)
	};

	private static void AsContainerId(ulong uniffiHandle, RustBuffer ty, ref RustBuffer uniffiOutReturn, ref UniffiRustCallStatus _uniffi_out_err)
	{
		if (FfiConverterTypeContainerIdLike.INSTANCE.handleMap.TryGet(uniffiHandle, out ContainerIdLike result))
		{
			ContainerId value = result.AsContainerId(FfiConverterTypeContainerType.INSTANCE.Lift(ty));
			uniffiOutReturn = FfiConverterTypeContainerID.INSTANCE.Lower(value);
			return;
		}
		throw new InternalException($"No callback in handlemap '{uniffiHandle}'");
	}

	private static void UniffiFree(ulong handle)
	{
		FfiConverterTypeContainerIdLike.INSTANCE.handleMap.Remove(handle);
	}

	public static void Register()
	{
		_UniFFILib.uniffi_loro_ffi_fn_init_callback_vtable_containeridlike(ref _vtable);
	}
}
