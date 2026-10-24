using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterDictionaryUInt64TypeCounterSpan : FfiConverterRustBuffer<Dictionary<ulong, CounterSpan>>
{
	public static FfiConverterDictionaryUInt64TypeCounterSpan INSTANCE = new FfiConverterDictionaryUInt64TypeCounterSpan();

	public override Dictionary<ulong, CounterSpan> Read(BigEndianStream stream)
	{
		Dictionary<ulong, CounterSpan> dictionary = new Dictionary<ulong, CounterSpan>();
		int num = stream.ReadInt();
		for (int i = 0; i < num; i++)
		{
			ulong key = FfiConverterUInt64.INSTANCE.Read(stream);
			CounterSpan value = FfiConverterTypeCounterSpan.INSTANCE.Read(stream);
			dictionary[key] = value;
		}
		return dictionary;
	}

	public override int AllocationSize(Dictionary<ulong, CounterSpan> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select<KeyValuePair<ulong, CounterSpan>, int>((KeyValuePair<ulong, CounterSpan> item) => FfiConverterUInt64.INSTANCE.AllocationSize(item.Key) + FfiConverterTypeCounterSpan.INSTANCE.AllocationSize(item.Value)).Sum();
		return num + num2;
	}

	public override void Write(Dictionary<ulong, CounterSpan> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		foreach (KeyValuePair<ulong, CounterSpan> item in value)
		{
			FfiConverterUInt64.INSTANCE.Write(item.Key, stream);
			FfiConverterTypeCounterSpan.INSTANCE.Write(item.Value, stream);
		}
	}
}
