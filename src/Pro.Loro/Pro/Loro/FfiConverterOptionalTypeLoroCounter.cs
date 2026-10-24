namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroCounter : FfiConverterRustBuffer<LoroCounter?>
{
	public static FfiConverterOptionalTypeLoroCounter INSTANCE = new FfiConverterOptionalTypeLoroCounter();

	public override LoroCounter? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroCounter.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroCounter? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroCounter.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroCounter? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroCounter.INSTANCE.Write(value, stream);
	}
}
