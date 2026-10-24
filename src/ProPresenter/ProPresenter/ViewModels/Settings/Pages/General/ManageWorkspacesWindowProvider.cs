using System;
using System.IO;
using System.Reactive.Disposables;
using System.Windows;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using ProPresenter.DO;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.CloudWorkspaces;
using ProPresenter.UI.Registration.PopUpAlerts;
using ProPresenter.UI.Settings.PageTemplates.General;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.UI.Workspaces;

namespace ProPresenter.ViewModels.Settings.Pages.General;

public class ManageWorkspacesWindowProvider : IManageWorkspacesWindowProvider
{
	private const long MAX_WORKSPACE_NAME_CHARACTERS = 255L;

	private readonly ILocalization _localization;

	private readonly IFileService _fileService;

	private readonly IUiDispatcher _dispatcher;

	public ManageWorkspacesWindowProvider(ILocalization localization, IFileService fileService, IUiDispatcher dispatcher)
	{
		_localization = localization;
		_fileService = fileService;
		_dispatcher = dispatcher;
	}

	public void ShowManageWorkspacesWindow(IWorkspacesVM workspaceVm)
	{
		ManageWorkspacesWindow manageWorkspacesWindow = new ManageWorkspacesWindow();
		manageWorkspacesWindow.DataContext = workspaceVm;
		manageWorkspacesWindow.ShowDialog();
	}

	public void ShowManageCloudWorkspacesWindow(IWorkspacesVM workspaceVm)
	{
		ManageCloudWorkspacesWindow manageCloudWorkspacesWindow = new ManageCloudWorkspacesWindow();
		manageCloudWorkspacesWindow.DataContext = workspaceVm;
		manageCloudWorkspacesWindow.ShowDialog();
	}

	public bool ConfirmDeletion(string workspaceName, bool isCloud = false)
	{
		MessageContent messageContent;
		if (isCloud)
		{
			messageContent = new MessageContent();
			messageContent.Heading = _localization.Get("CLOUDWORKSPACE_WORKSPACE_DIALOG_DELETE_description", new object[1] { workspaceName });
			messageContent.Message = _localization.Get("CLOUDWORKSPACE_DIALOG_REMOVE_WORKSPACE_subtext");
			MessageContent content = messageContent;
			return MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)content, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Remove, WorkspaceOperationResult.Remove) == WorkspaceOperationResult.Remove;
		}
		messageContent = new MessageContent();
		messageContent.Heading = _localization.Get("LOCALWORKSPACE_WORKSPACE_DIALOG_DELETE_description", new object[1] { workspaceName });
		messageContent.Message = _localization.Get("LOCALWORKSPACE_WORKSPACE_DIALOG_DELETE_subtext");
		MessageContent content2 = messageContent;
		return MessageDialogService.ShowDialog(string.Empty, (DependencyObject)(object)content2, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Delete, WorkspaceOperationResult.Delete) == WorkspaceOperationResult.Delete;
	}

	public bool ShowImportWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null)
	{
		GenericTextBoxDialog genericTextBoxDialog = new GenericTextBoxDialog
		{
			ItemName = (defaultName ?? string.Empty)
		};
		string path = workspace.Path;
		while (true)
		{
			if (MessageDialogService.ShowDialog(title, (DependencyObject)(object)genericTextBoxDialog, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Create, WorkspaceOperationResult.Create) == WorkspaceOperationResult.Cancel)
			{
				return false;
			}
			string text = genericTextBoxDialog.ItemName?.TrimEnd(' ', '.') ?? string.Empty;
			if (string.Compare(text, defaultName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return true;
			}
			if (!IsWorkspaceNameBlank(text) && !IsWorkspaceNameTooLong(text) && !DoesWorkspaceNameExist(IsInvalid, text))
			{
				workspace.Name = text;
				string text2 = text.SanitizeFilename();
				string directoryName = Path.GetDirectoryName(path);
				if (string.IsNullOrEmpty(directoryName))
				{
					break;
				}
				if (!DoesFolderNameAlreadyExist(text2, directoryName))
				{
					workspace.Name = text;
					workspace.Path = Path.Combine(directoryName, text2);
					return true;
				}
			}
		}
		return false;
	}

	public bool ShowDuplicateWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null)
	{
		GenericTextBoxDialog genericTextBoxDialog = new GenericTextBoxDialog
		{
			ItemName = (defaultName ?? string.Empty)
		};
		string path = workspace.Path;
		string text2;
		string text3;
		while (true)
		{
			if (MessageDialogService.ShowDialog(title, (DependencyObject)(object)genericTextBoxDialog, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Save, WorkspaceOperationResult.Save) == WorkspaceOperationResult.Cancel)
			{
				return false;
			}
			string text = genericTextBoxDialog.ItemName?.TrimEnd(' ', '.') ?? string.Empty;
			if (!IsWorkspaceNameBlank(text) && !IsWorkspaceNameTooLong(text) && !DoesWorkspaceNameExist(IsInvalid, text))
			{
				workspace.Name = text;
				text2 = text.SanitizeFilename();
				text3 = path;
				if (!DoesFolderNameAlreadyExist(text2, text3))
				{
					break;
				}
			}
		}
		workspace.Path = Path.Combine(text3, text2);
		return true;
	}

	public bool ShowRenameWorkspaceDialog(string title, IWorkspace workspace, Func<string, bool>? IsInvalid = null, string? defaultName = null)
	{
		GenericTextBoxDialog genericTextBoxDialog = new GenericTextBoxDialog
		{
			ItemName = (defaultName ?? string.Empty)
		};
		string text;
		do
		{
			if (MessageDialogService.ShowDialog(title, (DependencyObject)(object)genericTextBoxDialog, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Save, WorkspaceOperationResult.Save) == WorkspaceOperationResult.Cancel)
			{
				return false;
			}
			text = genericTextBoxDialog.ItemName?.TrimEnd(' ', '.') ?? string.Empty;
			if (string.Compare(text, defaultName, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return false;
			}
		}
		while (IsWorkspaceNameBlank(text) || IsWorkspaceNameTooLong(text) || DoesWorkspaceNameExist(IsInvalid, text));
		workspace.Name = text;
		return true;
	}

	public void ShowWorkspaceErrorDialog(string message, string submessage)
	{
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = message,
			Message = submessage
		}, new ButtonDescriptor[1]
		{
			new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"), IsDefault: true)
		}, null, null, canClose: true);
	}

	public bool ShowNameWorkspaceDialog(string title, IWorkspace workspace, out bool isCloudWorkspace)
	{
		AddWorkspaceDialog addWorkspaceDialog = new AddWorkspaceDialog
		{
			WorkspaceName = string.Empty
		};
		isCloudWorkspace = false;
		string text;
		string text2;
		string path;
		while (true)
		{
			WorkspaceOperationResult? workspaceOperationResult = MessageDialogService.ShowDialog(title, (DependencyObject)(object)addWorkspaceDialog, WorkspaceOperationResult.Cancel | WorkspaceOperationResult.Create, WorkspaceOperationResult.Create);
			text = addWorkspaceDialog.WorkspaceName?.TrimEnd(' ', '.') ?? string.Empty;
			if (!workspaceOperationResult.HasValue || workspaceOperationResult.Value == WorkspaceOperationResult.Cancel)
			{
				return false;
			}
			if (!IsWorkspaceNameBlank(text) && !IsWorkspaceNameTooLong(text))
			{
				text2 = text.SanitizeFilename();
				path = workspace.Path;
				if (!DoesFolderNameAlreadyExist(text2, path))
				{
					break;
				}
			}
		}
		workspace.Name = text;
		workspace.Path = Path.Combine(path, text2);
		isCloudWorkspace = addWorkspaceDialog.IsCloudWorkspace;
		return true;
	}

	public void ShowWorkspaceAlreadyExistsMessage()
	{
		MessageDialogService.ShowDialog(null, _localization.Get("LOCALWORKSPACE_IMPORT_LEGACY_FOLDER_WORKSPACE_ALREADY_EXISTS_message"), DefaultButtons.OK, DefaultButtons.OK);
	}

	public DuplicateWorkspaceProgressWindow? ShowDuplicationProgressWindow(IWorkspaceItemVM workspace, out IProgress<double> progress)
	{
		long totalBytes = _fileService.GetTotalSize(workspace.Path);
		DuplicateWorkspaceProgressWindow progressWindow = new DuplicateWorkspaceProgressWindow
		{
			DuplicationTitle = _localization.Get("LOCALWORKSPACE_DIALOG_DUPLICATING_label") + " \"" + workspace.Name + "\"",
			Status = "",
			WindowStartupLocation = WindowStartupLocation.CenterOwner,
			Topmost = true
		};
		progress = new Progress<double>(delegate(double value)
		{
			progressWindow.Progress = value / (double)totalBytes;
			progressWindow.Status = "Copying " + formatSize(value) + " of " + formatSize(totalBytes);
		});
		progressWindow.Show();
		return progressWindow;
		static string formatSize(double bytes)
		{
			if (bytes >= 1073741824.0)
			{
				return $"{bytes / 1073741824.0:0.##} GB";
			}
			if (bytes >= 1048576.0)
			{
				return $"{bytes / 1048576.0:0.##} MB";
			}
			if (bytes >= 1024.0)
			{
				return $"{bytes / 1024.0:0.##} KB";
			}
			return $"{bytes:N0} bytes";
		}
	}

	private bool IsWorkspaceNameBlank(string workspaceName)
	{
		if (!string.IsNullOrEmpty(workspaceName))
		{
			return false;
		}
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = _localization.Get("LOCALWORKSPACE_WORKSPACE_DIALOG_BLANK_NAME_title"),
			Message = _localization.Get("LOCALWORKSPACE_WORKSPACE_DIALOG_BLANK_NAME_message")
		}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(_localization.Get("GLOBAL_OK_BUTTON_title"))), null, 600.0);
		return true;
	}

	private bool IsWorkspaceNameTooLong(string workspaceName)
	{
		if ((long)workspaceName.Length > 255L)
		{
			MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
			{
				Heading = _localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_TOO_LONG_title"),
				Message = _localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_TOO_LONG_message")
			}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(_localization.Get("GLOBAL_OK_BUTTON_title"))), null, 600.0);
			return true;
		}
		return false;
	}

	private bool DoesWorkspaceNameExist(Func<string, bool>? isInvalid, string workspaceName)
	{
		if (isInvalid == null)
		{
			return false;
		}
		if (!isInvalid(workspaceName))
		{
			return false;
		}
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = _localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_ALREADY_EXISTS_title"),
			Message = _localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_ALREADY_EXISTS_description")
		}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(_localization.Get("GLOBAL_OK_BUTTON_title"))), null, 600.0);
		return true;
	}

	private bool DoesFolderNameAlreadyExist(string sanitizedName, string? parentFolder)
	{
		if (!_fileService.FolderExists(parentFolder))
		{
			return false;
		}
		if (_fileService.IsFolderNameUnique(sanitizedName, parentFolder))
		{
			return false;
		}
		MessageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = _localization.Get("LOCALWORKSPACE_FOLDER_NAME_ALREADY_EXISTS_title"),
			Message = _localization.Get("LOCALWORKSPACE_FOLDER_NAME_ALREADY_EXISTS_message")
		}, new global::_003C_003Ez__ReadOnlySingleElementList<ButtonDescriptor>(new ButtonDescriptor(_localization.Get("GLOBAL_OK_BUTTON_title"))), null, 600.0);
		return true;
	}

	public IDisposable ShowProgressSpinner(string message)
	{
		ProgressSpinner spinner = null;
		_dispatcher.Invoke(delegate
		{
			spinner = new ProgressSpinner
			{
				Message = message
			};
			spinner.Show();
		});
		return Disposable.Create(delegate
		{
			_dispatcher.Invoke(delegate
			{
				try
				{
					spinner?.Close();
				}
				catch
				{
				}
			});
		});
	}
}
