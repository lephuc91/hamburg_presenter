namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public interface IAirCastPrompt
{
	bool ShowConfirmDownload();

	bool ShowDownloadFailed();

	void ShowPasswordRequired();
}
