using System;

namespace Pro.Loro;

internal class FfiConverterTypePosType : FfiConverterRustBuffer<PosType>
{
	public static FfiConverterTypePosType INSTANCE = new FfiConverterTypePosType();

	public override PosType Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(PosType), num))
		{
			return (PosType)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypePosType.Read()");
	}

	public override int AllocationSize(PosType value)
	{
		return 4;
	}

	public override void Write(PosType value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
