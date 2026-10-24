using System;

namespace Pro.Loro;

internal class FfiConverterTypeSide : FfiConverterRustBuffer<Side>
{
	public static FfiConverterTypeSide INSTANCE = new FfiConverterTypeSide();

	public override Side Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(Side), num))
		{
			return (Side)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeSide.Read()");
	}

	public override int AllocationSize(Side value)
	{
		return 4;
	}

	public override void Write(Side value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
