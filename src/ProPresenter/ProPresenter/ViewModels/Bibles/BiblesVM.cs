using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.Web.Services;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.MainView.Bible;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PanelViewSettings;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Searching;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Transitions;
using ProPresenter.UI;
using ProPresenter.UI.Bibles;
using ProPresenter.UI.ViewModels.Bibles;

namespace ProPresenter.ViewModels.Bibles;

public class BiblesVM : LinkedNotifyPropertyChangedBase, IBiblesVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IRegistrationOperationFactory _registrationOperationFactory;

	private readonly IBibleProvider _bibleProvider;

	private readonly IApp _app;

	private readonly IRegistrationStateProvider _registrationStateProvider;

	private readonly IRegistrationWebResourceService _registrationWebResourceService;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly ILegacyPurchaseBiblesDialogService _legacyPurchaseBiblesDialogService;

	private TransitionParameters? _selectedTransition;

	private string _referenceText = string.Empty;

	private bool _referenceNeedsUpdate = true;

	private bool _contentNeedsUpdate;

	private bool _firstContentUpdate = true;

	private bool _ignoreTranslationChanges;

	private bool _updateInProgress;

	private bool _searchInProgress;

	private BibleReference _startReference;

	private BibleReference _endReference;

	private TemplateSlide? _selectedTemplate;

	private BibleTranslation? _searchTargetBible;

	private BibleSearchEngine? _searchEngine;

	private IPanelViewSettings _viewSettings;

	private int _panelRowCapacity = BibleSettings.Settings.PanelRowCapacity;

	private bool _showVerseNumbers = BibleSettings.Settings.ShowVerseNumbers;

	private bool _breakOnNewVerse = BibleSettings.Settings.BreakOnNewVerse;

	private bool _displayTranslation = BibleSettings.Settings.DisplayTranslation;

	private bool _preserveFontColor = BibleSettings.Settings.PreserveFontColor;

	private ReferenceType _referenceType = BibleSettings.Settings.ReferenceType;

	private ILibrary? _selectedImportLibrary;

	private readonly Pro.UI.Components.RelayCommand<AvailablePurchasedBible> _installPurchasedBibleCommand;

	private readonly Pro.UI.Components.RelayCommand<AvailablePurchasedBible> _uninstallPurchasedBibleCommand;

	private readonly Pro.UI.Components.RelayCommand<AvailableFreeBible> _installFreeBibleCommand;

	private readonly Pro.UI.Components.RelayCommand<AvailableFreeBible> _uninstallFreeBibleCommand;

	private readonly DispatcherTimer _timer = new DispatcherTimer
	{
		Interval = TimeSpan.FromSeconds(0.5)
	};

	private bool _isSlidesCancelled;

	private double _slidesProgress;

	private bool _isGeneratingSlides;

	private bool _scrollToSlide = true;

	private bool _applyTemplateMediaAction;

	private bool _isRefreshingBibles;

	private readonly IOutputService _outputService;

	private readonly IProPresenterResourceService _proPresenterResourceService;

	private bool _scrollToTop;

	private bool _nextOrPreviousVerse;

	private readonly ICopyPresentationIdentifier _copyIdentifier = new CustomPresentationCopyIdentifier();

	private readonly IThemeService _themeService;

	public LoadedBibleCollection LoadedBibles => _bibleProvider.LoadedBibles;

	public INotifyEnumerableChanged<IGrouping<string, AvailableBibleBase>> AvailablePurchasedBibles
	{
		get
		{
			IGrouping<string, AvailableBibleBase>[] collection = (from b in _bibleProvider.AvailableBibles.OfType<AvailablePurchasedBible>()
				group b by b.Name + " (" + b.TrackingAbbreviation + ")").ToArray();
			return new StaticCollectionAdapter<IGrouping<string, AvailableBibleBase>>(collection);
		}
	}

	public INotifyEnumerableChanged<IGrouping<string, AvailableBibleBase>> AvailableFreeBibles
	{
		get
		{
			IGrouping<string, AvailableBibleBase>[] collection = (from b in _bibleProvider.AvailableBibles.OfType<AvailableFreeBible>()
				group b by b.Language).ToArray();
			return new StaticCollectionAdapter<IGrouping<string, AvailableBibleBase>>(collection);
		}
	}

	public bool IsRegistered => _registrationStateProvider.Registration.ProPresenter.IsRegistered;

	public bool AnyBibleLoaded => LoadedBibles.Any();

	public BibleTranslationCollection Translations => BibleSettings.Settings.BibleSearchTranslations;

	public BibleBase? ActiveBible => LoadedBibles.GetLoadedBible(Translations.PrimaryTranslation?.Abbreviation);

	public BibleTranslation[] SearchableBibles => Translations.All.Where((BibleTranslation t) => !string.IsNullOrWhiteSpace(t.Abbreviation)).ToArray();

	public BibleTranslation? SearchTargetBible
	{
		get
		{
			return _searchTargetBible;
		}
		set
		{
			SetValue<BibleTranslation>("SearchTargetBible", ref _searchTargetBible, value, delegate(BibleTranslation o, BibleTranslation n)
			{
				if (o != null)
				{
					o.PropertyChanged -= SearchTargetBible_PropertyChanged;
					_searchEngine = null;
				}
				if (n != null)
				{
					n.PropertyChanged += SearchTargetBible_PropertyChanged;
					BibleBase loadedBible = LoadedBibles.GetLoadedBible(n.Abbreviation);
					if (loadedBible != null)
					{
						_searchEngine = new BibleSearchEngine(loadedBible);
					}
				}
				BibleSettings.Settings.SearchTargetBible = n?.Abbreviation;
			});
		}
	}

	public ObservableCollection<ArrangedCue> SelectedItems { get; } = new ObservableCollection<ArrangedCue>();

	public BiblePresentation WorkingPresentation { get; }

	public string ReferenceText
	{
		get
		{
			return _referenceText;
		}
		set
		{
			SetValue("ReferenceText", ref _referenceText, value, delegate(string o, string n)
			{
				BibleSettings.Settings.ReferenceText = n;
			});
		}
	}

	public bool SearchInProgress
	{
		get
		{
			return _searchInProgress;
		}
		private set
		{
			SetValue("SearchInProgress", ref _searchInProgress, value, (Action)delegate
			{
				OnPropertyChanged("AnySearchResults");
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public ObservableCollection<SearchResult> SearchResults { get; } = new ObservableCollection<SearchResult>();

	public bool AnySearchResults
	{
		get
		{
			if (!SearchInProgress)
			{
				return SearchResults.Any();
			}
			return true;
		}
	}

	public ssAPIOutput OutputController { get; }

	public TransitionHandler TransitionHandler { get; }

	public ILibrary? SelectedImportLibrary
	{
		get
		{
			return _selectedImportLibrary;
		}
		set
		{
			SetValue<ILibrary>("SelectedImportLibrary", ref _selectedImportLibrary, value, delegate(ILibrary o, ILibrary n)
			{
				if (n != null)
				{
					BibleSettings.Settings.SelectedImportLibraryName = n.Name;
				}
			});
		}
	}

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
				WorkingPresentation.SelectedTransition = n;
				OnSetGlobalBibleForegroundTransitionCommand();
			});
		}
	}

	public int PanelRowCapacity
	{
		get
		{
			return _panelRowCapacity;
		}
		set
		{
			SetValue("PanelRowCapacity", ref _panelRowCapacity, value, delegate(int o, int n)
			{
				BibleSettings.Settings.PanelRowCapacity = n;
			});
		}
	}

	public bool ShowVerseNumbers
	{
		get
		{
			return _showVerseNumbers;
		}
		set
		{
			SetValue("ShowVerseNumbers", ref _showVerseNumbers, value, delegate(bool o, bool n)
			{
				BibleSettings.Settings.ShowVerseNumbers = n;
				UpdateContent();
			});
		}
	}

	public bool BreakOnNewVerse
	{
		get
		{
			return _breakOnNewVerse;
		}
		set
		{
			SetValue("BreakOnNewVerse", ref _breakOnNewVerse, value, delegate(bool o, bool n)
			{
				BibleSettings.Settings.BreakOnNewVerse = n;
				if (ReferenceType == ReferenceType.VerseRefs)
				{
					ReferenceType = ReferenceType.PassageEach;
				}
				UpdateContent();
			});
		}
	}

	public bool DisplayTranslation
	{
		get
		{
			return _displayTranslation;
		}
		set
		{
			SetValue("DisplayTranslation", ref _displayTranslation, value, delegate(bool o, bool n)
			{
				BibleSettings.Settings.DisplayTranslation = n;
				UpdateContent();
			});
		}
	}

	public bool PreserveFontColor
	{
		get
		{
			return _preserveFontColor;
		}
		set
		{
			SetValue("PreserveFontColor", ref _preserveFontColor, value, delegate(bool o, bool n)
			{
				BibleSettings.Settings.PreserveFontColor = n;
				UpdateContent();
			});
		}
	}

	public ReferenceType ReferenceType
	{
		get
		{
			return _referenceType;
		}
		set
		{
			SetValue("ReferenceType", ref _referenceType, value, delegate(ReferenceType o, ReferenceType n)
			{
				BibleSettings.Settings.ReferenceType = n;
				UpdateContent();
			});
		}
	}

	public IPanelViewSettings BiblePresentationViewSettings
	{
		get
		{
			return _viewSettings;
		}
		set
		{
			SetValue("BiblePresentationViewSettings", ref _viewSettings, value);
		}
	}

	private TemplateSlide? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			SetValue<TemplateSlide>("SelectedTemplate", ref _selectedTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				if (o != null)
				{
					o.Slide.VisualInvalidated -= UpdateContent;
					o.VisualInvalidated -= Template_VisualInvalidated;
				}
				if (n != null)
				{
					n.Slide.VisualInvalidated += UpdateContent;
					n.VisualInvalidated += Template_VisualInvalidated;
					if (o != null)
					{
						RemapTranslations();
					}
					BibleSettings.Settings.SelectedTemplateID = n.Slide.ID;
					WorkingPresentation.ActiveTemplate = n;
					UpdateContent();
				}
			});
		}
	}

	public INotifyEnumerableChanged<ProPresenterCue> Items => new StaticCollectionAdapter<ProPresenterCue>(new ProPresenterCue[1] { BibleDocumentCue });

	public DocumentCue BibleDocumentCue { get; }

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

	public ArrangedCue? ActiveSlide => _manager.ActiveSlides[WorkingPresentation.Destination];

	public ActiveCueCollection ActiveSlides => _manager.ActiveSlides;

	public bool IsGeneratingSlides
	{
		get
		{
			return _isGeneratingSlides;
		}
		private set
		{
			SetValue("IsGeneratingSlides", ref _isGeneratingSlides, value);
		}
	}

	public bool ScrollToTop
	{
		get
		{
			return _scrollToTop;
		}
		private set
		{
			SetValue("ScrollToTop", ref _scrollToTop, value);
		}
	}

	public bool IsSlidesCancelled
	{
		get
		{
			return _isSlidesCancelled;
		}
		private set
		{
			SetValue("IsSlidesCancelled", ref _isSlidesCancelled, value);
		}
	}

	public double SlidesProgress
	{
		get
		{
			return _slidesProgress;
		}
		private set
		{
			SetValue("SlidesProgress", ref _slidesProgress, value);
		}
	}

	public bool IsRefreshingBibles
	{
		get
		{
			return _isRefreshingBibles;
		}
		private set
		{
			SetValue("IsRefreshingBibles", ref _isRefreshingBibles, value);
		}
	}

	public ICommand CancelGenerateSlidesCommand => new Pro.UI.Components.RelayCommand(delegate
	{
		IsSlidesCancelled = true;
	});

	public IEnumerable<IPlaylist<ProPresenterCue>> Playlists => _proPresenterResourceService.LibraryPlaylists;

	public ICommand<TemplateSlide> SelectTemplateCommand => new Pro.UI.Components.AsyncRelayCommand<TemplateSlide>(SelectTemplateCommandExecutedAsync);

	public ICommand SaveAsDocumentCommand => new Pro.UI.Components.RelayCommand(OnSaveDocumentCommand, () => WorkingPresentation.ArrangementGroups.Any() && SelectedImportLibrary != null);

	public ICommand CopyToCurrentDocumentCommand => new Pro.UI.Components.RelayCommand(OnCopyToCurrentDocumentCommand, () => ActivePresentation != null && WorkingPresentation.ArrangementGroups.Any());

	public ICommand<Playlist<ProPresenterCue>> SaveToSelectedPlaylistCommand => new Pro.UI.Components.RelayCommand<Playlist<ProPresenterCue>>(OnSaveToSelectedPlaylistCommand, (Playlist<ProPresenterCue> p) => WorkingPresentation.ArrangementGroups.Any() && SelectedImportLibrary != null && p is GeneralPlaylist);

	public ICommand GoToNextVerseCommand => new Pro.UI.Components.RelayCommand(OnGoToNextVerseCommand, () => _startReference.IsValid && _endReference.IsValid);

	public ICommand GoToPreviousVerseCommand => new Pro.UI.Components.RelayCommand(OnGoToPreviousVerseCommand, () => _startReference.IsValid && _endReference.IsValid);

	public ICommand CopyCommand => new Pro.UI.Components.RelayCommand(OnCopyCommand, () => SelectedItems.Any());

	public IAsyncRelayCommand<string> SearchKeywordCommand => new CommunityToolkit.Mvvm.Input.AsyncRelayCommand<string>(OnSearchKeywordCommand, (string? s) => SearchTargetBible != null, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);

	public ICommand<SelectBibleReferenceCommandParameter> SelectBookCommand => new Pro.UI.Components.RelayCommand<SelectBibleReferenceCommandParameter>(delegate(SelectBibleReferenceCommandParameter p)
	{
		OnSelectBookCommand(LoadedBibles.GetLoadedBible(Translations.PrimaryTranslation?.Abbreviation), p.Book);
	});

	public ICommand<SelectBibleReferenceCommandParameter> SelectChapterCommand => new Pro.UI.Components.RelayCommand<SelectBibleReferenceCommandParameter>(delegate(SelectBibleReferenceCommandParameter p)
	{
		OnSelectChapterCommand(LoadedBibles.GetLoadedBible(Translations.PrimaryTranslation?.Abbreviation), p.Book, p.Chapter);
		BibleLookupEvent.Publish(BibleLookupLocation.MenuChapter);
	});

	public ICommand<SelectBibleReferenceCommandParameter> SelectVerseCommand => new Pro.UI.Components.RelayCommand<SelectBibleReferenceCommandParameter>(delegate(SelectBibleReferenceCommandParameter p)
	{
		OnSelectVerseCommand(LoadedBibles.GetLoadedBible(Translations.PrimaryTranslation?.Abbreviation), p.Book, p.Chapter, p.Verse);
		BibleLookupEvent.Publish(BibleLookupLocation.MenuVerse);
	});

	public ICommand<SearchResult> SelectSearchChapterCommand => new Pro.UI.Components.RelayCommand<SearchResult>(OnSelectSearchChapterCommand);

	public ICommand<SearchResult> SelectSearchVerseCommand => new Pro.UI.Components.RelayCommand<SearchResult>(OnSelectSearchVerseCommand);

	public ICommand AddBibleTranslationCommand => new Pro.UI.Components.RelayCommand(OnAddBibleTranslationCommand);

	public ICommand<BibleTranslation> RemoveBibleTranslationCommand => new Pro.UI.Components.RelayCommand<BibleTranslation>(OnRemoveBibleTranslationCommand);

	public ICommand<string> UpdateReferenceTextCommand => new Pro.UI.Components.RelayCommand<string>(OnUpdateReferenceTextCommand);

	public ICommand<BibleTranslation> SetTargetSearchBibleCommand => new Pro.UI.Components.RelayCommand<BibleTranslation>(OnSetTargetSearchBibleCommand);

	public ICommand<ArrangedCue> TriggerSlideCommand => new Pro.UI.Components.RelayCommand<ArrangedCue>(OnTriggerSlideCommand);

	public ICommand TriggerPreviousSlideCommand => new Pro.UI.Components.RelayCommand(delegate
	{
		OnTriggerProximalSlideCommand(isNext: false);
	}, () => WorkingPresentation.DefaultArrangement.ArrangedCues.Any());

	public ICommand TriggerNextSlideCommand => new Pro.UI.Components.RelayCommand(delegate
	{
		OnTriggerProximalSlideCommand(isNext: true);
	}, () => WorkingPresentation.DefaultArrangement.ArrangedCues.Any());

	public ICommand<ILibrary> SelectLibraryCommand => new Pro.UI.Components.RelayCommand<ILibrary>(delegate(ILibrary t)
	{
		SelectedImportLibrary = t;
	});

	public ICommand<AvailablePurchasedBible> InstallPurchasedBibleCommand => _installPurchasedBibleCommand;

	public ICommand<AvailablePurchasedBible> UninstallPurchasedBibleCommand => _uninstallPurchasedBibleCommand;

	public ICommand<AvailableFreeBible> InstallFreeBibleCommand => _installFreeBibleCommand;

	public ICommand<AvailableFreeBible> UninstallFreeBibleCommand => _uninstallFreeBibleCommand;

	public ICommand ShowRegistrationCommand => new Pro.UI.Components.RelayCommand(OnShowRegistrationCommand);

	public ICommand GetBiblesCommand => new Pro.UI.Components.RelayCommand(OnGetBiblesCommand);

	public ICommand<(SlideElementBase, BibleTranslation)> SelectVerseElementCommand => new Pro.UI.Components.RelayCommand<(SlideElementBase, BibleTranslation)>(OnSelectVerseTemplateElement, CanSelectTemplateElement);

	public ICommand<(SlideElementBase, BibleTranslation)> SelectReferenceElementCommand => new Pro.UI.Components.RelayCommand<(SlideElementBase, BibleTranslation)>(OnSelectReferenceTemplateElement, CanSelectTemplateElement);

	public ICommand<BibleTranslation> SelectIncludeReferenceWithVerseCommand => new Pro.UI.Components.RelayCommand<BibleTranslation>(OnSelectIncludeReferenceWithVerse);

	public ICommand RefreshBiblesCommand => new Pro.UI.Components.RelayCommand(OnRefreshBiblesCommand);

	private IPresentation? ActivePresentation => (_manager.ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Presentation;

	public event Action? ShowRegistration;

	public BiblesVM(ICoreManager manager, ssAPIOutput outputController, IRegistrationOperationFactory registrationOperationFactory, IBibleProvider bibleProvider, IThemeService themeService, IApp app, ITriggeringFactory triggeringFactory, IPresentationFactory presentationFactory, IRegistrationStateProvider registrationStateProvider, IOutputService outputService, IProPresenterResourceService proPresenterResourceService, IRegistrationWebResourceService registrationWebResourceService, IHyperlinkService hyperlinkService, ILegacyPurchaseBiblesDialogService legacyPurchaseDialogService)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		WorkingPresentation = presentationFactory.CreateBible(null, BibleSettings.Settings.BibleSearchTranslations);
		WorkingPresentation.UndoStack.StartIgnoring();
		_outputService = outputService;
		_proPresenterResourceService = proPresenterResourceService;
		_manager = manager;
		_service = triggeringFactory.Create();
		_bibleProvider = bibleProvider;
		OutputController = outputController;
		_themeService = themeService;
		_app = app;
		_registrationStateProvider = registrationStateProvider;
		_registrationWebResourceService = registrationWebResourceService;
		_hyperlinkService = hyperlinkService;
		_legacyPurchaseBiblesDialogService = legacyPurchaseDialogService;
		_viewSettings = new ThumbnailViewSettings(_app);
		BibleDocumentCue = new DocumentCue(WorkingPresentation, supportsArrangement: false);
		GlobalTransitionProvider transitionProvider = new GlobalTransitionProvider(proPresenterResourceService.Transitions, _app.GlobalBibleTransitionType, _app.GlobalBibleAutoTransitionDuration, _app.GlobalBibleAdvancedTransition?.ToTransition(outputController.AvailableTransitions));
		transitionProvider.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "StoredAutoParameters":
				_app.GlobalBibleAutoTransitionDuration = transitionProvider.StoredAutoParameters?.Duration ?? TimeSlice.Zero;
				break;
			case "StoredAdvancedParameters":
				_app.GlobalBibleAdvancedTransition = transitionProvider.StoredAdvancedParameters?.Serialize();
				break;
			case "ActiveStoreType":
				_app.GlobalBibleTransitionType = transitionProvider.ActiveStoreType.GetValueOrDefault();
				break;
			}
		};
		SelectedTransition = transitionProvider.GetTransition(proPresenterResourceService.Transitions);
		TransitionHandler = new TransitionHandler(proPresenterResourceService.Transitions, transitionProvider);
		TransitionHandler.ActivateTransition(SelectedTransition);
		TransitionHandler.TransitionFinalized += TransitionUpdated;
		_registrationOperationFactory = registrationOperationFactory;
		LoadedBibles.CollectionChanged += LoadedBibles_CollectionChanged;
		_installPurchasedBibleCommand = new Pro.UI.Components.RelayCommand<AvailablePurchasedBible>(OnInstallPurchasedBible, CanInstallPurchasedBible);
		_uninstallPurchasedBibleCommand = new Pro.UI.Components.RelayCommand<AvailablePurchasedBible>(OnUninstallPurchasedBible, CanUninstallPurchasedBible);
		_installFreeBibleCommand = new Pro.UI.Components.RelayCommand<AvailableFreeBible>(OnInstallFreeBible, CanInstallFreeBible);
		_uninstallFreeBibleCommand = new Pro.UI.Components.RelayCommand<AvailableFreeBible>(OnUninstallFreeBible);
		_bibleProvider.InstalledBibles.BibleInstallStarted += delegate
		{
			NotifyPurchasedBibleCommandCanExecuteChanged();
			NotifyFreeBibleCommandCanExecuteChanged();
		};
		_bibleProvider.InstalledBibles.BibleInstallFailed += delegate
		{
			NotifyPurchasedBibleCommandCanExecuteChanged();
			NotifyFreeBibleCommandCanExecuteChanged();
		};
		_bibleProvider.InstalledBibles.BibleInstallCompleted += delegate
		{
			NotifyPurchasedBibleCommandCanExecuteChanged();
			NotifyFreeBibleCommandCanExecuteChanged();
		};
		_timer.Tick += delegate
		{
			if (_contentNeedsUpdate && !_updateInProgress)
			{
				_contentNeedsUpdate = false;
				UpdatePresentationContent(ActiveBible, _firstContentUpdate);
				_firstContentUpdate = false;
			}
		};
		SelectedImportLibrary = proPresenterResourceService.LibraryCollection.FirstOrDefault((ILibrary l) => l.Name == BibleSettings.Settings.SelectedImportLibraryName) ?? _proPresenterResourceService.LibraryCollection.FirstOrDefault();
		SelectedTemplate = proPresenterResourceService.Themes.FindTemplate(BibleSettings.Settings.SelectedTemplateID, "", useDefault: false);
		if (SelectedTemplate == null)
		{
			SelectedTemplate = proPresenterResourceService.Themes.DefaultBibleTheme[0];
			RemapTranslations();
		}
		Translations.TranslationPropertyChanged += Translation_PropertyChanged;
		Translations.CollectionChanged += Translations_CollectionChanged;
		_bibleProvider.AvailableBibles.CollectionChanged += delegate
		{
			OnPropertyChanged("AvailableFreeBibles");
			OnPropertyChanged("AvailablePurchasedBibles");
		};
		if (LoadedBibles.Any())
		{
			LoadSelectedBible();
		}
		SearchTargetBible = Array.Find(SearchableBibles, (BibleTranslation b) => b.Abbreviation?.Equals(BibleSettings.Settings.SearchTargetBible, StringComparison.OrdinalIgnoreCase) ?? false);
		HookupLinkedProperties();
		HookupScreenSizeChanges();
		proPresenterResourceService.LibraryPlaylists.CollectionModified += delegate
		{
			OnPropertyChanged("Playlists");
		};
		WorkingPresentation.UndoStack.StopIgnoring();
		BibleCountStartupEvent.Publish(AvailableFreeBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled), AvailablePurchasedBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled));
	}

	private bool CanSelectTemplateElement((SlideElementBase selectedElement, BibleTranslation translation) data)
	{
		if (data.selectedElement != null)
		{
			return !Translations.All.Any((BibleTranslation b) => b.VerseElement == data.selectedElement || (b.ReferenceElement == data.selectedElement && ReferenceType != ReferenceType.NoReference));
		}
		return true;
	}

	private static void OnSelectVerseTemplateElement((SlideElementBase element, BibleTranslation translation) p)
	{
		p.translation.VerseElement = p.element;
	}

	private static void OnSelectReferenceTemplateElement((SlideElementBase element, BibleTranslation translation) p)
	{
		p.translation.ReferenceElement = p.element;
		p.translation.IncludeReferenceWithVerse = false;
	}

	private static void OnSelectIncludeReferenceWithVerse(BibleTranslation translation)
	{
		translation.ReferenceElement = null;
		translation.IncludeReferenceWithVerse = true;
	}

	private void OnSelectedTransitionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Duration")
		{
			SelectedTransition.ThrowWhenNull("SelectedTransition");
			_app.GlobalBibleAutoTransitionDuration = SelectedTransition.Duration;
		}
	}

	private void TransitionUpdated(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
	}

	private void HookupLinkedProperties()
	{
		LinkAction("ActiveSlide", delegate
		{
			OnPropertyChanged("ActiveSlide");
			if (ActiveSlide != null)
			{
				ScrollToSlide = false;
			}
		});
		LinkProperties("Abbreviation", "SearchableBibles");
		LinkProperties("Abbreviation", "ActiveBible");
		LinkProperties("Registration", "IsRegistered");
		LinkAction(new string[3] { "Abbreviation", "VerseElement", "ReferenceElement" }, delegate
		{
			BibleSettings.Settings.PrimaryTranslation = Translations.PrimaryTranslation;
			if (SearchTargetBible == null || (!Translations.Contains(SearchTargetBible) && Translations.PrimaryTranslation?.Abbreviation != SearchTargetBible.Abbreviation))
			{
				SearchTargetBible = Translations.PrimaryTranslation;
			}
		});
		_manager.PropertyChanged += base.RaiseLinkedValues;
		if (Translations.PrimaryTranslation != null)
		{
			Translations.PrimaryTranslation.PropertyChanged += base.RaiseLinkedValues;
		}
		_registrationStateProvider.PropertyChanged += base.RaiseLinkedValues;
	}

	private void HookupScreenSizeChanges()
	{
		_outputService.OutputConfiguration.AudienceArrangementScreens.CollectionChanged += delegate
		{
			resolveScreenSize();
		};
		_outputService.OutputConfiguration.AudienceArrangementScreens.CollectionModified += delegate
		{
			resolveScreenSize();
		};
		resolveScreenSize();
		void resolveScreenSize()
		{
			ScreenArrangementBase screenArrangementBase = _outputService.OutputConfiguration.AudienceArrangementScreens.FirstOrDefault();
			if (screenArrangementBase != null)
			{
				WorkingPresentation.ChangeSize(screenArrangementBase.TotalSize);
			}
		}
	}

	private void LoadedBibles_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		Translations.PrimaryTranslation.ThrowWhenNull("Translations.PrimaryTranslation");
		if (Translations.PrimaryTranslation.Abbreviation == null)
		{
			Translations.PrimaryTranslation.Abbreviation = e.NewItems?.Cast<BibleBase>().FirstOrDefault()?.TrackingAbbreviation;
		}
		e.OldItems?.Cast<BibleBase>().ForEach(delegate(BibleBase bible)
		{
			Translations.RemoveBibleTranslation(bible.TrackingAbbreviation, LoadedBibles.FirstOrDefault((BibleBase b) => !b.TrackingAbbreviation.Equals(bible.TrackingAbbreviation))?.TrackingAbbreviation);
			if (!Translations.Any() && string.IsNullOrWhiteSpace(Translations.PrimaryTranslation.Abbreviation))
			{
				ClearBibleReferences();
			}
		});
		OnPropertyChanged("AnyBibleLoaded");
		OnPropertyChanged("ActiveBible");
	}

	private void Translation_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (_ignoreTranslationChanges)
		{
			return;
		}
		if (sender == Translations.PrimaryTranslation)
		{
			if (e.PropertyName == "Abbreviation")
			{
				_referenceNeedsUpdate = true;
				if (_startReference.IsValid && _endReference.IsValid)
				{
					ReferenceText = ((ActiveBible != null) ? BibleHelper.GetReferenceText(ActiveBible, _startReference, _endReference) : string.Empty);
				}
			}
			else
			{
				_referenceNeedsUpdate = false;
			}
		}
		UpdateContent();
		OnPropertyChanged("SearchableBibles");
		OnPropertyChanged("ActiveBible");
	}

	private void Translations_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_ignoreTranslationChanges)
		{
			IList? oldItems = e.OldItems;
			if (oldItems != null && oldItems.Cast<BibleTranslation>().Any((BibleTranslation b) => b.VerseElement != null || b.ReferenceElement != null))
			{
				UpdateContent();
			}
			if (!SearchableBibles.Contains<BibleTranslation>(SearchTargetBible))
			{
				SearchTargetBible = Translations.PrimaryTranslation;
			}
			OnPropertyChanged("SearchableBibles");
			OnPropertyChanged("ActiveBible");
		}
	}

	private async Task SelectTemplateCommandExecutedAsync(TemplateSlide? template)
	{
		bool flag = (await _themeService.GetThemePickerSettingsByGroupAsync(ThemePickerGroup.Bible))?.MediaActionEnabled ?? false;
		bool flag2 = flag != _applyTemplateMediaAction;
		if (_selectedTemplate != template)
		{
			SelectedTemplate = template;
		}
		else if (flag2)
		{
			UpdateContent();
		}
		_applyTemplateMediaAction = flag;
	}

	private void RemapTranslations()
	{
		if (SelectedTemplate == null)
		{
			return;
		}
		_ignoreTranslationChanges = true;
		IEnumerable<ClosedBezierPath> availableElements = Translations.GetAvailableElements(SelectedTemplate.Slide);
		foreach (BibleTranslation item in Translations.All)
		{
			item.VerseElement = BibleTemplateHelper.FindElement(availableElements, item.VerseElement, reset: false, autoLinkVerse: true);
			item.ReferenceElement = BibleTemplateHelper.FindElement(availableElements, item.ReferenceElement, reset: false, autoLinkVerse: false, autoLinkReference: true);
		}
		_ignoreTranslationChanges = false;
	}

	private void OnSelectBookCommand(BibleBase? bible, Book? book)
	{
		bible.ThrowWhenNull("bible");
		book.ThrowWhenNull("book");
		Chapter chapter = book.GetChapter(book.LastChapterNumber);
		chapter.ThrowWhenNull("lastChapter");
		UpdateReferenceText(bible, book, book.FirstChapterNumber, book.LastChapterNumber, 1, chapter.LastVerseNumber);
		BibleLookupEvent.Publish(BibleLookupLocation.MenuBook);
	}

	private void OnSelectChapterCommand(BibleBase? bible, Book? book, Chapter? chapter)
	{
		bible.ThrowWhenNull("bible");
		chapter.ThrowWhenNull("chapter");
		UpdateReferenceText(bible, book, chapter.Number, chapter.Number, chapter.FirstVerseNumber, chapter.LastVerseNumber);
	}

	private void OnSelectVerseCommand(BibleBase? bible, Book? book, Chapter? chapter, Verse? verse)
	{
		bible.ThrowWhenNull("bible");
		chapter.ThrowWhenNull("chapter");
		verse.ThrowWhenNull("verse");
		UpdateReferenceText(bible, book, chapter.Number, chapter.Number, verse.StartNumber, verse.EndNumber);
	}

	private void UpdateReferenceText(BibleBase bible, Book? book, int startChapter, int endChapter, int startVerse, int endVerse)
	{
		book.ThrowWhenNull("book");
		_startReference = new BibleReference(book.Index, book.Key, book.Name, startChapter, startVerse);
		_endReference = new BibleReference(book.Index, book.Key, book.Name, endChapter, endVerse);
		UpdateReferenceText(bible);
		UpdateContent();
	}

	private void UpdateReferenceText(BibleBase bible)
	{
		_referenceNeedsUpdate = true;
		ReferenceText = BibleHelper.GetReferenceText(bible, _startReference, _endReference);
	}

	private void OnSelectSearchChapterCommand(SearchResult result)
	{
		OnSelectChapterCommand(LoadedBibles.GetLoadedBible(SearchTargetBible?.Abbreviation), result.Verse.Key.Book, result.Verse.Key.Chapter);
		BibleLookupEvent.Publish(BibleLookupLocation.TextSearchChapter);
	}

	private void OnSelectSearchVerseCommand(SearchResult result)
	{
		OnSelectVerseCommand(LoadedBibles.GetLoadedBible(SearchTargetBible?.Abbreviation), result.Verse.Key.Book, result.Verse.Key.Chapter, result.Verse.Key.Verse);
		BibleLookupEvent.Publish(BibleLookupLocation.TextSearchVerse);
	}

	private void OnAddBibleTranslationCommand()
	{
		BibleBase bibleBase = LoadedBibles.OrderBy((BibleBase b) => b.Name).FirstOrDefault((BibleBase b) => !Translations.Any((BibleTranslation t) => LoadedBibles.GetLoadedBible(t.Abbreviation) == b) && b != ActiveBible);
		if (bibleBase == null)
		{
			MessageDialogService.ShowDialog(LocalizedStrings.Get("BIBLE_ADD_TRANSLATION_ALL_BIBLES_USED_ALERT_message"), LocalizedStrings.Get("BIBLE_ADD_TRANSLATION_ALL_BIBLES_USED_ALERT_info"), DefaultButtons.OK, DefaultButtons.OK);
		}
		else if (BreakOnNewVerse)
		{
			Translations.AddBibleTranslation(bibleBase);
		}
		else if (!BibleSettings.Settings.DoNotShowAgainBreakOnVerse)
		{
			if (MessageDialogService.ShowDialog(LocalizedStrings.Get("BIBLE_SETTINGS_FORCE_BREAK_ON_NEW_VERSE_ALERT_message"), LocalizedStrings.Get("BIBLE_SETTINGS_FORCE_BREAK_ON_NEW_VERSE_ALERT_info"), DefaultButtons.OK, DefaultButtons.OK) == DefaultButtons.OK)
			{
				BreakOnNewVerse = true;
				Translations.AddBibleTranslation(bibleBase);
			}
		}
		else
		{
			BreakOnNewVerse = true;
			Translations.AddBibleTranslation(bibleBase);
		}
	}

	private void OnRemoveBibleTranslationCommand(BibleTranslation bibleTranslation)
	{
		if (bibleTranslation == SearchTargetBible)
		{
			SearchTargetBible = Translations.PrimaryTranslation;
		}
		Translations.RemoveBibleTranslation(bibleTranslation);
	}

	private void LoadSelectedBible()
	{
		ReferenceText = BibleSettings.Settings.ReferenceText;
		UpdateContent();
	}

	private PresentationBase PrepareNewBiblePresentation()
	{
		PresentationBase presentationBase = WorkingPresentation.Clone();
		presentationBase.SelectedTransition = null;
		SetNewBiblePresentationName(presentationBase);
		return presentationBase;
	}

	private void SetNewBiblePresentationName(PresentationBase bible)
	{
		BibleTranslation[] source = (from b in SearchableBibles.Except(Translations.PrimaryTranslation)
			where b?.VerseElement != null || b?.ReferenceElement != null
			select b).ToArray();
		string text = ReferenceText.Replace(":", "_");
		text = ((!source.Any()) ? (text + " (" + getDisplayAbbreviation(Translations.PrimaryTranslation) + ")") : (text + " (" + getDisplayAbbreviation(Translations.PrimaryTranslation) + ", " + string.Join(", ", source.Select(getDisplayAbbreviation)) + ")"));
		text = text.SanitizeFilename();
		bible.Name = text;
		string getDisplayAbbreviation(BibleTranslation? translation)
		{
			return LoadedBibles.FirstOrDefault((BibleBase b) => b.TrackingAbbreviation == translation?.Abbreviation)?.DisplayAbbreviation ?? string.Empty;
		}
	}

	private void OnSaveDocumentCommand()
	{
		SelectedImportLibrary.ThrowWhenNull("SelectedImportLibrary");
		SelectedImportLibrary.Add(PrepareNewBiblePresentation(), userInitiated: true);
		BibleSaveSlidesEvent.Publish(BibleSlideDestination.SaveToLibrary);
	}

	private void OnCopyToCurrentDocumentCommand()
	{
		ActivePresentation.ThrowWhenNull("ActivePresentation");
		ActivePresentation.ArrangementGroups.AddArrangementGroup(new GroupLabel(ReferenceText)).Cues.AddCues(WorkingPresentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).CloneItems());
		BibleSaveSlidesEvent.Publish(BibleSlideDestination.CopyToPresentation);
	}

	private void OnSaveToSelectedPlaylistCommand(Playlist<ProPresenterCue> playlist)
	{
		if (!(playlist is GeneralPlaylist generalPlaylist))
		{
			return;
		}
		int index = -1;
		ProPresenterCue playlistItem = _manager?.ActivePlaylistItem;
		if (playlistItem != null)
		{
			index = generalPlaylist.FindIndex((ProPresenterCue x) => x == playlistItem);
			if (!(playlistItem is HeaderCue))
			{
				index = ((index != -1) ? (index + 1) : generalPlaylist.Count);
			}
			else
			{
				int num = generalPlaylist.FindIndex((ProPresenterCue i) => i is HeaderCue, index + 1);
				index = ((num == -1) ? generalPlaylist.Count : num);
			}
		}
		SelectedImportLibrary.ThrowWhenNull("SelectedImportLibrary");
		DocumentCue documentCue = SelectedImportLibrary.Add(PrepareNewBiblePresentation(), userInitiated: true);
		generalPlaylist.AddPresentationItem(documentCue, index);
		if (_manager != null)
		{
			_manager.ActivePlaylistItem = documentCue;
		}
		BibleSaveSlidesEvent.Publish(BibleSlideDestination.SaveToPlaylist);
	}

	private void OnGoToNextVerseCommand()
	{
		ActiveBible.ThrowWhenNull("ActiveBible");
		BibleReference endReference = BibleHelper.NavigateBibleVerse(ActiveBible, _endReference, isForward: true);
		if (endReference.IsValid)
		{
			_endReference = endReference;
			_nextOrPreviousVerse = true;
			UpdateReferenceText(ActiveBible);
			UpdateContent();
			BibleGenerateNextEvent.Publish(BibleLocation.BibleModule);
		}
	}

	private void OnGoToPreviousVerseCommand()
	{
		ActiveBible.ThrowWhenNull("ActiveBible");
		BibleReference startReference = BibleHelper.NavigateBibleVerse(ActiveBible, _startReference, isForward: false);
		if (startReference.IsValid)
		{
			_startReference = startReference;
			_nextOrPreviousVerse = true;
			UpdateReferenceText(ActiveBible);
			UpdateContent();
			BibleGeneratePreviousEvent.Publish(BibleLocation.BibleModule);
		}
	}

	private void OnInstallPurchasedBible(AvailablePurchasedBible bible)
	{
		_registrationOperationFactory.ActivateBible(bible.ID);
	}

	private bool CanInstallPurchasedBible(AvailablePurchasedBible bible)
	{
		if (_bibleProvider.AvailableBibles.IsBibleAvailable(bible.TrackingAbbreviation, requireActive: false))
		{
			return !_bibleProvider.InstalledBibles.IsInstalling(bible);
		}
		return false;
	}

	private void OnUninstallPurchasedBible(AvailablePurchasedBible bible)
	{
		_registrationOperationFactory.DeactivateBible(bible.ID);
	}

	private bool CanUninstallPurchasedBible(AvailablePurchasedBible bible)
	{
		if (bible.IsActive)
		{
			return !_bibleProvider.InstalledBibles.IsInstalling(bible);
		}
		return false;
	}

	private void NotifyPurchasedBibleCommandCanExecuteChanged()
	{
		_installPurchasedBibleCommand.NotifyCanExecuteChanged();
		_uninstallPurchasedBibleCommand.NotifyCanExecuteChanged();
	}

	private void OnInstallFreeBible(AvailableFreeBible bible)
	{
		_bibleProvider.InstalledBibles.InstallBible(bible, delegate
		{
			NotifyFreeBibleCommandCanExecuteChanged();
			BibleCountInstallEvent.Publish(AvailableFreeBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled), AvailablePurchasedBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled));
		});
		NotifyFreeBibleCommandCanExecuteChanged();
	}

	private bool CanInstallFreeBible(AvailableFreeBible bible)
	{
		if (!bible.IsInstalled && !_bibleProvider.InstalledBibles.IsInstalling(bible))
		{
			return !_bibleProvider.InstalledBibles.IsInstalled(bible);
		}
		return false;
	}

	private void OnUninstallFreeBible(AvailableFreeBible bible)
	{
		_bibleProvider.InstalledBibles.UninstallBible(bible);
		NotifyFreeBibleCommandCanExecuteChanged();
		BibleCountRemoveEvent.Publish(AvailableFreeBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled), AvailablePurchasedBibles.SelectMany((IGrouping<string, AvailableBibleBase> g) => g).Count((AvailableBibleBase g) => g.IsInstalled));
	}

	private void NotifyFreeBibleCommandCanExecuteChanged()
	{
		_installFreeBibleCommand.NotifyCanExecuteChanged();
		_uninstallFreeBibleCommand.NotifyCanExecuteChanged();
	}

	private void OnCopyCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(SelectedItems.Select((ArrangedCue s) => s.Source).GetSlidesData(_copyIdentifier));
	}

	private async Task OnSearchKeywordCommand(string? queryText)
	{
		SearchTargetBible.ThrowWhenNull("SearchTargetBible");
		queryText.ThrowWhenNull("queryText");
		SearchInProgress = true;
		SearchResults.Clear();
		SetOrVerifySearchEngine(SearchTargetBible);
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		await Task.Run(delegate
		{
			IEnumerable<SearchResult> results = _searchEngine?.Search(queryText);
			dispatcher.Invoke((Action)delegate
			{
				SearchResults.AddRange(results ?? Enumerable.Empty<SearchResult>());
			});
		});
		SearchInProgress = false;
	}

	private void OnSetTargetSearchBibleCommand(BibleTranslation bible)
	{
		SearchTargetBible = bible;
	}

	private void OnTriggerSlideCommand(ArrangedCue slide)
	{
		_service.TriggerSlide(slide, new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, WorkingPresentation));
		ScrollToSlide = false;
		BibleTriggerEvent.Publish(BibleLocation.BibleModule);
	}

	private void OnTriggerProximalSlideCommand(bool isNext)
	{
		ScrollToSlide = true;
		IImmutableObservableCollection<ArrangedCue> arrangedCues = WorkingPresentation.DefaultArrangement.ArrangedCues;
		_service.TriggerSlide(arrangedCues.ElementAtOrDefault(((ActiveSlide == null) ? (-1) : arrangedCues.IndexOf(ActiveSlide)) + (isNext ? 1 : (-1))) ?? arrangedCues[0], new SlideTriggerOptions(overrideEnable: false, suppressGoToNext: false, WorkingPresentation));
		BibleTriggerEvent.Publish(BibleLocation.BibleModule);
	}

	private void OnUpdateReferenceTextCommand(string text)
	{
		ReferenceText = text;
		_referenceNeedsUpdate = true;
		UpdateContent();
		BibleLookupEvent.Publish(BibleLookupLocation.TextReference);
	}

	private void UpdateContent()
	{
		_contentNeedsUpdate = !_updateInProgress;
		_timer.Start();
	}

	private void ShowProgress()
	{
		IsSlidesCancelled = false;
		IsGeneratingSlides = true;
		SlidesProgress = 0.0;
	}

	private void UpdatePresentationContent(BibleBase? bible, bool skipUndos)
	{
		if (bible == null)
		{
			return;
		}
		if (_referenceNeedsUpdate)
		{
			if (!BibleHelper.ParseReferenceText(bible, ReferenceText, out _startReference, out _endReference))
			{
				if (skipUndos)
				{
					WorkingPresentation.UndoStack.StartIgnoring();
				}
				ClearBibleReferences();
				if (skipUndos)
				{
					WorkingPresentation.UndoStack.StopIgnoring();
				}
				return;
			}
			_startReference = BibleHelper.ValidateBibleReference(bible, _startReference);
			_endReference = BibleHelper.ValidateBibleReference(bible, _endReference);
			if (!_startReference.IsValid || !_endReference.IsValid)
			{
				return;
			}
			_referenceNeedsUpdate = false;
			ReferenceText = BibleHelper.GetReferenceText(bible, _startReference, _endReference);
		}
		if (!_startReference.IsValid || !_endReference.IsValid)
		{
			return;
		}
		_updateInProgress = true;
		BibleSlideDisplayOptions displayOptions = new BibleSlideDisplayOptions(ReferenceType, BreakOnNewVerse, DisplayTranslation, PreserveFontColor, ShowVerseNumbers, BibleSettings.Settings.GroupMixedRangeVerses);
		Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
		ShowProgress();
		SharedWorkerPool.Queue.AddJob(delegate
		{
			try
			{
				if (skipUndos)
				{
					WorkingPresentation.UndoStack.StartIgnoring();
				}
				WorkingPresentation.UpdateSlides(dispatcher, _startReference, _endReference, ReferenceText, LoadedBibles, displayOptions, _applyTemplateMediaAction, delegate(bool completed, double progress)
				{
					dispatcher.InvokeAsync((Action)delegate
					{
						if (completed)
						{
							ScrollToTop = !_nextOrPreviousVerse;
							_nextOrPreviousVerse = false;
							ScrollToTop = false;
							SlidesProgress = 1.0;
							IsGeneratingSlides = false;
							int translationCount = Translations.Count + ((Translations.PrimaryTranslation != null) ? 1 : 0);
							int count = WorkingPresentation.DefaultArrangement.ArrangedCues.Count;
							int verseLocation = ((Translations.PrimaryTranslation?.VerseElement == null) ? 1 : 2);
							BibleTranslation primaryTranslation = Translations.PrimaryTranslation;
							BibleGenerateSlidesEvent.Publish(translationCount, count, (BibleTextBoxLocation)verseLocation, (primaryTranslation != null && primaryTranslation.IncludeReferenceWithVerse) ? BibleTextBoxLocation.WithVerse : ((Translations.PrimaryTranslation?.ReferenceElement == null) ? BibleTextBoxLocation.None : BibleTextBoxLocation.TextBox), ShowVerseNumbers, BreakOnNewVerse, DisplayTranslation, PreserveFontColor, ReferenceType);
						}
						else
						{
							SlidesProgress = progress;
						}
					});
				}, () => IsSlidesCancelled, Translations);
			}
			catch (Exception ex)
			{
				Log.Error("Failed to update bible slides {0}", ex);
			}
			finally
			{
				_updateInProgress = false;
				if (skipUndos)
				{
					WorkingPresentation.UndoStack.StopIgnoring();
				}
			}
		});
	}

	private void SearchTargetBible_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Abbreviation" && sender is BibleTranslation orVerifySearchEngine)
		{
			BibleSettings.Settings.SearchTargetBible = LoadedBibles.GetLoadedBible(SearchTargetBible?.Abbreviation)?.TrackingAbbreviation;
			SetOrVerifySearchEngine(orVerifySearchEngine);
		}
	}

	private void SetOrVerifySearchEngine(BibleTranslation bibleTranslation)
	{
		if (_searchEngine == null || _searchEngine.Abbreviation != bibleTranslation.Abbreviation)
		{
			BibleBase loadedBible = LoadedBibles.GetLoadedBible(bibleTranslation.Abbreviation);
			_searchEngine = ((loadedBible != null) ? new BibleSearchEngine(loadedBible) : null);
		}
	}

	private void OnShowRegistrationCommand()
	{
		this.ShowRegistration?.Invoke();
	}

	private void OnGetBiblesCommand()
	{
		if (_registrationStateProvider.Registration.ProPresenter is CodeState)
		{
			_legacyPurchaseBiblesDialogService.ShowPurchaseDialog();
		}
		else
		{
			_hyperlinkService.Open(new Uri(_registrationWebResourceService.GetPurchaseBibles()));
		}
	}

	private void ClearBibleReferences()
	{
		ReferenceText = string.Empty;
		_startReference = BibleReference.Invalid;
		_endReference = BibleReference.Invalid;
		WorkingPresentation.ClearSlides();
	}

	private void OnSetGlobalBibleForegroundTransitionCommand()
	{
		_manager.BibleTransition = SelectedTransition;
	}

	private void OnRefreshBiblesCommand()
	{
		OnRefreshBiblesAsync().ExecuteAsync();
	}

	private async Task OnRefreshBiblesAsync()
	{
		IsRefreshingBibles = true;
		await _registrationOperationFactory.RefreshBibles();
		IsRefreshingBibles = false;
	}

	private void Template_VisualInvalidated(TemplateSlide template)
	{
		UpdateContent();
	}
}
