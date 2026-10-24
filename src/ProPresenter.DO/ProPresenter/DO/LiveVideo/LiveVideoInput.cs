using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Storage;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Media;

namespace ProPresenter.DO.LiveVideo;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "AudioSource" })]
public class LiveVideoInput : NotifyPropertyChangedBase, IIdentifiable, IDisposable
{
	private Guid _id = Guid.NewGuid();

	private int _index = -1;

	private ProPresenter.DO.Media.AlphaType _alphaType = ProPresenter.DO.Media.AlphaType.Straight;

	private string _description = string.Empty;

	private IVideoInputDevice? _videoDevice;

	private string _deviceName = string.Empty;

	private string _deviceRenderID = string.Empty;

	private int _videoModeIndex;

	private bool _hasSignal = true;

	private System.Windows.Media.Color _displayColor;

	private RelativePath _thumbnailPath = new RelativePath();

	private Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice.Types.AirCast? _protoAirCast;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid ID => _id;

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

	public bool IsDeviceConnected => VideoDevice != null;

	public bool SupportsAlphaChannel => VideoDevice?.SupportsAlphaChannel ?? false;

	public ProPresenter.DO.Media.AlphaType AlphaType
	{
		get
		{
			return _alphaType;
		}
		set
		{
			SetValue("AlphaType", ref _alphaType, value, OnDataModified);
		}
	}

	public int Index
	{
		get
		{
			return _index;
		}
		protected internal set
		{
			string oldLongName = LongName;
			SetValue("Index", ref _index, value, (System.Action)delegate
			{
				OnPropertyChanged("DisplayNumber");
				OnPropertyChanged("Name");
				OnPropertyChanged("LongName");
				OnPropertyChanged("DefaultDescription");
				this.LongNameChanged?.Invoke(oldLongName, LongName);
				UpdateDisplayColor();
				OnDataModified();
			}, (Predicate<int>?)null, referenceComparison: false);
		}
	}

	public int DisplayNumber => Index + 1;

	public string Name
	{
		get
		{
			if (!string.IsNullOrEmpty(Description))
			{
				return Description;
			}
			return DefaultDescription;
		}
		set
		{
			Description = value;
		}
	}

	public string DefaultDescription => LocalizedStrings.Get("EDITOR_SHAPE_VIDEO_INPUT_NAME_title", new object[1] { DisplayNumber });

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			string oldLongName = LongName;
			SetValue("Description", ref _description, value, delegate(string o, string n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoDescription), this, "Description", o, n, null, null, autoFinalize: true);
				OnPropertyChanged("Name");
				OnPropertyChanged("LongName");
				this.LongNameChanged?.Invoke(oldLongName, LongName);
				OnDataModified();
			});
		}
	}

	public string LongName
	{
		get
		{
			if (!string.IsNullOrEmpty(Description))
			{
				return DefaultDescription + ": " + Description;
			}
			return DefaultDescription;
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
			SetValue<IVideoInputDevice>("VideoDevice", ref _videoDevice, value, delegate(IVideoInputDevice o, IVideoInputDevice n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoVideoDevice), this, "VideoDevice", o, n, null, null, autoFinalize: true);
				bool flag = IsUsingEmbeddedAudio(o);
				if (!AudioSource.HasAudioDevice && (!AudioSource.HasVideoDevice || flag))
				{
					if (n != null && n.SupportsAudio)
					{
						AudioSource.VideoDevice = n;
					}
					else if (flag)
					{
						AudioSource.ClearDeviceSelection();
					}
				}
				if (o is IAirCastVideoInputDevice airCastVideoInputDevice)
				{
					airCastVideoInputDevice.DataModified -= OnDataModified;
				}
				if (n is IAirCastVideoInputDevice airCastVideoInputDevice2)
				{
					airCastVideoInputDevice2.DataModified += OnDataModified;
				}
				DeviceName = n?.Name ?? string.Empty;
				DeviceRenderID = n?.UUID ?? string.Empty;
				HasSignal = n?.HasSignal ?? false;
				OnPropertyChanged("IsDeviceConnected");
				OnPropertyChanged("SupportsAlphaChannel");
				OnDataModified();
			});
		}
	}

	public IVideoMode? VideoMode
	{
		get
		{
			return VideoDevice?.CurrentMode;
		}
		set
		{
			int num = value?.ModeIndex ?? 0;
			if (_videoModeIndex != num)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoVideoMode), this, "VideoMode", VideoDevice?.CurrentMode, value, null, null, autoFinalize: true);
				_videoModeIndex = value?.ModeIndex ?? 0;
				OnDataModified();
			}
		}
	}

	public double AspectRatio
	{
		get
		{
			if (VideoMode == null || VideoMode.Size.X == 0 || VideoMode.Size.Y == 0)
			{
				return 1.7777777777777777;
			}
			return VideoMode.Size.X / VideoMode.Size.Y;
		}
	}

	public AudioSource AudioSource { get; }

	public bool HasSignal
	{
		get
		{
			return _hasSignal;
		}
		set
		{
			SetValue("HasSignal", ref _hasSignal, value);
		}
	}

	public System.Windows.Media.Color DisplayColor
	{
		get
		{
			return _displayColor;
		}
		set
		{
			SetValue("DisplayColor", ref _displayColor, value, OnDataModified);
		}
	}

	public bool HasThumbnail => ThumbnailPath?.IsValid ?? false;

	public RelativePath ThumbnailPath
	{
		get
		{
			return _thumbnailPath;
		}
		set
		{
			_thumbnailPath = value;
			OnPropertyChanged("ThumbnailPath");
			OnPropertyChanged("HasThumbnail");
			OnDataModified();
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event System.Action? DataModified;

	public event Action<string, string>? LongNameChanged;

	public ObjectBinder<LiveVideoInput, IMergedVideoInput> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedVideoInput entity)
	{
		ObjectBinder<LiveVideoInput, IMergedVideoInput> objectBinder = new ObjectBinder<LiveVideoInput, IMergedVideoInput>(this, entity);
		objectBinder.Bind((LiveVideoInput l) => l.WhenPropertyChanges("ID"), (IMergedVideoInput r) => r.Uuid.WhenValueChanges, delegate(LiveVideoInput l, IMergedVideoInput r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMergedVideoInput r, LiveVideoInput l)
		{
			l._id = r.Uuid.Value;
		}).Bind((LiveVideoInput l) => l.WhenPropertyChanges("Description"), (IMergedVideoInput r) => r.UserDescription.WhenValueChanges, delegate(LiveVideoInput l, IMergedVideoInput r)
		{
			r.UserDescription.Set(l.Description);
		}, delegate(IMergedVideoInput r, LiveVideoInput l)
		{
			l.Description = r.UserDescription.Value ?? string.Empty;
		}).Bind((LiveVideoInput l) => l.WhenPropertyChanges("DisplayColor"), (IMergedVideoInput r) => r.DisplayColor.WhenValueChanges, delegate(LiveVideoInput l, IMergedVideoInput r)
		{
			r.DisplayColor.Set(l.DisplayColor.ToEntityColor());
		}, delegate(IMergedVideoInput r, LiveVideoInput l)
		{
			l.DisplayColor = r.DisplayColor.Value.ToColor();
		})
			.Bind((LiveVideoInput l) => l.WhenPropertyChanges("AlphaType"), (IMergedVideoInput r) => r.AlphaType.WhenValueChanges, delegate(LiveVideoInput l, IMergedVideoInput r)
			{
				r.AlphaType.Set(l.AlphaType.ToEntityAlphaType());
			}, delegate(IMergedVideoInput r, LiveVideoInput l)
			{
				l.AlphaType = r.AlphaType.Value.ToAlphaType();
			})
			.Bind((LiveVideoInput l) => Observable.Merge<PropertyChangedEventArgs>(l.WhenPropertyChanges("VideoDevice"), l.WhenPropertyChanges("DeviceName"), l.WhenPropertyChanges("DeviceRenderID"), l.WhenPropertyChanges("VideoMode")).Throttle(TimeSpan.Zero, scheduler.Scheduler), (IMergedVideoInput r) => r.VideoInputDevice.WhenValueChanges, delegate(LiveVideoInput l, IMergedVideoInput r)
			{
				if (l.VideoDevice == null)
				{
					r.VideoInputDevice.Set(null);
				}
				else
				{
					IMedia.Types.IVideoDevice videoDevice = entityFactory.Create<IMedia.Types.IVideoDevice>();
					videoDevice.Name.Set(l.DeviceName);
					videoDevice.UniqueId.Set(l.DeviceRenderID);
					videoDevice.FormatIndex.Set((uint)l._videoModeIndex);
					if (l.VideoDevice is IAirCastVideoInputDevice || l._protoAirCast != null)
					{
						videoDevice.Type.Set(IMedia.Types.IVideoDevice.Types.Type.Aircast);
						IMedia.Types.IVideoDevice.Types.IAirCast airCast = entityFactory.Create<IMedia.Types.IVideoDevice.Types.IAirCast>();
						airCast.ServiceName.Set((l.VideoDevice as IAirCastVideoInputDevice)?.ServiceName ?? l._protoAirCast?.ServiceName ?? string.Empty);
						airCast.Password.Set((l.VideoDevice as IAirCastVideoInputDevice)?.Password ?? l._protoAirCast?.Password ?? string.Empty);
						airCast.PasswordEnabled.Set((l.VideoDevice as IAirCastVideoInputDevice)?.PasswordEnabled ?? l._protoAirCast?.PasswordEnabled ?? false);
						videoDevice.Aircast.Set(airCast);
					}
					r.VideoInputDevice.Set(videoDevice);
				}
			}, delegate(IMergedVideoInput r, LiveVideoInput l)
			{
				l.DeviceName = r.VideoInputDevice.Value?.Name.Value ?? string.Empty;
				l.DeviceRenderID = r.VideoInputDevice.Value?.UniqueId.Value ?? string.Empty;
				l._videoModeIndex = (int)(r.VideoInputDevice.Value?.FormatIndex.Value ?? 0);
				l._protoAirCast = ((r.VideoInputDevice.Value?.Aircast.Value != null) ? new Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice.Types.AirCast
				{
					ServiceName = (r.VideoInputDevice.Value.Aircast.Value.ServiceName.Value ?? string.Empty),
					Password = (r.VideoInputDevice.Value.Aircast.Value.Password.Value ?? string.Empty),
					PasswordEnabled = (r.VideoInputDevice.Value.Aircast.Value.PasswordEnabled.Value == true)
				} : null);
			})
			.Bind((LiveVideoInput l) => l.AudioSource.WhenPropertyChanges("DeviceType").Throttle(TimeSpan.Zero, scheduler.Scheduler), (IMergedVideoInput r) => Observable.Merge<Unit>(r.AudioType.WhenValueChanges.ToUnit(), r.AltAudioSource.WhenValueChanges.ToUnit(), r.VideoInputDevice.WhenValueChanges.ToUnit()), delegate(LiveVideoInput l, IMergedVideoInput r)
			{
				switch (l.AudioSource.DeviceType)
				{
				case Pro.DO.Audio.AudioSource.SourceDeviceType.None:
					r.AudioType.Set(IVideoInput.Types.AudioDeviceType.None);
					break;
				case Pro.DO.Audio.AudioSource.SourceDeviceType.Audio:
				{
					IVideoInput.Types.IAltAudioSource.IAudioDevice audioDevice = entityFactory.Create<IVideoInput.Types.IAltAudioSource.IAudioDevice>();
					IReadOnlyObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> readOnlyObjectBinder2 = l.AudioSource.Bind(scheduler, entityFactory, audioDevice.Value, (IDigitalAudio.Types.IDevice d) => audioDevices.FindDevice(d.RenderId.Value));
					audioDevice.RegisterLinkedDisposable(readOnlyObjectBinder2);
					readOnlyObjectBinder2.InitializeRightFromLeft();
					r.AltAudioSource.Set(audioDevice);
					r.AudioType.Set(IVideoInput.Types.AudioDeviceType.Alternate);
					break;
				}
				case Pro.DO.Audio.AudioSource.SourceDeviceType.Video:
					if (!l.IsUsingEmbeddedAudio(l.VideoDevice))
					{
						IVideoInput.Types.IAltAudioSource.IVideoDevice videoDevice2 = entityFactory.Create<IVideoInput.Types.IAltAudioSource.IVideoDevice>();
						IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> readOnlyObjectBinder = l.AudioSource.Bind(scheduler, entityFactory, videoDevice2.Value, (IMedia.Types.IVideoDevice d) => videoDevices.FindDevice(d.UniqueId.Value));
						videoDevice2.RegisterLinkedDisposable(readOnlyObjectBinder);
						readOnlyObjectBinder.InitializeRightFromLeft();
						r.AltAudioSource.Set(videoDevice2);
						r.AudioType.Set(IVideoInput.Types.AudioDeviceType.Alternate);
					}
					else
					{
						r.AudioType.Set(IVideoInput.Types.AudioDeviceType.Default);
						if (r.VideoInputDevice.Value != null)
						{
							SetupRoutingBinder(scheduler, entityFactory, l.AudioSource.Routing, delegate(IDigitalAudio.Types.IDevice.Types.IRouting routing)
							{
								r.VideoInputDevice.Value.AudioRouting.Set(routing);
							});
						}
					}
					break;
				}
			}, delegate(IMergedVideoInput r, LiveVideoInput l)
			{
				switch (r.AudioType.Value)
				{
				case IVideoInput.Types.AudioDeviceType.None:
					l.AudioSource.ClearDeviceSelection();
					break;
				case IVideoInput.Types.AudioDeviceType.Alternate:
					if (r.AltAudioSource.Value is IVideoInput.Types.IAltAudioSource.IAudioDevice audioDevice2)
					{
						IReadOnlyObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> readOnlyObjectBinder4 = l.AudioSource.Bind(scheduler, entityFactory, audioDevice2.Value, (IDigitalAudio.Types.IDevice d) => audioDevices.FindDevice(d.RenderId.Value));
						readOnlyObjectBinder4.InitializeLeftFromRight();
						audioDevice2.RegisterLinkedDisposable(readOnlyObjectBinder4);
					}
					else if (r.AltAudioSource.Value is IVideoInput.Types.IAltAudioSource.IVideoDevice videoDevice3)
					{
						IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> readOnlyObjectBinder5 = l.AudioSource.Bind(scheduler, entityFactory, videoDevice3.Value, (IMedia.Types.IVideoDevice d) => videoDevices.FindDevice(d.UniqueId.Value));
						readOnlyObjectBinder5.InitializeLeftFromRight();
						videoDevice3.RegisterLinkedDisposable(readOnlyObjectBinder5);
					}
					break;
				case IVideoInput.Types.AudioDeviceType.Default:
				{
					IMedia.Types.IVideoDevice value = r.VideoInputDevice.Value;
					if (value != null)
					{
						IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> readOnlyObjectBinder3 = l.AudioSource.Bind(scheduler, entityFactory, value, (IMedia.Types.IVideoDevice d) => videoDevices.FindDevice(d.UniqueId.Value));
						readOnlyObjectBinder3.InitializeLeftFromRight();
						value.RegisterLinkedDisposable(readOnlyObjectBinder3);
					}
					break;
				}
				}
			});
		return objectBinder;
	}

	private static void SetupRoutingBinder(IUiScheduler scheduler, IEntityFactory entityFactory, AudioRouting<DeviceChannel, Bus> audioRouting, Action<IDigitalAudio.Types.IDevice.Types.IRouting> setRouting)
	{
		IDigitalAudio.Types.IDevice.Types.IRouting routing = entityFactory.Create<IDigitalAudio.Types.IDevice.Types.IRouting>();
		ObjectBinder<IAudioRouting<DeviceChannel, Bus>, IDigitalAudio.Types.IDevice.Types.IRouting> objectBinder = audioRouting.Bind(scheduler, entityFactory, routing);
		routing.RegisterLinkedDisposable(objectBinder);
		objectBinder.InitializeRightFromLeft();
		setRouting(routing);
	}

	public LiveVideoInput(int index, ChannelSet<Bus> buses, IAudioMapRecallService<DeviceChannel, Bus> audioMapRecallService)
	{
		Index = index;
		AudioSource = new AudioSource(buses, audioMapRecallService);
		UpdateDisplayColor();
		AudioSource.DataModified += OnDataModified;
		AudioSource.Routing.ChannelMap.IsCustomMapChanged += VideoInputCustomMapEvent.Publish;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private bool IsUsingEmbeddedAudio(IVideoInputDevice? videoDevice)
	{
		if (AudioSource.HasVideoDevice)
		{
			return AudioSource.VideoDevice == videoDevice;
		}
		return false;
	}

	private void UpdateDisplayColor()
	{
		DisplayColor = DefaultColors.ColorPalette[Math.Max(Index, 0) % DefaultColors.ColorPalette.Length];
	}

	public void ClearDeviceSelection()
	{
		if (VideoDevice != null)
		{
			VideoDevice = null;
			return;
		}
		UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LiveVideoVideoDevice));
		UndoStack?.Commit(this, "DeviceName", DeviceName, string.Empty);
		UndoStack?.Commit(this, "DeviceRenderID", DeviceRenderID, string.Empty);
		if (AudioSource.DeviceRenderID == DeviceRenderID)
		{
			AudioSource.ClearDeviceSelection();
		}
		DeviceName = string.Empty;
		DeviceRenderID = string.Empty;
		UndoStack?.EndCommit();
		OnDataModified();
	}

	public void SynchronizeWithPhysicalDevice(IVideoInputDeviceCollection videoInputDevices, IAudioInputDeviceCollection audioInputDevices)
	{
		_videoDevice = videoInputDevices?.FindDevice(DeviceRenderID);
		if (_videoDevice == null && _protoAirCast != null)
		{
			_videoDevice = videoInputDevices?.GetOrAddAirCastVideoInputDevice();
			if (_videoDevice is IAirCastVideoInputDevice airCastVideoInputDevice)
			{
				airCastVideoInputDevice.Deserialize(_protoAirCast, DeviceRenderID);
			}
			_protoAirCast = null;
		}
		IVideoInputDevice? videoDevice = VideoDevice;
		if (videoDevice != null && videoDevice.SupportsAutoModeSelection)
		{
			IVideoMode currentMode = VideoDevice.CurrentMode;
			if (currentMode != null)
			{
				_videoModeIndex = currentMode.ModeIndex;
				goto IL_00f7;
			}
		}
		IVideoMode videoMode = VideoDevice?.Modes?.FirstOrDefault((IVideoMode m) => m.ModeIndex == _videoModeIndex) ?? VideoDevice?.CurrentMode;
		if (videoMode != null && _videoModeIndex != videoMode.ModeIndex)
		{
			_videoModeIndex = videoMode.ModeIndex;
			OnDataModified();
		}
		goto IL_00f7;
		IL_00f7:
		HasSignal = VideoDevice?.HasSignal ?? true;
		OnPropertyChanged("VideoDevice");
		OnPropertyChanged("VideoMode");
		OnPropertyChanged("IsDeviceConnected");
		OnPropertyChanged("AspectRatio");
		AudioSource.SynchronizeWithPhysicalDevice(audioInputDevices, videoInputDevices);
	}

	public VideoInput Serialize()
	{
		VideoInput videoInput = new VideoInput
		{
			Uuid = ID.ToUUID(),
			UserDescription = Description,
			DisplayColor = DisplayColor.ToProtoColor(),
			ThumbnailPath = ThumbnailPath?.Serialize(),
			VideoInputDevice = new Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice
			{
				Name = DeviceName,
				UniqueId = DeviceRenderID,
				FormatIndex = (uint)_videoModeIndex
			},
			AlphaType = AlphaType.ToProtoAlphaType()
		};
		if (VideoDevice is IAirCastVideoInputDevice || _protoAirCast != null)
		{
			videoInput.VideoInputDevice.Type = Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice.Types.Type.Aircast;
			videoInput.VideoInputDevice.Aircast = new Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice.Types.AirCast
			{
				ServiceName = ((VideoDevice as IAirCastVideoInputDevice)?.ServiceName ?? _protoAirCast?.ServiceName ?? string.Empty),
				Password = ((VideoDevice as IAirCastVideoInputDevice)?.Password ?? _protoAirCast?.Password ?? string.Empty),
				PasswordEnabled = ((VideoDevice as IAirCastVideoInputDevice)?.PasswordEnabled ?? _protoAirCast?.PasswordEnabled ?? false)
			};
		}
		switch (AudioSource.DeviceType)
		{
		case Pro.DO.Audio.AudioSource.SourceDeviceType.None:
			videoInput.AudioType = VideoInput.Types.AudioDeviceType.None;
			break;
		case Pro.DO.Audio.AudioSource.SourceDeviceType.Audio:
			videoInput.AudioDevice = AudioSource.SerializeAsAudioDevice();
			videoInput.AudioType = VideoInput.Types.AudioDeviceType.Alternate;
			break;
		case Pro.DO.Audio.AudioSource.SourceDeviceType.Video:
			if (!IsUsingEmbeddedAudio(VideoDevice))
			{
				videoInput.VideoDevice = AudioSource.SerializeAsVideoDevice();
				videoInput.AudioType = VideoInput.Types.AudioDeviceType.Alternate;
				break;
			}
			videoInput.AudioType = VideoInput.Types.AudioDeviceType.Default;
			if (videoInput.VideoInputDevice != null)
			{
				videoInput.VideoInputDevice.AudioRouting = AudioSource.Routing.Serialize();
			}
			break;
		}
		return videoInput;
	}

	public void Deserialize(VideoInput protoVideoInput, int index, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices)
	{
		Index = index;
		_id = protoVideoInput.Uuid.ToGuid();
		Description = protoVideoInput.UserDescription;
		ThumbnailPath = new RelativePath(protoVideoInput.ThumbnailPath);
		DeviceName = protoVideoInput.VideoInputDevice?.Name ?? string.Empty;
		DeviceRenderID = protoVideoInput.VideoInputDevice?.UniqueId ?? string.Empty;
		_videoModeIndex = (int)(protoVideoInput.VideoInputDevice?.FormatIndex ?? 0);
		AlphaType = protoVideoInput.AlphaType.ToAlphaType();
		_protoAirCast = protoVideoInput.VideoInputDevice?.Aircast;
		DisplayColor = protoVideoInput.DisplayColor.ToColor();
		switch (protoVideoInput.AudioType)
		{
		case VideoInput.Types.AudioDeviceType.None:
			AudioSource.ClearDeviceSelection();
			break;
		case VideoInput.Types.AudioDeviceType.Alternate:
			switch (protoVideoInput.AltAudioSourceCase)
			{
			case VideoInput.AltAudioSourceOneofCase.AudioDevice:
				AudioSource.DeserializeFromAudioDevice(protoVideoInput.AudioDevice, findDevice);
				break;
			case VideoInput.AltAudioSourceOneofCase.VideoDevice:
				AudioSource.DeserializeFromVideoDevice(protoVideoInput.VideoDevice, findVideoDevice);
				break;
			}
			break;
		case VideoInput.Types.AudioDeviceType.Default:
			AudioSource.DeserializeFromVideoDevice(protoVideoInput.VideoInputDevice, (Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice d) => videoDevices.FindDevice(d.UniqueId));
			break;
		}
		IAudioInputDevice? findDevice(DigitalAudio.Types.Device d)
		{
			return audioDevices.FindDevice(d.RenderID);
		}
		IVideoInputDevice? findVideoDevice(Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice d)
		{
			return videoDevices.FindDevice(d.UniqueId);
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
			AudioSource.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		AudioSource.DataModified -= OnDataModified;
	}
}
