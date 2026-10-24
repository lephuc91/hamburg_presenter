using System;

namespace Pro.Loro;

internal class FfiConverterTypeJsonPathSubscriber : FfiConverter<JsonPathSubscriber, IntPtr>
{
	public ConcurrentHandleMap<JsonPathSubscriber> handleMap = new ConcurrentHandleMap<JsonPathSubscriber>();

	public static FfiConverterTypeJsonPathSubscriber INSTANCE = new FfiConverterTypeJsonPathSubscriber();

	public override IntPtr Lower(JsonPathSubscriber value)
	{
		return (IntPtr)(long)handleMap.Insert(value);
	}

	public override JsonPathSubscriber Lift(IntPtr value)
	{
		return new JsonPathSubscriberImpl(value);
	}

	public override JsonPathSubscriber Read(BigEndianStream stream)
	{
		return Lift(new IntPtr(stream.ReadLong()));
	}

	public override int AllocationSize(JsonPathSubscriber value)
	{
		return 8;
	}

	public override void Write(JsonPathSubscriber value, BigEndianStream stream)
	{
		stream.WriteLong(Lower(value).ToInt64());
	}
}
