namespace Pro.Loro;

public record TreeParentId
{
	public record Node(TreeId id) : TreeParentId();

	public record Root : TreeParentId;

	public record Deleted : TreeParentId;

	public record Unexist : TreeParentId;
}
