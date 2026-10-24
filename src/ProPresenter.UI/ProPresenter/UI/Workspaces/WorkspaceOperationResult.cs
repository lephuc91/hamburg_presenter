using System;
using Pro.Localization;

namespace ProPresenter.UI.Workspaces;

[Flags]
public enum WorkspaceOperationResult
{
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 1,
	[LocalizedString("LOCALWORKSPACE_NEW_WORKSPACE_DIALOG_CREATE_button")]
	Create = 2,
	[LocalizedString("LOCALWORKSPACE_WORKSPACE_DIALOG_DELETE_button")]
	Delete = 4,
	[LocalizedString("LOCALWORKSPACE_DIALOG_SAVE_button")]
	Save = 8,
	[LocalizedString("CLOUDWORKSPACE_DIALOG_REMOVE_CLOUD_WORKSPACE_button")]
	Remove = 0x10
}
