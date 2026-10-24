using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using Pro.Web.Cookies;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Import;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.QuickSearch;

public class SongSelectSearchService : LinkedNotifyPropertyChangedBase, ISongSelectSearchService, INotifyPropertyChanged
{
	private readonly IPresentationVM _presentationVM;

	private readonly IPCOLiveVM _pcoLiveVM;

	private readonly ISongSelectConsumer _consumer;

	private readonly DispatcherTimer _searchTimer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(0.5)
	};

	private readonly ObservableCollection<SongSelectSearchResult> _items = new ObservableCollection<SongSelectSearchResult>();

	private readonly ICookieManagerService _cookieManagerService;

	private readonly IImportProcessFactory _importProcessFactory;

	private string _searchText = string.Empty;

	private Action? _callback;

	public IEnumerable<ISongSelectSearchResult> Items => _items;

	public bool IsAuthorized => _consumer.IsAuthorized;

	public SongSelectSearchService(IPresentationVM presentationVM, IPCOLiveVM pcoLiveVM, ISongSelectConsumer songSelectConsumer, ICookieManagerService cookieManagerService, IImportProcessFactory importProcessFactory)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_presentationVM = presentationVM;
		_pcoLiveVM = pcoLiveVM;
		_consumer = songSelectConsumer;
		_cookieManagerService = cookieManagerService;
		_importProcessFactory = importProcessFactory;
		_searchTimer.Tick += delegate
		{
			ExecuteSearch();
		};
		LinkProperties("IsAuthorized", "IsAuthorized");
		_consumer.PropertyChanged += base.RaiseLinkedValues;
		_items.CollectionChanged += delegate
		{
			OnPropertyChanged("Items");
		};
	}

	public void Search(string searchText, Action completedCallback)
	{
		_searchText = searchText;
		_callback = completedCallback;
		_items.Clear();
		if (!string.IsNullOrWhiteSpace(searchText))
		{
			RestartTimer();
		}
	}

	private void ExecuteSearch()
	{
		_searchTimer.Stop();
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		_consumer.SearchAsync(_searchText, 0, 100).ContinueWith(delegate(Task<SongSelectSearchResults> searchTask)
		{
			SongSelectSearchResults result = searchTask.Result;
			dispatcher.Invoke((Action)delegate
			{
				_items.AddRange(result.Items);
				_callback?.Invoke();
			});
		}).ExecuteAsync();
	}

	internal void ToggleAuthorization()
	{
		if (_consumer.IsAuthorized)
		{
			_consumer.Deauthorize();
		}
		else
		{
			CheckAvailability();
		}
	}

	public void CheckAvailability()
	{
		CheckAvailabilityAsync().ExecuteAsync();
	}

	private async Task CheckAvailabilityAsync()
	{
		if (_consumer.IsAuthorized)
		{
			return;
		}
		Window mainWindow = Application.Current.MainWindow;
		if (mainWindow == null || !mainWindow.IsVisible)
		{
			return;
		}
		if (InternetAccessCheck.IsInternetAvailable())
		{
			LoginDialog loginDialog = new LoginDialog(CommonPaths.WebCache, _cookieManagerService, CookieSession.SongSelect, _consumer.GetLoginUrl(), _consumer.IsAuthorizationCallback)
			{
				Title = LocalizedStrings.Get("PRESENTATION_QUICK_SEARCH_SONGSELECT_LOGIN_title"),
				CacheSession = _consumer.SessionId,
				Height = 500.0,
				Owner = mainWindow,
				CanContinueBrowseUrl = (string url) => !url.Contains("oauth_token_status=revoked")
			};
			loginDialog.ShowDialog();
			await _consumer.CompleteAuthorizationWithUrlAsync(loginDialog.FinalLoginUrl);
			await ((mainWindow != null) ? ((DispatcherObject)mainWindow).Dispatcher.InvokeAsync<bool>((Func<bool>)mainWindow.Focus) : null);
		}
		else
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"));
		}
	}

	private void RestartTimer()
	{
		_searchTimer.Stop();
		_searchTimer.Start();
	}

	public void Import(ISongSelectSearchResult selectedItem)
	{
		_consumer.Import(_importProcessFactory, (SongSelectSearchResult)selectedItem);
	}

	public void ImportAndLinkToItem(ProPresenterCue target, ISongSelectSearchResult selectedItem)
	{
		_consumer.Import(_importProcessFactory, (SongSelectSearchResult)selectedItem, delegate(string filename, IImportProcess process)
		{
			if (target is PlaceholderCue placeholderCue)
			{
				_presentationVM.LinkImportedFile(placeholderCue, filename, process, PlaceholderLinkSource.QuickSearch);
			}
			else if (target is PCOCueBase pcoCue)
			{
				_pcoLiveVM.LinkImportedFile(pcoCue, filename, process, PlaceholderLinkSource.QuickSearch, null);
			}
		});
	}
}
