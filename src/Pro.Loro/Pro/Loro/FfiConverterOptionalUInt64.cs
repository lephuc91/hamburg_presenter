namespace Pro.Loro;

internal class FfiConverterOptionalUInt64 : FfiConverterRustBuffer<ulong?>
{
	public static FfiConverterOptionalUInt64 INSTANCE = new FfiConverterOptionalUInt64();

	public override ulong? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterUInt64.INSTANCE.Read(stream);
	}

	public override int AllocationSize(ulong? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterUInt64.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(ulong? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterUInt64.INSTANCE.Write(value.Value, stream);
	}
}
