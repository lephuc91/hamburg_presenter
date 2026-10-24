namespace Pro.Loro;

public record ContainerId
{
	public record Root(string name, ContainerType containerType) : ContainerId();

	public record Normal(ulong peer, int counter, ContainerType containerType) : ContainerId();
}
