using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI.ViewModels;

public interface IOutputVM : INotifyPropertyChanged
{
	ICommand ToggleAudienceScreensCommand { get; }

	ICommand ToggleStageScreensCommand { get; }

	ICommand ToggleSlideOnStageDisplayOnlyCommand { get; }

	ICommand<ClearGroup?> TriggerClearGroupCommand { get; }

	ICommand TriggerFirstClearGroupCommand { get; }

	ICommand ClearAllCommand { get; }

	ICommand ClearAudioCommand { get; }

	ICommand ClearMessagesCommand { get; }

	ICommand ClearPropsCommand { get; }

	ICommand ClearAnnouncementCommand { get; }

	ICommand ClearSlideCommand { get; }

	ICommand ClearBackgroundCommand { get; }

	ICommand ClearVideoInputCommand { get; }

	ICommand ClearTelestratorCommand { get; }

	ICommand DisplayLogoCommand { get; }

	void ShowScreensOnStartup();
}
