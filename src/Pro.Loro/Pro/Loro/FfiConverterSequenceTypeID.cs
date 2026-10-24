using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeID : FfiConverterRustBuffer<List<Id>>
{
	public static FfiConverterSequenceTypeID INSTANCE = new FfiConverterSequenceTypeID();

	public override List<Id> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<Id> list = new List<Id>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeID.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<Id> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((Id item) => FfiConverterTypeID.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<Id> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(Id item)
		{
			FfiConverterTypeID.INSTANCE.Write(item, stream);
		});
	}
}
