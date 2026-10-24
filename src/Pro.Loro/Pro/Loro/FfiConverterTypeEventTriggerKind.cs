using System;

namespace Pro.Loro;

internal class FfiConverterTypeEventTriggerKind : FfiConverterRustBuffer<EventTriggerKind>
{
	public static FfiConverterTypeEventTriggerKind INSTANCE = new FfiConverterTypeEventTriggerKind();

	public override EventTriggerKind Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(EventTriggerKind), num))
		{
			return (EventTriggerKind)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeEventTriggerKind.Read()");
	}

	public override int AllocationSize(EventTriggerKind value)
	{
		return 4;
	}

	public override void Write(EventTriggerKind value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
