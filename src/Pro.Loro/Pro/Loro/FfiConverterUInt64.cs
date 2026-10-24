namespace Pro.Loro;

internal class FfiConverterUInt64 : FfiConverter<ulong, ulong>
{
	public static FfiConverterUInt64 INSTANCE = new FfiConverterUInt64();

	public override ulong Lift(ulong value)
	{
		return value;
	}

	public override ulong Read(BigEndianStream stream)
	{
		return stream.ReadULong();
	}

	public override ulong Lower(ulong value)
	{
		return value;
	}

	public override int AllocationSize(ulong value)
	{
		return 8;
	}

	public override void Write(ulong value, BigEndianStream stream)
	{
		stream.WriteULong(value);
	}
}
