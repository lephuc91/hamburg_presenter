namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroTree : FfiConverterRustBuffer<LoroTree?>
{
	public static FfiConverterOptionalTypeLoroTree INSTANCE = new FfiConverterOptionalTypeLoroTree();

	public override LoroTree? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroTree.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroTree? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroTree.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroTree? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroTree.INSTANCE.Write(value, stream);
	}
}
