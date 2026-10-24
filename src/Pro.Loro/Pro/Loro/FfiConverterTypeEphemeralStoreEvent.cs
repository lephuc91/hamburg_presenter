namespace Pro.Loro;

internal class FfiConverterTypeEphemeralStoreEvent : FfiConverterRustBuffer<EphemeralStoreEvent>
{
	public static FfiConverterTypeEphemeralStoreEvent INSTANCE = new FfiConverterTypeEphemeralStoreEvent();

	public override EphemeralStoreEvent Read(BigEndianStream stream)
	{
		return new EphemeralStoreEvent(FfiConverterTypeEphemeralEventTrigger.INSTANCE.Read(stream), FfiConverterSequenceString.INSTANCE.Read(stream), FfiConverterSequenceString.INSTANCE.Read(stream), FfiConverterSequenceString.INSTANCE.Read(stream));
	}

	public override int AllocationSize(EphemeralStoreEvent value)
	{
		return FfiConverterTypeEphemeralEventTrigger.INSTANCE.AllocationSize(value.by) + FfiConverterSequenceString.INSTANCE.AllocationSize(value.added) + FfiConverterSequenceString.INSTANCE.AllocationSize(value.removed) + FfiConverterSequenceString.INSTANCE.AllocationSize(value.updated);
	}

	public override void Write(EphemeralStoreEvent value, BigEndianStream stream)
	{
		FfiConverterTypeEphemeralEventTrigger.INSTANCE.Write(value.by, stream);
		FfiConverterSequenceString.INSTANCE.Write(value.added, stream);
		FfiConverterSequenceString.INSTANCE.Write(value.removed, stream);
		FfiConverterSequenceString.INSTANCE.Write(value.updated, stream);
	}
}
