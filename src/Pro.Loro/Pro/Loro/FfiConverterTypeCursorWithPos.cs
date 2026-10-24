namespace Pro.Loro;

internal class FfiConverterTypeCursorWithPos : FfiConverterRustBuffer<CursorWithPos>
{
	public static FfiConverterTypeCursorWithPos INSTANCE = new FfiConverterTypeCursorWithPos();

	public override CursorWithPos Read(BigEndianStream stream)
	{
		return new CursorWithPos(FfiConverterTypeCursor.INSTANCE.Read(stream), FfiConverterTypeAbsolutePosition.INSTANCE.Read(stream));
	}

	public override int AllocationSize(CursorWithPos value)
	{
		return FfiConverterTypeCursor.INSTANCE.AllocationSize(value.cursor) + FfiConverterTypeAbsolutePosition.INSTANCE.AllocationSize(value.pos);
	}

	public override void Write(CursorWithPos value, BigEndianStream stream)
	{
		FfiConverterTypeCursor.INSTANCE.Write(value.cursor, stream);
		FfiConverterTypeAbsolutePosition.INSTANCE.Write(value.pos, stream);
	}
}
