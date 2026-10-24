using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

public class AudioDestination : NotifyPropertyChangedBase, IAudioDestination, INotifyPropertyChanged
{
	private string _name = string.Empty;

	private string _renderID = string.Empty;

	private bool _isConnected;

	private IAudioOutputDevice? _audioDevice;

	private readonly IAudioMapRecallService<Bus, DeviceChannel> _audioMapRecallService;

	public string Name
	{
		get
		{
			return _name;
		}
		private set
		{
			SetValue("Name", ref _name, value);
		}
	}

	public string RenderID
	{
		get
		{
			return _renderID;
		}
		private set
		{
			SetValue("RenderID", ref _renderID, value);
		}
	}

	public IAudioOutputDevice? AudioDevice
	{
		get
		{
			return _audioDevice;
		}
		set
		{
			SetValue<IAudioOutputDevice>("AudioDevice", ref _audioDevice, value, delegate(IAudioOutputDevice o, IAudioOutputDevice n)
			{
				OnAudioDeviceChanged(o, n, skipChannelCountAndMappingUpdate: false);
			});
		}
	}

	public int ChannelCount => Routing.ChannelCount;

	public IAudioRouting<Bus, DeviceChannel> Routing { get; }

	public IEnumerable<IAudioChannelLevel>? DeviceChannelLevels => null;

	public bool IsConnected
	{
		get
		{
			return _isConnected;
		}
		set
		{
			SetValue("IsConnected", ref _isConnected, value);
		}
	}

	public event System.Action? DataModified;

	public static ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> Create(IUiScheduler uiScheduler, IEntityFactory entityFactory, IAudioOutputDeviceCollection? systemOutputDevices, IAudioDestination? left, IDigitalAudio.Types.IDevice? right)
	{
		ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder = new ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice>(left, right);
		objectBinder.Bind((IAudioDestination l) => l.WhenPropertyChanges("RenderID").Merge(l.WhenPropertyChanges("Name")), (IDigitalAudio.Types.IDevice r) => r.RenderId.WhenValueChanges.ToUnit().Merge(r.Name.WhenValueChanges.ToUnit()), delegate(IAudioDestination l, IDigitalAudio.Types.IDevice r)
		{
			r.RenderId.Set(l.RenderID);
			r.Name.Set(l.Name);
		}, delegate(IDigitalAudio.Types.IDevice r, IAudioDestination l)
		{
			l.AudioDevice = systemOutputDevices?.FirstOrDefault((IAudioOutputDevice d) => d.UUID == r.RenderId.Value);
		}, null, uiScheduler.Scheduler).Bind((IAudioDestination l) => l.WhenPropertyChanges("Routing"), (IDigitalAudio.Types.IDevice r) => r.Routing.WhenValueChanges, delegate(IAudioDestination l, IDigitalAudio.Types.IDevice r)
		{
			IDigitalAudio.Types.IDevice.Types.IRouting routing = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IRouting>();
			r.Routing.Set(routing);
			ObjectBinder<IAudioRouting<Bus, DeviceChannel>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder2 = l.Routing.Bind(uiScheduler, entityFactory, routing);
			objectBinder2.InitializeRightFromLeft();
			routing.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IDigitalAudio.Types.IDevice r, IAudioDestination l)
		{
			ObjectBinder<IAudioRouting<Bus, DeviceChannel>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder3 = l.Routing.Bind(uiScheduler, entityFactory, r.Routing.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Routing.Value.RegisterLinkedDisposable(objectBinder3);
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	public AudioDestination(ChannelSet<Bus> buses, IAudioMapRecallService<Bus, DeviceChannel> audioMapRecallService)
	{
		Routing = new AudioRouting<Bus, DeviceChannel>(inputToOutput: false, (ChannelSet<DeviceChannel> channelSet) => new AudioMap<Bus, DeviceChannel>(buses, channelSet));
		Routing.DataModified += OnDataModified;
		_audioMapRecallService = audioMapRecallService;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void UpdateChannelCount(int channelCount)
	{
		if (ChannelCount != channelCount)
		{
			Routing.ChannelSet.Resize(channelCount);
			OnDataModified();
		}
	}

	private void OnAudioDeviceChannelCountChanged()
	{
		if (AudioDevice != null)
		{
			UpdateChannelCount(AudioDevice.ChannelCount);
		}
	}

	private void UpdateIdentifiers(IDevice? device)
	{
		if (device == null)
		{
			IsConnected = false;
			return;
		}
		IsConnected = true;
		Name = device.Name;
		RenderID = device.UUID;
	}

	private void OnAudioDeviceChanged(IAudioDevice? oldDevice, IAudioDevice? newDevice, bool skipChannelCountAndMappingUpdate)
	{
		Routing.ChannelMap.MapInvalidated -= ChannelMap_MapInvalidated;
		if (oldDevice != null)
		{
			oldDevice.ChannelCountChanged -= OnAudioDeviceChannelCountChanged;
		}
		if (newDevice != null)
		{
			newDevice.ChannelCountChanged += OnAudioDeviceChannelCountChanged;
		}
		UpdateIdentifiers(newDevice);
		if (newDevice != null && !skipChannelCountAndMappingUpdate)
		{
			UpdateChannelCount(newDevice.ChannelCount);
			_audioMapRecallService?.RecallAudioMap(newDevice, Routing.ChannelMap);
		}
		OnPropertyChanged("DeviceChannelLevels");
		OnDataModified();
		Routing.ChannelMap.MapInvalidated += ChannelMap_MapInvalidated;
	}

	private void ChannelMap_MapInvalidated()
	{
		if (AudioDevice != null)
		{
			_audioMapRecallService?.AddOrUpdateAudioMap(AudioDevice, Routing.ChannelMap);
		}
	}

	public DigitalAudio.Types.Device Serialize()
	{
		return new DigitalAudio.Types.Device
		{
			Name = (Name ?? string.Empty),
			RenderID = (RenderID ?? string.Empty),
			Routing = Routing.Serialize()
		};
	}

	public void Deserialize(DigitalAudio.Types.Device? protoAudioDevice, Func<DigitalAudio.Types.Device, IAudioOutputDevice?>? findDevice = null)
	{
		if (protoAudioDevice == null)
		{
			Name = string.Empty;
			RenderID = string.Empty;
			Routing.Deserialize(null);
			return;
		}
		Name = protoAudioDevice.Name;
		RenderID = protoAudioDevice.RenderID;
		Routing.Deserialize(protoAudioDevice.Routing);
		if (findDevice != null)
		{
			IAudioOutputDevice audioDevice = _audioDevice;
			OnAudioDeviceChanged(audioDevice, _audioDevice = findDevice(protoAudioDevice), skipChannelCountAndMappingUpdate: true);
		}
	}
}
