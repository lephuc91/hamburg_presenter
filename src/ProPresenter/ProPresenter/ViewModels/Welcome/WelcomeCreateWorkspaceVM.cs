using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Localization.Services;
using ProPresenter.DO.CloudOnboarding;
using ProPresenter.DO.Web;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI.ViewModels.Welcome;
using ProPresenter.ViewModels.Settings.Pages.General;

namespace ProPresenter.ViewModels.Welcome;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public sealed class WelcomeCreateWorkspaceVM : ObservableObject, IWelcomeCreateWorkspaceVM, INotifyPropertyChanged, IDisposable
{
	private readonly ICloudOnboardingService _cloudOnboardingService;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	private readonly IWorkspaceService _workspaceService;

	private readonly ILocalization _localization;

	private readonly Action _navigateToScreenConfiguration;

	private readonly ILogger _logger;

	private readonly IWorkspaceDocumentOrchestrator _workspaceDocumentOrchestrator;

	private IDisposable? _userStateSubscription;

	private SynchronizationContext? _synchronizationContext;

	private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();

	private readonly IManageWorkspacesWindowProvider _manageWorkspacesWindowProvider;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsWorkspaceNameValid")]
	[NotifyPropertyChangedFor("CanCreateLocalWorkspace")]
	[NotifyPropertyChangedFor("CanCreateCloudWorkspace")]
	private string _workspaceName = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanCreateCloudWorkspace")]
	[NotifyPropertyChangedFor("CanCreateLocalWorkspace")]
	private bool _isCreatingWorkspace;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? openLearnMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? continueWithLocalCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? continueWithCloudCommand;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool IsWorkspaceNameValid
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(WorkspaceName))
			{
				return !ContainsInvalidCharacters(WorkspaceName);
			}
			return false;
		}
	}

	public bool CanCreateCloudWorkspace
	{
		get
		{
			if (IsWorkspaceNameValid && IsSignedIn && HasActiveSubscription && HasNetworkConnection)
			{
				return !IsCreatingWorkspace;
			}
			return false;
		}
	}

	public bool CanCreateLocalWorkspace
	{
		get
		{
			if (IsWorkspaceNameValid)
			{
				return !IsCreatingWorkspace;
			}
			return false;
		}
	}

	public bool HasActiveSubscription => _cloudOnboardingService.GetUserState() == OnboardingUserState.SignedInWithActiveSubscription;

	public bool HasNetworkConnection => _cloudOnboardingService.GetUserState() != OnboardingUserState.NoNetwork;

	public bool IsSignedIn => _cloudOnboardingService.GetUserState() != OnboardingUserState.SignedOut;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string WorkspaceName
	{
		get
		{
			return _workspaceName;
		}
		[MemberNotNull("_workspaceName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_workspaceName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.WorkspaceName);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsWorkspaceNameValid);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanCreateLocalWorkspace);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanCreateCloudWorkspace);
				_workspaceName = value;
				OnWorkspaceNameChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.WorkspaceName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsWorkspaceNameValid);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanCreateLocalWorkspace);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanCreateCloudWorkspace);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsCreatingWorkspace
	{
		get
		{
			return _isCreatingWorkspace;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isCreatingWorkspace, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsCreatingWorkspace);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanCreateCloudWorkspace);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanCreateLocalWorkspace);
				_isCreatingWorkspace = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsCreatingWorkspace);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanCreateCloudWorkspace);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanCreateLocalWorkspace);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand OpenLearnMoreCommand => openLearnMoreCommand ?? (openLearnMoreCommand = new RelayCommand(OpenLearnMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ContinueWithLocalCommand => continueWithLocalCommand ?? (continueWithLocalCommand = new RelayCommand(ContinueWithLocal));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ContinueWithCloudCommand => continueWithCloudCommand ?? (continueWithCloudCommand = new AsyncRelayCommand(ContinueWithCloud));

	public WelcomeCreateWorkspaceVM(ICloudOnboardingService cloudOnboardingService, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ILocalization localization, IWorkspaceService workspaceService, IWorkspaceDocumentOrchestrator workspaceDocumentOrchestrator, Action navigateToScreenConfiguration, IManageWorkspacesWindowProvider manageWorkspacesWindowProvider, ILogger logger)
	{
		_cloudOnboardingService = cloudOnboardingService;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		_workspaceService = workspaceService;
		_workspaceDocumentOrchestrator = workspaceDocumentOrchestrator;
		_navigateToScreenConfiguration = navigateToScreenConfiguration;
		_localization = localization;
		_manageWorkspacesWindowProvider = manageWorkspacesWindowProvider;
		_logger = logger;
		WorkspaceName = _localization.Get("CLOUDWORKSPACE_DEFAULT_WORKSPACE_name");
	}

	public void Initialize()
	{
		_synchronizationContext = SynchronizationContext.Current;
		WorkspaceName = _localization.Get("CLOUDWORKSPACE_DEFAULT_WORKSPACE_name");
		IsCreatingWorkspace = false;
		_userStateSubscription?.Dispose();
		_userStateSubscription = _cloudOnboardingService.WhenUserStateChanges.Subscribe(delegate(OnboardingUserState newState)
		{
			if (_synchronizationContext != null)
			{
				_synchronizationContext.Post(delegate
				{
					OnUserStateChanged(newState);
				}, null);
			}
			else
			{
				OnUserStateChanged(newState);
			}
		});
		OnPropertyChanged("HasActiveSubscription");
		OnPropertyChanged("HasNetworkConnection");
		OnPropertyChanged("IsSignedIn");
		OnPropertyChanged("CanCreateCloudWorkspace");
		OnPropertyChanged("CanCreateLocalWorkspace");
	}

	[RelayCommand]
	public void OpenLearnMore()
	{
		_hyperlinkService.Open(_webSourceProvider.DiscoverCloud);
	}

	[RelayCommand]
	private void ContinueWithLocal()
	{
		if (!IsWorkspaceNameValid || IsCreatingWorkspace)
		{
			return;
		}
		IsCreatingWorkspace = true;
		try
		{
			IWorkspace workspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
			if (workspace != null)
			{
				string newName = SanitizeWorkspaceName(WorkspaceName);
				_workspaceService.Workspaces.RenameWorkspace(workspace.Name, newName, workspace.Path);
			}
		}
		catch (Exception value)
		{
			_logger.Error($"Error occurred with continuing with local: {value}");
		}
		finally
		{
			IsCreatingWorkspace = false;
			_navigateToScreenConfiguration();
		}
	}

	[RelayCommand]
	public async Task ContinueWithCloud()
	{
		if (!IsWorkspaceNameValid || !CanCreateCloudWorkspace || IsCreatingWorkspace)
		{
			return;
		}
		IsCreatingWorkspace = true;
		string sanitizedName = string.Empty;
		try
		{
			sanitizedName = SanitizeWorkspaceName(WorkspaceName);
			IWorkspace activeWorkspace = _workspaceService.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
			if (activeWorkspace != null && !string.Equals(activeWorkspace.Name, sanitizedName, StringComparison.Ordinal))
			{
				_logger.Info($"Renaming workspace from '{activeWorkspace.Name}' to '{sanitizedName}' before cloud conversion");
				_workspaceService.Workspaces.RenameWorkspace(activeWorkspace.Name, sanitizedName, activeWorkspace.Path);
				try
				{
					await _workspaceDocumentOrchestrator.SendWorkspaceDocumentsToCoreAsync(activeWorkspace);
					_logger.Info("Sent workspace documents to core after rename");
				}
				catch (Exception value)
				{
					_logger.Warning($"Failed to send workspace documents to core after rename: {value}");
				}
			}
			Guid? guid = await _cloudOnboardingService.ConvertToCloudAsync(WorkspaceIssueFlags.None);
			if (!guid.HasValue)
			{
				throw new InvalidOperationException("Failed to convert workspace to cloud");
			}
			_logger.Info($"Successfully published workspace to cloud with ID: {guid.Value}");
			if (activeWorkspace != null)
			{
				activeWorkspace.WorkspaceType = WorkspaceType.Synced;
				activeWorkspace.CloudId = guid.Value;
				_logger.Info("Converted local workspace '" + activeWorkspace.Name + "' to synced cloud workspace");
			}
		}
		catch (Exception value2)
		{
			_logger.Error($"Failed to publish cloud workspace: {value2}");
			string message = _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_title", new object[1] { sanitizedName });
			_manageWorkspacesWindowProvider.ShowWorkspaceErrorDialog(message, _localization.Get("CLOUDWORKSPACE_PUBLISH_WORKSPACE_ERROR_description"));
			return;
		}
		finally
		{
			IsCreatingWorkspace = false;
		}
		_navigateToScreenConfiguration();
	}

	private void OnUserStateChanged(OnboardingUserState newState)
	{
		OnPropertyChanged("HasActiveSubscription");
		OnPropertyChanged("HasNetworkConnection");
		OnPropertyChanged("IsSignedIn");
		OnPropertyChanged("CanCreateCloudWorkspace");
		OnPropertyChanged("CanCreateLocalWorkspace");
	}

	private static bool ContainsInvalidCharacters(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		return text.Any((char c) => InvalidFileNameChars.Contains(c));
	}

	private static string SanitizeWorkspaceName(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return name;
		}
		return new string(name.Where((char c) => !InvalidFileNameChars.Contains(c)).ToArray()).Trim();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnWorkspaceNameChanged(string value)
	{
		string text = SanitizeWorkspaceName(value);
		if (text != value)
		{
			WorkspaceName = text;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_userStateSubscription?.Dispose();
	}
}
