namespace Pro.Loro;

public record Index
{
	public record Key(string key) : Index();

	public record Seq(uint index) : Index();

	public record Node(TreeId target) : Index();
}
