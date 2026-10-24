namespace Pro.Loro;

internal class FfiConverterUInt8 : FfiConverter<byte, byte>
{
	public static FfiConverterUInt8 INSTANCE = new FfiConverterUInt8();

	public override byte Lift(byte value)
	{
		return value;
	}

	public override byte Read(BigEndianStream stream)
	{
		return stream.ReadByte();
	}

	public override byte Lower(byte value)
	{
		return value;
	}

	public override int AllocationSize(byte value)
	{
		return 1;
	}

	public override void Write(byte value, BigEndianStream stream)
	{
		stream.WriteByte(value);
	}
}
