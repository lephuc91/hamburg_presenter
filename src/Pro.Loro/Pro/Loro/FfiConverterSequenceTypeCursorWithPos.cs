using System.Collections.Generic;
using System.Linq;

namespace Pro.Loro;

internal class FfiConverterSequenceTypeCursorWithPos : FfiConverterRustBuffer<List<CursorWithPos>>
{
	public static FfiConverterSequenceTypeCursorWithPos INSTANCE = new FfiConverterSequenceTypeCursorWithPos();

	public override List<CursorWithPos> Read(BigEndianStream stream)
	{
		int num = stream.ReadInt();
		List<CursorWithPos> list = new List<CursorWithPos>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(FfiConverterTypeCursorWithPos.INSTANCE.Read(stream));
		}
		return list;
	}

	public override int AllocationSize(List<CursorWithPos> value)
	{
		int num = 4;
		if (value == null)
		{
			return num;
		}
		int num2 = value.Select((CursorWithPos item) => FfiConverterTypeCursorWithPos.INSTANCE.AllocationSize(item)).Sum();
		return num + num2;
	}

	public override void Write(List<CursorWithPos> value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteInt(0);
			return;
		}
		stream.WriteInt(value.Count);
		value.ForEach(delegate(CursorWithPos item)
		{
			FfiConverterTypeCursorWithPos.INSTANCE.Write(item, stream);
		});
	}
}
