using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Events;

public record StageLayoutsUpdated(IEnumerable<(Guid ID, string Name)> Layouts) : IApplicationEvent
{
	public static void Publish(IEnumerable<(Guid ID, string Name)> layouts)
	{
		ApplicationEventPublisher.Publish(new StageLayoutsUpdated(layouts));
	}
}
