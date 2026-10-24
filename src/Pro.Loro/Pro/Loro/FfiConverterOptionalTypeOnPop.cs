namespace Pro.Loro;

internal class FfiConverterOptionalTypeOnPop : FfiConverterRustBuffer<OnPop?>
{
	public static FfiConverterOptionalTypeOnPop INSTANCE = new FfiConverterOptionalTypeOnPop();

	public override OnPop? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeOnPop.INSTANCE.Read(stream);
	}

	public override int AllocationSize(OnPop? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeOnPop.INSTANCE.AllocationSize(value);
	}

	public override void Write(OnPop? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeOnPop.INSTANCE.Write(value, stream);
	}
}
