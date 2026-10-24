using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Recent;
using Pro.DO.Triggering;
using Pro.Entity.Persistence;
using Pro.Localization.Services;
using Pro.UI.DialogService;
using Pro.UI.InputActions;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.Startup;
using ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;
using ProPresenter.DO.Calendar;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Label;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO;

public static class DataVault
{
	private static IApp? _app;

	public static LibraryCollection LibraryCollection { get; private set; }

	public static LibraryPlaylistCollection LibraryPlaylistCollection { get; private set; }

	public static VisualPlaylistCollection VisualPlaylistCollection { get; private set; }

	public static AudioPlaylistCollection AudioPlaylistCollection { get; private set; }

	public static EffectsPresetCollection EffectsPresetCollection { get; private set; }

	public static ThemeCollection Themes { get; private set; }

	public static CCLIPresentation CCLIPresentation { get; private set; }

	public static MessageCollection Messages { get; private set; }

	public static TransitionSet Transitions { get; private set; }

	public static IPropCueCollection PropCueCollection { get; private set; }

	public static IPropGroupCollection PropGroupCollection { get; private set; }

	public static IPropSource PropSource { get; private set; }

	public static StagePresentation StagePresentation { get; private set; }

	public static TimerDocument TimerDocument { get; private set; }

	public static PCOOrganization PCOOrganization { get; private set; }

	public static EventCalendar Calendar { get; private set; }

	public static GroupLabelCollection GroupLabels { get; private set; }

	public static SlideLabelCollection SlideLabels { get; private set; }

	public static MacroCollection Macros { get; private set; }

	public static MacroGroupCollection MacroGroups { get; private set; }

	public static IMacroSource MacroSource { get; private set; }

	public static ClearGroupCollection ClearGroups { get; private set; }

	public static PlaylistTemplateCollection PlaylistTemplates { get; private set; }

	public static event Action? VaultInitialized;

	public static void Initialize(IPresentationFactory presentationFactory, IApp app, IPresentationCapableSyncDataFactory syncDataFactory, ITimerFactory timerFactory, ICaptureSettingsDocument captureSettingsDocument, IResiService resiService, IPlaylistActionValidatorFactory playlistActionValidatorFactory, IIndexingService indexingService, IProPresenterResourceService resourceService, ILocalization localization, IOutputRepository outputRepository, IAsyncFileImporter importer, IInputActions inputActions, IImportProcessFactory importProcessFactory, IMediaImportService mediaImportService, IProPresenterDOFactoryProvider factoryProvider, IFileWatcherFactory fileWatcherFactory, IFileSystem fileSystem, IFlagService flagService, IUiScheduler scheduler, ILogger logger, IUiDispatcher uiDispatcher, IActionBinderFactory actionBinderFactory, IProPresenterCueFactory cueFactory, IGeneral general, IMessageDialogService messageDialogService, IMediaService mediaService, IAsyncExecutor asyncExecutor, ThemeCollection themeCollection, ICollectionStorage collectionStorage, ICommonPathsWrapper commonPathsWrapper, ICurrentTime currentTime, StagePresentation stagePresentation, ILocalDocumentSyncerFactory localTimerDocumentSyncerFactory, bool loadLegacy)
	{
		if (_app != null)
		{
			throw new InvalidOperationException();
		}
		ITransitionDescriptionCollection availableTransitions = outputRepository.AvailableTransitions;
		Log.Info("Initializing the data vault...");
		_app = app;
		Log.Info("Data vault tier 1 [timers, audio playlists, effect presets, transitions, pco, group labels, slide labels]...");
		Log.Info("Loading timers...");
		TimerDocument = new TimerDocument(syncDataFactory, scheduler, flagService, factoryProvider, localTimerDocumentSyncerFactory, loadLegacy);
		Log.Info("Loading audio playlists...");
		AudioPlaylistCollection = new AudioPlaylistCollection(app, importer, factoryProvider.MediaFactory, availableTransitions, syncDataFactory, flagService, factoryProvider, scheduler, actionBinderFactory, loadLegacy);
		Log.Info("Loading effect presets...");
		EffectsPresetCollection = new EffectsPresetCollection(syncDataFactory, flagService, scheduler, factoryProvider, outputRepository.AvailableEffects, collectionStorage, commonPathsWrapper, loadLegacy);
		if (availableTransitions.Count == 0)
		{
			throw new DataVaultException(ErrorCode.DataVaultFailedToLoadTransitions);
		}
		Log.Info("Loading transitions...");
		Transitions = new TransitionSet(syncDataFactory, availableTransitions, app.RecentTransitions, new WorkspacePathProvider(CommonPaths.TransitionPresetsRelative, loadLegacy), flagService, collectionStorage, factoryProvider.EntityDocumentSyncerFactory, factoryProvider.EntityFactory);
		Log.Info("Loading pco...");
		PCOOrganization = new PCOOrganization();
		Log.Info("Loading group labels...");
		GroupLabels = new GroupLabelCollection(syncDataFactory, factoryProvider, scheduler, flagService, loadLegacy);
		Log.Info("Loading slide labels...");
		SlideLabels = new SlideLabelCollection(syncDataFactory, factoryProvider, scheduler, flagService, loadLegacy);
		Transitions.RecentTransitions.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<RecentTransition>().ForEach(delegate(RecentTransition item)
			{
				item.Preset.PropertyChanged -= RecentPresetPropertyChanged;
			});
			e.NewItems?.OfType<RecentTransition>().ForEach(delegate(RecentTransition item)
			{
				item.Preset.PropertyChanged += RecentPresetPropertyChanged;
			});
			UpdateRecentList();
		};
		Log.Info("Done with data vault tier 1");
		Log.Info("Data vault tier 2 [media bin helper]...");
		Log.Info("Loading media bin helper...");
		MediaBinHelper.SetEffectsPreset(EffectsPresetCollection);
		Log.Info("Done with data vault tier 2");
		Log.Info("Data vault tier 3 [themes, ccli, props, stage displays, messages, media playlists, clear groups]...");
		Log.Info("Assigning themes...");
		Themes = themeCollection;
		Log.Info("Loading ccli...");
		CCLIPresentation = new CCLIPresentation(factoryProvider, availableTransitions, syncDataFactory, flagService, scheduler, actionBinderFactory, general, loadLegacy);
		Log.Info("Loading props...");
		PropCueCollection = new PropCueCollection(app, localization, availableTransitions, factoryProvider);
		PropGroupCollection = new PropGroupCollection(_app, localization, syncDataFactory, availableTransitions, factoryProvider, flagService, scheduler, loadLegacy);
		PropSource = new PropGroupCollectionSource(PropGroupCollection);
		Log.Info("Loading stage displays...");
		StagePresentation = stagePresentation;
		Log.Info("Loading messages...");
		Messages = new MessageCollection(syncDataFactory, Themes, flagService, scheduler, factoryProvider, localTimerDocumentSyncerFactory, loadLegacy);
		Log.Info("Loading media playlists...");
		VisualPlaylistCollection = new VisualPlaylistCollection(app, timerFactory, mediaImportService, factoryProvider.MediaFactory, availableTransitions, syncDataFactory, scheduler, flagService, factoryProvider, actionBinderFactory, mediaService, asyncExecutor, uiDispatcher, loadLegacy);
		Log.Info("Loading clear groups...");
		ClearGroups = new ClearGroupCollection(syncDataFactory, factoryProvider, scheduler, flagService, loadLegacy);
		Log.Info("Done with data vault tier 3");
		Log.Info("Data vault tier 4 [macros]...");
		Log.Info("Loading macros...");
		Macros = new MacroCollection(app);
		MacroGroups = new MacroGroupCollection(syncDataFactory, app, localization, scheduler, flagService, actionBinderFactory, factoryProvider.EntityDocumentSyncerFactory, factoryProvider.EntityFactory, factoryProvider.DocumentFactory, loadLegacy);
		MacroSource = new MacroGroupSource(MacroGroups);
		Log.Info("Done with data vault tier 4");
		Log.Info("Data vault tier 5 [libraries]...");
		Log.Info("Loading libraries...");
		LibraryCollection = new LibraryCollection(presentationFactory, indexingService, syncDataFactory, new DataIdDuplicatedEventPublisher(), fileWatcherFactory, fileSystem, uiDispatcher, messageDialogService, flagService, factoryProvider, scheduler, commonPathsWrapper, collectionStorage, actionBinderFactory, loadLegacy);
		Log.Info("Done with data vault tier 5");
		Log.Info("Data vault tier 6 [standard playlists]...");
		Log.Info("Loading standard playlists...");
		LibraryPlaylistCollection = new LibraryPlaylistCollection(resourceService, syncDataFactory, importProcessFactory, factoryProvider.EntityFactory, logger, cueFactory, factoryProvider.MediaFactory, scheduler, flagService, factoryProvider, actionBinderFactory, loadLegacy);
		Log.Info("Done with data vault tier 6");
		Log.Info("Data vault tier 7 [event calendar, show group hotkeys]...");
		Log.Info("Loading event calendar...");
		Calendar = new EventCalendar(syncDataFactory, timerFactory, flagService, factoryProvider, scheduler, actionBinderFactory, loadLegacy);
		Log.Info("Loading show group hotkeys...");
		inputActions.InitializeShowGroups();
		Log.Info("Loading playlist templates...");
		PlaylistTemplates = new PlaylistTemplateCollection(syncDataFactory, factoryProvider, flagService, scheduler, logger, cueFactory, actionBinderFactory);
		Log.Info("Done with data vault tier 7");
		Log.Info("Done initializing the data vault");
		RecordAnalytics(inputActions);
		DataVault.VaultInitialized?.Invoke();
	}

	private static void RecentPresetPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateRecentList();
	}

	private static void UpdateRecentList()
	{
		if (_app != null)
		{
			_app.RecentTransitions = Transitions.RecentTransitions.Select((RecentTransition r) => r.Preset.Serialize()).ToList();
		}
	}

	private static void RecordAnalytics(IInputActions inputActions)
	{
		if (UnitTestDetector.IsInUnitTest)
		{
			return;
		}
		int libraryPlaylistCount = 0;
		int libraryPlaylistFolderCount = 0;
		int libraryPlaylistMaxDepth = 1;
		LibraryPlaylistCollection.IteratePlaylists(delegate(IPlaylist<ProPresenterCue> playlist, int depth)
		{
			libraryPlaylistCount++;
			if (playlist.Type == PlaylistType.Group)
			{
				libraryPlaylistFolderCount++;
			}
			libraryPlaylistMaxDepth = Math.Max(libraryPlaylistMaxDepth, depth);
		});
		int mediaBinPlaylistCount = 0;
		int mediaBinPlaylistFolderCount = 0;
		int mediaBinPlaylistMaxDepth = 1;
		int mediaBinStandardPlaylistCount = 0;
		int mediaBinSmartPlaylistCount = 0;
		VisualPlaylistCollection.IteratePlaylists(delegate(IPlaylist<MediaCue> playlist, int depth)
		{
			mediaBinPlaylistCount++;
			switch (playlist.Type)
			{
			case PlaylistType.Group:
				mediaBinPlaylistFolderCount++;
				break;
			case PlaylistType.Custom:
				mediaBinStandardPlaylistCount++;
				break;
			case PlaylistType.Smart:
				mediaBinSmartPlaylistCount++;
				break;
			}
			mediaBinPlaylistMaxDepth = Math.Max(mediaBinPlaylistMaxDepth, depth);
		});
		int audioBinPlaylistCount = 0;
		int audioBinPlaylistFolderCount = 0;
		int audioBinPlaylistMaxDepth = 1;
		AudioPlaylistCollection.IteratePlaylists(delegate(IPlaylist<MediaCue> playlist, int depth)
		{
			audioBinPlaylistCount++;
			if (playlist.Type == PlaylistType.Group)
			{
				audioBinPlaylistFolderCount++;
			}
			audioBinPlaylistMaxDepth = Math.Max(audioBinPlaylistMaxDepth, depth);
		});
		int themeFolderCount = 0;
		int themeFolderMaxDepth = 0;
		int themeSlideCount = 0;
		if (Themes.ThemeTree != null)
		{
			countThemeContainer(Themes.ThemeTree);
		}
		StartupContentEvent.Publish(LibraryCollection.Count, libraryPlaylistCount, libraryPlaylistFolderCount, libraryPlaylistMaxDepth, mediaBinPlaylistCount, mediaBinPlaylistFolderCount, mediaBinPlaylistMaxDepth, mediaBinStandardPlaylistCount, mediaBinSmartPlaylistCount, VisualPlaylistCollection.LiveVideoPlaylist.Count, audioBinPlaylistCount, audioBinPlaylistFolderCount, audioBinPlaylistMaxDepth, TimerDocument.Timers.Count, Messages.Count, PropCueCollection.Count, countCues(StagePresentation), MacroSource.MacroGroups.Sum((ProPresenter.DO.MacroGroups.MacroGroup mg) => mg.Count), MacroSource.MacroGroups.Count(), MacroSource.MacroGroups.Sum((ProPresenter.DO.MacroGroups.MacroGroup mg) => mg.Count((ProPresenterMacro p) => p.ImageType == Pro.DO.Triggering.ImageType.Custom)), PropSource.PropGroups.Sum((IPropGroup pg) => pg.Select((IPropCue p) => p?.SlideAction).NonNull().Count((PropSlideAction s) => s.AutoClearEnabled)), PropSource.PropGroups.Count(), PropSource.PropGroups.Count((IPropGroup g) => g.SingleMode));
		StartupClearGroupEvent.Publish(ClearGroups.Count, ClearGroups.Count((ClearGroup g) => g.IsHiddenInPreview), ClearGroups.Count((ClearGroup g) => g.ImageType != ProPresenter.DO.ClearGroups.ImageType.Custom), ClearGroups.Count((ClearGroup g) => g.ImageType == ProPresenter.DO.ClearGroups.ImageType.Custom), ClearGroups.Count((ClearGroup g) => g.IsIconTinted));
		IEnumerable<InputAction> source = inputActions.SelectMany((InputActionGroupBase g) => g);
		StartupKeyMappingEvent.Publish(source.Count((InputAction a) => a.IsCustomized), source.Count((InputAction a) => a.Type == InputActionType.ClearGroup), source.Count((InputAction a) => a.Type == InputActionType.GroupLabel), source.Count((InputAction a) => a.Type == InputActionType.Macro), source.Count((InputAction a) => a.Type == InputActionType.Prop), source.Count((InputAction a) => a.Type == InputActionType.MenuItem));
		StartupThemesEvent.Publish(Themes.Count, themeFolderCount, themeFolderMaxDepth, themeSlideCount);
		static int countCues(PresentationBase presentation)
		{
			return presentation.DefaultArrangement.ArrangedCues.Count;
		}
		void countThemeContainer(ThemeContainer parent, int depth = 0)
		{
			if (parent == null)
			{
				return;
			}
			themeFolderMaxDepth = Math.Max(themeFolderMaxDepth, depth);
			foreach (ThemeContainer child in parent.Children)
			{
				if (child.Theme == null)
				{
					themeFolderCount++;
					countThemeContainer(child, depth + 1);
				}
				else
				{
					themeSlideCount += child.Theme.Count;
				}
			}
		}
	}

	public static void Cleanup()
	{
		LibraryCollection?.Dispose();
		LibraryPlaylistCollection?.Dispose();
		VisualPlaylistCollection?.Dispose();
		Messages?.Dispose();
		StagePresentation?.Dispose();
		CCLIPresentation?.Dispose();
	}
}
