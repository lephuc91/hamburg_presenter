using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceString : FfiConverterRustBuffer<List<string>>
{
	public static FfiConverterSequenceString INSTANCE = new FfiConverterSequenceString();

	public override List<string> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<string> list = new List<string>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterString.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<string> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((string item) => FfiConverterString.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<string> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(string item)
		{
			FfiConverterString.INSTANCE.Write(item, stream);
		});
	}
}
