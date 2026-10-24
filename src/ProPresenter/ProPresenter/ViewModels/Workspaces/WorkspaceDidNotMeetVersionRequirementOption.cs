using System;
using Pro.Localization;

namespace ProPresenter.ViewModels.Workspaces;

[Flags]
public enum WorkspaceDidNotMeetVersionRequirementOption
{
	[LocalizedString("APP_OUTDATED_UPDATE_button")]
	Update = 1,
	[LocalizedString("CLOUDWORKSPACE_CREATE_NEW_WORKSPACE_button")]
	CreateNew = 2,
	[LocalizedString("GLOBAL_CANCEL_BUTTON_title")]
	Cancel = 4,
	[LocalizedString("APP_OUTDATED_QUIT_button")]
	Quit = 8
}
