using System;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public abstract class DeviceBase : NotifyPropertyChangedBase, IDevice, INotifyPropertyChanged
{
	private int _videoDelay;

	public abstract DeviceType DeviceType { get; }

	public abstract string Name { get; }

	public abstract Rect<double> Bounds { get; }

	public abstract string Model { get; }

	public abstract string Serial { get; }

	public abstract string DeviceName { get; }

	public abstract string Vendor { get; }

	public abstract string DeviceID { get; }

	public abstract int ModeIndex { get; }

	IDeviceMode IDevice.DeviceMode => DeviceMode;

	public abstract DeviceModeBase DeviceMode { get; }

	public abstract bool IsAttached { get; }

	public virtual bool CanChangeModes => false;

	public virtual bool IsPrimaryMonitor => false;

	public virtual bool SupportsAlphaBlending => false;

	public virtual IReadOnlyList<HdrFormats> AvailableHdrFormats => Enum.GetValues<HdrFormats>();

	public virtual HdrFormats SelectedHdrFormat { get; set; }

	public virtual double HdrMaxNitsOffset { get; set; }

	public virtual bool SupportsHdrRendering => false;

	public int VideoDelay
	{
		get
		{
			return _videoDelay;
		}
		set
		{
			SetValue("VideoDelay", ref _videoDelay, value, OnDataChanged);
		}
	}

	public (string ErrorTitle, string ErrorContent)? ValidationError { get; set; }

	public event System.Action? DataChanged;

	public virtual ObjectBinder<IDevice, IOutputDisplay> Bind(IEntityFactory entityFactory, IOutputDisplay entity)
	{
		ObjectBinder<IDevice, IOutputDisplay> objectBinder = new ObjectBinder<IDevice, IOutputDisplay>(this, entity);
		objectBinder.Bind((IDevice l) => l.WhenPropertyChanges("VideoDelay"), (IOutputDisplay r) => r.VideoDelay.WhenValueChanges, delegate(IDevice l, IOutputDisplay r)
		{
			r.VideoDelay.Set(l.VideoDelay);
		}, delegate(IOutputDisplay r, IDevice l)
		{
			l.VideoDelay = r.VideoDelay.Value;
		});
		return objectBinder;
	}

	public virtual OutputDisplay Serialize()
	{
		return new OutputDisplay
		{
			Type = DeviceType.ToProtoDisplayType(),
			Name = (Name ?? string.Empty),
			Model = (Model ?? string.Empty),
			Serial = (Serial ?? string.Empty),
			DeviceName = (DeviceName ?? string.Empty),
			Vendor = (Vendor ?? string.Empty),
			ModeIndex = (uint)ModeIndex,
			Bounds = Bounds.ToProtoRect(),
			Mode = DeviceMode.Serialize(),
			RenderId = (DeviceID ?? string.Empty),
			VideoDelay = VideoDelay,
			RenderFormat = OutputDisplay.Types.RenderFormat.Sdr,
			Blackmagic = new OutputDisplay.Types.Blackmagic()
		};
	}

	public abstract void ChangeMode(DeviceMode mode);

	protected void OnDataChanged()
	{
		this.DataChanged?.Invoke();
	}

	protected internal void Deserialize(OutputDisplay protoOutputDisplay)
	{
		VideoDelay = protoOutputDisplay.VideoDelay;
		OnDeserialize(protoOutputDisplay);
	}

	protected abstract void OnDeserialize(OutputDisplay protoOutputDisplay);

	protected void NotifyModeChanged()
	{
		OnPropertyChanged("ModeIndex");
		OnPropertyChanged("DeviceMode");
		OnDataChanged();
	}
}
