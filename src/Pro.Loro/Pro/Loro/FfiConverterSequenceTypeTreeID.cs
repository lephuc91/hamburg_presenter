using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeTreeID : FfiConverterRustBuffer<List<TreeId>>
{
	public static FfiConverterSequenceTypeTreeID INSTANCE = new FfiConverterSequenceTypeTreeID();

	public override List<TreeId> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<TreeId> list = new List<TreeId>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeTreeID.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<TreeId> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((TreeId item) => FfiConverterTypeTreeID.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<TreeId> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(TreeId item)
		{
			FfiConverterTypeTreeID.INSTANCE.Write(item, stream);
		});
	}
}
