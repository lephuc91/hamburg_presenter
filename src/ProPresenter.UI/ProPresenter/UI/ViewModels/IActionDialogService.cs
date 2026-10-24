using System.Windows;

namespace ProPresenter.UI.ViewModels;

public interface IActionDialogService : ICommunicationActionDialogService, ILiveVideoDialogService
{
	void ShowEditActionDialog(ActionDialogParameter parameter);

	void UpdateDialogPlacementTarget(FrameworkElement placement);
}
