using System;

namespace Pro.Loro;

internal class FfiConverterTypeUndoOrRedo : FfiConverterRustBuffer<UndoOrRedo>
{
	public static FfiConverterTypeUndoOrRedo INSTANCE = new FfiConverterTypeUndoOrRedo();

	public override UndoOrRedo Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(UndoOrRedo), num))
		{
			return (UndoOrRedo)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeUndoOrRedo.Read()");
	}

	public override int AllocationSize(UndoOrRedo value)
	{
		return 4;
	}

	public override void Write(UndoOrRedo value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
