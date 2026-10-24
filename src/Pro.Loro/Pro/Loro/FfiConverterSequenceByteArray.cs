using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceByteArray : FfiConverterRustBuffer<List<byte[]>>
{
	public static FfiConverterSequenceByteArray INSTANCE = new FfiConverterSequenceByteArray();

	public override List<byte[]> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<byte[]> list = new List<byte[]>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterByteArray.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<byte[]> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((byte[] item) => FfiConverterByteArray.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<byte[]> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(byte[] item)
		{
			FfiConverterByteArray.INSTANCE.Write(item, stream);
		});
	}
}
