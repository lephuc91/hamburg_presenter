using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public class PhysicalDevice : DeviceBase, IAlphaSettings, IPhysicalDevice, IDevice, INotifyPropertyChanged
{
	private const double HDRMAXNITSOFFSET_DEFAULT = 100.0;

	private const double HDRMAXNITSOFFSET_FACTOR = 10.0;

	private IVideoOutputDevice? _reDevice;

	private DeviceType _deviceType = DeviceType.Screen;

	private string _name = string.Empty;

	private string _model = string.Empty;

	private string _serial = string.Empty;

	private string _deviceName = string.Empty;

	private string _vendor = string.Empty;

	private string _deviceID = string.Empty;

	private int _modeIndex;

	private readonly ObservableCollection<DeviceMode> _availableModes;

	private readonly ImmutableObservableCollection<DeviceMode> _immutableAvailableModes;

	private DeviceMode? _detachedMode;

	private HdrFormats _selectedHdrFormat;

	private double _hdrMaxNitsOffset = 100.0;

	private static VideoOutputDeviceCollection? _reDevices;

	private static readonly Dictionary<string, PhysicalDevice> _knownDevices = new Dictionary<string, PhysicalDevice>();

	private static readonly ObservableCollection<PhysicalDevice> _attachedPhysicalDevices = new ObservableCollection<PhysicalDevice>();

	private static readonly ImmutableObservableCollection<PhysicalDevice> _immutableAttachedPhysicalDevices = new ImmutableObservableCollection<PhysicalDevice>(_attachedPhysicalDevices);

	public override DeviceType DeviceType => _deviceType;

	public override string Name => _name;

	public override Rect<double> Bounds => new Rect<double>(Vector2<double>.Zero, DeviceMode.Size.Cast<double>());

	public override string Model => _model;

	public override string Serial => _serial;

	public override string DeviceName => _deviceName;

	public override string Vendor => _vendor;

	public override string DeviceID => _deviceID;

	public override int ModeIndex => _modeIndex;

	public override DeviceModeBase DeviceMode => _detachedMode ?? _availableModes[_modeIndex];

	public ImmutableObservableCollection<DeviceMode> AvailableModes => _immutableAvailableModes;

	public override bool IsAttached => _reDevice != null;

	public override bool CanChangeModes
	{
		get
		{
			ObservableCollection<DeviceMode> availableModes = _availableModes;
			if (availableModes == null)
			{
				return false;
			}
			return availableModes.Count > 1;
		}
	}

	public static ImmutableObservableCollection<PhysicalDevice> AttachedPhysicalDevices => _immutableAttachedPhysicalDevices;

	public static bool AnySDIDevicesAttached => _immutableAttachedPhysicalDevices.Any((PhysicalDevice pd) => pd.DeviceType == DeviceType.BlackmagicCard);

	public IDeviceSpecificAlphaKeySettings? HardwareSettings { get; private set; }

	public override bool IsPrimaryMonitor => _reDevice?.IsPrimaryMonitor ?? false;

	public override bool SupportsAlphaBlending { get; }

	public override bool SupportsHdrRendering { get; }

	public override HdrFormats SelectedHdrFormat
	{
		get
		{
			return _selectedHdrFormat;
		}
		set
		{
			SetValue("SelectedHdrFormat", ref _selectedHdrFormat, value, base.OnDataChanged);
		}
	}

	public override double HdrMaxNitsOffset
	{
		get
		{
			return _hdrMaxNitsOffset;
		}
		set
		{
			SetValue("HdrMaxNitsOffset", ref _hdrMaxNitsOffset, value, base.OnDataChanged);
		}
	}

	public override IReadOnlyList<HdrFormats> AvailableHdrFormats { get; }

	public override ObjectBinder<IDevice, IOutputDisplay> Bind(IEntityFactory entityFactory, IOutputDisplay right)
	{
		ObjectBinder<IDevice, IOutputDisplay> objectBinder = base.Bind(entityFactory, right);
		objectBinder.Bind((IDevice l) => l.WhenPropertyChanges("DeviceType"), (IOutputDisplay r) => r.Type.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Type.Set(l.DeviceType.ToEntityDisplayType());
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((PhysicalDevice)l)._deviceType = r.Type.Value.ToDeviceType();
		}).Bind((IDevice l) => l.WhenPropertyChanges("Name"), (IOutputDisplay r) => r.Name.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Name.Set(l.Name);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((PhysicalDevice)l)._name = r.Name.Value;
		}).Bind((IDevice l) => l.WhenPropertyChanges("Model"), (IOutputDisplay r) => r.Model.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Model.Set(l.Model);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((PhysicalDevice)l)._model = r.Model.Value;
		})
			.Bind((IDevice l) => l.WhenPropertyChanges("Serial"), (IOutputDisplay r) => r.Serial.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.Serial.Set(l.Serial);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l)._serial = r.Serial.Value;
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("DeviceName"), (IOutputDisplay r) => r.DeviceName.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.DeviceName.Set(l.DeviceName);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l)._deviceName = r.DeviceName.Value;
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("Vendor"), (IOutputDisplay r) => r.Vendor.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.Vendor.Set(l.Vendor);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l)._vendor = r.Vendor.Value;
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("DeviceMode"), (IOutputDisplay r) => r.Mode.WhenValueChanges.ToUnit().Merge(r.ModeIndex.WhenValueChanges.ToUnit()), delegate(IDevice l, IOutputDisplay r)
			{
				r.ModeIndex.Set((uint)l.ModeIndex);
				IDisplayMode displayMode = entityFactory.Create<IDisplayMode>();
				ObjectBinder<IDeviceMode, IDisplayMode> objectBinder2 = l.DeviceMode.Bind(entityFactory, displayMode);
				objectBinder2.InitializeRightFromLeft();
				displayMode.RegisterLinkedDisposable(objectBinder2);
				r.Mode.Set(displayMode);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l)._modeIndex = (int)r.ModeIndex.Value;
				if (!IsAttached)
				{
					((PhysicalDevice)l)._detachedMode = new DeviceMode(new Pro.SerializationInterop.RVProtoData.DisplayMode
					{
						Height = r.Mode.Value.Height.Value,
						Interlaced = r.Mode.Value.Interlaced.Value,
						Name = r.Mode.Value.Name.Value,
						RefreshRate = r.Mode.Value.RefreshRate.Value,
						Width = r.Mode.Value.Width.Value
					}, (int)r.ModeIndex.Value);
				}
				ObjectBinder<IDeviceMode, IDisplayMode> objectBinder3 = l.DeviceMode.Bind(entityFactory, r.Mode.Value);
				objectBinder3.InitializeLeftFromRight();
				r.Mode.Value.RegisterLinkedDisposable(objectBinder3);
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("DeviceID"), (IOutputDisplay r) => r.RenderId.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.RenderId.Set(l.DeviceID);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l)._deviceID = r.RenderId.Value;
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("SelectedHdrFormat"), (IOutputDisplay r) => r.RenderFormat.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.RenderFormat.Set(l.SelectedHdrFormat.ToEntityRenderFormat());
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l).SelectedHdrFormat = r.RenderFormat.Value.ToHdrFormats();
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("HdrMaxNitsOffset"), (IOutputDisplay r) => r.HdrMaxNitsOffset.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.HdrMaxNitsOffset.Set((int)(l.HdrMaxNitsOffset * 10.0));
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((PhysicalDevice)l).HdrMaxNitsOffset = (double)r.HdrMaxNitsOffset.Value / 10.0;
			})
			.Bind((IDevice l) => (!(l is PhysicalDevice propertyChangedObject)) ? Observable.Empty<PropertyChangedEventArgs>() : propertyChangedObject.WhenPropertyChanges("HardwareSettings"), (IOutputDisplay r) => r.HardwareOptions.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				if (l is PhysicalDevice physicalDevice)
				{
					IDeviceSpecificAlphaKeySettings hardwareSettings = physicalDevice.HardwareSettings;
					if (hardwareSettings != null)
					{
						IOutputDisplay.Types.IHardwareOptions.IBlackmagic blackmagic = entityFactory.Create<IOutputDisplay.Types.IHardwareOptions.IBlackmagic>();
						ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic> objectBinder4 = hardwareSettings.Bind(blackmagic.Value);
						objectBinder4.InitializeRightFromLeft();
						r.RegisterLinkedDisposable(objectBinder4);
						r.HardwareOptions.Set(blackmagic);
					}
				}
			}, delegate(IOutputDisplay r, IDevice l)
			{
				if (l is PhysicalDevice physicalDevice2)
				{
					IDeviceSpecificAlphaKeySettings hardwareSettings2 = physicalDevice2.HardwareSettings;
					if (hardwareSettings2 != null && r.HardwareOptions.Value is IOutputDisplay.Types.IHardwareOptions.IBlackmagic blackmagic2)
					{
						ObjectBinder<IDeviceSpecificAlphaKeySettings, IOutputDisplay.Types.IBlackmagic> objectBinder5 = hardwareSettings2.Bind(blackmagic2.Value);
						objectBinder5.InitializeLeftFromRight();
						r.RegisterLinkedDisposable(objectBinder5);
					}
				}
			});
		return objectBinder;
	}

	private PhysicalDevice(IVideoOutputDevice device)
		: this()
	{
		if (!device.DeviceType.IsHardOutput())
		{
			throw new NotSupportedException("Can't create a physical device from a soft output.");
		}
		if (device.DeviceType == VideoOutputDeviceType.DVI)
		{
			_deviceType = DeviceType.Screen;
			AvailableHdrFormats = new global::_003C_003Ez__ReadOnlyArray<HdrFormats>(new HdrFormats[2]
			{
				HdrFormats.Sdr,
				HdrFormats.Rec2100PQ
			});
		}
		else
		{
			_deviceType = DeviceType.BlackmagicCard;
			if (device.SupportsExternalAlphaKey || device.SupportsInternalAlphaKey)
			{
				List<BlackmagicAlphaKeyType> list = new List<BlackmagicAlphaKeyType>();
				if (device.SupportsExternalAlphaKey)
				{
					list.Add(BlackmagicAlphaKeyType.External);
				}
				if (device.SupportsInternalAlphaKey)
				{
					list.Add(BlackmagicAlphaKeyType.Internal);
				}
				HardwareSettings = new BlackMagicAlphaKeySettings(list);
				HardwareSettings.DataModified += base.OnDataChanged;
			}
		}
		_name = device.Name;
		_model = device.Model;
		_serial = string.Empty;
		_deviceName = device.DeviceName;
		_vendor = device.Vendor;
		_deviceID = device.UUID;
		_modeIndex = device.ActiveMode;
		SupportsAlphaBlending = device.SupportsAlphaKey;
		SupportsHdrRendering = device.SupportsHdrOutput;
		Attach(device);
	}

	protected PhysicalDevice()
	{
		_availableModes = new ObservableCollection<DeviceMode>();
		_immutableAvailableModes = new ImmutableObservableCollection<DeviceMode>(_availableModes);
		AvailableHdrFormats = Enum.GetValues<HdrFormats>();
	}

	public override void ChangeMode(DeviceMode mode)
	{
		_modeIndex = mode.ModeIndex;
		_detachedMode = (IsAttached ? null : mode);
		NotifyModeChanged();
	}

	public static void TrackRenderEngineDevices(VideoOutputDeviceCollection videoOutputs)
	{
		if (_reDevices != null)
		{
			_reDevices.CollectionChanged -= OnTrackedOutputsChanged;
			SyncCollections();
		}
		_reDevices = videoOutputs;
		if (_reDevices != null)
		{
			_reDevices.CollectionChanged += OnTrackedOutputsChanged;
			SyncCollections();
		}
	}

	public static PhysicalDevice FromProtoOutputDisplay(OutputDisplay protoOutputDisplay)
	{
		if (_knownDevices.TryGetValue(protoOutputDisplay.RenderId, out PhysicalDevice value))
		{
			value.Deserialize(protoOutputDisplay);
		}
		else
		{
			value = new PhysicalDevice();
			value.Deserialize(protoOutputDisplay);
			_knownDevices.Add(value.DeviceID, value);
		}
		return value;
	}

	public static PhysicalDevice FromEntityOutputDisplay(IOutputDisplay outputDisplay)
	{
		if (!_knownDevices.TryGetValue(outputDisplay.RenderId.Value, out PhysicalDevice value))
		{
			value = new PhysicalDevice();
			_knownDevices.Add(outputDisplay.RenderId.Value, value);
		}
		return value;
	}

	public static bool TryGetDevice(string deviceID, [MaybeNullWhen(false)] out PhysicalDevice device)
	{
		return _knownDevices.TryGetValue(deviceID, out device);
	}

	private static void OnTrackedOutputsChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		SyncCollections();
	}

	private static void SyncCollections()
	{
		Dictionary<string, IVideoOutputDevice> dictionary = _reDevices?.Where((IVideoOutputDevice dev) => dev.DeviceType.IsHardOutput()).Distinct((IVideoOutputDevice v) => v.UUID).ToDictionary((IVideoOutputDevice redev) => redev.UUID);
		foreach (KeyValuePair<string, PhysicalDevice> knownDevice in _knownDevices)
		{
			string key = knownDevice.Key;
			PhysicalDevice value = knownDevice.Value;
			if (dictionary != null && dictionary.TryGetValue(key, out var value2))
			{
				value.Attach(value2);
				dictionary.Remove(key);
			}
			else
			{
				value.Detach();
			}
		}
		IEnumerable<KeyValuePair<string, IVideoOutputDevice>> enumerable = dictionary;
		foreach (KeyValuePair<string, IVideoOutputDevice> item in enumerable ?? Enumerable.Empty<KeyValuePair<string, IVideoOutputDevice>>())
		{
			if (!_knownDevices.ContainsKey(item.Key))
			{
				_knownDevices.Add(item.Key, new PhysicalDevice(item.Value));
			}
		}
	}

	public override OutputDisplay Serialize()
	{
		OutputDisplay outputDisplay = base.Serialize();
		HardwareSettings?.Serialize(outputDisplay);
		outputDisplay.RenderFormat = SelectedHdrFormat.Serialize();
		outputDisplay.HdrMaxNitsOffset = (int)(HdrMaxNitsOffset * 10.0);
		return outputDisplay;
	}

	protected override void OnDeserialize(OutputDisplay protoOutputDisplay)
	{
		_deviceType = protoOutputDisplay.Type.ToDeviceType();
		_name = protoOutputDisplay.Name;
		_model = protoOutputDisplay.Model;
		_serial = protoOutputDisplay.Serial;
		_deviceName = protoOutputDisplay.DeviceName;
		_vendor = protoOutputDisplay.Vendor;
		_deviceID = protoOutputDisplay.RenderId;
		_modeIndex = (int)protoOutputDisplay.ModeIndex;
		if (!IsAttached)
		{
			_detachedMode = new DeviceMode(protoOutputDisplay.Mode, (int)protoOutputDisplay.ModeIndex);
		}
		HardwareSettings?.Deserialize(protoOutputDisplay);
		SelectedHdrFormat = protoOutputDisplay.RenderFormat.Deserialize();
		HdrMaxNitsOffset = (double)protoOutputDisplay.HdrMaxNitsOffset / 10.0;
	}

	private void Attach(IVideoOutputDevice? newDevice)
	{
		IVideoOutputDevice reDevice = _reDevice;
		if (reDevice == newDevice || (reDevice != null && newDevice != null))
		{
			return;
		}
		if (reDevice != null)
		{
			_detachedMode = _availableModes[reDevice.ActiveMode];
			int num = _attachedPhysicalDevices.IndexOf(this);
			if (num >= 0)
			{
				_attachedPhysicalDevices.RemoveAt(num);
			}
		}
		else
		{
			_availableModes.Clear();
			foreach (IVideoMode mode in newDevice.Modes)
			{
				_availableModes.Add(new DeviceMode(mode));
			}
			if (_detachedMode != null)
			{
				_modeIndex = _detachedMode.ModeIndex;
				_detachedMode = null;
			}
			_attachedPhysicalDevices.Add(this);
		}
		_reDevice = newDevice;
		OnPropertyChanged("IsAttached");
	}

	private void Detach()
	{
		Attach(null);
	}
}
