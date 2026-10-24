using System;

namespace Pro.Loro;

internal class FfiConverterTypeCursor : FfiConverter<Cursor, IntPtr>
{
	public static FfiConverterTypeCursor INSTANCE = new FfiConverterTypeCursor();

	public override IntPtr Lower(Cursor value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override Cursor Lift(IntPtr value)
	{
		return new Cursor(value);
	}

	public override Cursor Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Cursor value)
	{
		return 8;
	}

	public override void Write(Cursor value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
