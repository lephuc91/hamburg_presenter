using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeLoroValue : FfiConverterRustBuffer<List<LoroValue>>
{
	public static FfiConverterSequenceTypeLoroValue INSTANCE = new FfiConverterSequenceTypeLoroValue();

	public override List<LoroValue> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<LoroValue> list = new List<LoroValue>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeLoroValue.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<LoroValue> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((LoroValue item) => FfiConverterTypeLoroValue.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<LoroValue> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(LoroValue item)
		{
			FfiConverterTypeLoroValue.INSTANCE.Write(item, stream);
		});
	}
}
