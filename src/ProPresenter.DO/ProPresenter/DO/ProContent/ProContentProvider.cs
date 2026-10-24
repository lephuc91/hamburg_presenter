using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Cache.AsyncCache;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Internet;
using ProPresenter.DO.ProContent.Consumer;
using ProPresenter.DO.ProContent.Consumer.Model.Content;
using ProPresenter.DO.ProContent.Consumer.Model.Result;
using ProPresenter.DO.ProContent.Downloads;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Format;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.ProContent;

public class ProContentProvider : ObservableObject, IProContentProvider, INotifyPropertyChanged
{
	private const string API_THEMES_PATH = "/themes";

	private const string API_BROWSE_MORE_DEFAULT_PATH = "/search";

	private const string API_SIGN_UP_PATH = "/signup";

	private const string API_MANAGE_USER_ACCOUNT_PATH = "/manage_account";

	private const string API_HOME_PAGE_PATH = "/homepage";

	private const string SUPPORT_URL = "https://support.renewedvision.com";

	private const string SUPPORT_HYPERLINK_TEXT = "support.renewedvision.com";

	private const int GROUP_CACHE_CAPACITY = 50;

	private const int GROUP_SEARCH_CACHE_CAPACITY = 10;

	private readonly IProContentConsumer _consumer;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IProContentUserInteractionBehavior _userInteractionBehavior;

	private readonly ProContentSearchGroup _proContentSearchGroup = new ProContentSearchGroup();

	private readonly ProContentGroupCollection _groups = new ProContentGroupCollection();

	private readonly IAsyncCache<string, Group?> _groupCache;

	private readonly IAsyncCache<string, Group?> _searchGroupCache;

	private readonly ConcurrentDictionary<IInternalProContentGroup, CancellationTokenSource> _refreshCancellationTokens = new ConcurrentDictionary<IInternalProContentGroup, CancellationTokenSource>();

	[ObservableProperty]
	private ProContentConnectionState _connectionState;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? loginLogoutCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? reloadDataCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<Uri?>? browseMoreCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? browseThemesCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? browseHomepageCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? browseSignUpCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? browseManageUserAccountCommand;

	public bool IsAuthorized => _consumer.IsAuthorized;

	public string ContactSupportLinkText => "support.renewedvision.com";

	public Uri DefaultBrowseMoreUri => new Uri(_consumer.ProContentApiBaseUrl + "/search");

	public INotifyEnumerableChanged<IProContentGroup> Groups => _groups;

	public string BrowseHomepageCommandText => _consumer.ProContentHomePageText;

	public string ContactSupportUrl => "https://support.renewedvision.com";

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ProContentConnectionState ConnectionState
	{
		get
		{
			return _connectionState;
		}
		set
		{
			if (!EqualityComparer<ProContentConnectionState>.Default.Equals(_connectionState, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ConnectionState);
				_connectionState = value;
				OnConnectionStateChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ConnectionState);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand LoginLogoutCommand => loginLogoutCommand ?? (loginLogoutCommand = new AsyncRelayCommand(LoginLogout, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand ReloadDataCommand => reloadDataCommand ?? (reloadDataCommand = new AsyncRelayCommand(ReloadData, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<Uri?> BrowseMoreCommand => browseMoreCommand ?? (browseMoreCommand = new RelayCommand<Uri>(BrowseMore, CanBrowseMore));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BrowseThemesCommand => browseThemesCommand ?? (browseThemesCommand = new RelayCommand(BrowseThemes));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BrowseHomepageCommand => browseHomepageCommand ?? (browseHomepageCommand = new RelayCommand(BrowseHomepage));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BrowseSignUpCommand => browseSignUpCommand ?? (browseSignUpCommand = new RelayCommand(BrowseSignUp));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand BrowseManageUserAccountCommand => browseManageUserAccountCommand ?? (browseManageUserAccountCommand = new RelayCommand(BrowseManageUserAccount));

	public event Action? DataReloaded;

	public ProContentProvider(IProContentConsumer consumer, IInternetAccessCheck internetAccessCheck, IHyperlinkService hyperlinkService, ICacheFactory cacheFactory, IApp app, IProContentDownloadProcessFactory processFactory, IUiDispatcher uiDispatcher, IProContentUserInteractionBehavior userInteractionBehavior)
	{
		consumer.PropertyChanged += LinkedNotifyPropertyChanged;
		_consumer = consumer;
		_hyperlinkService = hyperlinkService;
		_uiDispatcher = uiDispatcher;
		_userInteractionBehavior = userInteractionBehavior;
		_groupCache = cacheFactory.CreateAsyncCache<string, Group>(50, TimeSpan.FromMinutes(Math.Max(app.ProContentCachingPolicyGroupTimeToLive, 1u)));
		_searchGroupCache = cacheFactory.CreateAsyncCache<string, Group>(10, TimeSpan.FromMinutes(Math.Max(app.ProContentCachingPolicyGroupTimeToLive, 1u)));
		internetAccessCheck.WhenIsAvailableChanged.Subscribe(InternetAccessStateChanged);
	}

	private void LinkedNotifyPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsAuthorized")
		{
			OnPropertyChanged("IsAuthorized");
		}
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private Task LoginLogout()
	{
		return _userInteractionBehavior.LoginLogoutAsync();
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task ReloadData(CancellationToken token)
	{
		ProPresenter.DO.ProContent.Consumer.Model.Result.IRequestResult requestResult = await _consumer.GetRootGroupsAsync(token);
		if (!(requestResult is ErrorResult) && !(requestResult is RedirectResult))
		{
			if (requestResult is SuccessResult<Groups> { Data: { } data })
			{
				ConnectionState = ProContentConnectionState.Connected;
				UpdateRootGroups(data.Items);
				this.DataReloaded?.Invoke();
			}
		}
		else
		{
			SetConnectionError();
		}
	}

	[RelayCommand(CanExecute = "CanBrowseMore")]
	private void BrowseMore(Uri? contentUri)
	{
		_hyperlinkService.Open(contentUri ?? new Uri(_consumer.ProContentApiBaseUrl + "/homepage"));
	}

	private static bool CanBrowseMore(Uri contentUri)
	{
		return contentUri?.IsAbsoluteUri ?? false;
	}

	[RelayCommand]
	private void BrowseThemes()
	{
		_hyperlinkService.Open(new Uri(_consumer.ProContentApiBaseUrl + "/themes"));
	}

	[RelayCommand]
	private void BrowseHomepage()
	{
		_hyperlinkService.Open(new Uri(_consumer.ProContentApiBaseUrl + "/homepage"));
	}

	[RelayCommand]
	private void BrowseSignUp()
	{
		_hyperlinkService.Open(new Uri(_consumer.ProContentApiBaseUrl + "/signup"));
	}

	[RelayCommand]
	private void BrowseManageUserAccount()
	{
		_hyperlinkService.Open(new Uri(_consumer.ProContentApiBaseUrl + "/manage_account"));
	}

	public async Task<IProContentGroup?> NavigateAsync(IProContentAsset? asset)
	{
		if (asset != null && asset.IsNavigable)
		{
			IProContentGroup matchingRootGroup = Groups.FirstOrDefault((IProContentGroup group) => group.Id == asset.Id);
			if (matchingRootGroup != null)
			{
				await RefreshAsync(matchingRootGroup);
				return matchingRootGroup;
			}
			return await LoadGroupAsync(asset.Id);
		}
		return null;
	}

	public async Task RefreshAsync(IProContentGroup? group)
	{
		if (!(group is IInternalProContentGroup internalGroup))
		{
			return;
		}
		CancellationTokenSource cancellationSource = new CancellationTokenSource();
		_refreshCancellationTokens.AddOrUpdate(internalGroup, cancellationSource, delegate(IInternalProContentGroup _, CancellationTokenSource previousCancellationSource)
		{
			previousCancellationSource.Cancel();
			return cancellationSource;
		});
		try
		{
			if (group is IInternalProContentSearchGroup internalSearchGroup)
			{
				internalSearchGroup.SearchInProgress = true;
				await RefreshSearchGroupAsync(internalSearchGroup, cancellationSource.Token);
				internalSearchGroup.SearchInProgress = false;
			}
			else
			{
				await RefreshStandardGroupAsync(internalGroup, cancellationSource.Token);
			}
			_refreshCancellationTokens.TryRemove(internalGroup, out CancellationTokenSource _);
		}
		catch (OperationCanceledException)
		{
		}
	}

	private async Task RefreshSearchGroupAsync(IInternalProContentSearchGroup internalSearchGroup, CancellationToken cancellationToken)
	{
		Group group = await GetSearchGroupAsync(internalSearchGroup.SearchTerm, cancellationToken);
		if (!(group != null))
		{
			return;
		}
		internalSearchGroup.DisplayName = group.DisplayName;
		internalSearchGroup.Clear();
		foreach (Collection item in group.Collections.Where((Collection c) => c.Assets.Any()))
		{
			internalSearchGroup.Add(Convert(item));
		}
	}

	private async Task RefreshStandardGroupAsync(IInternalProContentGroup internalGroup, CancellationToken cancellationToken)
	{
		Group group = await GetConsumerGroupAsync(internalGroup.Id, cancellationToken);
		if (group != null)
		{
			internalGroup.Icon = group.Icon;
			internalGroup.DisplayName = group.DisplayName;
			internalGroup.Clear();
			Collection[] collections = group.Collections;
			foreach (Collection receivedCollection in collections)
			{
				internalGroup.Add(Convert(receivedCollection));
			}
		}
	}

	private async Task<IProContentGroup?> LoadGroupAsync(string id)
	{
		Group group = await GetConsumerGroupAsync(id);
		return ((object)group == null) ? null : Convert(group);
	}

	private async Task<Group?> GetConsumerGroupAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _groupCache.GetOrAddAsync(id, (string id) => FinishGroupDownloadAsync(_consumer.GetGroupAsync(id, cancellationToken)));
	}

	private async Task<Group?> GetSearchGroupAsync(string searchTerm, CancellationToken cancellationToken = default(CancellationToken))
	{
		return await _searchGroupCache.GetOrAddAsync(searchTerm, (string searchTerm) => FinishGroupDownloadAsync(_consumer.GetSearchResultAsync(searchTerm, cancellationToken)));
	}

	private async Task<Group?> FinishGroupDownloadAsync(Task<ProPresenter.DO.ProContent.Consumer.Model.Result.IRequestResult> requestTask)
	{
		ProPresenter.DO.ProContent.Consumer.Model.Result.IRequestResult requestResult = await requestTask;
		if (!(requestResult is CancelledResult))
		{
			if (!(requestResult is ErrorResult) && !(requestResult is RedirectResult))
			{
				if (requestResult is SuccessResult<Group> successResult)
				{
					Group data = successResult.Data;
					ConnectionState = ProContentConnectionState.Connected;
					return data;
				}
			}
			else
			{
				SetConnectionError();
			}
			return null;
		}
		return null;
	}

	private void InternetAccessStateChanged(bool state)
	{
		if (state)
		{
			ConnectionState = ProContentConnectionState.Connected;
			_uiDispatcher.Invoke(delegate
			{
				ReloadDataCommand.Execute(null);
			});
		}
		else
		{
			ConnectionState = ProContentConnectionState.InternetUnavailable;
		}
	}

	private void SetConnectionError()
	{
		if (ConnectionState != 0)
		{
			ConnectionState = ProContentConnectionState.Error;
		}
	}

	private static IProContentGroup Convert(Group receivedGroup)
	{
		ProContentGroup proContentGroup = new ProContentGroup(receivedGroup.DisplayName, receivedGroup.Icon, receivedGroup.Id);
		Collection[] collections = receivedGroup.Collections;
		foreach (Collection receivedCollection in collections)
		{
			proContentGroup.Add(Convert(receivedCollection));
		}
		return proContentGroup;
	}

	private static IProContentCollection Convert(Collection receivedCollection)
	{
		ProContentCollection proContentCollection = (receivedCollection.IsDownloadable ? new ProContentDownloadableCollection(receivedCollection.Id, receivedCollection.DisplayName, receivedCollection.Description, receivedCollection.Formats.Select(Convert).ToArray(), receivedCollection.ExternalUrl, Convert(receivedCollection.LayoutType)) : new ProContentCollection(receivedCollection.Id, receivedCollection.DisplayName, receivedCollection.Description, receivedCollection.ExternalUrl, Convert(receivedCollection.LayoutType)));
		Asset[] assets = receivedCollection.Assets;
		for (int i = 0; i < assets.Length; i++)
		{
			IProContentAsset proContentAsset = Convert(assets[i]);
			if (proContentAsset != null)
			{
				proContentCollection.Add(proContentAsset);
			}
		}
		return proContentCollection;
	}

	private static IProContentFormat Convert(Format format)
	{
		return new ProContentFormat(format.Id, format.Name, format.Width, format.Height, format.Framerate, format.Interlaced);
	}

	private static ProContentCollectionLayoutType Convert(CollectionLayoutType layoutType)
	{
		return layoutType switch
		{
			CollectionLayoutType.CarouselLarge => ProContentCollectionLayoutType.CarouselLarge, 
			CollectionLayoutType.Grid => ProContentCollectionLayoutType.Grid, 
			_ => ProContentCollectionLayoutType.CarouselSmall, 
		};
	}

	private static IProContentAsset? Convert(Asset asset)
	{
		if (!(asset is Video video))
		{
			if (!(asset is Image image))
			{
				if (!(asset is Pack pack))
				{
					if (asset is Navigation navigation)
					{
						return new ProContentNavigationAsset(navigation.Id, navigation.DisplayName, navigation.ThumbnailUrl, navigation.PreviewUrl);
					}
					return null;
				}
				return new ProContentPackAsset(pack.Id, pack.DisplayName, pack.ThumbnailUrl, pack.PreviewUrl, pack.IsNavigatable, pack.SubscriptionType.ToModelSubscriptionType(), pack.Formats.Select(Convert).ToArray(), pack.LoopCount, pack.ImageCount, pack.CountdownCount);
			}
			return new ProContentFileAsset(image.Id, image.DisplayName, image.ThumbnailUrl, image.PreviewUrl, image.IsNavigatable, image.SubscriptionType.ToModelSubscriptionType(), image.Formats.Select(Convert).ToArray());
		}
		return new ProContentFileAsset(video.Id, video.DisplayName, video.ThumbnailUrl, video.PreviewUrl, video.IsNavigatable, video.SubscriptionType.ToModelSubscriptionType(), video.Formats.Select(Convert).ToArray());
	}

	private void UpdateRootGroups(ICollection<Group> newGroups)
	{
		IEnumerator<Group> enumerator = newGroups.GetEnumerator();
		IEnumerator<IProContentGroup> enumerator2 = _groups.GetEnumerator();
		Collection<IProContentGroup> collection = new Collection<IProContentGroup>();
		while (enumerator2.MoveNext())
		{
			IProContentGroup oldGroup = enumerator2.Current;
			if (!newGroups.Any((Group newGroup) => oldGroup.Id == newGroup.Id))
			{
				collection.Add(oldGroup);
			}
		}
		foreach (IProContentGroup item in collection)
		{
			_groups.Remove(item);
		}
		if (!_groups.Contains(_proContentSearchGroup))
		{
			_groups.Add(_proContentSearchGroup);
		}
		int num = 1;
		while (enumerator.MoveNext())
		{
			Group newGroup2 = enumerator.Current;
			_groupCache.AddOrUpdate(newGroup2.Id, newGroup2);
			(IInternalProContentGroup, int) tuple = _groups.Select((IProContentGroup group, int index) => (group: group as IInternalProContentGroup, index: index)).FirstOrDefault(((IInternalProContentGroup group, int index) oldGroupAndIndex) => oldGroupAndIndex.group?.Id == newGroup2.Id);
			if (tuple.Item1 == null)
			{
				_groups.Insert(num, Convert(newGroup2));
			}
			else
			{
				_groups.Move(tuple.Item2, num);
				UpdateGroup(tuple.Item1, newGroup2);
			}
			num++;
		}
	}

	private static void UpdateGroup(IInternalProContentGroup input, Group newInfo)
	{
		if (input != null)
		{
			input.Icon = newInfo.Icon;
			input.DisplayName = newInfo.DisplayName;
			input.Clear();
			Collection[] collections = newInfo.Collections;
			foreach (Collection receivedCollection in collections)
			{
				input.Add(Convert(receivedCollection));
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnConnectionStateChanged(ProContentConnectionState value)
	{
		if (value != ProContentConnectionState.Connected)
		{
			_groups.Clear();
		}
	}
}
