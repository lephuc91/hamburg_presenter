using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterDictionaryStringTypeLoroValue : FfiConverterRustBuffer<Dictionary<string, LoroValue>>
{
	public static FfiConverterDictionaryStringTypeLoroValue INSTANCE = new FfiConverterDictionaryStringTypeLoroValue();

	public override Dictionary<string, LoroValue> Read(BigEndianStream stream)
	{
		Dictionary<string, LoroValue> dictionary = new Dictionary<string, LoroValue>();
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			string key = FfiConverterString.INSTANCE.Read(stream);
			LoroValue value = FfiConverterTypeLoroValue.INSTANCE.Read(stream);
			dictionary[key] = value;
		}
		return dictionary;
	}

	public override int AllocationSize(Dictionary<string, LoroValue> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select<KeyValuePair<string, LoroValue>, int>((KeyValuePair<string, LoroValue> item) => FfiConverterString.INSTANCE.AllocationSize(item.Key) + FfiConverterTypeLoroValue.INSTANCE.AllocationSize(item.Value)).Sum();
		return num + num2;
	}

	public override void Write(Dictionary<string, LoroValue> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		foreach (KeyValuePair<string, LoroValue> item in value)
		{
			FfiConverterString.INSTANCE.Write(item.Key, stream);
			FfiConverterTypeLoroValue.INSTANCE.Write(item.Value, stream);
		}
	}
}
