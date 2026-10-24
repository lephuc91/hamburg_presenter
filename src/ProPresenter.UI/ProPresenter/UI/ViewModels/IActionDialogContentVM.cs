using Pro.DO.Triggering;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ViewModels;

public interface IActionDialogContentVM
{
	IAction? Action { get; }

	IActionRepository? ActionStore { get; }

	void OnDone();

	void SetContext(IActionDialogContext context);
}
