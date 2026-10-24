using System.IO.Abstractions;
using Pro.Common.FeatureFlag;
using Pro.Common.Strings;
using Pro.Localization.Services;
using Pro.UI.DialogService;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.ViewModels.Workspaces;

public class WorkspaceSwitchValidator : IWorkspaceSwitchValidator
{
	private readonly ICrdtProtoDirectoryFileScanner _crdtProtoDirectoryFileScanner;

	private readonly IMessageDialogService _messageDialogService;

	private readonly IAppUpdateService _appUpdateService;

	private readonly IFlagService _flagService;

	private readonly ILocalization _localization;

	private readonly ICommonPathsWrapper _commonPaths;

	private readonly IFileSystem _fileSystem;

	public WorkspaceSwitchValidator(ICrdtProtoDirectoryFileScanner crdtProtoDirectoryFileScanner, IMessageDialogService messageDialogService, IAppUpdateService appUpdateService, IFlagService flagService, ILocalization localization, ICommonPathsWrapper commonPaths, IFileSystem fileSystem)
	{
		_crdtProtoDirectoryFileScanner = crdtProtoDirectoryFileScanner;
		_messageDialogService = messageDialogService;
		_appUpdateService = appUpdateService;
		_flagService = flagService;
		_localization = localization;
		_commonPaths = commonPaths;
		_fileSystem = fileSystem;
	}

	public bool Validate(IWorkspace workspace, out IWorkspace resultWorkspace, bool isOnLaunch = false)
	{
		resultWorkspace = workspace;
		_crdtProtoDirectoryFileScanner.ValidateWorkspace(workspace);
		if (!_flagService.IsFlagEnabled(Flag.Cloud))
		{
			return true;
		}
		if (!ValidateVersion(workspace, out resultWorkspace, isOnLaunch))
		{
			return false;
		}
		return true;
	}

	public bool ValidateVersion(IWorkspace workspace, out IWorkspace resultWorkspace, bool isOnLaunch = false)
	{
		resultWorkspace = workspace;
		if (workspace.MinimumRequiredAppVersion == Workspace.FallbackDataModelVersion)
		{
			return true;
		}
		if (Workspace.CurrentDataModelVersion != workspace.MinimumRequiredAppVersion)
		{
			if (isOnLaunch)
			{
				return ShowAlertRequireNewVersionNoClose(workspace, out resultWorkspace);
			}
			return ShowAlertRequireNewVersion(workspace);
		}
		return true;
	}

	private bool ShowAlertRequireNewVersionNoClose(IWorkspace workspace, out IWorkspace resultWorkspace)
	{
		resultWorkspace = workspace;
		WorkspaceDidNotMeetVersionRequirementOption? workspaceDidNotMeetVersionRequirementOption = _messageDialogService.ShowDialogNoClose(_localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_title"), _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_info", new object[2]
		{
			workspace.Name,
			workspace.MinimumRequiredAppVersion.ToString()
		}), WorkspaceDidNotMeetVersionRequirementOption.Update | WorkspaceDidNotMeetVersionRequirementOption.CreateNew | WorkspaceDidNotMeetVersionRequirementOption.Quit, WorkspaceDidNotMeetVersionRequirementOption.Update);
		if (workspaceDidNotMeetVersionRequirementOption.HasValue)
		{
			if (workspaceDidNotMeetVersionRequirementOption == WorkspaceDidNotMeetVersionRequirementOption.Update)
			{
				UpdateToLatestVersion();
				return false;
			}
			if (workspaceDidNotMeetVersionRequirementOption == WorkspaceDidNotMeetVersionRequirementOption.CreateNew)
			{
				resultWorkspace = CreateWorkspace();
				return true;
			}
		}
		return false;
	}

	private bool ShowAlertRequireNewVersion(IWorkspace workspace)
	{
		string message = _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_info", new object[2]
		{
			workspace.Name,
			workspace.MinimumRequiredAppVersion.ToString()
		});
		if (workspace.WorkspaceType == WorkspaceType.Cloud)
		{
			message = _localization.Get("CLOUDWORKSPACE_EDITED_AND_REQUIRES_NEWER_PROPRESENTER_info", new object[2]
			{
				workspace.Name,
				workspace.MinimumRequiredAppVersion.ToString()
			});
		}
		WorkspaceDidNotMeetVersionRequirementOption? workspaceDidNotMeetVersionRequirementOption = _messageDialogService.ShowDialog(_localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_title"), message, WorkspaceDidNotMeetVersionRequirementOption.Update | WorkspaceDidNotMeetVersionRequirementOption.Cancel, WorkspaceDidNotMeetVersionRequirementOption.Update);
		if (workspaceDidNotMeetVersionRequirementOption.HasValue && workspaceDidNotMeetVersionRequirementOption == WorkspaceDidNotMeetVersionRequirementOption.Update)
		{
			UpdateToLatestVersion();
			return false;
		}
		return false;
	}

	private IWorkspace CreateWorkspace()
	{
		string text = _localization.Get("CLOUDWORKSPACE_DEFAULT_WORKSPACE_name").DuplicateName(_commonPaths.Workspaces, (IWorkspace w) => w.Name);
		string path = _fileSystem.Path.Combine(_commonPaths.DefaultLocalWorkspaces, text);
		_fileSystem.Directory.CreateDirectory(path);
		return _commonPaths.Workspaces.Add(text, path, WorkspaceType.Local, makeActive: true);
	}

	private void UpdateToLatestVersion()
	{
		if ((object)_appUpdateService.BuildAvailable != null)
		{
			_appUpdateService.InstallVersion(_appUpdateService.BuildAvailable);
		}
	}
}
