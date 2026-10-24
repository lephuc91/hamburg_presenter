using System;

namespace ProPresenter.DO.Actions;

public record Identification(Guid Id, string Name, Guid ParentId, string ParentName)
{
	public static Identification Empty()
	{
		return new Identification(Guid.Empty, string.Empty, Guid.Empty, string.Empty);
	}
}
