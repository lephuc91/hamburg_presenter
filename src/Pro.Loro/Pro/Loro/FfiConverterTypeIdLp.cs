namespace Pro.Loro;

internal class FfiConverterTypeIdLp : FfiConverterRustBuffer<IdLp>
{
	public static FfiConverterTypeIdLp INSTANCE = new FfiConverterTypeIdLp();

	public override IdLp Read(BigEndianStream stream)
	{
		return new IdLp(FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterUInt64.INSTANCE.Read(stream));
	}

	public override int AllocationSize(IdLp value)
	{
		return FfiConverterUInt32.INSTANCE.AllocationSize(value.lamport) + FfiConverterUInt64.INSTANCE.AllocationSize(value.peer);
	}

	public override void Write(IdLp value, BigEndianStream stream)
	{
		FfiConverterUInt32.INSTANCE.Write(value.lamport, stream);
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
	}
}
