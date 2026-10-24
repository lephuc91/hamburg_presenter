namespace ProPresenter.ViewModels.Settings.Pages.Media;

public interface IMediaCleanupPrompt
{
	MediaCleanupButtons? ConfirmDeletion();

	void ShowInformation();
}
