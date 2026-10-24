namespace ProPresenter.UI.ViewModels;

public interface IMediaImportDownloadDialogService
{
	IMediaImportDownloadDialogResult? Show(bool isDownload = false);
}
