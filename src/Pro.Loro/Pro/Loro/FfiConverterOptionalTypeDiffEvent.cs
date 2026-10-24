namespace Pro.Loro;

internal class FfiConverterOptionalTypeDiffEvent : FfiConverterRustBuffer<DiffEvent?>
{
	public static FfiConverterOptionalTypeDiffEvent INSTANCE = new FfiConverterOptionalTypeDiffEvent();

	public override DiffEvent? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeDiffEvent.INSTANCE.Read(stream);
	}

	public override int AllocationSize(DiffEvent? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeDiffEvent.INSTANCE.AllocationSize(value);
	}

	public override void Write(DiffEvent? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeDiffEvent.INSTANCE.Write(value, stream);
	}
}
