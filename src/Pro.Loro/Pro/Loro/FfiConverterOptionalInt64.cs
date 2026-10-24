namespace Pro.Loro;

internal class FfiConverterOptionalInt64 : FfiConverterRustBuffer<long?>
{
	public static FfiConverterOptionalInt64 INSTANCE = new FfiConverterOptionalInt64();

	public override long? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterInt64.INSTANCE.Read(stream);
	}

	public override int AllocationSize(long? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterInt64.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(long? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterInt64.INSTANCE.Write(value.Value, stream);
	}
}
