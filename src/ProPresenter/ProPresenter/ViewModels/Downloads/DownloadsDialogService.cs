using ProPresenter.UI.Downloads;

namespace ProPresenter.ViewModels.Downloads;

public class DownloadsDialogService : IDownloadsDialogService
{
	public bool ShowCleanupPlaceholderActions()
	{
		return new CleanupPlaceholderActionsDialog().ShowDialog() == true;
	}
}
