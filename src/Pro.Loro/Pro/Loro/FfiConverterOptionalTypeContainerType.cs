namespace Pro.Loro;

internal class FfiConverterOptionalTypeContainerType : FfiConverterRustBuffer<ContainerType?>
{
	public static FfiConverterOptionalTypeContainerType INSTANCE = new FfiConverterOptionalTypeContainerType();

	public override ContainerType? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeContainerType.INSTANCE.Read(stream);
	}

	public override int AllocationSize(ContainerType? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeContainerType.INSTANCE.AllocationSize(value);
	}

	public override void Write(ContainerType? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeContainerType.INSTANCE.Write(value, stream);
	}
}
