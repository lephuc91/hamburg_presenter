namespace Pro.Loro;

internal class FfiConverterTypeUpdateTimeoutError : FfiConverterRustBuffer<UpdateTimeoutException>, CallStatusErrorHandler<UpdateTimeoutException>
{
	public static FfiConverterTypeUpdateTimeoutError INSTANCE = new FfiConverterTypeUpdateTimeoutError();

	public override UpdateTimeoutException Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		if (num == 1)
		{
			return new UpdateTimeoutException.Timeout(FfiConverterString.INSTANCE.Read(stream));
		}
		throw new InternalException($"invalid error value '{num}' in FfiConverterTypeUpdateTimeoutError.Read()");
	}

	public override int AllocationSize(UpdateTimeoutException value)
	{
		return 4 + FfiConverterString.INSTANCE.AllocationSize(value.Message);
	}

	public override void Write(UpdateTimeoutException value, BigEndianStream stream)
	{
		if (value is UpdateTimeoutException.Timeout)
		{
			stream.WriteInt(1);
			return;
		}
		throw new InternalException($"invalid error value '{value}' in FfiConverterTypeUpdateTimeoutError.Write()");
	}
}
