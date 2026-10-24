using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.HTTP.Results;
using Pro.Common.Logging;
using Pro.Common.Utility;
using Pro.Reporting;
using Pro.Reporting.UserFeedback;
using Pro.Reporting.UserFeedback.AttachmentUpload.Model;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.UserAttachments;

namespace ProPresenter.ViewModels.UserAttachments;

public class UserAttachmentsVM : ObservableObject, IUserAttachmentsVM, INotifyPropertyChanged, IDisposable
{
	private const string APPMETADATA_JSON = "AppMetadata.json";

	private readonly IUserFeedbackConsumer _apiConsumer;

	private readonly ILogger _logger;

	private readonly IFileSystem _fileSystem;

	private readonly IProcessHelper _processHelper;

	private readonly IBuildAppMetaDataFile _buildAppMetaData;

	private readonly ISystemInfoProvider _systemInfoProvider;

	private readonly IWorkspaceService _workspaceService;

	private string _zippedWorkspaceLocation;

	private string _zippedCloudDocumentsLocation;

	[ObservableProperty]
	private IUserAttachmentCollectionVM _attachments;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("RemoveAttachmentCommand")]
	private IUserAttachment? _selectedAttachment;

	[ObservableProperty]
	private bool _attachmentInProgress;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachSystemDiagnosticsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachSystemInformationCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachCrashReportCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachProgramFileLogCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachChooseFileCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? attachCloudDocumentsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IUserAttachment>? removeAttachmentCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? showInFolderCommand;

	public bool IsValid => Attachments.All((IUserAttachment a) => a.IsValid);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IUserAttachmentCollectionVM Attachments
	{
		get
		{
			return _attachments;
		}
		[MemberNotNull("_attachments")]
		set
		{
			if (!EqualityComparer<IUserAttachmentCollectionVM>.Default.Equals(_attachments, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Attachments);
				_attachments = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Attachments);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IUserAttachment? SelectedAttachment
	{
		get
		{
			return _selectedAttachment;
		}
		set
		{
			if (!EqualityComparer<IUserAttachment>.Default.Equals(_selectedAttachment, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedAttachment);
				_selectedAttachment = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedAttachment);
				RemoveAttachmentCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool AttachmentInProgress
	{
		get
		{
			return _attachmentInProgress;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_attachmentInProgress, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AttachmentInProgress);
				_attachmentInProgress = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AttachmentInProgress);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachSystemDiagnosticsCommand => attachSystemDiagnosticsCommand ?? (attachSystemDiagnosticsCommand = new AsyncRelayCommand(AttachSystemDiagnostics, AttachSystemDiagnostics_CanExecute, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachSystemInformationCommand => attachSystemInformationCommand ?? (attachSystemInformationCommand = new AsyncRelayCommand(AttachSystemInformation, AttachSystemInformation_CanExecute, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachCrashReportCommand => attachCrashReportCommand ?? (attachCrashReportCommand = new AsyncRelayCommand(AttachCrashReport, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachProgramFileLogCommand => attachProgramFileLogCommand ?? (attachProgramFileLogCommand = new AsyncRelayCommand(AttachProgramFileLog, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachChooseFileCommand => attachChooseFileCommand ?? (attachChooseFileCommand = new AsyncRelayCommand(AttachChooseFile, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachWorkspaceCommand => attachWorkspaceCommand ?? (attachWorkspaceCommand = new AsyncRelayCommand(AttachWorkspace, AttachWorkspace_CanExecute, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AttachCloudDocumentsCommand => attachCloudDocumentsCommand ?? (attachCloudDocumentsCommand = new AsyncRelayCommand(AttachCloudDocuments, AttachCloudDocuments_CanExecute, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IUserAttachment> RemoveAttachmentCommand => removeAttachmentCommand ?? (removeAttachmentCommand = new RelayCommand<IUserAttachment>(RemoveAttachment, RemoveAttachmentCommand_CanExecute));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ShowInFolderCommand => showInFolderCommand ?? (showInFolderCommand = new RelayCommand(ShowInFolder));

	public UserAttachmentsVM(IUserAttachmentCollectionVM attachments, IUserFeedbackConsumer apiConsumer, ILogger logger, IFileSystem fileSystem, IProcessHelper processHelper, IBuildAppMetaDataFile buildAppMetaDataFile, ISystemInfoProvider systemInfoProvider, IWorkspaceService workspaceService)
	{
		_attachments = attachments;
		_apiConsumer = apiConsumer;
		_logger = logger;
		_fileSystem = fileSystem;
		_processHelper = processHelper;
		_buildAppMetaData = buildAppMetaDataFile;
		_systemInfoProvider = systemInfoProvider;
		_workspaceService = workspaceService;
		_zippedWorkspaceLocation = string.Empty;
		_zippedCloudDocumentsLocation = string.Empty;
		if (_attachments is ObservableCollection<IUserAttachment> observableCollection)
		{
			observableCollection.CollectionChanged += OnCollectionChanged;
		}
	}

	[RelayCommand(CanExecute = "AttachSystemDiagnostics_CanExecute", FlowExceptionsToTaskScheduler = true)]
	private async Task AttachSystemDiagnostics(CancellationToken token)
	{
		string fileName = await _systemInfoProvider.CreateSystemInfoFileAsync(token);
		await Attachments.AddAsync(fileName);
	}

	private IEnumerable<string> GetFiles(string filenameQuery)
	{
		string path = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RenewedVision", "ProPresenter");
		return _fileSystem.Directory.GetFiles(path, filenameQuery) ?? Array.Empty<string>();
	}

	private bool AttachSystemDiagnostics_CanExecute()
	{
		return Attachments.None((IUserAttachment a) => a.FileName.EndsWith(".systeminfo"));
	}

	[RelayCommand(CanExecute = "AttachSystemInformation_CanExecute", FlowExceptionsToTaskScheduler = true)]
	private async Task AttachSystemInformation()
	{
		await _buildAppMetaData.BuildAppMetaDataFile();
		IEnumerable<string> files = GetFiles("AppMetadata.json");
		if (files.Any())
		{
			await Attachments.AddAsync(files.ToArray());
		}
	}

	private bool AttachSystemInformation_CanExecute()
	{
		return Attachments.None((IUserAttachment a) => a.FileNameShort.Equals("AppMetadata.json"));
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task AttachCrashReport()
	{
		string initialDirectory = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RenewedVision", "ProPresenter", "Crash Reports");
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			InitialDirectory = initialDirectory,
			Filter = "Crash Files (*.crash)|*.crash|Memory Dump Files (*.mdmp)|*.mdmp|All Files (*.*)|*.*",
			Multiselect = true
		};
		if (openFileDialog.ShowDialog() != true)
		{
			return;
		}
		List<string> list = new List<string>(openFileDialog.FileNames);
		foreach (List<string> item in from f in (from f in list
				group f by _fileSystem.Path.GetFileNameWithoutExtension(f) into g
				select new
				{
					Key = g.Key,
					CountOf = g.Count(),
					Files = g.ToList()
				} into a
				where a.CountOf == 1
				select a).ToList()
			select f.Files)
		{
			string extension = ((_fileSystem.Path.GetExtension(item[0]) == ".crash") ? ".mdmp" : ".crash");
			string text = _fileSystem.Path.ChangeExtension(item[0], extension);
			if (_fileSystem.File.Exists(text))
			{
				list.Add(text);
			}
		}
		await Attachments.AddAsync(list.ToArray());
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task AttachProgramFileLog()
	{
		string path = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RenewedVision", "ProPresenter", "Logs");
		List<string> list = new List<string>();
		list.AddRange(_fileSystem.Directory.GetFiles(path, "Log*").OrderByDescending(File.GetLastWriteTime).Take(2));
		list.AddRange(_fileSystem.Directory.GetFiles(path, "helper-workspaces*").OrderByDescending(File.GetLastWriteTime).Take(2));
		list.AddRange(_fileSystem.Directory.GetFiles(path, "helper-snapshots*").OrderByDescending(File.GetLastWriteTime).Take(2));
		if (list.Count != 0)
		{
			await Attachments.AddAsync(list);
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task AttachChooseFile()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = "All Files (*.*)|*.*",
			Multiselect = true
		};
		if (openFileDialog.ShowDialog() == true)
		{
			await Attachments.AddAsync(openFileDialog.FileNames);
		}
	}

	[RelayCommand(CanExecute = "AttachWorkspace_CanExecute", FlowExceptionsToTaskScheduler = true)]
	private async Task AttachWorkspace()
	{
		AttachmentInProgress = true;
		try
		{
			IWorkspace workSpace = _workspaceService.Workspaces.First((IWorkspace w) => w.Active);
			_zippedWorkspaceLocation = await _workspaceService.ZipWorkspaceAsync(workSpace);
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(_zippedWorkspaceLocation) && _fileSystem.File.Exists(_zippedWorkspaceLocation))
			{
				list.Add(_zippedWorkspaceLocation);
				await Attachments.AddAsync(list);
			}
			else
			{
				_logger.Error("Failed to zip the active workspace.");
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to zip the active workspace. {value}");
		}
		finally
		{
			AttachmentInProgress = false;
		}
	}

	private bool AttachWorkspace_CanExecute()
	{
		IWorkspace workspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		if (workspace == null)
		{
			return false;
		}
		string zipFilename = workspace.Name + ".zip";
		return Attachments.None((IUserAttachment a) => a.FileNameShort.Equals(zipFilename));
	}

	[RelayCommand(CanExecute = "AttachCloudDocuments_CanExecute", FlowExceptionsToTaskScheduler = true)]
	private async Task AttachCloudDocuments()
	{
		AttachmentInProgress = true;
		try
		{
			IWorkspace activeWorkspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
			if (activeWorkspace == null)
			{
				_logger.Error("No active workspace found for cloud documents zip.");
				return;
			}
			List<string> cloudFiles = _fileSystem.Directory.EnumerateFiles(activeWorkspace.Path, "*.proCloud", SearchOption.AllDirectories).ToList();
			if (!cloudFiles.Any())
			{
				_logger.Warning("No .proCloud files found in active workspace.");
				return;
			}
			string text = _fileSystem.Path.Combine(_fileSystem.Path.GetTempPath(), _fileSystem.Path.GetRandomFileName());
			_fileSystem.Directory.CreateDirectory(text);
			string tempZip = _fileSystem.Path.Combine(text, "CRDTDocuments.zip");
			await Task.Run(delegate
			{
				using FileSystemStream stream = _fileSystem.File.Create(tempZip);
				using System.IO.Compression.ZipArchive zipArchive = new System.IO.Compression.ZipArchive(stream, ZipArchiveMode.Create);
				foreach (string item in cloudFiles)
				{
					string relativePath = _fileSystem.Path.GetRelativePath(activeWorkspace.Path, item);
					using Stream destination = zipArchive.CreateEntry(relativePath).Open();
					using FileSystemStream fileSystemStream = _fileSystem.File.OpenRead(item);
					fileSystemStream.CopyTo(destination);
				}
			});
			_zippedCloudDocumentsLocation = tempZip;
			if (_fileSystem.File.Exists(_zippedCloudDocumentsLocation))
			{
				await Attachments.AddAsync(new string[1] { _zippedCloudDocumentsLocation });
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to zip cloud documents. {value}");
		}
		finally
		{
			AttachmentInProgress = false;
		}
	}

	private bool AttachCloudDocuments_CanExecute()
	{
		IWorkspace? workspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		if (workspace != null && workspace.WorkspaceType == WorkspaceType.Synced)
		{
			return Attachments.None((IUserAttachment a) => a.FileNameShort.Equals("CRDTDocuments.zip"));
		}
		return false;
	}

	[RelayCommand(CanExecute = "RemoveAttachmentCommand_CanExecute")]
	private void RemoveAttachment(IUserAttachment attachment)
	{
		Attachments.Remove(attachment);
		if (SelectedAttachment == attachment)
		{
			SelectedAttachment = null;
		}
		CleanupWorkspaceAttachment();
	}

	public void CleanupWorkspaceAttachment()
	{
		if (!string.IsNullOrEmpty(_zippedWorkspaceLocation))
		{
			string directoryName = _fileSystem.Path.GetDirectoryName(_zippedWorkspaceLocation);
			if (!string.IsNullOrEmpty(directoryName) && _fileSystem.Directory.Exists(directoryName))
			{
				_fileSystem.Directory.Delete(directoryName, recursive: true);
			}
			_zippedWorkspaceLocation = string.Empty;
		}
		if (!string.IsNullOrEmpty(_zippedCloudDocumentsLocation))
		{
			string directoryName2 = _fileSystem.Path.GetDirectoryName(_zippedCloudDocumentsLocation);
			if (!string.IsNullOrEmpty(directoryName2) && _fileSystem.Directory.Exists(directoryName2))
			{
				_fileSystem.Directory.Delete(directoryName2, recursive: true);
			}
			_zippedCloudDocumentsLocation = string.Empty;
		}
	}

	private static bool RemoveAttachmentCommand_CanExecute(IUserAttachment attachment)
	{
		if (attachment != null)
		{
			return !attachment.IsReadOnly;
		}
		return false;
	}

	[RelayCommand]
	private void ShowInFolder()
	{
		if (SelectedAttachment != null)
		{
			_processHelper.OpenFileInExplorer(SelectedAttachment.FileName);
		}
	}

	protected void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("IsValid");
		AttachSystemDiagnosticsCommand.NotifyCanExecuteChanged();
		AttachSystemInformationCommand.NotifyCanExecuteChanged();
		AttachCloudDocumentsCommand.NotifyCanExecuteChanged();
	}

	public async Task PrepareAttachmentUploads()
	{
		List<Task> list = new List<Task>();
		foreach (IUserAttachment attachment in Attachments)
		{
			list.Add(GetAttachmentUploadDataAsync(attachment));
		}
		await Task.WhenAll(list);
	}

	private async Task GetAttachmentUploadDataAsync(IUserAttachment attachment)
	{
		try
		{
			using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			AttachmentUploadRequest uploadRequest = new AttachmentUploadRequest(new AttachmentMetadata(_fileSystem.Path.GetFileName(attachment.FileName), attachment.FileShaHash, attachment.FileSize));
			AttachmentUploadResponse attachmentUploadResponse = ((await _apiConsumer.PostCreateAttachmentUploadAsync(uploadRequest, cancellationTokenSource.Token)) as SuccessResult<AttachmentUploadResponse>)?.Data;
			if (attachmentUploadResponse != null)
			{
				attachment.UploadUrl = attachmentUploadResponse.UploadUrl;
				attachment.ViewUrl = attachmentUploadResponse.ViewUrl;
				attachment.UploadHeaders = attachmentUploadResponse.UploadHeaders;
				attachment.Identifier = attachmentUploadResponse.Identifier;
			}
		}
		catch (Exception ex)
		{
			_logger.Error(ex);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		SelectedAttachment = null;
		if (Attachments is ObservableCollection<IUserAttachment> observableCollection)
		{
			observableCollection.CollectionChanged -= OnCollectionChanged;
		}
	}
}
