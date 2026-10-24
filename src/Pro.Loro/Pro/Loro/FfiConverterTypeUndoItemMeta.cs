namespace Pro.Loro;

internal class FfiConverterTypeUndoItemMeta : FfiConverterRustBuffer<UndoItemMeta>
{
	public static FfiConverterTypeUndoItemMeta INSTANCE = new FfiConverterTypeUndoItemMeta();

	public override UndoItemMeta Read(BigEndianStream stream)
	{
		return new UndoItemMeta(FfiConverterTypeLoroValue.INSTANCE.Read(stream), FfiConverterSequenceTypeCursorWithPos.INSTANCE.Read(stream));
	}

	public override int AllocationSize(UndoItemMeta value)
	{
		return FfiConverterTypeLoroValue.INSTANCE.AllocationSize(value.value) + FfiConverterSequenceTypeCursorWithPos.INSTANCE.AllocationSize(value.cursors);
	}

	public override void Write(UndoItemMeta value, BigEndianStream stream)
	{
		FfiConverterTypeLoroValue.INSTANCE.Write(value.value, stream);
		FfiConverterSequenceTypeCursorWithPos.INSTANCE.Write(value.cursors, stream);
	}
}
