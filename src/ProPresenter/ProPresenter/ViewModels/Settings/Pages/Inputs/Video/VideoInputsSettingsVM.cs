using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.SerializationInterop.RVProtoData.MediaManagement.v2;
using Pro.SerializationInterop.RVProtoData.MediaService.v2;
using Pro.UI.Controls;
using Pro.UI.Utility;
using Pro.ssAPI.Devices;
using ProPresenter.Controller;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.UI.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs.Video;

public class VideoInputsSettingsVM : ObservableObject, IVideoInputsSettingsVM, INotifyPropertyChanged
{
	private readonly IInputsSettingsService _service;

	private readonly ICoreManager _coreManager;

	private readonly IFileSelectorService _fileSelector;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IFlagService _flagService;

	private readonly IMediaService _mediaService;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IFileSystem _fileSystem;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ServiceName", "AirCastDisplayName")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Password", "AirCastPassword")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("PasswordEnabled", "AirCastPasswordEnabled")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("Enabled", "NotifyCanAddAirCastInput")]
	private readonly IAirCastConfiguration _airCastConfiguration;

	private readonly IAirCastPluginDownload _airCastPluginDownload;

	private ConcurrentDictionary<LiveVideoInput, IDisposable> _awaitingThumbnailImportSubscriptions = new ConcurrentDictionary<LiveVideoInput, IDisposable>();

	[ObservableProperty]
	private bool _isActive;

	[ObservableProperty]
	private bool _isPreviewActive = true;

	[ObservableProperty]
	private LiveVideoInput? _activeLiveVideoInput;

	[ObservableProperty]
	private LiveVideoInput? _selectedLiveVideoInput;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addVideoInputCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<LiveVideoInput?>? addAirCastDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<AudioSource?>? addAirCastDeviceAudioSourceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? addAirCastDeviceOnEmptyCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SelectVideoDeviceCommandParameter?>? addVideoDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? removeVideoInputCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SelectVideoDeviceCommandParameter?>? selectVideoDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SelectVideoDeviceCommandParameter?>? selectAudioSourceVideoDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IAudioInputDevice>? selectAudioSourceAudioDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? setNoSourceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? refreshVideoInputSourceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearSelectedVideoInputDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? selectThumbnailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearThumbnailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<CreateRenderViewParameters>? loadPreviewCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<DestroyRenderViewParameters>? unloadPreviewCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleVideoInputAudioMonitoringCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? captureThumbnailCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? enableAllChannelsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? disableAllChannelsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? gotFocusCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<RequestRenderParameter>? requestRenderCommand;

	public InputsTab Index => InputsTab.VideoInput;

	public INotifyEnumerableChanged<IVideoInputDevice> VideoDevices => _service.VideoInputDeviceCollection;

	public INotifyEnumerableChanged<IAudioInputDevice> AudioDevices => _service.AudioInputDeviceCollection;

	public INotifyEnumerableChanged<LiveVideoInput> LiveVideoInputs => _service.AvailableLiveVideoInputs;

	public TimeSlice VideoInputAudioDelay
	{
		get
		{
			return ActiveLiveVideoInput?.AudioSource.Routing.ChannelSet.FirstOrDefault()?.Delay ?? TimeSlice.Zero;
		}
		set
		{
			ActiveLiveVideoInput?.AudioSource.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
			{
				c.Delay = value;
			});
			OnPropertyChanged("VideoInputAudioDelay");
		}
	}

	private AudioSource? SelectedAudioSource => ActiveLiveVideoInput?.AudioSource;

	public bool CanConfigureAirCast
	{
		get
		{
			LiveVideoInput? activeLiveVideoInput = ActiveLiveVideoInput;
			if (activeLiveVideoInput == null || activeLiveVideoInput.VideoDevice?.Type != VideoDeviceType.Aircast)
			{
				LiveVideoInput? activeLiveVideoInput2 = ActiveLiveVideoInput;
				if (activeLiveVideoInput2 == null)
				{
					return false;
				}
				return activeLiveVideoInput2.AudioSource.VideoDevice?.Type == VideoDeviceType.Aircast;
			}
			return true;
		}
	}

	public string? AirCastDisplayName
	{
		get
		{
			return _airCastConfiguration.ServiceName;
		}
		set
		{
			_airCastConfiguration.ServiceName = value;
		}
	}

	public string? AirCastPassword
	{
		get
		{
			return _airCastConfiguration.Password;
		}
		set
		{
			_airCastConfiguration.Password = value;
		}
	}

	public bool AirCastPasswordEnabled
	{
		get
		{
			return _airCastConfiguration.PasswordEnabled;
		}
		set
		{
			_airCastConfiguration.PasswordEnabled = value;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsActive
	{
		get
		{
			return _isActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsActive);
				_isActive = value;
				OnIsActiveChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public bool IsPreviewActive
	{
		get
		{
			return _isPreviewActive;
		}
		set
		{
			if (!EqualityComparer<bool>.Default.Equals(_isPreviewActive, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsPreviewActive);
				_isPreviewActive = value;
				OnIsPreviewActiveChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsPreviewActive);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public LiveVideoInput? ActiveLiveVideoInput
	{
		get
		{
			return _activeLiveVideoInput;
		}
		set
		{
			if (!EqualityComparer<LiveVideoInput>.Default.Equals(_activeLiveVideoInput, value))
			{
				LiveVideoInput activeLiveVideoInput = _activeLiveVideoInput;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActiveLiveVideoInput);
				_activeLiveVideoInput = value;
				OnActiveLiveVideoInputChanged(activeLiveVideoInput, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActiveLiveVideoInput);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public LiveVideoInput? SelectedLiveVideoInput
	{
		get
		{
			return _selectedLiveVideoInput;
		}
		set
		{
			if (!EqualityComparer<LiveVideoInput>.Default.Equals(_selectedLiveVideoInput, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedLiveVideoInput);
				_selectedLiveVideoInput = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedLiveVideoInput);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddVideoInputCommand => addVideoInputCommand ?? (addVideoInputCommand = new RelayCommand(AddVideoInput, CanAddVideoInput));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<LiveVideoInput?> AddAirCastDeviceCommand => addAirCastDeviceCommand ?? (addAirCastDeviceCommand = new AsyncRelayCommand<LiveVideoInput>(AddAirCastDevice, CanAddAirCastDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<AudioSource?> AddAirCastDeviceAudioSourceCommand => addAirCastDeviceAudioSourceCommand ?? (addAirCastDeviceAudioSourceCommand = new AsyncRelayCommand<AudioSource>(AddAirCastDeviceAudioSource, CanAddAirCastDeviceAudioSource, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AddAirCastDeviceOnEmptyCommand => addAirCastDeviceOnEmptyCommand ?? (addAirCastDeviceOnEmptyCommand = new AsyncRelayCommand(AddAirCastDeviceOnEmpty, CanAddVideoInput, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> AddVideoDeviceCommand => addVideoDeviceCommand ?? (addVideoDeviceCommand = new AsyncRelayCommand<SelectVideoDeviceCommandParameter>(AddVideoDevice, CanAddVideoDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand RemoveVideoInputCommand => removeVideoInputCommand ?? (removeVideoInputCommand = new AsyncRelayCommand(RemoveVideoInput, CanRemoveVideoInput));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectVideoDeviceCommand => selectVideoDeviceCommand ?? (selectVideoDeviceCommand = new AsyncRelayCommand<SelectVideoDeviceCommandParameter>(SelectVideoDevice, CanSelectVideoDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectAudioSourceVideoDeviceCommand => selectAudioSourceVideoDeviceCommand ?? (selectAudioSourceVideoDeviceCommand = new AsyncRelayCommand<SelectVideoDeviceCommandParameter>(SelectAudioSourceVideoDevice, CanSelectAudioSourceVideoDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IAudioInputDevice> SelectAudioSourceAudioDeviceCommand => selectAudioSourceAudioDeviceCommand ?? (selectAudioSourceAudioDeviceCommand = new RelayCommand<IAudioInputDevice>(SelectAudioSourceAudioDevice, (IAudioInputDevice? _) => CanUpdateAudioSettings()));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SetNoSourceCommand => setNoSourceCommand ?? (setNoSourceCommand = new RelayCommand(SetNoSource, CanSetNoSource));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RefreshVideoInputSourceCommand => refreshVideoInputSourceCommand ?? (refreshVideoInputSourceCommand = new RelayCommand(RefreshVideoInputSource));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearSelectedVideoInputDeviceCommand => clearSelectedVideoInputDeviceCommand ?? (clearSelectedVideoInputDeviceCommand = new RelayCommand(ClearSelectedVideoInputDevice));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand SelectThumbnailCommand => selectThumbnailCommand ?? (selectThumbnailCommand = new AsyncRelayCommand(SelectThumbnail, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearThumbnailCommand => clearThumbnailCommand ?? (clearThumbnailCommand = new RelayCommand(ClearThumbnail, CanClearThumbnail));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<CreateRenderViewParameters> LoadPreviewCommand => loadPreviewCommand ?? (loadPreviewCommand = new RelayCommand<CreateRenderViewParameters>(LoadPreview));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<DestroyRenderViewParameters> UnloadPreviewCommand => unloadPreviewCommand ?? (unloadPreviewCommand = new RelayCommand<DestroyRenderViewParameters>(UnloadPreview));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleVideoInputAudioMonitoringCommand => toggleVideoInputAudioMonitoringCommand ?? (toggleVideoInputAudioMonitoringCommand = new RelayCommand(ToggleVideoInputAudioMonitoring, CanToggleVideoInputAudioMonitoring));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand CaptureThumbnailCommand => captureThumbnailCommand ?? (captureThumbnailCommand = new AsyncRelayCommand(CaptureThumbnail, CanCaptureThumbnail, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearDeviceCommand => clearDeviceCommand ?? (clearDeviceCommand = new RelayCommand(ClearDevice, CanUpdateAudioSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand EnableAllChannelsCommand => enableAllChannelsCommand ?? (enableAllChannelsCommand = new RelayCommand(EnableAllChannels, CanUpdateAudioSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand DisableAllChannelsCommand => disableAllChannelsCommand ?? (disableAllChannelsCommand = new RelayCommand(DisableAllChannels, CanUpdateAudioSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GotFocusCommand => gotFocusCommand ?? (gotFocusCommand = new RelayCommand(GotFocus));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<RequestRenderParameter> RequestRenderCommand => requestRenderCommand ?? (requestRenderCommand = new RelayCommand<RequestRenderParameter>(RequestRender));

	public event Action<UndoStack>? StackChanged;

	public VideoInputsSettingsVM(IInputsSettingsService service, ICoreManager coreManager, IFileSelectorService fileSelector, IImportProcessFactory importProcessFactory, IFlagService flagService, IMediaService mediaService, IUiDispatcher uiDispatcher, IAirCastConfiguration airCastConfiguration, IAirCastPluginDownload airCastPluginDownload, IFileSystem fileSystem)
	{
		_service = service;
		_coreManager = coreManager;
		_fileSelector = fileSelector;
		_importProcessFactory = importProcessFactory;
		_flagService = flagService;
		_mediaService = mediaService;
		_uiDispatcher = uiDispatcher;
		_airCastConfiguration = airCastConfiguration;
		_airCastPluginDownload = airCastPluginDownload;
		_fileSystem = fileSystem;
		SelectFirstInput();
		_service.AvailableLiveVideoInputs.CollectionChanged += AvailableLiveVideoInputs_CollectionChanged;
		AddPropertyLinks();
	}

	[RelayCommand(CanExecute = "CanAddVideoInput")]
	private void AddVideoInput()
	{
		ActiveLiveVideoInput = _service.AddVideoInput();
		SelectedLiveVideoInput = ActiveLiveVideoInput;
	}

	private bool CanAddVideoInput()
	{
		return _service.CanAddVideoInput();
	}

	[RelayCommand(CanExecute = "CanAddAirCastDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task AddAirCastDevice(LiveVideoInput? input)
	{
		if (await _airCastPluginDownload.CheckAvailabilityAsync())
		{
			IAirCastVideoInputDevice orAddAirCastVideoInputDevice = _service.VideoInputDeviceCollection.GetOrAddAirCastVideoInputDevice();
			LiveVideoInput liveVideoInput = input ?? _service.AddVideoInput();
			if (liveVideoInput != null)
			{
				liveVideoInput.VideoDevice = orAddAirCastVideoInputDevice;
				ActiveLiveVideoInput = liveVideoInput;
				SelectedLiveVideoInput = liveVideoInput;
			}
		}
	}

	private bool CanAddAirCastDevice(LiveVideoInput? input)
	{
		if (!_airCastConfiguration.Enabled)
		{
			if (input == null)
			{
				return CanAddVideoInput();
			}
			return true;
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanAddAirCastDeviceAudioSource", FlowExceptionsToTaskScheduler = true)]
	private async Task AddAirCastDeviceAudioSource(AudioSource? source)
	{
		if (!(await _airCastPluginDownload.CheckAvailabilityAsync()))
		{
			return;
		}
		IAirCastVideoInputDevice orAddAirCastVideoInputDevice = _service.VideoInputDeviceCollection.GetOrAddAirCastVideoInputDevice();
		LiveVideoInput liveVideoInput = null;
		AudioSource audioSource = source;
		if (audioSource == null)
		{
			liveVideoInput = _service.AddVideoInput();
			audioSource = liveVideoInput?.AudioSource;
		}
		if (audioSource != null)
		{
			audioSource.VideoDevice = orAddAirCastVideoInputDevice;
			if (liveVideoInput != null)
			{
				ActiveLiveVideoInput = liveVideoInput;
			}
		}
	}

	[RelayCommand(CanExecute = "CanAddVideoInput", FlowExceptionsToTaskScheduler = true)]
	private async Task AddAirCastDeviceOnEmpty()
	{
		await AddAirCastDevice(null);
	}

	private bool CanAddAirCastDeviceAudioSource(AudioSource? source)
	{
		if (!_airCastConfiguration.Enabled)
		{
			if (source == null)
			{
				return CanAddVideoInput();
			}
			return true;
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanAddVideoDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task AddVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		if (await parameter.CanSelectVideoDeviceAsync(_airCastPluginDownload))
		{
			LiveVideoInput liveVideoInput = _service.AddVideoInput();
			if (liveVideoInput != null)
			{
				liveVideoInput.VideoDevice = parameter.VideoInputDevice;
				liveVideoInput.VideoMode = parameter.VideoMode ?? parameter.VideoInputDevice?.CurrentMode;
				ActiveLiveVideoInput = liveVideoInput;
				SelectedLiveVideoInput = ActiveLiveVideoInput;
			}
		}
	}

	private bool CanAddVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		return CanAddVideoInput();
	}

	[RelayCommand(CanExecute = "CanRemoveVideoInput")]
	private async Task RemoveVideoInput()
	{
		SelectedLiveVideoInput.ThrowWhenNull("SelectedLiveVideoInput");
		if (_mediaService is IMediaServiceV2 mediaService)
		{
			await RemoveMediaReferenceForVideoInputIfExists(SelectedLiveVideoInput, mediaService).ConfigureAwait(continueOnCapturedContext: true);
			if (_awaitingThumbnailImportSubscriptions.TryRemove(SelectedLiveVideoInput, out IDisposable value))
			{
				value.Dispose();
			}
		}
		LiveVideoInput liveVideoInput = LiveVideoInputs.GetPrevious<LiveVideoInput>(SelectedLiveVideoInput) ?? LiveVideoInputs.GetNext<LiveVideoInput>(SelectedLiveVideoInput);
		_service.RemoveLiveVideoInput(SelectedLiveVideoInput);
		if (ActiveLiveVideoInput == SelectedLiveVideoInput)
		{
			ActiveLiveVideoInput = liveVideoInput;
		}
		SelectedLiveVideoInput = liveVideoInput;
	}

	private bool CanRemoveVideoInput()
	{
		return SelectedLiveVideoInput != null;
	}

	[RelayCommand(CanExecute = "CanSelectVideoDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task SelectVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		if (await parameter.CanSelectVideoDeviceAsync(_airCastPluginDownload))
		{
			ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
			ActiveLiveVideoInput.VideoDevice = parameter.VideoInputDevice;
			ActiveLiveVideoInput.VideoMode = parameter.VideoMode;
		}
	}

	private bool CanSelectVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		return ActiveLiveVideoInput != null;
	}

	[RelayCommand(CanExecute = "CanSelectAudioSourceVideoDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task SelectAudioSourceVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		if (await parameter.CanSelectVideoDeviceAsync(_airCastPluginDownload))
		{
			VerifySelectedAudioSource();
			SelectedAudioSource.SelectVideoDevice(parameter.VideoInputDevice, null);
		}
	}

	private bool CanSelectAudioSourceVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		if (parameter != null)
		{
			IVideoInputDevice? videoInputDevice = parameter.VideoInputDevice;
			if (videoInputDevice != null && videoInputDevice.SupportsAudio)
			{
				return CanUpdateAudioSettings();
			}
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSettings")]
	private void SelectAudioSourceAudioDevice(IAudioInputDevice audioInputDevice)
	{
		VerifySelectedAudioSource();
		SelectedAudioSource.AudioDevice = audioInputDevice;
		StopMonitoringAudio();
	}

	private bool CanUpdateAudioSettings()
	{
		return SelectedAudioSource != null;
	}

	[RelayCommand(CanExecute = "CanSetNoSource")]
	private void SetNoSource()
	{
		ActiveLiveVideoInput.VideoDevice = null;
		ActiveLiveVideoInput.VideoMode = null;
	}

	private bool CanSetNoSource()
	{
		return ActiveLiveVideoInput != null;
	}

	private void NotifyCanAddAirCastInput()
	{
		AddAirCastDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceAudioSourceCommand.NotifyCanExecuteChanged();
		OnPropertyChanged("CanConfigureAirCast");
	}

	[RelayCommand]
	private void RefreshVideoInputSource()
	{
		_coreManager.RefreshVideoInputDevices();
	}

	[RelayCommand]
	private void ClearSelectedVideoInputDevice()
	{
		ActiveLiveVideoInput?.ClearDeviceSelection();
	}

	[RelayCommand(FlowExceptionsToTaskScheduler = true)]
	private async Task SelectThumbnail()
	{
		ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
		if (!_fileSelector.SelectFile(out string selectedFile, FileFilters.ImageOnlyFilter))
		{
			return;
		}
		if (_mediaService is IMediaServiceV2 mediaService)
		{
			await DoMediaImportWithMediaManagement(mediaService, selectedFile, deleteSourceFile: false, VideoInputThumbnailUpdateEvent.ThumbnailUpdateType.Disk).ConfigureAwait(continueOnCapturedContext: false);
			return;
		}
		_importProcessFactory.Create(new FileImportRequest(selectedFile, delegate(string _, string importedFilename, FileMediaBase? _)
		{
			ActiveLiveVideoInput.ThumbnailPath = new RelativePath(importedFilename);
			VideoInputThumbnailUpdateEvent.Publish(VideoInputThumbnailUpdateEvent.ThumbnailUpdateType.Disk);
		})).StartImport();
	}

	[RelayCommand(CanExecute = "CanClearThumbnail")]
	private void ClearThumbnail()
	{
		ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
		ActiveLiveVideoInput.ThumbnailPath = RelativePath.Empty();
		VideoInputThumbnailUpdateEvent.Publish(VideoInputThumbnailUpdateEvent.ThumbnailUpdateType.Reset);
	}

	private bool CanClearThumbnail()
	{
		return ActiveLiveVideoInput?.HasThumbnail ?? false;
	}

	[RelayCommand]
	private void LoadPreview(CreateRenderViewParameters parameters)
	{
		_coreManager.CreateRenderView(parameters);
	}

	[RelayCommand]
	private void UnloadPreview(DestroyRenderViewParameters parameters)
	{
		_coreManager.DestroyRenderView(parameters);
	}

	[RelayCommand(CanExecute = "CanToggleVideoInputAudioMonitoring")]
	private void ToggleVideoInputAudioMonitoring()
	{
		ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
		ToggleVideoInputAudioMonitoring(ActiveLiveVideoInput);
	}

	private void ToggleVideoInputAudioMonitoring(LiveVideoInput liveVideoInput)
	{
		liveVideoInput.AudioSource.IsMonitoring = !liveVideoInput.AudioSource.IsMonitoring;
		if (liveVideoInput.AudioSource.IsMonitoring)
		{
			_coreManager.StartMonitoringVideoInputAudio(liveVideoInput.Index);
		}
		else
		{
			_coreManager.StopMonitoringVideoInputAudio(liveVideoInput.Index);
		}
	}

	private bool CanToggleVideoInputAudioMonitoring()
	{
		return ActiveLiveVideoInput?.AudioSource.HasDevice ?? false;
	}

	[RelayCommand(CanExecute = "CanCaptureThumbnail", FlowExceptionsToTaskScheduler = true)]
	private async Task CaptureThumbnail()
	{
		ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
		if (_service.TryCaptureVideoInputThumbnail(ActiveLiveVideoInput.ID, _flagService.IsFlagEnabled(Flag.Cloud) ? _fileSystem.Path.GetTempPath() : CommonPaths.MediaAssets, out RelativePath thumbnailImageFile))
		{
			if (_mediaService is IMediaServiceV2 mediaService)
			{
				await DoMediaImportWithMediaManagement(mediaService, thumbnailImageFile, deleteSourceFile: true, VideoInputThumbnailUpdateEvent.ThumbnailUpdateType.Capture).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			ActiveLiveVideoInput.ThumbnailPath = thumbnailImageFile;
			VideoInputThumbnailUpdateEvent.Publish(VideoInputThumbnailUpdateEvent.ThumbnailUpdateType.Capture);
		}
	}

	private bool CanCaptureThumbnail()
	{
		if (ActiveLiveVideoInput != null && ActiveLiveVideoInput.HasSignal)
		{
			return IsPreviewActive;
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSettings")]
	private void ClearDevice()
	{
		VerifySelectedAudioSource();
		SelectedAudioSource.ClearDeviceSelection();
		StopMonitoringAudio();
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSettings")]
	private void EnableAllChannels()
	{
		SetMuteAllValue(mute: false);
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSettings")]
	private void DisableAllChannels()
	{
		SetMuteAllValue(mute: true);
	}

	[MemberNotNull("SelectedAudioSource")]
	private void VerifySelectedAudioSource()
	{
		if (SelectedAudioSource == null)
		{
			throw new InvalidOperationException("SelectedAudioSource must not be null");
		}
	}

	[RelayCommand]
	private void GotFocus()
	{
		this.StackChanged?.Invoke(_service.AvailableLiveVideoInputs.UndoStack);
	}

	[RelayCommand]
	private void RequestRender(RequestRenderParameter renderParam)
	{
		_service.RenderPreview(renderParam.Texture, renderParam.TextureSize);
	}

	private void StopMonitoringAudio()
	{
		LiveVideoInputs.Where((LiveVideoInput d) => d.AudioSource.IsMonitoring).ForEach(ToggleVideoInputAudioMonitoring);
	}

	private void UpdateVideoInputPreview()
	{
		if (IsActive && IsPreviewActive && ActiveLiveVideoInput != null)
		{
			_coreManager.ProCore.PreviewVideoInput(((IEnumerable<LiveVideoInput>)LiveVideoInputs).IndexOf<LiveVideoInput>(ActiveLiveVideoInput));
		}
		else
		{
			_coreManager.ClearVideoInputPreview();
		}
	}

	private void LiveVideoInput_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "HasThumbnail":
		case "HasSignal":
			NotifyCanExecuteChanged();
			break;
		case "VideoDevice":
		case "Index":
			UpdateVideoInputPreview();
			OnPropertyChanged("CanConfigureAirCast");
			break;
		}
	}

	private void AudioSource_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "HasDevice")
		{
			NotifyCanExecuteChanged();
		}
		else if (e.PropertyName == "VideoDevice")
		{
			OnPropertyChanged("CanConfigureAirCast");
		}
	}

	private void AvailableLiveVideoInputs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		AddVideoInputCommand.NotifyCanExecuteChanged();
		AddVideoDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceOnEmptyCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceAudioSourceCommand.NotifyCanExecuteChanged();
		LiveVideoInput liveVideoInput = e.NewItems?.OfType<LiveVideoInput>().FirstOrDefault();
		if (liveVideoInput != null)
		{
			ActiveLiveVideoInput = liveVideoInput;
		}
	}

	private void NotifyCanExecuteChanged()
	{
		RemoveVideoInputCommand.NotifyCanExecuteChanged();
		CaptureThumbnailCommand.NotifyCanExecuteChanged();
		ClearDeviceCommand.NotifyCanExecuteChanged();
		EnableAllChannelsCommand.NotifyCanExecuteChanged();
		DisableAllChannelsCommand.NotifyCanExecuteChanged();
		ToggleVideoInputAudioMonitoringCommand.NotifyCanExecuteChanged();
		ClearThumbnailCommand.NotifyCanExecuteChanged();
		SelectVideoDeviceCommand.NotifyCanExecuteChanged();
		SelectAudioSourceVideoDeviceCommand.NotifyCanExecuteChanged();
		SelectAudioSourceAudioDeviceCommand.NotifyCanExecuteChanged();
	}

	private void SelectFirstInput()
	{
		ActiveLiveVideoInput = LiveVideoInputs?.FirstOrDefault();
		SelectedLiveVideoInput = ActiveLiveVideoInput;
	}

	private void SetMuteAllValue(bool mute)
	{
		SelectedAudioSource?.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
		{
			c.MuteActive = mute;
		});
	}

	private async Task DoMediaImportWithMediaManagement(IMediaServiceV2 mediaService, string toImportFile, bool deleteSourceFile, VideoInputThumbnailUpdateEvent.ThumbnailUpdateType updateType)
	{
		ActiveLiveVideoInput.ThrowWhenNull("ActiveLiveVideoInput");
		LiveVideoInput liveVideoInput = ActiveLiveVideoInput;
		if (_awaitingThumbnailImportSubscriptions.TryRemove(liveVideoInput, out IDisposable value))
		{
			value.Dispose();
		}
		await RemoveMediaReferenceForVideoInputIfExists(liveVideoInput, mediaService).ConfigureAwait(continueOnCapturedContext: false);
		_awaitingThumbnailImportSubscriptions.AddOrUpdate(liveVideoInput, mediaService.WhenMediaReferenceChanged.FirstAsync((IMediaServiceResponse x) => (x is MediaServiceOkResponse<ImportSuccessData> mediaServiceOkResponse && mediaServiceOkResponse.Data.ContainerId == "VideoInput" && mediaServiceOkResponse.Data.MediaReferenceId == liveVideoInput.ID) || (x is IMediaServiceErrorResponse { ContainerId: "VideoInput", MediaReferenceId: var mediaReferenceId } && mediaReferenceId == liveVideoInput.ID)).Subscribe((Action<IMediaServiceResponse>)delegate(IMediaServiceResponse x)
		{
			MediaServiceOkResponse<ImportSuccessData> importResponse = x as MediaServiceOkResponse<ImportSuccessData>;
			if ((object)importResponse != null)
			{
				_uiDispatcher.Invoke(delegate
				{
					liveVideoInput.ThumbnailPath = new RelativePath(importResponse.Data.FinalUrl);
					VideoInputThumbnailUpdateEvent.Publish(updateType);
				});
				if (deleteSourceFile)
				{
					_fileSystem.File.Delete(toImportFile);
				}
			}
		}, (Action)delegate
		{
			_awaitingThumbnailImportSubscriptions.TryRemove(liveVideoInput, out IDisposable _);
		}), (LiveVideoInput _, IDisposable _) => Disposable.Empty);
		_importProcessFactory.Create(new FileImportRequest(toImportFile, delegate
		{
		})
		{
			ContainerId = "VideoInput",
			OverrideMediaId = liveVideoInput.ID,
			ForceManageMedia = true
		}).StartImport();
	}

	private async Task RemoveMediaReferenceForVideoInputIfExists(LiveVideoInput videoInput, IMediaServiceV2 mediaService)
	{
		if ((await mediaService.GetMedia(new RequestEnvelope.Types.GetMediaReference
		{
			Id = new ReferenceIdentifier
			{
				Uuid = videoInput.ID.ToString(),
				ContainerId = "VideoInput"
			}
		}).ConfigureAwait(continueOnCapturedContext: false)) is MediaServiceOkResponse<ResponseEnvelope.Types.GetMediaReferenceResponse>)
		{
			RemoveMediaReferences removeMediaReferences = new RemoveMediaReferences();
			removeMediaReferences.Id.Add(new ReferenceIdentifier
			{
				Uuid = videoInput.ID.ToString(),
				ContainerId = "VideoInput"
			});
			await mediaService.RemoveMediaReference(removeMediaReferences).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsActiveChanged(bool value)
	{
		if (value)
		{
			RefreshVideoInputSource();
		}
		else
		{
			StopMonitoringAudio();
		}
		UpdateVideoInputPreview();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsPreviewActiveChanged(bool value)
	{
		CaptureThumbnailCommand.NotifyCanExecuteChanged();
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnActiveLiveVideoInputChanged(LiveVideoInput? oldValue, LiveVideoInput? newValue)
	{
		StopMonitoringAudio();
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= LiveVideoInput_PropertyChanged;
			oldValue.AudioSource.PropertyChanged -= AudioSource_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += LiveVideoInput_PropertyChanged;
			newValue.AudioSource.PropertyChanged += AudioSource_PropertyChanged;
		}
		NotifyCanExecuteChanged();
		OnPropertyChanged("VideoInputAudioDelay");
		UpdateVideoInputPreview();
		OnPropertyChanged("CanConfigureAirCast");
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _airCastConfiguration_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		switch (e.PropertyName)
		{
		case "ServiceName":
			OnPropertyChanged("AirCastDisplayName");
			break;
		case "Password":
			OnPropertyChanged("AirCastPassword");
			break;
		case "PasswordEnabled":
			OnPropertyChanged("AirCastPasswordEnabled");
			break;
		case "Enabled":
			NotifyCanAddAirCastInput();
			break;
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_airCastConfiguration.PropertyChanged += _airCastConfiguration_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_airCastConfiguration.PropertyChanged -= _airCastConfiguration_PropertyChanged;
	}
}
