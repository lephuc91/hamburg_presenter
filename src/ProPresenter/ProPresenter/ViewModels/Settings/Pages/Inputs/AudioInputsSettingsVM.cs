using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.ssAPI.Devices;
using ProPresenter.Controller;
using ProPresenter.Controller.NetworkAPI;
using ProPresenter.DO.Audio;
using ProPresenter.DO.LiveVideo;
using ProPresenter.UI.LiveVideo;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs;
using ProPresenter.UI.ViewModels.Settings.Pages.Inputs.Audio;

namespace ProPresenter.ViewModels.Settings.Pages.Inputs;

public class AudioInputsSettingsVM : LinkedObservableObjectBase, IAudioInputsSettingsVM, INotifyPropertyChanged
{
	private readonly IInputsSettingsService _service;

	private readonly ICoreManager _coreManager;

	private readonly PairedCollection<LiveVideoInput, IVideoInputItemVM> _videoInputs;

	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ServiceName", "AirCastDisplayName")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("Password", "AirCastPassword")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("PasswordEnabled", "AirCastPasswordEnabled")]
	[Pro.Common.SourceGenerator.Attributes.ActionLink("Enabled", "NotifyCanAddAirCastAudioInput")]
	private readonly IAirCastConfiguration _airCastConfiguration;

	private readonly IAirCastPluginDownload _airCastPluginDownload;

	[ObservableProperty]
	private bool _isActive;

	[ObservableProperty]
	private AudioInput? _selectedAudioInput;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? refreshAudioInputSourceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? addAudioInputCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<AudioSource?>? addAirCastDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand? addAirCastDeviceOnEmptyCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? removeAudioInputCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? clearDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IAudioInputDevice>? selectAudioDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SelectVideoDeviceCommandParameter?>? selectVideoDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IAudioInputDevice?>? addAudioDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private AsyncRelayCommand<SelectVideoDeviceCommandParameter?>? addVideoDeviceCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? toggleAudioInputAudioMonitoringCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? enableAllChannelsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? disableAllChannelsCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? gotFocusCommand;

	public InputsTab Index => InputsTab.AudioInput;

	public INotifyEnumerableChanged<AudioInput> AudioInputs => _service.AvailableAudioInputs;

	public INotifyEnumerableChanged<IVideoInputItemVM> VideoInputs => _videoInputs;

	public AudioBehaviorModeInternal BehaviorMode
	{
		get
		{
			return SelectedAudioInput?.BehaviorMode.ToAudioBehaviorModeInternal() ?? AudioBehaviorModeInternal.On;
		}
		set
		{
			if (SelectedAudioInput != null)
			{
				SelectedAudioInput.BehaviorMode = value.ToBehaviorMode();
			}
		}
	}

	public TimeSlice AudioInputAudioDelay
	{
		get
		{
			return SelectedAudioSource?.Routing.ChannelSet.FirstOrDefault()?.Delay ?? TimeSlice.Zero;
		}
		set
		{
			SelectedAudioSource?.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
			{
				c.Delay = value;
			});
			OnPropertyChanged("AudioInputAudioDelay");
		}
	}

	public INotifyEnumerableChanged<IAudioInputDevice> AudioDevices => _service.AudioInputDeviceCollection;

	public INotifyEnumerableChanged<IVideoInputDevice> VideoDevices => _service.VideoInputDeviceCollection;

	private AudioSource? SelectedAudioSource => SelectedAudioInput?.Source;

	public bool CanConfigureAirCast
	{
		get
		{
			AudioSource? selectedAudioSource = SelectedAudioSource;
			if (selectedAudioSource == null)
			{
				return false;
			}
			return selectedAudioSource.VideoDevice?.Type == VideoDeviceType.Aircast;
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
	public AudioInput? SelectedAudioInput
	{
		get
		{
			return _selectedAudioInput;
		}
		set
		{
			if (!EqualityComparer<AudioInput>.Default.Equals(_selectedAudioInput, value))
			{
				AudioInput selectedAudioInput = _selectedAudioInput;
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedAudioInput);
				_selectedAudioInput = value;
				OnSelectedAudioInputChanged(selectedAudioInput, value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedAudioInput);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RefreshAudioInputSourceCommand => refreshAudioInputSourceCommand ?? (refreshAudioInputSourceCommand = new RelayCommand(RefreshAudioInputSource));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand AddAudioInputCommand => addAudioInputCommand ?? (addAudioInputCommand = new RelayCommand(AddAudioInput, CanAddAudioInput));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<AudioSource?> AddAirCastDeviceCommand => addAirCastDeviceCommand ?? (addAirCastDeviceCommand = new AsyncRelayCommand<AudioSource>(AddAirCastDevice, CanAddAirCastDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand AddAirCastDeviceOnEmptyCommand => addAirCastDeviceOnEmptyCommand ?? (addAirCastDeviceOnEmptyCommand = new AsyncRelayCommand(AddAirCastDeviceOnEmpty, CanAddAudioInput, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand RemoveAudioInputCommand => removeAudioInputCommand ?? (removeAudioInputCommand = new RelayCommand(RemoveAudioInput, CanUpdateAudioSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ClearDeviceCommand => clearDeviceCommand ?? (clearDeviceCommand = new RelayCommand(ClearDevice, CanUpdateAudioSourceSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IAudioInputDevice> SelectAudioDeviceCommand => selectAudioDeviceCommand ?? (selectAudioDeviceCommand = new RelayCommand<IAudioInputDevice>(SelectAudioDevice, (IAudioInputDevice? _) => CanUpdateAudioSourceSettings()));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> SelectVideoDeviceCommand => selectVideoDeviceCommand ?? (selectVideoDeviceCommand = new AsyncRelayCommand<SelectVideoDeviceCommandParameter>(SelectVideoDevice, CanSelectVideoDevice, AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IAudioInputDevice?> AddAudioDeviceCommand => addAudioDeviceCommand ?? (addAudioDeviceCommand = new RelayCommand<IAudioInputDevice>(AddAudioDevice, (IAudioInputDevice? _) => CanAddAudioInput()));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IAsyncRelayCommand<SelectVideoDeviceCommandParameter?> AddVideoDeviceCommand => addVideoDeviceCommand ?? (addVideoDeviceCommand = new AsyncRelayCommand<SelectVideoDeviceCommandParameter>(AddVideoDevice, (SelectVideoDeviceCommandParameter? _) => CanAddAudioInput(), AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand ToggleAudioInputAudioMonitoringCommand => toggleAudioInputAudioMonitoringCommand ?? (toggleAudioInputAudioMonitoringCommand = new RelayCommand(ToggleAudioInputAudioMonitoring, CanToggleAudioInputAudioMonitoring));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand EnableAllChannelsCommand => enableAllChannelsCommand ?? (enableAllChannelsCommand = new RelayCommand(EnableAllChannels, CanUpdateAudioSourceSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand DisableAllChannelsCommand => disableAllChannelsCommand ?? (disableAllChannelsCommand = new RelayCommand(DisableAllChannels, CanUpdateAudioSourceSettings));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GotFocusCommand => gotFocusCommand ?? (gotFocusCommand = new RelayCommand(GotFocus));

	public event Action<UndoStack>? StackChanged;

	public AudioInputsSettingsVM(IInputsSettingsService service, ICoreManager coreManager, IVideoInputItemVMFactory factory, IAirCastConfiguration airCastConfiguration, IAirCastPluginDownload airCastPluginDownload)
	{
		_service = service;
		_coreManager = coreManager;
		_airCastConfiguration = airCastConfiguration;
		_airCastPluginDownload = airCastPluginDownload;
		_service.AvailableAudioInputs.CollectionChanged += AvailableAudioInputs_CollectionChanged;
		_videoInputs = new PairedCollection<LiveVideoInput, IVideoInputItemVM>(_service.AvailableLiveVideoInputs, factory.Create);
		_videoInputs.CollectionChanged += VideoInputs_CollectionChanged;
		SelectedAudioInput = AudioInputs.FirstOrDefault();
		LinkProperties("BehaviorMode", "BehaviorMode");
		AddPropertyLinks();
	}

	[RelayCommand]
	private void RefreshAudioInputSource()
	{
		_coreManager.RefreshAudioInputDevices();
	}

	[RelayCommand(CanExecute = "CanAddAudioInput")]
	private void AddAudioInput()
	{
		SelectedAudioInput = _service.AddAudioInput();
	}

	private bool CanAddAudioInput()
	{
		return _service.CanAddAudioInput();
	}

	[RelayCommand(CanExecute = "CanAddAirCastDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task AddAirCastDevice(AudioSource? source)
	{
		if (!(await _airCastPluginDownload.CheckAvailabilityAsync()))
		{
			return;
		}
		IAirCastVideoInputDevice orAddAirCastVideoInputDevice = _service.VideoInputDeviceCollection.GetOrAddAirCastVideoInputDevice();
		AudioInput audioInput = null;
		AudioSource audioSource = source;
		if (audioSource == null)
		{
			audioInput = _service.AddAudioInput();
			audioSource = audioInput.Source;
		}
		if (audioSource != null)
		{
			audioSource.VideoDevice = orAddAirCastVideoInputDevice;
			if (audioInput != null)
			{
				SelectedAudioInput = audioInput;
			}
		}
	}

	[RelayCommand(CanExecute = "CanAddAudioInput", FlowExceptionsToTaskScheduler = true)]
	private async Task AddAirCastDeviceOnEmpty()
	{
		await AddAirCastDevice(null);
	}

	private bool CanAddAirCastDevice(AudioSource? source)
	{
		if (!_airCastConfiguration.Enabled)
		{
			if (source == null)
			{
				return CanAddAudioInput();
			}
			return true;
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSettings")]
	private void RemoveAudioInput()
	{
		ValidateSelectedAudioInput();
		AudioInput selectedAudioInput = AudioInputs.GetPrevious<AudioInput>(SelectedAudioInput) ?? AudioInputs.GetNext<AudioInput>(SelectedAudioInput);
		_service.RemoveAudioInput(SelectedAudioInput);
		SelectedAudioInput = selectedAudioInput;
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSourceSettings")]
	private void ClearDevice()
	{
		ValidateSelectedAudioSource();
		SelectedAudioSource.ClearDeviceSelection();
		StopMonitoringAudio();
	}

	private bool CanUpdateAudioSettings()
	{
		return SelectedAudioInput != null;
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSourceSettings")]
	private void SelectAudioDevice(IAudioInputDevice audioInputDevice)
	{
		ValidateSelectedAudioSource();
		SelectedAudioSource.AudioDevice = audioInputDevice;
		StopMonitoringAudio();
	}

	private bool CanUpdateAudioSourceSettings()
	{
		return SelectedAudioSource != null;
	}

	[RelayCommand(CanExecute = "CanSelectVideoDevice", FlowExceptionsToTaskScheduler = true)]
	private async Task SelectVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		bool flag = parameter?.VideoInputDevice == null;
		if (!flag)
		{
			flag = !(await parameter.CanSelectVideoDeviceAsync(_airCastPluginDownload));
		}
		if (!flag)
		{
			SelectedAudioSource.SelectVideoDevice(parameter.VideoInputDevice, parameter.VideoMode);
		}
	}

	private bool CanSelectVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		return SelectedAudioSource != null;
	}

	[RelayCommand(CanExecute = "CanAddAudioInput")]
	private void AddAudioDevice(IAudioInputDevice? audioInputDevice)
	{
		AudioInput audioInput = _service.AddAudioInput();
		if (audioInput != null)
		{
			audioInput.Source.AudioDevice = audioInputDevice;
		}
	}

	[RelayCommand(CanExecute = "CanAddAudioInput", FlowExceptionsToTaskScheduler = true)]
	private async Task AddVideoDevice(SelectVideoDeviceCommandParameter? parameter)
	{
		if (await parameter.CanSelectVideoDeviceAsync(_airCastPluginDownload))
		{
			AudioInput audioInput = _service.AddAudioInput();
			if (audioInput != null && parameter?.VideoInputDevice != null)
			{
				audioInput.Source.SelectVideoDevice(parameter.VideoInputDevice, parameter.VideoMode ?? parameter.VideoInputDevice?.CurrentMode);
				SelectedAudioInput = audioInput;
			}
		}
	}

	private void NotifyCanAddAirCastAudioInput()
	{
		AddAirCastDeviceCommand.NotifyCanExecuteChanged();
		OnPropertyChanged("CanConfigureAirCast");
	}

	private bool CanToggleAudioInputAudioMonitoring()
	{
		return SelectedAudioInput?.Source.HasDevice ?? false;
	}

	[RelayCommand(CanExecute = "CanToggleAudioInputAudioMonitoring")]
	private void ToggleAudioInputAudioMonitoring()
	{
		ValidateSelectedAudioInput();
		ToggleAudioInputAudioMonitoring(SelectedAudioInput);
	}

	private void ToggleAudioInputAudioMonitoring(AudioInput input)
	{
		input.Source.IsMonitoring = !input.Source.IsMonitoring;
		int index = AudioInputs.IndexOf(input);
		if (input.Source.IsMonitoring)
		{
			_coreManager.StartMonitoringAudioInput(index);
		}
		else
		{
			_coreManager.StopMonitoringAudioInput(index);
		}
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSourceSettings")]
	private void EnableAllChannels()
	{
		SetMuteAllValue(mute: false);
	}

	[RelayCommand(CanExecute = "CanUpdateAudioSourceSettings")]
	private void DisableAllChannels()
	{
		SetMuteAllValue(mute: true);
	}

	[RelayCommand]
	private void GotFocus()
	{
		this.StackChanged?.Invoke(_service.AvailableAudioInputs.UndoStack);
	}

	private void AvailableAudioInputs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		AddAudioInputCommand.NotifyCanExecuteChanged();
		AddVideoDeviceCommand.NotifyCanExecuteChanged();
		AddAudioDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceOnEmptyCommand.NotifyCanExecuteChanged();
		AudioInput audioInput = e.NewItems?.OfType<AudioInput>().FirstOrDefault();
		if (audioInput != null)
		{
			SelectedAudioInput = audioInput;
		}
	}

	private void VideoInputs_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateVideoInputsAudioInput(SelectedAudioInput);
	}

	private void UpdateVideoInputsAudioInput(AudioInput? newValue)
	{
		foreach (IVideoInputItemVM videoInput in _videoInputs)
		{
			videoInput.AudioInput = newValue;
		}
	}

	private void AudioSource_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "HasDevice")
		{
			ToggleAudioInputAudioMonitoringCommand.NotifyCanExecuteChanged();
		}
		else if (e.PropertyName == "VideoDevice")
		{
			NotifyCanAddAirCastAudioInput();
		}
	}

	private void StopMonitoringAudio()
	{
		AudioInputs.Where((AudioInput d) => d.Source.IsMonitoring).ForEach(ToggleAudioInputAudioMonitoring);
	}

	private void SetMuteAllValue(bool mute)
	{
		SelectedAudioSource?.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
		{
			c.MuteActive = mute;
		});
	}

	[MemberNotNull("SelectedAudioInput")]
	private void ValidateSelectedAudioInput()
	{
		if (SelectedAudioInput == null)
		{
			throw new InvalidOperationException("SelectedAudioInput must not be null");
		}
	}

	[MemberNotNull("SelectedAudioSource")]
	private void ValidateSelectedAudioSource()
	{
		if (SelectedAudioSource == null)
		{
			throw new InvalidOperationException("SelectedAudioSource must not be null");
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnIsActiveChanged(bool value)
	{
		if (value)
		{
			RefreshAudioInputSource();
		}
		else
		{
			StopMonitoringAudio();
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedAudioInputChanged(AudioInput? oldValue, AudioInput? newValue)
	{
		if (oldValue != null)
		{
			oldValue.PropertyChanged -= base.RaiseLinkedValues;
			oldValue.Source.PropertyChanged -= AudioSource_PropertyChanged;
		}
		if (newValue != null)
		{
			newValue.PropertyChanged += base.RaiseLinkedValues;
			newValue.Source.PropertyChanged += AudioSource_PropertyChanged;
		}
		StopMonitoringAudio();
		RemoveAudioInputCommand.NotifyCanExecuteChanged();
		SelectAudioDeviceCommand.NotifyCanExecuteChanged();
		ClearDeviceCommand.NotifyCanExecuteChanged();
		EnableAllChannelsCommand.NotifyCanExecuteChanged();
		DisableAllChannelsCommand.NotifyCanExecuteChanged();
		ToggleAudioInputAudioMonitoringCommand.NotifyCanExecuteChanged();
		SelectVideoDeviceCommand.NotifyCanExecuteChanged();
		AddAirCastDeviceCommand.NotifyCanExecuteChanged();
		UpdateVideoInputsAudioInput(newValue);
		OnPropertyChanged("AudioInputAudioDelay");
		OnPropertyChanged("BehaviorMode");
		NotifyCanAddAirCastAudioInput();
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
			NotifyCanAddAirCastAudioInput();
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
