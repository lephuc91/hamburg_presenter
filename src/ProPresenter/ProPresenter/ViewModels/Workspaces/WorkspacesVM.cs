using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Concurrency;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.CoreApplication.Workspace;
using Pro.DO.Utility;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using Pro.Web.Services;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.Subscription;
using ProPresenter.DO.Updates;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.Settings.PageTemplates.General;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.ViewModels.Settings.Pages.General;

namespace ProPresenter.ViewModels.Workspaces;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_cloudCollaboratorsSubscription", "_userStateSubscription" })]
public class WorkspacesVM : ObservableObject, IWorkspacesVM, IDisposable
{
	private const int MOVE_TO_TRASH_RETRY_COUNT = 5;

	private const int MOVE_TO_TRASH_EXPONENTIAL_BACKOFF = 200;

	private const long FOUR_GB_IN_BYTES = 4000000000L;

	private const long MAX_WORKSPACE_NAME_CHARACTERS = 255L;

	private readonly IChangeWorkspaceHandler _changeWorkspaceHandler;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly ILocalization _localization;

	private readonly IFileSystem _fileSystem;

	private readonly IProcessHelper _processHelper;

	private readonly IManageWorkspacesWindowProvider _manageWorkspacesWindowProvider;

	private readonly IFileUtility _fileUtility;

	private readonly ILogger _logger;

	private readonly IFileService _fileService;

	private readonly IWorkspaceService _workspaceService;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly IMainLayoutVM _mainLayoutVM;

	private readonly IWorkspaceSwitchValidator _workspaceSwitchValidator;

	private readonly ICloudWorkspaceService? _cloudWorkspaceService;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IMessageDialogService _messageDialogService;

	private readonly IWorkspaceDocumentOrchestrator _workspaceDocumentOrchestrator;

	private readonly IDisposable? _cloudCollaboratorsSubscription;

	private readonly IWorkspaceCollectionVM _workspaceCollectionVM;

	private readonly IWorkspaceAnalyticsEventPublisher _workspaceAnalytics;

	private readonly IVisualPlaylistRepo _visualPlaylistRepo;

	private readonly IStopwatchFactory _stopwatchFactory;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IRegistrationStateProvider _registration;

	private readonly IDisposable _userStateSubscription;

	private readonly IAppUpdateService _appUpdateService;

	private readonly IMediaFileProvider _mediaFileProvider;

	[ObservableProperty]
	private IReadOnlyList<string> _collaborators;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("DownloadCloudWorkspaceCommand", new string[] { "ConvertToLocalWorkspaceCommand", "PublishWorkspaceCommand" })]
	private bool _isCloudSignedIn;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("DownloadCloudWorkspaceCommand", new string[] { "ConvertToLocalWorkspaceCommand", "RenameWorkspaceCommand", "DeleteWorkspaceCommand", "PublishWorkspaceCommand" })]
	private IWorkspaceItemVM _selectedWorkspace;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("DownloadCloudWorkspaceCommand", new string[] { "ConvertToLocalWorkspaceCommand", "RenameWorkspaceCommand", "DeleteWorkspaceCommand", "PublishWorkspaceCommand" })]
	private IWorkspaceItemVM _selectedManagedWorkspace;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? createWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? deleteWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? importSelectedLegacyFolderToWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? manageCloudWorkspacesLinkCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? publishWorkspaceWithConfirmCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? publishWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? renameWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? manageWorkspacesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? manageCloudWorkspacesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openInExplorerCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? duplicateSelectedWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<IWorkspaceItemVM>? selectWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<IWorkspaceItemVM>? downloadCloudWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? convertToLocalWorkspaceCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public INotifyEnumerableChanged<IWorkspaceItemVM> Workspaces => _workspaceCollectionVM.Workspaces;

	private bool SelectedManagedWorkspaceIsCloud
	{
		get
		{
			IWorkspaceItemVM selectedManagedWorkspace = SelectedManagedWorkspace;
			if (selectedManagedWorkspace == null)
			{
				return false;
			}
			return selectedManagedWorkspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud;
		}
	}

	private bool SelectedManagedWorkspaceIsSyncedAndActive
	{
		get
		{
			IWorkspaceItemVM selectedManagedWorkspace = SelectedManagedWorkspace;
			if (selectedManagedWorkspace != null && selectedManagedWorkspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced)
			{
				return SelectedManagedWorkspace == SelectedWorkspace;
			}
			return false;
		}
	}

	private bool SelectedManagedWorkspaceIsNotCloud
	{
		get
		{
			IWorkspaceItemVM selectedManagedWorkspace = SelectedManagedWorkspace;
			if (selectedManagedWorkspace == null)
			{
				return true;
			}
			return selectedManagedWorkspace.WorkspaceType != ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud;
		}
	}

	private bool SelectedManagedWorkspaceIsNotNull => SelectedManagedWorkspace != null;

	private bool SelectedWorkspaceIsManagedWorkspace => SelectedManagedWorkspace == SelectedWorkspace;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IReadOnlyList<string> Collaborators
	{
		get
		{
			return _collaborators;
		}
		[MemberNotNull("_collaborators")]
		set
		{
			if (!EqualityComparer<IReadOnlyList<string>>.Default.Equals(_collaborators, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Collaborators);
				_collaborators = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Collaborators);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsCloudSignedIn
	{
		get
		{
			return _isCloudSignedIn;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isCloudSignedIn, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsCloudSignedIn);
				_isCloudSignedIn = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsCloudSignedIn);
				DownloadCloudWorkspaceCommand.NotifyCanExecuteChanged();
				ConvertToLocalWorkspaceCommand.NotifyCanExecuteChanged();
				PublishWorkspaceCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IWorkspaceItemVM SelectedWorkspace
	{
		get
		{
			return _selectedWorkspace;
		}
		[MemberNotNull("_selectedWorkspace")]
		set
		{
			if (!EqualityComparer<IWorkspaceItemVM>.Default.Equals(_selectedWorkspace, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedWorkspace);
				_selectedWorkspace = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedWorkspace);
				DownloadCloudWorkspaceCommand.NotifyCanExecuteChanged();
				ConvertToLocalWorkspaceCommand.NotifyCanExecuteChanged();
				RenameWorkspaceCommand.NotifyCanExecuteChanged();
				DeleteWorkspaceCommand.NotifyCanExecuteChanged();
				PublishWorkspaceCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IWorkspaceItemVM SelectedManagedWorkspace
	{
		get
		{
			return _selectedManagedWorkspace;
		}
		[MemberNotNull("_selectedManagedWorkspace")]
		set
		{
			if (!EqualityComparer<IWorkspaceItemVM>.Default.Equals(_selectedManagedWorkspace, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedManagedWorkspace);
				_selectedManagedWorkspace = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedManagedWorkspace);
				DownloadCloudWorkspaceCommand.NotifyCanExecuteChanged();
				ConvertToLocalWorkspaceCommand.NotifyCanExecuteChanged();
				RenameWorkspaceCommand.NotifyCanExecuteChanged();
				DeleteWorkspaceCommand.NotifyCanExecuteChanged();
				PublishWorkspaceCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CreateWorkspaceCommand => createWorkspaceCommand ?? (createWorkspaceCommand = new RelayCommand(CreateWorkspace));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DeleteWorkspaceCommand => deleteWorkspaceCommand ?? (deleteWorkspaceCommand = new AsyncRelayCommand(DeleteWorkspace, () => SelectedManagedWorkspaceIsNotCloud, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ImportSelectedLegacyFolderToWorkspaceCommand => importSelectedLegacyFolderToWorkspaceCommand ?? (importSelectedLegacyFolderToWorkspaceCommand = new RelayCommand(ImportSelectedLegacyFolderToWorkspace));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ManageCloudWorkspacesLinkCommand => manageCloudWorkspacesLinkCommand ?? (manageCloudWorkspacesLinkCommand = new RelayCommand(ManageCloudWorkspacesLink));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand PublishWorkspaceWithConfirmCommand => publishWorkspaceWithConfirmCommand ?? (publishWorkspaceWithConfirmCommand = new AsyncRelayCommand(PublishWorkspaceWithConfirm, () => SelectedWorkspaceIsManagedWorkspace, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand PublishWorkspaceCommand => publishWorkspaceCommand ?? (publishWorkspaceCommand = new AsyncRelayCommand(PublishWorkspace, () => SelectedWorkspaceIsManagedWorkspace, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RenameWorkspaceCommand => renameWorkspaceCommand ?? (renameWorkspaceCommand = new AsyncRelayCommand(RenameWorkspace, () => SelectedManagedWorkspaceIsNotNull, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ManageWorkspacesCommand => manageWorkspacesCommand ?? (manageWorkspacesCommand = new RelayCommand(ManageWorkspaces));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ManageCloudWorkspacesCommand => manageCloudWorkspacesCommand ?? (manageCloudWorkspacesCommand = new RelayCommand(ManageCloudWorkspaces));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenInExplorerCommand => openInExplorerCommand ?? (openInExplorerCommand = new RelayCommand(OpenInExplorer));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand DuplicateSelectedWorkspaceCommand => duplicateSelectedWorkspaceCommand ?? (duplicateSelectedWorkspaceCommand = new AsyncRelayCommand(DuplicateSelectedWorkspaceAsync, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<IWorkspaceItemVM> SelectWorkspaceCommand => selectWorkspaceCommand ?? (selectWorkspaceCommand = new AsyncRelayCommand<IWorkspaceItemVM>(SelectWorkspace, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<IWorkspaceItemVM> DownloadCloudWorkspaceCommand => downloadCloudWorkspaceCommand ?? (downloadCloudWorkspaceCommand = new AsyncRelayCommand<IWorkspaceItemVM>(DownloadCloudWorkspace, CanDownloadCloudWorkspace, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ConvertToLocalWorkspaceCommand => convertToLocalWorkspaceCommand ?? (convertToLocalWorkspaceCommand = new AsyncRelayCommand(ConvertToLocalWorkspace, () => SelectedManagedWorkspaceIsSyncedAndActive, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public WorkspacesVM(IChangeWorkspaceHandler changeWorkspaceHandler, IFileSelectorService fileSelectorService, ILocalization localization, IFileSystem fileSystem, IProcessHelper processHelper, IManageWorkspacesWindowProvider manageWorkspacesWindowProvider, IWorkspaceService workspaceService, IFileUtility fileUtility, ILogger logger, IFileService fileService, ICommonPathsWrapper commonPathsWrapper, IMainLayoutVM mainLayoutVm, IWorkspaceSwitchValidator workspaceSwitchValidator, IHyperlinkService hyperlinkService, ICloudWorkspaceService? cloudWorkspaceService, IRegistrationStateProvider registration, IRegistrationWebResourceService registrationWebResourceService, IUiScheduler uiScheduler, IMessageDialogService messageDialogService, IWorkspaceAnalyticsEventPublisher workspaceAnalytics, IVisualPlaylistRepo visualPlaylistRepo, IWorkspaceDocumentOrchestrator workspaceDocumentOrchestrator, IStopwatchFactory stopwatchFactory, IAsyncExecutor asyncExecutor, IAppUpdateService appUpdateService, IMediaFileProvider mediaFileProvider, IWorkspaceCollectionVM workspaceCollectionVM)
	{
		_changeWorkspaceHandler = changeWorkspaceHandler;
		_changeWorkspaceHandler.Completed += ChangeWorkspaceHandler_Completed;
		_cloudWorkspaceService = cloudWorkspaceService;
		_registration = registration;
		_fileSelectorService = fileSelectorService;
		_localization = localization;
		_fileSystem = fileSystem;
		_hyperlinkService = hyperlinkService;
		_processHelper = processHelper;
		_workspaceService = workspaceService;
		_manageWorkspacesWindowProvider = manageWorkspacesWindowProvider;
		_fileUtility = fileUtility;
		_registrationWebResourceService = registrationWebResourceService;
		_logger = logger;
		_fileService = fileService;
		_commonPathsWrapper = commonPathsWrapper;
		_mainLayoutVM = mainLayoutVm;
		_workspaceSwitchValidator = workspaceSwitchValidator;
		_messageDialogService = messageDialogService;
		_workspaceAnalytics = workspaceAnalytics;
		_visualPlaylistRepo = visualPlaylistRepo;
		_stopwatchFactory = stopwatchFactory;
		_asyncExecutor = asyncExecutor;
		_workspaceDocumentOrchestrator = workspaceDocumentOrchestrator;
		_appUpdateService = appUpdateService;
		_mediaFileProvider = mediaFileProvider;
		_collaborators = Array.Empty<string>();
		_workspaceCollectionVM = workspaceCollectionVM;
		EnsureActiveWorkspace();
		SelectedWorkspace = _workspaceCollectionVM.Workspaces.First((IWorkspaceItemVM a) => a.Active);
		SelectedManagedWorkspace = Workspaces.First((IWorkspaceItemVM a) => a.Active);
		if (_cloudWorkspaceService != null)
		{
			_cloudCollaboratorsSubscription = _cloudWorkspaceService.WhenCollaboratorsChanged.ObserveOn(uiScheduler.Scheduler).Subscribe(delegate(IReadOnlyList<string> @new)
			{
				Collaborators = @new;
			});
		}
		IObservable<bool> source = (from e in Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(delegate(PropertyChangedEventHandler h)
			{
				_registration.PropertyChanged += h;
			}, delegate(PropertyChangedEventHandler h)
			{
				_registration.PropertyChanged -= h;
			})
			where e.EventArgs.PropertyName == "Registration"
			select e into _
			select IsUserSignedIn()).StartWith(IsUserSignedIn()).DistinctUntilChanged();
		IsCloudSignedIn = IsUserSignedIn();
		_userStateSubscription = source.ObserveOn(uiScheduler.Scheduler).SelectMany((bool signedIn) => Observable.FromAsync((Func<Task>)async delegate
		{
			try
			{
				IsCloudSignedIn = signedIn;
				if (!signedIn)
				{
					await ValidateWorkspacesAsync();
				}
			}
			catch (Exception ex)
			{
				_logger.Error("Failed to handle user state change: " + ex.Message);
			}
		})).Subscribe();
	}

	private bool IsUserSignedIn()
	{
		return !(_registration.Registration?.SubscriptionState is UnsubscribedState);
	}

	private async Task ValidateWorkspacesAsync()
	{
		if (IsCloudSignedIn)
		{
			return;
		}
		if (SelectedWorkspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced && _cloudWorkspaceService != null)
		{
			try
			{
				await _cloudWorkspaceService.ConvertToLocalAsync();
			}
			catch (Exception ex)
			{
				_logger?.Error("ConvertToLocalAsync failed for cloud workspace '" + SelectedWorkspace.Name + "': " + ex.Message);
			}
		}
		foreach (IWorkspaceItemVM item in Workspaces.ToList())
		{
			if (item.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced)
			{
				try
				{
					item.ConvertToLocalWorkspace();
				}
				catch (Exception ex2)
				{
					_logger?.Error("Failed to convert cloud workspace '" + item.Name + "' to local: " + ex2.Message);
				}
			}
		}
	}

	private async Task SetActiveWorkspace(IWorkspaceItemVM value)
	{
		SelectedWorkspace = value;
		if (!(value is IWorkspaceItemVMInternal workspaceItemVMInternal))
		{
			return;
		}
		try
		{
			if (_cloudWorkspaceService != null && value.WorkspaceType != ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud && !string.IsNullOrEmpty(value.Path))
			{
				await _workspaceDocumentOrchestrator.SendWorkspaceDocumentsToCoreAsync(workspaceItemVMInternal.Workspace);
			}
		}
		catch (Exception ex)
		{
			_logger?.Error("Failed to open cloud workspace locally for '" + value?.Name + "': " + ex.Message);
		}
	}

	private void EnsureActiveWorkspace()
	{
		if (_workspaceCollectionVM.Workspaces.FirstOrDefault((IWorkspaceItemVM a) => a.Active) == null && _workspaceCollectionVM.Workspaces.Any())
		{
			_workspaceCollectionVM.Workspaces.ElementAt(0).Active = true;
		}
	}

	private void ChangeWorkspaceHandler_Completed(ChangeWorkspaceCompleted completed)
	{
		IWorkspaceItemVM selectedWorkspace;
		if (!completed.Success)
		{
			IWorkspaceItemVM workspaceItemVM = Workspaces.OfType<IWorkspaceItemVMInternal>().FirstOrDefault((IWorkspaceItemVMInternal p) => p.Workspace == completed.OldWorkspace);
			selectedWorkspace = workspaceItemVM ?? Workspaces.First();
		}
		else
		{
			selectedWorkspace = Workspaces.FirstOrDefault((IWorkspaceItemVM a) => a.Active) ?? Workspaces.First();
			_workspaceService.OnWorkspaceSwitch();
		}
		if (!selectedWorkspace.Active)
		{
			foreach (IWorkspaceItemVM item in Workspaces.Where((IWorkspaceItemVM w) => w.Active))
			{
				item.Active = false;
			}
			selectedWorkspace.Active = true;
		}
		SelectedManagedWorkspace = selectedWorkspace;
		_asyncExecutor.ExecuteAsync(() => SetActiveWorkspace(selectedWorkspace));
		if (completed.PublishAfterChange)
		{
			PublishWorkspaceCommand.Execute(selectedWorkspace);
		}
		_mainLayoutVM.ShowMainViewCommand.Invoke();
	}

	[RelayCommand]
	private void CreateWorkspace()
	{
		string title = _localization.Get("LOCALWORKSPACE_NEW_WORKSPACE_DIALOG_title");
		IWorkspace workspace = _workspaceService.Workspaces.Create(_localization.Get("CLOUDWORKSPACE_DEFAULT_WORKSPACE_name"), _commonPathsWrapper.DefaultLocalWorkspaces, ProPresenter.DO.Workspaces.WorkspaceType.Local, null, null, null);
		if (_manageWorkspacesWindowProvider.ShowNameWorkspaceDialog(title, workspace, out var isCloudWorkspace))
		{
			_fileSystem.Directory.CreateDirectory(workspace.Path);
			_workspaceService.Workspaces.Add(workspace, makeActive: true);
			_changeWorkspaceHandler.ChangeWorkspace(workspace, isCloudWorkspace);
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true, CanExecute = "SelectedManagedWorkspaceIsNotCloud")]
	private async Task DeleteWorkspace()
	{
		if (string.IsNullOrEmpty(SelectedManagedWorkspace.Path))
		{
			_logger.Error("Cannot delete workspace: Workspace or its path is null.");
			return;
		}
		try
		{
			if (_manageWorkspacesWindowProvider.ConfirmDeletion(SelectedManagedWorkspace.Name, SelectedManagedWorkspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced))
			{
				int index = _workspaceCollectionVM.Workspaces.IndexOf(SelectedManagedWorkspace);
				IWorkspace workspace = _workspaceService.Workspaces.First((IWorkspace p) => p.Path == SelectedManagedWorkspace.Path);
				bool wasActiveWorkspace = SelectedManagedWorkspace.Active;
				await _workspaceService.RemoveWorkspaceAsync(workspace);
				if (!(await MoveToRecycleBinWithRetryAsync(SelectedManagedWorkspace.Path)))
				{
					_logger.Error("[{0}]Failed to move workspace '{1}' to the recycle bin after {2} attempts.", "WorkspacesVM", SelectedManagedWorkspace.Name, 6);
				}
				IWorkspaceItemVM workspaceItemVM2 = (SelectedManagedWorkspace = Enumerable.ElementAt(index: index.Clamp(0, _workspaceCollectionVM.Workspaces.Count() - 1), source: _workspaceCollectionVM.Workspaces));
				if (wasActiveWorkspace)
				{
					workspaceItemVM2.Active = true;
					await SetActiveWorkspace(workspaceItemVM2);
				}
			}
		}
		catch (Exception value)
		{
			_logger.Error($"An error occurred while deleting the workspace '{SelectedManagedWorkspace.Name}': {value}");
		}
	}

	[RelayCommand]
	private void ImportSelectedLegacyFolderToWorkspace()
	{
		ImportFolderToWorkspace();
	}

	[RelayCommand]
	private void ManageCloudWorkspacesLink()
	{
		_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetWorkspaceDashboard()));
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true, CanExecute = "SelectedWorkspaceIsManagedWorkspace")]
	private async Task PublishWorkspaceWithConfirm()
	{
		string text;
		try
		{
			text = await Task.Run(() => _fileService.GetTotalSize(SelectedWorkspace.Path).BytesToReadableSizeFormat());
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to calculate workspace size for '{SelectedWorkspace.Name}': {value}");
			string message = _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_title", new object[1] { SelectedWorkspace.Name });
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(message, _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_description"));
			return;
		}
		bool userConfirmed = false;
		string heading = _localization.Get("CLOUDWORKSPACE_CONVERT_TO_CLOUD_CONFIRM_title", new object[2] { SelectedWorkspace.Name, text });
		_messageDialogService.ShowDialog(string.Empty, heading, string.Empty, new ButtonDescriptor[2]
		{
			new ButtonDescriptor(LocalizedStrings.Get("CLOUDWORKSPACE_CONVERT_TO_CLOUD_CONFIRM_button"), IsDefault: true, IsCancel: false, delegate
			{
				userConfirmed = true;
			}),
			new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
		}, DialogIcon.Default);
		if (userConfirmed)
		{
			await PublishWorkspace();
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true, CanExecute = "SelectedWorkspaceIsManagedWorkspace")]
	private async Task PublishWorkspace()
	{
		if (_cloudWorkspaceService == null)
		{
			return;
		}
		if ((long)SelectedWorkspace.Name.Length > 255L)
		{
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(_localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_TOO_LONG_FOR_CLOUD_title"), _localization.Get("LOCALWORKSPACE_WORKSPACE_NAME_TOO_LONG_FOR_CLOUD_message"));
			return;
		}
		bool num = _visualPlaylistRepo.Playlists.OfType<IPlaylist<MediaCue>>().Flatten().OfType<SmartPlaylist>()
			.ToArray()
			.Any();
		bool userConfirmed = false;
		if (num)
		{
			_messageDialogService.ShowDialog(string.Empty, _localization.Get("CLOUDWORKSPACE_CONVERSION_WARNING_SMART_PLAYLISTS_title"), string.Empty, new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"), IsDefault: true, IsCancel: false, delegate
				{
					userConfirmed = true;
				}),
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
			}, DialogIcon.Default);
			if (!userConfirmed)
			{
				return;
			}
		}
		else if (_mediaFileProvider.HasUnmanagedMedia())
		{
			_messageDialogService.ShowDialog(string.Empty, _localization.Get("CLOUDWORKSPACE_CONVERSION_WARNING_UNMANAGED_MEDIA_title"), string.Empty, new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_OK_BUTTON_title"), IsDefault: true, IsCancel: false, delegate
				{
					userConfirmed = true;
				}),
				new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
			}, DialogIcon.Default);
			if (!userConfirmed)
			{
				return;
			}
		}
		IStopwatch stopwatch = _stopwatchFactory.Create();
		stopwatch.Restart();
		using (_manageWorkspacesWindowProvider.ShowProgressSpinner(_localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_title", new object[1] { SelectedWorkspace.Name })))
		{
			_ = 1;
			try
			{
				await _visualPlaylistRepo.Playlists.ConvertAllSmartPlaylistsToVisualPlaylistsAsync();
				Guid result = await _cloudWorkspaceService.PublishAsync();
				SelectedWorkspace.WorkspaceType = ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced;
				SelectedWorkspace.CloudId = result;
				_workspaceAnalytics.WorkspaceCreation(WorkspaceCreationSource.Settings, stopwatch.Elapsed);
				IWorkspace workspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.CloudId == result && w.WorkspaceType == ProPresenter.DO.Workspaces.WorkspaceType.Cloud);
				if (workspace != null)
				{
					_workspaceService.Workspaces.Remove(workspace);
				}
			}
			catch (Exception value)
			{
				_logger.Error($"Failed to publish workspace: {value}");
				string message = _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_title", new object[1] { SelectedWorkspace.Name });
				_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(message, _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_description"));
			}
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true, CanExecute = "SelectedManagedWorkspaceIsNotNull")]
	private async Task RenameWorkspace()
	{
		string title = _localization.Get("LOCALWORKSPACE_RENAME_WORKSPACE_DIALOG_title");
		string name = SelectedManagedWorkspace.Name;
		IWorkspace workspace = _workspaceService.Workspaces.Create(SelectedManagedWorkspace.Name, SelectedManagedWorkspace.Path, ProPresenter.DO.Workspaces.WorkspaceType.Local, null, null, null);
		if (!_manageWorkspacesWindowProvider.ShowRenameWorkspaceDialog(title, workspace, DoesWorkspaceNameExists, name))
		{
			return;
		}
		_workspaceService.Workspaces.RenameWorkspace(SelectedManagedWorkspace.Name, workspace.Name, SelectedManagedWorkspace.Path);
		if (_cloudWorkspaceService == null)
		{
			return;
		}
		try
		{
			await _cloudWorkspaceService.RenameAsync(SelectedManagedWorkspace.CloudId, workspace.Name);
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to rename cloud workspace: {value}");
		}
	}

	[RelayCommand]
	private void ManageWorkspaces()
	{
		_manageWorkspacesWindowProvider.ShowManageWorkspacesWindow(this);
	}

	[RelayCommand]
	private void ManageCloudWorkspaces()
	{
		_manageWorkspacesWindowProvider.ShowManageCloudWorkspacesWindow(this);
	}

	[RelayCommand]
	private void OpenInExplorer()
	{
		if (!string.IsNullOrEmpty(SelectedManagedWorkspace?.Path))
		{
			_processHelper.OpenFileInExplorer(SelectedManagedWorkspace.Path);
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task DuplicateSelectedWorkspaceAsync()
	{
		await DuplicateWorkspaceAsync(SelectedManagedWorkspace);
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task SelectWorkspace(IWorkspaceItemVM workspace)
	{
		if (!workspace.Equals(SelectedWorkspace))
		{
			if (workspace is IWorkspaceItemVMInternal workspaceItemVMInternal)
			{
				_workspaceCollectionVM.EnsureCloudWorkspaceExists(workspaceItemVMInternal.Workspace);
			}
			if (workspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Local)
			{
				ChangeWorkspace(workspace);
				return;
			}
			if (workspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced)
			{
				ChangeToSyncedWorkspace(workspace);
				return;
			}
			if (workspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud)
			{
				await ChangeToCloudWorkspace(workspace);
				return;
			}
			_logger.Error($"New workspace type. Workspace: '{workspace.Name}' Type: '{workspace.WorkspaceType}'");
			ChangeWorkspace(workspace);
		}
	}

	private async Task ChangeToCloudWorkspace(IWorkspaceItemVM workspace)
	{
		if (workspace.MinimumRequiredAppVersion == ProPresenter.DO.Workspaces.Workspace.CurrentDataModelVersion)
		{
			if (await MakeLocal(workspace))
			{
				ChangeWorkspace(workspace);
			}
			return;
		}
		bool userChoseUpdate = false;
		_messageDialogService.ShowDialog(null, _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_title"), _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_info", workspace.Name, workspace.MinimumRequiredAppVersion), new ButtonDescriptor[2]
		{
			new ButtonDescriptor(LocalizedStrings.Get("APP_OUTDATED_UPDATE_button"), IsDefault: true, IsCancel: false, delegate
			{
				userChoseUpdate = true;
			}),
			new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
		}, DialogIcon.Default);
		if (userChoseUpdate)
		{
			if ((object)_appUpdateService.BuildAvailable != null)
			{
				_appUpdateService.InstallVersion(_appUpdateService.BuildAvailable);
				return;
			}
			_logger.Error($"MinimumRequiredAppVersion mismatch without an available update. Workspace: '{workspace.Name}' Version: '{workspace.MinimumRequiredAppVersion}'");
			workspace.ConvertToLocalWorkspace();
		}
	}

	private void ChangeToSyncedWorkspace(IWorkspaceItemVM workspace)
	{
		if (workspace.MinimumRequiredAppVersion == ProPresenter.DO.Workspaces.Workspace.CurrentDataModelVersion)
		{
			ChangeWorkspace(workspace);
			return;
		}
		bool userChoseUpdate = false;
		bool userChoseMakeLocalCopy = false;
		_messageDialogService.ShowDialog(null, _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_title"), _localization.Get("CLOUDWORKSPACE_REQUIRES_NEWER_PROPRESENTER_info", workspace.Name, workspace.MinimumRequiredAppVersion), new ButtonDescriptor[3]
		{
			new ButtonDescriptor(LocalizedStrings.Get("APP_OUTDATED_UPDATE_button"), IsDefault: true, IsCancel: false, delegate
			{
				userChoseUpdate = true;
			}),
			new ButtonDescriptor(LocalizedStrings.Get("CLOUDWORKSPACE_MAKE_LOCAL_COPY_OF_WORKSPACE_button"), IsDefault: true, IsCancel: false, delegate
			{
				userChoseMakeLocalCopy = true;
			}),
			new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
		}, DialogIcon.Default);
		if (userChoseMakeLocalCopy)
		{
			workspace.ConvertToLocalWorkspace();
			ChangeWorkspace(workspace);
		}
		else if (userChoseUpdate)
		{
			if ((object)_appUpdateService.BuildAvailable != null)
			{
				_appUpdateService.InstallVersion(_appUpdateService.BuildAvailable);
				return;
			}
			_logger.Error($"MinimumRequiredAppVersion mismatch without an available update. Workspace: '{workspace.Name}' Version: '{workspace.MinimumRequiredAppVersion}'");
			workspace.ConvertToLocalWorkspace();
		}
	}

	private void ChangeWorkspace(IWorkspaceItemVM workspace)
	{
		if (workspace is IWorkspaceItemVMInternal workspaceItemVMInternal && _workspaceSwitchValidator.Validate(workspaceItemVMInternal.Workspace, out IWorkspace resultWorkspace))
		{
			if (!_workspaceService.Workspaces.Contains(resultWorkspace))
			{
				_workspaceService.Workspaces.Add(resultWorkspace, makeActive: true);
			}
			else
			{
				resultWorkspace.Active = true;
			}
			_changeWorkspaceHandler.ChangeWorkspace(resultWorkspace);
		}
	}

	[RelayCommand(CanExecute = "CanDownloadCloudWorkspace", FlowExceptionsToTaskScheduler = true)]
	private async Task DownloadCloudWorkspace(IWorkspaceItemVM workspace)
	{
		IWorkspaceItemVM target = workspace ?? SelectedManagedWorkspace;
		if (target != null && await MakeLocal(target))
		{
			ChangeWorkspace(target);
		}
	}

	private bool CanDownloadCloudWorkspace(IWorkspaceItemVM workspace)
	{
		if (workspace == null)
		{
			return SelectedManagedWorkspaceIsCloud;
		}
		return workspace.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud;
	}

	[RelayCommand(CanExecute = "SelectedManagedWorkspaceIsSyncedAndActive", FlowExceptionsToTaskScheduler = true)]
	private async Task ConvertToLocalWorkspace()
	{
		if (_cloudWorkspaceService != null)
		{
			await _cloudWorkspaceService.ConvertToLocalAsync();
			SelectedWorkspace.ConvertToLocalWorkspace();
		}
	}

	private async Task<bool> MakeLocal(IWorkspaceItemVM workspace)
	{
		try
		{
			if (_cloudWorkspaceService == null)
			{
				_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(_localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_title", new object[1] { workspace.Name }), _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_description"));
				_logger.Error("Cannot sync cloud workspace '" + workspace.Name + "': Workspace Service is null'.");
				return false;
			}
			bool flag;
			try
			{
				flag = await DownloadAndSyncCloudWorkspace(workspace);
			}
			catch (Exception value)
			{
				_logger.Error($"Failed to sync cloud workspace remote for '{workspace.Name}': {value}");
				return false;
			}
			if (!flag)
			{
				_logger.Error("Download failed for cloud workspace '" + workspace.Name + "'");
				return false;
			}
			return true;
		}
		catch (Exception value2)
		{
			_logger.Error($"Failed to sync cloud workspace remote: {value2}");
			return false;
		}
	}

	private async Task<bool> DownloadAndSyncCloudWorkspace(IWorkspaceItemVM workspace)
	{
		if (string.IsNullOrEmpty(workspace.Path))
		{
			_logger.Error("Cannot sync cloud workspace: Path is null for workspace " + workspace.Name);
			return false;
		}
		DateTimeOffset dateTimeOffset = workspace.LastModified ?? DateTimeOffset.Now;
		bool userConfirmed = false;
		string text = (workspace.WorkspaceSizeInBytes.HasValue ? ((long)workspace.WorkspaceSizeInBytes.Value).BytesToReadableSizeFormat() : "0B");
		_messageDialogService.ShowDialog(null, (DependencyObject)(object)new MessageContent
		{
			Heading = _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_DIALOG_description", new object[1] { workspace.Name }),
			Message = _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_DIALOG_subtext", new object[2]
			{
				dateTimeOffset.ToLocalTime().ToString("g", CultureInfo.CurrentCulture),
				text
			})
		}, new ButtonDescriptor[2]
		{
			new ButtonDescriptor(LocalizedStrings.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_DIALOG_DOWNLOAD_button"), IsDefault: true, IsCancel: false, delegate
			{
				userConfirmed = true;
			}),
			new ButtonDescriptor(LocalizedStrings.Get("GLOBAL_CANCEL_BUTTON_title"))
		}, null, null, canClose: true);
		if (!userConfirmed)
		{
			return false;
		}
		if (!workspace.WorkspaceSizeInBytes.HasValue || !workspace.CloudId.HasValue)
		{
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(_localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_title", new object[1] { workspace.Name }), _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_description"));
			_logger.Error("Cannot sync cloud workspace '" + workspace.Name + "': missing size or CloudId.");
			return false;
		}
		string pathRoot = Path.GetPathRoot(workspace.Path);
		if (string.IsNullOrEmpty(pathRoot))
		{
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(_localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_title", new object[1] { workspace.Name }), _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_description"));
			_logger.Error($"Cannot sync cloud workspace '{workspace.Name}': invalid path '{workspace.Path}'.");
			return false;
		}
		long availableFreeSpace = _fileSystem.DriveInfo.New(pathRoot).AvailableFreeSpace;
		if ((long)(workspace.WorkspaceSizeInBytes.Value + 4000000000u) > availableFreeSpace)
		{
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(_localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_title", new object[1] { workspace.Name }), _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_INSUFFICIENT_ERROR_description"));
			return false;
		}
		try
		{
			if (_cloudWorkspaceService != null)
			{
				RemoteWorkspaceDocuments remoteWorkspaceDocuments = await _cloudWorkspaceService.OpenRemoteAsync(workspace.CloudId.Value, workspace.Path);
				await _workspaceDocumentOrchestrator.CreateRemoteWorkspaceAsync(remoteWorkspaceDocuments, workspace.Path);
				workspace.WorkspaceType = ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Synced;
				return true;
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to sync cloud workspace remote: {value}");
			string message = _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_title", new object[1] { workspace.Name });
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(message, _localization.Get("CLOUDWORKSPACE_DOWNLOAD_WORKSPACE_ERROR_description"));
			return false;
		}
		return false;
	}

	private bool DoesWorkspaceNameExists(string workspaceName)
	{
		return _workspaceService.DoesWorkspaceNameExist(workspaceName);
	}

	private async Task DuplicateWorkspaceAsync(IWorkspaceItemVM workspace)
	{
		string title = _localization.Get("LOCALWORKSPACE_DUPLICATE_WORKSPACE_DIALOG_title");
		string defaultName = workspace.Name + " " + _localization.Get("GLOBAL_COPY_ACTION");
		IWorkspace newWorkspace = _workspaceService.Workspaces.Create(workspace.Name, _commonPathsWrapper.DefaultLocalWorkspaces, ProPresenter.DO.Workspaces.WorkspaceType.Local, null, null, null);
		if (!_manageWorkspacesWindowProvider.ShowDuplicateWorkspaceDialog(title, newWorkspace, DoesWorkspaceNameExists, defaultName))
		{
			return;
		}
		IProgress<double> progress;
		DuplicateWorkspaceProgressWindow progressWindow = _manageWorkspacesWindowProvider.ShowDuplicationProgressWindow(workspace, out progress);
		CancellationToken cancellationToken = progressWindow?.CancellationTokenSource.Token ?? CancellationToken.None;
		try
		{
			if ((await _fileService.CopyAllAsync(workspace.Path, newWorkspace.Path, overwrite: true, progress, cancellationToken)).Successful)
			{
				await Task.Run(delegate
				{
					RegeneratePresentationIds(newWorkspace.Path);
				}, cancellationToken);
				_workspaceService.Workspaces.Add(newWorkspace, makeActive: false);
			}
		}
		catch (OperationCanceledException)
		{
			_logger.Error("Duplicate operation canceled by the user.");
			_fileService.DeleteDirectory(newWorkspace.Path);
		}
		catch (Exception value)
		{
			_logger.Error($"An error occurred while duplicating the workspace: {value}");
		}
		finally
		{
			progressWindow?.Close();
		}
	}

	private void RegeneratePresentationIds(string workspacePath)
	{
		string[] files = _fileSystem.Directory.GetFiles(workspacePath, "*.pro", SearchOption.AllDirectories);
		foreach (string text in files)
		{
			if (!ProtoHelper.TryReadFile<Pro.SerializationInterop.RVProtoData.Presentation>(text, out Pro.SerializationInterop.RVProtoData.Presentation data) || data == null)
			{
				_logger.Warning("Failed to read presentation for ID regeneration: " + text);
				continue;
			}
			data.Uuid = Guid.NewGuid().ToUUID();
			ProtoHelper.WriteFile(text, data);
		}
	}

	private void ImportFolderToWorkspace()
	{
		if (!_fileSelectorService.SelectFolderPath(out string selectedPath))
		{
			return;
		}
		if (_workspaceService.DoesWorkspacePathExist(selectedPath))
		{
			_manageWorkspacesWindowProvider.ShowWorkspaceAlreadyExistsMessage();
			return;
		}
		string title = _localization.Get("LOCALWORKSPACE_IMPORT_LEGACY_FOLDER_DIALOG_title");
		string fileName = _fileSystem.Path.GetFileName(selectedPath);
		IWorkspace workspace = _workspaceService.Workspaces.Create(fileName, selectedPath, ProPresenter.DO.Workspaces.WorkspaceType.Local, null, null, null);
		if (_manageWorkspacesWindowProvider.ShowImportWorkspaceDialog(title, workspace, DoesWorkspaceNameExists, fileName))
		{
			if (string.Compare(fileName, workspace.Name, StringComparison.OrdinalIgnoreCase) != 0)
			{
				string fileName2 = _fileSystem.Path.GetFileName(workspace.Path.TrimEnd(_fileSystem.Path.DirectorySeparatorChar, _fileSystem.Path.AltDirectorySeparatorChar));
				_fileService.RenameFolder(selectedPath, fileName2);
			}
			_workspaceService.Workspaces.Add(workspace, makeActive: true);
			_changeWorkspaceHandler.ChangeWorkspace(workspace);
		}
	}

	private async Task<bool> MoveToRecycleBinWithRetryAsync(string path)
	{
		int attempt = 0;
		while (true)
		{
			if (await _fileUtility.MoveToRecycleBin(path))
			{
				return true;
			}
			if (attempt == 5)
			{
				break;
			}
			await Task.Delay(200 * (1 << attempt));
			attempt++;
		}
		return false;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			_cloudCollaboratorsSubscription?.Dispose();
			_userStateSubscription.Dispose();
		}
	}
}
