using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeContainerID : FfiConverterRustBuffer<List<ContainerId>>
{
	public static FfiConverterSequenceTypeContainerID INSTANCE = new FfiConverterSequenceTypeContainerID();

	public override List<ContainerId> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ContainerId> list = new List<ContainerId>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeContainerID.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ContainerId> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ContainerId item) => FfiConverterTypeContainerID.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ContainerId> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ContainerId item)
		{
			FfiConverterTypeContainerID.INSTANCE.Write(item, stream);
		});
	}
}
