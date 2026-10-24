using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeListDiffItem : FfiConverterRustBuffer<List<ListDiffItem>>
{
	public static FfiConverterSequenceTypeListDiffItem INSTANCE = new FfiConverterSequenceTypeListDiffItem();

	public override List<ListDiffItem> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ListDiffItem> list = new List<ListDiffItem>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeListDiffItem.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ListDiffItem> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ListDiffItem item) => FfiConverterTypeListDiffItem.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ListDiffItem> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ListDiffItem item)
		{
			FfiConverterTypeListDiffItem.INSTANCE.Write(item, stream);
		});
	}
}
