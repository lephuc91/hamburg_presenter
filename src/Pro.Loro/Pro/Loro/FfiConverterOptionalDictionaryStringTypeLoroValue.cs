using System.Collections.Generic;

namespace Pro.Loro;

internal class FfiConverterOptionalDictionaryStringTypeLoroValue : FfiConverterRustBuffer<Dictionary<string, LoroValue>?>
{
	public static FfiConverterOptionalDictionaryStringTypeLoroValue INSTANCE = new FfiConverterOptionalDictionaryStringTypeLoroValue();

	public override Dictionary<string, LoroValue>? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterDictionaryStringTypeLoroValue.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Dictionary<string, LoroValue>? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterDictionaryStringTypeLoroValue.INSTANCE.AllocationSize(value);
	}

	public override void Write(Dictionary<string, LoroValue>? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterDictionaryStringTypeLoroValue.INSTANCE.Write(value, stream);
	}
}
