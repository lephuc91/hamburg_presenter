namespace Pro.Loro;

internal class FfiConverterTypeAwarenessPeerUpdate : FfiConverterRustBuffer<AwarenessPeerUpdate>
{
	public static FfiConverterTypeAwarenessPeerUpdate INSTANCE = new FfiConverterTypeAwarenessPeerUpdate();

	public override AwarenessPeerUpdate Read(BigEndianStream stream)
	{
		return new AwarenessPeerUpdate(FfiConverterSequenceUInt64.INSTANCE.Read(stream), FfiConverterSequenceUInt64.INSTANCE.Read(stream));
	}

	public override int AllocationSize(AwarenessPeerUpdate value)
	{
		return FfiConverterSequenceUInt64.INSTANCE.AllocationSize(value.updated) + FfiConverterSequenceUInt64.INSTANCE.AllocationSize(value.added);
	}

	public override void Write(AwarenessPeerUpdate value, BigEndianStream stream)
	{
		FfiConverterSequenceUInt64.INSTANCE.Write(value.updated, stream);
		FfiConverterSequenceUInt64.INSTANCE.Write(value.added, stream);
	}
}
