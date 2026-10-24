using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.CoreApplication.Workspace;
using ProPresenter.DO.Analytics.Events.Welcome;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.UI.ViewModels.Workspaces;

namespace ProPresenter.ViewModels.Welcome;

public class AdditionalResourcesVM : ObservableObject, IAdditionalResourcesVM
{
	private readonly IWelcomeAnalyticEventsPublisher _analytics;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly ICloudWorkspaceService _cloudWorkspaceService;

	private readonly IWorkspaceCollectionVM _workspaceCollectionVM;

	private readonly ILogger _logger;

	[ObservableProperty]
	private bool _isDownloadingWorkspace;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? tutorialsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? userGroupCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? knowledgeBaseCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? blogCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsDownloadingWorkspace
	{
		get
		{
			return _isDownloadingWorkspace;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isDownloadingWorkspace, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsDownloadingWorkspace);
				_isDownloadingWorkspace = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsDownloadingWorkspace);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand TutorialsCommand => tutorialsCommand ?? (tutorialsCommand = new RelayCommand(Tutorials));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand UserGroupCommand => userGroupCommand ?? (userGroupCommand = new RelayCommand(UserGroup));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand KnowledgeBaseCommand => knowledgeBaseCommand ?? (knowledgeBaseCommand = new RelayCommand(KnowledgeBase));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BlogCommand => blogCommand ?? (blogCommand = new RelayCommand(Blog));

	public AdditionalResourcesVM(IWelcomeAnalyticEventsPublisher analytics, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ICloudWorkspaceService cloudWorkspaceService, IWorkspaceCollectionVM workspaceCollectionVM, ILogger logger)
	{
		_analytics = analytics;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_cloudWorkspaceService = cloudWorkspaceService;
		_workspaceCollectionVM = workspaceCollectionVM;
		_logger = logger;
	}

	[RelayCommand]
	private void Tutorials()
	{
		GotoLink(_webSourceProvider.Tutorials, _analytics.TutorialsViewedEvent);
	}

	[RelayCommand]
	private void UserGroup()
	{
		GotoLink(_webSourceProvider.UserGroup, _analytics.UserGroupViewed);
	}

	[RelayCommand]
	private void KnowledgeBase()
	{
		GotoLink(_webSourceProvider.KnowledgeBase, _analytics.KnowledgeBaseViewedEvent);
	}

	[RelayCommand]
	private void Blog()
	{
		GotoLink(_webSourceProvider.Blog, _analytics.BlogViewedEvent);
	}

	public async Task DownloadWorkspaceAsync(IWorkspaceInfo workspaceInfo)
	{
		if (IsDownloadingWorkspace)
		{
			return;
		}
		IsDownloadingWorkspace = true;
		try
		{
			IWorkspaceItemVM workspaceItemVM = _workspaceCollectionVM.Workspaces.FirstOrDefault((IWorkspaceItemVM w) => w.CloudId?.ToString() == workspaceInfo.Id);
			if (workspaceItemVM != null)
			{
				workspaceItemVM.Active = true;
				if (Guid.TryParse(workspaceInfo.Id, out var result))
				{
					await _cloudWorkspaceService.OpenRemoteAsync(result, workspaceItemVM.Path);
				}
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Failed to download workspace from server. {value}");
		}
		finally
		{
			IsDownloadingWorkspace = false;
		}
	}

	private void GotoLink(Uri link, Action analytics)
	{
		analytics();
		_hyperlinkService.Open(link);
	}
}
