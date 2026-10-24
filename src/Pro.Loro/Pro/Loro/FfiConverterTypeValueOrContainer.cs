using System;

namespace Pro.Loro;

internal class FfiConverterTypeValueOrContainer : FfiConverter<ValueOrContainer, IntPtr>
{
	public static FfiConverterTypeValueOrContainer INSTANCE = new FfiConverterTypeValueOrContainer();

	public override IntPtr Lower(ValueOrContainer value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override ValueOrContainer Lift(IntPtr value)
	{
		return new ValueOrContainer(value);
	}

	public override ValueOrContainer Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(ValueOrContainer value)
	{
		return 8;
	}

	public override void Write(ValueOrContainer value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
