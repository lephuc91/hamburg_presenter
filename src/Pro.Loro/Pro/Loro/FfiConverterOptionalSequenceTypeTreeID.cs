using System.Collections.Generic;

namespace Pro.Loro;

internal class FfiConverterOptionalSequenceTypeTreeID : FfiConverterRustBuffer<List<TreeId>?>
{
	public static FfiConverterOptionalSequenceTypeTreeID INSTANCE = new FfiConverterOptionalSequenceTypeTreeID();

	public override List<TreeId>? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterSequenceTypeTreeID.INSTANCE.Read(stream);
	}

	public override int AllocationSize(List<TreeId>? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterSequenceTypeTreeID.INSTANCE.AllocationSize(value);
	}

	public override void Write(List<TreeId>? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterSequenceTypeTreeID.INSTANCE.Write(value, stream);
	}
}
