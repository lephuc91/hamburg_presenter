namespace Pro.Loro;

internal class FfiConverterTypeTreeDiff : FfiConverterRustBuffer<TreeDiff>
{
	public static FfiConverterTypeTreeDiff INSTANCE = new FfiConverterTypeTreeDiff();

	public override TreeDiff Read(BigEndianStream stream)
	{
		return new TreeDiff(FfiConverterSequenceTypeTreeDiffItem.INSTANCE.Read(stream));
	}

	public override int AllocationSize(TreeDiff value)
	{
		return FfiConverterSequenceTypeTreeDiffItem.INSTANCE.AllocationSize(value.diff);
	}

	public override void Write(TreeDiff value, BigEndianStream stream)
	{
		FfiConverterSequenceTypeTreeDiffItem.INSTANCE.Write(value.diff, stream);
	}
}
