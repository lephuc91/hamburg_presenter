using System;

namespace ProPresenter.DO.Resi;

public class DestinationGroup : IDestinationGroup
{
	public Guid ID { get; }

	public string Name { get; }

	public DestinationGroup(Guid id, string name)
	{
		ID = id;
		Name = name;
	}
}
