using System;

namespace Pro.Loro;

internal class FfiConverterTypeExpandType : FfiConverterRustBuffer<ExpandType>
{
	public static FfiConverterTypeExpandType INSTANCE = new FfiConverterTypeExpandType();

	public override ExpandType Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(ExpandType), num))
		{
			return (ExpandType)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeExpandType.Read()");
	}

	public override int AllocationSize(ExpandType value)
	{
		return 4;
	}

	public override void Write(ExpandType value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
