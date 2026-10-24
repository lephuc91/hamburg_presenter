namespace Pro.Loro;

internal class FfiConverterTypeContainerIDAndDiff : FfiConverterRustBuffer<ContainerIdAndDiff>
{
	public static FfiConverterTypeContainerIDAndDiff INSTANCE = new FfiConverterTypeContainerIDAndDiff();

	public override ContainerIdAndDiff Read(BigEndianStream stream)
	{
		return new ContainerIdAndDiff(FfiConverterTypeContainerID.INSTANCE.Read(stream), FfiConverterTypeDiff.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ContainerIdAndDiff value)
	{
		return FfiConverterTypeContainerID.INSTANCE.AllocationSize(value.cid) + FfiConverterTypeDiff.INSTANCE.AllocationSize(value.diff);
	}

	public override void Write(ContainerIdAndDiff value, BigEndianStream stream)
	{
		FfiConverterTypeContainerID.INSTANCE.Write(value.cid, stream);
		FfiConverterTypeDiff.INSTANCE.Write(value.diff, stream);
	}
}
