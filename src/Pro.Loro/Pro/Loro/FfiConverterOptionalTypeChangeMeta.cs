namespace Pro.Loro;

internal class FfiConverterOptionalTypeChangeMeta : FfiConverterRustBuffer<ChangeMeta?>
{
	public static FfiConverterOptionalTypeChangeMeta INSTANCE = new FfiConverterOptionalTypeChangeMeta();

	public override ChangeMeta? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeChangeMeta.INSTANCE.Read(stream);
	}

	public override int AllocationSize(ChangeMeta? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeChangeMeta.INSTANCE.AllocationSize(value);
	}

	public override void Write(ChangeMeta? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeChangeMeta.INSTANCE.Write(value, stream);
	}
}
