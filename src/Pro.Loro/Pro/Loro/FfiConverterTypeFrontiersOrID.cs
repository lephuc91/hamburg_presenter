namespace Pro.Loro;

internal class FfiConverterTypeFrontiersOrID : FfiConverterRustBuffer<FrontiersOrId>
{
	public static FfiConverterTypeFrontiersOrID INSTANCE = new FfiConverterTypeFrontiersOrID();

	public override FrontiersOrId Read(BigEndianStream stream)
	{
		return new FrontiersOrId(FfiConverterOptionalTypeFrontiers.INSTANCE.Read(stream), FfiConverterOptionalTypeID.INSTANCE.Read(stream));
	}

	public override int AllocationSize(FrontiersOrId value)
	{
		return FfiConverterOptionalTypeFrontiers.INSTANCE.AllocationSize(value.frontiers) + FfiConverterOptionalTypeID.INSTANCE.AllocationSize(value.id);
	}

	public override void Write(FrontiersOrId value, BigEndianStream stream)
	{
		FfiConverterOptionalTypeFrontiers.INSTANCE.Write(value.frontiers, stream);
		FfiConverterOptionalTypeID.INSTANCE.Write(value.id, stream);
	}
}
