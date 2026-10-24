namespace Pro.Loro;

internal class FfiConverterOptionalTypeFrontiers : FfiConverterRustBuffer<Frontiers?>
{
	public static FfiConverterOptionalTypeFrontiers INSTANCE = new FfiConverterOptionalTypeFrontiers();

	public override Frontiers? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeFrontiers.INSTANCE.Read(stream);
	}

	public override int AllocationSize(Frontiers? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeFrontiers.INSTANCE.AllocationSize(value);
	}

	public override void Write(Frontiers? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeFrontiers.INSTANCE.Write(value, stream);
	}
}
