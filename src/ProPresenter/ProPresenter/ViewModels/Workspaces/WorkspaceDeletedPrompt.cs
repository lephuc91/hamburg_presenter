using Pro.Localization.Services;
using Pro.UI.DialogService;

namespace ProPresenter.ViewModels.Workspaces;

public class WorkspaceDeletedPrompt : IWorkspaceDeletedPrompt
{
	private readonly IMessageDialogService _messageDialogService;

	private readonly ILocalization _localization;

	public WorkspaceDeletedPrompt(IMessageDialogService messageDialogService, ILocalization localization)
	{
		_messageDialogService = messageDialogService;
		_localization = localization;
	}

	public void Show()
	{
		_messageDialogService.ShowAlert(_localization.Get("CLOUDWORKSPACE_DELETED_ALERT_title"), _localization.Get("CLOUDWORKSPACE_DELETED_ALERT_info"));
	}
}
