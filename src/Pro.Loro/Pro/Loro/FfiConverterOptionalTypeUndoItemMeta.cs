namespace Pro.Loro;

internal class FfiConverterOptionalTypeUndoItemMeta : FfiConverterRustBuffer<UndoItemMeta?>
{
	public static FfiConverterOptionalTypeUndoItemMeta INSTANCE = new FfiConverterOptionalTypeUndoItemMeta();

	public override UndoItemMeta? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeUndoItemMeta.INSTANCE.Read(stream);
	}

	public override int AllocationSize(UndoItemMeta? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeUndoItemMeta.INSTANCE.AllocationSize(value);
	}

	public override void Write(UndoItemMeta? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeUndoItemMeta.INSTANCE.Write(value, stream);
	}
}
