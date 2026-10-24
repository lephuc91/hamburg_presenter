namespace Pro.Loro;

internal class FfiConverterTypeTreeID : FfiConverterRustBuffer<TreeId>
{
	public static FfiConverterTypeTreeID INSTANCE = new FfiConverterTypeTreeID();

	public override TreeId Read(BigEndianStream stream)
	{
		return new TreeId(FfiConverterUInt64.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream));
	}

	public override int AllocationSize(TreeId value)
	{
		return FfiConverterUInt64.INSTANCE.AllocationSize(value.peer) + FfiConverterInt32.INSTANCE.AllocationSize(value.counter);
	}

	public override void Write(TreeId value, BigEndianStream stream)
	{
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
		FfiConverterInt32.INSTANCE.Write(value.counter, stream);
	}
}
