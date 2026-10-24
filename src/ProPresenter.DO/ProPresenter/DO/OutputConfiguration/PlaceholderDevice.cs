using System;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class PlaceholderDevice : DeviceBase
{
	private string _placeholderName = LocalizedStrings.Get("SCREEN_CONFIGURATION_PLACEHOLDER_name");

	private Guid _deviceID = Guid.NewGuid();

	public override DeviceType DeviceType => DeviceType.Placeholder;

	public override string Name => _placeholderName;

	public string PlaceholderDeviceName
	{
		get
		{
			return _placeholderName;
		}
		set
		{
			SetValue("PlaceholderDeviceName", ref _placeholderName, value, (Action<string, string>?)delegate
			{
				OnDataChanged();
				OnPropertyChanged("Name");
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public override Rect<double> Bounds => new Rect<double>(Vector2<double>.Zero, DeviceMode.Size.Cast<double>());

	public override string Model => string.Empty;

	public override string Serial => string.Empty;

	public override string DeviceName => string.Empty;

	public override string Vendor => string.Empty;

	public override string DeviceID => _deviceID.ToString();

	public override int ModeIndex => 0;

	public override DeviceModeBase DeviceMode => PlaceholderDeviceMode;

	public override bool IsAttached => true;

	public PlaceholderDeviceMode PlaceholderDeviceMode { get; }

	public override ObjectBinder<IDevice, IOutputDisplay> Bind(IEntityFactory entityFactory, IOutputDisplay entity)
	{
		ObjectBinder<IDevice, IOutputDisplay> objectBinder = base.Bind(entityFactory, entity);
		objectBinder.Bind((IDevice l) => l.WhenPropertyChanges("Name"), (IOutputDisplay r) => r.Name.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Name.Set(l.Name);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			((PlaceholderDevice)l).PlaceholderDeviceName = r.Name.Value;
		}).Bind((IDevice l) => l.WhenPropertyChanges("Bounds"), (IOutputDisplay r) => r.Bounds.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.Bounds.Set(l.Bounds.ToRect());
		}, delegate(IOutputDisplay r, IDevice l)
		{
			Rect<double> rect = r.Bounds.Value.ToRectd();
			if (l.DeviceMode is PlaceholderDeviceMode placeholderDeviceMode)
			{
				placeholderDeviceMode.Width = (int)rect.Width;
				placeholderDeviceMode.Height = (int)rect.Height;
			}
		}).Bind((IDevice l) => l.WhenPropertyChanges("DeviceMode"), (IOutputDisplay r) => r.Mode.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			IDisplayMode displayMode = entityFactory.Create<IDisplayMode>();
			ObjectBinder<IDeviceMode, IDisplayMode> objectBinder2 = l.DeviceMode.Bind(entityFactory, displayMode);
			objectBinder2.InitializeRightFromLeft();
			displayMode.RegisterLinkedDisposable(objectBinder2);
			r.Mode.Set(displayMode);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			ObjectBinder<IDeviceMode, IDisplayMode> objectBinder3 = l.DeviceMode.Bind(entityFactory, r.Mode.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Mode.Value.RegisterLinkedDisposable(objectBinder3);
		})
			.Bind((IDevice l) => l.WhenPropertyChanges("DeviceID"), (IOutputDisplay r) => r.RenderId.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
			{
				r.RenderId.Set(l.DeviceID);
			}, delegate(IOutputDisplay r, IDevice l)
			{
				if (Guid.TryParse(r.RenderId.Value, out var result))
				{
					((PlaceholderDevice)l)._deviceID = result;
				}
			})
			.DoOnInitializeRightFromLeft(delegate
			{
				entity.Type.Set(IOutputDisplay.Types.Type.Custom);
				entity.Model.Set(Model);
				entity.Serial.Set(Serial);
				entity.DeviceName.Set(DeviceName);
				entity.Vendor.Set(Vendor);
				entity.ModeIndex.Set((uint)ModeIndex);
				entity.RenderFormat.Set(IOutputDisplay.Types.RenderFormat.Sdr);
			});
		return objectBinder;
	}

	public PlaceholderDevice(Vector2<int> size)
		: this(new PlaceholderDeviceMode(size.X, size.Y))
	{
	}

	private PlaceholderDevice(PlaceholderDeviceMode mode)
	{
		PlaceholderDeviceMode = mode;
		PlaceholderDeviceMode.SizeChanged += base.OnDataChanged;
		PlaceholderDeviceMode.SizeChanged += delegate
		{
			OnPropertyChanged("Bounds");
		};
	}

	protected override void OnDeserialize(OutputDisplay protoOutputDisplay)
	{
		_placeholderName = protoOutputDisplay.Name;
		PlaceholderDeviceMode.Deserialize(protoOutputDisplay.Mode, 0);
		if (Guid.TryParse(protoOutputDisplay.RenderId, out var result))
		{
			_deviceID = result;
		}
	}

	public override void ChangeMode(DeviceMode mode)
	{
		throw new InvalidOperationException("Changing the mode on a placeholder device is not supported");
	}
}
