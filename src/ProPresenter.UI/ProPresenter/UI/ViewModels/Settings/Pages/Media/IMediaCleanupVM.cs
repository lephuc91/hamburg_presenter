using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Media;

public interface IMediaCleanupVM
{
	IAsyncRelayCommand CleanupCommand { get; }

	bool CleanupInProgress { get; set; }
}
