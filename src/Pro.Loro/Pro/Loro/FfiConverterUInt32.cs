namespace Pro.Loro;

internal class FfiConverterUInt32 : FfiConverter<uint, uint>
{
	public static FfiConverterUInt32 INSTANCE = new FfiConverterUInt32();

	public override uint Lift(uint value)
	{
		return value;
	}

	public override uint Read(BigEndianStream stream)
	{
		return stream.ReadUInt();
	}

	public override uint Lower(uint value)
	{
		return value;
	}

	public override int AllocationSize(uint value)
	{
		return 4;
	}

	public override void Write(uint value, BigEndianStream stream)
	{
		stream.WriteUInt(value);
	}
}
