namespace Pro.Loro;

internal class FfiConverterTypeImportStatus : FfiConverterRustBuffer<ImportStatus>
{
	public static FfiConverterTypeImportStatus INSTANCE = new FfiConverterTypeImportStatus();

	public override ImportStatus Read(BigEndianStream stream)
	{
		return new ImportStatus(FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Read(stream), FfiConverterOptionalDictionaryUInt64TypeCounterSpan.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ImportStatus value)
	{
		return FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.AllocationSize(value.success) + FfiConverterOptionalDictionaryUInt64TypeCounterSpan.INSTANCE.AllocationSize(value.pending);
	}

	public override void Write(ImportStatus value, BigEndianStream stream)
	{
		FfiConverterDictionaryUInt64TypeCounterSpan.INSTANCE.Write(value.success, stream);
		FfiConverterOptionalDictionaryUInt64TypeCounterSpan.INSTANCE.Write(value.pending, stream);
	}
}
