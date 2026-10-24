namespace Pro.Loro;

internal class FfiConverterOptionalInt32 : FfiConverterRustBuffer<int?>
{
	public static FfiConverterOptionalInt32 INSTANCE = new FfiConverterOptionalInt32();

	public override int? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterInt32.INSTANCE.Read(stream);
	}

	public override int AllocationSize(int? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterInt32.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(int? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterInt32.INSTANCE.Write(value.Value, stream);
	}
}
