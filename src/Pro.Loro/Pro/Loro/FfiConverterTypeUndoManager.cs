using System;

namespace Pro.Loro;

internal class FfiConverterTypeUndoManager : FfiConverter<UndoManager, IntPtr>
{
	public static FfiConverterTypeUndoManager INSTANCE = new FfiConverterTypeUndoManager();

	public override IntPtr Lower(UndoManager value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override UndoManager Lift(IntPtr value)
	{
		return new UndoManager(value);
	}

	public override UndoManager Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(UndoManager value)
	{
		return 8;
	}

	public override void Write(UndoManager value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
