namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroValue : FfiConverterRustBuffer<LoroValue?>
{
	public static FfiConverterOptionalTypeLoroValue INSTANCE = new FfiConverterOptionalTypeLoroValue();

	public override LoroValue? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroValue.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroValue? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroValue.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroValue? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroValue.INSTANCE.Write(value, stream);
	}
}
