namespace Pro.Loro;

internal class FfiConverterTypeCounterSpan : FfiConverterRustBuffer<CounterSpan>
{
	public static FfiConverterTypeCounterSpan INSTANCE = new FfiConverterTypeCounterSpan();

	public override CounterSpan Read(BigEndianStream stream)
	{
		return new CounterSpan(FfiConverterInt32.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream));
	}

	public override int AllocationSize(CounterSpan value)
	{
		return FfiConverterInt32.INSTANCE.AllocationSize(value.start) + FfiConverterInt32.INSTANCE.AllocationSize(value.end);
	}

	public override void Write(CounterSpan value, BigEndianStream stream)
	{
		FfiConverterInt32.INSTANCE.Write(value.start, stream);
		FfiConverterInt32.INSTANCE.Write(value.end, stream);
	}
}
