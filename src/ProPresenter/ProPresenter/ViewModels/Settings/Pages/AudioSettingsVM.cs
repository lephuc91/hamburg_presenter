using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.HTTP;
using Pro.Common.Time;
using Pro.DO.Audio;
using Pro.Localization.Services;
using Pro.UI.Components;
using Pro.UI.Themes;
using Pro.ssAPI.Devices;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Web;
using ProPresenter.UI.ViewModels.Navigation;
using ProPresenter.UI.ViewModels.Settings;
using ProPresenter.UI.ViewModels.Settings.Pages;
using ProPresenter.UI.ViewModels.Settings.Search;
using ProPresenter.ViewModels.Settings.Search;

namespace ProPresenter.ViewModels.Settings.Pages;

public class AudioSettingsVM : LinkedNotifyPropertyChangedBase, IAudioSettingsVM, ISettingsItemVM, ISettingsListItem, INotifyPropertyChanged, ISettingsSearchPage, INavigationItem
{
	private readonly IOutputConfiguration _outputConfiguration;

	private readonly ILocalization _localization;

	private readonly IHyperlinkService _hyperlinkService;

	private readonly IWebSourceProvider _webSourceProvider;

	public Guid ID { get; } = Guid.NewGuid();

	public IEnumerable<ISettingsSearchPageField> Fields { get; }

	public ISettingsSearchPageField PageField { get; }

	public IEnumerable<ISettingsSearchPage> SubPages { get; } = Enumerable.Empty<ISettingsSearchPage>();

	public string Name { get; }

	public int BusCount
	{
		get
		{
			return Settings.BusCount;
		}
		set
		{
			Settings.BusCount = value;
		}
	}

	public bool MonitorOnMains
	{
		get
		{
			return Settings.MonitorOnMains;
		}
		private set
		{
			Settings.MonitorOnMains = value;
		}
	}

	public bool DisableMainOutputDevice
	{
		get
		{
			return Settings.DisableMainOutputDevice;
		}
		private set
		{
			Settings.DisableMainOutputDevice = value;
		}
	}

	public IAudioOutputDeviceCollection AudioOutputDevices { get; }

	public string MonitorDestinationDisplayName
	{
		get
		{
			if (!MonitorOnMains)
			{
				return MonitorDestination.Name;
			}
			return _localization.Get("SETTINGS_AUDIO_LISTEN_ON_MAIN_title");
		}
	}

	public IEnumerable<IAudioOutputDevice> ASIODevices => AudioOutputDevices.Where((IAudioOutputDevice d) => d.DeviceType == AudioDeviceType.ASIO);

	public IEnumerable<IAudioOutputDevice> WaveOutDevices => AudioOutputDevices.Where((IAudioOutputDevice d) => d.DeviceType == AudioDeviceType.WaveOut);

	public IAudioDestination MonitorDestination => Settings.MonitorOutputDestination;

	public IAudioDestination MainDestination => Settings.MainOutputDestination;

	public IAudioDestination SdiNdiDestination => Settings.SdiNdiOutputDestination;

	public TimeSlice MainDelay
	{
		get
		{
			return Settings.MainDelay;
		}
		set
		{
			Settings.MainDelay = value;
		}
	}

	public TimeSlice SDINDIDelay
	{
		get
		{
			return Settings.SdiNdiDelay;
		}
		set
		{
			Settings.SdiNdiDelay = value;
		}
	}

	public bool SDINDIEnabled
	{
		get
		{
			return Settings.SdiNdiOutputActive;
		}
		set
		{
			Settings.SdiNdiOutputActive = value;
		}
	}

	public ICommand<IAudioOutputDevice?> SelectInspectorDeviceCommand => new RelayCommand<IAudioOutputDevice>(SelectInspectorDeviceCommandExecuted);

	public ICommand SelectMonitorOnMainsCommand => new RelayCommand(SelectMonitorOnMainsCommandExecuted);

	public ICommand<IAudioOutputDevice?> SelectMainDeviceCommand => new RelayCommand<IAudioOutputDevice>(SelectMainDeviceCommandExecuted);

	public ICommand SelectNoMainDeviceCommand => new RelayCommand(SelectNoMainDeviceCommandExecuted);

	public ICommand ClearAllTestTones => new RelayCommand(ClearAllTestTonesCommandExecuted);

	public ISettingsItemVM? Parent => null;

	public ICommand HelpCommand => new RelayCommand(delegate
	{
		_hyperlinkService.Open(_webSourceProvider.GenerateLink(ResourceType.HelpAudioOutputs));
	});

	private IAudioSetup Settings => _outputConfiguration.DigitalAudioSettings;

	public Brush Background => SettingsListItemConstants.Orange;

	public ImageSource? Icon => Icons.GetIcon(Icons.SettingsAudio);

	public bool IsNavigable => true;

	public bool CanExit => true;

	public AudioSettingsVM(IOutputConfiguration outputConfiguration, ILocalization localization, IHyperlinkService hyperlinkService, IWebSourceProvider webSourceProvider, ISettingsSearchFactory settingsSearchFactory, IAudioOutputDeviceCollection audioOutputDevices)
	{
		_outputConfiguration = outputConfiguration;
		_localization = localization;
		_hyperlinkService = hyperlinkService;
		_webSourceProvider = webSourceProvider;
		AudioOutputDevices = audioOutputDevices;
		LinkProperties("BusCount", "BusCount");
		LinkProperties("MonitorOnMains", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "MonitorOnMains", "MonitorDestinationDisplayName" }));
		LinkProperties("SdiNdiOutputActive", "SDINDIEnabled");
		LinkProperties("Name", "MonitorDestinationDisplayName");
		LinkProperties("DisableMainOutputDevice", "DisableMainOutputDevice");
		LinkProperties("MainDelay", "MainDelay");
		LinkProperties("SdiNdiDelay", "SDINDIDelay");
		Name = _localization.Get("SETTINGS_AUDIO_PAGE_title");
		MonitorDestination.PropertyChanged += base.RaiseLinkedValues;
		Settings.PropertyChanged += base.RaiseLinkedValues;
		AudioOutputDevices.CollectionChanged += delegate
		{
			OnPropertyChanged("ASIODevices");
			OnPropertyChanged("WaveOutDevices");
		};
		PageField = settingsSearchFactory.CreatePageField(Name, this);
		Fields = settingsSearchFactory.GetFields("SETTINGS_AUDIO_PAGE_title", this, isComponent: false, PageField).Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_CHANNEL_COUNT_title", this, isComponent: true)).Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_INSPECTOR_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_INSPECTOR_DEVICE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_INSPECTOR_LEVEL_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_MAIN_SECTION_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_MAIN_DEVICE_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_ROUTING_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_MAIN_DELAY_title", this, isComponent: true))
			.Concat(settingsSearchFactory.GetFields("SETTINGS_AUDIO_SDI_NDI_SECTION_title", this, isComponent: true));
	}

	private void SelectInspectorDeviceCommandExecuted(IAudioOutputDevice? device)
	{
		MonitorDestination.AudioDevice = device;
		MonitorOnMains = device == null;
	}

	private void SelectMonitorOnMainsCommandExecuted()
	{
		MonitorOnMains = true;
		MonitorDestination.AudioDevice = null;
	}

	private void SelectMainDeviceCommandExecuted(IAudioOutputDevice? device)
	{
		DisableMainOutputDevice = device == null;
		MainDestination.AudioDevice = device;
	}

	private void SelectNoMainDeviceCommandExecuted()
	{
		DisableMainOutputDevice = true;
		MainDestination.AudioDevice = AudioOutputDevices.FirstOrDefault();
	}

	private void ClearAllTestTonesCommandExecuted()
	{
		MainDestination?.Routing.ChannelMap?.InputSet.Where((Bus bus) => bus.TestActive).ForEach(delegate(Bus b)
		{
			b.TestActive = false;
		});
		MonitorDestination?.Routing.ChannelMap?.InputSet.Where((Bus bus) => bus.TestActive).ForEach(delegate(Bus b)
		{
			b.TestActive = false;
		});
		SdiNdiDestination?.Routing.ChannelMap?.InputSet.Where((Bus bus) => bus.TestActive).ForEach(delegate(Bus b)
		{
			b.TestActive = false;
		});
		MainDestination?.Routing.ChannelMap?.OutputSet.Where((DeviceChannel dc) => dc.TestActive).ForEach(delegate(DeviceChannel dc)
		{
			dc.TestActive = false;
		});
		MonitorDestination?.Routing.ChannelMap?.OutputSet.Where((DeviceChannel dc) => dc.TestActive).ForEach(delegate(DeviceChannel dc)
		{
			dc.TestActive = false;
		});
		SdiNdiDestination?.Routing.ChannelMap?.OutputSet.Where((DeviceChannel dc) => dc.TestActive).ForEach(delegate(DeviceChannel dc)
		{
			dc.TestActive = false;
		});
	}

	public void PromptUnableToExit()
	{
	}
}
