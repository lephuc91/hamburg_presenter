using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterDictionaryStringOptionalTypeValueOrContainer : FfiConverterRustBuffer<Dictionary<string, ValueOrContainer?>>
{
	public static FfiConverterDictionaryStringOptionalTypeValueOrContainer INSTANCE = new FfiConverterDictionaryStringOptionalTypeValueOrContainer();

	public override Dictionary<string, ValueOrContainer?> Read(BigEndianStream stream)
	{
		Dictionary<string, ValueOrContainer> dictionary = new Dictionary<string, ValueOrContainer>();
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			string key = FfiConverterString.INSTANCE.Read(stream);
			ValueOrContainer value = FfiConverterOptionalTypeValueOrContainer.INSTANCE.Read(stream);
			dictionary[key] = value;
		}
		return dictionary;
	}

	public override int AllocationSize(Dictionary<string, ValueOrContainer?> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select<KeyValuePair<string, ValueOrContainer>, int>((KeyValuePair<string, ValueOrContainer> item) => FfiConverterString.INSTANCE.AllocationSize(item.Key) + FfiConverterOptionalTypeValueOrContainer.INSTANCE.AllocationSize(item.Value)).Sum();
		return num + num2;
	}

	public override void Write(Dictionary<string, ValueOrContainer?> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		foreach (KeyValuePair<string, ValueOrContainer> item in value)
		{
			FfiConverterString.INSTANCE.Write(item.Key, stream);
			FfiConverterOptionalTypeValueOrContainer.INSTANCE.Write(item.Value, stream);
		}
	}
}
