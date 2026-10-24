using System.Collections.Generic;
using Pro.DO.Triggering;

namespace ProPresenter.DO.Actions;

public interface IActionRepository
{
	IEnumerable<IAction> Actions { get; }

	bool CanAddAction(object data);

	bool CanAssign(object data, IAction? action);

	bool CanReplace(object data);

	void AddAction(IAction action, bool addMediaReferences = false);

	void RemoveAction(IAction action);

	void RemoveActions(IEnumerable<IAction> actions);

	void InsertActions(IEnumerable<IAction> actions, int index, bool addMediaReferences = false);
}
