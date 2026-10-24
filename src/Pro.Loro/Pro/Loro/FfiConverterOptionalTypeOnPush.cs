namespace Pro.Loro;

internal class FfiConverterOptionalTypeOnPush : FfiConverterRustBuffer<OnPush?>
{
	public static FfiConverterOptionalTypeOnPush INSTANCE = new FfiConverterOptionalTypeOnPush();

	public override OnPush? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeOnPush.INSTANCE.Read(stream);
	}

	public override int AllocationSize(OnPush? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeOnPush.INSTANCE.AllocationSize(value);
	}

	public override void Write(OnPush? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeOnPush.INSTANCE.Write(value, stream);
	}
}
