using System.Collections.Generic;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Events;

public record MacrosUpdated(IEnumerable<Macro> Macros) : IApplicationEvent
{
	public static void Publish(IEnumerable<Macro> macros)
	{
		ApplicationEventPublisher.Publish(new MacrosUpdated(macros));
	}
}
