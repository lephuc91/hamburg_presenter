using System;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.Settings.PageTemplates.General;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public interface IManageWorkspacesWindowProvider
{
	void ShowManageWorkspacesWindow(IWorkspacesVM workspacesVm);

	void ShowManageCloudWorkspacesWindow(IWorkspacesVM workspacesVm);

	bool ConfirmDeletion(string workspaceName, bool isCloud = false);

	bool ShowNameWorkspaceDialog(string title, IWorkspace workspace, out bool isCloudWorkspace);

	bool ShowImportWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null);

	bool ShowDuplicateWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null);

	bool ShowRenameWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null);

	void ShowWorkspaceErrorDialog(string message, string submessage);

	void ShowWorkspaceAlreadyExistsMessage();

	IDisposable ShowProgressSpinner(string message);

	DuplicateWorkspaceProgressWindow? ShowDuplicationProgressWindow(IWorkspaceItemVM workspace, out IProgress<double> progress);
}
