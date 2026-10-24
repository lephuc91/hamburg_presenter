using System;

namespace Pro.Loro;

internal class FfiConverterTypeEphemeralSubscriber : FfiConverter<EphemeralSubscriber, IntPtr>
{
	public ConcurrentHandleMap<EphemeralSubscriber> handleMap = new ConcurrentHandleMap<EphemeralSubscriber>();

	public static FfiConverterTypeEphemeralSubscriber INSTANCE = new FfiConverterTypeEphemeralSubscriber();

	public override IntPtr Lower(EphemeralSubscriber value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override EphemeralSubscriber Lift(IntPtr value)
	{
		return new EphemeralSubscriberImpl(value);
	}

	public override EphemeralSubscriber Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(EphemeralSubscriber value)
	{
		return 8;
	}

	public override void Write(EphemeralSubscriber value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
