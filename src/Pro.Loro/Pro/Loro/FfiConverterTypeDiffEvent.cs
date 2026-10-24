namespace Pro.Loro;

internal class FfiConverterTypeDiffEvent : FfiConverterRustBuffer<DiffEvent>
{
	public static FfiConverterTypeDiffEvent INSTANCE = new FfiConverterTypeDiffEvent();

	public override DiffEvent Read(BigEndianStream stream)
	{
		return new DiffEvent(FfiConverterTypeEventTriggerKind.INSTANCE.Read(stream), FfiConverterString.INSTANCE.Read(stream), FfiConverterOptionalTypeContainerID.INSTANCE.Read(stream), FfiConverterSequenceTypeContainerDiff.INSTANCE.Read(stream));
	}

	public override int AllocationSize(DiffEvent value)
	{
		return FfiConverterTypeEventTriggerKind.INSTANCE.AllocationSize(value.triggeredBy) + FfiConverterString.INSTANCE.AllocationSize(value.origin) + FfiConverterOptionalTypeContainerID.INSTANCE.AllocationSize(value.currentTarget) + FfiConverterSequenceTypeContainerDiff.INSTANCE.AllocationSize(value.events);
	}

	public override void Write(DiffEvent value, BigEndianStream stream)
	{
		FfiConverterTypeEventTriggerKind.INSTANCE.Write(value.triggeredBy, stream);
		FfiConverterString.INSTANCE.Write(value.origin, stream);
		FfiConverterOptionalTypeContainerID.INSTANCE.Write(value.currentTarget, stream);
		FfiConverterSequenceTypeContainerDiff.INSTANCE.Write(value.events, stream);
	}
}
