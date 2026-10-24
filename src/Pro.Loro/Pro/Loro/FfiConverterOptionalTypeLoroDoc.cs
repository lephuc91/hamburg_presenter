namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroDoc : FfiConverterRustBuffer<LoroDoc?>
{
	public static FfiConverterOptionalTypeLoroDoc INSTANCE = new FfiConverterOptionalTypeLoroDoc();

	public override LoroDoc? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroDoc.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroDoc? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroDoc.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroDoc? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroDoc.INSTANCE.Write(value, stream);
	}
}
