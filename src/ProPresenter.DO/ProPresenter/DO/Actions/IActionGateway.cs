using System.Collections.Generic;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Actions;

public interface IActionGateway
{
	bool CanAddAction(object data);

	void HandleIncoming(IAction action, out IEnumerable<IAction> replacements);

	void HandleOutgoing(IAction action);
}
