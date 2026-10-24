using System;
using System.Collections.Generic;

namespace ProPresenter.DO.Events;

public record StageScreensUpdated(IEnumerable<(Guid ID, string Name)> Screens) : IApplicationEvent
{
	public static void Publish(IEnumerable<(Guid ID, string Name)> screens)
	{
		ApplicationEventPublisher.Publish(new StageScreensUpdated(screens));
	}
}
