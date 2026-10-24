using System;

namespace Pro.Loro;

internal class FfiConverterTypeAwareness : FfiConverter<Awareness, IntPtr>
{
	public static FfiConverterTypeAwareness INSTANCE = new FfiConverterTypeAwareness();

	public override IntPtr Lower(Awareness value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override Awareness Lift(IntPtr value)
	{
		return new Awareness(value);
	}

	public override Awareness Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Awareness value)
	{
		return 8;
	}

	public override void Write(Awareness value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
