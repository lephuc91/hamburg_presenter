namespace Pro.Loro;

internal class FfiConverterOptionalTypeLoroUnknown : FfiConverterRustBuffer<LoroUnknown?>
{
	public static FfiConverterOptionalTypeLoroUnknown INSTANCE = new FfiConverterOptionalTypeLoroUnknown();

	public override LoroUnknown? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeLoroUnknown.INSTANCE.Read(stream);
	}

	public override int AllocationSize(LoroUnknown? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeLoroUnknown.INSTANCE.AllocationSize(value);
	}

	public override void Write(LoroUnknown? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeLoroUnknown.INSTANCE.Write(value, stream);
	}
}
