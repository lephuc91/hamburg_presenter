using System;

namespace Pro.Loro;

internal class FfiConverterTypeLoroCounter : FfiConverter<LoroCounter, IntPtr>
{
	public static FfiConverterTypeLoroCounter INSTANCE = new FfiConverterTypeLoroCounter();

	public override IntPtr Lower(LoroCounter value)
	{
		return value.CallWithPointer((IntPtr thisPtr) => thisPtr);
	}

	public override LoroCounter Lift(IntPtr value)
	{
		return new LoroCounter(value);
	}

	public override LoroCounter Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(LoroCounter value)
	{
		return 8;
	}

	public override void Write(LoroCounter value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
