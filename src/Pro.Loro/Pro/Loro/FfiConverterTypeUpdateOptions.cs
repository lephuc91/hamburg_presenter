namespace Pro.Loro;

internal class FfiConverterTypeUpdateOptions : FfiConverterRustBuffer<UpdateOptions>
{
	public static FfiConverterTypeUpdateOptions INSTANCE = new FfiConverterTypeUpdateOptions();

	public override UpdateOptions Read(BigEndianStream stream)
	{
		return new UpdateOptions(FfiConverterOptionalDouble.INSTANCE.Read(stream), FfiConverterBoolean.INSTANCE.Read(stream));
	}

	public override int AllocationSize(UpdateOptions value)
	{
		return FfiConverterOptionalDouble.INSTANCE.AllocationSize(value.timeoutMs) + FfiConverterBoolean.INSTANCE.AllocationSize(value.useRefinedDiff);
	}

	public override void Write(UpdateOptions value, BigEndianStream stream)
	{
		FfiConverterOptionalDouble.INSTANCE.Write(value.timeoutMs, stream);
		FfiConverterBoolean.INSTANCE.Write(value.useRefinedDiff, stream);
	}
}
