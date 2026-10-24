using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Audio;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Merged.Entities;
using Pro.Entity.Properties;
using Pro.Localization.Services;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Analytics.Events.TrackedEvents;

namespace ProPresenter.DO.Audio;

public class AudioInput : NotifyPropertyChangedBase, IAudioInput, INotifyPropertyChanged
{
	private Guid _id = Guid.NewGuid();

	private string _description = string.Empty;

	private BehaviorMode _behaviorMode = BehaviorMode.Off;

	private int _index;

	private readonly ILocalization _localization;

	private readonly IAudioSettingsAnalyticsEventPublisher _analyticsEventPublisher;

	public Guid ID => _id;

	public string Description
	{
		get
		{
			return _description;
		}
		set
		{
			SetValue("Description", ref _description, value, delegate(string o, string n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AudioInputDescription), this, "Description", o, n, null, null, autoFinalize: true);
				OnDataModified();
				OnPropertyChanged("LongName");
			});
		}
	}

	public BehaviorMode BehaviorMode
	{
		get
		{
			return _behaviorMode;
		}
		set
		{
			SetValue("BehaviorMode", ref _behaviorMode, value, delegate(BehaviorMode o, BehaviorMode n)
			{
				if (n != BehaviorMode.AutoOn)
				{
					LinkedVideoInputs.Clear();
				}
				OnDataModified();
				_analyticsEventPublisher.PublishAudioInputModeSelection(BehaviorMode);
			});
		}
	}

	public AudioSource Source { get; }

	public ILinkedVideoInputs LinkedVideoInputs { get; } = new LinkedVideoInputs();

	public UndoStack? UndoStack { get; set; }

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			SetValue("Index", ref _index, value, null, false, "DefaultDescription");
		}
	}

	public string DefaultDescription => _localization.Get("EDITOR_SHAPE_VIDEO_INPUT_NAME_title", new object[1] { Index });

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

	public event System.Action? DataModified;

	public ObjectBinder<AudioInput, IMergedAudioInput> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices, IMergedAudioInput entity)
	{
		ObjectBinder<AudioInput, IMergedAudioInput> objectBinder = new ObjectBinder<AudioInput, IMergedAudioInput>(this, entity);
		objectBinder.Bind((AudioInput l) => l.WhenPropertyChanges("ID"), (IMergedAudioInput r) => r.Uuid.WhenValueChanges, delegate(AudioInput l, IMergedAudioInput r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMergedAudioInput r, AudioInput l)
		{
			l._id = r.Uuid.Value;
		}).Bind((AudioInput l) => l.WhenPropertyChanges("Description"), (IMergedAudioInput r) => r.UserDescription.WhenValueChanges, delegate(AudioInput l, IMergedAudioInput r)
		{
			r.UserDescription.Set(l.Description);
		}, delegate(IMergedAudioInput r, AudioInput l)
		{
			l.Description = r.UserDescription.Value ?? string.Empty;
		}).Bind((AudioInput l) => l.WhenPropertyChanges("BehaviorMode").ToUnit().Merge(Observable.FromEvent(delegate(System.Action h)
		{
			l.LinkedVideoInputs.DataModified += h;
		}, delegate(System.Action h)
		{
			l.LinkedVideoInputs.DataModified -= h;
		}).ToUnit())
			.Throttle(TimeSpan.Zero, scheduler.Scheduler), (IMergedAudioInput r) => r.BehaviorMode.WhenAnyValueChanges, delegate(AudioInput l, IMergedAudioInput r)
		{
			Pro.Entity.IAudioInput.Types.IBehaviorMode behaviorMode = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode>();
			switch (l.BehaviorMode)
			{
			case BehaviorMode.On:
			{
				Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOn value3 = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOn>();
				behaviorMode.Mode.Set(value3);
				break;
			}
			case BehaviorMode.Off:
			{
				Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOff value2 = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IOff>();
				behaviorMode.Mode.Set(value2);
				break;
			}
			case BehaviorMode.AutoOff:
			{
				Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff value = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOff>();
				behaviorMode.Mode.Set(value);
				break;
			}
			case BehaviorMode.AutoOn:
			{
				Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn autoOn = entityFactory.Create<Pro.Entity.IAudioInput.Types.IBehaviorMode.Types.IMode.IAutoOn>();
				autoOn.Value.LinkedVideoInputs.Reset(l.LinkedVideoInputs.Serialize());
				behaviorMode.Mode.Set(autoOn);
				break;
			}
			default:
				throw new NotSupportedException();
			}
			r.BehaviorMode.Set(behaviorMode);
		}, delegate(IMergedAudioInput r, AudioInput l)
		{
			(BehaviorMode behaviorMode, IEnumerable<int>? linkedVideoInputs) tuple = r.BehaviorMode.Value.ToBehaviorMode();
			BehaviorMode item = tuple.behaviorMode;
			IEnumerable<int> item2 = tuple.linkedVideoInputs;
			l.BehaviorMode = item;
			if (item2 != null)
			{
				l.LinkedVideoInputs.Deserialize(item2);
			}
		})
			.Bind((AudioInput l) => l.Source.WhenPropertyChanges("DeviceType").Throttle(TimeSpan.Zero, scheduler.Scheduler), (IMergedAudioInput r) => r.Source.WhenValueChanges, delegate(AudioInput l, IMergedAudioInput r)
			{
				IComplexObservableProperty<Pro.Entity.IAudioInput.Types.ISource> source = r.Source;
				source.Set(l.Source.DeviceType switch
				{
					AudioSource.SourceDeviceType.Audio => CreateAudioSourceDeviceAndBind(l.Source, entityFactory, scheduler, (IDigitalAudio.Types.IDevice d) => audioDevices.FindDevice(d.RenderId.Value)), 
					AudioSource.SourceDeviceType.Video => CreateVideoSourceDeviceAndBind(l.Source, entityFactory, scheduler, (IMedia.Types.IVideoDevice d) => videoDevices.FindDevice(d.UniqueId.Value)), 
					_ => entityFactory.Create<Pro.Entity.IAudioInput.Types.ISource>(), 
				});
			}, delegate(IMergedAudioInput r, AudioInput l)
			{
				Pro.Entity.IAudioInput.Types.ISource value4 = r.Source.Value;
				if (!(value4 is Pro.Entity.IAudioInput.Types.ISource.IAudioDevice audioDevice))
				{
					if (value4 is Pro.Entity.IAudioInput.Types.ISource.IVideoDevice videoDevice)
					{
						IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> readOnlyObjectBinder = l.Source.Bind(scheduler, entityFactory, videoDevice.Value, (IMedia.Types.IVideoDevice d) => videoDevices.FindDevice(d.UniqueId.Value));
						videoDevice.RegisterLinkedDisposable(readOnlyObjectBinder);
						readOnlyObjectBinder.InitializeLeftFromRight();
					}
				}
				else
				{
					IReadOnlyObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> readOnlyObjectBinder2 = l.Source.Bind(scheduler, entityFactory, audioDevice.Value, (IDigitalAudio.Types.IDevice d) => audioDevices.FindDevice(d.RenderId.Value));
					audioDevice.RegisterLinkedDisposable(readOnlyObjectBinder2);
					readOnlyObjectBinder2.InitializeLeftFromRight();
				}
			});
		return objectBinder;
	}

	private static Pro.Entity.IAudioInput.Types.ISource CreateAudioSourceDeviceAndBind(AudioSource source, IEntityFactory entityFactory, IUiScheduler scheduler, Func<IDigitalAudio.Types.IDevice, IAudioInputDevice?> findDevice)
	{
		Pro.Entity.IAudioInput.Types.ISource.IAudioDevice audioDevice = entityFactory.Create<Pro.Entity.IAudioInput.Types.ISource.IAudioDevice>();
		IReadOnlyObjectBinder<AudioSource, IDigitalAudio.Types.IDevice> readOnlyObjectBinder = source.Bind(scheduler, entityFactory, audioDevice.Value, findDevice);
		audioDevice.RegisterLinkedDisposable(readOnlyObjectBinder);
		readOnlyObjectBinder.InitializeRightFromLeft();
		return audioDevice;
	}

	private static Pro.Entity.IAudioInput.Types.ISource CreateVideoSourceDeviceAndBind(AudioSource source, IEntityFactory entityFactory, IUiScheduler scheduler, Func<IMedia.Types.IVideoDevice, IVideoInputDevice?> findDevice)
	{
		Pro.Entity.IAudioInput.Types.ISource.IVideoDevice videoDevice = entityFactory.Create<Pro.Entity.IAudioInput.Types.ISource.IVideoDevice>();
		IReadOnlyObjectBinder<AudioSource, IMedia.Types.IVideoDevice> readOnlyObjectBinder = source.Bind(scheduler, entityFactory, videoDevice.Value, findDevice);
		videoDevice.RegisterLinkedDisposable(readOnlyObjectBinder);
		readOnlyObjectBinder.InitializeRightFromLeft();
		return videoDevice;
	}

	public AudioInput(ChannelSet<Bus> buses, IAudioMapRecallService<DeviceChannel, Bus> audioMapRecallService, ILocalization localization, IAudioSettingsAnalyticsEventPublisher analyticsEventPublisher)
	{
		_analyticsEventPublisher = analyticsEventPublisher;
		_localization = localization;
		Source = new AudioSource(buses, audioMapRecallService);
		Source.DataModified += OnDataModified;
		LinkedVideoInputs.DataModified += OnDataModified;
		Source.Routing.ChannelMap.IsCustomMapChanged += analyticsEventPublisher.PublishAudioSettingsCustomMap;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public Pro.SerializationInterop.RVProtoData.AudioInput Serialize()
	{
		Pro.SerializationInterop.RVProtoData.AudioInput audioInput = new Pro.SerializationInterop.RVProtoData.AudioInput
		{
			Uuid = _id.ToUUID(),
			UserDescription = (Description ?? string.Empty),
			BehaviorMode = BehaviorMode.ToProtoBehaviorMode(LinkedVideoInputs.Serialize())
		};
		switch (Source.DeviceType)
		{
		case AudioSource.SourceDeviceType.Audio:
			audioInput.AudioDevice = Source.SerializeAsAudioDevice();
			break;
		case AudioSource.SourceDeviceType.Video:
			audioInput.VideoDevice = Source.SerializeAsVideoDevice();
			break;
		default:
			throw new NotSupportedException();
		case AudioSource.SourceDeviceType.None:
			break;
		}
		return audioInput;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.AudioInput protoAudioInput, IAudioInputDeviceCollection audioDevices, IVideoInputDeviceCollection videoDevices)
	{
		if (protoAudioInput == null)
		{
			return;
		}
		_id = protoAudioInput.Uuid.ToGuid();
		Description = protoAudioInput.UserDescription;
		switch (protoAudioInput.SourceCase)
		{
		case Pro.SerializationInterop.RVProtoData.AudioInput.SourceOneofCase.AudioDevice:
			Source.DeserializeFromAudioDevice(protoAudioInput.AudioDevice, (DigitalAudio.Types.Device d) => audioDevices.FindDevice(d.RenderID));
			break;
		case Pro.SerializationInterop.RVProtoData.AudioInput.SourceOneofCase.VideoDevice:
			Source.DeserializeFromVideoDevice(protoAudioInput.VideoDevice, (Pro.SerializationInterop.RVProtoData.Media.Types.VideoDevice d) => videoDevices.FindDevice(d.UniqueId));
			break;
		}
		SetBehaviorMode(protoAudioInput.BehaviorMode);
	}

	public void SetBehaviorMode(Pro.SerializationInterop.RVProtoData.AudioInput.Types.BehaviorMode protoBehaviorMode)
	{
		(BehaviorMode behaviorMode, IEnumerable<int>? linkedVideoInputs) tuple = protoBehaviorMode.ToBehaviorMode();
		BehaviorMode item = tuple.behaviorMode;
		IEnumerable<int> item2 = tuple.linkedVideoInputs;
		BehaviorMode = item;
		if (item2 != null)
		{
			LinkedVideoInputs.Deserialize(item2);
		}
	}
}
