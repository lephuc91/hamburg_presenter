using System;

namespace Pro.Loro;

internal class FfiConverterTypeEphemeralEventTrigger : FfiConverterRustBuffer<EphemeralEventTrigger>
{
	public static FfiConverterTypeEphemeralEventTrigger INSTANCE = new FfiConverterTypeEphemeralEventTrigger();

	public override EphemeralEventTrigger Read(BigEndianStream stream)
	{
		int num = stream.ReadInt() - 1;
		if (Enum.IsDefined(typeof(EphemeralEventTrigger), num))
		{
			return (EphemeralEventTrigger)num;
		}
		throw new InternalException($"invalid enum value '{num}' in FfiConverterTypeEphemeralEventTrigger.Read()");
	}

	public override int AllocationSize(EphemeralEventTrigger value)
	{
		return 4;
	}

	public override void Write(EphemeralEventTrigger value, BigEndianStream stream)
	{
		stream.WriteInt((int)(value + 1));
	}
}
