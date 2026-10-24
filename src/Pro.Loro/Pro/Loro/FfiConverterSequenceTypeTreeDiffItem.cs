using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeTreeDiffItem : FfiConverterRustBuffer<List<TreeDiffItem>>
{
	public static FfiConverterSequenceTypeTreeDiffItem INSTANCE = new FfiConverterSequenceTypeTreeDiffItem();

	public override List<TreeDiffItem> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<TreeDiffItem> list = new List<TreeDiffItem>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeTreeDiffItem.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<TreeDiffItem> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((TreeDiffItem item) => FfiConverterTypeTreeDiffItem.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<TreeDiffItem> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(TreeDiffItem item)
		{
			FfiConverterTypeTreeDiffItem.INSTANCE.Write(item, stream);
		});
	}
}
