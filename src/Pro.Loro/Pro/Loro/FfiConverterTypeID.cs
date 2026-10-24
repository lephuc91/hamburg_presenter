namespace Pro.Loro;

internal class FfiConverterTypeID : FfiConverterRustBuffer<Id>
{
	public static FfiConverterTypeID INSTANCE = new FfiConverterTypeID();

	public override Id Read(BigEndianStream stream)
	{
		return new Id(FfiConverterUInt64.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream));
	}

	public override int AllocationSize(Id value)
	{
		return FfiConverterUInt64.INSTANCE.AllocationSize(value.peer) + FfiConverterInt32.INSTANCE.AllocationSize(value.counter);
	}

	public override void Write(Id value, BigEndianStream stream)
	{
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
		FfiConverterInt32.INSTANCE.Write(value.counter, stream);
	}
}
