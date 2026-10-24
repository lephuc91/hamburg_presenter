using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeIdSpan : FfiConverterRustBuffer<List<IdSpan>>
{
	public static FfiConverterSequenceTypeIdSpan INSTANCE = new FfiConverterSequenceTypeIdSpan();

	public override List<IdSpan> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<IdSpan> list = new List<IdSpan>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeIdSpan.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<IdSpan> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((IdSpan item) => FfiConverterTypeIdSpan.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<IdSpan> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(IdSpan item)
		{
			FfiConverterTypeIdSpan.INSTANCE.Write(item, stream);
		});
	}
}
