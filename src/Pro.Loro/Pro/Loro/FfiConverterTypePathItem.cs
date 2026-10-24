namespace Pro.Loro;

internal class FfiConverterTypePathItem : FfiConverterRustBuffer<PathItem>
{
	public static FfiConverterTypePathItem INSTANCE = new FfiConverterTypePathItem();

	public override PathItem Read(BigEndianStream stream)
	{
		return new PathItem(FfiConverterTypeContainerID.INSTANCE.Read(stream), FfiConverterTypeIndex.INSTANCE.Read(stream));
	}

	public override int AllocationSize(PathItem value)
	{
		return FfiConverterTypeContainerID.INSTANCE.AllocationSize(value.container) + FfiConverterTypeIndex.INSTANCE.AllocationSize(value.index);
	}

	public override void Write(PathItem value, BigEndianStream stream)
	{
		FfiConverterTypeContainerID.INSTANCE.Write(value.container, stream);
		FfiConverterTypeIndex.INSTANCE.Write(value.index, stream);
	}
}
