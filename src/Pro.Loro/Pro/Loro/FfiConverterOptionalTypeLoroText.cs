namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroText : FfiConverterRustBuffer<LoroText?>
{
	public static FfiConverterOptionalTypeLoroText INSTANCE = new FfiConverterOptionalTypeLoroText();

	public override LoroText? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroText.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroText? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroText.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroText? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroText.INSTANCE.Write(value, stream);
	}
}
