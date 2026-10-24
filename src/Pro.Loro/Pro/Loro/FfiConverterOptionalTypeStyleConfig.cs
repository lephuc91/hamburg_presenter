namespace Pro.Loro;

internal class FfiConverterOptionalTypeStyleConfig : FfiConverterRustBuffer<StyleConfig?>
{
	public static FfiConverterOptionalTypeStyleConfig INSTANCE = new FfiConverterOptionalTypeStyleConfig();

	public override StyleConfig? Read(BigEndianStream stream)
	{
		if (stream.ReadByte() == 0)
		{
			return null;
		}
		return FfiConverterTypeStyleConfig.INSTANCE.Read(stream);
	}

	public override int AllocationSize(StyleConfig? value)
	{
		if (value == null)
		{
			return 1;
		}
		return 1 + FfiConverterTypeStyleConfig.INSTANCE.AllocationSize(value);
	}

	public override void Write(StyleConfig? value, BigEndianStream stream)
	{
		if (value == null)
		{
			stream.WriteByte(0);
			return;
		}
		stream.WriteByte(1);
		FfiConverterTypeStyleConfig.INSTANCE.Write(value, stream);
	}
}
