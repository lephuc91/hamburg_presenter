using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using Pro.Common.Background;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using Pro.Web.Cookies;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.PCOLive;
using ProPresenter.UI.PresentationLibrary;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.PCO;
using ProPresenter.UI.ViewModels.QuickSearch;

namespace ProPresenter.ViewModels;

public class PCOLiveVM : NotifyPropertyChangedBase, IPCOLiveVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly Func<PCOPlan, PCOPlaylist> _addPCOPlaylist;

	private readonly ILibraryVM _libraryVM;

	private readonly IAttachmentManagerVM _attachmentManagerVM;

	private readonly Action<string> _setSearchText;

	private readonly ISongSelectConsumer _songSelectConsumer;

	private readonly IMatchSongsInteractor _matchSongsInteractor;

	private PCOObject? _activePlan;

	private PCOObject? _selectedPlan;

	private readonly Dictionary<string, (PCOCueBase, ILibrary)> _pendingLinkDocuments = new Dictionary<string, (PCOCueBase, ILibrary)>();

	private readonly ICookieManagerService _cookieManagerService;

	private readonly IApp _app;

	private readonly IInputActions _inputActions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IMediaFactory _mediaFactory;

	public IPCOConsumer PCOConsumer { get; }

	public PCOOrganization PCOOrganization { get; }

	public PCOObject? ActivePlan
	{
		get
		{
			return _activePlan;
		}
		set
		{
			SetValue("ActivePlan", ref _activePlan, value, OnActivePlanChanged);
		}
	}

	public PCOObject? SelectedPlan
	{
		get
		{
			return _selectedPlan;
		}
		set
		{
			SetValue("SelectedPlan", ref _selectedPlan, value);
		}
	}

	public ICommand LogoutCommand => new RelayCommand(OnLogoutCommand);

	public ICommand<LinkCommandParameters> LinkNewPresentationCommand => new RelayCommand<LinkCommandParameters>(OnLinkNewPresentationCommand);

	public ICommand<LinkCommandParameters> LinkImportCommand => new RelayCommand<LinkCommandParameters>(OnLinkImportCommand);

	public ICommand<LinkCommandParameters> LinkDocumentCommand => new RelayCommand<LinkCommandParameters>(delegate(LinkCommandParameters p)
	{
		(p.TargetCue as PCOCueBase)?.LinkDocument(p.Presentation);
		PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, PlaceholderLinkSource.DragDrop);
	}, (LinkCommandParameters p) => p.Presentation != null);

	public ICommand<LinkCommandParameters> LinkMediaCommand => new RelayCommand<LinkCommandParameters>(delegate(LinkCommandParameters p)
	{
		(p.TargetCue as PCOCueBase)?.LinkMedia(p.Media);
		PlaceholderLinkEvent.Publish(PlaceholderLinkType.Media, PlaceholderLinkSource.DragDrop);
	}, (LinkCommandParameters p) => p.Media != null);

	public ICommand<LinkCommandParameters> LinkDropFilesCommand => new RelayCommand<LinkCommandParameters>(OnLinkDropFilesCommand, CanDropLinkFiles);

	public ICommand<LinkCommandParameters> LinkSongSelectItemCommand => new RelayCommand<LinkCommandParameters>(OnLinkSongSelectItemCommand);

	public ICommand<ProPresenterCue> UnlinkItemCommand => new RelayCommand<ProPresenterCue>(delegate(ProPresenterCue p)
	{
		(p as PCOCueBase)?.UnlinkItem();
	}, (ProPresenterCue p) => (p as PCOCueBase)?.IsLinked ?? false);

	public ICommand<ProPresenterCue> OpenAttachmentsCommand => new RelayCommand<ProPresenterCue>(OnOpenAttachmentManagerCommand, (ProPresenterCue p) => p is PCOCueBase);

	public ICommand<ProPresenterCue> OpenSearchCommand => new RelayCommand<ProPresenterCue>(OnOpenSearchCommand, (ProPresenterCue p) => !((p as PCOCueBase)?.IsLinked ?? false));

	public ICommand<PCOPlan> ImportPCOPlanCommand => new RelayCommand<PCOPlan>(CreatePCOPlaylist, (PCOPlan p) => p != null);

	public ICommand RefreshOrganizationDataCommand => new RelayCommand(PCOConsumer.ReloadOrganizationData);

	public ICommand ShowPlanBrowserCommand => new RelayCommand(OnShowPlanBrowserCommand);

	public PCOLiveVM(ICoreManager manager, PCOOrganization organization, Func<PCOPlan, PCOPlaylist> addPCOPlaylist, ILibraryVM libraryVM, IAttachmentManagerVM attachmentManagerVM, Action<string> setSearchText, ISongSelectConsumer songSelectConsumer, ICookieManagerService cookieManagerService, IApp app, ILibraryCollection libraryCollection, IInputActions inputActions, IImportProcessFactory importProcessFactory, IMediaFactory mediaFactory, IMatchSongsInteractor matchSongsInteractor)
	{
		_addPCOPlaylist = addPCOPlaylist;
		_libraryVM = libraryVM;
		_attachmentManagerVM = attachmentManagerVM;
		_setSearchText = setSearchText;
		_songSelectConsumer = songSelectConsumer;
		_cookieManagerService = cookieManagerService;
		_app = app;
		_inputActions = inputActions;
		_importProcessFactory = importProcessFactory;
		_mediaFactory = mediaFactory;
		_matchSongsInteractor = matchSongsInteractor;
		PCOConsumer = manager.PCOConsumer;
		PCOConsumer.RequestPCOLogin = EnsureAuthorized;
		_manager = manager;
		PCOOrganization = organization;
		PCOOrganization.PropertyChanged += OnOrganizationPropertyChanged;
		libraryCollection.LibraryCollectionChanged += LibraryCollection_LibraryChanged;
		CookieModel cookie = _cookieManagerService.GetCookie(".planningcenteronline.com", "_account_center_session");
		CookieModel? cookie2 = _cookieManagerService.GetCookie(".planningcenteronline.com", "planning_center_session");
		PCOConsumer.PropertyChanged += PCOConsumer_PropertyChanged;
		if ((object)cookie2 == null || cookie2.IsExpired || (object)cookie == null || cookie.IsExpired)
		{
			OnLogoutCommand();
		}
		ReloadActivePlan();
	}

	private void PCOConsumer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsAuthorized")
		{
			SendPCODataToCore();
		}
	}

	private void SendPCODataToCore()
	{
		string planId = _app.SelectedPCOLivePlanID ?? string.Empty;
		string serviceTypeId = _app.SelectedPCOLiveServiceTypeID ?? string.Empty;
		if (!PCOConsumer.IsAuthorized)
		{
			planId = string.Empty;
			serviceTypeId = string.Empty;
		}
		_manager.SendPCOData(new PCOData
		{
			PlanId = planId,
			ServiceTypeId = serviceTypeId
		});
	}

	private void OnOrganizationPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Items")
		{
			ReloadActivePlan();
		}
	}

	private void OnActivePlanChanged(PCOObject oldValue, PCOObject newValue)
	{
		if (newValue is PCOPlan pCOPlan)
		{
			_app.SelectedPCOLiveServiceTypeID = pCOPlan.ServiceTypeID;
			_app.SelectedPCOLivePlanID = pCOPlan.ID ?? string.Empty;
		}
		else
		{
			_app.SelectedPCOLiveServiceTypeID = string.Empty;
			_app.SelectedPCOLivePlanID = string.Empty;
		}
		SendPCODataToCore();
	}

	private Task EnsureAuthorized()
	{
		return EnsureAuthorized(null);
	}

	public async Task EnsureAuthorized(Action<bool>? authorizedCallback)
	{
		if (PCOConsumer.IsAuthorized)
		{
			authorizedCallback?.Invoke(obj: true);
		}
		else
		{
			await ShowPCOLoginDialogAsync(authorizedCallback);
		}
	}

	private void OnLogoutCommand()
	{
		PCOConsumer.Deauthorize();
		ActivePlan = null;
		SelectedPlan = null;
	}

	private void CreatePCOPlaylist(PCOPlan pcoPlan)
	{
		PCOConsumer.IsPCOBusy = true;
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		PCOConsumer.LoadPlanItemsAsync(pcoPlan).ContinueWith(delegate(Task<PCOPlan> loadPlanTask)
		{
			PCOPlan plan = loadPlanTask.Result;
			if (plan == null || _addPCOPlaylist == null)
			{
				PCOConsumer.IsPCOBusy = false;
			}
			else
			{
				dispatcher.InvokeAsync((System.Action)delegate
				{
					PCOPlaylist playlist = _addPCOPlaylist(plan);
					_matchSongsInteractor.Execute(plan, playlist);
				});
			}
		});
	}

	private void ReloadActivePlan()
	{
		PCOOrganization.FindPlan(_app.SelectedPCOLiveServiceTypeID, _app.SelectedPCOLivePlanID, delegate(PCOPlan? p)
		{
			ActivePlan = p;
		});
	}

	private void OnShowPlanBrowserCommand()
	{
		if (PCOConsumer.IsAuthorized)
		{
			ShowPCOPlanBrowser();
		}
		else
		{
			ShowPCOLoginDialogAsync(OnPCOLogin_ShowPlanBrowser).ExecuteAsync();
		}
	}

	private void OnPCOLogin_ShowPlanBrowser(bool isSuccessful)
	{
		if (isSuccessful)
		{
			ShowPCOPlanBrowser();
		}
	}

	private async Task ShowPCOLoginDialogAsync(Action<bool>? successCallback)
	{
		if (!InternetAccessCheck.IsInternetAvailable())
		{
			MessageDialogService.ShowDialog(LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_message"), LocalizedStrings.Get("GLOBAL_NO_INTERNET_CONNECTION_info"), DefaultButtons.OK, DefaultButtons.OK);
			successCallback?.Invoke(obj: false);
			return;
		}
		LoginDialog loginDialog = new LoginDialog(CommonPaths.WebCache, _cookieManagerService, CookieSession.PCO, PCOConsumer.GetLoginUrl(), PCOConsumer.IsAuthorizationCallback)
		{
			Owner = Application.Current.MainWindow,
			Title = LocalizedStrings.Get("SERVICE_PREFERENCES_PLANNING_CENTER_ONLINE_LOGIN_title"),
			Height = 700.0,
			CacheSession = PCOConsumer.CacheSessionId
		};
		loginDialog.ShowDialog();
		await PCOConsumer.CompleteAuthorizationWithUrlAsync(loginDialog.FinalLoginUrl);
		successCallback?.Invoke(PCOConsumer.IsAuthorized);
	}

	private void ShowPCOPlanBrowser()
	{
		PCOPlanBrowser planBrowser = new PCOPlanBrowser
		{
			DataContext = this,
			SelectPCOPlanCommand = ImportPCOPlanCommand
		};
		PCOConsumer.Deauthorized += OnDeauth;
		planBrowser.ShowDialog();
		void OnDeauth()
		{
			PCOConsumer.Deauthorized -= OnDeauth;
			planBrowser.Close();
		}
	}

	public void ToggleAuthorization()
	{
		if (PCOConsumer.IsAuthorized)
		{
			OnLogoutCommand();
		}
		else
		{
			EnsureAuthorized().ExecuteAsync();
		}
	}

	private void OnLinkNewPresentationCommand(LinkCommandParameters parameters)
	{
		PCOCueBase pcoCue;
		if (_libraryVM != null)
		{
			ProPresenterCue targetCue = parameters.TargetCue;
			pcoCue = targetCue as PCOCueBase;
			if (pcoCue != null)
			{
				_libraryVM.NewPresentationCreated += onPresentationCreated;
				_inputActions.FileMenu.NewPresentation.BindCommand.Invoke();
				_libraryVM.NewPresentationVM.CanSelectPlaylist = true;
				_libraryVM.NewPresentationVM.SelectPlaylistCommand.Execute(_libraryVM.ActivePlaylist);
				_libraryVM.NewPresentationVM.CanSelectPlaylist = false;
			}
		}
		void onPresentationCreated(NewPresentationEventArgs args)
		{
			_libraryVM.NewPresentationCreated -= onPresentationCreated;
			if (args?.Document != null)
			{
				args.ShouldActivate = false;
				pcoCue.LinkDocument(args.Document.DocumentAction.Presentation);
				PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, PlaceholderLinkSource.CreateButton);
			}
		}
	}

	private void OnLinkImportCommand(LinkCommandParameters parameters)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.ImportableFileFilter
		};
		if (openFileDialog.ShowDialog() == true)
		{
			OnLinkFiles(new LinkCommandParameters(parameters.TargetCue, new FileInfo[1]
			{
				new FileInfo(openFileDialog.FileName)
			}), PlaceholderLinkSource.ImportButton);
		}
	}

	private void OnLinkDropFilesCommand(LinkCommandParameters parameters)
	{
		OnLinkFiles(parameters, PlaceholderLinkSource.DragDrop);
	}

	private void OnLinkFiles(LinkCommandParameters parameters, PlaceholderLinkSource linkSource)
	{
		PCOCueBase pcoCue = parameters.TargetCue as PCOCueBase;
		List<FileImportRequest> requests = new List<FileImportRequest>();
		if (parameters.RemoteFile != null)
		{
			parameters.RemoteFile.DownloadFile(delegate(FileInfo fileInfo)
			{
				RelativePath relativePath = new RelativePath(fileInfo.FullName);
				if (relativePath.IsValid)
				{
					requests.Add(new FileImportRequest(relativePath));
					runImport();
				}
			});
			return;
		}
		foreach (RelativePath item in parameters.Files?.Select((FileInfo f) => new RelativePath(f.FullName)) ?? Enumerable.Empty<RelativePath>())
		{
			if (item.IsValid)
			{
				requests.Add(new FileImportRequest(item));
			}
		}
		runImport();
		void runImport()
		{
			IImportProcess process = _importProcessFactory.Create(requests);
			foreach (FileImportRequest item2 in process.Requests.OfType<FileImportRequest>())
			{
				item2.CompleteCallback = delegate(string o, string n, FileMediaBase? createdMedia)
				{
					LinkImportedFile(pcoCue, n, process, linkSource, createdMedia);
				};
			}
			process.StartImport();
		}
	}

	public void LinkImportedFile(PCOCueBase? pcoCue, string filename, IImportProcess process, PlaceholderLinkSource linkSource, FileMediaBase? existingMedia)
	{
		if (pcoCue == null)
		{
			return;
		}
		if (filename.IsMediaFile())
		{
			FileMediaBase fileMediaBase = _mediaFactory.CreateEmptyFileMedia(filename, pcoCue.ContainerId, null);
			pcoCue.LinkMedia(fileMediaBase);
			fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)filename);
			PlaceholderLinkEvent.Publish(PlaceholderLinkType.Media, linkSource);
		}
		else if (filename.IsProPresentationFile() || filename.IsPowerPointFile())
		{
			DocumentCue documentCue = process.SelectedLibrary?.FirstOrDefault((DocumentCue p) => p.Name == Path.GetFileNameWithoutExtension(filename));
			if (documentCue != null)
			{
				pcoCue.LinkDocument(documentCue.DocumentAction.Presentation);
			}
			else
			{
				process.SelectedLibrary.ThrowWhenNull("process.SelectedLibrary");
				_pendingLinkDocuments[filename] = (pcoCue, process.SelectedLibrary);
			}
			PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, linkSource);
		}
	}

	private void OnLinkSongSelectItemCommand(LinkCommandParameters parameters)
	{
		parameters.SongSelectResult.ThrowWhenNull("parameters.SongSelectResult");
		_songSelectConsumer.Import(_importProcessFactory, (SongSelectSearchResult)parameters.SongSelectResult, delegate(string filename, IImportProcess process)
		{
			LinkImportedFile((PCOCueBase)parameters.TargetCue, filename, process, PlaceholderLinkSource.DragDrop, null);
		});
	}

	private void OnOpenAttachmentManagerCommand(ProPresenterCue cue)
	{
		_attachmentManagerVM.ActivePlan = ((_libraryVM.SelectedPlaylists.FirstOrDefault() ?? _libraryVM.ActivePlaylist) as PCOPlaylist)?.PCOPlan;
		_attachmentManagerVM.SelectedAttachmentGroup = _attachmentManagerVM.AllAttachmentGroups.FirstOrDefault((IAttachmentGroupVM g) => g.ReferenceObject?.ID == (cue as PCOCueBase)?.PCOItem?.ID) ?? _attachmentManagerVM.AllAttachmentGroups.FirstOrDefault();
		_inputActions.ProCommon.OpenPCOAttachmentManager.BindCommand?.Invoke();
	}

	private void OnOpenSearchCommand(ProPresenterCue cue)
	{
		_setSearchText?.Invoke((cue as PCOCueBase)?.PCOItem?.Name ?? cue.Name);
		_inputActions.CommonInputActions.Find.BindCommand?.Invoke(new SearchContext(cue));
	}

	private void LibraryCollection_LibraryChanged(ILibrary library, NotifyCollectionChangedEventArgs e)
	{
		KeyValuePair<string, (PCOCueBase, ILibrary)>[] array = _pendingLinkDocuments.ToArray();
		foreach (KeyValuePair<string, (PCOCueBase, ILibrary)> keyValuePair in array)
		{
			keyValuePair.Deconstruct(out var key, out var value);
			(PCOCueBase, ILibrary) tuple = value;
			string f = key;
			var (pCOCueBase, library2) = tuple;
			if (pCOCueBase != null && library2 == library)
			{
				DocumentCue documentCue = library2.FirstOrDefault((DocumentCue p) => p.Name == Path.GetFileNameWithoutExtension(f));
				if (documentCue != null)
				{
					pCOCueBase.LinkDocument(documentCue.DocumentAction.Presentation);
					_pendingLinkDocuments.Remove(f);
				}
			}
		}
	}

	private static bool CanDropLinkFiles(LinkCommandParameters parameters)
	{
		if (parameters.TargetCue is PCOCueBase && (parameters.RemoteFile == null || parameters.RemoteFile.Filename.IsMediaFile() || parameters.RemoteFile.Filename.IsProPresentationFile() || parameters.RemoteFile.Filename.IsProBundleFile() || parameters.RemoteFile.Filename.IsPowerPointFile()))
		{
			if (parameters.Files != null)
			{
				if (parameters.Files.Any())
				{
					return parameters.Files.All((FileInfo f) => f.FullName.IsMediaFile() || f.FullName.IsProPresentationFile() || f.FullName.IsProBundleFile() || f.FullName.IsPowerPointFile());
				}
				return false;
			}
			return true;
		}
		return false;
	}
}
