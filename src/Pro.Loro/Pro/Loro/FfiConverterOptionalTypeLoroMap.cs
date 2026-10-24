namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroMap : FfiConverterRustBuffer<LoroMap?>
{
	public static FfiConverterOptionalTypeLoroMap INSTANCE = new FfiConverterOptionalTypeLoroMap();

	public override LoroMap? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroMap.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroMap? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroMap.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroMap? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroMap.INSTANCE.Write(value, stream);
	}
}
