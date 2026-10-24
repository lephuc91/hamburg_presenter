namespace Pro.Loro;

internal class FfiConverterTypeMapDelta : FfiConverterRustBuffer<MapDelta>
{
	public static FfiConverterTypeMapDelta INSTANCE = new FfiConverterTypeMapDelta();

	public override MapDelta Read(BigEndianStream stream)
	{
		return new MapDelta(FfiConverterDictionaryStringOptionalTypeValueOrContainer.INSTANCE.Read(stream));
	}

	public override int AllocationSize(MapDelta value)
	{
		return FfiConverterDictionaryStringOptionalTypeValueOrContainer.INSTANCE.AllocationSize(value.updated);
	}

	public override void Write(MapDelta value, BigEndianStream stream)
	{
		FfiConverterDictionaryStringOptionalTypeValueOrContainer.INSTANCE.Write(value.updated, stream);
	}
}
