namespace Pro.Loro;

public record ContainerType
{
	public record Text : ContainerType;

	public record Map : ContainerType;

	public record List : ContainerType;

	public record MovableList : ContainerType;

	public record Tree : ContainerType;

	public record Counter : ContainerType;

	public record Unknown(byte kind) : ContainerType();
}
