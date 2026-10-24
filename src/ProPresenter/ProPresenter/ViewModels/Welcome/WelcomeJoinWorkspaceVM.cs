using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Logging;
using Pro.Common.Strings;
using Pro.CoreApplication.Workspace;
using Pro.Localization;
using Pro.Localization.Services;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.ViewModels.Workspaces;
using ProPresenter.ViewModels.Settings.Pages.General;
using ProPresenter.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Welcome;

public sealed class WelcomeJoinWorkspaceVM : ObservableObject, IWelcomeJoinWorkspaceVM, INotifyPropertyChanged
{
	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly IWorkspaceDocumentOrchestrator _workspaceDocumentOrchestrator;

	private readonly IChangeWorkspaceHandler _changeWorkspaceHandler;

	private readonly Action _navigateToCreateWorkspace;

	private readonly Action _navigateToAdditionalResources;

	private readonly ILocalization _localization;

	private readonly ILogger _logger;

	private readonly IWorkspaceCollectionVM _workspaceCollectionVM;

	[ObservableProperty]
	private bool _isLoadingWorkspaces;

	[ObservableProperty]
	private IWorkspaceInfo? _selectedWorkspace;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? createNewWorkspaceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<IWorkspaceInfo>? joinSelectedWorkspaceCommand;

	public ObservableCollection<IWorkspaceInfo> Workspaces { get; } = new ObservableCollection<IWorkspaceInfo>();

	public bool HasWorkspaces => Workspaces.Count > 0;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingWorkspaces
	{
		get
		{
			return _isLoadingWorkspaces;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingWorkspaces, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsLoadingWorkspaces);
				_isLoadingWorkspaces = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsLoadingWorkspaces);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IWorkspaceInfo? SelectedWorkspace
	{
		get
		{
			return _selectedWorkspace;
		}
		set
		{
			if (!EqualityComparer<IWorkspaceInfo>.Default.Equals(_selectedWorkspace, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedWorkspace);
				_selectedWorkspace = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedWorkspace);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand CreateNewWorkspaceCommand => createNewWorkspaceCommand ?? (createNewWorkspaceCommand = new RelayCommand(CreateNewWorkspace));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<IWorkspaceInfo> JoinSelectedWorkspaceCommand => joinSelectedWorkspaceCommand ?? (joinSelectedWorkspaceCommand = new AsyncRelayCommand<IWorkspaceInfo>(JoinSelectedWorkspace));

	public WelcomeJoinWorkspaceVM(ICloudWorkspaceService cloudWorkspaceService, IWorkspaceDocumentOrchestrator workspaceDocumentOrchestrator, IChangeWorkspaceHandler changeWorkspaceHandler, Action navigateToCreateWorkspace, Action navigateToAdditionalResources, ILocalization localization, ILogger logger, IWorkspaceCollectionVM workspaceCollectionVM)
	{
		_cloudWorkspaceService = cloudWorkspaceService;
		_workspaceDocumentOrchestrator = workspaceDocumentOrchestrator;
		_changeWorkspaceHandler = changeWorkspaceHandler;
		_navigateToCreateWorkspace = navigateToCreateWorkspace;
		_navigateToAdditionalResources = navigateToAdditionalResources;
		_localization = localization;
		_logger = logger;
		_workspaceCollectionVM = workspaceCollectionVM;
	}

	public void Initialize()
	{
		LoadWorkspacesFromService();
	}

	[RelayCommand]
	public void CreateNewWorkspace()
	{
		_navigateToCreateWorkspace();
	}

	[RelayCommand]
	public async Task JoinSelectedWorkspace(IWorkspaceInfo workspace)
	{
		SelectedWorkspace = workspace;
		if (!Guid.TryParse(workspace.Id, out var cloudId))
		{
			_logger.Error("WelcomeJoinWorkspaceVM: Invalid CloudId for workspace '" + workspace.Name + "'");
			return;
		}
		if (!(_workspaceCollectionVM.Workspaces.FirstOrDefault((IWorkspaceItemVM w) => w.CloudId == cloudId) is IWorkspaceItemVMInternal workspaceItemVMInternal))
		{
			_logger.Error($"WelcomeJoinWorkspaceVM: Could not find workspace with CloudId '{cloudId}'");
			return;
		}
		IWorkspace targetWorkspace = workspaceItemVMInternal.Workspace;
		try
		{
			RemoteWorkspaceDocuments remoteWorkspaceDocuments = await _cloudWorkspaceService.OpenRemoteAsync(cloudId, targetWorkspace.Path);
			await _workspaceDocumentOrchestrator.CreateRemoteWorkspaceAsync(remoteWorkspaceDocuments, targetWorkspace.Path);
			targetWorkspace.WorkspaceType = ProPresenter.DO.Workspaces.WorkspaceType.Synced;
		}
		catch (Exception value)
		{
			_logger.Error($"WelcomeJoinWorkspaceVM: Failed to download workspace '{workspace.Name}': {value}");
			return;
		}
		targetWorkspace.Active = true;
		_changeWorkspaceHandler.ChangeWorkspace(targetWorkspace);
		_navigateToAdditionalResources();
	}

	private void LoadWorkspacesFromService()
	{
		IsLoadingWorkspaces = true;
		try
		{
			Workspaces.Clear();
			foreach (IWorkspaceItemVM item in _workspaceCollectionVM.Workspaces.Where((IWorkspaceItemVM w) => w.WorkspaceType == ProPresenter.UI.ViewModels.Workspaces.WorkspaceType.Cloud).ToList())
			{
				DateTime time = item.LastModified?.DateTime ?? DateTime.Now;
				CultureInfo cultureInfo = _localization.LoadedCulture;
				if (cultureInfo.IsNeutralCulture)
				{
					cultureInfo = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
				}
				string text = DateTimeFormatter.FormatDateTime(time, cultureInfo, FormatLength.Long, FormatLength.Short, use24HourMode: false);
				string text2 = (item.WorkspaceSizeInBytes.HasValue ? ((long)item.WorkspaceSizeInBytes.Value).BytesToReadableSizeFormat() : _localization.Get("COMMON_UNKNOWN_label"));
				string lastModified = _localization.Get("ONBOARDING_JOIN_WORKSPACE_LAST_MODIFICATION_label", new object[2] { text, text2 });
				Workspaces.Add(new WorkspaceInfo
				{
					Id = (item.CloudId?.ToString() ?? string.Empty),
					Name = item.Name,
					LastModified = lastModified,
					Size = text2
				});
			}
		}
		finally
		{
			OnPropertyChanged("HasWorkspaces");
			IsLoadingWorkspaces = false;
		}
	}
}
