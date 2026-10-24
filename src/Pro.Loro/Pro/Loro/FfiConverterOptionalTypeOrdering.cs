namespace Pro.Loro;

internal class FfiConverterOptionalTypeOrdering : FfiConverterRustBuffer<Ordering?>
{
	public static FfiConverterOptionalTypeOrdering INSTANCE = new FfiConverterOptionalTypeOrdering();

	public override Ordering? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeOrdering.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Ordering? value)
	{
		if (!value.HasValue)
		{
			return 1;
		}
		return 1 + FfiConverterTypeOrdering.INSTANCE.AllocationSize(value.Value);
	}

	public override void Write(Ordering? value, BigEndianStream stream)
	{
		if (!value.HasValue)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeOrdering.INSTANCE.Write(value.Value, stream);
	}
}
