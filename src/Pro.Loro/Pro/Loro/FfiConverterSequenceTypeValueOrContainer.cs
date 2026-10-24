using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeValueOrContainer : FfiConverterRustBuffer<List<ValueOrContainer>>
{
	public static FfiConverterSequenceTypeValueOrContainer INSTANCE = new FfiConverterSequenceTypeValueOrContainer();

	public override List<ValueOrContainer> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ValueOrContainer> list = new List<ValueOrContainer>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeValueOrContainer.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ValueOrContainer> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ValueOrContainer item) => FfiConverterTypeValueOrContainer.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ValueOrContainer> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ValueOrContainer item)
		{
			FfiConverterTypeValueOrContainer.INSTANCE.Write(item, stream);
		});
	}
}
