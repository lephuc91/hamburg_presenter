using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeContainerPath : FfiConverterRustBuffer<List<ContainerPath>>
{
	public static FfiConverterSequenceTypeContainerPath INSTANCE = new FfiConverterSequenceTypeContainerPath();

	public override List<ContainerPath> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ContainerPath> list = new List<ContainerPath>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeContainerPath.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ContainerPath> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ContainerPath item) => FfiConverterTypeContainerPath.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ContainerPath> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ContainerPath item)
		{
			FfiConverterTypeContainerPath.INSTANCE.Write(item, stream);
		});
	}
}
