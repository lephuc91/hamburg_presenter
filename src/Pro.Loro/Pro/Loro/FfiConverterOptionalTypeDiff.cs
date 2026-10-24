namespace Pro.Loro;

internal class FfiConverterOptionalTypeDiff : FfiConverterRustBuffer<Diff?>
{
	public static FfiConverterOptionalTypeDiff INSTANCE = new FfiConverterOptionalTypeDiff();

	public override Diff? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeDiff.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Diff? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeDiff.INSTANCE.AllocationSize(value);
	}

	public override void Write(Diff? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeDiff.INSTANCE.Write(value, stream);
	}
}
