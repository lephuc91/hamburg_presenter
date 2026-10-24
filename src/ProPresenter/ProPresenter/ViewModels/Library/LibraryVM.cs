using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.Entity;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.AdditionalInfo;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.RemoteFile;
using ProPresenter.UI;
using ProPresenter.UI.Calendar;
using ProPresenter.UI.Commands;
using ProPresenter.UI.LibraryView;
using ProPresenter.UI.PresentationLibrary;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.Library;

public class LibraryVM : LinkedNotifyPropertyChangedBase, ILibraryVM, ISizeableTarget, INotifyPropertyChanged
{
	private sealed class LibraryDragDropSourceCollection(ProPresenter.DO.Librarian.ILibrary library) : IDragDropNotifyEnumerableChanged<ProPresenterCue>, INotifyEnumerableChanged<ProPresenterCue>, IEnumerable<ProPresenterCue>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ProPresenterCue>
	{
		private readonly ProPresenter.DO.Librarian.ILibrary _library = library;

		public event NotifyCollectionChangedEventHandler? CollectionChanged
		{
			add
			{
				library.CollectionChanged += value;
			}
			remove
			{
				library.CollectionChanged -= value;
			}
		}

		public void DraggedFrom(IEnumerable<ProPresenterCue> items)
		{
			library.DraggedFrom(items.OfType<DocumentCue>());
		}

		public void DroppedInto(IEnumerable<ProPresenterCue> items, int index, bool isCopy)
		{
			library.DroppedInto(items.OfType<DocumentCue>(), index, isCopy);
		}

		public IEnumerator<ProPresenterCue> GetEnumerator()
		{
			return library.GetEnumerator();
		}

		public int IndexOf(ProPresenterCue item)
		{
			if (!(item is DocumentCue item2))
			{
				return -1;
			}
			return library.IndexOf(item2);
		}

		public void MoveTo(IEnumerable<ProPresenterCue> items, int index)
		{
			library.MoveTo(items.OfType<DocumentCue>(), index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass276_0
	{
		public LibraryVM _003C_003E4__this;

		public ProPresenter.DO.Librarian.ILibrary library;

		public bool applyToAll;

		public bool skip;

		public bool overwrite;

		public bool abort;
	}

	private readonly ICoreManager _manager;

	private readonly IProContentDownloader _proContentDownloader;

	private readonly ITriggering _service;

	private readonly ILibraryService _libraryService;

	private readonly IPresentationFactory _presentationFactory;

	private readonly IApp _app;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly ILogger _logger;

	private readonly IMessageDialogService _messageDialogService;

	private readonly IPowerPointImportOptionsDialog _powerPointImportOptionsDialog;

	private readonly IProPresenterCueVMFactory _cueVmFactory;

	private readonly IGeneral _general;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IInternetAccess _internetAccess;

	private readonly ILocalization _localization;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ITimelineManager _timelineManager;

	private readonly ILibraryPrompt _prompt;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IEntityFactory _entityFactory;

	private ProPresenter.DO.Librarian.ILibrary? _activeLibrary;

	private IPlaylist<ProPresenterCue>? _activePlaylist;

	private IProPresenterCueVM? _activeCue;

	private bool _ignoreSelectionChanges;

	private IProPresenterCueVM? _selectedCue;

	private bool _renameNextItem;

	private bool _isReflowTargetReset;

	private IProPresenterCueVM? _reflowTargetCue;

	private string _filterText = string.Empty;

	private LibraryItemType _activeItemType;

	private OutputDestination? _selectedCuesDestination;

	private bool _applyTemplateMediaAction;

	private IPlaylist<ProPresenterCue>? _selectedPlaylist;

	private DragDropPairedCollection<ProPresenterCue, IProPresenterCueVM> _cueVms;

	private IDisposable? _cueVmsWhenCollectionChangesSubscription;

	public OutputDestination? SelectedCuesDestination
	{
		get
		{
			return _selectedCuesDestination;
		}
		private set
		{
			SetValue("SelectedCuesDestination", ref _selectedCuesDestination, value);
		}
	}

	public ILibraryCollection Libraries => _libraryService.Libraries;

	public LibraryPlaylistCollection Playlists => _libraryService.Playlists;

	public ProPresenter.DO.Librarian.ILibrary? ActiveLibrary
	{
		get
		{
			return _activeLibrary;
		}
		set
		{
			SetValue("ActiveLibrary", ref _activeLibrary, value, OnActiveLibraryChanged);
		}
	}

	public bool UseContextMenuReflowTarget
	{
		get
		{
			return _isReflowTargetReset;
		}
		set
		{
			SetValue("UseContextMenuReflowTarget", ref _isReflowTargetReset, value);
		}
	}

	public IProPresenterCueVM? ActiveCue
	{
		get
		{
			return _activeCue;
		}
		set
		{
			OnActiveCueChanged(value);
			SetValue("ActiveCue", ref _activeCue, value, (Action<IProPresenterCueVM, IProPresenterCueVM>?)delegate
			{
				if (ActiveCue is IDocumentCue except)
				{
					_timelineManager.StopTheActiveRecordingAsync(except).ExecuteAsync();
				}
			}, (Predicate<IProPresenterCueVM>?)null, referenceComparison: false);
		}
	}

	public IProPresenterCueVM? ReflowTargetCue
	{
		get
		{
			return _reflowTargetCue;
		}
		set
		{
			SetValue("ReflowTargetCue", ref _reflowTargetCue, value, (Action)delegate
			{
				UseContextMenuReflowTarget = true;
			}, (Predicate<IProPresenterCueVM>?)null, referenceComparison: false);
		}
	}

	public ObservableCollection<ProPresenter.DO.Librarian.ILibrary> SelectedLibraries { get; } = new ObservableCollection<ProPresenter.DO.Librarian.ILibrary>();

	public IPlaylist<ProPresenterCue>? ActivePlaylist
	{
		get
		{
			return _activePlaylist;
		}
		set
		{
			SetValue<IPlaylist<ProPresenterCue>>("ActivePlaylist", ref _activePlaylist, value, OnActivePlaylistChanged, (IPlaylist<ProPresenterCue> n) => n == null || n.Type != PlaylistType.Group);
		}
	}

	public IPlaylist<ProPresenterCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			SetValue("SelectedPlaylist", ref _selectedPlaylist, value);
		}
	}

	public bool IsPresentationAvailable
	{
		get
		{
			IDocumentCueVM obj = SelectedCue as IDocumentCueVM;
			if (obj == null)
			{
				return false;
			}
			return obj.DocumentAction?.Presentation?.IsAvailable == true;
		}
	}

	public string ActiveItemName
	{
		get
		{
			return ActiveLibrary?.Name ?? ActivePlaylist?.Name ?? string.Empty;
		}
		set
		{
			if (ActiveLibrary != null)
			{
				ActiveLibrary.Name = value;
			}
			else if (ActivePlaylist != null)
			{
				ActivePlaylist.Name = value;
			}
		}
	}

	public LibraryItemType ActiveItemType
	{
		get
		{
			return _activeItemType;
		}
		private set
		{
			SetValue("ActiveItemType", ref _activeItemType, value);
		}
	}

	public ObservableCollection<IPlaylist<ProPresenterCue>> SelectedPlaylists { get; } = new ObservableCollection<IPlaylist<ProPresenterCue>>();

	public bool MultiplePlaylistsSelected => SelectedPlaylists.Count() > 1;

	public bool OnlyPCOPlaylistSelected
	{
		get
		{
			if (!SelectedPlaylists.All((IPlaylist<ProPresenterCue> p) => p is PCOPlaylist))
			{
				return ActivePlaylist is PCOPlaylist;
			}
			return true;
		}
	}

	public bool ShowPCOPlaylistAddMenu => _general.ShowHoW;

	public bool ShowAddToPlaylistsOnly
	{
		get
		{
			if (ActiveLibrary != null)
			{
				return Libraries.Count == 1;
			}
			return true;
		}
	}

	public bool ShowMoveTo
	{
		get
		{
			if (ActiveLibrary != null)
			{
				return Libraries.Count > 1;
			}
			return false;
		}
	}

	private GeneralPlaylist? ActiveGeneralPlaylist => ActivePlaylist as GeneralPlaylist;

	private PCOPlaylist? ActivePCOPlaylist => ActivePlaylist as PCOPlaylist;

	public string ItemsCountText
	{
		get
		{
			int num = CueCollectionView.Count();
			string value = _localization.Get((num == 1) ? "LIBRARY_PLAYLIST_ITEMS_COUNT_SINGULAR_label" : "LIBRARY_PLAYLIST_ITEMS_COUNT_PLURAL_label");
			string totalPlayLength = GetTotalPlayLength();
			if (string.IsNullOrEmpty(totalPlayLength))
			{
				return $"{num} {value}";
			}
			return $"{num} {value} {totalPlayLength}";
		}
	}

	public ICollectionView CueCollectionView { get; private set; }

	public ICollectionView HiddenCueCollectionView { get; private set; }

	public string FilterText
	{
		get
		{
			return _filterText;
		}
		set
		{
			SetValue("FilterText", ref _filterText, value, UpdateFilteredCues);
		}
	}

	private IDocumentCue? ActiveDocumentCue => (ActiveCue as IDocumentCueVM)?.Document;

	public IEnumerable<IDocumentCue> SelectedActiveCues
	{
		get
		{
			IEnumerable<IDocumentCue> source;
			if (!SelectedCues.Any())
			{
				source = ActiveDocumentCue.ToEnumerable();
			}
			else
			{
				IEnumerable<IDocumentCue> enumerable = SelectedCues.Select(delegate(IProPresenterCueVM c)
				{
					if (c is IDocumentCueVM documentCueVM)
					{
						return documentCueVM.Document;
					}
					if (c is IPcoCueVM pcoCueVM)
					{
						IDocumentCue pco = pcoCueVM.Pco;
						if (pco != null)
						{
							return pco;
						}
					}
					return (IDocumentCue)null;
				}).NonNull();
				source = enumerable;
			}
			return source.Where((IDocumentCue d) => d?.DocumentAction != null);
		}
	}

	public IProPresenterCueVM? SelectedCue
	{
		get
		{
			return _selectedCue;
		}
		set
		{
			SetValue("SelectedCue", ref _selectedCue, value, null, false, "IsPresentationAvailable");
		}
	}

	public ObservableCollection<IProPresenterCueVM> SelectedCues { get; } = new ObservableCollection<IProPresenterCueVM>();

	public IDragDropCollection<IProPresenterCueVM>? DropTarget => _cueVms;

	public IEnumerable<MediaCue> SelectedMedia => (from m in SelectedCues.OrderBy(_cueVms.IndexOf).OfType<IMediaCueVM>()
		select m.Media into c
		select c.ToMediaCue()).NonNull();

	public IPCOConsumer PCOConsumer => _manager.PCOConsumer;

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public INewPresentationVM NewPresentationVM { get; }

	public IPlaylistTemplateCollectionVM PlaylistTemplatesVM { get; }

	public ICommand NewLibraryCommand => new RelayCommand(OnAddNewLibraryCommand);

	public ICommand NewGroupFolderCommand => new RelayCommand(OnAddNewGroupPlaylistCommand);

	public ICommand NewHeaderCommand => new RelayCommand(OnAddNewHeaderCommand, () => ActiveGeneralPlaylist != null || ActivePCOPlaylist != null);

	public ICommand NewPlaceholderCommand => new RelayCommand(OnAddNewPlaceholderCommand, () => ActiveGeneralPlaylist != null || ActivePCOPlaylist != null);

	public ICommand NewPlaylistCommand => new RelayCommand(OnAddNewPlaylistCommand);

	public ICommand<GeneralPlaylist> AddPlaylistFromTemplateCommand => new RelayCommand<GeneralPlaylist>(AddPlaylistFromTemplateCommandExecuted, (GeneralPlaylist p) => p != null);

	public ICommand<IPlaylist<ProPresenterCue>> ExportPlaylistCommand => new RelayCommand<IPlaylist<ProPresenterCue>>(OnExportPlaylistCommand, (IPlaylist<ProPresenterCue> p) => p != null || ActivePlaylist != null);

	public ICommand ExportToTextCommand => new RelayCommand(OnExportToTextCommand, OnCanExportAsText);

	public ICommand ExportToPro7Command => new RelayCommand(OnExportToPro7Command, AreAnyActiveCuesSelected);

	public ICommand ExportToBundleCommand => new RelayCommand(OnExportToBundleCommand, AreAnyActiveCuesSelected);

	public ICommand DeleteLibraryCommand => new RelayCommand(delegate
	{
		OnDeleteLibraryCommand(SelectedLibraries);
	}, () => Libraries.Count > 1 && SelectedLibraries.Any());

	public ICommand DeletePlaylistCommand => new RelayCommand(delegate
	{
		OnDeletePlaylistCommand(SelectedPlaylists);
	}, () => SelectedPlaylists.Any());

	public ICommand DuplicatePlaylistCommand => new RelayCommand(delegate
	{
		OnDuplicatePlaylistCommand(SelectedPlaylists);
	}, () => SelectedPlaylists.Any());

	public ICommand DuplicateActivePlaylistCommand => new RelayCommand(delegate
	{
		OnDuplicatePlaylistCommand(ActivePlaylist.ToEnumerable());
	}, () => ActivePlaylist != null);

	public ICommand DeleteActivePlaylistCommand => new RelayCommand(delegate
	{
		OnDeletePlaylistCommand(ActivePlaylist.ToEnumerable());
	}, () => ActivePlaylist != null);

	public ICommand DeleteActiveLibraryCommand => new RelayCommand(delegate
	{
		OnDeleteLibraryCommand(ActiveLibrary.ToEnumerable());
	}, () => Libraries.Count > 1 && ActiveLibrary != null);

	public ICommand CopyCuesCommand => new RelayCommand(OnCopyCuesCommand, OnCopyCuesCommandCanExecute);

	public ICommand PasteCuesCommand => new RelayCommand(OnPasteCuesCommand, OnPasteCuesCommandCanExecute);

	public ICommand DuplicateCuesCommand => new RelayCommand(OnDuplicateCuesCommand, OnDuplicateOrDeleteCuesCommandCanExecute);

	public ICommand DeleteCuesCommand => new RelayCommand(OnDeleteCuesCommand, OnDuplicateOrDeleteCuesCommandCanExecute);

	public ICommand<DropFilesCommandParameters> DropFilesCommand => new RelayCommand<DropFilesCommandParameters>(OnDropFilesCommand);

	public ICommand<(IEnumerable<IDocumentCueVM>, int, bool)> DropPresentationsCommand => new RelayCommand<(IEnumerable<IDocumentCueVM>, int, bool)>(OnDropPresentationsCommand);

	public ICommand<ProPresenter.DO.Librarian.ILibrary> SelectLibraryCommand => new RelayCommand<ProPresenter.DO.Librarian.ILibrary>(delegate(ProPresenter.DO.Librarian.ILibrary l)
	{
		ActiveLibrary = l;
	});

	public ICommand<IProPresenterCueVM> ShowInLibraryCommand => new RelayCommand<IProPresenterCueVM>(OnShowInLibraryCommand, (IProPresenterCueVM c) => c is IDocumentCueVM documentCueVM && documentCueVM.Document.DocumentAction?.Presentation != null && ActiveLibrary == null);

	public ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand => new RelayCommand<IPlaylist<ProPresenterCue>>(delegate(IPlaylist<ProPresenterCue> p)
	{
		ActivePlaylist = p;
	});

	public ICommand<ProPresenter.DO.Librarian.ILibrary> MoveToLibraryCommand => new RelayCommand<ProPresenter.DO.Librarian.ILibrary>(OnMoveToLibraryCommand);

	public ICommand<ProPresenter.DO.Librarian.ILibrary> AddToLibraryCommand => new RelayCommand<ProPresenter.DO.Librarian.ILibrary>(OnAddToLibraryCommand);

	public ICommand<Playlist<ProPresenterCue>?> AddToPlaylistCommand => new RelayCommand<Playlist<ProPresenterCue>>(OnAddToPlaylistCommand, (Playlist<ProPresenterCue>? p) => p != null);

	public ICommand<DropFilesCommandParameters> DropPlaylistFilesCommand => new RelayCommand<DropFilesCommandParameters>(OnDropPlaylistFilesCommand);

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(SelectTemplateCommandExecuted, (TemplateSlide a) => SelectedActiveCues.Any());

	public ICommand<Arrangement> SelectArrangementCommand => new RelayCommand<Arrangement>(OnSelectArrangementCommand, (Arrangement a) => SelectedCue is IDocumentCueVM documentCueVM && documentCueVM.DocumentAction != null);

	public ICommand<MediaCue> TriggerMediaItemCommand => new RelayCommand<MediaCue>(OnTriggerMediaItemCommand, (MediaCue m) => m != null);

	public ICommand RefreshPCOPlaylistCommand => new RelayCommand(OnRefreshPCOPlaylistCommand, () => !_manager.PCOConsumer.IsPCOBusy && OnlyPCOPlaylistSelected);

	public ICommand ConvertPCOPlaylistCommand => new RelayCommand(OnConvertPCOPlaylistCommand, () => !_manager.PCOConsumer.IsPCOBusy && OnlyPCOPlaylistSelected);

	public ICommand<IProPresenterCueVM> PCOUploadCommand => new RelayCommand<IProPresenterCueVM>(delegate(IProPresenterCueVM p)
	{
		PCOPlaylistHelper.UploadToPCO(_manager.PCOConsumer, p.Cue as PCOCueBase);
	}, (IProPresenterCueVM p) => p is IPcoCueVM pcoCueVM && pcoCueVM.Cue is PCOCueBase);

	public ICommand ShowTriggeredPresentationCommand => new RelayCommand(delegate
	{
		OnShowTriggered(OutputDestination.Presentation);
	}, () => CanShowTriggered(OutputDestination.Presentation));

	public ICommand ShowTriggeredAnnouncementCommand => new RelayCommand(delegate
	{
		OnShowTriggered(OutputDestination.Announcement);
	}, () => CanShowTriggered(OutputDestination.Announcement));

	public ICommand RevealInLibraryCommand => new RelayCommand(OnRevealInLibraryCommand, () => ActiveDocumentCue?.DocumentAction?.Presentation != null);

	public ICommand<DependencyObject> GotFocusCommand => new RelayCommand<DependencyObject>(OnGotFocusCommand, (DependencyObject e) => e != null);

	public ICommand<bool> LibraryNavigationCrestedCommand => new RelayCommand<bool>(delegate
	{
		OnLibraryNavigationCrestedCommand();
	}, (bool isDown) => isDown && Playlists.Any());

	public ICommand<bool> PlaylistNavigationCrestedCommand => new RelayCommand<bool>(delegate
	{
		OnPlaylistNavigationCrestedCommand();
	}, (bool isDown) => !isDown && Libraries.Any());

	public ICommand<IProPresenterCueVM> UnlinkItemCommand => new RelayCommand<IProPresenterCueVM>(OnUnlinkItemCommandExecute, OnUnlinkItemCommandCanExecute);

	public ICommand<IProPresenterCueVM> HideItemCommand => new RelayCommand<IProPresenterCueVM>(delegate(IProPresenterCueVM c)
	{
		OnToggleVisibilityCommand(c, isHidden: true);
	}, (IProPresenterCueVM c) => c != null);

	public ICommand<IProPresenterCueVM> ShowItemCommand => new RelayCommand<IProPresenterCueVM>(delegate(IProPresenterCueVM c)
	{
		OnToggleVisibilityCommand(c, isHidden: false);
	}, (IProPresenterCueVM c) => c != null);

	public ICommand UnhideAllItemsCommand => new RelayCommand(OnUnhideAllItems, () => ActivePlaylist is Playlist<ProPresenterCue>);

	public Vector2<double> Size => SizeableTargets.FirstOrDefault()?.Size ?? Vector2<double>.Zero;

	private IEnumerable<ISizeableTarget> SizeableTargets => (from d in SelectedCues.OfType<IDocumentCueVM>()
		select d.DocumentAction?.Presentation).NonNull();

	public ICommand<ColorPair> ColorChangeFinishedCommand => new RelayCommand<ColorPair>(delegate(ColorPair c)
	{
		OnChangeHeaderColorCommand(c.NewColor.GetValueOrDefault());
	}, (ColorPair c) => SelectedCues.Any());

	public ICommand<OutputDestination> ChangeOutputDestinationCommand => new RelayCommand<OutputDestination>(OnChangeOutputDestinationCommandExecuted, (OutputDestination d) => AreAnyCuesSelected() && (ActiveLibrary != null || ActivePlaylist != null));

	public ICommand<ProContentDropParameter<GeneralPlaylist?>> DropProContentAssetCommand => new RelayCommand<ProContentDropParameter<GeneralPlaylist>>(DropProContentAssetCommandExecuted, CanDropAsset);

	public ICommand EditSelectedPresentationFromContextMenuCommand => new RelayCommand(delegate
	{
		this.PresentationEdited?.Invoke(ShowSource.LibraryContextMenu, (SelectedCue as IDocumentCueVM)?.DocumentAction?.Presentation as CustomPresentation, EditMode.Presentation);
	});

	public ICommand<TriggerLayer> SetMediaTargetLayerCommand => new RelayCommand<TriggerLayer>(OnSetMediaTargetLayerCommand);

	public ICommand RelinkCommand { get; }

	public event Action<UndoStack?>? StackChanged;

	public event Action<NewPresentationEventArgs>? NewPresentationCreated;

	public event Action<ShowSource, CustomPresentation?, EditMode>? PresentationEdited;

	public LibraryVM(ICoreManager manager, IPlaylistTemplateCollectionVM playlistTemplatesVM, IMessageService messageService, IProContentDownloader proContentDownloader, IThemeService themeService, IApp app, ILibraryService libraryService, ITriggeringFactory triggeringFactory, IPresentationFactory presentationFactory, IProPresenterResourceService resourceService, ITimelineManager timelineManager, ILibraryPrompt prompt, IImportProcessFactory importProcessFactory, IEntityFactory entityFactory, IFileSelectorService fileSelectorService, IProPresenterCueFactory cueFactory, ILogger logger, IMessageDialogService messageDialogService, IPowerPointImportOptionsDialog powerPointImportOptionsDialog, IProPresenterCueVMFactory cueVMFactory, IGeneral general, IUiDispatcher uiDispatcher, IInternetAccess internetAccess, ILocalization localization, bool initializeImportPrompt)
	{
		PlaylistTemplatesVM = playlistTemplatesVM;
		_proContentDownloader = proContentDownloader;
		_app = app;
		_manager = manager;
		_service = triggeringFactory.Create();
		_libraryService = libraryService;
		_presentationFactory = presentationFactory;
		_timelineManager = timelineManager;
		_prompt = prompt;
		_cueFactory = cueFactory;
		_logger = logger;
		_messageDialogService = messageDialogService;
		_powerPointImportOptionsDialog = powerPointImportOptionsDialog;
		_cueVmFactory = cueVMFactory;
		_general = general;
		_uiDispatcher = uiDispatcher;
		_internetAccess = internetAccess;
		_localization = localization;
		_importProcessFactory = importProcessFactory;
		_entityFactory = entityFactory;
		_resourceService = resourceService;
		NewPresentationVM = new NewPresentationVM(AddNewPresentation, this, app, themeService);
		messageService.SubscribeToMessage<ThemePickerSettingsUpdatedMessage>(HandleSettingsUpdated);
		_cueVms = new DragDropPairedCollection<ProPresenterCue, IProPresenterCueVM>(null, _cueVmFactory.Create, delegate(IProPresenterCueVM c)
		{
			c.Dispose();
		}, (IProPresenterCueVM c) => c.Cue);
		CueCollectionView = new CollectionViewSource
		{
			Source = _cueVms
		}.View;
		HiddenCueCollectionView = new CollectionViewSource
		{
			Source = _cueVms
		}.View;
		IObservable<ObservableCollection<IProPresenterCueVM>> source = SelectedCues.WhenCollectionChanges();
		source.Subscribe(delegate
		{
			UpdateSelectedCuesDestination();
		});
		RelinkCommand = source.Select((ObservableCollection<IProPresenterCueVM> _) => SelectedCues.Select((IProPresenterCueVM vm) => vm.Cue).OfType<MediaCue>()).StartWith(SelectedCues.Select((IProPresenterCueVM vm) => vm.Cue).OfType<MediaCue>()).WhenMediaValidityUpdates()
			.ToRelinkCommand(GetSelectedMediaCues, fileSelectorService, importProcessFactory);
		SetupManager();
		SetupCalendarService();
		if (initializeImportPrompt)
		{
			SetImportPrompts();
		}
		LoadActiveItems();
		HookupPropertyChanges();
		SetupPlaylists();
		SetupLibraries();
		UpdateSelectedCuesDestination();
	}

	private void HandleSettingsUpdated(Pro.Common.MessageService.IMessage message)
	{
		if (message is ThemePickerSettingsUpdatedMessage themePickerSettingsUpdatedMessage && themePickerSettingsUpdatedMessage.Model.ContextualGroup == ThemePickerGroup.Presentation)
		{
			_applyTemplateMediaAction = themePickerSettingsUpdatedMessage.Model.MediaActionEnabled;
		}
	}

	private void UpdateSelectedCuesDestination()
	{
		IEnumerable<IDocumentCue> source = from c in SelectedCues.OfType<IDocumentCueVM>()
			select c.Document;
		OutputDestination? selectedCuesDestination = null;
		if (source.Any())
		{
			OutputDestination? destination = source.First().DocumentAction?.Destination;
			if (source.All(delegate(IDocumentCue c)
			{
				IDocumentAction? documentAction = c.DocumentAction;
				return (documentAction == null) ? (!destination.HasValue) : (documentAction.Destination == destination);
			}))
			{
				selectedCuesDestination = destination;
			}
		}
		SelectedCuesDestination = selectedCuesDestination;
	}

	private void SetupManager()
	{
		if (_manager != null)
		{
			_manager.ActivePlaylistItemChanged += delegate(ProPresenterCue? o, ProPresenterCue? n)
			{
				ActiveCue = ((n != null) ? _cueVmFactory.Create(n) : null);
			};
			_manager.ActivePlaylistChanged += delegate(Playlist<ProPresenterCue> o, Playlist<ProPresenterCue> n)
			{
				ActivePlaylist = n;
			};
			_manager.ActiveLibraryChanged += delegate(ProPresenter.DO.Librarian.ILibrary o, ProPresenter.DO.Librarian.ILibrary n)
			{
				ActiveLibrary = n;
			};
		}
	}

	private void SetupCalendarService()
	{
		_libraryService.Calendar.CueTriggered += Calendar_CueTriggered;
	}

	private void Calendar_CueTriggered(object? sender, CalendarCueTriggeredEventArgs e)
	{
		ActivePlaylist = e.Playlist;
		SelectedCues.Clear();
		ActiveCue = null;
		IProPresenterCueVM proPresenterCueVM = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == e.Cue);
		if (proPresenterCueVM != null)
		{
			SelectedCues.Add(proPresenterCueVM);
			ActiveCue = proPresenterCueVM;
		}
	}

	private void SetImportPrompts()
	{
		ImportPrompt.SetAddToSelectedPlaylist(AddToSelectedPlaylist);
		ImportPrompt.SetAddToPlaylist(AddToPlaylist);
		ImportPrompt.SetImportCompleted(OnImportCompleted);
	}

	private void LoadActiveItems()
	{
		Guid cueID = _app.SelectedCueID;
		ProPresenterCue proPresenterCue = Libraries.SelectMany((ProPresenter.DO.Librarian.ILibrary l) => l).FirstOrDefault((DocumentCue d) => d.ID == cueID);
		if (proPresenterCue == null && Playlists.TryFindPlaylistItem((ProPresenterCue c) => c.ID == cueID, out ProPresenterCue cue))
		{
			proPresenterCue = cue;
		}
		ActiveCue = ((proPresenterCue != null) ? _cueVmFactory.Create(proPresenterCue) : null);
		if (_app.SelectedPlaylistID == Guid.Empty)
		{
			ActiveLibrary = Libraries.FirstOrDefault((ProPresenter.DO.Librarian.ILibrary l) => l.Name == _app.SelectedLibraryName);
		}
		else if (Playlists != null)
		{
			ActivePlaylist = Playlists.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.ID == _app.SelectedPlaylistID).FirstOrDefault();
			_manager.ActiveLibraryPlaylist = (Playlist<ProPresenterCue>)ActivePlaylist;
		}
	}

	private void HookupPropertyChanges()
	{
		LinkProperties("ShowHoW", "ShowPCOPlaylistAddMenu");
		_general.PropertyChanged += base.RaiseLinkedValues;
		SelectedCues.CollectionChanged += delegate
		{
			OnPropertyChanged("Size");
		};
		SelectedPlaylists.CollectionChanged += delegate
		{
			OnPropertyChanged("MultiplePlaylistsSelected");
			OnPropertyChanged("OnlyPCOPlaylistSelected");
		};
		_manager.MultiTracksConsumer.SubscriptionAuthorizationUpdated += OnMultiTracksConsumerSubscriptionAuthorizationUpdated;
	}

	private void SetupPlaylists()
	{
		Playlists.CollectionModified += delegate
		{
			OnPropertyChanged("Playlists");
			OnPropertyChanged("ActiveItemName");
		};
		Playlists.LocationChanged += delegate
		{
			ActivePlaylist = Playlists.FirstOrDefault();
			if (ActivePlaylist is GeneralPlaylist)
			{
				SelectedCue = _cueVms.FirstOrDefault();
				ActiveCue = SelectedCue;
			}
		};
	}

	private void SetupLibraries()
	{
		Libraries.ForEach(delegate(ProPresenter.DO.Librarian.ILibrary x)
		{
			x.PresentationRemovedBySync += OnCueRemovedBySync;
		});
		Libraries.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			OnPropertyChanged("ShowAddToPlaylistsOnly");
			OnPropertyChanged("ShowMoveTo");
			IList? oldItems = e.OldItems;
			if (oldItems != null && oldItems.OfType<ProPresenter.DO.Librarian.ILibrary>().Contains<ProPresenter.DO.Librarian.ILibrary>(ActiveLibrary))
			{
				ActiveLibrary = null;
			}
			e.OldItems?.OfType<ProPresenter.DO.Librarian.ILibrary>().ForEach(delegate(ProPresenter.DO.Librarian.ILibrary x)
			{
				x.PresentationRemovedBySync -= OnCueRemovedBySync;
			});
			e.NewItems?.OfType<ProPresenter.DO.Librarian.ILibrary>().ForEach(delegate(ProPresenter.DO.Librarian.ILibrary x)
			{
				x.PresentationRemovedBySync += OnCueRemovedBySync;
			});
		};
		Libraries.PresentationNameChanged += delegate
		{
			CueCollectionView.Refresh();
		};
		Libraries.LocationChanged += delegate
		{
			ActiveLibrary = Libraries.FirstOrDefault();
			SelectedCues.Clear();
			SelectedCue = _cueVms.FirstOrDefault();
			ActiveCue = SelectedCue;
		};
		Libraries.LibraryNameChanged += delegate
		{
			OnPropertyChanged("ActiveItemName");
		};
	}

	private bool CanShowTriggered(OutputDestination destination)
	{
		return _manager.ActiveSlides[destination] != null;
	}

	private void OnActiveLibraryChanged(ProPresenter.DO.Librarian.ILibrary? oldValue, ProPresenter.DO.Librarian.ILibrary? newValue)
	{
		_ignoreSelectionChanges = true;
		_app.SelectedLibraryName = newValue?.Name ?? string.Empty;
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= CueCollectionChanged;
		}
		if (newValue != null)
		{
			FilterText = string.Empty;
			ChangeCueVmsSource(new LibraryDragDropSourceCollection(newValue), sortItems: true);
			ActivePlaylist = null;
			ActiveItemType = LibraryItemType.Library;
			_app.SelectedPlaylistID = Guid.Empty;
		}
		if (newValue != null)
		{
			_manager.ActiveLibrary = newValue;
			_manager.ActiveLibraryPlaylist = null;
		}
		_ignoreSelectionChanges = false;
		OnPropertyChanged("ItemsCountText");
		OnPropertyChanged("ActiveItemName");
		OnPropertyChanged("DropTarget");
		OnPropertyChanged("ShowAddToPlaylistsOnly");
		OnPropertyChanged("ShowMoveTo");
		OnPropertyChanged("IsPresentationAvailable");
	}

	public void AddToActivePlaylist(IEnumerable<ProPresenterCue> cues)
	{
		IProPresenterCueVM proPresenterCueVM = SelectedCues.OrderBy(_cueVms.IndexOf).LastOrDefault() ?? ActiveCue;
		if (ActivePlaylist is ILibraryPlaylist<ProPresenterCue> libraryPlaylist)
		{
			int num = ((proPresenterCueVM != null) ? libraryPlaylist.IndexOf(proPresenterCueVM.Cue) : (-1));
			libraryPlaylist.AddPresentationItem(cues.Select((ProPresenterCue c) => c), (num >= 0) ? (num + 1) : (-1));
		}
	}

	private void OnActivePlaylistChanged(IPlaylist<ProPresenterCue>? oldValue, IPlaylist<ProPresenterCue>? newValue)
	{
		_ignoreSelectionChanges = true;
		_app.SelectedPlaylistID = newValue?.ID ?? Guid.Empty;
		Playlist<ProPresenterCue> playlist = newValue as Playlist<ProPresenterCue>;
		_manager.ActiveLibraryPlaylist = playlist;
		_manager.ActiveLibrary = ((playlist != null) ? null : _resourceService.LibraryCollection.FirstOrDefault());
		if (oldValue is Playlist<ProPresenterCue> playlist2)
		{
			playlist2.CollectionChanged -= CueCollectionChanged;
			SelectedPlaylists.Clear();
		}
		if (newValue != null)
		{
			if (newValue is Playlist<ProPresenterCue> playlist3 && newValue.Type != PlaylistType.Group)
			{
				FilterText = string.Empty;
				ChangeCueVmsSource(playlist3);
				ChangeUndoStack(Playlists?.UndoStack);
				if (_manager?.MultiTracksConsumer?.IsAuthorized == true)
				{
					(from d in (from d in playlist3.OfType<IDocumentCue>()
							where d.DocumentAction?.Presentation != null && d.DocumentAction.PresentationType == PresentationType.MultiTracks && !d.DocumentAction.Presentation.IsAvailable
							select d).Distinct((IDocumentCue d) => d.DocumentAction.Presentation.ID)
						select (MultiTracksPresentation)d.DocumentAction.Presentation).ToArray().ForEach(delegate(MultiTracksPresentation p)
					{
						_manager.MultiTracksConsumer.RefreshAuthorization(p, consumeCredit: false);
					});
				}
			}
			ActiveLibrary = null;
			ActiveItemType = LibraryItemType.Playlist;
			SelectedLibraries.Clear();
		}
		else if (ActiveLibrary == null)
		{
			ActiveCue = null;
			ActiveItemType = LibraryItemType.None;
			ChangeCueVmsSource(null);
			ChangeUndoStack(Playlists?.UndoStack);
		}
		_ignoreSelectionChanges = false;
		OnPropertyChanged("ItemsCountText");
		OnPropertyChanged("ActiveItemName");
		OnPropertyChanged("DropTarget");
		OnPropertyChanged("IsPresentationAvailable");
	}

	private void UpdateFilteredCues()
	{
		CueCollectionView.Refresh();
		HiddenCueCollectionView.Refresh();
		OnPropertyChanged("ItemsCountText");
	}

	private bool FilterCues(IProPresenterCueVM cueVM, bool showHidden)
	{
		if (!string.IsNullOrWhiteSpace(FilterText) && !cueVM.Cue.Name.ToLowerInvariant().Contains(FilterText.ToLowerInvariant()))
		{
			return false;
		}
		return showHidden == cueVM.Cue.IsHidden;
	}

	private void CueCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		OnPropertyChanged("ItemsCountText");
	}

	protected void OnCueRemovedBySync(ProPresenter.DO.Librarian.ILibrary library, DocumentCue documentRemoved)
	{
		IProPresenterCueVM proPresenterCueVM = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == documentRemoved);
		if (ActiveLibrary == library && proPresenterCueVM != null && ActiveCue == proPresenterCueVM)
		{
			int num = _cueVms.IndexOf(proPresenterCueVM);
			ActiveCue = _cueVms.ElementAtOrDefault(num + 1) ?? _cueVms.ElementAtOrDefault(num - 1);
			SelectedCues.Remove(proPresenterCueVM);
			if (ActiveCue != null && !SelectedCues.Contains(ActiveCue))
			{
				SelectedCues.Add(ActiveCue);
			}
		}
		else
		{
			_ = _manager.ActivePlaylistItem;
			_ = documentRemoved;
		}
	}

	private void OnActiveCueChanged(IProPresenterCueVM? newValue)
	{
		if (_ignoreSelectionChanges)
		{
			return;
		}
		if (newValue is DocumentCue documentCue)
		{
			documentCue.DocumentAction?.EnsurePresentationResolved(_libraryService.Libraries);
		}
		if (ActivePlaylist is Playlist<ProPresenterCue> activePlaylist)
		{
			_libraryService.ActivePlaylist = activePlaylist;
		}
		_manager.ActivePlaylistItem = newValue?.Cue;
		_app.SelectedCueID = newValue?.Cue.ID ?? Guid.Empty;
		if (ActivePlaylist != null)
		{
			ChangeUndoStack(Playlists?.UndoStack);
		}
		ReflowTargetCue = null;
		UseContextMenuReflowTarget = false;
		if (_manager?.MultiTracksConsumer?.IsAuthorized == true && newValue is IDocumentCue documentCue2 && documentCue2.DocumentAction?.Presentation != null && documentCue2.DocumentAction.PresentationType == PresentationType.MultiTracks)
		{
			IDocumentAction? documentAction = documentCue2.DocumentAction;
			if (documentAction != null && !documentAction.Presentation.IsAvailable)
			{
				_manager.MultiTracksConsumer.RefreshAuthorization((MultiTracksPresentation)documentCue2.DocumentAction.Presentation, consumeCredit: false);
			}
		}
	}

	private static void AddToPlaylist(DocumentCue documentCue, IPlaylist<ProPresenterCue> playlist)
	{
		(playlist as GeneralPlaylist)?.AddPresentationItem((DocumentCue)documentCue.Clone());
	}

	private void AddToSelectedPlaylist(DocumentCue documentCue)
	{
		if (ActiveGeneralPlaylist != null)
		{
			ActiveGeneralPlaylist.AddPresentationItem((DocumentCue)documentCue.Clone());
		}
		else if (ActivePCOPlaylist != null)
		{
			ActivePCOPlaylist.AddPresentationItem((DocumentCue)documentCue.Clone());
		}
		else
		{
			_prompt.ShowNoPlaylistSelected();
		}
	}

	private bool AddNewPresentation()
	{
		ChangeUndoStack(Libraries.UndoStack);
		string name = NewPresentationVM.Name;
		if (!LibraryHelper.ValidateName(Path.Combine(CommonPaths.Libraries, NewPresentationVM.SelectedLibrary.Name), _messageDialogService.ShowAlert, name, ".pro", delegate
		{
			name = name.DuplicateName(NewPresentationVM.SelectedLibrary, (DocumentCue c) => c.Name);
		}))
		{
			return false;
		}
		CustomPresentation customPresentation = _presentationFactory.CreateCustom(NewPresentationVM.SelectedTemplate);
		customPresentation.Name = NewPresentationVM.Name;
		customPresentation.UndoStack.StartIgnoring();
		SlideCue newCue = customPresentation.AddCue();
		ApplyTemplateMediaActionOnNewCue(newCue, customPresentation);
		customPresentation.ChangeSize(NewPresentationVM.Size);
		customPresentation.UndoStack.StopIgnoring();
		DocumentCue documentCue = NewPresentationVM.SelectedLibrary.Add(customPresentation, userInitiated: true);
		if (NewPresentationVM.CanSelectPlaylist)
		{
			if (NewPresentationVM.SelectedPlaylist is GeneralPlaylist generalPlaylist)
			{
				generalPlaylist.AddPresentationItem(documentCue);
			}
			else if (NewPresentationVM.SelectedPlaylist is PCOPlaylist pCOPlaylist)
			{
				pCOPlaylist.AddPresentationItem(documentCue);
			}
		}
		NewPresentationEventArgs args = new NewPresentationEventArgs(documentCue);
		this.NewPresentationCreated?.Invoke(args);
		if (args.ShouldActivate)
		{
			ActiveLibrary = NewPresentationVM.SelectedLibrary;
			if (NewPresentationVM.SelectedPlaylist != null)
			{
				ActivePlaylist = NewPresentationVM.SelectedPlaylist;
			}
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == args.Document);
		}
		NewPresentationVM.CanSelectPlaylist = true;
		return true;
	}

	private void ApplyTemplateMediaActionOnNewCue(SlideCue newCue, CustomPresentation presentation)
	{
		if (_applyTemplateMediaAction)
		{
			newCue.ApplyTemplateMediaAction(presentation.ActiveTemplate);
		}
	}

	private void OnAddNewLibraryCommand()
	{
		RenameNextItem = true;
		ActiveLibrary = Libraries.Add(_localization.Get("LIBRARY_PLAYLIST_NEW_LIBRARY_name"));
	}

	private void OnDeleteLibraryCommand(IEnumerable<ProPresenter.DO.Librarian.ILibrary> libraries)
	{
		if (!_prompt.ConfirmDeleteLibraries())
		{
			return;
		}
		int index = libraries.Min((ProPresenter.DO.Librarian.ILibrary l) => Libraries.IndexOf(l)) - 1;
		ProPresenter.DO.Librarian.ILibrary library = (libraries.ContainsAll(Libraries) ? Libraries.FirstOrDefault() : null);
		ProPresenter.DO.Librarian.ILibrary[] array = libraries.ToArray();
		foreach (ProPresenter.DO.Librarian.ILibrary library2 in array)
		{
			if (library2.Contains(ActiveCue?.Cue))
			{
				ActiveCue = null;
			}
			if (library2 != library)
			{
				Libraries.Remove(library2);
			}
		}
		ProPresenter.DO.Librarian.Library.GetAllTrackedMedia((from x in libraries.OfType<ProPresenter.DO.Librarian.Library>().SelectMany((ProPresenter.DO.Librarian.Library x) => x.SortedItems)
			select x.DocumentAction.Presentation).NonNull().ToArray()).ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		SelectedLibraries.Clear();
		ActiveLibrary = Libraries.ElementAtOrDefault(index) ?? Libraries.FirstOrDefault();
		if (ActiveCue == null)
		{
			_manager.ActiveLibrary = null;
		}
		if (ActiveLibrary != null)
		{
			SelectedLibraries.Add(ActiveLibrary);
		}
	}

	private void OnDeletePlaylistCommand(IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		Playlists.UndoStack?.BeginCommit(UndoActionTypes.RemovePlaylist.ToAction());
		IPlaylist<ProPresenterCue>[] array = playlists.ToArray();
		foreach (IPlaylist<ProPresenterCue> playlist in array)
		{
			if (ActiveCue != null)
			{
				Playlist<ProPresenterCue> obj = playlist as Playlist<ProPresenterCue>;
				if (obj != null && obj.Contains(ActiveCue.Cue))
				{
					ActiveCue = null;
				}
			}
			if (playlist.Parent == null)
			{
				Playlists.RemovePlaylist(playlist);
			}
			else if (playlist.Parent is GroupPlaylist<ProPresenterCue> groupPlaylist)
			{
				groupPlaylist.RemoveChild(playlist);
			}
		}
		Playlists.UndoStack?.EndCommit(null, null, autoFinalize: true);
		ChangeUndoStack(Playlists?.UndoStack);
	}

	private void OnDuplicatePlaylistCommand(IEnumerable<IPlaylist<ProPresenterCue>> playlists)
	{
		Playlists.Duplicate(playlists);
		ChangeUndoStack(Playlists?.UndoStack);
	}

	private void OnDropFilesCommand(DropFilesCommandParameters parameter)
	{
		IPlaylist<ProPresenterCue> playlist = parameter.TargetPlaylist as Playlist<ProPresenterCue>;
		IPlaylist<ProPresenterCue> targetPlaylist = playlist ?? ActivePlaylist;
		int index = parameter.DropIndex;
		if (parameter.RemoteFile != null)
		{
			parameter.RemoteFile.DownloadFile(delegate(FileInfo f)
			{
				doImport(new FileImportRequest[1]
				{
					new FileImportRequest(f.FullName)
				});
			});
		}
		else
		{
			parameter.Filenames.ThrowWhenNull("parameter.Filenames");
			doImport(parameter.Filenames.Select((string f) => new FileImportRequest(f)).ToArray());
		}
		void doImport(FileImportRequest[] requests)
		{
			IImportProcess process = _importProcessFactory.Create(requests, null, allowSelectPlaylist: false);
			process.SelectedLibrary = parameter.TargetLibrary ?? ActiveLibrary;
			process.SelectedPlaylist = targetPlaylist;
			if (requests.Any((FileImportRequest r) => r.FileExtension.IsOpenXmlPowerPointFile()))
			{
				bool? flag = _powerPointImportOptionsDialog.ShowLegacyPowerPointImportOptions();
				if (!flag.HasValue)
				{
					return;
				}
				process.PowerPointInfo = new PowerPointInfo(flag.Value, IgnoreBackgrounds: false);
			}
			foreach (FileImportRequest request in requests)
			{
				request.ShouldAddItemToPlaylist = false;
				request.CompleteCallback = delegate(string o, string n, FileMediaBase? createdMedia)
				{
					if (targetPlaylist != null)
					{
						if (n.IsMediaFile())
						{
							if (createdMedia != null)
							{
								if (targetPlaylist is GeneralPlaylist generalPlaylist)
								{
									int num = index;
									index = num + 1;
									generalPlaylist.InsertMediaItem(createdMedia, num);
								}
								else if (targetPlaylist is PCOPlaylist pCOPlaylist)
								{
									int num = index;
									index = num + 1;
									pCOPlaylist.InsertMediaItem(createdMedia, num);
								}
							}
							else if (targetPlaylist is GeneralPlaylist generalPlaylist2)
							{
								int num = index;
								index = num + 1;
								generalPlaylist2.InsertMediaItem(n, num);
							}
							else if (targetPlaylist is PCOPlaylist pCOPlaylist2)
							{
								int num = index;
								index = num + 1;
								pCOPlaylist2.InsertMediaItem(n, num);
							}
						}
						else
						{
							ProPresenter.DO.Librarian.ILibrary selectedLibrary = process.SelectedLibrary;
							DocumentCue documentCue = selectedLibrary?.FirstOrDefault((DocumentCue c) => c.Name == Path.GetFileNameWithoutExtension(request.FinalName));
							if (documentCue != null)
							{
								if (targetPlaylist is GeneralPlaylist generalPlaylist3)
								{
									global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue> cues = new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>((DocumentCue)documentCue.Clone());
									int num = index;
									index = num + 1;
									generalPlaylist3.AddPresentationItem(cues, num);
								}
								else if (targetPlaylist is PCOPlaylist pCOPlaylist3)
								{
									global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue> cues2 = new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>((DocumentCue)documentCue.Clone());
									int num = index;
									index = num + 1;
									pCOPlaylist3.AddPresentationItem(cues2, num);
								}
							}
							else if (selectedLibrary?.Location != null)
							{
								DocumentCue item = new DocumentCue(new RelativePath(n));
								if (targetPlaylist is GeneralPlaylist generalPlaylist4)
								{
									global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue> cues3 = new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>(item);
									int num = index;
									index = num + 1;
									generalPlaylist4.AddPresentationItem(cues3, num);
								}
								else if (targetPlaylist is PCOPlaylist pCOPlaylist4)
								{
									global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue> cues4 = new global::_003C_003Ez__ReadOnlySingleElementList<ProPresenterCue>(item);
									int num = index;
									index = num + 1;
									pCOPlaylist4.AddPresentationItem(cues4, num);
								}
							}
						}
					}
				};
			}
			process.StartImport();
		}
	}

	private void OnDropPresentationsCommand((IEnumerable<IDocumentCueVM>, int, bool) p)
	{
		var (source, index, isCopying) = p;
		MoveToLibrary(Libraries.ElementAtOrDefault(index), isCopying, source.Select((IDocumentCueVM c) => c.Cue));
	}

	private void OnShowInLibraryCommand(IProPresenterCueVM cueVM)
	{
		if (!(cueVM is IDocumentCueVM documentCueVM))
		{
			return;
		}
		ProPresenter.DO.Librarian.ILibrary library;
		DocumentCue cue = Libraries.FindDocument(documentCueVM.Document.DocumentAction.Presentation?.SourceFile, out library);
		if (library != null && cue != null)
		{
			ActiveLibrary = library;
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == cue);
		}
	}

	private void OnMoveToLibraryCommand(ProPresenter.DO.Librarian.ILibrary library)
	{
		MoveToLibrary(library, isCopying: false);
	}

	private void OnAddToLibraryCommand(ProPresenter.DO.Librarian.ILibrary library)
	{
		MoveToLibrary(library, isCopying: true);
	}

	private void MoveToLibrary(ProPresenter.DO.Librarian.ILibrary? library, bool isCopying, IEnumerable<ProPresenterCue>? cues = null)
	{
		_003C_003Ec__DisplayClass276_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass276_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		CS_0024_003C_003E8__locals10.library = library;
		if (CS_0024_003C_003E8__locals10.library != null)
		{
			CS_0024_003C_003E8__locals10.applyToAll = false;
			CS_0024_003C_003E8__locals10.skip = false;
			CS_0024_003C_003E8__locals10.overwrite = false;
			CS_0024_003C_003E8__locals10.abort = false;
			ChangeUndoStack(Libraries.UndoStack);
			Libraries.MoveTo(ActiveLibrary, CS_0024_003C_003E8__locals10.library, selectCuesToMove(cues), ref CS_0024_003C_003E8__locals10.overwrite, ref isCopying);
		}
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass276_0._003C_003CMoveToLibrary_003Eg__selectCuesToMove_007C0_003Ed))]
		IEnumerable<DocumentCue> selectCuesToMove(IEnumerable<ProPresenterCue>? cues)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass276_0._003C_003CMoveToLibrary_003Eg__selectCuesToMove_007C0_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals10,
				_003C_003E3__cues = cues
			};
		}
	}

	private void OnAddToPlaylistCommand(Playlist<ProPresenterCue>? playlist)
	{
		if (playlist != null)
		{
			List<ProPresenterCue> list = new List<ProPresenterCue>();
			list.AddRange((from c in SelectedCues.OrderBy(_cueVms.IndexOf)
				select c.Cue).CloneItems());
			playlist.AddItems(new global::_003C_003Ez__ReadOnlyList<ProPresenterCue>(list));
		}
	}

	private void OnDropPlaylistFilesCommand(DropFilesCommandParameters parameters)
	{
		if (parameters.RemoteFile != null)
		{
			parameters.RemoteFile.DownloadFile(delegate(FileInfo f)
			{
				doImport(new FileImportRequest[1]
				{
					new FileImportRequest(f.FullName)
				});
			});
		}
		else
		{
			parameters.Filenames.ThrowWhenNull("parameters.Filenames");
			doImport(parameters.Filenames.Select((string f) => new FileImportRequest(f, new PlaylistImportData(PlaylistLocation.Library, overWritePlaylist: false, parameters.TargetPlaylist, parameters.DropIndex))).ToArray());
		}
		void doImport(FileImportRequest[] requests)
		{
			_importProcessFactory.Create(requests).StartImport();
		}
	}

	private void OnCopyCuesCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(SelectedCues.Where((IProPresenterCueVM c) => !(c.Cue is PCOCueBase pCOCueBase) || pCOCueBase.IsLinked).OrderBy(_cueVms.IndexOf).Select(sanitizeCue));
		static ProPresenterCue sanitizeCue(IProPresenterCueVM cueVM)
		{
			if (cueVM.Cue is PCOCueBase pCOCueBase2)
			{
				DocumentCue documentCue = pCOCueBase2.DocumentAction?.ToCue();
				if (documentCue != null)
				{
					return documentCue;
				}
				MediaCue mediaCue = pCOCueBase2.MediaAction?.ToCue();
				if (mediaCue != null)
				{
					return mediaCue;
				}
				HeaderCue headerCue = (pCOCueBase2 as IHeaderCue)?.HeaderAction.ToCue();
				if (headerCue != null)
				{
					return headerCue;
				}
			}
			return cueVM.Cue;
		}
	}

	private void OnPasteCuesCommand()
	{
		int index = (SelectedCues.Any() ? (((IEnumerable<IProPresenterCueVM>)SelectedCues).Max((Func<IProPresenterCueVM, int>)_cueVms.IndexOf) + 1) : 0);
		if (ActiveLibrary != null)
		{
			ClipboardManagerHelper.PasteIntoCollection<ProPresenter.DO.Librarian.ILibrary, ProPresenterCue>(ActiveLibrary, index);
		}
		else if (ActivePlaylist is Playlist<ProPresenterCue> collection)
		{
			ClipboardManagerHelper.PasteIntoCollection<Playlist<ProPresenterCue>, ProPresenterCue>(collection, index);
		}
	}

	private void OnDuplicateCuesCommand()
	{
		OnCopyCuesCommand();
		OnPasteCuesCommand();
	}

	private void OnDeleteCuesCommand()
	{
		IProPresenterCueVM[] array = SelectedCues.Where((IProPresenterCueVM c) => c.Cue.Type != CueType.PCO).ToArray();
		if (array.Length == 0)
		{
			return;
		}
		int index = array.Min((IProPresenterCueVM c) => _cueVms.IndexOf(c)) - 1;
		if (ActivePlaylist is Playlist<ProPresenterCue> playlist)
		{
			List<ProPresenterCue> list = new List<ProPresenterCue>();
			list.AddRange(array.Select((IProPresenterCueVM c) => c.Cue));
			playlist.RemoveItems(new global::_003C_003Ez__ReadOnlyList<ProPresenterCue>(list));
			ChangeUndoStack(Playlists?.UndoStack);
		}
		else
		{
			if (!_prompt.ConfirmDeletePresentation(array.Select((IProPresenterCueVM c) => c.Cue.Name).ToArray()))
			{
				return;
			}
			ProPresenter.DO.Librarian.ILibrary? activeLibrary = ActiveLibrary;
			if (activeLibrary != null)
			{
				List<DocumentCue> list2 = new List<DocumentCue>();
				list2.AddRange(array.Select((IProPresenterCueVM c) => c.Cue).OfType<DocumentCue>());
				activeLibrary.Remove(new global::_003C_003Ez__ReadOnlyList<DocumentCue>(list2));
			}
			ChangeUndoStack(Libraries.UndoStack);
		}
		ActiveCue = _cueVms.ElementAtOrDefault(index) ?? _cueVms.FirstOrDefault();
		SelectedCues.Clear();
		if (ActiveCue != null)
		{
			SelectedCues.Add(ActiveCue);
		}
	}

	private void SelectTemplateCommandExecuted(TemplateSlide template)
	{
		TemplateHelper.AssignTemplateToSelectedPresentation(template, (from d in SelectedActiveCues
			select d.DocumentAction?.Presentation into p
			where p != null
			select p).OfType<CustomPresentation>().ToArray(), _applyTemplateMediaAction);
	}

	private void OnSelectArrangementCommand(Arrangement arrangement)
	{
		if (SelectedCue is IDocumentCueVM { DocumentAction: not null } documentCueVM)
		{
			documentCueVM.DocumentAction.ActiveArrangement = arrangement;
		}
	}

	private void OnTriggerMediaItemCommand(MediaCue mediaCue)
	{
		if (!(ActivePlaylist is Playlist<ProPresenterCue> playlist))
		{
			return;
		}
		MediaType? mediaType = mediaCue.MediaAction?.Media.MediaType;
		if (mediaType.HasValue)
		{
			switch (mediaType.GetValueOrDefault())
			{
			case MediaType.Image:
			case MediaType.Video:
			case MediaType.LiveVideo:
				_service.TriggerBackground(mediaCue, playlist, CueLocation.PlaylistLibrary);
				break;
			case MediaType.Audio:
				_service.TriggerAudio(mediaCue, playlist, CueLocation.PlaylistLibrary);
				break;
			}
		}
	}

	private void OnRefreshPCOPlaylistCommand()
	{
		if (!_internetAccess.IsInternetAvailable())
		{
			_prompt.ShowNoInternet();
			return;
		}
		IEnumerable<PCOPlaylist> source = SelectedPlaylists.OfType<PCOPlaylist>();
		if (source.Empty() && ActivePlaylist is PCOPlaylist item)
		{
			source = item.ToEnumerable();
		}
		foreach (PCOPlaylist playlist in source.Where((PCOPlaylist p) => p.PCOPlan != null))
		{
			_manager.PCOConsumer.RefreshPCOPlanAsync(playlist.PCOPlan).ContinueWith(delegate(Task<PlanRefreshResult> refreshPlanTask)
			{
				PlanRefreshResult result = refreshPlanTask.Result;
				if (result.Success)
				{
					_uiDispatcher.Invoke(delegate
					{
						if (result.PlanDetail != null)
						{
							playlist.Refresh(result.PlanDetail);
							_libraryService.MatchSongsInteractor.Execute(result.PlanDetail, playlist);
							ProPresenterCue proPresenterCue = playlist.FirstOrDefault();
							if (proPresenterCue != null)
							{
								ActiveCue = _cueVmFactory.Create(proPresenterCue);
							}
							else
							{
								ActiveCue = null;
							}
						}
						else
						{
							Playlists.RemovePlaylist(playlist);
							_manager.PCOConsumer.IsPCOBusy = false;
							_manager.PCOConsumer.PCOBusyMessage = string.Empty;
						}
					});
				}
			}).ExecuteAsync();
		}
	}

	private void OnConvertPCOPlaylistCommand()
	{
		IEnumerable<PCOPlaylist> pcoPlaylists = SelectedPlaylists.OfType<PCOPlaylist>();
		Playlists.UndoStack?.BeginCommit(UndoActionTypes.ConvertPCOPlaylist.ToAction());
		IEnumerable<GeneralPlaylist> source = Playlists.ConvertToStandardPlaylist(pcoPlaylists);
		IPlaylist<ProPresenterCue> originalPlaylist = ActivePlaylist;
		GeneralPlaylist convertedPlaylist = source.LastOrDefault();
		Playlists.UndoStack?.Commit(delegate
		{
			setActivePlaylist(originalPlaylist);
		}, delegate
		{
			setActivePlaylist(convertedPlaylist);
		});
		setActivePlaylist(convertedPlaylist);
		Playlists.UndoStack?.EndCommit(null, null, autoFinalize: true);
		void setActivePlaylist(IPlaylist<ProPresenterCue>? playlist)
		{
			ActivePlaylist = playlist;
			ActiveCue = _cueVms.FirstOrDefault();
		}
	}

	private void OnAddNewHeaderCommand()
	{
		RenameNextItem = true;
		if (ActiveGeneralPlaylist != null)
		{
			ProPresenterCue header = ActiveGeneralPlaylist.AddHeaderPlaylistItem(_localization.Get("LIBRARY_PLAYLIST_NEW_HEADER_name"), ActiveGeneralPlaylist.FilteredItems.IndexOf(ActiveCue?.Cue));
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == header);
		}
		else if (ActivePCOPlaylist != null)
		{
			HeaderCue header2 = ActivePCOPlaylist.AddHeaderPlaylistItem(_localization.Get("LIBRARY_PLAYLIST_NEW_HEADER_name"), ActivePCOPlaylist.FilteredItems.IndexOf(ActiveCue?.Cue));
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == header2);
		}
	}

	private void OnAddNewPlaceholderCommand()
	{
		RenameNextItem = true;
		if (ActiveGeneralPlaylist != null)
		{
			ProPresenterCue placeholder = ActiveGeneralPlaylist.AddPlaceholderPlaylistItem(_localization.Get("LIBRARY_PLAYLIST_NEW_PLACEHOLDER_name"), ActiveGeneralPlaylist.FilteredItems.IndexOf(ActiveCue?.Cue));
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == placeholder);
		}
		else if (ActivePCOPlaylist != null)
		{
			ProPresenterCue placeholder2 = ActivePCOPlaylist.AddPlaceholderPlaylistItem(_localization.Get("LIBRARY_PLAYLIST_NEW_PLACEHOLDER_name"), ActivePCOPlaylist.FilteredItems.IndexOf(ActiveCue?.Cue));
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == placeholder2);
		}
	}

	private void OnAddNewGroupPlaylistCommand()
	{
		RenameNextItem = true;
		ActivePlaylist = Playlists.AddNewGroupPlaylist(FindCurrentGroup(), FindInsertIndex());
	}

	private void OnAddNewPlaylistCommand()
	{
		RenameNextItem = true;
		ActivePlaylist = Playlists.AddNewPlaylist("", FindCurrentGroup(), FindInsertIndex());
	}

	private void AddPlaylistFromTemplateCommandExecuted(GeneralPlaylist template)
	{
		GeneralPlaylist generalPlaylist = (GeneralPlaylist)template.Clone();
		ProPresenterCue[] array = generalPlaylist.ToArray();
		foreach (ProPresenterCue proPresenterCue in array)
		{
			if (!(proPresenterCue is DocumentCue documentCue))
			{
				if (!(proPresenterCue is MediaCue mediaCue))
				{
					if (proPresenterCue is PlaceholderCue { IsLinked: not false } placeholderCue && ((placeholderCue.MediaAction != null && File.Exists(placeholderCue.MediaAction.FileMedia?.SourceFile)) || (placeholderCue.DocumentAction != null && Libraries.FindDocument(placeholderCue.DocumentAction?.Presentation?.SourceFile) == null)))
					{
						placeholderCue.PlaceholderAction.Unlink();
					}
				}
				else if (!File.Exists(mediaCue.MediaAction.FileMedia?.SourceFile))
				{
					generalPlaylist.ReplaceItem(proPresenterCue, _cueFactory.CreatePlaceholder(mediaCue.MediaAction.Name));
				}
			}
			else
			{
				ProPresenterCue proPresenterCue2 = Libraries.FindDocument(documentCue.DocumentAction?.Presentation?.SourceFile)?.Clone() as ProPresenterCue;
				if (proPresenterCue2 == null)
				{
					proPresenterCue2 = _cueFactory.CreatePlaceholder(documentCue.DocumentAction?.Name ?? documentCue.Name);
				}
				generalPlaylist.ReplaceItem(proPresenterCue, proPresenterCue2);
			}
		}
		Playlists.AddPlaylist(generalPlaylist);
		ActivePlaylist = generalPlaylist;
	}

	private void OnExportPlaylistCommand(IPlaylist<ProPresenterCue>? playlist)
	{
		if (playlist == null)
		{
			playlist = ActivePlaylist;
		}
		IPlaylist<ProPresenterCue>[] array = SelectedPlaylists.Concat<IPlaylist<ProPresenterCue>>(playlist.ToEnumerable()).NonNull().Distinct((IPlaylist<ProPresenterCue> i) => i.ID)
			.ToArray();
		IPlaylist<ProPresenterCue>[] array2 = array.Where((IPlaylist<ProPresenterCue> p) => p.Type == PlaylistType.PCO).ToArray();
		foreach (IPlaylist<ProPresenterCue> playlist2 in array2)
		{
			GeneralPlaylist generalPlaylist = ((PCOPlaylist)playlist2).ConvertToStandardPlaylist(Playlists.UndoStack, _entityFactory, _logger, _cueFactory);
			if (generalPlaylist == null)
			{
				return;
			}
			array[array.IndexOf(playlist2)] = generalPlaylist;
		}
		_libraryService.Export.Playlists(array);
	}

	private void OnExportToTextCommand()
	{
		_libraryService.Export.ToText(SelectedActiveCues);
	}

	private void OnExportToPro7Command()
	{
		_libraryService.Export.Presentations(SelectedActiveCues);
	}

	private void OnExportToBundleCommand()
	{
		_libraryService.Export.ToBundle(SelectedActiveCues);
	}

	public PCOPlaylist AddPCOPlaylist(PCOPlan pcoPlan)
	{
		PCOPlaylist pCOPlaylist = Playlists.AddNewPCOPlaylist(pcoPlan, FindCurrentGroup(), FindInsertIndex());
		ProPresenterCue proPresenterCue = pCOPlaylist.FirstOrDefault();
		if (proPresenterCue != null)
		{
			ActiveCue = _cueVmFactory.Create(proPresenterCue);
			return pCOPlaylist;
		}
		ActiveCue = null;
		return pCOPlaylist;
	}

	private GeneralGroupPlaylist? FindCurrentGroup()
	{
		return (SelectedPlaylist as GeneralGroupPlaylist) ?? (ActivePlaylist?.Parent as GeneralGroupPlaylist);
	}

	private int FindInsertIndex()
	{
		if (SelectedPlaylists.FirstOrDefault() is GeneralGroupPlaylist generalGroupPlaylist)
		{
			return generalGroupPlaylist.Count;
		}
		if (ActivePlaylist == null)
		{
			return Playlists.Count;
		}
		if (ActivePlaylist.Type == PlaylistType.Group)
		{
			return -1;
		}
		if (ActivePlaylist.Parent == null)
		{
			return Playlists.IndexOf(ActivePlaylist) + 1;
		}
		return ((ActivePlaylist.Parent as GeneralGroupPlaylist)?.IndexOf(ActivePlaylist) ?? (-2)) + 1;
	}

	private string GetTotalPlayLength()
	{
		return TimeSlice.FromMinutes((from m in (from vm in _cueVms.OfType<IMediaCueVM>()
				select vm.Cue).OfType<IMediaCue>()
			where m.MediaAction != null
			select m).Sum((IMediaCue m) => m.MediaAction.MediaDuration.TotalMinutes)).GetFormattedTotalLength();
	}

	protected void OnImportCompleted(IImportProcess process)
	{
		if (process.ImportCanceled)
		{
			return;
		}
		IImportRequest importRequest = process.SelectionRequest ?? (from r in process.CompletedRequests
			where !string.IsNullOrWhiteSpace(r.FinalName)
			orderby r.FinalName
			select r).FirstOrDefault();
		ProPresenter.DO.Librarian.ILibrary targetLibrary = (importRequest as FileImportRequest)?.TargetLibrary;
		bool wasTargetLibrarySpecified = targetLibrary != null;
		targetLibrary = targetLibrary ?? process.SelectedLibrary;
		string requestName = importRequest?.FinalName ?? string.Empty;
		IPlaylist<ProPresenterCue> playlist = process.SelectedPlaylist;
		_uiDispatcher.InvokeAsync(delegate
		{
			OnPropertyChanged("SelectedCue");
		}, (DispatcherPriority)4);
		ProPresenterCue cue;
		if (targetLibrary != null && importRequest != null)
		{
			cue = findCue();
			if (cue != null)
			{
				setImportSelection();
			}
			else
			{
				targetLibrary.CollectionChanged += onLibraryCollectionChanged;
			}
			if (process.AllowSelectPlaylist)
			{
				AddImportedDocumentsToPlaylist(playlist, process.CompletedRequests.OfType<FileImportRequest>(), process.SelectedLibrary);
			}
		}
		ProPresenterCue? findCue()
		{
			return playlist?.FirstOrDefault((ProPresenterCue c) => c.Name == requestName) ?? targetLibrary.FirstOrDefault((DocumentCue c) => c.Name == requestName);
		}
		void onLibraryCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
		{
			cue = findCue();
			if (cue != null)
			{
				setImportSelection();
				targetLibrary.CollectionChanged -= onLibraryCollectionChanged;
			}
		}
		void setImportSelection()
		{
			bool flag = false;
			if (playlist != null)
			{
				ActivePlaylist = playlist;
				if (ActivePlaylist is GeneralPlaylist source)
				{
					flag = source.Any((ProPresenterCue c) => c.Name == cue.Name);
				}
			}
			else if (wasTargetLibrarySpecified || ActivePlaylist == null)
			{
				ActiveLibrary = targetLibrary;
				flag = ActiveLibrary?.Any((DocumentCue d) => d.Name == cue.Name) ?? false;
			}
			if (flag)
			{
				ActiveCue = _cueVmFactory.Create(cue);
			}
		}
	}

	private static void AddImportedDocumentsToPlaylist(IPlaylist<ProPresenterCue>? playlist, IEnumerable<FileImportRequest> importRequests, ProPresenter.DO.Librarian.ILibrary? fallbackLibrary)
	{
		if (!(playlist is GeneralPlaylist generalPlaylist))
		{
			return;
		}
		foreach (FileImportRequest importRequest in importRequests.Where((FileImportRequest f) => !string.IsNullOrEmpty(f.FinalName) && f.FullName.IsProPresentationFile()))
		{
			ProPresenter.DO.Librarian.ILibrary library = importRequest.TargetLibrary ?? fallbackLibrary;
			if (importRequest.ShouldAddItemToPlaylist && library != null)
			{
				ProPresenterCue proPresenterCue = library.FirstOrDefault((DocumentCue d) => d.Name == importRequest.FinalName) ?? new DocumentCue(new RelativePath(Path.Combine(CommonPaths.Libraries, library.Name, importRequest.FinalName + importRequest.FileExtension)));
				RelativePath value = (proPresenterCue as DocumentCue)?.DocumentAction?.DocumentPath;
				if (!generalPlaylist.Select((ProPresenterCue c) => (c as DocumentCue)?.DocumentAction?.DocumentPath).NonNull().Contains(value))
				{
					generalPlaylist.AddItem(proPresenterCue);
				}
			}
		}
	}

	private void OnShowTriggered(OutputDestination destination)
	{
		ProPresenter.DO.Presentation.IPresentation presentation = _manager.ActiveSlides[destination]?.Source.ParentPresentation;
		if (presentation != null)
		{
			ProPresenter.DO.Librarian.ILibrary library;
			DocumentCue documentCue = Libraries.FindDocument(presentation.SourceFile, out library);
			if (documentCue != null)
			{
				ActiveLibrary = library;
				ActiveCue = _cueVmFactory.Create(documentCue);
				SelectedCues.Clear();
				SelectedCues.Add(ActiveCue);
			}
		}
	}

	private void OnRevealInLibraryCommand()
	{
		if (ActiveDocumentCue?.DocumentAction?.Presentation == null)
		{
			return;
		}
		ProPresenter.DO.Librarian.ILibrary library;
		DocumentCue targetCue = Libraries.FindDocument(ActiveDocumentCue.DocumentAction.Presentation.SourceFile, out library);
		if (targetCue != null)
		{
			ActiveLibrary = library;
			SelectedCues.Clear();
			IProPresenterCueVM proPresenterCueVM = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == targetCue);
			if (proPresenterCueVM != null)
			{
				SelectedCues.Add(proPresenterCueVM);
			}
		}
	}

	private void OnGotFocusCommand(DependencyObject newFocus)
	{
		PlaylistTreeView? playlistTreeView = newFocus.FindVisualParent<PlaylistTreeView>();
		LibraryListBox libraryListBox = newFocus.FindVisualParent<LibraryListBox>();
		ProPresenter.DO.Presentation.IPresentation presentation = (ActiveCue as IDocumentCue)?.DocumentAction?.Presentation;
		UndoStack undoStack = ((playlistTreeView != null) ? Playlists.UndoStack : ((libraryListBox != null) ? Libraries.UndoStack : presentation?.UndoStack));
		ChangeUndoStack(undoStack);
	}

	private void OnLibraryNavigationCrestedCommand()
	{
		IPlaylist<ProPresenterCue> item = (ActivePlaylist = Playlists.GetPlaylists().First());
		SelectedPlaylists.Clear();
		SelectedPlaylists.Add(item);
	}

	private void OnPlaylistNavigationCrestedCommand()
	{
		ProPresenter.DO.Librarian.ILibrary item = (ActiveLibrary = Libraries.Last());
		SelectedLibraries.Clear();
		SelectedLibraries.Add(item);
	}

	private void OnChangeHeaderColorCommand(System.Windows.Media.Color selectedColor)
	{
		SelectedCues.OfType<IHeaderCueVM>().ForEach(delegate(IHeaderCueVM c)
		{
			c.HeaderAction.Color = selectedColor;
		});
	}

	private void OnToggleVisibilityCommand(IProPresenterCueVM cueVm, bool isHidden)
	{
		if (SelectedCues.Any((IProPresenterCueVM c) => c.Cue == cueVm.Cue))
		{
			SelectedCues.ForEach(delegate(IProPresenterCueVM c)
			{
				c.Cue.IsHidden = isHidden;
			});
		}
		else
		{
			cueVm.Cue.IsHidden = isHidden;
		}
		UpdateFilteredCues();
	}

	private void OnUnhideAllItems()
	{
		(ActivePlaylist as Playlist<ProPresenterCue>)?.ForEach(delegate(ProPresenterCue c)
		{
			c.IsHidden = false;
		});
		UpdateFilteredCues();
	}

	private void ChangeUndoStack(UndoStack? undoStack)
	{
		if (undoStack != null)
		{
			this.StackChanged?.Invoke(undoStack);
		}
	}

	private bool AreAnyCuesSelected()
	{
		return SelectedCues.Any();
	}

	private bool CanModifyCue()
	{
		return SelectedCues.Any((IProPresenterCueVM c) => c.Cue.Type != CueType.PCO);
	}

	private bool AreAnyActiveCuesSelected()
	{
		return SelectedActiveCues.Any();
	}

	private bool OnCanExportAsText()
	{
		List<IDocumentCue> list = SelectedActiveCues.ToList();
		List<IDocumentCue> list2 = list.Where((IDocumentCue c) => c.DocumentAction?.Presentation is MultiTracksPresentation).ToList();
		if (list2.Count != 0)
		{
			if (list.Count != 0)
			{
				return list2.All((IDocumentCue c) => ((MultiTracksPresentation)c.DocumentAction.Presentation).IsAvailable);
			}
			return false;
		}
		return list.Count != 0;
	}

	private void OnMultiTracksConsumerSubscriptionAuthorizationUpdated()
	{
		OnPropertyChanged("IsPresentationAvailable");
		if (_manager?.MultiTracksConsumer?.IsAuthorized != true)
		{
			return;
		}
		if (ActivePlaylist is Playlist<ProPresenterCue> { Type: not PlaylistType.Group } playlist)
		{
			(from d in (from d in playlist.OfType<IDocumentCue>()
					where d.DocumentAction?.Presentation != null && d.DocumentAction.PresentationType == PresentationType.MultiTracks && !d.DocumentAction.Presentation.IsAvailable
					select d).Distinct((IDocumentCue d) => d.DocumentAction.Presentation.ID)
				select (MultiTracksPresentation)d.DocumentAction.Presentation).ToArray().ForEach(delegate(MultiTracksPresentation p)
			{
				_manager.MultiTracksConsumer.RefreshAuthorization(p, consumeCredit: false);
			});
		}
		else if (ActiveCue is IDocumentCue documentCue)
		{
			IDocumentAction? documentAction = documentCue.DocumentAction;
			if (documentAction != null && documentAction.PresentationType == PresentationType.MultiTracks && !(documentCue.DocumentAction?.Presentation?.IsAvailable ?? true))
			{
				_manager.MultiTracksConsumer.RefreshAuthorization((MultiTracksPresentation)documentCue.DocumentAction.Presentation, consumeCredit: false);
			}
		}
	}

	public void ChangeSize(Vector2<double> size)
	{
		SizeableTargets.ForEach(delegate(ISizeableTarget p)
		{
			p.ChangeSize(size);
		});
		OnPropertyChanged("Size");
	}

	private void OnChangeOutputDestinationCommandExecuted(OutputDestination destination)
	{
		List<IDocumentCueVM> source = SelectedCues.OfType<IDocumentCueVM>().ToList();
		if (!source.Any())
		{
			return;
		}
		foreach (IDocumentCueVM item in source.Where((IDocumentCueVM c) => c.DocumentAction != null))
		{
			item.DocumentAction.Destination = destination;
		}
		UpdateSelectedCuesDestination();
	}

	private static void OnUnlinkItemCommandExecute(IProPresenterCueVM cueVm)
	{
		if (cueVm.Cue is PlaceholderCue placeholderCue)
		{
			placeholderCue.PlaceholderAction?.Unlink();
		}
		if (cueVm.Cue is PCOCueBase pCOCueBase)
		{
			pCOCueBase.UnlinkItem();
		}
	}

	private bool OnUnlinkItemCommandCanExecute(IProPresenterCueVM cueVm)
	{
		if (cueVm == null || SelectedCues.Count() > 1)
		{
			return false;
		}
		if (cueVm.Cue is ILinkableCue linkableCue)
		{
			return linkableCue.IsLinked;
		}
		return false;
	}

	private bool OnCopyCuesCommandCanExecute()
	{
		if (AreAnyCuesSelected())
		{
			return CanModifyCue();
		}
		return false;
	}

	private bool OnPasteCuesCommandCanExecute()
	{
		if (ActivePCOPlaylist != null)
		{
			return false;
		}
		if (ClipboardManagerHelper.CanPasteIntoCollection<ProPresenterCue>())
		{
			if (ActiveLibrary == null)
			{
				return ActivePlaylist != null;
			}
			return true;
		}
		return false;
	}

	private bool OnDuplicateOrDeleteCuesCommandCanExecute()
	{
		if (!AreAnyCuesSelected() || !CanModifyCue())
		{
			return false;
		}
		if (ActiveLibrary == null)
		{
			return ActivePlaylist != null;
		}
		return true;
	}

	private void DropProContentAssetCommandExecuted(ProContentDropParameter<GeneralPlaylist?> parameter)
	{
		IProContentDownloadableAsset asset = (IProContentDownloadableAsset)((IProContentAssetVMInternal)parameter.Asset).Asset;
		_proContentDownloader.ImportAssetAsync(asset, null, delegate(IDownloadObserverCallbackData data)
		{
			IDragDropCollection<ProPresenterCue> target = parameter.Target;
			if (target != null && data is ProContentDownloadObserveCallbackData proContentDownloadObserveCallbackData)
			{
				if (proContentDownloadObserveCallbackData.Cleanup)
				{
					parameter.Target.RemoveItems(proContentDownloadObserveCallbackData.MediaCue.ToEnumerable(), isReversible: false);
				}
				else
				{
					target.DroppedInto(proContentDownloadObserveCallbackData.MediaCue.ToEnumerable(), parameter.DropIndex, isCopy: false);
				}
			}
		}).ExecuteAsync();
	}

	private static bool CanDropAsset(ProContentDropParameter<GeneralPlaylist?> parameter)
	{
		if (parameter.Asset is IProContentAssetVMInternal proContentAssetVMInternal)
		{
			return proContentAssetVMInternal.Asset is IProContentDownloadableAsset;
		}
		return false;
	}

	private void OnSetMediaTargetLayerCommand(TriggerLayer triggerLayer)
	{
		if (SelectedCue?.Cue is IMediaCue mediaCue)
		{
			mediaCue.MediaAction.TriggerLayer = triggerLayer;
			OnPropertyChanged("SelectedCue");
		}
	}

	private IEnumerable<MediaCue> GetSelectedMediaCues()
	{
		return SelectedCues.Select((IProPresenterCueVM vm) => vm.Cue).OfType<MediaCue>() ?? Array.Empty<MediaCue>();
	}

	private void ChangeCueVmsSource(IDragDropNotifyEnumerableChanged<ProPresenterCue>? newSource, bool sortItems = false)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		_cueVmsWhenCollectionChangesSubscription?.Dispose();
		_cueVms.ClearSource();
		_cueVms = new DragDropPairedCollection<ProPresenterCue, IProPresenterCueVM>(newSource, _cueVmFactory.Create, delegate(IProPresenterCueVM c)
		{
			c.Dispose();
		}, (IProPresenterCueVM c) => c.Cue);
		CueCollectionView = new CollectionViewSource
		{
			Source = _cueVms
		}.View;
		CueCollectionView.Filter = (object c) => FilterCues((IProPresenterCueVM)c, showHidden: false);
		_cueVmsWhenCollectionChangesSubscription = _cueVms.WhenCollectionChanges().Subscribe(delegate
		{
			OnPropertyChanged("ItemsCountText");
		});
		HiddenCueCollectionView = new CollectionViewSource
		{
			Source = _cueVms
		}.View;
		HiddenCueCollectionView.Filter = (object c) => FilterCues((IProPresenterCueVM)c, showHidden: true);
		if (CueCollectionView is ListCollectionView listCollectionView)
		{
			listCollectionView.CustomSort = (sortItems ? new NaturalStringComparer<IProPresenterCueVM>((IProPresenterCueVM? d) => d?.Cue.Name ?? string.Empty) : null);
		}
		else
		{
			((Collection<SortDescription>)(object)CueCollectionView.SortDescriptions).Clear();
			if (sortItems)
			{
				((Collection<SortDescription>)(object)CueCollectionView.SortDescriptions).Add(new SortDescription("Name", ListSortDirection.Ascending));
			}
		}
		if (ActiveCue != null && !_cueVms.Contains(ActiveCue))
		{
			ActiveCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == ActiveCue.Cue);
		}
		SelectedCues.Clear();
		if (SelectedCue != null && !_cueVms.Contains(SelectedCue))
		{
			SelectedCue = _cueVms.FirstOrDefault((IProPresenterCueVM c) => c.Cue == SelectedCue.Cue);
			if (SelectedCue != null)
			{
				SelectedCues.Add(SelectedCue);
			}
		}
		OnPropertyChanged("DropTarget");
		OnPropertyChanged("CueCollectionView");
		OnPropertyChanged("HiddenCueCollectionView");
	}
}
