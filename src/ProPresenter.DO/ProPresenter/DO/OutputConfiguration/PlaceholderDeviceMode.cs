using System;
using System.Reactive.Linq;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class PlaceholderDeviceMode : DeviceModeBase
{
	private int _width;

	private int _height;

	public override string Name => $"{Width} x {Height}";

	public override Vector2<int> Size => new Vector2<int>(Width, Height);

	public override double RefreshRate => 0.0;

	public override bool Interlaced => false;

	public int Width
	{
		get
		{
			return _width;
		}
		set
		{
			SetValue("Width", ref _width, value, (Action<int, int>?)delegate
			{
				OnSizeChanged();
			}, (Predicate<int>?)null, referenceComparison: false);
		}
	}

	public int Height
	{
		get
		{
			return _height;
		}
		set
		{
			SetValue("Height", ref _height, value, (Action<int, int>?)delegate
			{
				OnSizeChanged();
			}, (Predicate<int>?)null, referenceComparison: false);
		}
	}

	public event System.Action? SizeChanged;

	public override ObjectBinder<IDeviceMode, IDisplayMode> Bind(IEntityFactory entityFactory, IDisplayMode right)
	{
		ObjectBinder<IDeviceMode, IDisplayMode> objectBinder = new ObjectBinder<IDeviceMode, IDisplayMode>(this, right);
		objectBinder.Bind((IDeviceMode l) => l.WhenPropertyChanges("Name"), (IDisplayMode r) => r.Name.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
		{
			r.Name.Set(l.Name);
		}, delegate
		{
		}).Bind((IDeviceMode l) => l.WhenPropertyChanges("Size"), (IDisplayMode r) => r.Width.WhenValueChanges.Merge(r.Height.WhenValueChanges), delegate(IDeviceMode l, IDisplayMode r)
		{
			r.Width.Set((uint)l.Size.X);
			r.Height.Set((uint)l.Size.Y);
		}, delegate(IDisplayMode r, IDeviceMode l)
		{
			((PlaceholderDeviceMode)l).Width = (int)r.Width.Value;
			((PlaceholderDeviceMode)l).Height = (int)r.Height.Value;
		}).Bind((IDeviceMode l) => l.WhenPropertyChanges("RefreshRate"), (IDisplayMode r) => r.RefreshRate.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
		{
			r.RefreshRate.Set(0.0);
		}, delegate
		{
		})
			.Bind((IDeviceMode l) => l.WhenPropertyChanges("Interlaced"), (IDisplayMode r) => r.Interlaced.WhenValueChanges, delegate(IDeviceMode l, IDisplayMode r)
			{
				r.Interlaced.Set(l.Interlaced);
			}, delegate
			{
			});
		return objectBinder;
	}

	public PlaceholderDeviceMode(int width, int height)
	{
		_width = width;
		_height = height;
	}

	private void OnSizeChanged()
	{
		OnPropertyChanged("Size");
		OnPropertyChanged("Name");
		this.SizeChanged?.Invoke();
	}

	protected internal override void Deserialize(Pro.SerializationInterop.RVProtoData.DisplayMode mode, int modeIndex)
	{
		_width = (int)mode.Width;
		_height = (int)mode.Height;
	}
}
