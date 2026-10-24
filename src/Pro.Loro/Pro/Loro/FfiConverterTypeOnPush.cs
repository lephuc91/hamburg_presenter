using System;

namespace Pro.Loro;

internal class FfiConverterTypeOnPush : FfiConverter<OnPush, IntPtr>
{
	public ConcurrentHandleMap<OnPush> handleMap = new ConcurrentHandleMap<OnPush>();

	public static FfiConverterTypeOnPush INSTANCE = new FfiConverterTypeOnPush();

	public override IntPtr Lower(OnPush value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override OnPush Lift(IntPtr value)
	{
		return new OnPushImpl(value);
	}

	public override OnPush Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(OnPush value)
	{
		return 8;
	}

	public override void Write(OnPush value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
