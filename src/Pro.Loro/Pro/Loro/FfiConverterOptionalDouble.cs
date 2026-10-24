namespace Pro.Loro;

internal class FfiConverterOptionalDouble : FfiConverterRustBuffer<double?>
{
	public static FfiConverterOptionalDouble INSTANCE = new FfiConverterOptionalDouble();

	public override double? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterDouble.INSTANCE.Read(stream);
	}

	public override int AllocationSize(double? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterDouble.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(double? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterDouble.INSTANCE.Write(value.Value, stream);
	}
}
