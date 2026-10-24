using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Descriptions;
using Pro.DO.Triggering;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Downloads;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Import.Results;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.DO.Transitions;
using ProPresenter.UI;
using ProPresenter.UI.ActionPalette;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.PresentationLibrary;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.QuickSearch;
using ProPresenter.ViewModels.Actions;
using ProPresenter.ViewModels.ProContent.Asset;
using ProPresenter.ViewModels.Props;
using ProPresenter.ViewModels.Settings.Pages.General;

namespace ProPresenter.ViewModels;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class PresentationVM : LinkedNotifyPropertyChangedBase, IPresentationVM, INotifyPropertyChanged, IDisposable
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IBibleProvider _bibleProvider;

	private readonly ILibraryVM _libraryVM;

	private readonly Action<string> _setSearchText;

	private readonly IProContentDownloader _proContentDownloader;

	private readonly IApp _app;

	private readonly UpdatingFilteredObservableCollection<ProPresenterCue> _filteredItems;

	private readonly IUiDispatcher _dispatcher;

	private readonly IActionDropOperation _dropOperation;

	private readonly IProPresenterResourceService _resourceService;

	private readonly Dictionary<string, (PlaceholderCue, ILibrary)> _pendingLinkDocuments = new Dictionary<string, (PlaceholderCue, ILibrary)>();

	private readonly ILayout _layout;

	private readonly IInputActions _inputActions;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IChangeWorkspaceHandler _supportFolderHandler;

	private readonly IFlagService _flagService;

	private ArrangedCue? _selectedSlide;

	private IPanelViewSettings? _presentationViewSettings;

	private bool _hideBackgroundImage;

	private TransitionParameters? _selectedTransition;

	private bool _forceFlipView;

	private Action? _togglePresentationView;

	private bool _scrollToCue = true;

	private bool _scrollToSlide;

	private IAction? _currentEditedAction;

	private IMultiTracksSearchService? _multiTracksSearchService;

	private bool _applyTemplateMediaAction;

	private bool _mediaBinShowsProContent;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private ICoreManager CoreManager => _manager;

	public IMultiTracksSearchService? MultiTracksSearchService
	{
		get
		{
			return _multiTracksSearchService;
		}
		set
		{
			SetValue<IMultiTracksSearchService>("MultiTracksSearchService", ref _multiTracksSearchService, value, delegate(IMultiTracksSearchService o, IMultiTracksSearchService n)
			{
				if (o != null)
				{
					o.Consumer.SubscriptionAuthorizationUpdated -= OnMultitracksConsumerSubscriptionUpdated;
				}
				if (n != null)
				{
					n.Consumer.SubscriptionAuthorizationUpdated += OnMultitracksConsumerSubscriptionUpdated;
				}
			});
		}
	}

	public IMediaLibraryVM MediaLibraryVM { get; }

	public IActionsMenuVM TimelineActionsMenuVM { get; }

	public int PresentationRowCapacity
	{
		get
		{
			return _app.PresentationRowCapacity;
		}
		set
		{
			_app.PresentationRowCapacity = value;
		}
	}

	public int ReflowRowCapacity
	{
		get
		{
			return _app.ReflowRowCapacity;
		}
		set
		{
			_app.ReflowRowCapacity = value;
		}
	}

	public double ReflowTextZoomLevel
	{
		get
		{
			return _app.ReflowTextZoomLevel;
		}
		set
		{
			_app.ReflowTextZoomLevel = value;
		}
	}

	public bool HideBackgroundImage
	{
		get
		{
			return _hideBackgroundImage;
		}
		set
		{
			SetValue("HideBackgroundImage", ref _hideBackgroundImage, value);
		}
	}

	public IPanelViewSettings? PresentationViewSettings
	{
		get
		{
			return _presentationViewSettings;
		}
		set
		{
			SetValue<IPanelViewSettings>("PresentationViewSettings", ref _presentationViewSettings, value, delegate(IPanelViewSettings o, IPanelViewSettings n)
			{
				if (n != null)
				{
					_app.PresentationPanelViewType = n.ViewType;
				}
			});
		}
	}

	public bool ScrollToCue
	{
		get
		{
			return _scrollToCue;
		}
		private set
		{
			SetValue("ScrollToCue", ref _scrollToCue, value);
		}
	}

	public bool ScrollToSlide
	{
		get
		{
			return _scrollToSlide;
		}
		private set
		{
			SetValue("ScrollToSlide", ref _scrollToSlide, value);
		}
	}

	public ArrangedCue? ActiveSlide => _manager.ActiveSlide;

	public ActiveCueCollection ActiveSlides => _manager.ActiveSlides;

	public ArrangedCue? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue("SelectedSlide", ref _selectedSlide, value);
		}
	}

	public ObservableCollection<ArrangedCue> SelectedSlides { get; } = new ObservableCollection<ArrangedCue>();

	public IEnumerable<ActionLabel> SlideLabels => _resourceService.SlideLabels;

	public IEnumerable<GroupLabel> GroupLabels => _resourceService.GroupLabels;

	public TransitionHandler TransitionHandler { get; private set; }

	public bool LibrariesContainPresentations => _libraryVM.Libraries.Any((ILibrary library) => library.Count > 0);

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			SetValue<TransitionParameters>("SelectedTransition", ref _selectedTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= OnSelectedTransitionPropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += OnSelectedTransitionPropertyChanged;
				}
				SetGlobalForegroundTransition();
			});
		}
	}

	public ssAPIOutput OutputController { get; }

	public bool IsContiguousActive => _manager.IsContiguousActive;

	public ProPresenterCue? ActiveSlideParent => _manager.ActiveSlideParent;

	public ProPresenterCue? ActivePlaylistItem
	{
		get
		{
			return _manager.ActivePlaylistItem;
		}
		set
		{
			ScrollToCue = false;
			ProPresenterCue proPresenterCue = _filteredItems.FirstOrDefault((ProPresenterCue x) => x == value);
			if (proPresenterCue != null)
			{
				_manager.ActivePlaylistItem = proPresenterCue;
			}
			ScrollToCue = true;
		}
	}

	public bool IsContiguousViewFocused => _filteredItems.Count() > 1;

	public INotifyEnumerableChanged<ProPresenterCue> Items
	{
		get
		{
			INotifyEnumerableChanged<ProPresenterCue> notifyEnumerableChanged = null;
			if (_manager.ActiveLibraryPlaylist != null)
			{
				if (_manager.ActiveLibraryPlaylist.Contains(_manager.ActivePlaylistItem))
				{
					INotifyEnumerableChanged<ProPresenterCue> notifyEnumerableChanged3;
					if (!_manager.IsContiguousActive)
					{
						INotifyEnumerableChanged<ProPresenterCue> notifyEnumerableChanged2 = new StaticCollectionAdapter<ProPresenterCue>(new ProPresenterCue[1] { _manager.ActivePlaylistItem });
						notifyEnumerableChanged3 = notifyEnumerableChanged2;
					}
					else
					{
						INotifyEnumerableChanged<ProPresenterCue> notifyEnumerableChanged2 = _manager.ActiveLibraryPlaylist;
						notifyEnumerableChanged3 = notifyEnumerableChanged2;
					}
					notifyEnumerableChanged = notifyEnumerableChanged3;
				}
				else if (_manager.ActiveLibraryPlaylist.Count == 0 && _manager.ActivePlaylistItem == null)
				{
					_filteredItems.UpdateSourceCollection(new EmptyNotifyEnumerableChanged<ProPresenterCue>());
				}
			}
			else if (_manager.ActiveLibrary != null)
			{
				if (_manager.ActiveLibrary.Contains(_manager.ActivePlaylistItem))
				{
					notifyEnumerableChanged = new StaticCollectionAdapter<ProPresenterCue>(new ProPresenterCue[1] { _manager.ActivePlaylistItem });
				}
				else if (_manager.ActivePlaylistItem == null)
				{
					_filteredItems.UpdateSourceCollection(new EmptyNotifyEnumerableChanged<ProPresenterCue>());
				}
			}
			else if (_manager.ActiveLibraryPlaylist == null && _manager.ActiveLibrary == null)
			{
				if (_manager.ActivePlaylistItem != null)
				{
					return _filteredItems;
				}
				_filteredItems.UpdateSourceCollection(new EmptyNotifyEnumerableChanged<ProPresenterCue>());
			}
			else
			{
				_filteredItems.UpdateSourceCollection(new EmptyNotifyEnumerableChanged<ProPresenterCue>());
			}
			if (notifyEnumerableChanged != null)
			{
				_filteredItems.UpdateSourceCollection(notifyEnumerableChanged);
			}
			return _filteredItems;
		}
	}

	public bool IsSecondaryTransitionVisible
	{
		get
		{
			if (!_layout.MediaLibraryCollapsed)
			{
				return _mediaBinShowsProContent;
			}
			return true;
		}
	}

	private IDocumentAction? ActiveDocumentAction => (ActivePlaylistItem as IDocumentCue)?.DocumentAction;

	public IPresentation? ActivePresentation => ActiveDocumentAction?.Presentation;

	public IEnumerable<ArrangedCue> CurrentCues
	{
		get
		{
			IEnumerable<ArrangedCue> enumerable = ActiveDocumentAction?.ActiveArrangement?.ArrangedCues;
			return enumerable ?? Array.Empty<ArrangedCue>();
		}
	}

	public TimerCollection Timers => DataVault.TimerDocument.Timers;

	public bool ShowVerseNavigation => ActivePresentation is BiblePresentation;

	public ICustomSlideMenuVM CustomSlideMenuVM { get; }

	public bool ForceFlipView
	{
		get
		{
			return _forceFlipView;
		}
		set
		{
			SetValue("ForceFlipView", ref _forceFlipView, value);
		}
	}

	public Action? TogglePresentationView
	{
		get
		{
			return _togglePresentationView;
		}
		set
		{
			SetValue("TogglePresentationView", ref _togglePresentationView, value);
		}
	}

	public Func<ArrangedCue?, Thumbnail?>? FindThumbnailProvider { get; set; }

	public bool CanAddNewSlide
	{
		get
		{
			if (ActivePresentation is CustomPresentation)
			{
				return ActivePresentation.IsAvailable;
			}
			return false;
		}
	}

	public ICommand DeriveAndAddSlideCommand => new RelayCommand(delegate
	{
		DefiveAndAddSlide((CustomPresentation)ActivePresentation);
	}, () => CanAddNewSlide);

	public ICommand<ArrangedCue> TriggerSlideCommand => new RelayCommand<ArrangedCue>(TriggerSlide);

	public ICommand<TemplateSlide> AddTemplateSlideCommand => new RelayCommand<TemplateSlide>(AddTemplateSlideCommandExecuted, (TemplateSlide _) => CanAddNewSlide);

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(SelectTemplateCommandExecuted, (TemplateSlide t) => ActivePresentation is CustomPresentation);

	public ICommand TriggerNextSlideCommand => new RelayCommand(TriggerNextSlide);

	public ICommand TriggerPreviousSlideCommand => new RelayCommand(TriggerPreviousSlide);

	public ICommand<int> TriggerNumberCommand => new RelayCommand<int>(TriggerByNumber, (int n) => CurrentCues.ElementAtOrDefault(n - 1) != null);

	public ICommand<Key> TriggerHotkeyCommand => new RelayCommand<Key>(TriggerByHotkey, (Key k) => CurrentCues.Any((ArrangedCue s) => s.HasHotkey(k)));

	public ICommand GoToPreviousPresentationCommand => new RelayCommand(delegate
	{
		_manager.ActivePlaylistItem = _manager.PreviousPresentation;
	}, () => _manager.PreviousPresentation != null);

	public ICommand GoToNextPresentationCommand => new RelayCommand(delegate
	{
		_manager.ActivePlaylistItem = _manager.NextPresentation;
	}, () => _manager.NextPresentation != null);

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, OnCanExecuteSelectionDependentCommand);

	public ICommand CutCommand => new RelayCommand(OnCutCommand, OnCanExecuteSelectionDependentCommand);

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, OnCanExecutePaste);

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, OnCanExecuteSelectionDependentCommand);

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, OnCanExecuteSelectionDependentCommand);

	public ICommand<IDragDropCommandParameters<ArrangedCue, IPresentation>> DroppedIntoCommand => new RelayCommand<IDragDropCommandParameters<ArrangedCue, IPresentation>>(OnDroppedIntoCommand);

	public ICommand<IDragDropCommandParameters<ArrangedCue, IPresentation>> MoveToCommand => new RelayCommand<IDragDropCommandParameters<ArrangedCue, IPresentation>>(MoveToCommandExecute);

	public ICommand GotFocusCommand => new RelayCommand(delegate
	{
		UpdateActiveUndoStack(ActivePresentation?.UndoStack);
	});

	public ICommand<(IDocumentCue, AddMediaCueParameters)> AddMediaActionCommand => new RelayCommand<(IDocumentCue, AddMediaCueParameters)>(delegate((IDocumentCue document, AddMediaCueParameters parameters) p)
	{
		OnAddMediaActionCommand(p.document, p.parameters);
	});

	public ICommand<(IDocumentCue, MediaActionCommandParameters)> AddDroppedMediaActionCommand => new RelayCommand<(IDocumentCue, MediaActionCommandParameters)>(delegate((IDocumentCue document, MediaActionCommandParameters parameters) p)
	{
		OnAddDroppedMediaActionCommand(p.document, p.parameters);
	});

	public ICommand<(IDocumentCue, AddMediaPlaylistParameters)> AddMediaPlaylistActionCommand => new RelayCommand<(IDocumentCue, AddMediaPlaylistParameters)>(delegate((IDocumentCue document, AddMediaPlaylistParameters parameters) p)
	{
		OnAddMediaPlaylistActionCommand(p.document, p.parameters);
	});

	public ICommand<(IDocumentCue, DropMediaFilesCommandParameters)> DropMediaFilesCommand => new RelayCommand<(IDocumentCue, DropMediaFilesCommandParameters)>(delegate((IDocumentCue document, DropMediaFilesCommandParameters parameters) p)
	{
		OnDropMediaFilesCommand(p.document, p.parameters);
	});

	public ICommand<ProPresenterCue> ItemActivatedCommand => new RelayCommand<ProPresenterCue>(OnItemActivatedCommand);

	public ICommand<(IDocumentCue, ActionCommandParameters)> AddDroppedActionCommand => new RelayCommand<(IDocumentCue, ActionCommandParameters)>(delegate((IDocumentCue document, ActionCommandParameters parameters) p)
	{
		OnAddDroppedActionCommand(p.document, p.parameters);
	});

	public ICommand<HeaderAction> TriggerHeaderItemCommand => new RelayCommand<HeaderAction>(_manager.TriggerHeaderAction, (HeaderAction t) => t != null);

	public ICommand GoToNextVerseCommand => new RelayCommand(delegate
	{
		NavigateVerseCommandExecuted(isForward: true);
	}, CanNavigateVerse);

	public ICommand GoToPreviousVerseCommand => new RelayCommand(delegate
	{
		NavigateVerseCommandExecuted(isForward: false);
	}, CanNavigateVerse);

	public ICommand<TemplateSlide> ApplyTemplateToSelectedSlides => new RelayCommand<TemplateSlide>(ApplyTemplateToSelectedSlidesExecuted, (TemplateSlide t) => t != null);

	public ICommand<LinkCommandParameters> LinkNewPresentationCommand => new RelayCommand<LinkCommandParameters>(OnLinkNewPresentationCommand);

	public ICommand<LinkCommandParameters> LinkImportCommand => new RelayCommand<LinkCommandParameters>(OnLinkImportCommand);

	public ICommand<LinkCommandParameters> LinkDocumentCommand => new RelayCommand<LinkCommandParameters>(delegate(LinkCommandParameters p)
	{
		p.Presentation.ThrowWhenNull("p.Presentation");
		(p.TargetCue as PlaceholderCue)?.PlaceholderAction?.LinkDocument(p.Presentation);
		PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, PlaceholderLinkSource.DragDrop);
	}, (LinkCommandParameters p) => p.Presentation != null);

	public ICommand<LinkCommandParameters> LinkMediaCommand => new RelayCommand<LinkCommandParameters>(delegate(LinkCommandParameters p)
	{
		p.Media.ThrowWhenNull("p.Media");
		(p.TargetCue as PlaceholderCue)?.PlaceholderAction?.LinkMedia(p.Media);
		PlaceholderLinkEvent.Publish(PlaceholderLinkType.Media, PlaceholderLinkSource.DragDrop);
	}, (LinkCommandParameters p) => p.Media != null);

	public ICommand<LinkCommandParameters> LinkDropFilesCommand => new RelayCommand<LinkCommandParameters>(OnLinkDropFilesCommand, CanDropLinkFiles);

	public ICommand<LinkCommandParameters> LinkSongSelectItemCommand => new RelayCommand<LinkCommandParameters>(OnLinkSongSelectItemCommand);

	public ICommand<LinkCommandParameters> LinkMultiTracksItemCommand => new RelayCommand<LinkCommandParameters>(LinkMultiTracksItemCommandExecuted, (LinkCommandParameters l) => MultiTracksSearchService != null && l.TargetCue != null && l.MultiTracksSearchResult != null);

	public ICommand<ProPresenterCue> UnlinkItemCommand => new RelayCommand<ProPresenterCue>(delegate(ProPresenterCue p)
	{
		(p as PlaceholderCue)?.PlaceholderAction?.Unlink();
	}, (ProPresenterCue p) => (p as PlaceholderCue)?.IsLinked ?? false);

	public ICommand<ProPresenterCue> OpenSearchCommand => new RelayCommand<ProPresenterCue>(OnOpenSearchCommand, (ProPresenterCue p) => !((p as PlaceholderCue)?.IsLinked ?? false));

	public ICommand<IPresentation?> OpenMultiTracksWebsiteCommand => new RelayCommand<IPresentation>(delegate
	{
		ProcessHelper.StartProcess("https://multitracks.com");
	});

	public ICommand<IPresentation?> RetryMultiTracksAuthorizationCommand => new RelayCommand<IPresentation>(delegate(IPresentation? p)
	{
		OnRetryMultiTracksAuthorization((MultiTracksPresentation)p);
	}, (IPresentation? p) => p is MultiTracksPresentation);

	public ICommand<(IDocumentCue, ProContentDropParameter<ArrangedCue?>)> DropProContentAssetCommand => new RelayCommand<(IDocumentCue, ProContentDropParameter<ArrangedCue>)>(delegate((IDocumentCue documentCue, ProContentDropParameter<ArrangedCue?> parameters) p)
	{
		DropProContentAssetCommandExecuted(p.documentCue, p.parameters);
	}, ((IDocumentCue documentCue, ProContentDropParameter<ArrangedCue?> parameters) p) => CanDropAsset(p.parameters));

	public ICommand<DropPropCommandParameter> DropPropCommand => new RelayCommand<DropPropCommandParameter>(DropPropCommandExecute);

	public event SlideTriggeredAction? SlideTriggered
	{
		add
		{
			_manager.SlideTriggered += value;
		}
		remove
		{
			_manager.SlideTriggered -= value;
		}
	}

	public event SlideClearedAction? SlideCleared
	{
		add
		{
			_manager.SlideCleared += value;
		}
		remove
		{
			_manager.SlideCleared -= value;
		}
	}

	public event Action<UndoStack?>? StackChanged;

	public event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>?>? ShowActionDialog;

	public event Action<FrameworkElement?>? UpdateDialogPlacementTarget;

	public PresentationVM(ICoreManager manager, ssAPIOutput outputController, ILibraryVM libraryVM, IMediaLibraryVM mediaLibraryVM, IBibleProvider bibleProvider, Action<string> setSearchText, IMessageService messageService, IProContentDownloader proContentDownloader, IApp app, ITriggeringFactory triggeringFactory, IUiDispatcher uiDispatcher, IActionDropOperation dropOperation, ITransitionSet transitions, IActionsMenuVMFactory actionsMenuVMFactory, IProPresenterResourceService resourceService, ILayout layout, IInputActions inputActions, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, IChangeWorkspaceHandler supportFolderHandler, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
	{
		_manager = manager;
		_service = triggeringFactory.Create();
		OutputController = outputController;
		_libraryVM = libraryVM;
		_bibleProvider = bibleProvider;
		_setSearchText = setSearchText;
		_proContentDownloader = proContentDownloader;
		_dispatcher = uiDispatcher;
		_filteredItems = new UpdatingFilteredObservableCollection<ProPresenterCue>(null, (ProPresenterCue c) => !c.IsHidden, uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsHidden"));
		_app = app;
		_dropOperation = dropOperation;
		_resourceService = resourceService;
		_layout = layout;
		_inputActions = inputActions;
		_importProcessFactory = importProcessFactory;
		_factoryProvider = factoryProvider;
		MediaLibraryVM = mediaLibraryVM;
		_supportFolderHandler = supportFolderHandler;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
		TimelineActionsMenuVM = actionsMenuVMFactory.Create(null);
		messageService.SubscribeToMessage<ThemePickerSettingsUpdatedMessage>(HandleSettingsUpdated);
		CustomSlideMenuVM customSlideMenuVM = new CustomSlideMenuVM(outputController, SelectedSlides, messageService, app, importProcessFactory, actionsMenuVMFactory, _factoryProvider.MediaFactory, transitionDescriptions);
		customSlideMenuVM.ShowActionDialog += OnShowActionDialog;
		CustomSlideMenuVM = customSlideMenuVM;
		CustomSlideMenuVM.SelectedCue = _manager.ActivePlaylistItem;
		LoadTransition(transitions);
		LoadViewSettings();
		HookupLinkedProperties();
		if (DataVault.LibraryCollection != null)
		{
			DataVault.LibraryCollection.LibraryCollectionChanged += LibraryCollection_LibraryChanged;
			DataVault.LibraryCollection.ForEach(delegate(ILibrary l)
			{
				l.CueUpdated += OnLibraryCueUpdated;
			});
		}
		_supportFolderHandler.Completed += RefreshLibrariesContainPresentations;
	}

	private void RefreshLibrariesContainPresentations(ChangeWorkspaceCompleted _)
	{
		OnPropertyChanged("LibrariesContainPresentations");
	}

	private void HandleSettingsUpdated(IMessage message)
	{
		if (message is ThemePickerSettingsUpdatedMessage themePickerSettingsUpdatedMessage && themePickerSettingsUpdatedMessage.Model.ContextualGroup == ThemePickerGroup.Presentation)
		{
			_applyTemplateMediaAction = themePickerSettingsUpdatedMessage.Model.MediaActionEnabled;
		}
	}

	private void LoadViewSettings()
	{
		switch (_app.PresentationPanelViewType)
		{
		case PanelViewType.Thumbnail:
			_presentationViewSettings = new ThumbnailViewSettings(_app);
			break;
		case PanelViewType.EasyView:
			_presentationViewSettings = new EasyViewSettings(_app);
			break;
		case PanelViewType.List:
			_presentationViewSettings = new ListViewSettings(_app);
			break;
		}
	}

	[MemberNotNull("TransitionHandler")]
	private void LoadTransition(ITransitionSet transitions)
	{
		IReadOnlyList<TransitionDescription> readOnlyList = OutputController?.AvailableTransitions;
		if (readOnlyList == null)
		{
			readOnlyList = Array.Empty<TransitionDescription>();
		}
		GlobalTransitionProvider transitionProvider = new GlobalTransitionProvider(transitions, _app.GlobalForegroundTransitionType, _app.GlobalForegroundAutoTransitionDuration, _app.GlobalForegroundAdvancedTransition.ToTransition(readOnlyList));
		transitionProvider.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "StoredAutoParameters":
				_app.GlobalForegroundAutoTransitionDuration = transitionProvider.StoredAutoParameters.Duration;
				break;
			case "StoredAdvancedParameters":
				_app.GlobalForegroundAdvancedTransition = transitionProvider.StoredAdvancedParameters?.Serialize();
				break;
			case "ActiveStoreType":
				_app.GlobalForegroundTransitionType = transitionProvider.ActiveStoreType.GetValueOrDefault();
				break;
			}
		};
		SelectedTransition = transitionProvider.GetTransition(transitions);
		TransitionHandler = new TransitionHandler(transitions, transitionProvider);
		TransitionHandler.ActivateTransition(SelectedTransition);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
	}

	private void OnSelectedTransitionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Duration" && sender is TransitionParameters { Duration: var duration })
		{
			_app.GlobalForegroundAutoTransitionDuration = duration;
		}
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
	}

	private void HookupLinkedProperties()
	{
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "ActiveLibraryPlaylist", "ActivePlaylistItem", "IsContiguousActive", "ActiveLibrary" }), new global::_003C_003Ez__ReadOnlyArray<string>(new string[4] { "CanAddNewSlide", "Items", "ActivePlaylistItem", "IsContiguousViewFocused" }));
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "PresentationRowCapacity", "ReflowRowCapacity", "ReflowTextZoomLevel" }), new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "PresentationRowCapacity", "ReflowRowCapacity", "ReflowTextZoomLevel" }));
		LinkProperties("MediaLibraryCollapsed", "IsSecondaryTransitionVisible");
		LinkProperties("SelectedTransition", "MediaLibraryVM");
		LinkAction("ActivePlaylistItem", OnActivePlaylistItemChanged);
		LinkAction("ActiveSlide", OnActiveSlideChanged);
		_manager.PropertyChanged += base.RaiseLinkedValues;
		_layout.PropertyChanged += base.RaiseLinkedValues;
		_app.PropertyChanged += base.RaiseLinkedValues;
	}

	private void DefiveAndAddSlide(CustomPresentation presentation)
	{
		ArrangedCue arrangedCue = SelectedSlides.LastOrDefault() ?? ActiveSlide;
		ArrangedCue arrangedCue2 = CurrentCues.LastOrDefault();
		CustomSlide customSlide = arrangedCue?.Source.SlideAction?.Slide as CustomSlide;
		presentation.AddCue((customSlide == null) ? new TemplateSlide(_factoryProvider, _transitionDescriptions, _flagService) : new TemplateSlide(_factoryProvider, customSlide, _flagService), (arrangedCue ?? arrangedCue2)?.Source);
	}

	private void TriggerSlide(ArrangedCue slide)
	{
		TriggerSlideAction(delegate
		{
			_service.TriggerSlide(slide, GetOptions());
		}, scrollToSlide: false);
	}

	private void TriggerNextSlide()
	{
		TriggerSlideAction(_service.TriggerNextSlide);
	}

	private void TriggerPreviousSlide()
	{
		TriggerSlideAction(_service.TriggerPreviousSlide);
	}

	private void TriggerByNumber(int number)
	{
		TriggerSlideAction(delegate
		{
			ArrangedCue arrangedCue = CurrentCues.ElementAtOrDefault(number - 1);
			if (arrangedCue != null)
			{
				_service.TriggerSlide(arrangedCue, GetOptions());
			}
		});
	}

	private void TriggerByHotkey(Key key)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		TriggerSlideAction(delegate
		{
			ArrangedCue arrangedCue = CurrentCues.FirstOrDefault((ArrangedCue s) => s.HasHotkey(key));
			if (arrangedCue != null)
			{
				_service.TriggerSlide(arrangedCue, GetOptions());
			}
		});
	}

	private static SlideTriggerOptions GetOptions()
	{
		return new SlideTriggerOptions(overrideEnable: true);
	}

	private void TriggerSlideAction(Action action, bool scrollToSlide = true)
	{
		SelectedSlides.Clear();
		ScrollToSlide = scrollToSlide;
		action();
		if (ActivePresentation is BiblePresentation)
		{
			BibleTriggerEvent.Publish(BibleLocation.Presentation);
		}
	}

	private bool OnCanExecuteSelectionDependentCommand()
	{
		if (ActivePlaylistItem != null && ActivePresentation != null)
		{
			return SelectedSlides.Any();
		}
		return false;
	}

	private bool OnCanExecutePaste()
	{
		if (ActivePresentation is CustomPresentation)
		{
			return ClipboardManagerHelper.CanPasteIntoCollection<SlidesCopyData>(IsPasteable);
		}
		return false;
	}

	private bool IsPasteable(SlidesCopyData data)
	{
		if (data.SourceCopyIdentifier != null && ActivePresentation != null)
		{
			return ActivePresentation.CopyIdentifier.CanPasteFrom(data.SourceCopyIdentifier);
		}
		return false;
	}

	private void OnCopyCommand()
	{
		IArrangement arrangement = ActiveDocumentAction?.ActiveArrangement ?? ActivePresentation.ActiveArrangement ?? ActivePresentation.DefaultArrangement;
		IEnumerable<SlidesCopyData> slidesData = SelectedSlides.ToArray().GetSlidesData(ActivePresentation.CopyIdentifier, arrangement);
		if (slidesData.Any())
		{
			ClipboardManagerHelper.CopyFromCollection(slidesData);
		}
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private void OnPasteCommand()
	{
		if (!(ActivePresentation is CustomPresentation customPresentation))
		{
			return;
		}
		using (ActivePresentation?.UndoStack.Transaction(UndoActionTypes.DuplicateSlide.ToAction(), null, null, autoFinalize: true))
		{
			IArrangement arrangement = customPresentation.ActiveArrangement ?? customPresentation.DefaultArrangement;
			SlideCue[] array = customPresentation.ArrangementGroups.SelectMany((CueGroup s) => s.Cues).ToArray();
			IEnumerable<SlidesCopyData> source = ClipboardManagerHelper.PasteIntoCollection<PresentationBase, SlidesCopyData>(customPresentation, array.IndexOf(SelectedSlides.OrderBy(arrangement.ArrangedCues.IndexOf).LastOrDefault()?.Source), IsPasteable);
			IEnumerable<SlideCue> cues = source.SelectMany((SlidesCopyData a) => a.Slides);
			IEnumerable<ITrackedMedia> trackedMedia = cues.SelectMany((SlideCue x) => x.GetTrackedMedia());
			trackedMedia.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
			ActivePresentation?.UndoStack.Commit(delegate
			{
				trackedMedia.ForEach(delegate(ITrackedMedia x)
				{
					x.RemoveFromMediaService(deleteAssets: false);
				});
			}, delegate
			{
				trackedMedia.ForEach(delegate(ITrackedMedia x)
				{
					x.AddToMediaServiceAndApplyTransform(userInitiated: true);
				});
			});
			SelectedSlides.Clear();
			SelectedSlides.AddRange(arrangement.ArrangedCues.Where((ArrangedCue s) => cues.Contains(s.Source)));
		}
	}

	private void OnDuplicateCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnDeleteCommand()
	{
		SlideCue[] targetCues = SelectedSlides.Select((ArrangedCue x) => x.Source).ToArray();
		(ActivePresentation as CustomPresentation)?.RemoveCues(targetCues, canClearAll: true);
	}

	private void OnDroppedIntoCommand(IDragDropCommandParameters<ArrangedCue, IPresentation> e)
	{
		if (e.Source != null && e.Items != null && e.TargetItem != null)
		{
			UpdateActiveUndoStack(e.Source.UndoStack);
			e.Source.CuesDroppedInto(e.Items.Select((ArrangedCue a) => a.Source).OfType<SlideCue>().CloneItems(), e.TargetItem.Source, e.DroppedBefore, e.DroppedOutside && ((e.TargetItem.IsGroupHead && e.DroppedBefore) || (e.TargetItem.IsGroupTail && !e.DroppedBefore)), e.TargetItem.Group);
		}
	}

	private void MoveToCommandExecute(IDragDropCommandParameters<ArrangedCue, IPresentation> e)
	{
		if (e.Source != null && e.Items != null && e.TargetItem != null)
		{
			ArrangedCue[] array = e.Items.ToArray();
			IArrangement arrangement = ((ActivePlaylistItem is IDocumentCue documentCue && documentCue.DocumentAction?.Presentation == e.Source) ? documentCue.DocumentAction.ActiveArrangement : null);
			e.Source.MoveCuesTo(array.Select((ArrangedCue s) => s.Source), e.TargetItem.Source, e.DroppedBefore, e.DroppedOutside && ((e.TargetItem.IsGroupHead && e.DroppedBefore) || (e.TargetItem.IsGroupTail && !e.DroppedBefore)), e.TargetItem.Group, e.Copy, arrangement);
			if (arrangement != null && _manager.ActiveSlide != null && e.Items.Contains<ArrangedCue>(_manager.ActiveSlide))
			{
				int index = PresentationHelper.FindSlideNewIndex(arrangement, array, _manager.ActiveSlide, e.TargetItem, e.DroppedBefore);
				_manager.ResetActiveSlide((IDocumentCue)ActivePlaylistItem, arrangement.ArrangedCues[index]);
			}
		}
	}

	private void OnActivePlaylistItemChanged()
	{
		SelectedSlides.Clear();
		CustomSlideMenuVM.SelectedCue = ActivePlaylistItem;
		OnPropertyChanged("ActivePresentation");
		OnPropertyChanged("ShowVerseNavigation");
		if (ActivePresentation != null)
		{
			ActivePresentation.ResetCueClick();
			UpdateActiveUndoStack(ActivePresentation.UndoStack);
		}
	}

	private void UpdateActiveUndoStack(UndoStack? undoStack)
	{
		this.StackChanged?.Invoke(undoStack);
	}

	private void OnActiveSlideChanged()
	{
		OnPropertyChanged("ActiveSlide");
		if (ActiveSlide != null)
		{
			ArrangedCue arrangedCue = ActivePresentation?.DefaultArrangement.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source.ID == ActiveSlide.Source.ID);
			if (arrangedCue != null)
			{
				ActivePresentation?.IncreaseCueClick(arrangedCue);
			}
			ScrollToSlide = false;
		}
	}

	private void OnItemActivatedCommand(ProPresenterCue playlistItem)
	{
		ActivePlaylistItem = playlistItem;
	}

	private void AddTemplateSlideCommandExecuted(TemplateSlide? template)
	{
		if (!(ActivePresentation is CustomPresentation customPresentation))
		{
			return;
		}
		SlideCue slideCue = customPresentation.AddCue(template, SelectedSlides, ActiveDocumentAction?.ActiveArrangement);
		if (_applyTemplateMediaAction)
		{
			if (template == null)
			{
				template = customPresentation.ActiveTemplate;
			}
			slideCue.ApplyTemplateMediaAction(template);
		}
	}

	private void SelectTemplateCommandExecuted(TemplateSlide template)
	{
		if (ActivePresentation is CustomPresentation customPresentation)
		{
			customPresentation.ApplyTemplateToSlides(template, SelectedSlides.Select((ArrangedCue s) => s.Source).Distinct().ToArray(), _applyTemplateMediaAction);
		}
	}

	private Thumbnail? GetPlacementTarget(IDocumentCue documentCue, SlideCue? slideCue)
	{
		ArrangedCue arg = ((documentCue.DocumentAction ?? ActiveDocumentAction)?.ActiveArrangement ?? ActivePresentation?.ActiveArrangement ?? ActivePresentation?.DefaultArrangement)?.ArrangedCues.FirstOrDefault((ArrangedCue s) => s.Source == slideCue);
		return FindThumbnailProvider?.Invoke(arg);
	}

	private void OnAddDroppedActionCommand(IDocumentCue document, ActionCommandParameters param)
	{
		SlideCue slideCue = (param.TargetThumbnail?.Source as ArrangedCue)?.Source;
		List<IAction> actions = (param.ActionTypes?.Select((ActionType a) => a.ConstructAction(null, document.ContainerId)) ?? param.Actions)?.ToList();
		OnDropActionCommand(document, slideCue, actions, param.DroppedBefore, param.DroppedOutside, param.ActionTypes);
	}

	private void DropPropCommandExecute(DropPropCommandParameter param)
	{
		SlideCue slideCue = (param.TargetThumbnail?.Source as ArrangedCue)?.Source;
		List<IAction> list = new List<IAction>();
		foreach (IPropCueVMInternal item in param.Props.OfType<IPropCueVMInternal>())
		{
			list.Add(item.Source.ToAction(null));
		}
		param.Document.ThrowWhenNull("param.Document");
		OnDropActionCommand(param.Document, slideCue, list, param.DroppedBefore, param.DroppedOutside, ActionType.Prop.ToEnumerable());
	}

	private void OnDropActionCommand(IDocumentCue document, SlideCue? slideCue, List<IAction>? actions, bool droppedBefore, bool droppedOutside, IEnumerable<ActionType>? actionTypes)
	{
		UpdateActions(actions);
		IActionRepository placement;
		IAction action = _dropOperation.Execute(actions, document, slideCue, droppedBefore, droppedOutside, out placement);
		if (action != null && action.CanShowDialogOnDrop(actionTypes))
		{
			OnShowActionDialog(document, action, placement);
		}
	}

	private void UpdateActions(List<IAction>? actions)
	{
		if (actions == null)
		{
			return;
		}
		List<ActionBase> items = new List<ActionBase>();
		foreach (IAction action in actions)
		{
			if (!(action is StageAction stageAction))
			{
				continue;
			}
			StageScreenAssignment[] array = stageAction.ScreenAssignments?.Where((StageScreenAssignment a) => (object)a.Layout != null).ToArray() ?? Array.Empty<StageScreenAssignment>();
			foreach (StageScreenAssignment assignment in array)
			{
				KeyValuePair<ScreenArrangementBase, SlideCue> keyValuePair = _manager.OutputConfiguration.StageScreenLayoutMap.FirstOrDefault<KeyValuePair<ScreenArrangementBase, SlideCue>>((KeyValuePair<ScreenArrangementBase, SlideCue> kp) => kp.Key.ID == assignment.Screen.ID);
				assignment.Layout = new Identifier(keyValuePair.Value.ID, keyValuePair.Value.Name);
			}
		}
		actions.RemoveRange(items);
	}

	private void OnAddDroppedMediaActionCommand(IDocumentCue document, MediaActionCommandParameters param)
	{
		SlideCue slideCue = (param.TargetThumbnail?.Source as ArrangedCue)?.Source;
		UpdateActiveUndoStack(slideCue?.ParentPresentation?.UndoStack);
		(IAction, IActionRepository) tuple = _dropOperation.Execute(param.MediaType, document, slideCue, param.DroppedBefore, param.DroppedOutside, ActivePresentation?.ContainerId ?? "");
		var (action, _) = tuple;
		if (action != null && action.CanShowDialogOnDrop(param.MediaType.ToEnumerable()))
		{
			OnShowActionDialog(document, action, tuple.Item2);
		}
	}

	private void OnShowActionDialog(IDocumentCue document, IAction action, IActionRepository? placement)
	{
		ArrangedCue arrangedCue = document.DocumentAction?.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source == placement);
		_dispatcher.InvokeAsync(delegate
		{
			OnShowActionDialog(GetPlacementTarget(document, placement as SlideCue), action, arrangedCue?.Source, null);
		}, (DispatcherPriority)6);
	}

	private void OnShowActionDialog(FrameworkElement? target, IAction? action, IActionRepository? slide, IEnumerable<IActionRepository> slides)
	{
		OnShowActionDialog(target, action, slide as SlideCue, slides.Cast<SlideCue>());
	}

	private void OnShowActionDialog(FrameworkElement? target, IAction? action, SlideCue? slide, IEnumerable<SlideCue>? slides)
	{
		if (_currentEditedAction != null)
		{
			_currentEditedAction.PropertyChanged -= Action_PropertyChanged;
		}
		_currentEditedAction = action;
		if (_currentEditedAction != null)
		{
			_currentEditedAction.PropertyChanged += Action_PropertyChanged;
		}
		this.ShowActionDialog?.Invoke(getPlacement(target), action, slide, slides);
		void Action_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsValid")
			{
				this.UpdateDialogPlacementTarget?.Invoke(getPlacement(target));
			}
		}
		FrameworkElement? getPlacement(FrameworkElement? t)
		{
			return ((DependencyObject)(object)t)?.FindVisualChild<ScrimPanel>()?.GetScrimItem((IScrimSource)action) ?? t;
		}
	}

	private void OnAddMediaActionCommand(IDocumentCue documentCue, AddMediaCueParameters p)
	{
		_dropOperation.Execute(p.MediaCues, documentCue, p.TargetItem, p.DroppedBefore, p.DroppedOutside);
	}

	private void OnAddMediaPlaylistActionCommand(IDocumentCue documentCue, AddMediaPlaylistParameters param)
	{
		IActionRepository placement;
		IAction action = _dropOperation.Execute(param.Playlists, documentCue, param.TargetItem, param.DroppedBefore, param.DroppedOutside, out placement);
		if (action != null && action.CanShowDialogOnDrop(ActionType.LibraryPlaylist.ToEnumerable()))
		{
			OnShowActionDialog(documentCue, action, placement);
		}
	}

	private void OnDropMediaFilesCommand(IDocumentCue documentCue, DropMediaFilesCommandParameters p)
	{
		if (p.RemoteFile != null)
		{
			_dropOperation.Execute(p.RemoteFile, documentCue, p.TargetItem, p.DroppedBefore, p.DroppedOutside, documentCue.ContainerId);
		}
		else if (p.Files != null)
		{
			_dropOperation.Execute(p.Files, documentCue, p.TargetItem, p.DroppedBefore, p.DroppedOutside, documentCue.ContainerId);
		}
	}

	private void SetGlobalForegroundTransition()
	{
		_manager.ForegroundTransition = SelectedTransition;
	}

	private void NavigateVerseCommandExecuted(bool isForward)
	{
		((BiblePresentation)ActivePresentation).NavigateVerse(_bibleProvider.LoadedBibles, isForward, _applyTemplateMediaAction);
		if (isForward)
		{
			BibleGenerateNextEvent.Publish(BibleLocation.Presentation);
		}
		else
		{
			BibleGeneratePreviousEvent.Publish(BibleLocation.Presentation);
		}
	}

	private bool CanNavigateVerse()
	{
		if (ActivePresentation is BiblePresentation { StartReference: { IsValid: not false }, EndReference: var endReference })
		{
			return endReference.IsValid;
		}
		return false;
	}

	private void ApplyTemplateToSelectedSlidesExecuted(TemplateSlide templateSlide)
	{
		IEnumerable<SlideCue> targetCues = SelectedSlides.Select((ArrangedCue s) => s.Source).Distinct();
		((CustomPresentation)ActivePresentation).ApplyTemplateToSlides(templateSlide, targetCues, _applyTemplateMediaAction);
	}

	private void OnLinkNewPresentationCommand(LinkCommandParameters parameters)
	{
		PlaceholderCue placeholderCue;
		if (_libraryVM != null)
		{
			ProPresenterCue targetCue = parameters.TargetCue;
			placeholderCue = targetCue as PlaceholderCue;
			if (placeholderCue != null)
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
			if (args.Document != null)
			{
				args.ShouldActivate = false;
				placeholderCue.PlaceholderAction?.LinkDocument(args.Document.DocumentAction.Presentation);
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
		PlaceholderCue placeholderCue = parameters.TargetCue as PlaceholderCue;
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
		static string getFilePath(ILibrary? library, FileImportRequest request)
		{
			RelativePath relativePath2 = library?.Location;
			return Path.Combine(((object)relativePath2 != null) ? ((string)relativePath2) : string.Empty, request.FinalName + request.FileExtension);
		}
		void process_ImportComplete(IImportProcess p)
		{
			p.ImportComplete -= process_ImportComplete;
			FileImportRequest[] array = p.CompletedRequests.OfType<FileImportRequest>().Where(delegate(FileImportRequest f)
			{
				bool flag = f.FileExtension.IsMediaFile() || f.FileExtension.IsProPresentationFile();
				if (f.FileExtension.IsMediaFile() && f.ParentRequest is FileImportRequest fileImportRequest)
				{
					flag = flag && !fileImportRequest.FullName.IsBundleFile();
				}
				return flag;
			}).ToArray();
			if (array.Length == 1)
			{
				FileImportRequest fileImportRequest2 = array[0];
				if (p.SelectedLibrary != null)
				{
					LinkImportedFile(placeholderCue, getFilePath(p.SelectedLibrary, fileImportRequest2), p, linkSource);
				}
				else if (p.GetResultOfRequest(fileImportRequest2) is FileImportResult fileImportResult)
				{
					LinkImportedFile(placeholderCue, fileImportResult.GetTargetFilename(fileImportRequest2), p, linkSource);
				}
				else if (p.GetResultOfRequest(fileImportRequest2) is MediaManagementFileImportResult mediaManagementFileImportResult)
				{
					LinkMedia(placeholderCue, mediaManagementFileImportResult.CreatedMedia, linkSource);
				}
				else
				{
					Log.Error("Unable to import dropped file: " + fileImportRequest2.FinalName);
				}
			}
			else if (array.Length > 1)
			{
				SelectLinkFileControl selectLinkFileControl = new SelectLinkFileControl
				{
					Files = array
				};
				selectLinkFileControl.File = array[0];
				DefaultButtons? defaultButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("PLACEHOLDER_PROBUNDLE_IMPORT_LINK_ALERT_message", new object[1] { p.SelectedLibrary?.Name ?? string.Empty }), (DependencyObject)(object)selectLinkFileControl, DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.OK);
				if (defaultButtons.HasValue && defaultButtons.Value == DefaultButtons.OK)
				{
					LinkImportedFile(placeholderCue, getFilePath(p.SelectedLibrary, selectLinkFileControl.File), p, linkSource);
				}
			}
		}
		void runImport()
		{
			IImportProcess importProcess = _importProcessFactory.Create(requests, null, allowSelectPlaylist: false);
			importProcess.ImportComplete += process_ImportComplete;
			importProcess.StartImport();
		}
	}

	public void LinkImportedFile(PlaceholderCue? placeholderCue, string? filename, IImportProcess process, PlaceholderLinkSource linkSource)
	{
		if (placeholderCue == null)
		{
			return;
		}
		if (filename.IsMediaFile())
		{
			FileMediaBase fileMediaBase = _factoryProvider.MediaFactory.CreateEmptyFileMedia(filename, placeholderCue.ContainerId, null);
			placeholderCue.PlaceholderAction?.LinkMedia(fileMediaBase);
			fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)filename);
			PlaceholderLinkEvent.Publish(PlaceholderLinkType.Media, linkSource);
		}
		else if (filename.IsProPresentationFile())
		{
			DocumentCue documentCue = process.SelectedLibrary?.FirstOrDefault((DocumentCue p) => p.Name == Path.GetFileNameWithoutExtension(filename));
			if (documentCue != null)
			{
				placeholderCue.PlaceholderAction?.LinkDocument(documentCue.DocumentAction.Presentation);
			}
			else if (process.SelectedLibrary != null)
			{
				_pendingLinkDocuments[filename] = (placeholderCue, process.SelectedLibrary);
			}
			PlaceholderLinkEvent.Publish(PlaceholderLinkType.Presentation, linkSource);
		}
	}

	public void LinkMedia(PlaceholderCue? placeholderCue, FileMediaBase? media, PlaceholderLinkSource linkSource)
	{
		if (placeholderCue != null && media != null)
		{
			placeholderCue.PlaceholderAction?.LinkMedia(media);
			PlaceholderLinkEvent.Publish(PlaceholderLinkType.Media, linkSource);
		}
	}

	private void OnLinkSongSelectItemCommand(LinkCommandParameters parameters)
	{
		SongSelectSearchResult songSelectSearchResult = parameters.SongSelectResult as SongSelectSearchResult;
		songSelectSearchResult.ThrowWhenNull("searchResult");
		_manager.SongSelectConsumer.Import(_importProcessFactory, songSelectSearchResult, delegate(string filename, IImportProcess process)
		{
			LinkImportedFile(parameters.TargetCue as PlaceholderCue, filename, process, PlaceholderLinkSource.DragDrop);
		});
	}

	private void LinkMultiTracksItemCommandExecuted(LinkCommandParameters parameters)
	{
		MultiTracksSearchResult searchResult = parameters.MultiTracksSearchResult as MultiTracksSearchResult;
		searchResult.ThrowWhenNull("searchResult");
		MultiTracksSearchService.ThrowWhenNull("MultiTracksSearchService");
		parameters.TargetCue.ThrowWhenNull("parameters.TargetCue");
		_dispatcher.InvokeAsync(delegate
		{
			MultiTracksSearchService.ImportAndLinkToItem(parameters.TargetCue, searchResult);
		});
	}

	private void OnOpenSearchCommand(ProPresenterCue cue)
	{
		_setSearchText(cue.Name);
		_inputActions.CommonInputActions.Find.BindCommand.Invoke(new SearchContext(cue));
	}

	private void LibraryCollection_LibraryChanged(ILibrary library, NotifyCollectionChangedEventArgs e)
	{
		KeyValuePair<string, (PlaceholderCue, ILibrary)>[] array = _pendingLinkDocuments.ToArray();
		foreach (KeyValuePair<string, (PlaceholderCue, ILibrary)> keyValuePair in array)
		{
			keyValuePair.Deconstruct(out var key, out var value);
			(PlaceholderCue, ILibrary) tuple = value;
			string f = key;
			var (placeholderCue, library2) = tuple;
			if (placeholderCue != null && library2 == library)
			{
				DocumentCue documentCue = library2.FirstOrDefault((DocumentCue p) => p.Name == Path.GetFileNameWithoutExtension(f));
				if (documentCue != null)
				{
					placeholderCue.PlaceholderAction?.LinkDocument(documentCue.DocumentAction.Presentation);
					_pendingLinkDocuments.Remove(f);
				}
			}
		}
		OnPropertyChanged("LibrariesContainPresentations");
		e.OldItems?.OfType<ILibrary>().ForEach(delegate(ILibrary l)
		{
			l.CueUpdated -= OnLibraryCueUpdated;
		});
		e.NewItems?.OfType<ILibrary>().ForEach(delegate(ILibrary l)
		{
			l.CueUpdated += OnLibraryCueUpdated;
		});
	}

	private void OnLibraryCueUpdated(Cue _)
	{
		_filteredItems.Refresh();
		OnPropertyChanged("LibrariesContainPresentations");
	}

	private static bool CanDropLinkFiles(LinkCommandParameters parameters)
	{
		if (parameters.TargetCue is PlaceholderCue && (parameters.RemoteFile == null || parameters.RemoteFile.Filename.IsMediaFile() || parameters.RemoteFile.Filename.IsProPresentationFile() || parameters.RemoteFile.Filename.IsProBundleFile()))
		{
			if (parameters.Files != null)
			{
				if (parameters.Files.Any())
				{
					return parameters.Files.All((FileInfo f) => f.FullName.IsMediaFile() || f.FullName.IsProPresentationFile() || f.FullName.IsProBundleFile());
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private void OnRetryMultiTracksAuthorization(MultiTracksPresentation presentation)
	{
		_multiTracksSearchService?.RetryAuthorization(presentation);
	}

	private void OnMultitracksConsumerSubscriptionUpdated()
	{
		OnPropertyChanged("CanAddNewSlide");
	}

	private void DropProContentAssetCommandExecuted(IDocumentCue documentCue, ProContentDropParameter<ArrangedCue?> parameter)
	{
		IProContentDownloadableAsset asset = (IProContentDownloadableAsset)((IProContentAssetVMInternal)parameter.Asset).Asset;
		_proContentDownloader.ImportAssetAsync(asset, null, delegate(IDownloadObserverCallbackData data)
		{
			ProContentDownloadObserveCallbackData callbackData = data as ProContentDownloadObserveCallbackData;
			if ((object)callbackData != null)
			{
				if (callbackData.Cleanup)
				{
					if (documentCue.DocumentAction?.Presentation is CustomPresentation customPresentation)
					{
						SlideCue[] array = (from a in customPresentation.DefaultArrangement.ArrangedCues
							where a.Source.Actions.Any((IAction action) => action == callbackData.MediaCue.MediaAction)
							select a.Source).ToArray();
						if (parameter.DropOutside)
						{
							customPresentation.RemoveCues(array);
						}
						else if (callbackData.MediaCue.MediaAction != null)
						{
							SlideCue[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								array2[i].RemoveAction(callbackData.MediaCue.MediaAction);
							}
						}
					}
				}
				else
				{
					_dropOperation.Execute(callbackData.MediaCue.ToEnumerable(), documentCue, parameter.Target?.Source, parameter.DropBefore, parameter.DropOutside, shouldCloneAction: false);
				}
			}
		}).ExecuteAsync();
	}

	private static bool CanDropAsset(ProContentDropParameter<ArrangedCue?> parameter)
	{
		if (parameter.Asset is IProContentAssetVMInternal proContentAssetVMInternal)
		{
			return proContentAssetVMInternal.Asset is IProContentDownloadableAsset;
		}
		return false;
	}

	public void SetMediaBinShowsProContent(bool value)
	{
		SetValue("IsSecondaryTransitionVisible", ref _mediaBinShowsProContent, value);
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
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		_supportFolderHandler.Completed -= RefreshLibrariesContainPresentations;
	}
}
