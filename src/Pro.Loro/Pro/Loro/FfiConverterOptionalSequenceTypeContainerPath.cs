using System.Collections.Generic;

namespace Pro.Loro;

internal class FfiConverterOptionalSequenceTypeContainerPath : FfiConverterRustBuffer<List<ContainerPath>?>
{
	public static FfiConverterOptionalSequenceTypeContainerPath INSTANCE = new FfiConverterOptionalSequenceTypeContainerPath();

	public override List<ContainerPath>? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterSequenceTypeContainerPath.INSTANCE.Read(stream);
	}

	public override int AllocationSize(List<ContainerPath>? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterSequenceTypeContainerPath.INSTANCE.AllocationSize(value);
	}

	public override void Write(List<ContainerPath>? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterSequenceTypeContainerPath.INSTANCE.Write(value, stream);
	}
}
