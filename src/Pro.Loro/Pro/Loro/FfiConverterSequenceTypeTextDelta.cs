using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeTextDelta : FfiConverterRustBuffer<List<TextDelta>>
{
	public static FfiConverterSequenceTypeTextDelta INSTANCE = new FfiConverterSequenceTypeTextDelta();

	public override List<TextDelta> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<TextDelta> list = new List<TextDelta>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeTextDelta.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<TextDelta> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((TextDelta item) => FfiConverterTypeTextDelta.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<TextDelta> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(TextDelta item)
		{
			FfiConverterTypeTextDelta.INSTANCE.Write(item, stream);
		});
	}
}
