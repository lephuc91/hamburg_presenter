namespace Pro.Loro;

internal class FfiConverterTypeImportBlobMetadata : FfiConverterRustBuffer<ImportBlobMetadata>
{
	public static FfiConverterTypeImportBlobMetadata INSTANCE = new FfiConverterTypeImportBlobMetadata();

	public override ImportBlobMetadata Read(BigEndianStream stream)
	{
		return new ImportBlobMetadata(FfiConverterTypeVersionVector.INSTANCE.Read(stream), FfiConverterTypeVersionVector.INSTANCE.Read(stream), FfiConverterInt64.INSTANCE.Read(stream), FfiConverterTypeFrontiers.INSTANCE.Read(stream), FfiConverterInt64.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterString.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ImportBlobMetadata value)
	{
		return FfiConverterTypeVersionVector.INSTANCE.AllocationSize(value.partialStartVv) + FfiConverterTypeVersionVector.INSTANCE.AllocationSize(value.partialEndVv) + FfiConverterInt64.INSTANCE.AllocationSize(value.startTimestamp) + FfiConverterTypeFrontiers.INSTANCE.AllocationSize(value.startFrontiers) + FfiConverterInt64.INSTANCE.AllocationSize(value.endTimestamp) + FfiConverterUInt32.INSTANCE.AllocationSize(value.changeNum) + FfiConverterString.INSTANCE.AllocationSize(value.mode);
	}

	public override void Write(ImportBlobMetadata value, BigEndianStream stream)
	{
		FfiConverterTypeVersionVector.INSTANCE.Write(value.partialStartVv, stream);
		FfiConverterTypeVersionVector.INSTANCE.Write(value.partialEndVv, stream);
		FfiConverterInt64.INSTANCE.Write(value.startTimestamp, stream);
		FfiConverterTypeFrontiers.INSTANCE.Write(value.startFrontiers, stream);
		FfiConverterInt64.INSTANCE.Write(value.endTimestamp, stream);
		FfiConverterUInt32.INSTANCE.Write(value.changeNum, stream);
		FfiConverterString.INSTANCE.Write(value.mode, stream);
	}
}
