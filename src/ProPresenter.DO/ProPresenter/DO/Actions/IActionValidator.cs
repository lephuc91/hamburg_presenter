using System.Collections.Generic;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Actions;

public interface IActionValidator
{
	bool Validate(IEnumerable<IAction> actions, out string warningMessage);
}
