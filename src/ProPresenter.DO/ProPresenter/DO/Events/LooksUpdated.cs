using System.Collections.Generic;
using ProPresenter.DO.Looks;

namespace ProPresenter.DO.Events;

public record LooksUpdated(IEnumerable<AudienceLook> Looks) : IApplicationEvent
{
	public static void Publish(IEnumerable<AudienceLook> looks)
	{
		ApplicationEventPublisher.Publish(new LooksUpdated(looks));
	}
}
