using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "Routing" })]
public class AudioSource : NotifyPropertyChangedBase, IDisposable
{
	public enum SourceDeviceType
	{
		None,
		Audio,
		Video
	}

	private SourceDeviceType _deviceType;

	private string _deviceName = string.Empty;

	private string _deviceRenderID = string.Empty;

	private IAudioInputDevice? _audioDevice;

	private IVideoInputDevice? _videoDevice;

	private Media.Types.VideoDevice.Types.AirCast? _protoAirCast;

	private int _videoDeviceModeIndex;

	private bool _isMonitoring;

	private readonly IAudioMapRecallService<DeviceChannel, Bus> _audioMapRecallService;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public SourceDeviceType DeviceType
	{
		get
		{
			return _deviceType;
		}
		private set
		{
			SetValue("DeviceType", ref _deviceType, value, (System.Action)delegate
			{
				OnPropertyChanged("HasDevice");
				OnPropertyChanged("HasAudioDevice");
				OnPropertyChanged("HasVideoDevice");
				OnPropertyChanged("IsDeviceConnected");
			}, (Predicate<SourceDeviceType>?)null, referenceComparison: false);
		}
	}

	public string DeviceName
	{
		get
		{
			return _deviceName;
		}
		private set
		{
			SetValue("DeviceName", ref _deviceName, value);
		}
	}

	public string DeviceRenderID
	{
		get
		{
			return _deviceRenderID;
		}
		private set
		{
			SetValue("DeviceRenderID", ref _deviceRenderID, value);
		}
	}

	public bool IsDeviceConnected
	{
		get
		{
			if (!HasAudioDevice || AudioDevice == null)
			{
				if (HasVideoDevice)
				{
					return VideoDevice != null;
				}
				return false;
			}
			return true;
		}
	}

	public bool HasDevice => DeviceType != SourceDeviceType.None;

	public bool HasAudioDevice => DeviceType == SourceDeviceType.Audio;

	public bool HasVideoDevice => DeviceType == SourceDeviceType.Video;

	public IAudioInputDevice? AudioDevice
	{
		get
		{
			return _audioDevice;
		}
		set
		{
			if (value != null)
			{
				VideoDevice = null;
			}
			SetValue<IAudioInputDevice>("AudioDevice", ref _audioDevice, value, delegate(IAudioInputDevice o, IAudioInputDevice n)
			{
				OnAudioDeviceChanged(o, n);
			});
		}
	}

	public IVideoInputDevice? VideoDevice
	{
		get
		{
			return _videoDevice;
		}
		set
		{
			if (value != null)
			{
				AudioDevice = null;
			}
			SetValue<IVideoInputDevice>("VideoDevice", ref _videoDevice, value, delegate(IVideoInputDevice o, IVideoInputDevice n)
			{
				OnVideoDeviceChanged(o, n);
			});
		}
	}

	public int VideoDeviceModeIndex
	{
		get
		{
			return _videoDeviceModeIndex;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException($"Unable to set {"VideoDeviceModeIndex"} with value {value}");
			}
			if (!HasVideoDevice && value > 0)
			{
				throw new InvalidOperationException();
			}
			SetValue("VideoDeviceModeIndex", ref _videoDeviceModeIndex, value, OnDataModified);
		}
	}

	public int ChannelCount => Routing.ChannelCount;

	public AudioRouting<DeviceChannel, Bus> Routing { get; }

	public bool IsMonitoring
	{
		get
		{
			return _isMonitoring;
		}
		set
		{
			SetValue("IsMonitoring", ref _isMonitoring, value);
		}
	}

	public IEnumerable<IAudioChannelLevel>? DeviceChannelLevels
	{
		get
		{
			if (HasVideoDevice)
			{
				if (!HasAudioDevice)
				{
					return VideoDevice?.ChannelLevels;
				}
				return AudioDevice?.ChannelLevels;
			}
			if (!HasAudioDevice)
			{
				return null;
			}
			return AudioDevice?.ChannelLevels;
		}
	}

	public event System.Action? DataModified;

	public IReadOnlyObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IDigitalAudio.Types.IDevice audioDevice, Func<IDigitalAudio.Types.IDevice, IAudioInputDevice?> findDevice)
	{
		ObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> objectBinder = new ObjectBinder<AudioSource, IDigitalAudio.Types.IDevice>(this, audioDevice);
		objectBinder.Bind((AudioSource l) => l.WhenPropertyChanges("DeviceName"), (IDigitalAudio.Types.IDevice r) => r.Name.WhenValueChanges, delegate(AudioSource l, IDigitalAudio.Types.IDevice r)
		{
			r.Name.Set(l.DeviceName);
		}, delegate(IDigitalAudio.Types.IDevice r, AudioSource l)
		{
			l.DeviceName = r.Name.Value;
		}).Bind((AudioSource l) => l.WhenPropertyChanges("DeviceRenderID"), (IDigitalAudio.Types.IDevice r) => r.RenderId.WhenValueChanges, delegate(AudioSource l, IDigitalAudio.Types.IDevice r)
		{
			r.RenderId.Set(l.DeviceRenderID);
		}, delegate(IDigitalAudio.Types.IDevice r, AudioSource l)
		{
			IVideoInputDevice videoDevice = _videoDevice;
			_videoDevice = null;
			OnPropertyChanged("VideoDevice");
			OnVideoDeviceChanged(videoDevice, null, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
			l.DeviceRenderID = r.RenderId.Value;
			IAudioInputDevice audioDevice2 = _audioDevice;
			IAudioInputDevice audioInputDevice = findDevice(r);
			_audioDevice = audioInputDevice;
			_videoDevice = null;
			if (_audioDevice != null)
			{
				_audioMapRecallService.AddOrUpdateAudioMap(_audioDevice, Routing.ChannelMap);
			}
			OnAudioDeviceChanged(audioDevice2, audioInputDevice, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
			OnPropertyChanged("AudioDevice");
			OnPropertyChanged("IsDeviceConnected");
		}).Bind((AudioSource l) => l.WhenPropertyChanges("Routing"), (IDigitalAudio.Types.IDevice r) => r.Routing.WhenValueChanges, delegate(AudioSource l, IDigitalAudio.Types.IDevice r)
		{
			IDigitalAudio.Types.IDevice.Types.IRouting routing = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IRouting>();
			ObjectBinder<IAudioRouting<DeviceChannel, Bus>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder2 = Routing.Bind(scheduler, entityFactory, routing);
			objectBinder2.InitializeRightFromLeft();
			r.Routing.Set(routing);
			r.RegisterLinkedDisposable(objectBinder2);
		}, delegate(IDigitalAudio.Types.IDevice r, AudioSource l)
		{
			ObjectBinder<IAudioRouting<DeviceChannel, Bus>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder3 = l.Routing.Bind(scheduler, entityFactory, r.Routing.Value);
			objectBinder3.InitializeLeftFromRight();
			r.RegisterLinkedDisposable(objectBinder3);
		})
			.DoOnInitializeLeftFromRight(delegate
			{
				DeviceType = SourceDeviceType.Audio;
				VideoDeviceModeIndex = 0;
			});
		return objectBinder;
	}

	public IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IMedia.Types.IVideoDevice videoDevice, Func<IMedia.Types.IVideoDevice, IVideoInputDevice?> findDevice)
	{
		ObjectBinder<AudioSource, IMedia.Types.IVideoDevice> objectBinder = new ObjectBinder<AudioSource, IMedia.Types.IVideoDevice>(this, videoDevice);
		objectBinder.Bind((AudioSource l) => l.WhenPropertyChanges("DeviceName"), (IMedia.Types.IVideoDevice r) => r.Name.WhenValueChanges, delegate(AudioSource l, IMedia.Types.IVideoDevice r)
		{
			r.Name.Set(l.DeviceName);
		}, delegate(IMedia.Types.IVideoDevice r, AudioSource l)
		{
			l.DeviceName = r.Name.Value;
		}).Bind((AudioSource l) => l.WhenPropertyChanges("DeviceRenderID"), (IMedia.Types.IVideoDevice r) => r.UniqueId.WhenValueChanges, delegate(AudioSource l, IMedia.Types.IVideoDevice r)
		{
			r.UniqueId.Set(l.DeviceRenderID);
		}, delegate(IMedia.Types.IVideoDevice r, AudioSource l)
		{
			IAudioInputDevice audioDevice = _audioDevice;
			_audioDevice = null;
			OnPropertyChanged("AudioDevice");
			OnAudioDeviceChanged(audioDevice, null, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
			l.DeviceRenderID = r.UniqueId.Value;
			IVideoInputDevice videoDevice2 = _videoDevice;
			IVideoInputDevice videoInputDevice = findDevice(r);
			if (videoInputDevice != null && videoInputDevice.SupportsAudio)
			{
				_videoDevice = videoInputDevice;
				_protoAirCast = ((videoDevice.Aircast.Value != null) ? new Media.Types.VideoDevice.Types.AirCast
				{
					ServiceName = (videoDevice.Aircast.Value.ServiceName.Value ?? string.Empty),
					Password = (videoDevice.Aircast.Value.Password.Value ?? string.Empty),
					PasswordEnabled = (videoDevice.Aircast.Value.PasswordEnabled.Value == true)
				} : null);
				_audioMapRecallService.AddOrUpdateAudioMap(_videoDevice, Routing.ChannelMap);
				if (_videoDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
				{
					airCastVideoInputDevice.ServiceName = videoDevice.Aircast.Value?.ServiceName.Value ?? string.Empty;
					airCastVideoInputDevice.Password = videoDevice.Aircast.Value?.Password.Value ?? string.Empty;
					airCastVideoInputDevice.PasswordEnabled = videoDevice.Aircast.Value?.PasswordEnabled.Value == true;
				}
				OnVideoDeviceChanged(videoDevice2, videoInputDevice, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
				OnPropertyChanged("VideoDevice");
				OnPropertyChanged("IsDeviceConnected");
			}
			else
			{
				_videoDevice = null;
				OnVideoDeviceChanged(videoDevice2, null, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
			}
		}).Bind((AudioSource l) => l.WhenPropertyChanges("VideoDeviceModeIndex"), (IMedia.Types.IVideoDevice r) => r.FormatIndex.WhenValueChanges, delegate(AudioSource l, IMedia.Types.IVideoDevice r)
		{
			r.FormatIndex.Set((uint)l.VideoDeviceModeIndex);
		}, delegate(IMedia.Types.IVideoDevice r, AudioSource l)
		{
			l.VideoDeviceModeIndex = (int)r.FormatIndex.Value;
		})
			.Bind((AudioSource l) => l.WhenPropertyChanges("VideoDevice").ToUnit().StartWith(Unit.Default)
				.Select((Func<Unit, IObservable<Unit>>)delegate
				{
					IVideoInputDevice videoDevice3 = l.VideoDevice;
					IAirCastVideoInputDevice airCastDevice = videoDevice3 as IAirCastVideoInputDevice;
					return (airCastDevice == null) ? Observable.Return(Unit.Default) : Observable.FromEvent(delegate(System.Action h)
					{
						airCastDevice.DataModified += h;
					}, delegate(System.Action h)
					{
						airCastDevice.DataModified -= h;
					}).ToUnit().StartWith(Unit.Default);
				})
				.Switch(), (IMedia.Types.IVideoDevice r) => r.Type.WhenValueChanges.ToUnit().Merge(r.Aircast.WhenAnyValueChanges.ToUnit()), delegate(AudioSource l, IMedia.Types.IVideoDevice r)
			{
				if (l.VideoDevice is IAirCastVideoInputDevice airCastVideoInputDevice2)
				{
					r.Type.Set(IMedia.Types.IVideoDevice.Types.Type.Aircast);
					IMedia.Types.IVideoDevice.Types.IAirCast airCast = entityFactory.Create<IMedia.Types.IVideoDevice.Types.IAirCast>();
					airCast.ServiceName.Set(airCastVideoInputDevice2.ServiceName ?? string.Empty);
					airCast.Password.Set(airCastVideoInputDevice2.Password ?? string.Empty);
					airCast.PasswordEnabled.Set(airCastVideoInputDevice2.PasswordEnabled);
					r.Aircast.Set(airCast);
				}
				else
				{
					r.Type.Set(IMedia.Types.IVideoDevice.Types.Type.Generic);
					r.Aircast.Set(null);
				}
			}, delegate(IMedia.Types.IVideoDevice r, AudioSource l)
			{
				if (r.Aircast.Value != null)
				{
					l._protoAirCast = new Media.Types.VideoDevice.Types.AirCast
					{
						ServiceName = (r.Aircast.Value.ServiceName.Value ?? string.Empty),
						Password = (r.Aircast.Value.Password.Value ?? string.Empty),
						PasswordEnabled = (r.Aircast.Value.PasswordEnabled.Value == true)
					};
					if (l.VideoDevice is IAirCastVideoInputDevice airCastVideoInputDevice3)
					{
						airCastVideoInputDevice3.ServiceName = r.Aircast.Value.ServiceName.Value ?? string.Empty;
						airCastVideoInputDevice3.Password = r.Aircast.Value.Password.Value ?? string.Empty;
						airCastVideoInputDevice3.PasswordEnabled = r.Aircast.Value.PasswordEnabled.Value == true;
					}
				}
				else
				{
					l._protoAirCast = null;
				}
			})
			.Bind((AudioSource l) => l.WhenPropertyChanges("Routing"), (IMedia.Types.IVideoDevice r) => r.AudioRouting.WhenValueChanges, delegate(AudioSource l, IMedia.Types.IVideoDevice r)
			{
				IDigitalAudio.Types.IDevice.Types.IRouting routing = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IRouting>();
				ObjectBinder<IAudioRouting<DeviceChannel, Bus>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder2 = Routing.Bind(scheduler, entityFactory, routing);
				objectBinder2.InitializeRightFromLeft();
				r.AudioRouting.Set(routing);
				r.RegisterLinkedDisposable(objectBinder2);
			}, delegate(IMedia.Types.IVideoDevice r, AudioSource l)
			{
				ObjectBinder<IAudioRouting<DeviceChannel, Bus>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder3 = l.Routing.Bind(scheduler, entityFactory, r.AudioRouting.Value);
				objectBinder3.InitializeLeftFromRight();
				r.RegisterLinkedDisposable(objectBinder3);
			})
			.DoOnInitializeLeftFromRight(delegate
			{
				DeviceType = SourceDeviceType.Video;
			});
		return objectBinder;
	}

	public AudioSource(ChannelSet<Bus> buses, IAudioMapRecallService<DeviceChannel, Bus> audioMapRecallService)
	{
		Routing = new AudioRouting<DeviceChannel, Bus>(inputToOutput: true, (ChannelSet<DeviceChannel> channelSet) => new AudioMap<DeviceChannel, Bus>(channelSet, buses));
		Routing.DataModified += OnDataModified;
		_audioMapRecallService = audioMapRecallService;
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void SelectVideoDevice(IVideoInputDevice? videoDevice, IVideoMode? videoMode)
	{
		VideoDevice = videoDevice;
		VideoDeviceModeIndex = videoMode?.ModeIndex ?? 0;
	}

	public void ClearDeviceSelection()
	{
		if (HasAudioDevice && AudioDevice != null)
		{
			AudioDevice = null;
		}
		else if (HasVideoDevice && VideoDevice != null)
		{
			VideoDevice = null;
		}
		else
		{
			UpdateIdentifiers(null, SourceDeviceType.None);
		}
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
		if (HasAudioDevice && AudioDevice != null)
		{
			UpdateChannelCount(AudioDevice.ChannelCount);
		}
	}

	private void UpdateIdentifiers(IDevice? device, SourceDeviceType deviceType)
	{
		DeviceType = ((device != null) ? deviceType : SourceDeviceType.None);
		DeviceName = device?.Name ?? string.Empty;
		DeviceRenderID = device?.UUID ?? string.Empty;
	}

	private void OnAudioDeviceChanged(IAudioDevice? oldDevice, IAudioDevice? newDevice, bool skipIdentifierUpdate = false, bool skipChannelCountAndMappingUpdate = false)
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
		if (!skipIdentifierUpdate)
		{
			UpdateIdentifiers(newDevice, SourceDeviceType.Audio);
		}
		if (newDevice != null && !skipChannelCountAndMappingUpdate)
		{
			UpdateChannelCount(newDevice.ChannelCount);
			_audioMapRecallService.RecallAudioMap(newDevice, Routing.ChannelMap);
		}
		OnPropertyChanged("DeviceChannelLevels");
		if (!skipIdentifierUpdate || !skipChannelCountAndMappingUpdate)
		{
			OnDataModified();
		}
		OnPropertyChanged("IsDeviceConnected");
		Routing.ChannelMap.MapInvalidated += ChannelMap_MapInvalidated;
	}

	private void ChannelMap_MapInvalidated()
	{
		IDevice device = null;
		IDevice audioDevice = AudioDevice;
		if (audioDevice != null)
		{
			device = audioDevice;
		}
		else
		{
			IDevice videoDevice = VideoDevice;
			if (videoDevice != null)
			{
				device = videoDevice;
			}
		}
		if (device != null)
		{
			_audioMapRecallService.AddOrUpdateAudioMap(device, Routing.ChannelMap);
		}
	}

	private void OnVideoDeviceChanged(IVideoInputDevice? oldDevice, IVideoInputDevice? newDevice, bool skipIdentifierUpdate = false, bool skipChannelCountAndMappingUpdate = false)
	{
		if (oldDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
		{
			airCastVideoInputDevice.DataModified -= OnDataModified;
		}
		if (newDevice is IAirCastVideoInputDevice airCastVideoInputDevice2)
		{
			airCastVideoInputDevice2.DataModified += OnDataModified;
		}
		Routing.ChannelMap.MapInvalidated -= ChannelMap_MapInvalidated;
		if (newDevice != null && !newDevice.SupportsAudio)
		{
			throw new InvalidOperationException("Newly selected device does not support audio.");
		}
		if (!skipIdentifierUpdate)
		{
			UpdateIdentifiers(newDevice, SourceDeviceType.Video);
			VideoDeviceModeIndex = (newDevice?.Modes?.FirstOrDefault()?.ModeIndex).GetValueOrDefault();
		}
		if (newDevice != null && !skipChannelCountAndMappingUpdate)
		{
			UpdateChannelCount(newDevice.AudioChannelCount);
			_audioMapRecallService.RecallAudioMap(newDevice, Routing.ChannelMap);
		}
		OnPropertyChanged("DeviceChannelLevels");
		if (!skipIdentifierUpdate || !skipChannelCountAndMappingUpdate)
		{
			OnDataModified();
		}
		Routing.ChannelMap.MapInvalidated += ChannelMap_MapInvalidated;
	}

	public void SynchronizeWithPhysicalDevice(IAudioInputDeviceCollection? audioDevices, IVideoInputDeviceCollection? videoDevices)
	{
		if (HasAudioDevice)
		{
			IAudioInputDevice audioDevice = _audioDevice;
			_audioDevice = audioDevices?.FindDevice(DeviceRenderID);
			OnPropertyChanged("AudioDevice");
			OnAudioDeviceChanged(audioDevice, _audioDevice, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
		}
		else if (HasVideoDevice)
		{
			IVideoInputDevice videoDevice = _videoDevice;
			IVideoInputDevice videoInputDevice = videoDevices?.FindDevice(DeviceRenderID);
			if (videoInputDevice == null && _protoAirCast != null)
			{
				videoInputDevice = videoDevices?.GetOrAddAirCastVideoInputDevice();
				if (videoInputDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
				{
					airCastVideoInputDevice.Deserialize(_protoAirCast, DeviceRenderID);
				}
				_protoAirCast = null;
			}
			if (videoInputDevice == null || videoInputDevice.SupportsAudio)
			{
				_videoDevice = videoInputDevice;
				OnPropertyChanged("VideoDevice");
				OnVideoDeviceChanged(videoDevice, _videoDevice, skipIdentifierUpdate: true, skipChannelCountAndMappingUpdate: true);
			}
			else
			{
				VideoDevice = null;
				DeviceType = SourceDeviceType.None;
				DeviceName = string.Empty;
				DeviceRenderID = string.Empty;
				VideoDeviceModeIndex = 0;
			}
		}
		OnPropertyChanged("IsDeviceConnected");
	}

	public DigitalAudio.Types.Device SerializeAsAudioDevice()
	{
		if (!HasAudioDevice)
		{
			throw new InvalidOperationException();
		}
		return new DigitalAudio.Types.Device
		{
			Name = (DeviceName ?? string.Empty),
			RenderID = (DeviceRenderID ?? string.Empty),
			Routing = Routing.Serialize()
		};
	}

	public Media.Types.VideoDevice SerializeAsVideoDevice()
	{
		if (!HasVideoDevice)
		{
			throw new InvalidOperationException();
		}
		Media.Types.VideoDevice videoDevice = new Media.Types.VideoDevice
		{
			Name = (DeviceName ?? string.Empty),
			UniqueId = (DeviceRenderID ?? string.Empty),
			FormatIndex = (uint)VideoDeviceModeIndex,
			AudioRouting = Routing.Serialize()
		};
		if (VideoDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
		{
			videoDevice.Type = Media.Types.VideoDevice.Types.Type.Aircast;
			videoDevice.Aircast = new Media.Types.VideoDevice.Types.AirCast
			{
				Password = (airCastVideoInputDevice.Password ?? string.Empty),
				PasswordEnabled = airCastVideoInputDevice.PasswordEnabled,
				ServiceName = (airCastVideoInputDevice.ServiceName ?? string.Empty)
			};
		}
		return videoDevice;
	}

	public void DeserializeFromAudioDevice(DigitalAudio.Types.Device? protoAudioDevice, Func<DigitalAudio.Types.Device, IAudioInputDevice?>? findDevice = null)
	{
		if (protoAudioDevice == null)
		{
			return;
		}
		DeviceType = SourceDeviceType.Audio;
		DeviceName = protoAudioDevice.Name;
		DeviceRenderID = protoAudioDevice.RenderID;
		VideoDeviceModeIndex = 0;
		Routing.Deserialize(protoAudioDevice.Routing);
		if (findDevice != null)
		{
			IAudioInputDevice audioDevice = _audioDevice;
			IAudioInputDevice audioInputDevice = (_audioDevice = findDevice(protoAudioDevice));
			if (_audioDevice != null)
			{
				_audioMapRecallService.AddOrUpdateAudioMap(_audioDevice, Routing.ChannelMap);
			}
			OnAudioDeviceChanged(audioDevice, audioInputDevice, audioInputDevice == null, skipChannelCountAndMappingUpdate: true);
			OnPropertyChanged("AudioDevice");
			OnPropertyChanged("IsDeviceConnected");
		}
	}

	public void DeserializeFromVideoDevice(Media.Types.VideoDevice? protoVideoDevice, Func<Media.Types.VideoDevice, IVideoInputDevice?>? findDevice = null)
	{
		if (protoVideoDevice == null)
		{
			return;
		}
		DeviceType = SourceDeviceType.Video;
		DeviceName = protoVideoDevice.Name;
		DeviceRenderID = protoVideoDevice.UniqueId;
		VideoDeviceModeIndex = (int)protoVideoDevice.FormatIndex;
		Routing.Deserialize(protoVideoDevice.AudioRouting);
		if (findDevice == null)
		{
			return;
		}
		IVideoInputDevice videoDevice = _videoDevice;
		IVideoInputDevice videoInputDevice = findDevice(protoVideoDevice);
		if (videoInputDevice == null || videoInputDevice.SupportsAudio)
		{
			_videoDevice = videoInputDevice;
			_protoAirCast = protoVideoDevice.Aircast;
			if (_videoDevice != null)
			{
				_audioMapRecallService.AddOrUpdateAudioMap(_videoDevice, Routing.ChannelMap);
				if (_videoDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
				{
					airCastVideoInputDevice.ServiceName = protoVideoDevice.Aircast?.ServiceName;
					airCastVideoInputDevice.Password = protoVideoDevice.Aircast?.Password;
					airCastVideoInputDevice.PasswordEnabled = protoVideoDevice.Aircast?.PasswordEnabled ?? false;
				}
			}
			OnVideoDeviceChanged(videoDevice, videoInputDevice, videoInputDevice == null, skipChannelCountAndMappingUpdate: true);
			OnPropertyChanged("VideoDevice");
			OnPropertyChanged("IsDeviceConnected");
		}
		else
		{
			AudioDevice = null;
			VideoDevice = null;
			DeviceType = SourceDeviceType.None;
			DeviceName = string.Empty;
			DeviceRenderID = string.Empty;
			VideoDeviceModeIndex = 0;
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
			Routing.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Routing.DataModified -= OnDataModified;
	}
}
