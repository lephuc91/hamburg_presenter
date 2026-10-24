using System;

namespace Pro.Loro;

internal class FfiConverterTypeOrdering : FfiConverterRustBuffer<Ordering>
{
	public static FfiConverterTypeOrdering INSTANCE = new FfiConverterTypeOrdering();

	public override Ordering Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(Ordering), num))
		{
			return (Ordering)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeOrdering.Read()");
	}

	public override int AllocationSize(Ordering value)
	{
		return 4;
	}

	public override void Write(Ordering value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
