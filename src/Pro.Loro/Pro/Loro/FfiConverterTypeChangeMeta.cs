namespace Pro.Loro;

internal class FfiConverterTypeChangeMeta : FfiConverterRustBuffer<ChangeMeta>
{
	public static FfiConverterTypeChangeMeta INSTANCE = new FfiConverterTypeChangeMeta();

	public override ChangeMeta Read(BigEndianStream stream)
	{
		return new ChangeMeta(FfiConverterUInt32.INSTANCE.Read(stream), FfiConverterTypeID.INSTANCE.Read(stream), FfiConverterInt64.INSTANCE.Read(stream), FfiConverterOptionalString.INSTANCE.Read(stream), FfiConverterTypeFrontiers.INSTANCE.Read(stream), FfiConverterUInt32.INSTANCE.Read(stream));
	}

	public override int AllocationSize(ChangeMeta value)
	{
		return FfiConverterUInt32.INSTANCE.AllocationSize(value.lamport) + FfiConverterTypeID.INSTANCE.AllocationSize(value.id) + FfiConverterInt64.INSTANCE.AllocationSize(value.timestamp) + FfiConverterOptionalString.INSTANCE.AllocationSize(value.message) + FfiConverterTypeFrontiers.INSTANCE.AllocationSize(value.deps) + FfiConverterUInt32.INSTANCE.AllocationSize(value.len);
	}

	public override void Write(ChangeMeta value, BigEndianStream stream)
	{
		FfiConverterUInt32.INSTANCE.Write(value.lamport, stream);
		FfiConverterTypeID.INSTANCE.Write(value.id, stream);
		FfiConverterInt64.INSTANCE.Write(value.timestamp, stream);
		FfiConverterOptionalString.INSTANCE.Write(value.message, stream);
		FfiConverterTypeFrontiers.INSTANCE.Write(value.deps, stream);
		FfiConverterUInt32.INSTANCE.Write(value.len, stream);
	}
}
