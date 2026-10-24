namespace Pro.Loro;

public static class LoroMethods
{
	public static ImportBlobMetadata DecodeImportBlobMeta(byte[] bytes, bool checkChecksum)
	{
		return FfiConverterTypeImportBlobMetadata.INSTANCE.Lift(_UniffiHelpers.RustCallWithError(FfiConverterTypeLoroError.INSTANCE, delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_func_decode_import_blob_meta(FfiConverterByteArray.INSTANCE.Lower(bytes), FfiConverterBoolean.INSTANCE.Lower(checkChecksum), ref _status);
		}));
	}

	public static string GetVersion()
	{
		return FfiConverterString.INSTANCE.Lift(_UniffiHelpers.RustCall(delegate(ref UniffiRustCallStatus _status)
		{
			return _UniFFILib.uniffi_loro_ffi_fn_func_get_version(ref _status);
		}));
	}
}
