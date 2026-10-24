using System.Windows.Input;
using ProPresenter.UI.ViewModels;
using ProPresenter.ViewModels.ActionsMenu;

namespace ProPresenter.ViewModels;

public interface IActionsMenuVMFactory
{
	IActionsMenuVM Create(IAddActionInteractor? addActionInteractor, IMediaStrategy? addMediaStategy = null, ICommand? openLiveVideoSetupCommand = null);
}
