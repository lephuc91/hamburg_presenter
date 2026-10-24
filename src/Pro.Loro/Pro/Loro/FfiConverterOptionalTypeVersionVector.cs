namespace Pro.Loro;

internal class FfiConverterOptionalTypeVersionVector : FfiConverterRustBuffer<VersionVector?>
{
	public static FfiConverterOptionalTypeVersionVector INSTANCE = new FfiConverterOptionalTypeVersionVector();

	public override VersionVector? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeVersionVector.INSTANCE.Read(stream);
	}

	public override int AllocationSize(VersionVector? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeVersionVector.INSTANCE.AllocationSize(value);
	}

	public override void Write(VersionVector? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeVersionVector.INSTANCE.Write(value, stream);
	}
}
