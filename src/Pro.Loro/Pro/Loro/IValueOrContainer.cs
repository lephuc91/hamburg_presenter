namespace Pro.Loro;

public interface IValueOrContainer
{
	ContainerId? AsContainer();

	LoroCounter? AsLoroCounter();

	LoroList? AsLoroList();

	LoroMap? AsLoroMap();

	LoroMovableList? AsLoroMovableList();

	LoroText? AsLoroText();

	LoroTree? AsLoroTree();

	LoroUnknown? AsLoroUnknown();

	LoroValue? AsValue();

	ContainerType? ContainerType();

	bool IsContainer();

	bool IsValue();
}
