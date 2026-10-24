namespace Pro.Loro;

internal class _UniffiHelpers
{
	public delegate void RustCallAction(ref UniffiRustCallStatus status);

	public delegate U RustCallFunc<out U>(ref UniffiRustCallStatus status);

	public static U RustCallWithError<U, E>(CallStatusErrorHandler<E> errorHandler, RustCallFunc<U> callback) where E : UniffiException
	{
		UniffiRustCallStatus status = default(UniffiRustCallStatus);
		U result = callback(ref status);
		if (status.IsSuccess())
		{
			return result;
		}
		if (status.IsError())
		{
			throw errorHandler.Lift(status.error_buf);
		}
		if (status.IsPanic())
		{
			if (status.error_buf.len != 0)
			{
				throw new PanicException(FfiConverterString.INSTANCE.Lift(status.error_buf));
			}
			throw new PanicException("Rust panic");
		}
		throw new InternalException($"Unknown rust call status: {status.code}");
	}

	public static void RustCallWithError<E>(CallStatusErrorHandler<E> errorHandler, RustCallAction callback) where E : UniffiException
	{
		RustCallWithError(errorHandler, delegate(ref UniffiRustCallStatus status)
		{
			callback(ref status);
			return 0;
		});
	}

	public static U RustCall<U>(RustCallFunc<U> callback)
	{
		return RustCallWithError(NullCallStatusErrorHandler.INSTANCE, callback);
	}

	public static void RustCall(RustCallAction callback)
	{
		RustCall(delegate(ref UniffiRustCallStatus status)
		{
			callback(ref status);
			return 0;
		});
	}
}
