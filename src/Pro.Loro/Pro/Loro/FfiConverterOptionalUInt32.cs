namespace Pro.Loro;

internal class FfiConverterOptionalUInt32 : FfiConverterRustBuffer<uint?>
{
	public static FfiConverterOptionalUInt32 INSTANCE = new FfiConverterOptionalUInt32();

	public override uint? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterUInt32.INSTANCE.Read(stream);
	}

	public override int AllocationSize(uint? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterUInt32.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(uint? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterUInt32.INSTANCE.Write(value.Value, stream);
	}
}
