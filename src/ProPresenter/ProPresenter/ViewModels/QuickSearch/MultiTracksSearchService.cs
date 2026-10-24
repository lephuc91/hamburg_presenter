using System;
using System.Windows;
using System.Windows.Threading;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using Pro.Web.Cookies;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Import;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.QuickSearch;

public class MultiTracksSearchService : IMultiTracksSearchService
{
	public const string CacheSessionID = "multitracks";

	private readonly IMultiTracksConsumer _consumer;

	private readonly IPresentationVM _presentationVM;

	private readonly IPCOLiveVM _pcoLiveVM;

	private readonly IMultiTracksImportDialogVM _importMultiTracksVM;

	private readonly ICookieManagerService _cookieManagerService;

	private readonly IApp _app;

	private readonly IImportProcessFactory _importProcessFactory;

	public bool IsAuthorized => _consumer.IsAuthorized;

	public IMultiTracksConsumer Consumer => _consumer;

	public event Action? RefreshSearchResults;

	public MultiTracksSearchService(IMultiTracksConsumer consumer, IPresentationVM presentationVM, IPCOLiveVM pcoLiveVM, IMultiTracksImportDialogVM importMultiTracksVM, ICookieManagerService cookieManagerService, IApp app, IImportProcessFactory importProcessFactory)
	{
		_consumer = consumer;
		_presentationVM = presentationVM;
		_presentationVM.MultiTracksSearchService = this;
		_pcoLiveVM = pcoLiveVM;
		_importMultiTracksVM = importMultiTracksVM;
		_cookieManagerService = cookieManagerService;
		_app = app;
		_importProcessFactory = importProcessFactory;
		_consumer.SubscriptionAuthorizationUpdated += delegate
		{
			this.RefreshSearchResults?.Invoke();
		};
	}

	public void TryLogin()
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
			LoginDialog loginDialog = new LoginDialog(CommonPaths.WebCache, _cookieManagerService, CookieSession.MultiTracks, _consumer.BeginAuthorization(), _consumer.TryCompleteAuthorization);
			loginDialog.Title = "MultiTracks Login";
			loginDialog.CacheSession = "multitracks";
			loginDialog.Height = 500.0;
			loginDialog.Owner = mainWindow;
			loginDialog.ShowDialog();
			if (mainWindow != null)
			{
				((DispatcherObject)mainWindow).Dispatcher.InvokeAsync<bool>((Func<bool>)mainWindow.Focus);
			}
		}
		else
		{
			MessageDialogService.ShowAlert(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"));
		}
	}

	public void ToggleAuthorization()
	{
		if (_consumer.IsAuthorized)
		{
			_consumer.Deauthorize();
		}
		else
		{
			TryLogin();
		}
	}

	public void Search(string searchText, Action<MultiTracksSearchResults> completedCallback)
	{
		if (_consumer.IsAuthorized)
		{
			_consumer.GetSearchResults(searchText, completedCallback, MessageDialogService.ShowAlert, 1, 100);
		}
	}

	public void Import(MultiTracksSearchResult searchResult)
	{
		HandleImport(searchResult);
	}

	public void ImportAndLinkToItem(ProPresenterCue target, MultiTracksSearchResult searchResult)
	{
		HandleImport(searchResult, delegate(string? filename, IImportProcess process)
		{
			if (target is PlaceholderCue placeholderCue)
			{
				_presentationVM.LinkImportedFile(placeholderCue, filename, process, PlaceholderLinkSource.QuickSearch);
			}
			else if (target is PCOCueBase pcoCue)
			{
				_pcoLiveVM.LinkImportedFile(pcoCue, filename ?? string.Empty, process, PlaceholderLinkSource.QuickSearch, null);
			}
		});
	}

	private void HandleImport(MultiTracksSearchResult searchResult, Action<string?, IImportProcess>? completeCallback = null)
	{
		if (_importMultiTracksVM.Import(searchResult))
		{
			_importMultiTracksVM.SelectedTemplate.ThrowWhenNull("_importMultiTracksVM.SelectedTemplate");
			_importMultiTracksVM.PresentationName.ThrowWhenNull("_importMultiTracksVM.PresentationName");
			_importMultiTracksVM.SelectedLibrary.ThrowWhenNull("_importMultiTracksVM.SelectedLibrary");
			if (_importMultiTracksVM.IsAutomationAndChords)
			{
				_importMultiTracksVM.SelectedNote.ThrowWhenNull("_importMultiTracksVM.SelectedNote");
				_importMultiTracksVM.SelectedScale.ThrowWhenNull("_importMultiTracksVM.SelectedScale");
				_consumer.Import(searchResult, new Key(_importMultiTracksVM.SelectedNote.Value, _importMultiTracksVM.SelectedScale.Value), _importMultiTracksVM.LinesPerSlide, _importMultiTracksVM.SelectedTemplate, _importMultiTracksVM.Size, _importMultiTracksVM.PresentationName, _importMultiTracksVM.SelectedLibrary, _importMultiTracksVM.SelectedPlaylist, _app, _importProcessFactory, completeCallback, MessageDialogService.ShowAlert);
			}
			else
			{
				_consumer.Import(searchResult, _importMultiTracksVM.LinesPerSlide, _importMultiTracksVM.SelectedTemplate, _importMultiTracksVM.Size, _importMultiTracksVM.PresentationName, _importMultiTracksVM.SelectedLibrary, _importMultiTracksVM.SelectedPlaylist, _app, _importProcessFactory, completeCallback, MessageDialogService.ShowAlert);
			}
		}
	}

	public void RetryAuthorization(MultiTracksPresentation presentation)
	{
		if (!_consumer.IsAuthorized)
		{
			TryLogin();
			if (_consumer.IsAuthorized)
			{
				_consumer.GetAccountInfo(delegate
				{
					OnDoAuthorization();
				});
			}
		}
		else
		{
			OnDoAuthorization();
		}
		void OnDoAuthorization()
		{
			if (!presentation.IsAvailable)
			{
				_consumer.RefreshAuthorization(presentation, consumeCredit: false, delegate(MultiTracksPresentation multiTracksPresentation)
				{
					if (!multiTracksPresentation.IsAvailable && MessageDialogService.ShowDialog(LocalizedStrings.Get("PRESENTATION_MULTITRACKS_ERROR_DIALOG_Title"), multiTracksPresentation.OwnedByCurrentCustomer ? (LocalizedStrings.Get("EDITOR_MULTITRACKS_LICENSED_EXPIRED_message") + "\n\n" + LocalizedStrings.Get("EDITOR_MULTITRACKS_LICENSED_EXPIRED_info")) : (LocalizedStrings.Get("EDITOR_MULTITRACKS_LICENSED_DIFFERENT_CUSTOMER_message") + "\n\n" + LocalizedStrings.Get("EDITOR_MULTITRACKS_LICENSED_DIFFERENT_CUSTOMER_info")), DefaultButtons.CONTINUE | DefaultButtons.CANCEL, DefaultButtons.CONTINUE) == DefaultButtons.CONTINUE)
					{
						_consumer.RefreshAuthorization(multiTracksPresentation, consumeCredit: true, delegate(MultiTracksPresentation tracksPresentation)
						{
							if (!tracksPresentation.IsAvailable)
							{
								MessageDialogService.ShowDialog(LocalizedStrings.Get("PRESENTATION_MULTITRACKS_ERROR_DIALOG_Title"), LocalizedStrings.Get("PRESENTATION_MULTITRACKS_FAILED_CONTACT_Message"), DefaultButtons.OK, DefaultButtons.OK);
							}
						}, errorHandler);
					}
				}, errorHandler);
			}
		}
		static void errorHandler(string message)
		{
			MessageDialogService.ShowDialog(LocalizedStrings.Get("PRESENTATION_MULTITRACKS_ERROR_DIALOG_Title"), message, DefaultButtons.OK, DefaultButtons.OK);
		}
	}
}
