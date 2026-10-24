using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Localization.Services;
using Pro.UI.Commands;
using Pro.UI.Themes;
using ProPresenter.DO.Analytics.Events.ProContent;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;
using ProPresenter.ViewModels.ProContent.Asset;
using ProPresenter.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent;

public class ProContentVM : ObservableObject, IInternalProContentVM, IProContentVM, INotifyPropertyChanged, INavigationItem
{
	private readonly IProContentVMsFactory _factory;

	private readonly IProContentProvider _provider;

	private readonly ILocalization _localization;

	private readonly IProContentAnalyticEventsPublisher _analyticEvents;

	private readonly IApp _app;

	private readonly PairedCollection<IProContentGroup, IProContentGroupVM> _groups;

	private readonly IPeriodicTimer _refreshRootElementsTimer;

	private bool _ignoreCollectionChanged;

	[ObservableProperty]
	private IProContentGroupVM? _selectedRootElement;

	[ObservableProperty]
	[NotifyPropertyChangedFor("Collections")]
	private IProContentGroupVM? _currentGroup;

	[ObservableProperty]
	private bool _isLoadingData;

	[ObservableProperty]
	private bool _focusSearchBox;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<IProContentAssetVM>? selectAssetCommand;

	public INotifyEnumerableChanged<IProContentCollectionVM>? Collections => CurrentGroup?.Collection;

	public INotifyEnumerableChanged<IProContentGroupVM> Groups => _groups;

	public bool IsLoggedIn => _provider.IsAuthorized;

	public IRelayCommand BrowseMoreCommand { get; }

	public IAsyncRelayCommand ToggleLoginLogoutCommand => _provider.LoginLogoutCommand;

	public IAsyncRelayCommand ReloadCommand => _provider.ReloadDataCommand;

	public string ContactSupportUrl => _provider.ContactSupportUrl;

	public string ContactSupportLinkText => _provider.ContactSupportLinkText;

	public ConnectionState ConnectionState => Convert(_provider.ConnectionState);

	public string Name => _localization.Get("GLOBAL_PROCONTENT_NAME");

	public INavigationItem? Parent { get; private set; }

	public IEnumerable Children => Groups;

	public ImageSource? Icon => Icons.GetIcon(Icons.ProContent);

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IProContentGroupVM? SelectedRootElement
	{
		get
		{
			return _selectedRootElement;
		}
		set
		{
			if (!EqualityComparer<IProContentGroupVM>.Default.Equals(_selectedRootElement, value))
			{
				OnSelectedRootElementChanging(value);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedRootElement);
				_selectedRootElement = value;
				OnSelectedRootElementChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedRootElement);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IProContentGroupVM? CurrentGroup
	{
		get
		{
			return _currentGroup;
		}
		set
		{
			if (!EqualityComparer<IProContentGroupVM>.Default.Equals(_currentGroup, value))
			{
				IProContentGroupVM currentGroup = _currentGroup;
				OnCurrentGroupChanging(currentGroup, value);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CurrentGroup);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Collections);
				_currentGroup = value;
				OnCurrentGroupChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CurrentGroup);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Collections);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsLoadingData
	{
		get
		{
			return _isLoadingData;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isLoadingData, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsLoadingData);
				_isLoadingData = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsLoadingData);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool FocusSearchBox
	{
		get
		{
			return _focusSearchBox;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_focusSearchBox, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.FocusSearchBox);
				_focusSearchBox = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.FocusSearchBox);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<IProContentAssetVM> SelectAssetCommand => selectAssetCommand ?? (selectAssetCommand = new AsyncRelayCommand<IProContentAssetVM>(SelectAsset, CanSelectAsset, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	public ProContentVM(IProContentProvider provider, IProContentVMsFactory factory, ILocalization localization, IProContentAnalyticEventsPublisher analyticEvents, ITimerFactory timerFactory, IApp app)
	{
		ProContentVM proContentVM = this;
		_provider = provider;
		_factory = factory;
		_localization = localization;
		_analyticEvents = analyticEvents;
		_app = app;
		_refreshRootElementsTimer = timerFactory.CreatePeriodicDispatched(TimeSlice.FromMinutes(Math.Max(app.ProContentRefreshPolicyRefreshOutline, 1u)), delegate
		{
			provider.ReloadDataCommand.Execute(null);
		});
		_groups = new PairedCollection<IProContentGroup, IProContentGroupVM>(_provider.Groups, (IProContentGroup c) => proContentVM._factory.CreateGroup(c, proContentVM), delegate(IProContentGroupVM g)
		{
			g.Dispose();
		});
		BrowseMoreCommand = new ParameterAugmentingCommand<Uri>(_provider.BrowseMoreCommand, provider.DefaultBrowseMoreUri);
		provider.PropertyChanged += ProContentProviderPropertyChanged;
		provider.DataReloaded += Provider_DataReloaded;
	}

	public async Task NavigateAsync(IProContentGroupVM group)
	{
		IsLoadingData = true;
		if (FindRootGroup(group) is IProContentGroupVM selectedRootElement)
		{
			_ignoreCollectionChanged = true;
			SelectedRootElement = selectedRootElement;
			_ignoreCollectionChanged = false;
		}
		CurrentGroup = group;
		await _provider.RefreshAsync((group as IProContentGroupVMInternal)?.Group);
		IsLoadingData = false;
	}

	private void OnSelectedRootElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SearchInProgress" && sender is IProContentSearchGroupVM { SearchInProgress: false } proContentSearchGroupVM && CurrentGroup != proContentSearchGroupVM)
		{
			CurrentGroup = proContentSearchGroupVM;
		}
	}

	private void Provider_DataReloaded()
	{
		if (!string.IsNullOrEmpty(_app.SelectedProContentRootGroup))
		{
			IProContentGroupVM proContentGroupVM = _groups.FirstOrDefault((IProContentGroupVM g) => g is IProContentGroupVMInternal proContentGroupVMInternal && proContentGroupVMInternal.Group.Id == _app.SelectedProContentRootGroup);
			if (proContentGroupVM != null)
			{
				SelectedRootElement = proContentGroupVM;
			}
		}
	}

	private void ProContentProviderPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "IsAuthorized"))
		{
			if (propertyName == "ConnectionState")
			{
				OnPropertyChanged("ConnectionState");
				if (ConnectionState == ConnectionState.Connected)
				{
					_refreshRootElementsTimer.Start();
				}
				else
				{
					_refreshRootElementsTimer.Stop();
				}
			}
		}
		else
		{
			OnPropertyChanged("IsLoggedIn");
		}
	}

	private static ConnectionState Convert(ProContentConnectionState state)
	{
		return state switch
		{
			ProContentConnectionState.Connected => ConnectionState.Connected, 
			ProContentConnectionState.InternetUnavailable => ConnectionState.InternetUnavailable, 
			_ => ConnectionState.Error, 
		};
	}

	private void OnCurrentGroupPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SearchInProgress" && sender is IProContentSearchGroupVM proContentSearchGroupVM)
		{
			IsLoadingData = proContentSearchGroupVM.SearchInProgress;
		}
	}

	[RelayCommand(CanExecute = "CanSelectAsset", FlowExceptionsToTaskScheduler = true)]
	private async Task SelectAsset(IProContentAssetVM assetVM)
	{
		if (assetVM is IProContentAssetVMInternal proContentAssetVMInternal)
		{
			IsLoadingData = true;
			IProContentGroup proContentGroup = await _provider.NavigateAsync(proContentAssetVMInternal.Asset);
			if (proContentGroup != null)
			{
				CurrentGroup = _factory.CreateGroup(proContentGroup, assetVM.ContainingGroup);
			}
			IsLoadingData = false;
		}
	}

	private static bool CanSelectAsset(IProContentAssetVM asset)
	{
		return (asset as IProContentAssetVMInternal)?.Asset.IsNavigable ?? false;
	}

	private INavigationItem? FindRootGroup(INavigationItem? group)
	{
		if (group == null)
		{
			return null;
		}
		if (group.Parent == this)
		{
			return group;
		}
		return FindRootGroup(group.Parent);
	}

	private bool IsParent(INavigationItem? potentialChild, INavigationItem? potentialParent)
	{
		if (potentialChild == null || potentialParent == null)
		{
			return false;
		}
		if (potentialChild.Parent == potentialParent)
		{
			return true;
		}
		return IsParent(potentialChild.Parent, potentialParent);
	}

	public void SetParent(IMediaBinHeaderNavigatorVM headerNavigatorVM)
	{
		Parent = headerNavigatorVM;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedRootElementChanging(IProContentGroupVM? value)
	{
		if (value != null)
		{
			value.PropertyChanged -= OnSelectedRootElementPropertyChanged;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedRootElementChanged(IProContentGroupVM? value)
	{
		if (value != null)
		{
			value.PropertyChanged += OnSelectedRootElementPropertyChanged;
		}
		if (_ignoreCollectionChanged)
		{
			return;
		}
		CurrentGroup = value;
		if (value == null)
		{
			_app.SelectedProContentRootGroup = null;
			return;
		}
		if (value is IProContentGroupVMInternal proContentGroupVMInternal)
		{
			_app.SelectedProContentRootGroup = proContentGroupVMInternal.Group.Id;
		}
		_provider.RefreshAsync((value as IProContentGroupVMInternal).Group).ExecuteAsync();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentGroupChanging(IProContentGroupVM? oldValue, IProContentGroupVM? newValue)
	{
		if (oldValue is IProContentSearchGroupVM { SearchInProgress: not false })
		{
			IsLoadingData = false;
		}
		if (oldValue != null)
		{
			if (oldValue.Parent != this && !IsParent(oldValue, newValue))
			{
				oldValue.Dispose();
			}
			oldValue.PropertyChanged -= OnCurrentGroupPropertyChanged;
		}
		if (oldValue == null && newValue != null)
		{
			_analyticEvents?.ViewMediaBin();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnCurrentGroupChanged(IProContentGroupVM? value)
	{
		if (value != null)
		{
			value.PropertyChanged += OnCurrentGroupPropertyChanged;
		}
	}
}
