namespace Pro.Loro;

internal class FfiConverterTypeContainerDiff : FfiConverterRustBuffer<ContainerDiff>
{
	public static FfiConverterTypeContainerDiff INSTANCE = new FfiConverterTypeContainerDiff();

	public override ContainerDiff Read(BigEndianStream stream)
	{
		return new ContainerDiff(FfiConverterTypeContainerID.INSTANCE.Read(stream), FfiConverterSequenceTypePathItem.INSTANCE.Read(stream), FfiConverterBoolean.INSTANCE.Read(stream), FfiConverterTypeDiff.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ContainerDiff value)
	{
		return FfiConverterTypeContainerID.INSTANCE.AllocationSize(value.target) + FfiConverterSequenceTypePathItem.INSTANCE.AllocationSize(value.path) + FfiConverterBoolean.INSTANCE.AllocationSize(value.isUnknown) + FfiConverterTypeDiff.INSTANCE.AllocationSize(value.diff);
	}

	public override void Write(ContainerDiff value, BigEndianStream stream)
	{
		FfiConverterTypeContainerID.INSTANCE.Write(value.target, stream);
		FfiConverterSequenceTypePathItem.INSTANCE.Write(value.path, stream);
		FfiConverterBoolean.INSTANCE.Write(value.isUnknown, stream);
		FfiConverterTypeDiff.INSTANCE.Write(value.diff, stream);
	}
}
