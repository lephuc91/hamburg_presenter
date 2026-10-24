namespace Pro.Loro;

internal class FfiConverterOptionalTypeCounterSpan : FfiConverterRustBuffer<CounterSpan?>
{
	public static FfiConverterOptionalTypeCounterSpan INSTANCE = new FfiConverterOptionalTypeCounterSpan();

	public override CounterSpan? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeCounterSpan.INSTANCE.Read(stream);
	}

	public override int AllocationSize(CounterSpan? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeCounterSpan.INSTANCE.AllocationSize(value);
	}

	public override void Write(CounterSpan? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeCounterSpan.INSTANCE.Write(value, stream);
	}
}
