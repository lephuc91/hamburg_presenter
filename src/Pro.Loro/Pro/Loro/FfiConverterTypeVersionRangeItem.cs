namespace Pro.Loro;

internal class FfiConverterTypeVersionRangeItem : FfiConverterRustBuffer<VersionRangeItem>
{
	public static FfiConverterTypeVersionRangeItem INSTANCE = new FfiConverterTypeVersionRangeItem();

	public override VersionRangeItem Read(BigEndianStream stream)
	{
		return new VersionRangeItem(FfiConverterUInt64.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream), FfiConverterInt32.INSTANCE.Read(stream));
	}

	public override int AllocationSize(VersionRangeItem value)
	{
		return FfiConverterUInt64.INSTANCE.AllocationSize(value.peer) + FfiConverterInt32.INSTANCE.AllocationSize(value.start) + FfiConverterInt32.INSTANCE.AllocationSize(value.end);
	}

	public override void Write(VersionRangeItem value, BigEndianStream stream)
	{
		FfiConverterUInt64.INSTANCE.Write(value.peer, stream);
		FfiConverterInt32.INSTANCE.Write(value.start, stream);
		FfiConverterInt32.INSTANCE.Write(value.end, stream);
	}
}
