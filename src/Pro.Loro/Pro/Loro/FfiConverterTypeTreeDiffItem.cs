namespace Pro.Loro;

internal class FfiConverterTypeTreeDiffItem : FfiConverterRustBuffer<TreeDiffItem>
{
	public static FfiConverterTypeTreeDiffItem INSTANCE = new FfiConverterTypeTreeDiffItem();

	public override TreeDiffItem Read(BigEndianStream stream)
	{
		return new TreeDiffItem(FfiConverterTypeTreeID.INSTANCE.Read(stream), FfiConverterTypeTreeExternalDiff.INSTANCE.Read(stream));
	}

	public override int AllocationSize(TreeDiffItem value)
	{
		return FfiConverterTypeTreeID.INSTANCE.AllocationSize(value.target) + FfiConverterTypeTreeExternalDiff.INSTANCE.AllocationSize(value.action);
	}

	public override void Write(TreeDiffItem value, BigEndianStream stream)
	{
		FfiConverterTypeTreeID.INSTANCE.Write(value.target, stream);
		FfiConverterTypeTreeExternalDiff.INSTANCE.Write(value.action, stream);
	}
}
