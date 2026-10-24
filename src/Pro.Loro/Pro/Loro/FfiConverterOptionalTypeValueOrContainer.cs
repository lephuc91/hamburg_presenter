namespace Pro.Loro;

internal class FfiConverterOptionalTypeValueOrContainer : FfiConverterRustBuffer<ValueOrContainer?>
{
	public static FfiConverterOptionalTypeValueOrContainer INSTANCE = new FfiConverterOptionalTypeValueOrContainer();

	public override ValueOrContainer? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeValueOrContainer.INSTANCE.Read(stream);
	}

	public override int AllocationSize(ValueOrContainer? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeValueOrContainer.INSTANCE.AllocationSize(value);
	}

	public override void Write(ValueOrContainer? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeValueOrContainer.INSTANCE.Write(value, stream);
	}
}
