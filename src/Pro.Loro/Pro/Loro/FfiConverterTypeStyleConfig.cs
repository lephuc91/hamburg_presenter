namespace Pro.Loro;

internal class FfiConverterTypeStyleConfig : FfiConverterRustBuffer<StyleConfig>
{
	public static FfiConverterTypeStyleConfig INSTANCE = new FfiConverterTypeStyleConfig();

	public override StyleConfig Read(BigEndianStream stream)
	{
		return new StyleConfig(FfiConverterTypeExpandType.INSTANCE.Read(stream));
	}

	public override int AllocationSize(StyleConfig value)
	{
		return FfiConverterTypeExpandType.INSTANCE.AllocationSize(value.expand);
	}

	public override void Write(StyleConfig value, BigEndianStream stream)
	{
		FfiConverterTypeExpandType.INSTANCE.Write(value.expand, stream);
	}
}
