using System.Collections.Generic;

namespace Pro.Loro;

internal class FfiConverterOptionalDictionaryUInt64TypeCounterSpan : FfiConverterRustBuffer<Dictionary<ulong, CounterSpan>?>
{
	public static FfiConverterOptionalDictionaryUInt64TypeCounterSpan INSTANCE = new FfiConverterOptionalDictionaryUInt64TypeCounterSpan();

	public override Dictionary<ulong, CounterSpan>? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Dictionary<ulong, CounterSpan>? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.AllocationSize(value);
	}

	public override void Write(Dictionary<ulong, CounterSpan>? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Write(value, stream);
	}
}
