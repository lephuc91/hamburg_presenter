namespace Pro.Loro;

internal class FfiConverterOptionalTypeCursor : FfiConverterRustBuffer<Cursor?>
{
	public static FfiConverterOptionalTypeCursor INSTANCE = new FfiConverterOptionalTypeCursor();

	public override Cursor? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeCursor.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Cursor? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeCursor.INSTANCE.AllocationSize(value);
	}

	public override void Write(Cursor? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeCursor.INSTANCE.Write(value, stream);
	}
}
