namespace Pro.Loro;

internal class FfiConverterOptionalTypeContainerID : FfiConverterRustBuffer<ContainerId?>
{
	public static FfiConverterOptionalTypeContainerID INSTANCE = new FfiConverterOptionalTypeContainerID();

	public override ContainerId? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeContainerID.INSTANCE.Read(stream);
	}

	public override int AllocationSize(ContainerId? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeContainerID.INSTANCE.AllocationSize(value);
	}

	public override void Write(ContainerId? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeContainerID.INSTANCE.Write(value, stream);
	}
}
