using System.Collections.Generic;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ViewModels;

public interface IActionDialogContext
{
	IAction? Action { get; }

	IActionRepository? ActionStore { get; }

	List<IActionRepository>? OtherActionStores { get; }

	void OnDone();
}
