using System;

namespace Pro.Loro;

internal class FfiConverterTypeSubscriber : FfiConverter<Subscriber, IntPtr>
{
	public ConcurrentHandleMap<Subscriber> handleMap = new ConcurrentHandleMap<Subscriber>();

	public static FfiConverterTypeSubscriber INSTANCE = new FfiConverterTypeSubscriber();

	public override IntPtr Lower(Subscriber value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override Subscriber Lift(IntPtr value)
	{
		return new SubscriberImpl(value);
	}

	public override Subscriber Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(Subscriber value)
	{
		return 8;
	}

	public override void Write(Subscriber value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
