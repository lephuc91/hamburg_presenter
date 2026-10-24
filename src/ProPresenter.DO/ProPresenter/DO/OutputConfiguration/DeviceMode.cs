using System.Reactive.Linq;
using System.Text;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;
using Pro.ssAPI.Devices;

namespace ProPresenter.DO.OutputConfiguration;

public class DeviceMode : DeviceModeBase
{
	private string _name = string.Empty;

	private Vector2<int> _size;

	private double _refreshRate;

	private bool _interlaced;

	private int _modeIndex;

	public override string Name => _name;

	public override Vector2<int> Size => _size;

	public override double RefreshRate => _refreshRate;

	public override bool Interlaced => _interlaced;

	public virtual int ModeIndex => _modeIndex;

	public override ObjectBinder<IDeviceMode, IDisplayMode> Bind(IEntityFactory entityFactory, IDisplayMode right)
	{
		ObjectBinder<IDeviceMode, IDisplayMode> objectBinder = new ObjectBinder<IDeviceMode, IDisplayMode>(this, right);
		objectBinder.Bind((IDeviceMode l) => l.WhenPropertyChanges("Name"), (IDisplayMode r) => r.Name.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
		{
			r.Name.Set(l.Name);
		}, delegate(IDisplayMode r, IDeviceMode l)
		{
			((DeviceMode)l)._name = r.Name.Value;
		}).Bind((IDeviceMode l) => l.WhenPropertyChanges("Size"), (IDisplayMode r) => r.Width.WhenValueChanges.Merge(r.Height.WhenValueChanges), delegate(IDeviceMode l, IDisplayMode r)
		{
			r.Width.Set((uint)l.Size.X);
			r.Height.Set((uint)l.Size.Y);
		}, delegate(IDisplayMode r, IDeviceMode l)
		{
			((DeviceMode)l)._size = new Vector2<int>((int)r.Width.Value, (int)r.Height.Value);
		}).Bind((IDeviceMode l) => l.WhenPropertyChanges("RefreshRate"), (IDisplayMode r) => r.RefreshRate.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
		{
			r.RefreshRate.Set(l.RefreshRate);
		}, delegate(IDisplayMode r, IDeviceMode l)
		{
			((DeviceMode)l)._refreshRate = r.RefreshRate.Value;
		})
			.Bind((IDeviceMode l) => l.WhenPropertyChanges("Interlaced"), (IDisplayMode r) => r.Interlaced.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
			{
				r.Interlaced.Set(l.Interlaced);
			}, delegate(IDisplayMode r, IDeviceMode l)
			{
				((DeviceMode)l)._interlaced = r.Interlaced.Value;
			});
		return objectBinder;
	}

	public DeviceMode(IVideoMode videoMode)
	{
		_name = videoMode.Name;
		_size = videoMode.Size;
		_refreshRate = videoMode.Frequency;
		_interlaced = videoMode.Interlaced;
		_modeIndex = videoMode.ModeIndex;
	}

	public DeviceMode(Pro.SerializationInterop.RVProtoData.DisplayMode mode, int modeIndex)
	{
		Deserialize(mode, modeIndex);
	}

	public static string GenerateNDIModeName(Pro.SerializationInterop.RVProtoData.DisplayMode mode)
	{
		if (mode == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(mode.Width);
		stringBuilder.Append("x");
		stringBuilder.Append(mode.Height);
		stringBuilder.Append(mode.Interlaced ? "i" : "p");
		stringBuilder.Append(mode.Interlaced ? (mode.RefreshRate * 2.0) : mode.RefreshRate);
		return stringBuilder.ToString();
	}

	protected internal override void Deserialize(Pro.SerializationInterop.RVProtoData.DisplayMode mode, int modeIndex)
	{
		_name = mode.Name;
		_size = new Vector2<int>((int)mode.Width, (int)mode.Height);
		_refreshRate = mode.RefreshRate;
		_interlaced = mode.Interlaced;
		_modeIndex = modeIndex;
	}
}
