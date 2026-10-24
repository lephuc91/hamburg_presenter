namespace Pro.Loro;

internal class FfiConverterTypeCommitOptions : FfiConverterRustBuffer<CommitOptions>
{
	public static FfiConverterTypeCommitOptions INSTANCE = new FfiConverterTypeCommitOptions();

	public override CommitOptions Read(BigEndianStream stream)
	{
		return new CommitOptions(FfiConverterOptionalString.INSTANCE.Read(stream), FfiConverterBoolean.INSTANCE.Read(stream), FfiConverterOptionalInt64.INSTANCE.Read(stream), FfiConverterOptionalString.INSTANCE.Read(stream));
	}

	public override int AllocationSize(CommitOptions value)
	{
		return FfiConverterOptionalString.INSTANCE.AllocationSize(value.origin) + FfiConverterBoolean.INSTANCE.AllocationSize(value.immediateRenew) + FfiConverterOptionalInt64.INSTANCE.AllocationSize(value.timestamp) + FfiConverterOptionalString.INSTANCE.AllocationSize(value.commitMsg);
	}

	public override void Write(CommitOptions value, BigEndianStream stream)
	{
		FfiConverterOptionalString.INSTANCE.Write(value.origin, stream);
		FfiConverterBoolean.INSTANCE.Write(value.immediateRenew, stream);
		FfiConverterOptionalInt64.INSTANCE.Write(value.timestamp, stream);
		FfiConverterOptionalString.INSTANCE.Write(value.commitMsg, stream);
	}
}
