using System;

namespace Pro.Loro;

internal class FfiConverterTypeOnPop : FfiConverter<OnPop, IntPtr>
{
	public ConcurrentHandleMap<OnPop> handleMap = new ConcurrentHandleMap<OnPop>();

	public static FfiConverterTypeOnPop INSTANCE = new FfiConverterTypeOnPop();

	public override IntPtr Lower(OnPop value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override OnPop Lift(IntPtr value)
	{
		return new OnPopImpl(value);
	}

	public override OnPop Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(OnPop value)
	{
		return 8;
	}

	public override void Write(OnPop value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
