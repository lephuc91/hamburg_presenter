using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeContainerDiff : FfiConverterRustBuffer<List<ContainerDiff>>
{
	public static FfiConverterSequenceTypeContainerDiff INSTANCE = new FfiConverterSequenceTypeContainerDiff();

	public override List<ContainerDiff> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ContainerDiff> list = new List<ContainerDiff>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeContainerDiff.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ContainerDiff> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ContainerDiff item) => FfiConverterTypeContainerDiff.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ContainerDiff> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ContainerDiff item)
		{
			FfiConverterTypeContainerDiff.INSTANCE.Write(item, stream);
		});
	}
}
