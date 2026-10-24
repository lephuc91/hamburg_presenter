using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeVersionRangeItem : FfiConverterRustBuffer<List<VersionRangeItem>>
{
	public static FfiConverterSequenceTypeVersionRangeItem INSTANCE = new FfiConverterSequenceTypeVersionRangeItem();

	public override List<VersionRangeItem> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<VersionRangeItem> list = new List<VersionRangeItem>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeVersionRangeItem.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<VersionRangeItem> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((VersionRangeItem item) => FfiConverterTypeVersionRangeItem.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<VersionRangeItem> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(VersionRangeItem item)
		{
			FfiConverterTypeVersionRangeItem.INSTANCE.Write(item, stream);
		});
	}
}
