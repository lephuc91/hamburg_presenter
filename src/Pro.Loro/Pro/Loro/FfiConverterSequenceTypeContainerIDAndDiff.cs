using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeContainerIDAndDiff : FfiConverterRustBuffer<List<ContainerIdAndDiff>>
{
	public static FfiConverterSequenceTypeContainerIDAndDiff INSTANCE = new FfiConverterSequenceTypeContainerIDAndDiff();

	public override List<ContainerIdAndDiff> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ContainerIdAndDiff> list = new List<ContainerIdAndDiff>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeContainerIDAndDiff.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ContainerIdAndDiff> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ContainerIdAndDiff item) => FfiConverterTypeContainerIDAndDiff.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ContainerIdAndDiff> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ContainerIdAndDiff item)
		{
			FfiConverterTypeContainerIDAndDiff.INSTANCE.Write(item, stream);
		});
	}
}
