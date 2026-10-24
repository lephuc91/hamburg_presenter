using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Nullability;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Actions;

public class ActionDialogContext : IActionDialogContext
{
	public IActionRepository? ActionStore { get; }

	public List<IActionRepository>? OtherActionStores { get; }

	public IAction? Action { get; }

	public ActionDialogContext(IActionRepository? actionStore, IAction? action)
		: this(actionStore, action, null)
	{
	}

	public ActionDialogContext(IActionRepository? actionStore, IAction? action, IEnumerable<IActionRepository>? otherActionStores)
	{
		ActionStore = actionStore;
		if (otherActionStores != null)
		{
			OtherActionStores = otherActionStores.ToList();
			OtherActionStores.RemoveIf((object? x) => x == actionStore);
		}
		Action = action;
	}

	public void OnDone()
	{
		CopyActionToOtherSlides();
	}

	private void CopyActionToOtherSlides()
	{
		Action.ThrowWhenNull("Action");
		if (OtherActionStores == null)
		{
			return;
		}
		OtherActionStores.ForEach(delegate(IActionRepository r)
		{
			IAction action = r.Actions.LastOrDefault((IAction a) => a.ActionType == Action.ActionType);
			if (action != null && action != Action)
			{
				Action.CopyAction(action);
			}
		});
	}
}
