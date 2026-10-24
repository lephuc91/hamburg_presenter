namespace Pro.Loro;

internal class FfiConverterTypeVersionVectorDiff : FfiConverterRustBuffer<VersionVectorDiff>
{
	public static FfiConverterTypeVersionVectorDiff INSTANCE = new FfiConverterTypeVersionVectorDiff();

	public override VersionVectorDiff Read(BigEndianStream stream)
	{
		return new VersionVectorDiff(FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Read(stream), FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Read(stream));
	}

	public override int AllocationSize(VersionVectorDiff value)
	{
		return FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.AllocationSize(value.retreat) + FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.AllocationSize(value.forward);
	}

	public override void Write(VersionVectorDiff value, BigEndianStream stream)
	{
		FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Write(value.retreat, stream);
		FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Write(value.forward, stream);
	}
}
