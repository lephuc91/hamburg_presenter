using System;

namespace Pro.Loro;

internal class FfiConverterTypeChangeModifier : FfiConverter<ChangeModifier, IntPtr>
{
	public static FfiConverterTypeChangeModifier INSTANCE = new FfiConverterTypeChangeModifier();

	public override IntPtr Lower(ChangeModifier value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override ChangeModifier Lift(IntPtr value)
	{
		return new ChangeModifier(value);
	}

	public override ChangeModifier Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(ChangeModifier value)
	{
		return 8;
	}

	public override void Write(ChangeModifier value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
