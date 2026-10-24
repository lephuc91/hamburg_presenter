using Pro.Localization;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaCleanupPrompt : IMediaCleanupPrompt
{
	public MediaCleanupButtons? ConfirmDeletion()
	{
		string message = LocalizedStrings.Get("SETTINGS_MEDIA_CLEANUP_UNLINKED_MEDIA_WARNING_title") ?? "";
		return MessageDialogService.ShowDialog(string.Empty, message, MediaCleanupButtons.Cancel | MediaCleanupButtons.MoveToTrash | MediaCleanupButtons.MoveToFolder, MediaCleanupButtons.MoveToTrash);
	}

	public void ShowInformation()
	{
		MessageDialogService.ShowAlert(string.Empty, LocalizedStrings.Get("SETTINGS_MEDIA_CLEANUP_UNLINKED_MEDIA_NO_FILES_TO_DELETE_message"));
	}
}
