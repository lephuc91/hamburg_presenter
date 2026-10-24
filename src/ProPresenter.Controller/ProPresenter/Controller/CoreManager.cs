using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.HTTP;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Effects;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using Pro.ssAPI;
using Pro.ssAPI.Devices;
using ProPresenter.Controller.AsyncTransferHandlers;
using ProPresenter.Controller.Links;
using ProPresenter.Controller.NetworkAPI.Transmit;
using ProPresenter.Controller.Outputs;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ClearGroups;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;
using ProPresenter.DO.Messages;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.GeneralSettings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.SongSelect;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.Rendering;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.AsyncTransfers;
using ProPresenterCore.ProCore.Interop.Triggering.Transfers;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_activeCuesChangedSubscription", "_displaySettingsTimer", "_stageLayoutTriggerer" })]
public class CoreManager : LinkedNotifyPropertyChangedBase, IInternalCoreManager, ICoreManager, INotifyPropertyChanged, IApplicationEventHandler, IDisposable
{
	private readonly TimeSlice DocumentChangeThrottle = TimeSlice.FromMilliseconds(100.0);

	private readonly MonitorController _monitorController;

	private bool _needToSwitchActivePlaylistItem;

	private ILibrary? _activeLibrary;

	private Playlist<ProPresenterCue>? _activeLibraryPlaylist;

	private ProPresenterCue? _activePlaylistItem;

	private VisualPlaylist? _activeVisualPlaylist;

	private AudioPlaylist? _activeAudioPlaylist;

	private MacroGroup? _activeMacroGroup;

	private IPropGroup? _activePropGroup;

	private readonly ObservableCollection<IPropCue> _activeProps = new ObservableCollection<IPropCue>();

	private readonly ObservableCollection<ProPresenter.DO.Messages.Message> _activeMessages = new ObservableCollection<ProPresenter.DO.Messages.Message>();

	private bool _audienceScreensVisible;

	private bool _stageScreensVisible;

	private bool _slideOnStageDisplayOnly;

	private readonly SlideEnvironments _slideEnvironments = new SlideEnvironments();

	private readonly TransportStatus _transportStatus = new TransportStatus();

	private readonly Dictionary<ProLayerIndex, (PlaybackMarkerCollection collection, System.Action dataModified)> _activeMarkers = new Dictionary<ProLayerIndex, (PlaybackMarkerCollection, System.Action)>();

	private MediaCue? _activeLibraryBackground;

	private MediaCue? _activeMediaBinBackground;

	private MediaCue? _activeLiveVideo;

	private MediaCue? _previouslyActiveBackground;

	private MediaCue? _mostRecentActiveMedia;

	private MediaCue? _previouslyActiveAudio;

	private MediaCue? _mostRecentActiveAudio;

	private MediaCue? _activeAudio;

	private ProPresenterCue? _nextPresentation;

	private ProPresenterCue? _previousPresentation;

	private MediaAction? _logo;

	private readonly ssAPIOutput _ssAPIOutput;

	private readonly IPeriodicTimer _displaySettingsTimer;

	private bool _outputChangePending = true;

	private bool _audioInputUpdating;

	private readonly IUiDispatcher _dispatcher;

	private readonly ITimelineManager _timelineManager;

	private readonly IGeneral _general;

	private TransitionParameters? _backgroundTransition;

	private TransitionParameters? _messagesTransition;

	private TransitionParameters? _foregroundTransition;

	private TransitionParameters? _bibleTransition;

	private TransitionParameters? _propsTransition;

	private TransitionParameters? _audioTransition;

	private readonly ThrottledStageLayoutTriggerer _stageLayoutTriggerer;

	private StageData _stageDoc = new StageData(null);

	private readonly ThrottledSerializer<IPropGroupCollection, PropDocument> _propGroups;

	private readonly ThrottledSerializer<MessageCollection, MessageDocument> _messages;

	private readonly ThrottledSerializer<CCLIPresentation, CCLIDocument> _ccliSlide;

	private readonly ThrottledSerializer<AudienceLook, SerializedLook> _liveLook;

	private readonly ThrottledSerializer<IAudienceLookCollection, Dictionary<Guid, SerializedLook>> _audienceLooks;

	private readonly ThrottledSerializer<IMaskCollection, Dictionary<Guid, CustomSlide>> _masks;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _backgroundTxSerializer;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _propsTxSerializer;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _messagesTxSerializer;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _foregroundTxSerializer;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _bibleTxSerializer;

	private readonly ThrottledSerializer<ICoreManager, Transition?> _audioTxSerializer;

	private readonly ThrottledSerializer<LibraryPlaylistCollection, PlaylistDocument> _libraryPlaylistSerializer;

	private readonly ThrottledSerializer<TimerDocument, Dictionary<Guid, Pro.SerializationInterop.RVProtoData.Timer>> _timers;

	private readonly ThrottledSerializer<MacroGroupCollection, MacrosDocument> _macroGroups;

	private readonly ThrottledSerializer<AudioPlaylistCollection, PlaylistDocument> _audioPlaylistSerializer;

	private readonly ThrottledSerializer<VisualPlaylistCollection, PlaylistDocument> _visualPlaylistSerializer;

	private readonly IDebouncer<(ProPresenterWorkspace data, bool triggerLiveLook)> _workspaceDebouncer;

	private readonly INetworkTriggerDataTransferFactory _networkTriggerDataTransferFactory;

	private CaptureInformation _captureInformation = new CaptureInformation(null, string.Empty, Colors.Transparent);

	private readonly ConcurrentDictionary<ITriggerOperation, ProPresenterMacro> _triggeredMacros = new ConcurrentDictionary<ITriggerOperation, ProPresenterMacro>();

	private readonly IThemeService _themeService;

	private readonly IReportRepository _reportRepo;

	private readonly ITransferHandlerFactory _transferHandlerFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly ITimecodeService _timecodeService;

	private readonly IMessageService _messageService;

	private readonly IProPresenterResourceService _resources;

	private readonly IOutputService _outputService;

	private readonly IApp _app;

	private readonly IRestClientFactory _restClientFactory;

	private IDisposable? _activeCuesChangedSubscription;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	private ConcurrentDictionary<ProLayerIndex, TimeSlice> AutoAdvanceTimeRemaining { get; } = new ConcurrentDictionary<ProLayerIndex, TimeSlice>();

	public ISongSelectConsumer SongSelectConsumer { get; }

	public IMultiTracksConsumer MultiTracksConsumer { get; }

	public IPCOConsumer PCOConsumer { get; }

	public ILibrary? ActiveLibrary
	{
		get
		{
			return _activeLibrary;
		}
		set
		{
			SetValue<ILibrary>("ActiveLibrary", ref _activeLibrary, value, delegate(ILibrary o, ILibrary n)
			{
				this.ActiveLibraryChanged?.Invoke(o, n);
			});
		}
	}

	public Playlist<ProPresenterCue>? ActiveLibraryPlaylist
	{
		get
		{
			return _activeLibraryPlaylist;
		}
		set
		{
			SetValue<Playlist<ProPresenterCue>>("ActiveLibraryPlaylist", ref _activeLibraryPlaylist, value, delegate(Playlist<ProPresenterCue> o, Playlist<ProPresenterCue> n)
			{
				this.ActivePlaylistChanged?.Invoke(o, n);
				if (ActivePlaylistItem != null && ActiveLibraryPlaylist != null)
				{
					LibraryPlaylistFocusedUpdated.Publish(ActivePlaylistItem, ActiveLibraryPlaylist);
				}
				OnActiveLibraryPlaylistChanged(o, n);
				if (_activeLibraryPlaylist != null)
				{
					SendLibraryPlaylistFocused(_activeLibraryPlaylist);
				}
			});
		}
	}

	public ProPresenterCue? ActivePlaylistItem
	{
		get
		{
			return _activePlaylistItem;
		}
		set
		{
			SetValue<ProPresenterCue>("ActivePlaylistItem", ref _activePlaylistItem, value, delegate(ProPresenterCue o, ProPresenterCue n)
			{
				UpdateNextPresentations();
				HookupArrangementChanged(n as IDocumentCue);
				(n as IDocumentCue)?.DocumentAction?.Presentation?.DefaultArrangement.ForEach(delegate(CueGroup g)
				{
					g.Cues.ForEach(delegate(SlideCue c)
					{
						c.UpdateValidity();
					});
				});
				ActiveLibraryMedia = null;
				this.ActivePlaylistItemChanged?.Invoke(o, n);
				if (o is IDocumentCue documentCue)
				{
					documentCue.DocumentAction?.StopWatchingMedia();
				}
				if (n is IDocumentCue documentCue2)
				{
					documentCue2.DocumentAction?.StartWatchingMedia();
				}
				this.PresentationCueFocusChanged?.Invoke(_activePlaylistItem);
				if (_activePlaylistItem != null)
				{
					CueFocusChange.Publish(_activePlaylistItem);
					SendLibraryPlaylistItemFocused(_activePlaylistItem);
				}
				if (ActivePlaylistItem != null && ActiveLibraryPlaylist != null)
				{
					LibraryPlaylistFocusedUpdated.Publish(ActivePlaylistItem, ActiveLibraryPlaylist);
				}
			});
		}
	}

	public MacroGroup? ActiveMacroGroup
	{
		get
		{
			return _activeMacroGroup;
		}
		set
		{
			SetValue("ActiveMacroGroup", ref _activeMacroGroup, value, (System.Action)delegate
			{
				DataVault.MacroSource.ActiveCollection = ActiveMacroGroup;
			}, (Predicate<MacroGroup>?)null, referenceComparison: false);
		}
	}

	public IPropGroup? ActivePropGroup
	{
		get
		{
			return _activePropGroup;
		}
		set
		{
			SetValue("ActivePropGroup", ref _activePropGroup, value, (System.Action)delegate
			{
				DataVault.PropSource.ActiveCollection = ActivePropGroup;
			}, (Predicate<IPropGroup>?)null, referenceComparison: false);
		}
	}

	public ProPresenterCue? ActiveSlideParent => _slideEnvironments[Destination.GetValueOrDefault()]?.PlaylistItem;

	public ProPresenterCue? ActivePresentationParent => _slideEnvironments[OutputDestination.Presentation]?.PlaylistItem;

	public ProPresenterCue? ActiveAnnouncementParent => _slideEnvironments[OutputDestination.Announcement]?.PlaylistItem;

	public TransitionParameters? BackgroundTransition
	{
		get
		{
			return _backgroundTransition;
		}
		set
		{
			SetValue<TransitionParameters>("BackgroundTransition", ref _backgroundTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _backgroundTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _backgroundTxSerializer.SourceUpdated;
				}
				_backgroundTxSerializer.SourceUpdated();
			});
		}
	}

	public TransitionParameters? MessagesTransition
	{
		get
		{
			return _messagesTransition;
		}
		set
		{
			SetValue<TransitionParameters>("MessagesTransition", ref _messagesTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _messagesTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _messagesTxSerializer.SourceUpdated;
				}
				_messagesTxSerializer.SourceUpdated();
			});
		}
	}

	public TransitionParameters? ForegroundTransition
	{
		get
		{
			return _foregroundTransition;
		}
		set
		{
			SetValue<TransitionParameters>("ForegroundTransition", ref _foregroundTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _foregroundTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _foregroundTxSerializer.SourceUpdated;
				}
				_foregroundTxSerializer.SourceUpdated();
			});
		}
	}

	public TransitionParameters? BibleTransition
	{
		get
		{
			return _bibleTransition;
		}
		set
		{
			SetValue<TransitionParameters>("BibleTransition", ref _bibleTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _bibleTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _bibleTxSerializer.SourceUpdated;
				}
				_bibleTxSerializer.SourceUpdated();
			});
		}
	}

	public TransitionParameters? AudioTransition
	{
		get
		{
			return _audioTransition;
		}
		set
		{
			SetValue<TransitionParameters>("AudioTransition", ref _audioTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _audioTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _audioTxSerializer.SourceUpdated;
				}
				_audioTxSerializer.SourceUpdated();
			});
		}
	}

	public TransitionParameters? PropsTransition
	{
		get
		{
			return _propsTransition;
		}
		set
		{
			SetValue<TransitionParameters>("PropsTransition", ref _propsTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				if (o != null)
				{
					o.PropertyChanged -= _propsTxSerializer.SourceUpdated;
				}
				if (n != null)
				{
					n.PropertyChanged += _propsTxSerializer.SourceUpdated;
				}
				_propsTxSerializer.SourceUpdated();
			});
		}
	}

	public VisualPlaylist? ActiveVisualPlaylist
	{
		get
		{
			return _activeVisualPlaylist;
		}
		set
		{
			SetValue("ActiveVisualPlaylist", ref _activeVisualPlaylist, value, OnActiveVisualPlaylistChanged);
		}
	}

	public AudioPlaylist? ActiveAudioPlaylist
	{
		get
		{
			return _activeAudioPlaylist;
		}
		set
		{
			SetValue<AudioPlaylist>("ActiveAudioPlaylist", ref _activeAudioPlaylist, value, delegate(AudioPlaylist o, AudioPlaylist n)
			{
				this.ActiveAudioPlaylistChanged?.Invoke(n);
				AudioPlaylistFocusedUpdated.Publish(n);
				SendAudioPlaylistFocused(n);
			});
		}
	}

	public ImmutableObservableCollection<IPropCue> ActiveProps => _activeProps.ConvertImmutable();

	public ImmutableObservableCollection<ProPresenter.DO.Messages.Message> ActiveMessages => _activeMessages.ConvertImmutable();

	public bool IsContiguousActive
	{
		get
		{
			return General.Settings.ContiguousViewEnabled;
		}
		set
		{
			General.Settings.ContiguousViewEnabled = value;
		}
	}

	public bool AudienceEnable
	{
		get
		{
			return _audienceScreensVisible;
		}
		private set
		{
			SetValue("AudienceEnable", ref _audienceScreensVisible, value, delegate(bool o, bool n)
			{
				General.Settings.AudienceScreensEnabled = n;
				ToggleAudienceScreensUpdated.Publish(n);
			});
		}
	}

	public bool StageEnable
	{
		get
		{
			return _stageScreensVisible;
		}
		private set
		{
			SetValue("StageEnable", ref _stageScreensVisible, value, delegate(bool o, bool n)
			{
				General.Settings.StageScreensEnabled = n;
				ToggleStageScreensUpdated.Publish(n);
			});
		}
	}

	public bool SlideOnStageDisplayOnly
	{
		get
		{
			return _slideOnStageDisplayOnly;
		}
		private set
		{
			SetValue("SlideOnStageDisplayOnly", ref _slideOnStageDisplayOnly, value);
		}
	}

	public ArrangedCue? ActiveSlide => ActiveSlides[Destination.GetValueOrDefault()];

	public ArrangedCue? ActivePresentationSlide => ActiveSlides[OutputDestination.Presentation];

	public ArrangedCue? NextPresentationSlide => _slideEnvironments[OutputDestination.Presentation]?.NextLogical;

	public ActiveCueCollection ActiveSlides { get; } = new ActiveCueCollection();

	private ActiveCueCollection PreviouslyActiveSlides { get; } = new ActiveCueCollection();

	public BuildPositionCollection SlideBuildPositions { get; } = new BuildPositionCollection();

	public MediaCue? ActiveLibraryMedia
	{
		get
		{
			return _activeLibraryBackground;
		}
		private set
		{
			SetValue("ActiveLibraryMedia", ref _activeLibraryBackground, value);
		}
	}

	public MediaCue? ActiveMediaBinBackground
	{
		get
		{
			return _activeMediaBinBackground;
		}
		private set
		{
			SetValue("ActiveMediaBinBackground", ref _activeMediaBinBackground, value);
		}
	}

	public MediaCue? ActiveLiveVideo
	{
		get
		{
			return _activeLiveVideo;
		}
		private set
		{
			SetValue("ActiveLiveVideo", ref _activeLiveVideo, value);
		}
	}

	public MediaCue? MostRecentActiveMedia
	{
		get
		{
			return _mostRecentActiveMedia;
		}
		private set
		{
			SetValue("MostRecentActiveMedia", ref _mostRecentActiveMedia, value);
		}
	}

	public MediaCue? MostRecentActiveAudio
	{
		get
		{
			return _mostRecentActiveAudio;
		}
		private set
		{
			SetValue("MostRecentActiveAudio", ref _mostRecentActiveAudio, value);
		}
	}

	public MediaCue? ActiveAudio
	{
		get
		{
			return _activeAudio;
		}
		private set
		{
			SetValue<MediaCue>("ActiveAudio", ref _activeAudio, value, delegate(MediaCue o, MediaCue n)
			{
				if (o != null && ActiveAudioItems.Contains(o))
				{
					ActiveAudioItems.Remove(o);
				}
				if (n != null && !ActiveAudioItems.Contains(n))
				{
					ActiveAudioItems.Add(n);
				}
			});
		}
	}

	public ObservableCollection<MediaCue> ActiveAudioItems { get; } = new ObservableCollection<MediaCue>();

	public ProPresenterCue? NextPresentation
	{
		get
		{
			return _nextPresentation;
		}
		private set
		{
			SetValue("NextPresentation", ref _nextPresentation, value);
		}
	}

	public ProPresenterCue? PreviousPresentation
	{
		get
		{
			return _previousPresentation;
		}
		private set
		{
			SetValue("PreviousPresentation", ref _previousPresentation, value);
		}
	}

	public MediaAction? Logo
	{
		get
		{
			return _logo;
		}
		set
		{
			SetValue("Logo", ref _logo, value);
		}
	}

	private OutputDestination? Destination => (ActivePlaylistItem as IDocumentCue)?.DocumentAction?.Destination;

	public IOutputConfiguration OutputConfiguration => _outputService.OutputConfiguration;

	public IProCoreInstance ProCore { get; }

	public ICaptureSettingsDocument? CaptureSettings => OutputConfiguration?.CaptureSettings;

	public ITransportStatus TransportStatus => _transportStatus;

	public INetworkCommandTrigger NetworkCommandTrigger { get; }

	public event SlideTriggeredAction? SlideTriggered;

	public event AudioTriggeredAction? AudioTriggered;

	public event MessageTriggeredAction? MessageTriggered;

	public event ClearAllAction? AllCleared;

	public event SlideClearedAction? SlideCleared;

	public event BackgroundClearedAction? BackgroundCleared;

	public event AudioClearedAction? AudioCleared;

	public event PropClearedAction? PropCleared;

	public event MessageClearedAction? MessageCleared;

	public event TestPatternClearedAction? TestPatternCleared;

	public event Action<LiveAudienceLook>? LiveLookChanged;

	public event Action<ProPresenterCue, ProPresenterCue>? ActivePlaylistItemChanged;

	public event Action<ILibrary, ILibrary>? ActiveLibraryChanged;

	public event Action<Playlist<ProPresenterCue>, Playlist<ProPresenterCue>>? ActivePlaylistChanged;

	public event PresentationCueFocusChangedAction? PresentationCueFocusChanged;

	public event Action<Playlist<MediaCue>>? ActiveAudioPlaylistChanged;

	public event Action<Playlist<MediaCue>>? ActiveVisualPlaylistChanged;

	public event SendCommunicationDelegate? SendCommunication
	{
		add
		{
			IProCoreInstance proCore = ProCore;
			proCore.SendCommunication = (SendCommunicationDelegate)Delegate.Combine(proCore.SendCommunication, value);
		}
		remove
		{
			IProCoreInstance proCore = ProCore;
			proCore.SendCommunication = (SendCommunicationDelegate)Delegate.Remove(proCore.SendCommunication, value);
		}
	}

	public event TransportStatusChangedDelegate? TransportStatusChanged
	{
		add
		{
			IProCoreInstance proCore = ProCore;
			proCore.TransportStatusChanged = (TransportStatusChangedDelegate)Delegate.Combine(proCore.TransportStatusChanged, value);
		}
		remove
		{
			IProCoreInstance proCore = ProCore;
			proCore.TransportStatusChanged = (TransportStatusChangedDelegate)Delegate.Remove(proCore.TransportStatusChanged, value);
		}
	}

	public event Action<ProLayerIndex, ProResourceState>? LayerTriggered;

	public event Action<MediaTriggeredParameters>? MediaTriggered;

	public event Action<ProLayerIndex, bool, double>? WillGotoNextUpdated;

	public event Action<ProPresenterMacro>? MacroTriggerStarted;

	public event Action<ProPresenterMacro>? MacroTriggerCompleted;

	public CoreManager(IProCoreInstance proCore, ssAPIOutput ssAPIOutput, INetworkCommandTrigger networkCommandTrigger, INetworkTriggerDataTransferFactory networkTriggerDataTransferFactory, IApp app, ITimerFactory timerFactory, IUiDispatcher uiDispatcher, ICaptureService captureService, IDebouncerFactory debouncerFactory, ITimelineManager timelineManager, IGeneral general, ISongSelectConsumer songSelectConsumer, ITimecodeService timecodeService, IMessageService messageService, IThemeService themeService, IReportRepository reportRepository, IProPresenterResourceService resourceService, IOutputService outputService, IMultiTracksConsumer multiTracksConsumer, ITransferHandlerFactory transferHandlerFactory, IPCOConsumer pcoConsumer, IStoredPcoOptions storedPcoOptions, IProPresenterDOFactoryProvider factoryProvider, IRestClientFactory restClientFactory)
	{
		CoreManager coreManager = this;
		ProCore = proCore;
		_ssAPIOutput = ssAPIOutput;
		NetworkCommandTrigger = networkCommandTrigger;
		_networkTriggerDataTransferFactory = networkTriggerDataTransferFactory;
		SongSelectConsumer = songSelectConsumer;
		_timecodeService = timecodeService;
		_messageService = messageService;
		_themeService = themeService;
		_reportRepo = reportRepository;
		_resources = resourceService;
		_outputService = outputService;
		MultiTracksConsumer = multiTracksConsumer;
		PCOConsumer = pcoConsumer;
		_factoryProvider = factoryProvider;
		_app = app;
		_restClientFactory = restClientFactory;
		_dispatcher = uiDispatcher;
		_timelineManager = timelineManager;
		_general = general;
		_transferHandlerFactory = transferHandlerFactory;
		_workspaceDebouncer = debouncerFactory.Create(delegate((ProPresenterWorkspace data, bool triggerLiveLook) v)
		{
			coreManager.SendWorkspace(v.data, v.triggerLiveLook);
		});
		_monitorController = new MonitorController(_ssAPIOutput, _dispatcher, timerFactory, _restClientFactory);
		_backgroundTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => t.BackgroundTransition?.Serialize());
		_propsTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => t.PropsTransition?.Serialize());
		_messagesTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => t.MessagesTransition?.Serialize());
		_foregroundTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => t.ForegroundTransition?.Serialize());
		_bibleTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => t.BibleTransition?.Serialize());
		_audioTxSerializer = new ThrottledSerializer<ICoreManager, Transition>(this, (ICoreManager t) => coreManager.AudioTransition?.Serialize());
		_libraryPlaylistSerializer = new ThrottledSerializer<LibraryPlaylistCollection, PlaylistDocument>(DataVault.LibraryPlaylistCollection, (LibraryPlaylistCollection c) => c.Serialize());
		_audioPlaylistSerializer = new ThrottledSerializer<AudioPlaylistCollection, PlaylistDocument>(DataVault.AudioPlaylistCollection, (AudioPlaylistCollection c) => c.Serialize());
		_visualPlaylistSerializer = new ThrottledSerializer<VisualPlaylistCollection, PlaylistDocument>(DataVault.VisualPlaylistCollection, (VisualPlaylistCollection c) => c.Serialize());
		_liveLook = new ThrottledSerializer<AudienceLook, SerializedLook>(OutputConfiguration.LiveLook.Live, (AudienceLook src) => new SerializedLook(src, coreManager._themeService.Themes));
		_audienceLooks = new ThrottledSerializer<IAudienceLookCollection, Dictionary<Guid, SerializedLook>>(OutputConfiguration.AudienceLooks, (IAudienceLookCollection src) => src.Select((AudienceLook look) => new SerializedLook(look, coreManager._themeService.Themes)).ToDictionary((SerializedLook sl) => sl.LookID));
		_masks = new ThrottledSerializer<IMaskCollection, Dictionary<Guid, CustomSlide>>(OutputConfiguration.Masks, (IMaskCollection src) => (from s in src.Select((SlideCue mask) => mask.SlideAction?.Slide).OfType<CustomSlide>()
			select s.Clone(null, preserveID: true, userInitiated: false, includeBackgroundMedia: false, ignoreMediaNotifications: true)).ToDictionary((CustomSlide s) => s.ID));
		_stageLayoutTriggerer = new ThrottledStageLayoutTriggerer(timerFactory, TriggerStageLayouts);
		_propGroups = new ThrottledSerializer<IPropGroupCollection, PropDocument>(_resources.PropGroupCollection, (IPropGroupCollection p) => p.Serialize());
		_messages = new ThrottledSerializer<MessageCollection, MessageDocument>(DataVault.Messages, (MessageCollection src) => src.Serialize());
		_ccliSlide = new ThrottledSerializer<CCLIPresentation, CCLIDocument>(DataVault.CCLIPresentation, (CCLIPresentation p) => p.Serialize());
		_displaySettingsTimer = timerFactory.CreatePeriodicDispatched(DocumentChangeThrottle, FlushDisplaySettings);
		captureService.CaptureInformationUpdated += UpdateCaptureInformation;
		ProCore.SetForegroundMediaAudioBehavior(ProContentDestination.Global, Advanced.Settings.PresentationForegroundMediaAudioBehavior.ToBehavior());
		ProCore.SetForegroundMediaAudioBehavior(ProContentDestination.Announcements, Advanced.Settings.AnnouncementForegroundMediaAudioBehavior.ToBehavior());
		Advanced.Settings.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (!(propertyName == "PresentationForegroundMediaAudioBehavior"))
			{
				if (propertyName == "AnnouncementForegroundMediaAudioBehavior")
				{
					coreManager.ProCore.SetForegroundMediaAudioBehavior(ProContentDestination.Announcements, Advanced.Settings.AnnouncementForegroundMediaAudioBehavior.ToBehavior());
				}
			}
			else
			{
				coreManager.ProCore.SetForegroundMediaAudioBehavior(ProContentDestination.Global, Advanced.Settings.PresentationForegroundMediaAudioBehavior.ToBehavior());
			}
		};
		ProCore.AddDeviceChangedCallback(ProDeviceType.VideoOutput, (System.Action)delegate
		{
			coreManager.InvokeOnDispatcherAsync(delegate
			{
				coreManager._ssAPIOutput.RefreshVideoOutputs();
				coreManager.OutputConfigurationChanged();
			});
		});
		ProCore.AddDeviceChangedCallback(ProDeviceType.VideoInput, delegate(object device, ProDeviceAction action)
		{
			coreManager.InvokeOnDispatcherAsync(delegate
			{
				coreManager.VideoInputDeviceChanged(device as ProVideoInputDevice, action);
			});
		});
		ProCore.AddDeviceChangedCallback(ProDeviceType.AudioOutput, (System.Action)delegate
		{
			coreManager.InvokeOnDispatcherAsync(coreManager._ssAPIOutput.RefreshAudioOutputs);
		});
		ProCore.AddDeviceChangedCallback(ProDeviceType.AudioInput, delegate(object device, ProDeviceAction action)
		{
			coreManager.InvokeOnDispatcherAsync(delegate
			{
				coreManager.AudioInputDeviceChanged(device as ProAudioDevice, action);
			});
		});
		ProCore.TriggerTransferHandler = TriggerTransferHandler;
		ProCore.AsyncTriggerTransferHandler = AsyncTriggerTransferHandler;
		ProCore.AudioInputStatusChanged = AudioInputStatusHandler;
		ProCore.OperationHandler = OperationStateChanged;
		ProCore.ResourceHandler = OnResourceStateChanged;
		ProCore.CloseDisplayButtonClicked = CloseDisplayButtonClicked;
		ProCore.VideoInputStatusChanged = VideoInputStatusHandler;
		ProCore.UpdateAudioInput = UpdateAudioInputHandler;
		ProCore.ImageRequestTransferHandler = ImageRequestTransferHandler;
		IProCoreInstance proCore2 = ProCore;
		proCore2.TransportStatusChanged = (TransportStatusChangedDelegate)Delegate.Combine(proCore2.TransportStatusChanged, new TransportStatusChangedDelegate(ProCore_TransportStatusChanged));
		_backgroundTxSerializer.TargetUpdated += SendGlobalBackgroundTransition;
		_propsTxSerializer.TargetUpdated += SendGlobalPropsTransition;
		_messagesTxSerializer.TargetUpdated += SendGlobalMessagesTransition;
		_foregroundTxSerializer.TargetUpdated += SendGlobalForegroundTransition;
		_audioTxSerializer.TargetUpdated += SendGlobalAudioTransition;
		_libraryPlaylistSerializer.TargetUpdated += SendLibraryPlaylistDoc;
		_messages.TargetUpdated += SendMessageDocument;
		_audioPlaylistSerializer.TargetUpdated += SendAudioPlaylistDoc;
		_visualPlaylistSerializer.TargetUpdated += SendVisualPlaylistDoc;
		_timers = new ThrottledSerializer<TimerDocument, Dictionary<Guid, Pro.SerializationInterop.RVProtoData.Timer>>(DataVault.TimerDocument, (TimerDocument d) => d.Timers.Select((TimerData t) => t.Serialize()).ToDictionary((Pro.SerializationInterop.RVProtoData.Timer t) => t.Uuid.ToGuid()));
		_macroGroups = new ThrottledSerializer<MacroGroupCollection, MacrosDocument>(DataVault.MacroGroups, (MacroGroupCollection g) => g.Serialize());
		DataVault.LibraryPlaylistCollection.CollectionChanged += PlaylistLibraryChanged;
		PCOCueBase.ItemLinked += delegate(PCOCueBase c)
		{
			if (storedPcoOptions.AutoUpload)
			{
				PCOPlaylistHelper.UploadToPCO(coreManager.PCOConsumer, c);
			}
		};
		ProCore.SetOnScreenStatsVisible(Advanced.Settings.ShowScreenStats);
		FlushDisplaySettings();
		RefreshVideoInputDevices();
		RefreshAudioInputDevices();
		OnAudioInputsChanged();
		OnVideoInputsChanged();
		_stageLayoutTriggerer.RequestTrigger(StageDataUpdateSource.Initialization);
		SendTimersDocument();
		SendMessageDocument(DataVault.Messages.Serialize());
		SendCCLILayoutData();
		SendCCLIDocument(DataVault.CCLIPresentation.Serialize());
		SendPropGroupsDocument(DataVault.PropGroupCollection.Serialize());
		SendMacroGroupsDocument(DataVault.MacroGroups.Serialize());
		SendGlobalBackgroundTransition(BackgroundTransition?.Serialize());
		SendGlobalMessagesTransition(MessagesTransition?.Serialize());
		SendGlobalForegroundTransition(ForegroundTransition?.Serialize());
		SendGlobalPropsTransition(PropsTransition?.Serialize());
		SendGlobalAudioTransition(AudioTransition?.Serialize());
		SendVisualPlaylistDoc(DataVault.VisualPlaylistCollection.Serialize());
		SendAudioPlaylistDoc(DataVault.AudioPlaylistCollection.Serialize());
		SendLibraryPlaylistDoc(DataVault.LibraryPlaylistCollection.Serialize());
		DataVault.StagePresentation.DataModified += delegate
		{
			coreManager._stageLayoutTriggerer.RequestTrigger(StageDataUpdateSource.StagePresentationChanged);
		};
		OutputConfiguration.StageScreenLayoutMap.DataModified += delegate
		{
			coreManager._stageLayoutTriggerer.RequestTrigger(StageDataUpdateSource.StageScreenAssignmentChanged);
		};
		DataVault.Messages.DataModified += _messages.SourceUpdated;
		DataVault.CCLIPresentation.DataModified += _ccliSlide.SourceUpdated;
		OutputConfiguration.Masks.CollectionModified += _masks.SourceUpdated;
		OutputConfiguration.LiveLook.Live.DataModified += _liveLook.SourceUpdated;
		_themeService.Themes.CollectionChanged += _liveLook.SourceUpdated;
		_themeService.Themes.ThemeDataModified += delegate(Theme theme, TemplateSlide? templateSlide)
		{
			if (templateSlide != null && coreManager.OutputConfiguration.LiveLook.Live.ScreenLooks.Any((ScreenLook x) => x.TemplateId == templateSlide.ID))
			{
				coreManager._liveLook.SourceUpdated();
			}
		};
		OutputConfiguration.AudienceLooks.CollectionModified += _audienceLooks.SourceUpdated;
		_themeService.Themes.CollectionChanged += _audienceLooks.SourceUpdated;
		DataVault.TimerDocument.DataModified += _timers.SourceUpdated;
		DataVault.TimerDocument.DataModified += SendTimersDocument;
		DataVault.MacroGroups.DataModified += _macroGroups.SourceUpdated;
		DataVault.PropGroupCollection.DataModified += _propGroups.SourceUpdated;
		OutputConfiguration.StageArrangementScreens.CollectionModified += delegate
		{
			coreManager._stageLayoutTriggerer.RequestTrigger(StageDataUpdateSource.StageScreenArrangementsChanged);
		};
		_liveLook.TargetUpdated += delegate
		{
			coreManager._masks.SourceUpdated();
		};
		_macroGroups.TargetUpdated += SendMacroGroupsDocument;
		_propGroups.TargetUpdated += SendPropGroupsDocument;
		_ccliSlide.TargetUpdated += SendCCLIDocument;
		General.Settings.CCLILayoutData.DataModified += SendCCLILayoutData;
		OutputConfiguration.ConfigurationChanged += OutputConfigurationChanged;
		OutputConfiguration.WorkspaceChanged += delegate(WorkspaceChangedArgs e)
		{
			coreManager._workspaceDebouncer.Invoke((coreManager.OutputConfiguration.Serialize(), e.LiveLookChanged), e.Immediate);
		};
		outputService.OutputRepository.AvailableAudioInputs.CollectionModified += OnAudioInputsChanged;
		outputService.OutputRepository.AvailableLiveVideoInputs.CollectionModified += OnVideoInputsChanged;
		TransitionHandler transitionHandler = new TransitionHandler(DataVault.Transitions);
		transitionHandler.ActivateTransition(TransitionStoreType.Auto);
		AudioTransition = transitionHandler.ActiveParameters;
		if (AudioTransition != null)
		{
			AudioTransition.PropertyChanged += delegate
			{
				coreManager._audioTxSerializer.SourceUpdated();
			};
			AudioTransition.Duration = _app.AudioFadeInOutDuration;
		}
		TriggerTimers();
		DataVault.TimerDocument.TimersUpdated += TriggerTimers;
		LinkAction("AudioInputTransitionTime", OnAudioInputsChanged);
		OutputConfiguration.PropertyChanged += base.RaiseLinkedValues;
		ProCore.UpdateClearGroups(DataVault.ClearGroups.Serialize());
		DataVault.ClearGroups.DataModified += delegate
		{
			coreManager.ProCore.UpdateClearGroups(DataVault.ClearGroups.Serialize());
		};
		MultiTracksConsumer.SubscriptionAuthorizationUpdated += delegate
		{
			DataVault.LibraryCollection.ForEach(delegate(ILibrary library)
			{
				library.Select((DocumentCue cue) => cue.DocumentAction?.Presentation).OfType<MultiTracksPresentation>().ForEach(delegate(MultiTracksPresentation presentation)
				{
					presentation.CheckAuthorization();
				});
			});
		};
		LinkProperties("ContiguousViewEnabled", "IsContiguousActive");
		General.Settings.PropertyChanged += base.RaiseLinkedValues;
	}

	private void ProCore_TransportStatusChanged(ResourceAddress address, ProTransportStatus transportStatus)
	{
		double elapsed = Math.Max(0.0, transportStatus.TimeElapsed);
		double num = Math.Max(0.0, transportStatus.TimeRemaining);
		if (address.Layer == ProLayerIndex.PresentationBackground)
		{
			VideoCountdownTimeChanged.Publish(TimeSlice.FromSeconds(num));
		}
		_transportStatus.UpdateTime(address.Layer, elapsed, num);
	}

	private void TriggerTimers()
	{
		DataVault.TimerDocument.Timers.ForEach(delegate(TimerData t)
		{
			TriggerTimerAction(t, TimerActionType.Reset, TriggerSource.Internal, TimeSlice.Zero, ignoreAnalytics: true);
		});
	}

	public void Shutdown()
	{
		_displaySettingsTimer.Stop();
		_outputService.OutputRepository.AvailableAudioInputs.CollectionModified -= OnAudioInputsChanged;
		_outputService.OutputRepository.AvailableLiveVideoInputs.CollectionModified -= OnVideoInputsChanged;
		_backgroundTxSerializer.TargetUpdated -= SendGlobalBackgroundTransition;
		_propsTxSerializer.TargetUpdated -= SendGlobalPropsTransition;
		_messagesTxSerializer.TargetUpdated -= SendGlobalMessagesTransition;
		_foregroundTxSerializer.TargetUpdated -= SendGlobalForegroundTransition;
		_audioTxSerializer.TargetUpdated -= SendGlobalAudioTransition;
		ProCore.RemoveDeviceChangedCallback(ProDeviceType.VideoInput);
		ProCore.RemoveDeviceChangedCallback(ProDeviceType.VideoOutput);
		ProCore.RemoveDeviceChangedCallback(ProDeviceType.AudioInput);
		ProCore.RemoveDeviceChangedCallback(ProDeviceType.AudioOutput);
	}

	private void OnAudioInputsChanged()
	{
		if (!_audioInputUpdating)
		{
			AudioInputSettings audioInputSettings = new AudioInputSettings();
			audioInputSettings.Inputs.AddRange(_outputService.OutputRepository.AvailableAudioInputs.Select((ProPresenter.DO.Audio.AudioInput i) => i.Serialize()));
			audioInputSettings.TransitionTime = OutputConfiguration.AudioInputTransitionTime.TotalSeconds;
			ProCore.UpdateAudioInputs(audioInputSettings);
		}
	}

	private void OnVideoInputsChanged()
	{
		VideoInputSettings videoInputSettings = new VideoInputSettings();
		videoInputSettings.Inputs.AddRange(_outputService.OutputRepository.AvailableLiveVideoInputs.Select((LiveVideoInput i) => i.Serialize()));
		ProCore.UpdateVideoInputs(videoInputSettings);
	}

	private void OnActiveVisualPlaylistChanged(VisualPlaylist oldValue, VisualPlaylist newValue)
	{
		this.ActiveVisualPlaylistChanged?.Invoke(newValue);
		VisualPlaylistFocusedUpdated.Publish(newValue);
		SendMediaPlaylistFocused(newValue);
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= PlaylistCollectionChanged;
			oldValue.ForEach(StopWatching);
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += PlaylistCollectionChanged;
			newValue.ForEach(StartWatching);
		}
	}

	private static void StartWatching(MediaCue mediaCue)
	{
		mediaCue.MediaAction?.FileMedia?.StartObservingSourceFile();
	}

	private static void StopWatching(MediaCue mediaCue)
	{
		mediaCue.MediaAction?.FileMedia?.StopObservingSourceFile();
	}

	private static void PlaylistCollectionChanged(object? s, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaCue>().ForEach(StopWatching);
		e.NewItems?.OfType<MediaCue>().ForEach(StartWatching);
	}

	private static void OnActiveLibraryPlaylistChanged(Playlist<ProPresenterCue> oldValue, Playlist<ProPresenterCue> newValue)
	{
		if (oldValue != null)
		{
			oldValue.CollectionChanged -= PlaylistCollectionChanged;
			oldValue.OfType<MediaCue>().ForEach(StopWatching);
		}
		if (newValue != null)
		{
			newValue.CollectionChanged += PlaylistCollectionChanged;
			newValue.OfType<MediaCue>().ForEach(StartWatching);
		}
	}

	public void ShowAudienceScreens(bool persistState = true)
	{
		if (persistState)
		{
			AudienceEnable = true;
		}
		else
		{
			_audienceScreensVisible = true;
			OnPropertyChanged("AudienceEnable");
		}
		ProCore.ShowOutputs(ProScreenType.Audience);
	}

	public void HideAudienceScreens()
	{
		AudienceEnable = false;
		ProCore.HideOutputs(ProScreenType.Audience);
	}

	public void ShowStageScreens(bool persistState = true)
	{
		if (persistState)
		{
			StageEnable = true;
		}
		else
		{
			_stageScreensVisible = true;
			OnPropertyChanged("StageEnable");
		}
		ProCore.ShowOutputs(ProScreenType.Stage);
	}

	public void HideStageScreens()
	{
		StageEnable = false;
		ProCore.HideOutputs(ProScreenType.Stage);
	}

	public void SendStageMessage(string message, TriggerSource triggerSource)
	{
		_app.StageMessage = message;
		ProCore.SendStageMessage(message);
		ForwardTrigger(delegate
		{
			NetworkCommandTrigger.OnShowStageMessage(message);
		}, triggerSource);
		StageMessageState.Publish(isShowing: true, message);
	}

	public void HideStageMessage(TriggerSource triggerSource)
	{
		ProCore.HideStageMessage();
		ForwardTrigger(delegate
		{
			NetworkCommandTrigger.OnHideStageMessage();
		}, triggerSource);
		StageMessageState.Publish(isShowing: false, _app.StageMessage);
	}

	public void ShowMonitorIdentificationOverlay(PhysicalDevice device)
	{
		ProCore.ShowIdentificationOverlay(device.DeviceID);
	}

	public void HideAllMonitorIdentificationOverlays()
	{
		ProCore.HideIdentificationOverlays();
	}

	public void CreateRenderView(CreateRenderViewParameters createParams)
	{
		ProRenderViewType type = createParams.RenderViewType switch
		{
			RenderViewType.Preview => ProRenderViewType.LeadingSidebar, 
			RenderViewType.Inspector => ProRenderViewType.Inspector, 
			RenderViewType.InputPreferenceTab => ProRenderViewType.VideoInputPreferenceTab, 
			_ => throw new NotSupportedException("Unknown RenderViewType"), 
		};
		createParams.RenderViewHandle = ProCore.CreateRenderView(type, createParams.HostHandle);
	}

	public void DestroyRenderView(DestroyRenderViewParameters destroyParams)
	{
		ProCore.DestroyRenderView(destroyParams.RenderViewHandle);
	}

	public void SetPreviewScreenID(Guid id)
	{
		ProCore.SetSidebarPreviewScreenID(id);
	}

	public void TriggerNextSlide(TriggerSource triggerSource)
	{
		TriggerNextSlide(Destination.GetValueOrDefault(), triggerSource);
	}

	public void TriggerNextSlide(OutputDestination destination, TriggerSource triggerSource)
	{
		if (TriggerMediaPlaylistItem())
		{
			return;
		}
		if (_slideEnvironments[destination].PlaylistItem != ActivePlaylistItem)
		{
			UpdateSlideEnvironments(Destination.GetValueOrDefault(), null, null, forceUpdateNext: true);
		}
		ArrangedCue nextLogical = _slideEnvironments[destination].NextLogical;
		if (nextLogical == null)
		{
			UpdateSlideEnvironments(destination);
		}
		if (nextLogical != null)
		{
			if (!ParentCueIsActive(nextLogical))
			{
				ActivePlaylistItem = FindParentCue(nextLogical) ?? ActivePlaylistItem;
			}
			TriggerSlide(nextLogical, triggerSource);
			if (triggerSource == TriggerSource.Internal)
			{
				_messageService.PublishMessage(new CueTriggeredMessage(nextLogical));
			}
		}
		else if (NextPresentation != null)
		{
			UpdateActivePlaylistItem(NextPresentation, destination);
		}
	}

	public void TriggerPreviousSlide(TriggerSource triggerSource)
	{
		TriggerPreviousSlide(Destination.GetValueOrDefault(), triggerSource);
	}

	public void TriggerPreviousSlide(OutputDestination destination, TriggerSource triggerSource)
	{
		if (_slideEnvironments[destination].PlaylistItem != ActivePlaylistItem)
		{
			UpdateSlideEnvironments(Destination.GetValueOrDefault(), null, null, forceUpdateNext: true);
		}
		ArrangedCue previousLogical = _slideEnvironments[destination].PreviousLogical;
		if (previousLogical == null)
		{
			UpdateSlideEnvironments(destination);
		}
		if (previousLogical != null)
		{
			if (!ParentCueIsActive(previousLogical))
			{
				ActivePlaylistItem = FindParentCue(previousLogical) ?? ActivePlaylistItem;
			}
			TriggerSlide(previousLogical, triggerSource);
			if (triggerSource == TriggerSource.Internal)
			{
				_messageService.PublishMessage(new CueTriggeredMessage(previousLogical));
			}
		}
		else if (PreviousPresentation != null)
		{
			UpdateActivePlaylistItem(PreviousPresentation, destination);
		}
	}

	private void UpdateActivePlaylistItem(ProPresenterCue? cue, OutputDestination destination)
	{
		if (cue is IDocumentCue { DocumentAction: not null } documentCue)
		{
			UpdateActiveSlide(destination, documentCue, ActiveSlide, ActiveSlides.GetActiveHandle(destination));
		}
		ActivePlaylistItem = cue;
		ActiveLibraryMedia = null;
	}

	private bool ParentCueIsActive(ArrangedCue slide)
	{
		return TriggerHelper.GetActiveArrangement(ActivePlaylistItem)?.ArrangedCues.Contains(slide) ?? false;
	}

	private ProPresenterCue? FindParentCue(ArrangedCue nextLogicalSlide)
	{
		return ActiveLibraryPlaylist?.FirstOrDefaultOf((IDocumentCue d) => d.DocumentAction?.ActiveArrangement?.ArrangedCues.Contains(nextLogicalSlide) == true) as ProPresenterCue;
	}

	private bool TriggerMediaPlaylistItem()
	{
		if (ActivePlaylistItem is MediaCue mediaCue && ActivePlaylistItem != ActiveLibraryMedia && ActiveLibraryPlaylist != null)
		{
			_needToSwitchActivePlaylistItem = true;
			TriggerMedia(mediaCue, ActiveLibraryPlaylist, CueLocation.Presentation);
			return true;
		}
		return false;
	}

	public bool SetupSlideTrigger(ArrangedCue? slide, TriggerSource triggerSource, bool allowBuildSteps = true, ITriggerOperation? triggerOp = null, SlideTriggerOptions? options = null, Action<TriggerHandle, Guid, int>? handleBuildTrigger = null, Action<Pro.SerializationInterop.RVProtoData.Action, ITriggerOperation, TriggerOptions>? handleActionTrigger = null, Action<Pro.SerializationInterop.RVProtoData.Cue, ITriggerOperation, TriggerOptions, LibraryCollection>? handleCueTrigger = null)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		if (slide?.Source != null)
		{
			IPresentation? parentPresentation = slide.Source.ParentPresentation;
			if (parentPresentation == null || parentPresentation.IsAvailable)
			{
				slide.Source.UpdateValidity();
				bool num = options?.OverrideEnable ?? false;
				bool flag = options?.SuppressGotoNext ?? false;
				bool flag2 = options != null && options.BiblePresentation != null;
				ProPresenterCue activePlaylistItem = ActivePlaylistItem;
				Playlist<ProPresenterCue> playlist = options?.Playlist ?? ActiveLibraryPlaylist;
				bool suppressAutoStartVideo = Keyboard.Modifiers.AnyFlags<ModifierKeys>((ModifierKeys)1) && Advanced.Settings.SuppressVideoStart;
				OutputDestination outputDestination = ((!flag2) ? (options?.Destination ?? Destination ?? slide.Source.ParentPresentation?.Destination ?? OutputDestination.Presentation) : OutputDestination.Presentation);
				Pro.SerializationInterop.RVProtoData.Cue cue = slide.Source.Serialize();
				bool resetChordChart = ActiveSlide != null && ActiveSlide.Source.ParentPresentation != slide.Source.ParentPresentation;
				if (cue.CompletionTargetType == Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None && activePlaylistItem is IDocumentCue documentCue && documentCue.DocumentAction?.Presentation != null && documentCue.DocumentAction.Presentation.SlideShowEnabled && !flag2)
				{
					cue.CompletionActionType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterTime;
					cue.CompletionTargetType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next;
					cue.CompletionTime = documentCue.DocumentAction.Presentation.SlideShowDuration;
				}
				if (num)
				{
					cue.IsEnabled = true;
				}
				ArrangedCue arrangedCue = ActiveSlides[outputDestination];
				if (arrangedCue == slide && arrangedCue.BuildCount > 0 && SlideBuildPositions[outputDestination] < arrangedCue.BuildCount && SlideBuildPositions.GetBuildCount(outputDestination) == slide.BuildCount)
				{
					if (!allowBuildSteps)
					{
						return false;
					}
					int num2 = SlideBuildPositions[outputDestination] + 1;
					handleBuildTrigger?.Invoke(ActiveSlides.GetActiveHandle(outputDestination), slide.Source.SlideAction?.Slide.ID ?? Guid.Empty, num2);
					if (num2 >= slide.BuildCount)
					{
						UpdateSlideEnvironments(outputDestination, slide, activePlaylistItem, forceUpdateNext: true);
					}
				}
				else
				{
					ITriggerOperation triggerOperation = triggerOp ?? CreateTriggerOperation();
					CustomSlide customSlide = (slide.Source.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
					CustomSlide slide2 = customSlide?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
					triggerOperation.SlidePool.AddSlide(slide2);
					UpdateSlideEnvironments(outputDestination, slide, activePlaylistItem);
					SlideCueInfo slideCueInfo;
					if (outputDestination == OutputDestination.Presentation)
					{
						ProPresenterCue cue2 = (flag2 ? new DocumentCue(options.BiblePresentation) : activePlaylistItem);
						SlideCue slideCue = TriggerHelper.FindNextLogicalSlide(playlist, cue2, slide, forceFindNextSlide: true, allowLooping: true)?.Source;
						TimelineTriggerOptions timelineTriggerOptions = options?.Timeline;
						if (timelineTriggerOptions != null)
						{
							slideCue = timelineTriggerOptions.NextSlide;
						}
						CustomSlide customSlide2 = (slideCue?.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
						CustomSlide slide3 = customSlide2?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
						triggerOperation.SlidePool.AddSlide(slide3);
						slideCueInfo = triggerOperation.AttachPresentationSlideCueInfo(slide, slideCue, customSlide?.Serialize().BaseSlide, customSlide, customSlide2, playlist, activePlaylistItem as IDocumentCue, flag2);
					}
					else
					{
						SlideCue slideCue2 = TriggerHelper.FindNextLogicalSlide(playlist, activePlaylistItem, slide, forceFindNextSlide: true, allowLooping: true)?.Source;
						CustomSlide customSlide3 = (slideCue2?.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
						CustomSlide slide4 = customSlide3?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
						triggerOperation.SlidePool.AddSlide(slide4);
						slideCueInfo = triggerOperation.AttachAnnouncementSlideCueInfo(slide, slideCue2, customSlide?.Serialize().BaseSlide, customSlide, customSlide3, playlist, activePlaylistItem as IDocumentCue);
					}
					TriggerOptions triggerOptions = new TriggerOptions
					{
						ContentDestination = slideCueInfo.ContentDestination,
						SuppressAutoStartVideo = suppressAutoStartVideo,
						SuppressMediaBackground = Keyboard.Modifiers.AnyFlags<ModifierKeys>((ModifierKeys)1),
						ResetChordChart = resetChordChart,
						FromPlaylistLibrary = (playlist != null),
						TriggerSource = new Pro.SerializationInterop.RVProtoData.TriggerSource()
					};
					int valueOrDefault = ((activePlaylistItem as IDocumentCue)?.DocumentAction?.ActiveArrangement?.ArrangedCues?.IndexOf(slide)).GetValueOrDefault();
					if (playlist != null && activePlaylistItem != null)
					{
						triggerOptions.TriggerSource = GetTriggerSource(playlist, activePlaylistItem);
						if (DataVault.LibraryPlaylistCollection.TryFindPlaylistItemPath(activePlaylistItem, out int[] finalPath))
						{
							triggerOptions.NetworkIdentifier = finalPath?.ToNetworkIdentifier().AddIndex(valueOrDefault);
						}
					}
					else
					{
						triggerOptions.TriggerSource = GetTriggerSource(slide.Source);
						if (DataVault.LibraryCollection.FindDocument(slide.Source.ParentPresentation?.SourceFile, out ILibrary library) != null && library != null)
						{
							int num3 = DataVault.LibraryCollection.IndexOf(library);
							int num4 = library.SortedItems.IndexOf(activePlaylistItem);
							int[] indexPath = new int[3] { num3, num4, valueOrDefault };
							triggerOptions.NetworkIdentifier = indexPath.ToNetworkIdentifier();
						}
					}
					if (flag)
					{
						cue.CompletionTargetType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None;
					}
					handleCueTrigger?.Invoke(cue, triggerOperation, triggerOptions, DataVault.LibraryCollection);
				}
				return true;
			}
		}
		return false;
	}

	public void TriggerSlide(ArrangedCue slide, TriggerSource triggerSource, SlideTriggerOptions? options = null)
	{
		SetupSlideTrigger(slide, triggerSource, allowBuildSteps: true, null, options, delegate(TriggerHandle handle, Guid slideID, int buildIndex)
		{
			ProCore.TriggerBuildIndex(handle, slide.Source.SlideAction?.Slide.ID ?? Guid.Empty, buildIndex);
		}, null, delegate(Pro.SerializationInterop.RVProtoData.Cue protoCue, ITriggerOperation op, TriggerOptions triggerOptions, LibraryCollection libraryCollection)
		{
			IPresentation presentation = slide.Source.ParentPresentation;
			DocumentCue document = libraryCollection.SelectMany((ILibrary l) => l).FirstOrDefault((DocumentCue d) => d.DocumentAction.Presentation == presentation);
			ILibrary library = ((document == null) ? null : libraryCollection.FirstOrDefault((ILibrary l) => l.Contains(document)));
			Presentation presentation2 = ((presentation == null) ? null : library?.GetPresentationLoadData(presentation)?.ProtoData);
			if (options?.BiblePresentation != null)
			{
				presentation = options.BiblePresentation;
				presentation2 = options.BiblePresentation.Serialize();
			}
			TriggerCue(protoCue, op, triggerOptions, new TriggerCue.Types.PresentationCue
			{
				Presentation = presentation2,
				ArrangementId = presentation?.ActiveArrangement?.ID.ToUUID(),
				CueIndex = slide.Index - 1
			}, GetPlaylistForTrigger(options));
		});
	}

	private Playlist? GetPlaylistForTrigger(SlideTriggerOptions? options = null)
	{
		Playlist<ProPresenterCue> playlist = null;
		if (options?.Playlist != null)
		{
			playlist = options.Playlist;
		}
		else if (ActivePlaylistItem is IDocumentCue documentCue)
		{
			playlist = documentCue.PlaylistParent;
		}
		return playlist?.ProtoSerialize();
	}

	public void TriggerLogo()
	{
		if (Logo != null)
		{
			Logo.SelectedTransition = BackgroundTransition;
			TriggerOperation triggerOperation = CreateTriggerOperation();
			ProCore.TriggerLogo(triggerOperation.Handle, Logo.Serialize());
		}
	}

	public void TriggerNextBackground(VisualPlaylist playlist, TriggerSource triggerSource)
	{
		TriggerProximalBackground(playlist, isNext: true, triggerSource);
	}

	public void TriggerPreviousBackground(VisualPlaylist playlist, TriggerSource triggerSource)
	{
		TriggerProximalBackground(playlist, isNext: false, triggerSource);
	}

	private void TriggerProximalBackground(VisualPlaylist playlist, bool isNext, TriggerSource triggerSource)
	{
		if (MostRecentActiveMedia == null && _previouslyActiveBackground == null)
		{
			return;
		}
		int index = playlist.IndexOf(MostRecentActiveMedia ?? _previouslyActiveBackground) + (isNext ? 1 : (-1));
		MediaCue mediaCue = playlist.ElementAtOrDefault(index) ?? playlist.FirstOrDefault();
		if (mediaCue != null)
		{
			TriggerBackground(mediaCue, playlist, triggerSource);
			if (triggerSource == TriggerSource.Internal)
			{
				_messageService?.PublishMessage(new CueTriggeredMessage(mediaCue));
			}
		}
	}

	public void TriggerBackground<T>(MediaCue media, Playlist<T> playlist, TriggerSource triggerSource, CueLocation cueLocation = CueLocation.MediaBin) where T : ProPresenterCue
	{
		TriggerMedia(media, playlist, cueLocation);
	}

	public void TriggerNextAudio(AudioPlaylist playlist, TriggerSource triggerSource)
	{
		TriggerProximalAudio(playlist, isNext: true, triggerSource);
	}

	public void TriggerPreviousAudio(AudioPlaylist playlist, TriggerSource triggerSource)
	{
		TriggerProximalAudio(playlist, isNext: false, triggerSource);
	}

	private void TriggerProximalAudio(AudioPlaylist playlist, bool isNext, TriggerSource triggerSource)
	{
		if (MostRecentActiveMedia == null && _previouslyActiveBackground == null)
		{
			return;
		}
		int index = playlist.IndexOf(MostRecentActiveAudio ?? _previouslyActiveAudio) + (isNext ? 1 : (-1));
		MediaCue mediaCue = playlist.ElementAtOrDefault(index) ?? playlist.FirstOrDefault();
		if (mediaCue != null)
		{
			TriggerAudio(mediaCue, playlist, triggerSource);
			if (triggerSource == TriggerSource.Internal)
			{
				_messageService?.PublishMessage(new CueTriggeredMessage(mediaCue));
			}
		}
	}

	public void TriggerAudio<T>(MediaCue audio, Playlist<T> playlist, TriggerSource triggerSource, CueLocation cueLocation = CueLocation.AudioBin) where T : ProPresenterCue
	{
		TriggerMedia(audio, playlist, cueLocation);
	}

	private void TriggerMedia<T>(MediaCue mediaCue, Playlist<T> playlist, CueLocation location) where T : ProPresenterCue
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		TriggerOptions triggerOptions = new TriggerOptions
		{
			SuppressAutoStartVideo = (Keyboard.Modifiers.AnyFlags<ModifierKeys>((ModifierKeys)1) && Advanced.Settings.SuppressVideoStart),
			ForceRetrigger = (location != 0 && location != CueLocation.PlaylistLibrary),
			FromPlaylistLibrary = (playlist is GeneralPlaylist),
			TriggerSource = new Pro.SerializationInterop.RVProtoData.TriggerSource()
		};
		if (location == CueLocation.PlaylistLibrary)
		{
			triggerOptions.TriggerSource = GetTriggerSource(playlist, mediaCue);
		}
		PlaylistCollectionBase<T> playlistCollectionBase = location switch
		{
			CueLocation.MediaBin => DataVault.VisualPlaylistCollection as PlaylistCollectionBase<T>, 
			CueLocation.AudioBin => DataVault.AudioPlaylistCollection as PlaylistCollectionBase<T>, 
			CueLocation.PlaylistLibrary => DataVault.LibraryPlaylistCollection as PlaylistCollectionBase<T>, 
			_ => null, 
		};
		if (playlistCollectionBase != null && mediaCue is T item && playlistCollectionBase.TryFindPlaylistItemPath(item, out int[] finalPath))
		{
			triggerOptions.NetworkIdentifier = finalPath?.ToNetworkIdentifier();
		}
		else
		{
			MediaAction? mediaAction = mediaCue.MediaAction;
			if (mediaAction != null && mediaAction.Media?.MediaType == MediaType.LiveVideo)
			{
				triggerOptions.NetworkIdentifier = DataVault.VisualPlaylistCollection.LiveVideoPlaylist.IndexOf(mediaCue).ToNetworkIdentifier();
			}
		}
		if (playlist is Playlist<ProPresenterCue>)
		{
			location = CueLocation.Presentation;
		}
		TriggerOperation triggerOperation = CreateTriggerOperation();
		triggerOperation.AttachMediaCueInfo(location, mediaCue, playlist);
		TriggerCue(mediaCue.Serialize(), triggerOperation, triggerOptions, null, playlist?.ProtoSerialize());
	}

	public void TriggerProp(IPropCue prop, TriggerSource triggerSource)
	{
		if (prop != null && prop.SlideAction != null)
		{
			TriggerOperation triggerOperation = CreateTriggerOperation();
			Pro.SerializationInterop.RVProtoData.Action action = prop.SlideAction.Serialize();
			Slide slide = action.GetSlide();
			triggerOperation.SlidePool.AddSlide((prop.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: true, ignoreMediaNotifications: true));
			triggerOperation.AttachPropCueInfo(prop, slide);
			TriggerOptions triggerOptions = new TriggerOptions
			{
				NetworkIdentifier = _resources.PropSource.FlatCollection.IndexOf(prop).ToNetworkIdentifier()
			};
			TriggerAction(action, triggerOperation, triggerOptions);
		}
	}

	public void ToggleProp(IPropCue prop, TriggerSource triggerSource)
	{
		if (_activeProps.Contains(prop))
		{
			ClearProp(prop, triggerSource);
		}
		else
		{
			TriggerProp(prop, triggerSource);
		}
	}

	public void TriggerMessage(ProPresenter.DO.Messages.Message message, TriggerSource triggerSource)
	{
		if (message != null)
		{
			TriggerOptions triggerOptions = new TriggerOptions
			{
				NetworkIdentifier = DataVault.Messages.IndexOf(message).ToNetworkIdentifier()
			};
			TriggerMessage(message.ID, message.Name, message.Tokens.SerializeTokenValues(), triggerOptions);
		}
	}

	public void TriggerMessage(Guid id, string name, IEnumerable<Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue> tokenValues, TriggerOptions? triggerOptions = null)
	{
		TriggerOperation triggerOperation = CreateTriggerOperation();
		Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
		{
			Uuid = Guid.NewGuid().ToUUID(),
			Name = "Trigger Message",
			IsEnabled = true,
			Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Message,
			Message = new Pro.SerializationInterop.RVProtoData.Action.Types.MessageType
			{
				MessageIdentificaton = new CollectionElementType
				{
					ParameterUuid = id.ToUUID(),
					ParameterName = name
				}
			}
		};
		action.Message.Content.AddRange(tokenValues);
		TriggerAction(action, triggerOperation, triggerOptions);
	}

	public void TriggerAudienceLook(AudienceLook audienceLook, TriggerSource triggerSource)
	{
		Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
		{
			Uuid = Guid.NewGuid().ToUUID(),
			Name = "Trigger Audience Look",
			IsEnabled = true,
			Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.AudienceLook,
			AudienceLook = new Pro.SerializationInterop.RVProtoData.Action.Types.AudienceLookType
			{
				Identification = new CollectionElementType
				{
					ParameterUuid = audienceLook.ID.ToUUID(),
					ParameterName = audienceLook.Name
				}
			}
		};
		TriggerOptions triggerOptions = new TriggerOptions
		{
			NetworkIdentifier = OutputConfiguration.AudienceLooks.IndexOf(audienceLook).ToNetworkIdentifier()
		};
		TriggerAction(action, null, triggerOptions);
	}

	public void TriggerTimerAction(TimerData timer, TimerActionType timerActionType, TriggerSource triggerSource, TimeSlice incrementAmount, bool ignoreAnalytics = false)
	{
		TriggerTimerAction(timer.ID, timer.Name, timer.GetTimerActionType(timerActionType), timer.Serialize().Configuration, incrementAmount, DataVault.TimerDocument.Timers.IndexOf(timer).ToNetworkIdentifier(), ignoreAnalytics);
	}

	public void TriggerTimerAction(Guid id, string name, TimerActionType timerActionType, Pro.SerializationInterop.RVProtoData.Timer.Types.Configuration protoConfiguration, TimeSlice incrementAmount, NetworkIdentifier? networkIdentifier = null, bool ignoreAnalytics = false)
	{
		Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
		{
			Uuid = Guid.NewGuid().ToUUID(),
			Name = "Trigger Timer",
			IsEnabled = true,
			Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Timer,
			Timer = new Pro.SerializationInterop.RVProtoData.Action.Types.TimerType
			{
				ActionType = timerActionType.ToProtoTimerActionType(),
				TimerIdentification = new CollectionElementType
				{
					ParameterUuid = id.ToUUID(),
					ParameterName = name
				},
				TimerConfiguration = protoConfiguration,
				IncrementAmount = incrementAmount.TotalSeconds
			}
		};
		TriggerAction(action, null, new TriggerOptions
		{
			IgnoreAnalytics = ignoreAnalytics,
			NetworkIdentifier = ((!ignoreAnalytics) ? networkIdentifier : null)
		});
	}

	public void TriggerHeaderAction(HeaderAction headerAction)
	{
		Pro.SerializationInterop.RVProtoData.Action action = headerAction.Timer?.Serialize();
		if (action != null)
		{
			action.Name = "Trigger Header Item Timer";
			TriggerAction(action);
		}
	}

	public void TriggerCapture(CaptureAction captureAction)
	{
		TriggerOperation triggerOperation = CreateTriggerOperation();
		Pro.SerializationInterop.RVProtoData.Action action = captureAction.Serialize();
		TriggerAction(action, triggerOperation);
	}

	private TriggerOperation CreateTriggerOperation()
	{
		return InternalCreateTriggerOperation(ProCore.AcquireTriggerHandle());
	}

	public ITriggerOperation CreateTriggerOperation(TriggerHandle handle)
	{
		return InternalCreateTriggerOperation(handle);
	}

	private TriggerOperation InternalCreateTriggerOperation(TriggerHandle handle)
	{
		TriggerEnvironment? triggerEnvironment = _dispatcher.Invoke(() => new TriggerEnvironment(_stageDoc, _resources.Messages.ToElementDictionary((ProPresenter.DO.Messages.Message m) => new SerializedMessage(m)), _resources.CCLIPresentation.FirstOrDefault()?.CloneWithID(), _liveLook.Target, _audienceLooks.Target ?? new Dictionary<Guid, SerializedLook>(), _timers.Target ?? new Dictionary<Guid, Pro.SerializationInterop.RVProtoData.Timer>()));
		triggerEnvironment.ThrowWhenNull("env");
		return new TriggerOperation(triggerEnvironment, handle, _general, _factoryProvider, _ssAPIOutput.AvailableTransitions);
	}

	private void TriggerAction(Pro.SerializationInterop.RVProtoData.Action action, ITriggerOperation? triggerOperation = null, TriggerOptions? triggerOptions = null)
	{
		ITriggerOperation triggerOperation2 = triggerOperation ?? CreateTriggerOperation();
		ProCore.TriggerAction(triggerOperation2.Handle, action, triggerOptions, triggerOperation2);
	}

	private void TriggerCue(Pro.SerializationInterop.RVProtoData.Cue protoCue, ITriggerOperation op, TriggerOptions? triggerOptions = null, TriggerCue.Types.PresentationCue? presentation = null, Playlist? playlist = null)
	{
		op.Clock = new Pro.Common.Time.Clock(autoStart: true);
		SendData sendData = new SendData
		{
			TriggerCue = new TriggerCue
			{
				TriggerHandle = op.Handle.RawValue,
				TriggerOptions = triggerOptions,
				Cue = protoCue,
				Presentation = presentation,
				Playlist = playlist,
				ClientData = (ulong)((IntPtr)GCHandle.ToIntPtr(GCHandle.Alloc(op))).ToInt64()
			}
		};
		SendData(sendData);
	}

	public void TriggerMacro(ProPresenterMacro macro, TriggerSource triggerSource)
	{
		Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
		{
			Uuid = Guid.NewGuid().ToUUID(),
			Name = "Trigger Macro",
			IsEnabled = true,
			Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.Macro,
			Macro = new Pro.SerializationInterop.RVProtoData.Action.Types.MacroType
			{
				Identification = new CollectionElementType
				{
					ParameterUuid = macro.ID.ToUUID(),
					ParameterName = macro.Name,
					ParentCollection = new CollectionElementType
					{
						ParameterUuid = macro.ParentCollectionID.ToUUID(),
						ParameterName = macro.ParentCollectionName
					}
				}
			}
		};
		TriggerOperation triggerOperation = CreateTriggerOperation();
		_triggeredMacros[triggerOperation] = macro;
		TriggerOptions triggerOptions = new TriggerOptions
		{
			NetworkIdentifier = DataVault.MacroSource.FlatCollection.IndexOf(macro).ToNetworkIdentifier()
		};
		TriggerAction(action, triggerOperation, triggerOptions);
	}

	public void TriggerClearGroup(ClearGroup clearGroup, TriggerSource triggerSource)
	{
		if (clearGroup != null)
		{
			Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
			{
				Uuid = Guid.NewGuid().ToUUID(),
				Name = "Trigger Clear Group",
				IsEnabled = true,
				Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.ClearGroup,
				ClearGroup = new Pro.SerializationInterop.RVProtoData.Action.Types.ClearGroupType
				{
					Identification = new CollectionElementType
					{
						ParameterUuid = clearGroup.ID.ToUUID(),
						ParameterName = clearGroup.Name
					}
				}
			};
			TriggerOperation triggerOperation = CreateTriggerOperation();
			TriggerOptions triggerOptions = new TriggerOptions
			{
				NetworkIdentifier = DataVault.ClearGroups.IndexOf(clearGroup).ToNetworkIdentifier()
			};
			TriggerAction(action, triggerOperation, triggerOptions);
		}
	}

	public void TriggerStageAction(IEnumerable<Stage.Types.ScreenAssignment> assignments, bool ignoreAnalytics = false)
	{
		if (assignments.Any())
		{
			Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
			{
				Uuid = Guid.NewGuid().ToUUID(),
				Name = "Change Stage layouts from UI",
				IsEnabled = true,
				Type = Pro.SerializationInterop.RVProtoData.Action.Types.ActionType.StageLayout,
				Stage = new Pro.SerializationInterop.RVProtoData.Action.Types.StageLayoutType()
			};
			action.Stage.StageScreenAssignments.AddRange(assignments);
			TriggerOperation triggerOperation = CreateTriggerOperation();
			triggerOperation.StageInfo = new StageInfo(assignments);
			TriggerAction(action, triggerOperation, new TriggerOptions
			{
				ForceRetrigger = true,
				IgnoreAnalytics = ignoreAnalytics
			});
		}
	}

	private static void ForwardTrigger(System.Action action, TriggerSource triggerSource)
	{
		if (triggerSource != TriggerSource.NetworkAPI)
		{
			action();
		}
	}

	public void ToggleInputStatus(bool enable)
	{
		SendData(new SendData
		{
			InputStatusCallback = new InputStatusCallback
			{
				Enable = enable
			}
		});
	}

	public void ClearAll()
	{
		ProCore.TriggerClearAllAction();
		this.AllCleared?.Invoke();
	}

	public void ClearSlide(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.PresentationForeground);
	}

	public void ClearBackground(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.PresentationBackground);
	}

	public void ClearVideoInput(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.UserLayerBegin);
	}

	public void ClearProps(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.Props);
	}

	public void ClearAnnouncement(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProContentDestination.Announcements, ProLayerIndex.InternalLayerEnd);
	}

	public void ClearMessages(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.Messages);
	}

	public void ClearProp(IPropCue prop, TriggerSource triggerSource)
	{
		ProCore.TriggerClearSlotAction(ProLayerIndex.Props, prop.SlideAction?.ID ?? Guid.Empty);
	}

	public void ClearMessage(ProPresenter.DO.Messages.Message message, TriggerSource triggerSource)
	{
		ProCore.TriggerClearSlotAction(ProLayerIndex.Messages, message.ID);
	}

	public void ClearAudio(TriggerSource triggerSource)
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.Music);
	}

	public void ClearTelestrator()
	{
	}

	public void ClearTestPattern()
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.TestPattern);
		this.TestPatternCleared?.Invoke();
	}

	public void ClearVideoInputPreview()
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.VideoInputPreview);
	}

	public void CancelPresentationGotoNext()
	{
		ProCore.CancelAutoAdvance(ProLayerIndex.PresentationForeground);
	}

	public void CancelAnnouncementGotoNext()
	{
		ProCore.CancelAutoAdvance(ProLayerIndex.AnnouncementsForeground);
	}

	public void CancelAudioGotoNext()
	{
		ProCore.CancelAutoAdvance(ProLayerIndex.Music);
	}

	public void TriggerSlideOnStageDisplayOnly(bool stageOnly)
	{
		ProCore.TriggerSlideOnStageOnlyAction(stageOnly);
	}

	public void ClearTimer(TimerData timerData)
	{
		ProCore.TriggerClearSlotAction(ProLayerIndex.Utility, timerData.ID);
	}

	private void UpdateActiveSlide(OutputDestination destination, IDocumentCue? documentCue, ArrangedCue? slide, TriggerHandle handle)
	{
		ActiveSlides.SetActiveCue(destination, (handle == TriggerHandle.Invalid) ? null : slide, (handle == TriggerHandle.Invalid) ? null : documentCue, handle);
		PreviouslyActiveSlides.SetActiveCue(destination, (handle == TriggerHandle.Invalid) ? slide : null, (handle == TriggerHandle.Invalid) ? documentCue : null, handle);
		SlideBuildPositions.ResetBuildPosition(destination, (!(handle == TriggerHandle.Invalid)) ? (slide?.BuildCount ?? 0) : 0);
		OnPropertyChanged("ActiveSlide");
	}

	public void ResetActiveSlide(IDocumentCue documentCue, ArrangedCue slide)
	{
		if (slide != null && Destination.HasValue)
		{
			TriggerHandle activeHandle = ActiveSlides.GetActiveHandle(Destination.Value);
			UpdateActiveSlide(Destination.Value, documentCue, slide, activeHandle);
			UpdateSlideEnvironments(Destination.Value, ActiveSlide, null, forceUpdateNext: true);
			this.SlideTriggered?.Invoke(slide, 0, Destination.Value);
		}
	}

	private void UpdateSlideEnvironments(OutputDestination destination, ArrangedCue? activeSlide = null, ProPresenterCue? playlistItem = null, bool forceUpdateNext = false)
	{
		if (activeSlide == null && !forceUpdateNext)
		{
			activeSlide = ActiveSlides[destination] ?? PreviouslyActiveSlides[destination];
		}
		_slideEnvironments[destination].Update(ActiveLibraryPlaylist, playlistItem ?? ActivePlaylistItem, activeSlide, forceUpdateNext);
	}

	private void UpdateNextPresentations()
	{
		NextPresentation = TriggerHelper.FindNextPlaylistItem(ActiveLibraryPlaylist, ActivePlaylistItem);
		PreviousPresentation = TriggerHelper.FindPreviousPlaylistItem(ActiveLibraryPlaylist, ActivePlaylistItem);
	}

	private void HookupArrangementChanged(IDocumentCue? newDocumentCue)
	{
		_activeCuesChangedSubscription?.Dispose();
		_activeCuesChangedSubscription = new ActiveArrangementChangeSubscription(newDocumentCue, ArrangedCues_CollectionChanged);
	}

	private void ArrangedCues_CollectionChanged()
	{
		OutputDestination[] values = Enum.GetValues<OutputDestination>();
		foreach (OutputDestination destination in values)
		{
			if (ActiveSlides.UpdateLink(destination))
			{
				UpdateSlideEnvironments(Destination.GetValueOrDefault(), ActiveSlide, null, forceUpdateNext: true);
				OnPropertyChanged("ActiveSlide");
			}
		}
	}

	private TriggerCue? ResolveNextPresentationCue(TriggerOperation currOp, TriggerOperation nextOp)
	{
		if (!(currOp.CueInfo is SlideCueInfo slideCueInfo))
		{
			return null;
		}
		Playlist<ProPresenterCue> originalPlaylist = slideCueInfo.OriginalPlaylist;
		IDocumentCue documentCue = slideCueInfo.OriginalDocumentCue;
		if (documentCue == null || documentCue.DocumentAction == null)
		{
			return null;
		}
		ArrangedCue arrangedCue = TriggerHelper.FindNextLogicalSlide(originalPlaylist, (ProPresenterCue)documentCue, slideCueInfo.OriginalCurrentSlide);
		if (slideCueInfo.OriginalCurrentSlide?.Source.GotoNext?.LoopToBeginning == true)
		{
			goto IL_00a2;
		}
		if (arrangedCue == null)
		{
			IPresentation? presentation = documentCue.DocumentAction.Presentation;
			if (presentation != null && presentation.SlideShowEnabled)
			{
				goto IL_00a2;
			}
		}
		goto IL_00d9;
		IL_00a2:
		arrangedCue = TriggerHelper.GetActiveArrangement(documentCue)?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source.IsEnabled);
		goto IL_00d9;
		IL_00d9:
		ProPresenterCue proPresenterCue = ((arrangedCue == null) ? null : ((ProPresenterCue)documentCue));
		if (arrangedCue == null && originalPlaylist != null && originalPlaylist.Contains((ProPresenterCue)documentCue))
		{
			proPresenterCue = TriggerHelper.FindNextPlaylistItem(originalPlaylist, (ProPresenterCue)documentCue);
			if (proPresenterCue is IDocumentCue documentCue2)
			{
				_needToSwitchActivePlaylistItem = true;
				documentCue = documentCue2;
				arrangedCue = TriggerHelper.GetActiveArrangement(documentCue)?.ArrangedCues.FirstOrDefault((ArrangedCue a) => a.Source.IsEnabled);
			}
			else
			{
				if (proPresenterCue is MediaCue mediaCue)
				{
					_needToSwitchActivePlaylistItem = true;
					nextOp.AttachMediaCueInfo(CueLocation.Presentation, mediaCue, originalPlaylist);
					return new TriggerCue
					{
						TriggerHandle = currOp.Handle.RawValue,
						TriggerOptions = new TriggerOptions
						{
							ContentDestination = Pro.SerializationInterop.RVProtoData.Action.Types.ContentDestination.Global
						},
						Cue = proPresenterCue.Serialize(),
						Presentation = null,
						Playlist = documentCue.PlaylistParent?.ProtoSerialize(),
						ClientData = 0uL
					};
				}
				_ = proPresenterCue is HeaderCue;
			}
		}
		if (arrangedCue != null)
		{
			SlideCue slideCue = TriggerHelper.FindNextLogicalSlide(originalPlaylist, (ProPresenterCue)documentCue, arrangedCue, forceFindNextSlide: true, allowLooping: true)?.Source;
			Pro.SerializationInterop.RVProtoData.Cue cue = arrangedCue.Source.Serialize();
			CustomSlide customSlide = (arrangedCue.Source.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			if (customSlide == null)
			{
				return null;
			}
			CustomSlide slide = customSlide.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			nextOp.SlidePool.AddSlide(slide);
			if (cue.CompletionTargetType == Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.None && documentCue.DocumentAction?.Presentation?.SlideShowEnabled == true)
			{
				cue.CompletionActionType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionActionType.AfterTime;
				cue.CompletionTargetType = Pro.SerializationInterop.RVProtoData.Cue.Types.CompletionTargetType.Next;
				cue.CompletionTime = documentCue.DocumentAction.Presentation.SlideShowDuration;
			}
			CustomSlide customSlide2 = (slideCue?.SlideAction?.Slide as CustomSlide)?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			CustomSlide slide2 = customSlide2?.Clone(null, preserveID: true, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
			nextOp.SlidePool.AddSlide(slide2);
			switch (documentCue.DocumentAction?.Destination)
			{
			case OutputDestination.Announcement:
				nextOp.AttachAnnouncementSlideCueInfo(arrangedCue, slideCue, customSlide.Serialize()?.BaseSlide, customSlide, customSlide2, originalPlaylist, documentCue);
				break;
			case OutputDestination.Presentation:
				nextOp.AttachPresentationSlideCueInfo(arrangedCue, slideCue, customSlide.Serialize()?.BaseSlide, customSlide, customSlide2, originalPlaylist, documentCue);
				break;
			default:
				return null;
			}
			return new TriggerCue
			{
				TriggerHandle = currOp.Handle.RawValue,
				TriggerOptions = new TriggerOptions
				{
					ContentDestination = documentCue.DocumentAction.Destination.ToProtoDestination(),
					TriggerSource = GetTriggerSource(originalPlaylist, proPresenterCue)
				},
				Cue = cue,
				Presentation = new TriggerCue.Types.PresentationCue
				{
					Presentation = documentCue.DocumentAction.Presentation?.Serialize(),
					ArrangementId = TriggerHelper.GetActiveArrangement(documentCue)?.ID.ToUUID(),
					CueIndex = arrangedCue.Index - 1
				},
				Playlist = documentCue.PlaylistParent?.ProtoSerialize(),
				ClientData = 0uL
			};
		}
		return null;
	}

	private static Pro.SerializationInterop.RVProtoData.TriggerSource? GetTriggerSource<T>(Playlist<T>? playlist, ProPresenterCue? item) where T : ProPresenterCue
	{
		if (playlist == null || item == null)
		{
			return null;
		}
		return new Pro.SerializationInterop.RVProtoData.TriggerSource
		{
			PlaylistLocation = new Pro.SerializationInterop.RVProtoData.TriggerSource.Types.Playlist
			{
				Identifier = playlist.ID.ToUUID(),
				ItemIdentifier = item.ID.ToUUID()
			}
		};
	}

	private static Pro.SerializationInterop.RVProtoData.TriggerSource? GetTriggerSource(SlideCue? slide)
	{
		if (slide == null)
		{
			return null;
		}
		return new Pro.SerializationInterop.RVProtoData.TriggerSource
		{
			LibraryLocation = new Pro.SerializationInterop.RVProtoData.TriggerSource.Types.Library
			{
				Path = (slide.ParentPresentation?.SourceFile?.FullPath ?? string.Empty),
				PresentationName = (slide.ParentPresentation?.Name ?? string.Empty)
			}
		};
	}

	private TriggerCue? ResolveNextMediaCue(TriggerOperation currOp, TriggerOperation? nextOp)
	{
		MediaCueInfo<MediaCue> mediaCueInfo = currOp.CueInfo as MediaCueInfo<MediaCue>;
		MediaCue mediaCue = mediaCueInfo?.OriginalMedia;
		Playlist<MediaCue> playlist = mediaCueInfo?.OriginalPlaylist;
		MediaCue mediaCue2 = null;
		if (playlist != null && playlist.Type.CanGotoNext() && playlist.Count > 1)
		{
			if (mediaCue != null && mediaCue.MediaAction?.AudioMedia?.AudioType == AudioType.SoundEffect)
			{
				return null;
			}
			if (playlist is AudioPlaylist audioPlaylist && _app.ShuffleEnabled)
			{
				Func<MediaCue, bool> filter = delegate(MediaCue x)
				{
					MediaAction? mediaAction = x.MediaAction;
					return mediaAction != null && mediaAction.AudioMedia?.AudioType == AudioType.AudioTrack;
				};
				IEnumerable<MediaCue> ignoreCues;
				if (mediaCue == null)
				{
					ignoreCues = Enumerable.Empty<MediaCue>();
				}
				else
				{
					IEnumerable<MediaCue> enumerable = new MediaCue[1] { mediaCue };
					ignoreCues = enumerable;
				}
				mediaCue2 = audioPlaylist.GetRandomCue(filter, ignoreCues);
			}
			else
			{
				switch (mediaCue?.CompletionTarget.Type)
				{
				case CompletionTargetType.Next:
				{
					Func<MediaCue, MediaCue> func = delegate(MediaCue c)
					{
						int num = playlist.IndexOf(c) + 1;
						num %= playlist.Count;
						return playlist.ElementAtOrDefault(num);
					};
					MediaCue mediaCue3 = mediaCue;
					AudioMedia? audioMedia;
					do
					{
						mediaCue3 = func(mediaCue3);
						mediaCue2 = mediaCue3;
						if (mediaCue2 == null || mediaCue2.MediaAction?.Media.MediaType != MediaType.Audio)
						{
							break;
						}
						audioMedia = mediaCue2.MediaAction.AudioMedia;
					}
					while (audioMedia != null && audioMedia.AudioType == AudioType.SoundEffect);
					break;
				}
				case CompletionTargetType.Random:
					mediaCue2 = playlist.GetRandomCue(null, new MediaCue[1] { mediaCue });
					break;
				case CompletionTargetType.Cue:
				{
					CueTarget nextCueTarget = (CueTarget)mediaCue.CompletionTarget;
					mediaCue2 = playlist.FirstOrDefault((MediaCue p) => p.ID == nextCueTarget.ID);
					break;
				}
				case CompletionTargetType.First:
					mediaCue2 = playlist.FirstOrDefault();
					break;
				}
			}
			if (mediaCue2 != null && (currOp.CueInfo?.Location).HasValue)
			{
				nextOp?.AttachMediaCueInfo(currOp.CueInfo.Location, mediaCue2, playlist);
			}
		}
		if (mediaCue2 == null)
		{
			return null;
		}
		return new TriggerCue
		{
			TriggerHandle = currOp.Handle.RawValue,
			TriggerOptions = null,
			Cue = mediaCue2.Serialize(),
			Presentation = null,
			Playlist = playlist?.ProtoSerialize(),
			ClientData = 0uL
		};
	}

	private void OutputConfigurationChanged()
	{
		_outputChangePending = true;
		_displaySettingsTimer.Stop();
		_displaySettingsTimer.Start();
	}

	private void TriggerStageLayouts(StageDataUpdateSource source)
	{
		FlushDisplaySettings();
		StageData stageDoc = _stageDoc;
		_stageDoc = new StageData(DataVault.StagePresentation?.SerializeStageDocument());
		SendData(new SendData
		{
			StageDocument = _stageDoc.StageDocProto
		});
		IEnumerable<Stage.Types.ScreenAssignment> assignments = ((source <= StageDataUpdateSource.StagePresentationChanged) ? GetScreensWithUpdatedLayout(stageDoc, _stageDoc, OutputConfiguration.StageScreenLayoutMap) : OutputConfiguration.StageScreenLayoutMap.Serialize());
		TriggerStageAction(assignments, source.HasFlag(StageDataUpdateSource.Initialization));
		NetworkCommandTrigger.OnChangeStageLayout(OutputConfiguration.StageScreenLayoutMap);
		_messageService.PublishMessage(new CueTriggeredMessage(OutputConfiguration.StageScreenLayoutMap));
	}

	private static IEnumerable<Stage.Types.ScreenAssignment> GetScreensWithUpdatedLayout(StageData oldScreens, StageData newScreens, StageScreenLayoutMap currentMap)
	{
		if (newScreens.StageDocProto == null)
		{
			return Array.Empty<Stage.Types.ScreenAssignment>();
		}
		if (oldScreens.StageDocProto == null)
		{
			return currentMap.Serialize();
		}
		UUID[] changedScreenIds = (from s in newScreens.StageDocProto.Layouts
			where WasChanged(s, oldScreens)
			select s.Uuid).ToArray();
		return from s in currentMap.Serialize()
			where changedScreenIds.Any((UUID id) => s.Layout.ParameterUuid.Equals(id))
			select s;
		static bool WasChanged(Stage.Types.Layout newLayout, StageData oldScreens)
		{
			Stage.Types.Layout layout = oldScreens.StageDocProto?.Layouts.FirstOrDefault((Stage.Types.Layout s) => s.Uuid.Equals(newLayout.Uuid));
			if (layout != null)
			{
				return !layout.Equals(newLayout);
			}
			return false;
		}
	}

	private void FlushDisplaySettings()
	{
		if (Interlocked.Exchange(ref _outputChangePending, value: false))
		{
			_workspaceDebouncer.Invoke((OutputConfiguration.Serialize(), false));
		}
	}

	private void PlaylistLibraryChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (ActivePlaylistItem == null)
		{
			return;
		}
		Playlist<ProPresenterCue>? activeLibraryPlaylist = ActiveLibraryPlaylist;
		if (activeLibraryPlaylist == null || !activeLibraryPlaylist.Contains(ActivePlaylistItem))
		{
			return;
		}
		IEnumerable<IPlaylist<ProPresenterCue>> enumerable = e.OldItems?.Cast<IPlaylist<ProPresenterCue>>();
		if (enumerable == null)
		{
			return;
		}
		foreach (IPlaylist<ProPresenterCue> item in enumerable)
		{
			if (e.Action != NotifyCollectionChangedAction.Remove || ActiveLibraryPlaylist == null)
			{
				continue;
			}
			if (item != ActiveLibraryPlaylist)
			{
				GroupPlaylist<ProPresenterCue> obj = item as GroupPlaylist<ProPresenterCue>;
				if (obj == null || !obj.ContainsChild(ActiveLibraryPlaylist))
				{
					continue;
				}
			}
			ActiveLibraryPlaylist = null;
			ActivePlaylistItem = null;
		}
	}

	private static (Vector2<double> offset, Vector2<double> size, int[] segmentSizes) CalculateSegmentBounds(IBitmapHandle[] bitmaps, bool isVertical)
	{
		IBitmapHandle bitmapHandle = bitmaps.FirstOrDefault();
		if (bitmapHandle == null)
		{
			return default((Vector2<double>, Vector2<double>, int[]));
		}
		int[] array = new int[bitmaps.Length];
		for (int i = 0; i < bitmaps.Length; i++)
		{
			BitmapSource bitmapSource = bitmaps[i].BitmapSource;
			array[i] = (isVertical ? (bitmapSource?.PixelHeight ?? 0) : (bitmapSource?.PixelWidth ?? 0));
		}
		double x = (isVertical ? bitmapHandle.RenderSize.X : bitmaps.Sum((IBitmapHandle b) => b.RenderSize.X));
		double y = (isVertical ? bitmaps.Sum((IBitmapHandle b) => b.RenderSize.Y) : bitmapHandle.RenderSize.Y);
		Vector2<double> item = new Vector2<double>(x, y);
		return (offset: bitmapHandle.RenderOffset + new Vector2<double>(item.X, isVertical ? 0.0 : item.Y) / 2.0, size: item, segmentSizes: array);
	}

	private void SegmentedElementTransfer(RenderingMode renderMode, TriggerOperation currentOp, SlideElementTransfer elementTransfer)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		if (currentOp.SlidePool.TryGetSegments(elementTransfer.ElementID, renderMode, delegate(BezierPath p)
		{
			ResolvePath(p, currentOp, elementTransfer);
		}, out IBitmapHandle[] bitmaps, out bool isVertical) && !bitmaps.Empty())
		{
			var (vector, vector2, segmentSizes) = CalculateSegmentBounds(bitmaps, isVertical);
			elementTransfer.RenderOffset = vector;
			elementTransfer.RenderSize = vector2;
			elementTransfer.SegmentSizes = segmentSizes;
			elementTransfer.BitmapSourceList = bitmaps.ToList();
		}
	}

	private void SingleElementTransfer(RenderingMode renderMode, TriggerOperation currentOp, SlideElementTransfer elementTransfer)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		if (currentOp.SlidePool.TryGetBitmap(elementTransfer.ElementID, renderMode, elementTransfer.TextIndex, delegate(BezierPath p)
		{
			ResolvePath(p, currentOp, elementTransfer);
		}, out IBitmapHandle bitmap))
		{
			elementTransfer.RenderOffset = bitmap.RenderOffset;
			elementTransfer.RenderSize = bitmap.RenderSize;
			elementTransfer.BitmapSourceList.Add(bitmap);
		}
	}

	private void HandleSlideElementTransfer(TriggerAddress address, SlideElementTransfer elementTransfer)
	{
		if (address.TryGetOperation(out TriggerOperation operation))
		{
			RenderingMode renderModeFromLayer = GetRenderModeFromLayer(elementTransfer.ElementLayer);
			if (renderModeFromLayer == RenderingMode.OutputSegment)
			{
				SegmentedElementTransfer(renderModeFromLayer, operation, elementTransfer);
			}
			else
			{
				SingleElementTransfer(renderModeFromLayer, operation, elementTransfer);
			}
		}
	}

	public void ResolvePath(BezierPath path, TriggerOperation currOp, ILinkedTextTransfer elementTransfer)
	{
		PresentationSlideCueInfo linkCueInfo = null;
		if (elementTransfer.SlideLink.Trigger.TryGetOperation(out TriggerOperation operation) && operation.CueInfo is PresentationSlideCueInfo presentationSlideCueInfo)
		{
			linkCueInfo = presentationSlideCueInfo;
		}
		CueInfo activePlaylistItem = null;
		if (elementTransfer.ActivePlaylistItemLink.Trigger.TryGetOperation(out TriggerOperation operation2))
		{
			activePlaylistItem = operation2.CueInfo;
		}
		if (currOp.State == ProOperationState.Prerolling && currOp.CueInfo is PresentationSlideCueInfo presentationSlideCueInfo2)
		{
			linkCueInfo = presentationSlideCueInfo2;
			activePlaylistItem = currOp.CueInfo;
		}
		CountdownInfo countdownInfo = new CountdownInfo((TimeSlice)elementTransfer.PresentationVideoTimeRemaining, elementTransfer.PresentationVideoLooping, (TimeSlice)elementTransfer.AnnouncementVideoTimeRemaining, elementTransfer.AnnouncementVideoLooping, (TimeSlice)elementTransfer.AudioTimeRemaining, elementTransfer.AudioLooping);
		ResolvePath(currOp, path, linkCueInfo, activePlaylistItem, countdownInfo, elementTransfer.StageMessage, elementTransfer.RenderState);
	}

	private void ResolvePath(TriggerOperation currOp, BezierPath path, PresentationSlideCueInfo? linkCueInfo, CueInfo? activePlaylistItem, CountdownInfo? countdownInfo, string stageMessage, TriggerTransferRenderState? renderState = null)
	{
		foreach (MessageInfo item in currOp.MessageInfo)
		{
			if (item.PrimaryTextElement != Guid.Empty && item.PrimaryTextElement == path.ID)
			{
				item.Message.ResolveText(path, _resources.Themes);
			}
		}
		LinkData linkData = new LinkData(_dispatcher, linkCueInfo)
		{
			CurrentSlide = linkCueInfo?.LinkedCurrentSlide,
			NextSlide = linkCueInfo?.LinkedNextSlide,
			CountdownInfo = countdownInfo,
			StageMessage = stageMessage,
			GroupInformation = new SlideGroupInformation(_dispatcher, linkCueInfo),
			SlideLabelInfo = new SlideLabelInfo(_dispatcher, linkCueInfo),
			PlaylistItemInfo = new PlaylistItemInfo(_dispatcher, activePlaylistItem, _timelineManager),
			AutoAdvanceTimeInfo = GetAutoAdvancedInfo(),
			ArrangementInformation = new ArrangementInformation(_dispatcher, linkCueInfo),
			KeyInformation = new KeyInformation(_dispatcher, linkCueInfo),
			PresentationInfo = new PresentationInfo(TriggerHelper.GetDocumentName(ActiveSlides, OutputDestination.Presentation, _timelineManager), TriggerHelper.GetDocumentName(ActiveSlides, OutputDestination.Announcement, _timelineManager), linkCueInfo, _dispatcher),
			CaptureInformation = GetCaptureInformation(),
			CurrentPresentationPlaybackMarkers = TriggerHelper.GetMarkerInformation(this, ProLayerIndex.PresentationBackground),
			CurrentAnnouncementPlaybackMarkers = TriggerHelper.GetMarkerInformation(this, ProLayerIndex.AnnouncementsBackground),
			CurrentAudioPlaybackMarkers = TriggerHelper.GetMarkerInformation(this, ProLayerIndex.Music),
			Timecode = _timecodeService.GetTimecodeInformation(),
			Timers = _resources.Timers,
			CoreTimers = renderState?.Timers,
			RestClientFactory = _restClientFactory
		};
		path.ResolveLinkedData(linkData);
	}

	private IAutoAdvanceTimeInfo GetAutoAdvancedInfo()
	{
		if (!TryGetAutoAdvanceTimeRemaining(ProLayerIndex.PresentationForeground, out var time))
		{
			time = null;
		}
		if (!TryGetAutoAdvanceTimeRemaining(ProLayerIndex.AnnouncementsForeground, out var time2))
		{
			time2 = null;
		}
		return new AutoAdvanceTimeInfo(time, time2);
	}

	private CaptureInformation GetCaptureInformation()
	{
		return _captureInformation;
	}

	private void UpdateCaptureInformation((TimeSlice? elapsedTime, string statusText, System.Windows.Media.Color statusColor) data)
	{
		_captureInformation = new CaptureInformation(data.elapsedTime, data.statusText, data.statusColor);
	}

	private void HandleMessageSlideTransfer(TriggerAddress address, MessageSlideTransfer transfer)
	{
		if (!address.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		if (!operation.Environment.Messages.TryGetValue(transfer.MessageAction.MessageIdentificaton.ParameterUuid.ToGuid(), out SerializedMessage value))
		{
			value = operation.Environment.Messages.FirstOrDefault<KeyValuePair<Guid, SerializedMessage>>((KeyValuePair<Guid, SerializedMessage> kv) => kv.Value.Message.Title.Equals(transfer.MessageAction.MessageIdentificaton.ParameterName)).Value;
		}
		if (value == null)
		{
			return;
		}
		value.Message.TokenValues.Clear();
		foreach (Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue item in transfer.MessageAction.Content)
		{
			value.Message.TokenValues.Add(item.Clone());
		}
		ProPresenter.DO.Messages.Message message = new ProPresenter.DO.Messages.Message(_resources.Themes);
		message.Deserialize(value.Message);
		foreach (Pro.SerializationInterop.RVProtoData.Message.Types.Token token in value.Message.Tokens)
		{
			Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue tokenValue = value.Message.TokenValues.FirstOrDefault((Pro.SerializationInterop.RVProtoData.Message.Types.TokenValue v) => v.TokenId.ToGuid() == token.Uuid.ToGuid());
			if (tokenValue == null || token.Timer == null || tokenValue.Timer == null)
			{
				continue;
			}
			Guid guid = token.Timer.TimerUuid.ToGuid();
			string timerName = token.Timer.Name;
			if (!operation.Environment.Timers.TryGetValue(guid, out Pro.SerializationInterop.RVProtoData.Timer value2))
			{
				value2 = operation.Environment.Timers.FirstOrDefault<KeyValuePair<Guid, Pro.SerializationInterop.RVProtoData.Timer>>((KeyValuePair<Guid, Pro.SerializationInterop.RVProtoData.Timer> kv) => kv.Value.Name.Equals(timerName)).Value;
			}
			if (value2 != null)
			{
				operation.TimerActionData.Add(new TimerInfo(guid, value2.Uuid.ToGuid(), address.Handle, timerName, tokenValue.Timer.Configuration, TimeSlice.Zero, ProTimerActionType.ResetAndStart));
			}
		}
		Pro.SerializationInterop.RVProtoData.Message message2 = message.Serialize();
		Guid primaryTextElement = value.TemplateSlide?.Slide.GetPrimaryTextElement(useDisplayText: false)?.ID ?? Guid.Empty;
		operation.MessageInfo.Add(new MessageInfo(message2, primaryTextElement));
		transfer.Message = message2;
		transfer.Slide = operation.SlidePool.AddMessageSlide(message, value.TemplateSlide);
	}

	private void HandleNextCueTransfer(TriggerAddress currentAddress, NextCueTransfer nextCueTransfer)
	{
		if (!currentAddress.TryGetOperation(out TriggerOperation currOp) || currOp.CueInfo == null)
		{
			return;
		}
		CueInfo cueInfo = currOp.CueInfo;
		InvokeOnDispatcherAndWait(delegate
		{
			TriggerOperation triggerOperation = InternalCreateTriggerOperation(nextCueTransfer.NextCueHandle);
			switch (cueInfo.Location)
			{
			default:
				return;
			case CueLocation.Presentation:
				nextCueTransfer.NextCue = ResolveNextPresentationCue(currOp, triggerOperation);
				nextCueTransfer.Options = nextCueTransfer.NextCue?.TriggerOptions;
				break;
			case CueLocation.MediaBin:
			case CueLocation.AudioBin:
				nextCueTransfer.NextCue = ResolveNextMediaCue(currOp, triggerOperation);
				break;
			}
			if (nextCueTransfer.NextCue != null)
			{
				nextCueTransfer.ClientObject = triggerOperation;
			}
		});
	}

	private static void HandleRemoteStageSlideData(RemoteStageSlideDataTransfer slideDataTransfer)
	{
		if (slideDataTransfer.CurrentSlideAddress.Trigger.TryGetOperation(out TriggerOperation operation) && operation.CueInfo is PresentationSlideCueInfo presentationSlideCueInfo)
		{
			CustomSlide linkedCurrentSlide = presentationSlideCueInfo.LinkedCurrentSlide;
			slideDataTransfer.CurrentSlideText = linkedCurrentSlide?.DisplayText?.AllText ?? string.Empty;
			slideDataTransfer.CurrentSlideNotes = linkedCurrentSlide?.Note?.AllText ?? string.Empty;
			slideDataTransfer.CurrentSlideRTFNotes = linkedCurrentSlide?.Note?.ToRTF() ?? string.Empty;
			CustomSlide linkedNextSlide = presentationSlideCueInfo.LinkedNextSlide;
			if (linkedNextSlide != null)
			{
				slideDataTransfer.NextSlideID = linkedNextSlide.ID;
				slideDataTransfer.NextSlideText = linkedNextSlide.DisplayText?.AllText ?? string.Empty;
				slideDataTransfer.NextSlideNotes = linkedNextSlide.Note?.AllText ?? string.Empty;
				slideDataTransfer.NextSlideRTFNotes = linkedNextSlide.Note?.ToRTF() ?? string.Empty;
			}
		}
	}

	private void ImageRequestTransferHandler(ImageRequestTransfer imageRequestTransfer)
	{
		if (imageRequestTransfer.ImageType == ProImageRequestTransferType.kProImageRequestTransferChordChart)
		{
			InvokeOnDispatcherAndWait(delegate
			{
				if (ActiveSlide?.Source.SlideAction?.Slide is CustomSlide customSlide)
				{
					RelativePath? chordChart = customSlide.ChordChart;
					if ((object)chordChart != null && chordChart.IsValid)
					{
						imageRequestTransfer.Image = ImageHelper.LoadImage(customSlide.ChordChart)?.ToBitmapHandle();
					}
				}
			});
			return;
		}
		bool includeBackground = true;
		CustomSlide customSlide2 = InvokeOnDispatcherAndWait(delegate
		{
			ArrangedCue arrangedCue = null;
			switch (imageRequestTransfer.ImageType)
			{
			case ProImageRequestTransferType.kProImageRequestTransferCurrentSlide:
				arrangedCue = ActiveSlide;
				break;
			case ProImageRequestTransferType.kProImageRequestTransferNextSlide:
				arrangedCue = _slideEnvironments[Destination.GetValueOrDefault()].NextPhysical;
				break;
			}
			includeBackground = arrangedCue?.Source.GetIncludeBackground() ?? false;
			return cloneSlide(arrangedCue);
		});
		if (customSlide2 != null)
		{
			imageRequestTransfer.Image = SlidePreviewRenderer.RenderSlidePreview(customSlide2, new SlidePreviewRenderParams(customSlide2.Size.Cast<int>(), includeBackground, IncludeBackgroundMedia: true, Colors.Black));
		}
		static CustomSlide? cloneSlide(ArrangedCue? cue)
		{
			return cue?.Source?.SlideAction?.Slide?.Clone() as CustomSlide;
		}
	}

	private void HandleAltSlideTransfer(TriggerAddress address, AltSlideTransfer transfer)
	{
		if (!address.TryGetOperation(out TriggerOperation operation) || !transfer.OriginalSlide.Trigger.TryGetOperation(out TriggerOperation operation2))
		{
			return;
		}
		if (!operation.Environment.AudienceLooks.TryGetValue(transfer.LookID, out SerializedLook value) && operation.Environment.LiveLook?.LookID == transfer.LookID)
		{
			value = operation.Environment.LiveLook;
		}
		CustomSlide customSlide = (operation2.CueInfo as SlideCueInfo)?.LinkedCurrentSlide?.Clone(null, preserveID: false, userInitiated: true, includeBackgroundMedia: false, ignoreMediaNotifications: true);
		if (value != null && value.ScreenTemplateProtos.TryGetValue(transfer.ScreenID, out TemplateSlide value2) && operation2.CueInfo != null)
		{
			if (_themeService?.Themes != null && !_themeService.Themes.DoesTemplateSlideExist(value2.Slide.ID))
			{
				transfer.AltSlide = customSlide?.SerializeSlide();
			}
			else
			{
				transfer.AltSlide = operation.SlidePool.AddAltTemplateSlide(customSlide, value2, transfer.ScreenSize);
			}
		}
		else
		{
			transfer.AltSlide = operation.SlidePool.AddAltTemplateSlide(customSlide, null, customSlide?.Size ?? Vector2<double>.Zero);
		}
	}

	private static void HandleTimerTransfer(TriggerAddress address, TimerTransfer transfer)
	{
		if (!address.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		if (!operation.Environment.Timers.TryGetValue(transfer.TimerID, out Pro.SerializationInterop.RVProtoData.Timer value))
		{
			value = operation.Environment.Timers.FirstOrDefault<KeyValuePair<Guid, Pro.SerializationInterop.RVProtoData.Timer>>((KeyValuePair<Guid, Pro.SerializationInterop.RVProtoData.Timer> kv) => kv.Value.Name.Equals(transfer.TimerName)).Value;
		}
		if (value != null)
		{
			if (transfer.TimerActionType == ProTimerActionType.ResetAndStart || transfer.TimerActionType == ProTimerActionType.StopAndReset)
			{
				value.Configuration = transfer.TimerConfiguration;
			}
			operation.TimerActionData.Add(new TimerInfo(transfer.TimerID, value.Uuid.ToGuid(), address.Handle, transfer.TimerName, value.Configuration, transfer.TimerIncrementTime, transfer.TimerActionType));
			transfer.Timer = value;
		}
	}

	private static void HandleCCLISlideTransfer(TriggerAddress address, CCLISlideTransfer transfer)
	{
		if (!transfer.OriginalSlide.Trigger.TryGetOperation(out TriggerOperation operation) || !(operation.CueInfo is SlideCueInfo slideCueInfo) || slideCueInfo.OriginalCurrentSlide?.Source.ParentPresentation != slideCueInfo.OriginalDocumentCue?.DocumentAction?.Presentation)
		{
			return;
		}
		CCLIData cCLIData = slideCueInfo.OriginalDocumentCue?.DocumentAction?.Presentation?.CCLIInfo;
		if (cCLIData != null && DataVault.CCLIPresentation.Display && cCLIData.Display && slideCueInfo.OriginalCurrentSlide != null)
		{
			if (address.TryGetOperation(out TriggerOperation operation2))
			{
				transfer.CCLISlide = operation2.SlidePool.AddCCLISlide(operation2.Environment.CCLITemplateSlide, cCLIData, transfer.ScreenSize);
			}
			else
			{
				transfer.CCLISlide = null;
			}
		}
	}

	private void HandlePlaylistTransfer(TriggerAddress address, PlaylistCueTransfer transfer)
	{
		if (!address.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		Guid playlistID = transfer.PlaylistID;
		string playlistName = transfer.PlaylistName;
		ProPlaylistSourceType playlistSource = transfer.PlaylistSource;
		bool flag = false;
		Func<MediaCue, bool> func = null;
		IEnumerable<IPlaylist<MediaCue>> playlists;
		CueLocation location;
		switch (playlistSource)
		{
		case ProPlaylistSourceType.MediaBin:
			playlists = DataVault.VisualPlaylistCollection;
			location = CueLocation.MediaBin;
			break;
		case ProPlaylistSourceType.AudioBin:
			playlists = DataVault.AudioPlaylistCollection;
			location = CueLocation.AudioBin;
			func = delegate(MediaCue x)
			{
				MediaAction? mediaAction = x.MediaAction;
				return mediaAction != null && mediaAction.AudioMedia?.AudioType == AudioType.AudioTrack;
			};
			if (_app.ShuffleEnabled)
			{
				flag = true;
			}
			break;
		default:
			throw new NotSupportedException();
		}
		if (!(playlists.GetPlaylists()?.FirstOrDefaultBy((IPlaylist<MediaCue> p) => p.ID == playlistID, (IPlaylist<MediaCue> p) => p.Name == playlistName) is Playlist<MediaCue> playlist))
		{
			Log.Warning("Playlist ID={0} Name=\"{1}\" not found for action.", playlistID.ToString(), playlistName);
			return;
		}
		MediaCue mediaCue = null;
		mediaCue = ((!flag) ? ((func != null) ? playlist.FirstOrDefault(func) : playlist.FirstOrDefault()) : playlist.GetRandomCue(func));
		if (mediaCue == null)
		{
			Log.Info("No media cue to trigger from playlist.");
			return;
		}
		transfer.Cue = mediaCue.Serialize();
		TriggerOperation triggerOperation = new TriggerOperation(operation.Environment, transfer.CueHandle, _general, _factoryProvider, _ssAPIOutput.AvailableTransitions);
		triggerOperation.AttachMediaCueInfo(location, mediaCue, playlist);
		transfer.ClientObject = triggerOperation;
	}

	private void HandleStartExternalMonitorTransfer(TriggerAddress address, StartExternalMonitorTransfer transfer)
	{
		if (address.TryGetOperation(out TriggerOperation operation) && operation.SlidePool.TryGetNonResolvedPath(transfer.ElementID, out BezierPath path))
		{
			_monitorController.StartMonitoring(transfer.TriggerHandle, transfer.SlideID, transfer.ElementID, path);
		}
	}

	private void HandleStopExternalMonitorTransfer(StopExternalMonitorTransfer transfer)
	{
		_monitorController.StopMonitoring(transfer.TriggerHandle, transfer.SlideID, transfer.ElementID);
	}

	private void TriggerTransferHandler(TriggerAddress address, TriggerTransfer baseTransfer)
	{
		switch (baseTransfer.TransferType)
		{
		case ProTriggerTransferType.SlideElement:
			HandleSlideElementTransfer(address, (SlideElementTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.MessageSlide:
			HandleMessageSlideTransfer(address, (MessageSlideTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.NextCue:
			HandleNextCueTransfer(address, (NextCueTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.RemoteStageSlideData:
			HandleRemoteStageSlideData((RemoteStageSlideDataTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.AltSlide:
			HandleAltSlideTransfer(address, (AltSlideTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.Timer:
			HandleTimerTransfer(address, (TimerTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.CCLISlide:
			HandleCCLISlideTransfer(address, (CCLISlideTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.PlaylistCue:
			HandlePlaylistTransfer(address, (PlaylistCueTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.StartExternalMonitor:
			HandleStartExternalMonitorTransfer(address, (StartExternalMonitorTransfer)baseTransfer);
			break;
		case ProTriggerTransferType.StopExternalMonitor:
			HandleStopExternalMonitorTransfer((StopExternalMonitorTransfer)baseTransfer);
			break;
		default:
			_transferHandlerFactory.CreateTransferHandler(this, baseTransfer.TransferType)?.Handle(address, baseTransfer);
			break;
		case ProTriggerTransferType.NewAction:
			break;
		}
	}

	private void AsyncTriggerTransferHandler(TriggerAddress address, AsyncTriggerTransfer baseTransfer)
	{
		if (baseTransfer.TransferType == ProTriggerTransferType.GetNetworkTriggerData)
		{
			NetworkTriggerDataTransfer networkTriggerDataTransfer = (NetworkTriggerDataTransfer)baseTransfer;
			ITriggerOperation op = CreateTriggerOperation(networkTriggerDataTransfer.NewTriggerHandle);
			_networkTriggerDataTransferFactory.Handle(this, networkTriggerDataTransfer, op);
		}
	}

	private static RenderingMode GetRenderModeFromLayer(ProSlideElementLayer layer)
	{
		return layer switch
		{
			ProSlideElementLayer.Composite => RenderingMode.OutputComposite, 
			ProSlideElementLayer.ContentMask => RenderingMode.OutputContentMask, 
			ProSlideElementLayer.StageFlash => RenderingMode.OutputStageFlash, 
			ProSlideElementLayer.ByTextIndex => RenderingMode.OutputTextLayer, 
			ProSlideElementLayer.Over => RenderingMode.OutputOver, 
			ProSlideElementLayer.Under => RenderingMode.OutputUnder, 
			ProSlideElementLayer.Segment => RenderingMode.OutputSegment, 
			_ => throw new NotSupportedException(), 
		};
	}

	private void OperationStateChanged(TriggerAddress address, ProOperationState operationState)
	{
		switch (operationState)
		{
		case ProOperationState.Prerolling:
			OnOperationPrerolling(address);
			NotifyMacroTriggerStarted(address);
			break;
		case ProOperationState.Activated:
			OnOperationActivated(address);
			break;
		case ProOperationState.Deactivated:
			OnOperationDeactivated(address);
			break;
		case ProOperationState.Released:
			OnOperationReleased(address);
			break;
		case ProOperationState.Ready:
			OnOperationReady(address);
			break;
		}
		if (operationState.IsAnyOf(ProOperationState.Activated, ProOperationState.Deactivated, ProOperationState.Released))
		{
			NotifyMacroTriggerCompleted(address);
		}
	}

	public void MacroTriggerOPCreated(ITriggerOperation operation, ProPresenterMacro macro)
	{
		_triggeredMacros[operation] = macro;
	}

	private void NotifyMacroTriggerStarted(TriggerAddress address)
	{
		if (address.TryGetOperation(out TriggerOperation operation) && _triggeredMacros.TryGetValue(operation, out ProPresenterMacro macro))
		{
			InvokeOnDispatcherAsync(delegate
			{
				this.MacroTriggerStarted?.Invoke(macro);
			});
		}
	}

	private void NotifyMacroTriggerCompleted(TriggerAddress address)
	{
		if (address.TryGetOperation(out TriggerOperation op) && _triggeredMacros.TryGetValue(op, out ProPresenterMacro macro))
		{
			InvokeOnDispatcherAsync(delegate
			{
				this.MacroTriggerCompleted?.Invoke(macro);
				_triggeredMacros.TryRemove(op, out ProPresenterMacro _);
			});
		}
	}

	private void OnOperationActivated(TriggerAddress address)
	{
		if (!address.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		operation.State = ProOperationState.Activated;
		SendCueTriggerAnalytics(operation);
		CueInfo cueInfo = operation.CueInfo;
		if (cueInfo == null)
		{
			return;
		}
		switch (cueInfo.Location)
		{
		case CueLocation.Presentation:
		{
			PresentationSlideCueInfo presentationSlideCueInfo = cueInfo as PresentationSlideCueInfo;
			if (presentationSlideCueInfo != null)
			{
				InvokeOnDispatcherAsync(delegate
				{
					CCLIData cCLIData = presentationSlideCueInfo.OriginalDocumentCue?.DocumentAction?.Presentation?.CCLIInfo;
					if (cCLIData != null)
					{
						_reportRepo.Add(new CCLIReport(cCLIData));
					}
				});
				break;
			}
			MediaCueInfo<ProPresenterCue> mediaInfo = cueInfo as MediaCueInfo<ProPresenterCue>;
			if (mediaInfo == null)
			{
				break;
			}
			InvokeOnDispatcherAsync(delegate
			{
				if (_needToSwitchActivePlaylistItem)
				{
					ActivePlaylistItem = mediaInfo.OriginalMedia;
					ActiveLibraryMedia = mediaInfo.OriginalMedia;
					_needToSwitchActivePlaylistItem = false;
				}
			});
			break;
		}
		case CueLocation.MediaBin:
		{
			MediaCueInfo<MediaCue> mediaCueInfo2 = cueInfo as MediaCueInfo<MediaCue>;
			if (mediaCueInfo2 == null)
			{
				break;
			}
			InvokeOnDispatcherAsync(delegate
			{
				MediaCue originalMedia = mediaCueInfo2.OriginalMedia;
				MostRecentActiveMedia = originalMedia;
				if (mediaCueInfo2.TriggerLayer == TriggerLayer.Input)
				{
					ActiveLiveVideo = originalMedia;
				}
				else
				{
					ActiveMediaBinBackground = originalMedia;
				}
				VisualPlaylistActiveUpdated.Publish(originalMedia, mediaCueInfo2.OriginalPlaylist);
			});
			break;
		}
		case CueLocation.AudioBin:
			if (cueInfo is MediaCueInfo<MediaCue> mediaCueInfo)
			{
				AudioPlaylistItemTriggered(mediaCueInfo.OriginalMedia, mediaCueInfo.OriginalPlaylist);
			}
			break;
		}
	}

	private static void SendCueTriggerAnalytics(TriggerOperation activatedOp)
	{
		Pro.Common.Time.Clock clock = activatedOp.Clock;
		if (clock != null)
		{
			CueTriggeredEvent.Publish(clock.Stop().TotalMilliseconds);
			LiveVideoInput liveVideoInput = (activatedOp.CueInfo as MediaCueInfo<MediaCue>)?.OriginalMedia?.LiveVideoInput ?? (activatedOp.CueInfo as MediaCueInfo<ProPresenterCue>)?.OriginalMedia?.LiveVideoInput ?? (activatedOp.CueInfo as SlideCueInfo)?.OriginalCurrentSlide?.LiveVideoInput;
			if (liveVideoInput != null)
			{
				VideoInputTriggeredEvent.Publish((!liveVideoInput.AudioSource.IsDeviceConnected) ? VideoInputTriggeredEvent.AudioSources.None : ((liveVideoInput.AudioSource.HasVideoDevice && liveVideoInput.AudioSource.VideoDevice == liveVideoInput.VideoDevice) ? VideoInputTriggeredEvent.AudioSources.Self : VideoInputTriggeredEvent.AudioSources.Other));
			}
		}
	}

	private void OnOperationDeactivated(TriggerAddress address)
	{
		if (!address.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		operation.State = ProOperationState.Deactivated;
		CueInfo cueInfo = operation.CueInfo;
		MediaCueInfo<MediaCue> mediaCueInfo = cueInfo as MediaCueInfo<MediaCue>;
		if (mediaCueInfo == null)
		{
			return;
		}
		MediaCue media = mediaCueInfo.OriginalMedia;
		switch (mediaCueInfo.Location)
		{
		case CueLocation.Presentation:
			InvokeOnDispatcherAsync(delegate
			{
				ActiveLibraryMedia = null;
			});
			break;
		case CueLocation.MediaBin:
			InvokeOnDispatcherAsync(delegate
			{
				if (MostRecentActiveMedia == media)
				{
					_previouslyActiveBackground = MostRecentActiveMedia;
					MostRecentActiveMedia = null;
				}
				if (mediaCueInfo.TriggerLayer.IsAnyOf(TriggerLayer.Background, TriggerLayer.Foreground))
				{
					ActiveMediaBinBackground = null;
				}
				if (mediaCueInfo.TriggerLayer == TriggerLayer.Input)
				{
					ActiveLiveVideo = null;
				}
				VisualPlaylistActiveUpdated.Publish(null, null);
			});
			break;
		case CueLocation.AudioBin:
			InvokeOnDispatcherAsync(delegate
			{
				if (MostRecentActiveAudio == media)
				{
					_previouslyActiveAudio = MostRecentActiveAudio;
					MostRecentActiveAudio = null;
				}
				if (ActiveAudio == media)
				{
					MediaAction? mediaAction = media.MediaAction;
					if (mediaAction != null && mediaAction.AudioMedia?.AudioType == AudioType.AudioTrack)
					{
						ActiveAudio = null;
						AudioPlaylistActiveUpdated.Publish(null, null);
						return;
					}
				}
				if (ActiveAudioItems.Contains(media))
				{
					ActiveAudioItems.Remove(media);
				}
			});
			break;
		}
	}

	private static void OnOperationPrerolling(TriggerAddress address)
	{
		if (address.TryGetOperation(out TriggerOperation operation))
		{
			operation.State = ProOperationState.Prerolling;
		}
	}

	private static void OnOperationReleased(TriggerAddress address)
	{
		if (address.TryGetOperation(out TriggerOperation operation))
		{
			operation.State = ProOperationState.Released;
		}
	}

	private void OnOperationReady(TriggerAddress address)
	{
		if (address.TryGetOperation(out TriggerOperation operation))
		{
			operation.State = ProOperationState.Ready;
		}
		ProCore.TriggerActivate(address.Handle);
	}

	private void OnResourceStateChanged(ResourceAddress address, ProResourceState resourceState, ResourceUpdateInfo? updateInfo)
	{
		TriggerOperation op = address.Trigger?.ClientObject as TriggerOperation;
		if (op != null && address.ResourceType == ProResourceType.Slide)
		{
			switch (resourceState)
			{
			case ProResourceState.Prerolling:
				if (address.Layer == ProLayerIndex.StageDisplay)
				{
					_dispatcher.Invoke(delegate
					{
						_resources.StagePresentation.Layouts.Select((SlideCue l) => l.SlideAction?.Slide as CustomSlide).NotNull().ForEach(delegate(CustomSlide s)
						{
							op.SlidePool.AddSlide(s);
						});
					});
				}
				op.SlidePool.BeginRender(address.ResourceID);
				break;
			case ProResourceState.Activated:
				OnPresentationSlideActivated(address);
				break;
			case ProResourceState.Deactivated:
				OnPresentationSlideDeactivated(address);
				break;
			case ProResourceState.Released:
				op.SlidePool.EndRender(address.ResourceID);
				break;
			}
		}
		if (address.ResourceType == ProResourceType.AudienceLook)
		{
			OnLookStateChanged(address, resourceState);
		}
		if (address.ResourceType == ProResourceType.Slide && address.Layer == ProLayerIndex.StageDisplay)
		{
			OnStageSlideStateChanged(address, resourceState);
		}
		if (address.ResourceType == ProResourceType.Slide && address.Layer == ProLayerIndex.Messages && op?.MessageInfo != null)
		{
			OnMessageStateChanged(address, resourceState);
		}
		if (address.ResourceType == ProResourceType.Slide && resourceState == ProResourceState.Updated && updateInfo != null)
		{
			OnSlideUpdated(address, updateInfo);
		}
		if (address.ResourceType == ProResourceType.Slide && address.Layer == ProLayerIndex.Props)
		{
			OnPropsStateChanged(address, resourceState);
		}
		if (resourceState != ProResourceState.Activated && resourceState != ProResourceState.Deactivated)
		{
			return;
		}
		InvokeOnDispatcherAsync(delegate
		{
			if (address.Layer != ProLayerIndex.PresentationForeground || address.Slot == Guid.Empty)
			{
				this.LayerTriggered?.Invoke(address.Layer, resourceState);
			}
			if (address.ResourceType == ProResourceType.Slide || address.ResourceType == ProResourceType.Media)
			{
				OnMediaTriggered(op, address.Layer, resourceState, address.ResourceID);
			}
			if (resourceState == ProResourceState.Deactivated)
			{
				switch (address.Layer)
				{
				case ProLayerIndex.PresentationForeground:
					this.SlideCleared?.Invoke(OutputDestination.Presentation);
					ProPresenter.DO.Events.SlideCleared.Publish(OutputDestination.Presentation);
					break;
				case ProLayerIndex.PresentationBackground:
					this.BackgroundCleared?.Invoke();
					break;
				case ProLayerIndex.AnnouncementsBackground:
				case ProLayerIndex.AnnouncementsForeground:
					this.SlideCleared?.Invoke(OutputDestination.Announcement);
					ProPresenter.DO.Events.SlideCleared.Publish(OutputDestination.Announcement);
					break;
				case ProLayerIndex.Props:
					this.PropCleared?.Invoke();
					break;
				case ProLayerIndex.Music:
					this.AudioCleared?.Invoke();
					break;
				case ProLayerIndex.Messages:
					break;
				}
			}
		});
	}

	private void OnMediaTriggered(TriggerOperation? op, ProLayerIndex layer, ProResourceState resourceState, Guid mediaResourceId)
	{
		MediaCue originalMediaCue = op.GetOriginalMediaCue();
		MediaAction mediaAction = layer switch
		{
			ProLayerIndex.Music => op.GetAudioMediaAction(), 
			ProLayerIndex.SoundEffects => op.GetAudioMediaAction(), 
			_ => op.GetGraphicMediaAction(), 
		};
		if (mediaAction == null)
		{
			mediaAction = TriggerHelper.GetMediaFromMacro(_resources.MacroSource?.FlatCollection ?? Array.Empty<ProPresenterMacro>(), mediaResourceId);
		}
		this.MediaTriggered?.Invoke(new MediaTriggeredParameters(originalMediaCue, mediaAction, layer, resourceState));
		OnMediaUpdated(layer, resourceState, op, mediaAction?.Media, mediaAction?.PlaybackMarkers, resourceState == ProResourceState.Deactivated);
		if (op?.CueInfo is MediaCueInfo<ProPresenterCue> mediaCueInfo)
		{
			LibraryPlaylistActiveItemUpdated.Publish(OutputDestination.Presentation, mediaCueInfo.OriginalMedia, mediaCueInfo.OriginalPlaylist, layer, resourceState);
		}
	}

	private void OnMediaUpdated(ProLayerIndex layer, ProResourceState state, TriggerOperation? op = null, MediaBase? media = null, PlaybackMarkerCollection? playbackMarkers = null, bool cleared = false)
	{
		if ((cleared || playbackMarkers != null) && _activeMarkers.TryGetValue(layer, out (PlaybackMarkerCollection, System.Action) value))
		{
			value.Item1.DataModified -= value.Item2;
			_activeMarkers.Remove(layer);
		}
		if (!cleared && playbackMarkers != null)
		{
			playbackMarkers.DataModified += dataModified;
			_activeMarkers.Add(layer, (playbackMarkers, dataModified));
		}
		if (cleared)
		{
			_transportStatus.Remove(layer);
		}
		else
		{
			_transportStatus.UpdateMedia(layer, media, cloneMarkers(relative: true), state);
		}
		TransportStatusEntry status = TransportStatus.GetStatus(layer);
		MediaUpdated.Publish(status?.Media, layer, status?.IsPlaying ?? false);
		IPlaybackMarker[] cloneMarkers(bool relative)
		{
			if (cleared || media == null || playbackMarkers == null)
			{
				return Array.Empty<IPlaybackMarker>();
			}
			TimeSlice inPoint = ((!relative) ? TimeSlice.Zero : ((media as ITransportMedia)?.Transport.InPoint ?? TimeSlice.Zero));
			TimeSlice outPoint = ((!relative) ? TimeSlice.MaxValue : ((media as ITransportMedia)?.Transport.OutPoint ?? TimeSlice.Zero));
			return (from m in playbackMarkers
				where m.Timestamp >= inPoint && m.Timestamp <= outPoint
				select m.CloneRelativeTo(inPoint, preserveID: true)).ToArray();
		}
		void dataModified()
		{
			if (op != null)
			{
				Pro.SerializationInterop.RVProtoData.Action action = new Pro.SerializationInterop.RVProtoData.Action
				{
					Media = new Pro.SerializationInterop.RVProtoData.Action.Types.MediaType()
				};
				action.Media.Markers.AddRange(from m in cloneMarkers(relative: false)
					select m.Serialize());
				ProCore.UpdateMediaPlaybackMarkers(op.Handle, layer, action);
				_transportStatus.UpdateMedia(layer, media, cloneMarkers(relative: true), state);
			}
		}
	}

	private void OnPresentationSlideActivated(ResourceAddress address)
	{
		if ((address.Layer != ProLayerIndex.PresentationForeground && address.Layer != ProLayerIndex.AnnouncementsForeground) || !address.Trigger.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		TriggerHandle activatedHandle = operation.Handle;
		CueInfo cueInfo = operation.CueInfo;
		SlideCueInfo slideInfo = cueInfo as SlideCueInfo;
		if (slideInfo == null)
		{
			return;
		}
		ArrangedCue activatedCue = slideInfo.OriginalCurrentSlide;
		if (activatedCue == null)
		{
			return;
		}
		InvokeOnDispatcherAsync(delegate
		{
			OutputDestination destination = slideInfo.ContentDestination.ToDestination();
			if (ActiveSlides.GetActiveHandle(slideInfo.ContentDestination) != activatedHandle && address.Slot == Guid.Empty)
			{
				UpdateActiveSlide(destination, slideInfo.OriginalDocumentCue, activatedCue, activatedHandle);
				UpdateSlideEnvironments(destination, null, slideInfo.OriginalDocumentCue as ProPresenterCue);
				UpdateNextPresentations();
				SlidesUpdated.Publish(ActivePresentationSlide?.Source, NextPresentationSlide?.Source);
				if (_needToSwitchActivePlaylistItem)
				{
					ActivePlaylistItem = slideInfo.OriginalDocumentCue as ProPresenterCue;
					_needToSwitchActivePlaylistItem = false;
				}
			}
			LibraryPlaylistActiveItemUpdated.Publish(destination, slideInfo.OriginalDocumentCue as ProPresenterCue, slideInfo.OriginalPlaylist, address.Layer, ProResourceState.Activated);
			this.SlideTriggered?.Invoke(activatedCue, 0, destination);
			ProPresenter.DO.Events.SlideTriggered.Publish(activatedCue, destination, slideInfo.OriginalDocumentCue?.DocumentAction?.ActiveArrangement?.ArrangedCues.IndexOf(activatedCue) ?? (-1));
		});
	}

	private void OnSlideUpdated(ResourceAddress address, ResourceUpdateInfo updateInfo)
	{
		switch (updateInfo.UpdateType)
		{
		case ProResourceUpdateType.SlideBuildIndex:
		{
			if (!address.Trigger.TryGetOperation(out TriggerOperation operation))
			{
				break;
			}
			CueInfo cueInfo = operation.CueInfo;
			SlideCueInfo slideCueInfo = cueInfo as SlideCueInfo;
			if (slideCueInfo == null)
			{
				break;
			}
			OutputDestination destination = slideCueInfo.ContentDestination.ToDestination();
			int buildIndex = ((SlideBuildIndexUpdateInfo)updateInfo).BuildIndex;
			InvokeOnDispatcherAsync(delegate
			{
				if (slideCueInfo.OriginalCurrentSlide != null)
				{
					slideCueInfo.OriginalCurrentSlide.BuildPosition = buildIndex;
				}
				SlideBuildPositions.SetBuildPosition(destination, buildIndex);
			});
			break;
		}
		case ProResourceUpdateType.AutoAdvance:
		{
			AutoAdvancedUpdateInfo autoAdvanceInfo = (AutoAdvancedUpdateInfo)updateInfo;
			AutoAdvanceTimeRemaining[address.Layer] = TimeSlice.FromSeconds(autoAdvanceInfo.TimeRemaining);
			InvokeOnDispatcherAsync(delegate
			{
				this.WillGotoNextUpdated?.Invoke(address.Layer, autoAdvanceInfo.WillAutoAdvance, autoAdvanceInfo.Progress);
			});
			break;
		}
		case ProResourceUpdateType.SlideOnStageDisplayOnly:
		{
			SlideOnStageOnlyUpdateInfo slideOnStageInfo = (SlideOnStageOnlyUpdateInfo)updateInfo;
			InvokeOnDispatcherAsync(delegate
			{
				SlideOnStageDisplayOnly = slideOnStageInfo.StageOnly;
			});
			break;
		}
		case ProResourceUpdateType.Timer:
			break;
		}
	}

	private void OnPresentationSlideDeactivated(ResourceAddress address)
	{
		if ((address.Layer != ProLayerIndex.PresentationForeground && address.Layer != ProLayerIndex.AnnouncementsForeground) || !address.Trigger.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		TriggerHandle deactivatedHandle = operation.Handle;
		CueInfo cueInfo = operation.CueInfo;
		AutoAdvanceTimeRemaining.TryRemove(address.Layer, out var _);
		InvokeOnDispatcherAsync(delegate
		{
			if (cueInfo is SlideCueInfo slideCueInfo && ActiveSlides.GetActiveHandle(slideCueInfo.ContentDestination) == deactivatedHandle && address.Slot == Guid.Empty)
			{
				OutputDestination destination = slideCueInfo.ContentDestination.ToDestination();
				UpdateActiveSlide(destination, slideCueInfo.OriginalDocumentCue, ActiveSlide, TriggerHandle.Invalid);
				UpdateSlideEnvironments(destination);
				UpdateNextPresentations();
				if (slideCueInfo.OriginalCurrentSlide != null)
				{
					slideCueInfo.OriginalCurrentSlide.BuildPosition = 0;
				}
				LibraryPlaylistActiveItemUpdated.Publish(destination, slideCueInfo.OriginalDocumentCue as ProPresenterCue, slideCueInfo.OriginalPlaylist, address.Layer, ProResourceState.Deactivated);
			}
		});
	}

	private void OnLookStateChanged(ResourceAddress address, ProResourceState resourceState)
	{
		if (resourceState != ProResourceState.Activated)
		{
			return;
		}
		InvokeOnDispatcherAsync(delegate
		{
			if (OutputConfiguration.LiveLook.Live.ID != address.ResourceID)
			{
				_liveLook.UpdateEventEnabled = false;
				try
				{
					if (OutputConfiguration.LiveLook.GoLive(address.ResourceID))
					{
						this.LiveLookChanged?.Invoke(OutputConfiguration.LiveLook);
					}
				}
				finally
				{
					_liveLook.UpdateEventEnabled = true;
				}
			}
		});
	}

	private void OnStageSlideStateChanged(ResourceAddress address, ProResourceState resourceState)
	{
		if ((resourceState != ProResourceState.Activated && resourceState != ProResourceState.Deactivated) || !address.Trigger.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		Guid screenID = address.Slot;
		Guid resourceID = address.ResourceID;
		Guid layoutID = Guid.Empty;
		IEnumerable<Stage.Types.Layout> enumerable = operation.Environment.StageDocument?.StageDocProto?.Layouts;
		foreach (Stage.Types.Layout item in enumerable ?? Enumerable.Empty<Stage.Types.Layout>())
		{
			if (item.Slide.Uuid.ToGuid() == resourceID)
			{
				layoutID = item.Uuid.ToGuid();
				break;
			}
		}
		if (layoutID.IsEmpty() || resourceState != ProResourceState.Activated)
		{
			return;
		}
		InvokeOnDispatcherAsync(delegate
		{
			using (_stageLayoutTriggerer.StartTriggerSupression())
			{
				ScreenArrangementBase screenArrangementBase = OutputConfiguration.StageArrangementScreens.FirstOrDefault((ScreenArrangementBase s) => s.ID == screenID);
				if (screenArrangementBase != null)
				{
					SlideCue slideCue = DataVault.StagePresentation.Layouts.First((SlideCue l) => l.ID == layoutID);
					OutputConfiguration.StageScreenLayoutMap.AssignScreen(screenArrangementBase, slideCue);
				}
			}
		});
	}

	private void OnMessageStateChanged(ResourceAddress address, ProResourceState resourceState)
	{
		if (!address.Trigger.TryGetOperation(out TriggerOperation operation))
		{
			return;
		}
		MessageInfo proto_message = operation.MessageInfo.FirstOrDefault((MessageInfo m) => m.Message.Uuid.ToGuid() == address.Slot);
		if (proto_message == null)
		{
			return;
		}
		switch (resourceState)
		{
		case ProResourceState.Activated:
			InvokeOnDispatcherAsync(delegate
			{
				MessageCollection messageCollection2 = _resources?.Messages;
				if (messageCollection2 != null)
				{
					ProPresenter.DO.Messages.Message message2 = messageCollection2.FirstOrDefaultBy((ProPresenter.DO.Messages.Message m) => m.ID == address.Slot, (ProPresenter.DO.Messages.Message m) => m.Name.Equals(proto_message.Message.Title));
					if (message2 != null)
					{
						messageCollection2.IgnoreTokenChanges = true;
						_messages.UpdateEventEnabled = false;
						message2.Deserialize(proto_message.Message);
						_messages.UpdateEventEnabled = true;
						messageCollection2.IgnoreTokenChanges = false;
						if (!_activeMessages.Contains(message2))
						{
							_activeMessages.Add(message2);
						}
						this.MessageTriggered?.Invoke(message2);
					}
				}
			});
			break;
		case ProResourceState.Deactivated:
			InvokeOnDispatcherAsync(delegate
			{
				MessageCollection messageCollection = _resources?.Messages;
				if (messageCollection != null)
				{
					ProPresenter.DO.Messages.Message message = messageCollection.FirstOrDefaultBy((ProPresenter.DO.Messages.Message m) => m.ID == address.Slot, (ProPresenter.DO.Messages.Message m) => m.Name.Equals(proto_message.Message.Title));
					if (message != null)
					{
						_activeMessages.Remove(message);
						this.MessageCleared?.Invoke(message);
					}
				}
			});
			break;
		}
	}

	private void OnPropsStateChanged(ResourceAddress address, ProResourceState resourceState)
	{
		switch (resourceState)
		{
		case ProResourceState.Activated:
			InvokeOnDispatcherAsync(delegate
			{
				IPropCue propCue2 = _resources.PropSource.FlatCollection.FirstOrDefault((IPropCue a) => a.SlideAction?.Slide.ID == address.ResourceID);
				if (propCue2 != null && !_activeProps.Contains(propCue2))
				{
					_activeProps.Add(propCue2);
					PropTriggered.Publish(propCue2);
				}
			});
			break;
		case ProResourceState.Deactivated:
			InvokeOnDispatcherAsync(delegate
			{
				IPropCue propCue = _resources.PropSource.FlatCollection.FirstOrDefault((IPropCue a) => a.SlideAction?.Slide.ID == address.ResourceID);
				if (propCue != null && _activeProps.Contains(propCue))
				{
					_activeProps.Remove(propCue);
					ProPresenter.DO.Events.PropCleared.Publish(propCue);
				}
			});
			break;
		}
	}

	private void AudioInputStatusHandler(ProAudioInputStatus audioInputStatus)
	{
		if (audioInputStatus != null)
		{
			if (_ssAPIOutput.AvailableAudioInputs.FirstOrDefault((IAudioInputDevice input) => input.UUID == audioInputStatus.DeviceID) is AudioInputDevice audioInputDevice)
			{
				audioInputDevice.UpdateLevels(audioInputStatus);
			}
			else if (_ssAPIOutput.AvailableVideoInputs.FirstOrDefault((IVideoInputDevice input) => input.UUID == audioInputStatus.DeviceID) is VideoInputDevice videoInputDevice)
			{
				videoInputDevice.UpdateLevels(audioInputStatus);
			}
		}
	}

	private void VideoInputStatusHandler(ProVideoInputStatus videoInputStatus)
	{
		if (videoInputStatus != null && _ssAPIOutput.AvailableVideoInputs.FirstOrDefault((IVideoInputDevice input) => input.UUID == videoInputStatus.DeviceID) is VideoInputDevice videoInputDevice)
		{
			videoInputDevice.UpdateStatus(videoInputStatus);
			SyncronizeInputsWithPhysicalDevices();
		}
	}

	private void UpdateAudioInputHandler(Pro.SerializationInterop.RVProtoData.Action.Types.AudioInputType audioInputAction)
	{
		ProPresenter.DO.Audio.AudioInput audioInput = OutputConfiguration.AvailableAudioInputs.ElementAtOrDefault(audioInputAction.Index);
		if (audioInput != null)
		{
			_audioInputUpdating = true;
			if (audioInputAction.OverrideMode)
			{
				audioInput.SetBehaviorMode(audioInputAction.BehaviorMode);
			}
			if (audioInputAction.OverrideVolume)
			{
				audioInput.Source.Routing.MasterChannel.Level = audioInputAction.Volume;
			}
			_audioInputUpdating = false;
			OnAudioInputsChanged();
		}
	}

	private void CloseDisplayButtonClicked(ProScreenType screenType)
	{
		switch (screenType)
		{
		case ProScreenType.Audience:
			HideAudienceScreens();
			break;
		case ProScreenType.Stage:
			HideStageScreens();
			break;
		case ProScreenType.All:
			HideAudienceScreens();
			HideStageScreens();
			break;
		}
	}

	private void InvokeOnDispatcherAsync(System.Action action)
	{
		_dispatcher.InvokeAsync(action, (DispatcherPriority)10);
	}

	private void InvokeOnDispatcherAndWait(System.Action action)
	{
		try
		{
			_dispatcher.Invoke(action, (DispatcherPriority)10);
		}
		catch (TaskCanceledException)
		{
		}
	}

	private T? InvokeOnDispatcherAndWait<T>(Func<T> action)
	{
		try
		{
			return _dispatcher.Invoke(action, (DispatcherPriority)10);
		}
		catch (TaskCanceledException)
		{
			return default(T);
		}
	}

	public void ShowOnScreenStats(bool showOnScreenStats)
	{
		ProCore.SetOnScreenStatsVisible(showOnScreenStats);
	}

	public void InspectAction(ActionBase action)
	{
		ProCore.InspectAction(action.Serialize());
	}

	public void PlayCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			Play = new ControlTransport.Types.PlayControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void UpdateCIPlayRate(double playRate)
	{
		ControlTransport.Types.SetPlayRateControlType setPlayRate = new ControlTransport.Types.SetPlayRateControlType
		{
			PlayRate = playRate
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetPlayRate = setPlayRate
		});
	}

	public void UpdateCIScaleMode(ScaleBehavior scaleBehavior, ScaleAlignment alignment)
	{
		bool isBlurred;
		ControlTransport.Types.SetScaleModeControlType setScaleMode = new ControlTransport.Types.SetScaleModeControlType
		{
			Alignment = alignment.ToProtoScaleAlignment(),
			Mode = scaleBehavior.ToProtoScaleBehavior(out isBlurred),
			IsBlurred = isBlurred
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetScaleMode = setScaleMode
		});
	}

	public void UpdateCIFlipMode(bool flipHorizontally, bool flipVertically)
	{
		ControlTransport.Types.SetFlippedModeControlType setFlippedMode = new ControlTransport.Types.SetFlippedModeControlType
		{
			Horizontal = flipHorizontally,
			Vertical = flipVertically
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetFlippedMode = setFlippedMode
		});
	}

	public void UpdateCINativeRotation(NativeRotation nativeRotation)
	{
		ControlTransport.Types.SetNativeRotationControlType setRotation = new ControlTransport.Types.SetNativeRotationControlType
		{
			Rotation = nativeRotation.ToProtoNativeRotationType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetRotation = setRotation
		});
	}

	public void UpdateCIPremultipliedAlpha(ProPresenter.DO.Media.AlphaType alphaType)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			SetAlphaType = new ControlTransport.Types.SetAlphaTypeControlType
			{
				AlphaType = alphaType.ToProtoAlphaType()
			}
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void UpdateCIAudioFades(bool shouldFadeIn, TimeSlice fadeIn, bool shouldFadeOut, TimeSlice fadeOut)
	{
		ControlTransport.Types.SetAudioFadeType setAudioFade = new ControlTransport.Types.SetAudioFadeType
		{
			FadeInDuration = fadeIn.TotalSeconds,
			FadeOutDuration = fadeOut.TotalSeconds,
			ShouldFadeIn = shouldFadeIn,
			ShouldFadeOut = shouldFadeOut
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetAudioFade = setAudioFade
		});
	}

	public void UpdateCIAudioProperties(AudioProperties audioProps)
	{
		ControlTransport.Types.SetAudioPropertiesType setAudioProperties = new ControlTransport.Types.SetAudioPropertiesType
		{
			AudioProperties = audioProps.Serialize(),
			Solo = { audioProps.InputChannelSet.Select((MediaChannel channel) => channel.SoloActive) }
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			SetAudioProperties = setAudioProperties
		});
	}

	public void MarkCIInPoint(TimeSlice inPoint)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			MarkIn = new ControlTransport.Types.MarkInPointControlType
			{
				Time = inPoint.TotalSeconds
			}
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void MarkCIOutPoint(TimeSlice outPoint)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			MarkOut = new ControlTransport.Types.MarkOutPointControlType
			{
				Time = outPoint.TotalSeconds
			}
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void GoToPosCI(TimeSlice time)
	{
		ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
		{
			JumpToTime = new ControlTransport.Types.JumpToTimeControlType
			{
				Time = time.TotalSeconds
			}
		});
	}

	public void ScrubCIPos(TimeSlice time)
	{
		ScrubToTime(ProLayerIndex.Inspector, time);
	}

	public void BeginCIScrub(TimeSlice time)
	{
		BeginScrub(ProLayerIndex.Inspector, time);
	}

	public void EndCIScrub(TimeSlice time)
	{
		EndScrub(ProLayerIndex.Inspector, time);
	}

	public void ClearCI()
	{
		ProCore.TriggerClearLayerAction(ProLayerIndex.Inspector);
	}

	public void SetCIEffects(EffectsCollection effects)
	{
		if (effects != null)
		{
			ControlTransport.Types.SetEffectsControlType setEffectsControlType = new ControlTransport.Types.SetEffectsControlType();
			setEffectsControlType.Effects.AddRange(from e in effects
				where e.IsEnabled
				select e.Serialize());
			ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
			{
				SetEffects = setEffectsControlType
			});
		}
	}

	public void UpdateCIEffect(EffectParameters effect)
	{
		if (effect.IsEnabled)
		{
			ProCore.ControlTransport(ProLayerIndex.Inspector, new ControlTransport
			{
				UpdateEffect = new ControlTransport.Types.UpdateEffectControlType
				{
					Effect = effect.Serialize()
				}
			});
		}
	}

	public void PauseCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			Pause = new ControlTransport.Types.PauseControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void StepForwardCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			StepForward = new ControlTransport.Types.StepForwardControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void StepBackwardCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			StepBack = new ControlTransport.Types.StepBackControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void GoToStartCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToStart = new ControlTransport.Types.GoToStartControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void GoToEndCI()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToEnd = new ControlTransport.Types.GoToEndControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.Inspector, controlTransport);
	}

	public void Play(ProLayerIndex layer, bool sendToNetwork = true)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			Play = new ControlTransport.Types.PlayControlType()
		};
		ProCore.ControlTransport(layer, controlTransport);
		if (sendToNetwork)
		{
			NetworkCommandTrigger.OnPlay(layer);
		}
		OnMediaUpdated(layer, ProResourceState.Activated);
	}

	public void Pause(ProLayerIndex layer, bool sendToNetwork = true)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			Pause = new ControlTransport.Types.PauseControlType()
		};
		ProCore.ControlTransport(layer, controlTransport);
		if (sendToNetwork)
		{
			NetworkCommandTrigger.OnPause(layer);
		}
		OnMediaUpdated(layer, ProResourceState.Deactivated);
	}

	public void SkipToTime(ProLayerIndex proLayerIndex, int seconds)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			JumpToTime = new ControlTransport.Types.JumpToTimeControlType
			{
				Time = seconds
			}
		};
		ProCore.ControlTransport(proLayerIndex, controlTransport);
	}

	private void BeginScrub(ProLayerIndex layer, TimeSlice time)
	{
		ProCore.ControlTransport(layer, new ControlTransport
		{
			BeginScrub = new ControlTransport.Types.BeginScrubControlType
			{
				Time = time.TotalSeconds
			}
		});
	}

	private void ScrubToTime(ProLayerIndex layer, TimeSlice time)
	{
		ProCore.ControlTransport(layer, new ControlTransport
		{
			ScrubToTime = new ControlTransport.Types.ScrubToTimeControlType
			{
				Time = time.TotalSeconds
			}
		});
	}

	private void EndScrub(ProLayerIndex layer, TimeSlice time)
	{
		ProCore.ControlTransport(layer, new ControlTransport
		{
			EndScrub = new ControlTransport.Types.EndScrubControlType
			{
				Time = time.TotalSeconds
			}
		});
	}

	public bool GetAutoAdvance(ProLayerIndex proLayerIndex)
	{
		if (AutoAdvanceTimeRemaining.ContainsKey(proLayerIndex))
		{
			return AutoAdvanceTimeRemaining[proLayerIndex].TotalMilliseconds > 0.0;
		}
		return false;
	}

	public void CancelAutoAdvance(ProLayerIndex proLayerIndex)
	{
		ProCore.CancelAutoAdvance(proLayerIndex);
	}

	public void PlayPresentationBackground()
	{
		Play(ProLayerIndex.PresentationBackground);
	}

	public void PausePresentationBackground()
	{
		Pause(ProLayerIndex.PresentationBackground);
	}

	public void SetPresentationBackgroundPos(TimeSlice pos)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			JumpToTime = new ControlTransport.Types.JumpToTimeControlType
			{
				Time = pos.TotalSeconds
			}
		};
		ProCore.ControlTransport(ProLayerIndex.PresentationBackground, controlTransport);
	}

	public ProResult SendWebFillTokenAndCookies(int messageId, WebFillTokenAndCookies token)
	{
		return SendData(new SendData
		{
			MessageId = messageId,
			WebfillTokenAndCookies = token
		});
	}

	public ProResult SendPCOData(PCOData pCOData)
	{
		return SendData(new SendData
		{
			PcoData = pCOData
		});
	}

	public void ScrubPresentationBackground(TimeSlice time)
	{
		ScrubToTime(ProLayerIndex.PresentationBackground, time);
	}

	public void BeginPresentationBackgroundScrub(TimeSlice time)
	{
		BeginScrub(ProLayerIndex.PresentationBackground, time);
	}

	public void EndPresentationBackgroundScrub(TimeSlice time)
	{
		EndScrub(ProLayerIndex.PresentationBackground, time);
	}

	public void GotoPresentationBackgroundStart()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToStart = new ControlTransport.Types.GoToStartControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.PresentationBackground, controlTransport);
	}

	public void GotoPresentationBackgroundEnd()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToEnd = new ControlTransport.Types.GoToEndControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.PresentationBackground, controlTransport);
	}

	public void PlayAnnouncementBackground()
	{
		Play(ProLayerIndex.AnnouncementsBackground);
	}

	public void PauseAnnouncementBackground()
	{
		Pause(ProLayerIndex.AnnouncementsBackground);
	}

	public void BeginAnnouncementBackgroundScrub(TimeSlice time)
	{
		BeginScrub(ProLayerIndex.AnnouncementsBackground, time);
	}

	public void EndAnnouncementBackgroundScrub(TimeSlice time)
	{
		EndScrub(ProLayerIndex.AnnouncementsBackground, time);
	}

	public void SetAnnouncementBackgroundPos(TimeSlice pos)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			JumpToTime = new ControlTransport.Types.JumpToTimeControlType
			{
				Time = pos.TotalSeconds
			}
		};
		ProCore.ControlTransport(ProLayerIndex.AnnouncementsBackground, controlTransport);
	}

	public void ScrubAnnouncementBackground(TimeSlice time)
	{
		ScrubToTime(ProLayerIndex.AnnouncementsBackground, time);
	}

	public void GotoAnnouncementBackgroundStart()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToStart = new ControlTransport.Types.GoToStartControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.AnnouncementsBackground, controlTransport);
	}

	public void GotoAnnouncementBackgroundEnd()
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToEnd = new ControlTransport.Types.GoToEndControlType()
		};
		ProCore.ControlTransport(ProLayerIndex.AnnouncementsBackground, controlTransport);
	}

	public void GotoAudioStart(AudioType audioType)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToStart = new ControlTransport.Types.GoToStartControlType()
		};
		ProCore.ControlTransport(audioType.ToProLayerIndex(), controlTransport);
	}

	public void GotoAudioEnd(AudioType audioType)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			GoToEnd = new ControlTransport.Types.GoToEndControlType()
		};
		ProCore.ControlTransport(audioType.ToProLayerIndex(), controlTransport);
	}

	public void PauseAudio(AudioType audioType)
	{
		Pause(audioType.ToProLayerIndex());
		this.AudioTriggered?.Invoke(null, isPlaying: false);
	}

	public void PlayAudio(AudioType audioType)
	{
		Play(audioType.ToProLayerIndex());
		this.AudioTriggered?.Invoke(null, isPlaying: true);
	}

	public void BeginAudioScrub(AudioType audioType, TimeSlice time)
	{
		BeginScrub(audioType.ToProLayerIndex(), time);
	}

	public void ScrubAudio(AudioType audioType, TimeSlice position)
	{
		ScrubToTime(audioType.ToProLayerIndex(), position);
	}

	public void SetAudioPos(AudioType audioType, TimeSlice position)
	{
		ControlTransport controlTransport = new ControlTransport
		{
			JumpToTime = new ControlTransport.Types.JumpToTimeControlType
			{
				Time = position.TotalSeconds
			}
		};
		ProCore.ControlTransport(audioType.ToProLayerIndex(), controlTransport);
	}

	public void EndAudioScrub(AudioType audioType, TimeSlice time)
	{
		EndScrub(audioType.ToProLayerIndex(), time);
	}

	public void StartMonitoringAudioInput(int index)
	{
		ProCore.StartMonitoringAudioInput(index);
		InputAudioMonitoringEvent.Publish(InputAudioMonitoringEvent.InputTypes.Audio);
	}

	public void StopMonitoringAudioInput(int index)
	{
		ProCore.StopMonitoringAudioInput(index);
	}

	public void StartMonitoringVideoInputAudio(int index)
	{
		ProCore.StartMonitoringVideoInputAudio(index);
		InputAudioMonitoringEvent.Publish(InputAudioMonitoringEvent.InputTypes.Video);
	}

	public void StopMonitoringVideoInputAudio(int index)
	{
		ProCore.StopMonitoringVideoInputAudio(index);
	}

	public void RefreshVideoInputDevices()
	{
		_ssAPIOutput.RefreshVideoInputs();
		SyncronizeInputsWithPhysicalDevices();
	}

	public void VideoInputDeviceChanged(ProVideoInputDevice? device, ProDeviceAction action)
	{
		_ssAPIOutput.VideoInputChanged(device, action);
		_outputService.OutputRepository.AvailableLiveVideoInputs.ForEach(delegate(LiveVideoInput i)
		{
			i.SynchronizeWithPhysicalDevice(_outputService.OutputRepository.VideoInputDeviceCollection, _outputService.OutputRepository.AudioInputDeviceCollection);
		});
	}

	public void RefreshAudioInputDevices()
	{
		_ssAPIOutput.RefreshAudioInputs();
		SyncronizeInputsWithPhysicalDevices();
	}

	public void AudioInputDeviceChanged(ProAudioDevice? device, ProDeviceAction action)
	{
		_ssAPIOutput.AudioInputChanged(device, action);
		_outputService.OutputRepository.AvailableAudioInputs.ForEach(delegate(ProPresenter.DO.Audio.AudioInput i)
		{
			i.Source.SynchronizeWithPhysicalDevice(_outputService.OutputRepository.AudioInputDeviceCollection, _outputService.OutputRepository.VideoInputDeviceCollection);
		});
	}

	private void SyncronizeInputsWithPhysicalDevices()
	{
		_outputService.OutputRepository.AvailableLiveVideoInputs.ForEach(delegate(LiveVideoInput i)
		{
			i.SynchronizeWithPhysicalDevice(_outputService.OutputRepository.VideoInputDeviceCollection, _outputService.OutputRepository.AudioInputDeviceCollection);
		});
		_outputService.OutputRepository.AvailableAudioInputs.ForEach(delegate(ProPresenter.DO.Audio.AudioInput i)
		{
			i.Source.SynchronizeWithPhysicalDevice(_outputService.OutputRepository.AudioInputDeviceCollection, _outputService.OutputRepository.VideoInputDeviceCollection);
		});
	}

	public void UpdateNDIFinderSettings(bool nDIShowSources, string nDIReceiveGroups, string nDIAdditionalSearchIPs)
	{
		ProCore.UpdateNDIFinderSettings(nDIShowSources, nDIReceiveGroups, nDIAdditionalSearchIPs);
	}

	public bool TryGetAutoAdvanceTimeRemaining(ProLayerIndex layer, out TimeSlice? time)
	{
		time = null;
		if (AutoAdvanceTimeRemaining.TryGetValue(layer, out var value))
		{
			time = value;
			return true;
		}
		return false;
	}

	public void ChangeActiveMacroGroup(int index)
	{
		ActiveMacroGroup = DataVault.MacroGroups.ElementAtOrDefault(index);
	}

	public void ChangeActivePropGroup(int index)
	{
		ActivePropGroup = DataVault.PropGroupCollection.ElementAtOrDefault(index);
	}

	public void AudioPlaylistItemTriggered(MediaCue mediaCue, Playlist<MediaCue>? playlist)
	{
		InvokeOnDispatcherAsync(delegate
		{
			MediaCue mediaCue2 = mediaCue;
			MostRecentActiveAudio = mediaCue2;
			MediaAction? mediaAction = mediaCue2.MediaAction;
			if (mediaAction != null && mediaAction.AudioMedia?.AudioType == AudioType.AudioTrack)
			{
				ActiveAudio = mediaCue2;
				AudioPlaylistActiveUpdated.Publish(ActiveAudio, playlist);
			}
			else
			{
				ActiveAudioItems.Add(mediaCue2);
			}
			this.AudioTriggered?.Invoke(mediaCue2, isPlaying: true);
		});
	}

	public void SendDocumentsToCore()
	{
		_timers.SourceUpdated();
		_macroGroups.SourceUpdated();
		_propGroups.SourceUpdated();
		_messages.SourceUpdated();
		_ccliSlide.SourceUpdated();
		_liveLook.SourceUpdated();
		_audienceLooks.SourceUpdated();
		_masks.SourceUpdated();
		_backgroundTxSerializer.SourceUpdated();
		_propsTxSerializer.SourceUpdated();
		_messagesTxSerializer.SourceUpdated();
		_foregroundTxSerializer.SourceUpdated();
		_bibleTxSerializer.SourceUpdated();
		_audioTxSerializer.SourceUpdated();
		_libraryPlaylistSerializer.SourceUpdated();
		_audioPlaylistSerializer.SourceUpdated();
		_visualPlaylistSerializer.SourceUpdated();
		FlushDisplaySettings();
	}

	private void SendTimersDocument()
	{
		SendData sendData = new SendData();
		sendData.TimersDocument = DataVault.TimerDocument.Serialize();
		SendData(sendData);
	}

	public void SendMacroIcons(Func<Pro.DO.Triggering.ImageType, string?> getSvgImageString)
	{
		List<MacroIcons.Types.MacroIcon> list = new List<MacroIcons.Types.MacroIcon>();
		Pro.DO.Triggering.ImageType[] values = Enum.GetValues<Pro.DO.Triggering.ImageType>();
		foreach (Pro.DO.Triggering.ImageType imageType in values)
		{
			string text = getSvgImageString(imageType);
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(new MacroIcons.Types.MacroIcon
				{
					ImageData = ByteString.CopyFromUtf8(text),
					ImageType = imageType.ToProtoImageType(),
					ContentType = "image/svg+xml"
				});
			}
		}
		SendData(new SendData
		{
			MacroIcons = new MacroIcons
			{
				Icons = { (IEnumerable<MacroIcons.Types.MacroIcon>)list }
			}
		});
	}

	private void SendMacroGroupsDocument(MacrosDocument? macros)
	{
		SendData(new SendData
		{
			MacrosDocument = macros
		});
	}

	private void SendPropGroupsDocument(PropDocument? document)
	{
		SendData(new SendData
		{
			PropDocument = document
		});
	}

	private void SendMessageDocument(MessageDocument? document)
	{
		SendData(new SendData
		{
			MessageDocument = document
		});
	}

	private void SendCCLIDocument(CCLIDocument document)
	{
		SendData(new SendData
		{
			CcliDocument = document
		});
	}

	private void SendWorkspace(ProPresenterWorkspace workspace, bool triggerLiveLook = false)
	{
		SendData(new SendData
		{
			Workspace = (workspace ?? OutputConfiguration.Serialize())
		});
		if (triggerLiveLook)
		{
			TriggerAudienceLook(OutputConfiguration.LiveLook.Live, TriggerSource.Internal);
		}
	}

	private void SendCCLILayoutData()
	{
		SendData(new SendData
		{
			CopyrightLayout = General.Settings.CCLILayoutData.Serialize()
		});
	}

	private void SendGlobalBackgroundTransition(Transition? transition)
	{
		SendData(new SendData
		{
			GlobalBackgroundTransition = transition
		});
	}

	private void SendGlobalMessagesTransition(Transition? transition)
	{
		SendData(new SendData
		{
			GlobalMessagesTransition = transition
		});
	}

	private void SendGlobalForegroundTransition(Transition? transition)
	{
		SendData(new SendData
		{
			GlobalForegroundTransition = transition
		});
	}

	private void SendGlobalPropsTransition(Transition? transition)
	{
		SendData(new SendData
		{
			GlobalPropsTransition = transition
		});
	}

	private void SendGlobalAudioTransition(Transition? transition)
	{
		SendData(new SendData
		{
			GlobalAudioTransition = transition
		});
	}

	private void SendVisualPlaylistDoc(PlaylistDocument? document)
	{
		SendData(new SendData
		{
			VisualPlaylistDoc = document
		});
	}

	private void SendAudioPlaylistDoc(PlaylistDocument? document)
	{
		SendData(new SendData
		{
			AudioPlaylistDoc = document
		});
	}

	private void SendLibraryPlaylistDoc(PlaylistDocument? document)
	{
		SendData(new SendData
		{
			LibraryPlaylistDoc = document
		});
	}

	public void SendPreferencesData(Preferences proto)
	{
		SendData(new SendData
		{
			Preferences = proto
		});
	}

	public void SendStartupComplete()
	{
		SendData(new SendData
		{
			StartupComplete = new GenericEvent()
		});
	}

	private void SendAudioPlaylistFocused(Playlist<MediaCue> playlist)
	{
		SendData(new SendData
		{
			AudioPlaylistFocusUuid = playlist.ID.ToUUID()
		});
	}

	private void SendMediaPlaylistFocused(Playlist<MediaCue> playlist)
	{
		SendData(new SendData
		{
			MediaPlaylistFocusUuid = playlist.ID.ToUUID()
		});
	}

	private void SendLibraryPlaylistFocused(Playlist<ProPresenterCue> playlist)
	{
		SendData(new SendData
		{
			LibraryPlaylistFocusUuid = playlist.ID.ToUUID()
		});
	}

	private void SendLibraryPlaylistItemFocused(ProPresenterCue item)
	{
		SendData(new SendData
		{
			LibraryPlaylistItemFocusUuid = item.ID.ToUUID()
		});
	}

	private ProResult SendData(SendData sendData)
	{
		int messageId;
		return ProCore.SendData(sendData, out messageId);
	}

	public void HandleTimerStateUpdate(TimerStateUpdate message)
	{
		InvokeOnDispatcherAsync(delegate
		{
			TimerData timerData = DataVault.TimerDocument.Timers.FirstOrDefaultBy((TimerData t) => t.ID == message.Timer.Uuid.ToGuid(), (TimerData t) => t.Name == message.Timer.Name);
			if (timerData != null)
			{
				if (message.State != null && message.State.State == TimerRuntimeState.Types.ResourceState.Deactivated)
				{
					_timers.UpdateEventEnabled = false;
					timerData.Expire();
					_timers.UpdateEventEnabled = true;
				}
				else
				{
					timerData.UpdateSource(message.Timer.Configuration);
					if (message.State != null && message.State.ActionType != null)
					{
						switch (message.State.ActionType.ActionType)
						{
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionStart:
							timerData.Start();
							break;
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionStop:
							timerData.Pause();
							break;
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionReset:
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionStopAndReset:
							_timers.UpdateEventEnabled = false;
							timerData.Reset(message.State.ActionType.TimerConfiguration);
							_timers.UpdateEventEnabled = true;
							break;
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionResetAndStart:
							_timers.UpdateEventEnabled = false;
							timerData.ResetAndStart(message.State.ActionType.TimerConfiguration);
							_timers.UpdateEventEnabled = true;
							break;
						case Pro.SerializationInterop.RVProtoData.Action.Types.TimerType.Types.TimerAction.ActionIncrement:
							_timers.UpdateEventEnabled = false;
							timerData.Increment(TimeSlice.FromSeconds(message.State.ActionType.IncrementAmount));
							_timers.UpdateEventEnabled = true;
							break;
						}
					}
				}
			}
		});
	}

	public void Handle(IApplicationEvent @event)
	{
		if (!(@event is VisualPlaylistCollectionUpdated))
		{
			if (!(@event is AudioPlaylistCollectionUpdated))
			{
				if (@event is LibraryPlaylistCollectionUpdated)
				{
					_libraryPlaylistSerializer.SourceUpdated();
				}
			}
			else
			{
				_audioPlaylistSerializer.SourceUpdated();
			}
		}
		else
		{
			_visualPlaylistSerializer.SourceUpdated();
		}
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
			_activeCuesChangedSubscription?.Dispose();
			_displaySettingsTimer.Dispose();
			_stageLayoutTriggerer.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		OutputConfiguration.PropertyChanged -= base.RaiseLinkedValues;
		General.Settings.PropertyChanged -= base.RaiseLinkedValues;
	}
}
