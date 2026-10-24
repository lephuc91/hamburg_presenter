using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypePathItem : FfiConverterRustBuffer<List<PathItem>>
{
	public static FfiConverterSequenceTypePathItem INSTANCE = new FfiConverterSequenceTypePathItem();

	public override List<PathItem> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<PathItem> list = new List<PathItem>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypePathItem.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<PathItem> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((PathItem item) => FfiConverterTypePathItem.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<PathItem> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(PathItem item)
		{
			FfiConverterTypePathItem.INSTANCE.Write(item, stream);
		});
	}
}
