namespace Pro.Loro;

internal class FfiConverterTypeIdSpan : FfiConverterRustBuffer<IdSpan>
{
	public static FfiConverterTypeIdSpan INSTANCE = new FfiConverterTypeIdSpan();

	public override IdSpan Read(BigEndianStream stream)
	{
		return new IdSpan(FfiConverterUInt64.INSTANCE.Read(stream), FfiConverterTypeCounterSpan.INSTANCE.Read(stream));
	}

	public override int AllocationSize(IdSpan value)
	{
		return FfiConverterUInt64.INSTANCE.AllocationSize(value.peer) + FfiConverterTypeCounterSpan.INSTANCE.AllocationSize(value.counter);
	}

	public override void Write(IdSpan value, BigEndianStream stream)
	{
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
		FfiConverterTypeCounterSpan.INSTANCE.Write(value.counter, stream);
	}
}
