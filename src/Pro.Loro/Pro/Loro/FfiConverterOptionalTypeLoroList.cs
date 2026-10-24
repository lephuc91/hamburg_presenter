namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroList : FfiConverterRustBuffer<LoroList?>
{
	public static FfiConverterOptionalTypeLoroList INSTANCE = new FfiConverterOptionalTypeLoroList();

	public override LoroList? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroList.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroList? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroList.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroList? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroList.INSTANCE.Write(value, stream);
	}
}
