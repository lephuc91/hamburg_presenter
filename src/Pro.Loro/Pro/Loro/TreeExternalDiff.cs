namespace Pro.Loro;

public record TreeExternalDiff
{
	public record Create(TreeParentId parent, uint index, string fractionalIndex) : TreeExternalDiff();

	public record Move(TreeParentId parent, uint index, string fractionalIndex, TreeParentId oldParent, uint oldIndex) : TreeExternalDiff();

	public record Delete(TreeParentId oldParent, uint oldIndex) : TreeExternalDiff();
}
