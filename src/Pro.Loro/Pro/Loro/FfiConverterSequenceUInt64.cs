using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceUInt64 : FfiConverterRustBuffer<List<ulong>>
{
	public static FfiConverterSequenceUInt64 INSTANCE = new FfiConverterSequenceUInt64();

	public override List<ulong> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<ulong> list = new List<ulong>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterUInt64.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<ulong> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((ulong item) => FfiConverterUInt64.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<ulong> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(ulong item)
		{
			FfiConverterUInt64.INSTANCE.Write(item, stream);
		});
	}
}
