using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Analytics.Events;
using Pro.DO.Audio;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Collections;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Localization.Services;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Audio;
using ProPresenter.DO.Capture;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncers" })]
public class OutputConfiguration : ObservableObject, IOutputConfiguration, INotifyPropertyChanged, IDocumentProvider, IDisposable
{
	public const int MAXIMUM_SCREEN_ARRANGMENT_COUNT = 16;

	private IProtoSyncedData<ProPresenterWorkspace>? _syncedData;

	private IEntityDocumentSyncer<IProPresenterWorkspaceDoc>? _syncer;

	private DisposableCollection _syncers;

	private readonly AudioInputDeviceCollection _audioInputDevices;

	private readonly VideoInputDeviceCollection _videoInputDevices;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("SelectedLibraryName", "SelectedLibraryName")]
	private readonly IApp _app;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _uiScheduler;

	private readonly IFlagService _flagService;

	private readonly IScreenArrangementFactory _screenArrangementFactory;

	private readonly ProPresenter.DO.Looks.AudienceLookCollection _audienceLooks;

	private readonly ILiveVideoInputCollection _availableLiveVideoInputs;

	private readonly ILocalDocumentSyncerFactory _localConfigSyncerFactory;

	private readonly ILocalization _localization;

	[ObservableProperty]
	private TimeSlice _audioInputTransitionTime = TimeSlice.FromSeconds(1.0);

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack { get; } = new UndoStack();

	public AudienceScreenArrangementCollection AudienceArrangementScreens { get; }

	public StageScreenArrangementCollection StageArrangementScreens { get; }

	public IEnumerable<ScreenArrangementBase> ArrangementScreens => AudienceArrangementScreens.Concat(StageArrangementScreens);

	public StageScreenLayoutMap StageScreenLayoutMap { get; }

	public IAudienceLookCollection AudienceLooks => _audienceLooks;

	public LiveAudienceLook LiveLook { get; }

	public IMaskCollection Masks { get; }

	public IEnumerable<HardwareScreenRectangleOptions> ConfiguredRectangles => ArrangementScreens.GetConfiguredHardwareRectangles();

	public IEnumerable<IDevice> Devices => ArrangementScreens.GetDevices();

	public IAudioInputCollection AvailableAudioInputs { get; }

	public IAudioSetup DigitalAudioSettings { get; }

	public ICaptureSettingsDocument CaptureSettings { get; }

	private string SelectedLibraryName => _app.SelectedLibraryName;

	public bool CanAddMoreScreens => StageArrangementScreens.Count + AudienceArrangementScreens.Count < 16;

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TimeSlice AudioInputTransitionTime
	{
		get
		{
			return _audioInputTransitionTime;
		}
		set
		{
			if (!EqualityComparer<TimeSlice>.Default.Equals(_audioInputTransitionTime, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AudioInputTransitionTime);
				_audioInputTransitionTime = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AudioInputTransitionTime);
			}
		}
	}

	public event System.Action? ConfigurationChanged;

	public event Action<WorkspaceChangedArgs>? WorkspaceChanged;

	public static ObjectBinder<OutputConfiguration, IMergedProPresenterWorkspace> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, ILocalization localization, OutputConfiguration left, IMergedProPresenterWorkspace right)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<ProPresenter.DO.Looks.AudienceLookCollection, IComplexCollection<IProAudienceLook>> audienceLooksBinder = ProPresenter.DO.Looks.AudienceLookCollection.CreateBinder(scheduler, entityFactory, left.AudienceArrangementScreens, left._audienceLooks, right.AudienceLooks);
		IReadOnlyObjectBinder<IMaskCollection, IComplexCollection<IProMask>> masksBinder = left.Masks.CreateBinder(scheduler, right.Masks);
		IReadOnlyObjectBinder<ScreenArrangementCollections, IMergedCollection<IMergedScreen>> screensBinder = ScreenArrangementCollections.CreateBinder(scheduler, entityFactory, factoryProvider.MergedEntityFactory, factoryProvider.ErrorReporter, left.AudienceArrangementScreens, left.StageArrangementScreens, left._screenArrangementFactory, right.Screens);
		IReadOnlyObjectBinder<LiveVideoInputCollection, IMergedCollection<IMergedVideoInput>> videoInputsBinder = left._availableLiveVideoInputs.Bind(scheduler, entityFactory, factoryProvider.MergedEntityFactory, left._audioInputDevices, left._videoInputDevices, right.VideoInputs);
		IReadOnlyObjectBinder<AudioInputCollection, IMergedCollection<IMergedAudioInput>> audioInputsBinder = left.AvailableAudioInputs.Bind(scheduler, entityFactory, factoryProvider.MergedEntityFactory, left._audioInputDevices, left._videoInputDevices, right.AudioInputs);
		ObjectBinder<StageScreenLayoutMap, Pro.Entity.Collections.ICollection<IStage.Types.IScreenAssignment>> stageLayoutMapBinder = ProPresenter.DO.OutputConfiguration.StageScreenLayoutMap.CreateBinder(entityFactory, left.StageScreenLayoutMap, right.StageLayoutMappings);
		ObjectBinder<OutputConfiguration, IMergedProPresenterWorkspace> objectBinder = new ObjectBinder<OutputConfiguration, IMergedProPresenterWorkspace>(left, right);
		objectBinder.Bind((OutputConfiguration l) => l.WhenPropertyChanges("SelectedLibraryName"), (IMergedProPresenterWorkspace r) => r.SelectedLibraryName.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
		{
			r.SelectedLibraryName.Set(l.SelectedLibraryName);
		}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
		{
			l._app.SelectedLibraryName = r.SelectedLibraryName.Value;
		}).Bind((OutputConfiguration l) => l.DigitalAudioSettings.WhenPropertyChanges("BusCount"), (IMergedProPresenterWorkspace r) => r.AudioChannelCount.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
		{
			r.AudioChannelCount.Set((uint)l.DigitalAudioSettings.BusCount);
		}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
		{
			l.DigitalAudioSettings.BusCount = (int)r.AudioChannelCount.Value;
		}).Bind((OutputConfiguration l) => l.WhenPropertyChanges("AudioInputTransitionTime"), (IMergedProPresenterWorkspace r) => r.AudioInputTransitionTime.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
		{
			r.AudioInputTransitionTime.Set(l.AudioInputTransitionTime.TotalSeconds);
		}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
		{
			l.AudioInputTransitionTime = TimeSlice.FromSeconds(r.AudioInputTransitionTime.Value);
		})
			.Bind((OutputConfiguration l) => l.WhenPropertyChanges("CaptureSettings"), (IMergedProPresenterWorkspace r) => r.RecordSettings.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
			{
				IRecording.Types.ISettingsDocument settingsDocument = entityFactory.Create<IRecording.Types.ISettingsDocument>();
				r.RecordSettings.Set(settingsDocument);
				ObjectBinder<ICaptureSettingsDocument, IRecording.Types.ISettingsDocument> objectBinder2 = CaptureSettingsDocument.CreateBinder(scheduler, entityFactory, l.CaptureSettings, settingsDocument);
				settingsDocument.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
			}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
			{
				IRecording.Types.ISettingsDocument settingsDocument2 = r.RecordSettings.Value;
				if (settingsDocument2 == null)
				{
					settingsDocument2 = entityFactory.Create<IRecording.Types.ISettingsDocument>();
					r.RecordSettings.Set(settingsDocument2);
				}
				ObjectBinder<ICaptureSettingsDocument, IRecording.Types.ISettingsDocument> objectBinder3 = CaptureSettingsDocument.CreateBinder(scheduler, entityFactory, l.CaptureSettings, settingsDocument2);
				settingsDocument2.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
			})
			.Bind((OutputConfiguration l) => l.WhenPropertyChanges("DigitalAudioSettings"), (IMergedProPresenterWorkspace r) => r.DigitalAudioSetup.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
			{
				IDigitalAudio.Types.ISetup setup = entityFactory.Create<IDigitalAudio.Types.ISetup>();
				IReadOnlyObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup> readOnlyObjectBinder = l.DigitalAudioSettings.Bind(scheduler, entityFactory, setup);
				setup.RegisterLinkedDisposable(readOnlyObjectBinder);
				r.DigitalAudioSetup.Set(setup);
				readOnlyObjectBinder.InitializeRightFromLeft();
			}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
			{
				IDigitalAudio.Types.ISetup setup2 = r.DigitalAudioSetup.Value;
				if (setup2 == null)
				{
					setup2 = entityFactory.Create<IDigitalAudio.Types.ISetup>();
					r.DigitalAudioSetup.Set(setup2);
				}
				IReadOnlyObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup> readOnlyObjectBinder2 = l.DigitalAudioSettings.Bind(scheduler, entityFactory, setup2);
				setup2.RegisterLinkedDisposable(readOnlyObjectBinder2);
				readOnlyObjectBinder2.InitializeLeftFromRight();
			})
			.Bind((OutputConfiguration l) => l.WhenPropertyChanges("LiveLook"), (IMergedProPresenterWorkspace r) => r.LiveAudienceLook.WhenValueChanges, delegate(OutputConfiguration l, IMergedProPresenterWorkspace r)
			{
				IProAudienceLook proAudienceLook = entityFactory.Create<IProAudienceLook>();
				ObjectBinder<LiveAudienceLook, IProAudienceLook> objectBinder4 = LiveAudienceLook.CreateBinder(scheduler, entityFactory, l.LiveLook, proAudienceLook);
				proAudienceLook.RegisterLinkedDisposable(objectBinder4);
				r.LiveAudienceLook.Set(proAudienceLook);
				objectBinder4.InitializeRightFromLeft();
			}, delegate(IMergedProPresenterWorkspace r, OutputConfiguration l)
			{
				IProAudienceLook proAudienceLook2 = r.LiveAudienceLook.Value;
				if (proAudienceLook2 == null)
				{
					proAudienceLook2 = entityFactory.Create<IProAudienceLook>();
					r.LiveAudienceLook.Set(proAudienceLook2);
				}
				ObjectBinder<LiveAudienceLook, IProAudienceLook> objectBinder5 = LiveAudienceLook.CreateBinder(scheduler, entityFactory, l.LiveLook, proAudienceLook2);
				proAudienceLook2.RegisterLinkedDisposable(objectBinder5);
				objectBinder5.InitializeLeftFromRight();
				if (string.IsNullOrEmpty(l.LiveLook.Live.Name))
				{
					l.LiveLook.Live.Name = localization.Get("GLOBAL_DEFAULT");
				}
			})
			.DoOnInitializeLeftFromRight(delegate
			{
				audienceLooksBinder.InitializeLeftFromRight();
				masksBinder.InitializeLeftFromRight();
				screensBinder.InitializeLeftFromRight();
				videoInputsBinder.InitializeLeftFromRight();
				audioInputsBinder.InitializeLeftFromRight();
				stageLayoutMapBinder.InitializeLeftFromRight();
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				audienceLooksBinder.InitializeRightFromLeft();
				masksBinder.InitializeRightFromLeft();
				screensBinder.InitializeRightFromLeft();
				videoInputsBinder.InitializeRightFromLeft();
				audioInputsBinder.InitializeRightFromLeft();
				stageLayoutMapBinder.InitializeRightFromLeft();
			})
			.RegisterChildDisposable(new CompositeDisposable { audienceLooksBinder, masksBinder, screensBinder, videoInputsBinder, audioInputsBinder, stageLayoutMapBinder });
		return objectBinder;
	}

	public OutputConfiguration(VideoOutputDeviceCollection videoOutputDevices, AudioInputDeviceCollection audioInputDevices, VideoInputDeviceCollection videoInputDevices, IApp app, ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler uiScheduler, IFlagService flagService, IScreenArrangementFactory screenArrangementFactory, IAudioSetup audioSetup, ILiveVideoInputCollection liveVideoInputs, IAudioInputCollection audioInputs, IMaskCollection masks, ProPresenter.DO.Presentation.IPresentation stageScreenPresentation, ILocalDocumentSyncerFactory localConfigSyncerFactory, ILocalization localization, bool loadLegacy)
	{
		_app = app;
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_uiScheduler = uiScheduler;
		_flagService = flagService;
		_screenArrangementFactory = screenArrangementFactory;
		_audioInputDevices = audioInputDevices;
		_videoInputDevices = videoInputDevices;
		_localization = localization;
		Masks = masks;
		PhysicalDevice.TrackRenderEngineDevices(videoOutputDevices);
		AudienceArrangementScreens = new AudienceScreenArrangementCollection(screenArrangementFactory, UndoStack, () => CanAddMoreScreens);
		StageArrangementScreens = new StageScreenArrangementCollection(screenArrangementFactory, UndoStack, () => CanAddMoreScreens);
		_audienceLooks = new ProPresenter.DO.Looks.AudienceLookCollection(AudienceArrangementScreens);
		LiveLook = new LiveAudienceLook(LocalizedStrings.Get("GLOBAL_DEFAULT"), AudienceArrangementScreens, _audienceLooks);
		StageScreenLayoutMap = new StageScreenLayoutMap(StageArrangementScreens, stageScreenPresentation);
		DigitalAudioSettings = audioSetup;
		_availableLiveVideoInputs = liveVideoInputs;
		AvailableAudioInputs = audioInputs;
		_localConfigSyncerFactory = localConfigSyncerFactory;
		CaptureSettings = new CaptureSettingsDocument(new StreamFactory(DigitalAudioSettings.Buses, new DestinationFactory()));
		AudienceArrangementScreens.CollectionModified += ScreenCollectionModified;
		StageArrangementScreens.CollectionModified += ScreenCollectionModified;
		Masks.CollectionModified += OnDataModified;
		AudienceLooks.CollectionModified += OnDataModified;
		LiveLook.Live.DataModified += LiveLook_DataModified;
		_availableLiveVideoInputs.CollectionModified += OnDataModified;
		StageScreenLayoutMap.DataModified += OnDataModified;
		DigitalAudioSettings.DataModified += OnDataModified;
		DigitalAudioSettings.LevelChanged += OnAudioLevelChanged;
		AvailableAudioInputs.CollectionModified += OnDataModified;
		CaptureSettings.DataModified += OnDataModified;
		SetupDocumentSyncer(loadLegacy);
		NormalizeDeviceAssignment();
		UpdateConflictingArrangements();
		videoOutputDevices.CollectionChanged += delegate
		{
			UpdateConflictingArrangements();
		};
		AddPropertyLinks();
		VideoInputStartUpEvent.Publish((uint)_availableLiveVideoInputs.Count);
		AudioSettingsSdiNdiStateEvent.Publish((uint)DigitalAudioSettings.BusCount);
		AudioInputStartUpEvent.Publish((uint)AvailableAudioInputs.Count, (uint)AvailableAudioInputs.Count((ProPresenter.DO.Audio.AudioInput i) => i.BehaviorMode == BehaviorMode.On), (uint)AvailableAudioInputs.Count((ProPresenter.DO.Audio.AudioInput i) => i.BehaviorMode == BehaviorMode.Off), (uint)AvailableAudioInputs.Count((ProPresenter.DO.Audio.AudioInput i) => i.BehaviorMode == BehaviorMode.AutoOn), (uint)AvailableAudioInputs.Count((ProPresenter.DO.Audio.AudioInput i) => i.BehaviorMode == BehaviorMode.AutoOff));
		AvailableAudioInputs.Where((ProPresenter.DO.Audio.AudioInput i) => i.BehaviorMode == BehaviorMode.AutoOn).ForEach(delegate(ProPresenter.DO.Audio.AudioInput i)
		{
			AudioInputAutoOnStartupEvent.Publish((uint)i.LinkedVideoInputs.Count);
		});
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncers.Dispose();
	}

	[MemberNotNull("_syncers")]
	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			ILocalDocumentSyncer<IProPresenterLocalWorkspaceDoc> localConfigSyncer = _localConfigSyncerFactory.CreateWorkspace();
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Workspace", delegate(IProPresenterWorkspaceDoc doc)
			{
				IMergedProPresenterWorkspace mergedProPresenterWorkspace = _factoryProvider.MergedEntityFactory.CreateMergedProPresenterWorkspace(doc, localConfigSyncer.Document);
				ObjectBinder<OutputConfiguration, IMergedProPresenterWorkspace> objectBinder = Bind(_uiScheduler, _factoryProvider, _localization, this, mergedProPresenterWorkspace);
				objectBinder.RegisterChildDisposable(new CompositeDisposable { mergedProPresenterWorkspace });
				return objectBinder;
			}, () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(ProPresenterWorkspace.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
			global::_003C_003Ey__InlineArray2<IDisposable> buffer = default(global::_003C_003Ey__InlineArray2<IDisposable>);
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 0) = localConfigSyncer;
			global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(ref buffer, 1) = _syncer;
			_syncers = DisposableCollection.Create(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<IDisposable>, IDisposable>(in buffer, 2));
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<ProPresenterWorkspace>(CommonPaths.Configuration, "Workspace", OnDataUpdated, OnDataCleared);
			IDisposable reference = _syncedData;
			_syncers = DisposableCollection.Create(new ReadOnlySpan<IDisposable>(in reference));
		}
	}

	private void LoadDefaults()
	{
		OnDataCleared(DataClearSource.FileRemoved);
	}

	private void NormalizeDeviceAssignment()
	{
		IGrouping<string, HardwareScreenRectangleOptions>[] array = (from s in ConfiguredRectangles
			group s by s.OutputDevice?.DeviceID).ToArray();
		foreach (IGrouping<string, HardwareScreenRectangleOptions> source in array)
		{
			HardwareScreenRectangleOptions[] array2 = source.ToArray();
			IDevice device = array2[0].OutputDevice;
			array2.ForEach(delegate(HardwareScreenRectangleOptions s)
			{
				s.OutputDevice = device;
			});
		}
	}

	private void ScreenCollectionModified(ScreenArrangementCollectionBase screenCollection)
	{
		UpdateConflictingArrangements();
		OnPropertyChanged("CanAddMoreScreens");
		OnConfigChanged();
		ScreensUpdated.Publish();
	}

	private void OnConfigChanged()
	{
		OnDataModified();
		this.ConfigurationChanged?.Invoke();
	}

	private void OnDataModified()
	{
		_syncedData?.UpdateData(Serialize());
		this.WorkspaceChanged?.Invoke(new WorkspaceChangedArgs(Immediate: false));
	}

	private void OnAudioLevelChanged()
	{
		_syncedData?.UpdateData(Serialize());
		this.WorkspaceChanged?.Invoke(new WorkspaceChangedArgs(Immediate: true));
	}

	private void LiveLook_DataModified()
	{
		_syncedData?.UpdateData(Serialize());
		this.WorkspaceChanged?.Invoke(new WorkspaceChangedArgs(Immediate: false, LiveLookChanged: true));
	}

	private void UpdateConflictingArrangements()
	{
		ScreenArrangementBase[] array = ArrangementScreens.ToArray();
		ScreenArrangementBase[] array2 = array;
		foreach (ScreenArrangementBase screenArrangementBase in array2)
		{
			Screen[] otherScreens = array.Except(screenArrangementBase).SelectMany((ScreenArrangementBase a) => a.Screens).ToArray();
			screenArrangementBase.CheckForConflicts(otherScreens);
		}
		OnPropertyChanged("Devices");
	}

	private void OnDataCleared(DataClearSource clearSource)
	{
		if (clearSource == DataClearSource.FileRemoved)
		{
			StageArrangementScreens.Clear();
			AudienceArrangementScreens.Clear();
			ScreenArrangementBase defaultScreen = AudienceArrangementScreens.GetDefaultScreen();
			AudienceArrangementScreens.AddScreenArrangement(defaultScreen);
			CaptureSettings.Streams.Reset();
			_audienceLooks.Deserialize(null);
			LiveLook.LoadDefaults(LocalizedStrings.Get("GLOBAL_DEFAULT"));
			Masks.Clear();
		}
		OnPropertyChanged("Devices");
	}

	public void Save()
	{
		OnDataModified();
	}

	private void OnDataUpdated(ProPresenterWorkspace data)
	{
		Deserialize(data);
	}

	public ProPresenterWorkspace Serialize()
	{
		ProPresenterWorkspace proPresenterWorkspace = new ProPresenterWorkspace();
		proPresenterWorkspace.ProScreens.AddRange(ArrangementScreens.Select((ScreenArrangementBase s) => s.Serialize()));
		proPresenterWorkspace.AudienceLooks.AddRange(_audienceLooks.Serialize());
		proPresenterWorkspace.LiveAudienceLook = LiveLook.Serialize();
		proPresenterWorkspace.Masks.AddRange(Masks.Serialize());
		proPresenterWorkspace.VideoInputs.AddRange(_availableLiveVideoInputs.Select((LiveVideoInput i) => i.Serialize()));
		proPresenterWorkspace.StageLayoutMappings.AddRange(StageScreenLayoutMap.Serialize());
		proPresenterWorkspace.AudioInputs.AddRange(AvailableAudioInputs.Select((ProPresenter.DO.Audio.AudioInput i) => i.Serialize()));
		proPresenterWorkspace.DigitalAudioSetup = DigitalAudioSettings.Serialize();
		proPresenterWorkspace.RecordSettings = CaptureSettings.Serialize();
		proPresenterWorkspace.AudioInputTransitionTime = AudioInputTransitionTime.TotalSeconds;
		return proPresenterWorkspace;
	}

	private void Deserialize(ProPresenterWorkspace workspace)
	{
		Deserialize(workspace, removeExisting: true);
	}

	public void Deserialize(ProPresenterWorkspace workspace, bool removeExisting)
	{
		UndoStack.StartIgnoring();
		AudienceArrangementScreens.CollectionModified -= ScreenCollectionModified;
		StageArrangementScreens.CollectionModified -= ScreenCollectionModified;
		AudienceLooks.CollectionModified -= OnDataModified;
		LiveLook.Live.DataModified -= LiveLook_DataModified;
		_availableLiveVideoInputs.CollectionModified -= OnDataModified;
		AvailableAudioInputs.CollectionModified -= OnDataModified;
		StageScreenLayoutMap.DataModified -= OnDataModified;
		CaptureSettings.DataModified -= OnDataModified;
		DigitalAudioSettings.DataModified -= OnDataModified;
		DigitalAudioSettings.LevelChanged -= OnAudioLevelChanged;
		Masks.CollectionModified -= OnDataModified;
		if (workspace.Masks != null)
		{
			Masks.Deserialize(workspace.Masks, null, removeExisting);
		}
		RepeatedField<ProPresenterScreen> proScreens = workspace.ProScreens;
		if (proScreens != null && proScreens.Any())
		{
			SoftDevice.ClearCacheDevice();
			AudienceArrangementScreens.DeserializeScreens(workspace.ProScreens.Where((ProPresenterScreen s) => s.ScreenType == ProPresenterScreen.Types.ScreenType.Audience), removeExisting);
			StageArrangementScreens.DeserializeScreens(workspace.ProScreens.Where((ProPresenterScreen s) => s.ScreenType == ProPresenterScreen.Types.ScreenType.Stage), removeExisting);
		}
		_audienceLooks.Deserialize(workspace.AudienceLooks, removeExisting);
		if (workspace.LiveAudienceLook != null)
		{
			LiveLook.Deserialize(workspace.LiveAudienceLook, AudienceLooks);
		}
		RepeatedField<Stage.Types.ScreenAssignment> stageLayoutMappings = workspace.StageLayoutMappings;
		if (stageLayoutMappings != null && stageLayoutMappings.Any())
		{
			StageScreenLayoutMap.Deserialize(workspace.StageLayoutMappings);
		}
		if (workspace.DigitalAudioSetup != null)
		{
			DigitalAudioSettings.Deserialize(workspace.DigitalAudioSetup);
		}
		else if (workspace.AudioSettings != null)
		{
			DigitalAudioSettings.Deserialize(workspace.AudioSettings);
		}
		RepeatedField<VideoInput> videoInputs = workspace.VideoInputs;
		if (videoInputs != null && videoInputs.Any())
		{
			_availableLiveVideoInputs.Deserialize(workspace.VideoInputs, _audioInputDevices, _videoInputDevices);
		}
		RepeatedField<Pro.SerializationInterop.RVProtoData.AudioInput> audioInputs = workspace.AudioInputs;
		if (audioInputs != null && audioInputs.Any())
		{
			AvailableAudioInputs.Deserialize(workspace.AudioInputs, _audioInputDevices, _videoInputDevices);
		}
		AudioInputTransitionTime = TimeSlice.FromSeconds(workspace.AudioInputTransitionTime);
		CaptureSettings.Deserialize(workspace.RecordSettings);
		AudienceArrangementScreens.CollectionModified += ScreenCollectionModified;
		StageArrangementScreens.CollectionModified += ScreenCollectionModified;
		AudienceLooks.CollectionModified += OnDataModified;
		LiveLook.Live.DataModified += LiveLook_DataModified;
		_availableLiveVideoInputs.CollectionModified += OnDataModified;
		AvailableAudioInputs.CollectionModified += OnDataModified;
		StageScreenLayoutMap.DataModified += OnDataModified;
		CaptureSettings.DataModified += OnDataModified;
		DigitalAudioSettings.DataModified += OnDataModified;
		DigitalAudioSettings.LevelChanged += OnAudioLevelChanged;
		Masks.CollectionModified += OnDataModified;
		UndoStack.StopIgnoring();
		this.WorkspaceChanged?.Invoke(new WorkspaceChangedArgs(Immediate: true, LiveLookChanged: true));
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new WorkspaceDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncers.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _app_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "SelectedLibraryName")
		{
			OnPropertyChanged("SelectedLibraryName");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_app.PropertyChanged += _app_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_app.PropertyChanged -= _app_PropertyChanged;
	}
}
