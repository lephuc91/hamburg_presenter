using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Analytics.Events;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace Pro.DO.Audio;

public sealed class AudioSetup : NotifyPropertyChangedBase, IAudioSetup, INotifyPropertyChanged
{
	private sealed class DummySdiNdiOutputDevice : NotifyPropertyChangedBase, IAudioOutputDevice, IAudioDevice, IDevice, INotifyPropertyChanged
	{
		public string UUID => string.Empty;

		public string Name => string.Empty;

		public AudioDeviceType DeviceType => AudioDeviceType.Unknown;

		public int ChannelCount => 16;

		public bool ShouldAutoMap { get; set; } = true;

		public event System.Action? ChannelCountChanged;
	}

	private const int DefaultChannelCount = 2;

	private readonly IAudioOutputDeviceCollection _systemOutputDevices;

	private bool _monitorOnMains = true;

	private bool _sdindiOutputActive;

	private bool _mainDeviceNone;

	public ChannelSet<Bus> Buses { get; } = new ChannelSet<Bus>();

	public int BusCount
	{
		get
		{
			return Buses.ChannelCount;
		}
		set
		{
			Buses.Resize(value);
		}
	}

	public bool MonitorOnMains
	{
		get
		{
			return _monitorOnMains;
		}
		set
		{
			SetValue("MonitorOnMains", ref _monitorOnMains, value, OnDataModified);
		}
	}

	public bool DisableMainOutputDevice
	{
		get
		{
			return _mainDeviceNone;
		}
		set
		{
			SetValue("DisableMainOutputDevice", ref _mainDeviceNone, value, OnDataModified);
		}
	}

	public bool SdiNdiOutputActive
	{
		get
		{
			return _sdindiOutputActive;
		}
		set
		{
			SetValue("SdiNdiOutputActive", ref _sdindiOutputActive, value, (Action<bool, bool>?)delegate
			{
				OnDataModified();
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public IAudioDestination MainOutputDestination { get; }

	public TimeSlice MainDelay
	{
		get
		{
			return MainOutputDestination.Routing.ChannelSet.FirstOrDefault()?.Delay ?? TimeSlice.Zero;
		}
		set
		{
			MainOutputDestination.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
			{
				c.Delay = value;
			});
			OnPropertyChanged("MainDelay");
		}
	}

	public IAudioDestination MonitorOutputDestination { get; }

	public IAudioDestination SdiNdiOutputDestination { get; }

	public TimeSlice SdiNdiDelay
	{
		get
		{
			return SdiNdiOutputDestination.Routing.ChannelSet.FirstOrDefault()?.Delay ?? TimeSlice.Zero;
		}
		set
		{
			SdiNdiOutputDestination.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
			{
				c.Delay = value;
			});
			OnPropertyChanged("SdiNdiDelay");
		}
	}

	public event System.Action? DataModified;

	public event System.Action? LevelChanged;

	public IReadOnlyObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup> Bind(IUiScheduler uiScheduler, IEntityFactory entityFactory, IDigitalAudio.Types.ISetup? right)
	{
		ObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup> binder = new ObjectBinder<AudioSetup, IDigitalAudio.Types.ISetup>(this, right);
		binder.Bind((AudioSetup l) => l.WhenPropertyChanges("MonitorOnMains"), (IDigitalAudio.Types.ISetup r) => r.MonitorOnMains.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
		{
			r.MonitorOnMains.Set(l.MonitorOnMains);
		}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
		{
			l.MonitorOnMains = r.MonitorOnMains.Value;
		}).Bind((AudioSetup l) => l.Buses.WhenCollectionChanges(), (IDigitalAudio.Types.ISetup r) => r.Buses.WhenCollectionChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
		{
			int busCount = l.BusCount;
			int count = r.Buses.Items.Count;
			if (busCount != count)
			{
				if (busCount > count)
				{
					for (int i = count; i < busCount; i++)
					{
						IDigitalAudio.Types.IBus bus = entityFactory.Create<IDigitalAudio.Types.IBus>();
						ObjectBinder<Bus, IDigitalAudio.Types.IBus> objectBinder = Bus.CreateBinder(l.Buses[i], bus);
						objectBinder.InitializeRightFromLeft();
						bus.RegisterLinkedDisposable(objectBinder);
						r.Buses.Add(bus);
					}
				}
				else
				{
					for (int num = count - 1; num >= busCount; num--)
					{
						r.Buses.RemoveAt(num);
					}
				}
			}
		}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
		{
			int busCount2 = l.BusCount;
			int count2 = r.Buses.Items.Count;
			if (busCount2 != count2)
			{
				if (busCount2 > count2)
				{
					l.BusCount = r.Buses.Items.Count;
				}
				else
				{
					l.BusCount = count2;
					for (int j = busCount2; j < count2; j++)
					{
						IDigitalAudio.Types.IBus bus2 = r.Buses.Items[j];
						ObjectBinder<Bus, IDigitalAudio.Types.IBus> objectBinder2 = Bus.CreateBinder(l.Buses[j], bus2);
						objectBinder2.InitializeLeftFromRight();
						bus2.RegisterLinkedDisposable(objectBinder2);
					}
				}
			}
		}).Bind((AudioSetup l) => l.WhenPropertyChanges("SdiNdiOutputActive"), (IDigitalAudio.Types.ISetup r) => r.EnableSdiNdiDevice.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
		{
			r.EnableSdiNdiDevice.Set(l.SdiNdiOutputActive);
		}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
		{
			l.SdiNdiOutputActive = r.EnableSdiNdiDevice.Value;
		})
			.Bind((AudioSetup l) => l.WhenPropertyChanges("MainOutputDestination"), (IDigitalAudio.Types.ISetup r) => r.MainOutputDevice.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
			{
				IDigitalAudio.Types.IDevice device = entityFactory.Create<IDigitalAudio.Types.IDevice>();
				r.MainOutputDevice.Set(device);
				ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder3 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.MainOutputDestination, device);
				objectBinder3.InitializeRightFromLeft();
				device.RegisterLinkedDisposable(objectBinder3);
			}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
			{
				if (r.MainOutputDevice.Value != null)
				{
					ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder4 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.MainOutputDestination, r.MainOutputDevice.Value);
					objectBinder4.InitializeLeftFromRight();
					r.MainOutputDevice.Value.RegisterLinkedDisposable(objectBinder4);
				}
			})
			.Bind((AudioSetup l) => l.WhenPropertyChanges("MonitorOutputDestination"), (IDigitalAudio.Types.ISetup r) => r.MonitorDevice.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
			{
				IDigitalAudio.Types.IDevice device2 = entityFactory.Create<IDigitalAudio.Types.IDevice>();
				r.MonitorDevice.Set(device2);
				ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder5 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.MonitorOutputDestination, device2);
				objectBinder5.InitializeRightFromLeft();
				device2.RegisterLinkedDisposable(objectBinder5);
			}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
			{
				if (r.MonitorDevice.Value != null)
				{
					ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder6 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.MonitorOutputDestination, r.MonitorDevice.Value);
					objectBinder6.InitializeLeftFromRight();
					r.MonitorDevice.Value.RegisterLinkedDisposable(objectBinder6);
				}
			})
			.Bind((AudioSetup l) => l.WhenPropertyChanges("SdiNdiOutputDestination"), (IDigitalAudio.Types.ISetup r) => r.SdiNdiDevice.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
			{
				IDigitalAudio.Types.IDevice device3 = entityFactory.Create<IDigitalAudio.Types.IDevice>();
				r.SdiNdiDevice.Set(device3);
				ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder7 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.SdiNdiOutputDestination, device3);
				objectBinder7.InitializeRightFromLeft();
				device3.RegisterLinkedDisposable(objectBinder7);
			}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
			{
				if (r.SdiNdiDevice.Value != null)
				{
					ObjectBinder<IAudioDestination, IDigitalAudio.Types.IDevice> objectBinder8 = AudioDestination.Create(uiScheduler, entityFactory, l._systemOutputDevices, l.SdiNdiOutputDestination, r.SdiNdiDevice.Value);
					objectBinder8.InitializeLeftFromRight();
					r.SdiNdiDevice.Value.RegisterLinkedDisposable(objectBinder8);
				}
			})
			.Bind((AudioSetup l) => l.WhenPropertyChanges("DisableMainOutputDevice"), (IDigitalAudio.Types.ISetup r) => r.DisableMainOutputDevice.WhenValueChanges, delegate(AudioSetup l, IDigitalAudio.Types.ISetup r)
			{
				r.DisableMainOutputDevice.Set(l.DisableMainOutputDevice);
			}, delegate(IDigitalAudio.Types.ISetup r, AudioSetup l)
			{
				l.DisableMainOutputDevice = r.DisableMainOutputDevice.Value;
			})
			.DoOnInitializeLeftFromRight(delegate
			{
				InitializeBusBinders(delegate(ObjectBinder<Bus, IDigitalAudio.Types.IBus> b)
				{
					b.InitializeLeftFromRight();
				});
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				InitializeBusBinders(delegate(ObjectBinder<Bus, IDigitalAudio.Types.IBus> b)
				{
					b.InitializeRightFromLeft();
				});
			});
		return binder;
		void InitializeBusBinders(Action<ObjectBinder<Bus, IDigitalAudio.Types.IBus>> initialize)
		{
			if (binder.Left != null && binder.Right != null)
			{
				AudioSetup left = binder.Left;
				IDigitalAudio.Types.ISetup right2 = binder.Right;
				int num2 = Math.Min(left.BusCount, right2.Buses.Items.Count);
				for (int k = 0; k < num2; k++)
				{
					Bus left2 = left.Buses[k];
					IDigitalAudio.Types.IBus bus3 = right2.Buses.Items[k];
					ObjectBinder<Bus, IDigitalAudio.Types.IBus> objectBinder9 = Bus.CreateBinder(left2, bus3);
					initialize(objectBinder9);
					bus3.RegisterLinkedDisposable(objectBinder9);
				}
			}
		}
	}

	public ObjectBinder<AudioSetup, IAudio.Types.ISettingsDocument> CreateBinder(AudioSetup left, IAudio.Types.ISettingsDocument right)
	{
		ObjectBinder<AudioSetup, IAudio.Types.ISettingsDocument> objectBinder = new ObjectBinder<AudioSetup, IAudio.Types.ISettingsDocument>(left, right);
		objectBinder.Bind((AudioSetup l) => l.WhenPropertyChanges("MonitorOnMains"), (IAudio.Types.ISettingsDocument r) => r.MonitorOnMains.WhenValueChanges, delegate(AudioSetup l, IAudio.Types.ISettingsDocument r)
		{
			r.MonitorOnMains.Set(l.MonitorOnMains);
		}, delegate(IAudio.Types.ISettingsDocument r, AudioSetup l)
		{
			l.MonitorOnMains = r.MonitorOnMains.Value;
		});
		return objectBinder;
	}

	public AudioSetup(IAudioOutputDeviceCollection systemOutputDevices)
	{
		_systemOutputDevices = systemOutputDevices;
		Buses.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.Cast<Bus>().ForEach(delegate(Bus bus)
			{
				bus.DataModified -= OnDataModified;
			});
			e.NewItems?.Cast<Bus>().ForEach(delegate(Bus bus)
			{
				bus.DataModified += OnDataModified;
			});
			OnPropertyChanged("BusCount");
			OnDataModified();
		};
		Buses.Resize(2);
		AudioMapRecallService<Bus, DeviceChannel> audioMapRecallService = new AudioMapRecallService<Bus, DeviceChannel>((ChannelSet<Bus> i, ChannelSet<DeviceChannel> o) => new AudioMap<Bus, DeviceChannel>(i, o));
		MainOutputDestination = new AudioDestination(Buses, audioMapRecallService)
		{
			AudioDevice = _systemOutputDevices.FirstOrDefault()
		};
		MonitorOutputDestination = new AudioDestination(Buses, audioMapRecallService)
		{
			AudioDevice = null
		};
		SdiNdiOutputDestination = new AudioDestination(Buses, audioMapRecallService)
		{
			AudioDevice = new DummySdiNdiOutputDevice()
		};
		MainOutputDestination.DataModified += OnDataModified;
		MonitorOutputDestination.DataModified += OnDataModified;
		SdiNdiOutputDestination.DataModified += OnDataModified;
		MainOutputDestination.Routing.MasterChannel.PropertyChanged += Channel_PropertyChanged;
		MonitorOutputDestination.Routing.MasterChannel.PropertyChanged += Channel_PropertyChanged;
		SdiNdiOutputDestination.Routing.MasterChannel.PropertyChanged += Channel_PropertyChanged;
		MainOutputDestination.Routing.ChannelMap.IsCustomMapChanged += TrackCustomMap;
		MonitorOutputDestination.Routing.ChannelMap.IsCustomMapChanged += TrackCustomMap;
		SdiNdiOutputDestination.Routing.ChannelMap.IsCustomMapChanged += TrackCustomMap;
	}

	private void Channel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Level")
		{
			OnLevelChanged();
		}
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	private void OnLevelChanged()
	{
		this.LevelChanged?.Invoke();
	}

	private static void TrackCustomMap(bool isCustomMap)
	{
		AudioSettingsCustomMapEvent.Publish(isCustomMap);
	}

	public DigitalAudio.Types.Setup Serialize()
	{
		DigitalAudio.Types.Setup setup = new DigitalAudio.Types.Setup();
		setup.MonitorOnMains = MonitorOnMains;
		setup.EnableSdiNdiDevice = SdiNdiOutputActive;
		setup.MainOutputDevice = MainOutputDestination.Serialize();
		setup.MonitorDevice = MonitorOutputDestination.Serialize();
		setup.SdiNdiDevice = SdiNdiOutputDestination.Serialize();
		setup.DisableMainOutputDevice = DisableMainOutputDevice;
		setup.Buses.AddRange(Buses.Select((Bus b) => b.Serialize()));
		return setup;
	}

	public void Deserialize(DigitalAudio.Types.Setup protoAudioSetup)
	{
		MonitorOnMains = protoAudioSetup.MonitorOnMains;
		SdiNdiOutputActive = protoAudioSetup.EnableSdiNdiDevice;
		DisableMainOutputDevice = protoAudioSetup.DisableMainOutputDevice;
		Buses.Resize(protoAudioSetup.Buses.Count);
		int num = 0;
		foreach (DigitalAudio.Types.Bus bus in protoAudioSetup.Buses)
		{
			Buses.ElementAtOrDefault(num++)?.Deserialize(bus);
		}
		MainOutputDestination.Deserialize(protoAudioSetup.MainOutputDevice, findOutputDevice);
		MonitorOutputDestination.Deserialize(protoAudioSetup.MonitorDevice, findOutputDevice);
		SdiNdiOutputDestination.Deserialize(protoAudioSetup.SdiNdiDevice, findOutputDevice);
		IAudioOutputDevice? findOutputDevice(DigitalAudio.Types.Device protoAudioDevice)
		{
			return _systemOutputDevices.FindDevice(protoAudioDevice?.RenderID ?? string.Empty);
		}
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.Audio.Types.SettingsDocument protoAudioSettings)
	{
		MonitorOnMains = protoAudioSettings.MonitorOnMains;
		MonitorOutputDestination.AudioDevice = _systemOutputDevices.FindDevice(protoAudioSettings.MonitorDevice?.RenderID ?? string.Empty);
		Pro.SerializationInterop.RVProtoData.Audio.Types.OutputSetup protoOutputSetup = protoAudioSettings.OutputSetup;
		if (protoOutputSetup == null)
		{
			return;
		}
		if (protoOutputSetup.PhysicalChanels.Any())
		{
			MainOutputDestination.Routing.ChannelSet.Resize(protoOutputSetup.PhysicalChanels.Count);
			foreach (Pro.SerializationInterop.RVProtoData.Audio.Types.PhysicalChannel physicalChanel in protoOutputSetup.PhysicalChanels)
			{
				MainOutputDestination.Routing.ChannelSet.ElementAtOrDefault((int)physicalChanel.Index)?.Deserialize(physicalChanel);
			}
		}
		if (protoOutputSetup.LogicalChannels.Any())
		{
			Buses.Resize(protoOutputSetup.LogicalChannels.Count);
			MainOutputDestination.Routing.ChannelMap.ClearMap();
			foreach (Pro.SerializationInterop.RVProtoData.Audio.Types.LogicalChannel logicalChannel in protoOutputSetup.LogicalChannels)
			{
				Bus bus = Buses.ElementAtOrDefault((int)logicalChannel.Index);
				if (bus == null)
				{
					continue;
				}
				bus.Deserialize(logicalChannel);
				foreach (Pro.SerializationInterop.RVProtoData.Audio.Types.LogicalChannel.Types.OutputChannel physicalAudioChannel in logicalChannel.PhysicalAudioChannels)
				{
					DeviceChannel deviceChannel = MainOutputDestination.Routing.ChannelSet.ElementAtOrDefault((int)physicalAudioChannel.Index);
					if (deviceChannel != null)
					{
						MainOutputDestination.Routing.ChannelMap.ToggleOn(bus, deviceChannel);
					}
				}
			}
		}
		MainOutputDestination.Routing.MasterChannel.Level = protoOutputSetup.MasterLevel;
		MainOutputDestination.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
		{
			c.Delay = TimeSlice.FromSeconds(protoOutputSetup.AudioDelay);
		});
		MainOutputDestination.AudioDevice = _systemOutputDevices.FindDevice(protoOutputSetup.AudioDevice?.RenderID ?? string.Empty);
	}
}
