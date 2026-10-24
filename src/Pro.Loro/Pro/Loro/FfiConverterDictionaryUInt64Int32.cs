using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterDictionaryUInt64Int32 : FfiConverterRustBuffer<Dictionary<ulong, int>>
{
	public static FfiConverterDictionaryUInt64Int32 INSTANCE = new FfiConverterDictionaryUInt64Int32();

	public override Dictionary<ulong, int> Read(BigEndianStream stream)
	{
		Dictionary<ulong, int> dictionary = new Dictionary<ulong, int>();
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			ulong key = FfiConverterUInt64.INSTANCE.Read(stream);
			int value = FfiConverterInt32.INSTANCE.Read(stream);
			dictionary[key] = value;
		}
		return dictionary;
	}

	public override int AllocationSize(Dictionary<ulong, int> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((KeyValuePair<ulong, int> item) => FfiConverterUInt64.INSTANCE.AllocationSize(item.Key) + FfiConverterInt32.INSTANCE.AllocationSize(item.Value)).Sum();
		return num + num2;
	}

	public override void Write(Dictionary<ulong, int> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		foreach (KeyValuePair<ulong, int> item in value)
		{
			FfiConverterUInt64.INSTANCE.Write(item.Key, stream);
			FfiConverterInt32.INSTANCE.Write(item.Value, stream);
		}
	}
}
