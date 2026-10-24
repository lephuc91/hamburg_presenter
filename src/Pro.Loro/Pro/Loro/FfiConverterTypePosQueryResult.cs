namespace Pro.Loro;

internal class FfiConverterTypePosQueryResult : FfiConverterRustBuffer<PosQueryResult>
{
	public static FfiConverterTypePosQueryResult INSTANCE = new FfiConverterTypePosQueryResult();

	public override PosQueryResult Read(BigEndianStream stream)
	{
		return new PosQueryResult(FfiConverterOptionalTypeCursor.INSTANCE.Read(stream), FfiConverterTypeAbsolutePosition.INSTANCE.Read(stream));
	}

	public override int AllocationSize(PosQueryResult value)
	{
		return FfiConverterOptionalTypeCursor.INSTANCE.AllocationSize(value.update) + FfiConverterTypeAbsolutePosition.INSTANCE.AllocationSize(value.current);
	}

	public override void Write(PosQueryResult value, BigEndianStream stream)
	{
		FfiConverterOptionalTypeCursor.INSTANCE.Write(value.update, stream);
		FfiConverterTypeAbsolutePosition.INSTANCE.Write(value.current, stream);
	}
}
