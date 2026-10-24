using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeIndex : FfiConverterRustBuffer<List<Index>>
{
	public static FfiConverterSequenceTypeIndex INSTANCE = new FfiConverterSequenceTypeIndex();

	public override List<Index> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<Index> list = new List<Index>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeIndex.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<Index> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((Index item) => FfiConverterTypeIndex.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<Index> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(Index item)
		{
			FfiConverterTypeIndex.INSTANCE.Write(item, stream);
		});
	}
}
