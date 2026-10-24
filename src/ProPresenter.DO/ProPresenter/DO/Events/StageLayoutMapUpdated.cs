using System.Collections.Generic;
using Pro.Common.Components;

namespace ProPresenter.DO.Events;

public record StageLayoutMapUpdated(IReadOnlyList<(IIdentifiable key, IIdentifiable value)> Entries) : IApplicationEvent
{
	public static void Publish(IReadOnlyList<(IIdentifiable key, IIdentifiable value)> entries)
	{
		ApplicationEventPublisher.Publish(new StageLayoutMapUpdated(entries));
	}
}
