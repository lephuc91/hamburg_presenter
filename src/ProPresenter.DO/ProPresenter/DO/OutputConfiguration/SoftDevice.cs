using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public class SoftDevice : DeviceBase, IAlphaSettings
{
	private DeviceType _deviceType;

	private string _softDeviceName = string.Empty;

	private string _model = string.Empty;

	private string _serial = string.Empty;

	private string _vendor = string.Empty;

	private string _deviceID = string.Empty;

	private int _modeIndex;

	private DeviceMode? _deserializedMode;

	private static int _nextNDIIndex;

	private static readonly ObservableCollection<DeviceMode> _availableNDIModes;

	private static readonly Dictionary<string, SoftDevice> _softDevicesByName;

	public override DeviceType DeviceType => _deviceType;

	public override string Name => SoftDeviceName;

	public string SoftDeviceName
	{
		get
		{
			return _softDeviceName;
		}
		set
		{
			if (_softDeviceName == value)
			{
				return;
			}
			if (_softDevicesByName.TryGetValue(value, out SoftDevice value2) && value2 != this)
			{
				base.ValidationError = (LocalizedStrings.Get("SCREEN_CONFIGURATION_NDI_DUPLICATE_NAME_title"), LocalizedStrings.Get("SCREEN_CONFIGURATION_NDI_DUPLICATE_NAME_body"));
			}
			else
			{
				base.ValidationError = null;
			}
			SetValue("SoftDeviceName", ref _softDeviceName, value, (Action<string, string>?)delegate
			{
				OnPropertyChanged("Name");
				OnPropertyChanged("DeviceName");
				if (!base.ValidationError.HasValue)
				{
					OnDataChanged();
				}
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public override Rect<double> Bounds => new Rect<double>(Vector2<double>.Zero, DeviceMode.Size.Cast<double>());

	public override string Model => _model;

	public override string Serial => _serial;

	public override string DeviceName => _softDeviceName;

	public override string Vendor => _vendor;

	public override string DeviceID => _deviceID;

	public override int ModeIndex
	{
		get
		{
			if (_deserializedMode == null)
			{
				return _modeIndex;
			}
			return _deserializedMode.ModeIndex;
		}
	}

	public override DeviceModeBase DeviceMode => _deserializedMode ?? _availableNDIModes[_modeIndex];

	public override bool IsAttached => true;

	public static ImmutableObservableCollection<DeviceMode> AvailableNDIModes { get; private set; }

	public override bool CanChangeModes => (AvailableNDIModes?.Count ?? 0) > 0;

	public IDeviceSpecificAlphaKeySettings? HardwareSettings => null;

	public override bool SupportsAlphaBlending => true;

	public override ObjectBinder<IDevice, IOutputDisplay> Bind(IEntityFactory entityFactory, IOutputDisplay entity)
	{
		ObjectBinder<IDevice, IOutputDisplay> objectBinder = base.Bind(entityFactory, entity);
		objectBinder.Bind((IDevice l) => l.WhenPropertyChanges("DeviceType"), (IOutputDisplay r) => r.Type.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Type.Set(l.DeviceType.ToEntityDisplayType());
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((SoftDevice)l)._deviceType = r.Type.Value.ToDeviceType();
		}).Bind((IDevice l) => l.WhenPropertyChanges("Name"), (IOutputDisplay r) => r.Name.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Name.Set(l.Name);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((SoftDevice)l).SoftDeviceName = ((!_softDevicesByName.ContainsKey(r.Name.Value)) ? r.Name.Value : GetNextNDIName());
		}).Bind((IDevice l) => l.WhenPropertyChanges("Model"), (IOutputDisplay r) => r.Model.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Model.Set(l.Model);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((SoftDevice)l)._model = r.Model.Value;
		})
			.Bind((IDevice l) => l.WhenPropertyChanges("Serial"), (IOutputDisplay r) => r.Serial.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.Serial.Set(l.Serial);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((SoftDevice)l)._serial = r.Serial.Value;
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("Vendor"), (IOutputDisplay r) => r.Vendor.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.Vendor.Set(l.Vendor);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((SoftDevice)l)._vendor = r.Vendor.Value;
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
				int value = (int)r.ModeIndex.Value;
				((SoftDevice)l)._modeIndex = value;
				Pro.SerializationInterop.RVProtoData.DisplayMode mode = new Pro.SerializationInterop.RVProtoData.DisplayMode
				{
					Height = r.Mode.Value.Height.Value,
					Interlaced = r.Mode.Value.Interlaced.Value,
					Name = r.Mode.Value.Name.Value,
					RefreshRate = r.Mode.Value.RefreshRate.Value,
					Width = r.Mode.Value.Width.Value
				};
				((SoftDevice)l)._deserializedMode = ((value < 0) ? new CustomDeviceMode(mode) : new DeviceMode(mode, value));
				ObjectBinder<IDeviceMode, IDisplayMode> objectBinder3 = l.DeviceMode.Bind(entityFactory, r.Mode.Value);
				objectBinder3.InitializeLeftFromRight();
				r.Mode.Value.RegisterLinkedDisposable(objectBinder3);
			})
			.Bind((IDevice l) => l.WhenPropertyChanges("DeviceID"), (IOutputDisplay r) => r.RenderId.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.RenderId.Set(l.DeviceID);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				((SoftDevice)l)._deviceID = r.RenderId.Value;
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				entity.RenderFormat.Set(IOutputDisplay.Types.RenderFormat.Sdr);
			});
		return objectBinder;
	}

	static SoftDevice()
	{
		_nextNDIIndex = 1;
		_softDevicesByName = new Dictionary<string, SoftDevice>();
		_availableNDIModes = new ObservableCollection<DeviceMode>();
		AvailableNDIModes = new ImmutableObservableCollection<DeviceMode>(_availableNDIModes);
	}

	public override void ChangeMode(DeviceMode mode)
	{
		_modeIndex = mode.ModeIndex;
		_deserializedMode = ((_modeIndex == -1) ? mode : _availableNDIModes[_modeIndex]);
		NotifyModeChanged();
	}

	public override OutputDisplay Serialize()
	{
		OutputDisplay outputDisplay = base.Serialize();
		outputDisplay.Name = SoftDeviceName;
		return outputDisplay;
	}

	public static void SetAvailableNDIModes(IEnumerable<IVideoMode> availableNDIModes)
	{
		foreach (IVideoMode availableNDIMode in availableNDIModes)
		{
			_availableNDIModes.Add(new DeviceMode(availableNDIMode));
		}
	}

	private static string GetNextNDIName()
	{
		string text;
		do
		{
			text = $"{Environment.MachineName.ToLower()} - NDI {_nextNDIIndex++}";
		}
		while (_softDevicesByName.ContainsKey(text));
		return text;
	}

	public static SoftDevice CreateNDIDevice(DeviceMode mode)
	{
		if (mode.ModeIndex >= 0 && (mode.ModeIndex >= _availableNDIModes.Count || _availableNDIModes[mode.ModeIndex] != mode))
		{
			throw new NotSupportedException("Non-NDI mode passed to CreateNDIDevice.");
		}
		SoftDevice softDevice = new SoftDevice
		{
			_deviceType = DeviceType.NDI,
			_softDeviceName = GetNextNDIName(),
			_deviceID = "ndi:" + Guid.NewGuid(),
			_modeIndex = mode.ModeIndex
		};
		if (mode is CustomDeviceMode)
		{
			softDevice._deserializedMode = mode;
		}
		_softDevicesByName.Add(softDevice.SoftDeviceName, softDevice);
		return softDevice;
	}

	public static SoftDevice FromProtoOutputDisplay(OutputDisplay protoOutputDisplay)
	{
		SoftDevice softDevice = new SoftDevice();
		softDevice.Deserialize(protoOutputDisplay);
		return softDevice;
	}

	protected override void OnDeserialize(OutputDisplay protoOutputDisplay)
	{
		_deviceType = protoOutputDisplay.Type.ToDeviceType();
		SoftDeviceName = ((!_softDevicesByName.ContainsKey(protoOutputDisplay.Name)) ? protoOutputDisplay.Name : GetNextNDIName());
		_model = protoOutputDisplay.Model;
		_serial = protoOutputDisplay.Serial;
		_vendor = protoOutputDisplay.Vendor;
		_deviceID = protoOutputDisplay.RenderId;
		int modeIndex = (int)protoOutputDisplay.ModeIndex;
		_deserializedMode = ((modeIndex < 0) ? new CustomDeviceMode(protoOutputDisplay.Mode) : new DeviceMode(protoOutputDisplay.Mode, modeIndex));
		_softDevicesByName[_softDeviceName] = this;
	}

	internal static void ClearCacheDevice()
	{
		_nextNDIIndex = 1;
		_softDevicesByName.Clear();
	}
}
