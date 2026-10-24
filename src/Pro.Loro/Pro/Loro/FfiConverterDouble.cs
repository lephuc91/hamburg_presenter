namespace Pro.Loro;

internal class FfiConverterDouble : FfiConverter<double, double>
{
	public static FfiConverterDouble INSTANCE = new FfiConverterDouble();

	public override double Lift(double value)
	{
		return value;
	}

	public override double Read(BigEndianStream stream)
	{
		return stream.ReadDouble();
	}

	public override double Lower(double value)
	{
		return value;
	}

	public override int AllocationSize(double value)
	{
		return 8;
	}

	public override void Write(double value, BigEndianStream stream)
	{
		stream.WriteDouble(value);
	}
}
