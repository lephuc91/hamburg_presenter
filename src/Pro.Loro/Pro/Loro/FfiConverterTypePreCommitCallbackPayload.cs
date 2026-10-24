namespace Pro.Loro;

internal class FfiConverterTypePreCommitCallbackPayload : FfiConverterRustBuffer<PreCommitCallbackPayload>
{
	public static FfiConverterTypePreCommitCallbackPayload INSTANCE = new FfiConverterTypePreCommitCallbackPayload();

	public override PreCommitCallbackPayload Read(BigEndianStream stream)
	{
		return new PreCommitCallbackPayload(FfiConverterTypeChangeMeta.INSTANCE.Read(stream), FfiConverterString.INSTANCE.Read(stream), FfiConverterTypeChangeModifier.INSTANCE.Read(stream));
	}

	public override int AllocationSize(PreCommitCallbackPayload value)
	{
		return FfiConverterTypeChangeMeta.INSTANCE.AllocationSize(value.changeMeta) + FfiConverterString.INSTANCE.AllocationSize(value.origin) + FfiConverterTypeChangeModifier.INSTANCE.AllocationSize(value.modifier);
	}

	public override void Write(PreCommitCallbackPayload value, BigEndianStream stream)
	{
		FfiConverterTypeChangeMeta.INSTANCE.Write(value.changeMeta, stream);
		FfiConverterString.INSTANCE.Write(value.origin, stream);
		FfiConverterTypeChangeModifier.INSTANCE.Write(value.modifier, stream);
	}
}
