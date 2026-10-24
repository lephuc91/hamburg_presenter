namespace Pro.Loro;

internal class FfiConverterTypeContainerPath : FfiConverterRustBuffer<ContainerPath>
{
	public static FfiConverterTypeContainerPath INSTANCE = new FfiConverterTypeContainerPath();

	public override ContainerPath Read(BigEndianStream stream)
	{
		return new ContainerPath(FfiConverterTypeContainerID.INSTANCE.Read(stream), FfiConverterTypeIndex.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ContainerPath value)
	{
		return FfiConverterTypeContainerID.INSTANCE.AllocationSize(value.id) + FfiConverterTypeIndex.INSTANCE.AllocationSize(value.path);
	}

	public override void Write(ContainerPath value, BigEndianStream stream)
	{
		FfiConverterTypeContainerID.INSTANCE.Write(value.id, stream);
		FfiConverterTypeIndex.INSTANCE.Write(value.path, stream);
	}
}
