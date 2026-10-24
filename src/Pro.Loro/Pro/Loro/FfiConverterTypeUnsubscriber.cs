using System;

namespace Pro.Loro;

internal class FfiConverterTypeUnsubscriber : FfiConverter<Unsubscriber, IntPtr>
{
	public ConcurrentHandleMap<Unsubscriber> handleMap = new ConcurrentHandleMap<Unsubscriber>();

	public static FfiConverterTypeUnsubscriber INSTANCE = new FfiConverterTypeUnsubscriber();

	public override IntPtr Lower(Unsubscriber value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override Unsubscriber Lift(IntPtr value)
	{
		return new UnsubscriberImpl(value);
	}

	public override Unsubscriber Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Unsubscriber value)
	{
		return 8;
	}

	public override void Write(Unsubscriber value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
