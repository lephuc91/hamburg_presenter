using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Updates;

public interface IUpdatesViewerVM
{
	string ReleaseNotes { get; }

	string NewVersion { get; }

	string InstalledVersion { get; }

	IRelayCommand SkipThisVersionCommand { get; }

	IRelayCommand DownloadUpdateCommand { get; }
}
