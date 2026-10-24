using System;
using Pro.Common.Components;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

public class ColorAdjustmentOptions : LinkedNotifyPropertyChangedBase, ICloneable<ColorAdjustmentOptions>
{
	private const double RedDefaultValue = 0.0;

	private const double GreenDefaultValue = 0.0;

	private const double BlueDefaultValue = 0.0;

	private const double GammaDefaultValue = 0.0;

	private const double BlackDefaultValue = 0.0;

	private const double BrightnessDefaultValue = 0.0;

	private const double ContrastDefaultValue = 0.0;

	private double _gamma;

	private double _blackLevel;

	private double _redLevel;

	private double _greenLevel;

	private double _blueLevel;

	private double _brightness;

	private double _contrast;

	public double Gamma
	{
		get
		{
			return _gamma;
		}
		set
		{
			SetValue("Gamma", ref _gamma, value, OnColorAdjustmentChanged);
		}
	}

	public double BlackLevel
	{
		get
		{
			return _blackLevel;
		}
		set
		{
			SetValue("BlackLevel", ref _blackLevel, value, OnColorAdjustmentChanged);
		}
	}

	public double RedLevel
	{
		get
		{
			return _redLevel;
		}
		set
		{
			SetValue("RedLevel", ref _redLevel, value, OnColorAdjustmentChanged);
		}
	}

	public double GreenLevel
	{
		get
		{
			return _greenLevel;
		}
		set
		{
			SetValue("GreenLevel", ref _greenLevel, value, OnColorAdjustmentChanged);
		}
	}

	public double BlueLevel
	{
		get
		{
			return _blueLevel;
		}
		set
		{
			SetValue("BlueLevel", ref _blueLevel, value, OnColorAdjustmentChanged);
		}
	}

	public double Brightness
	{
		get
		{
			return _brightness;
		}
		set
		{
			SetValue("Brightness", ref _brightness, value, OnColorAdjustmentChanged);
		}
	}

	public double Contrast
	{
		get
		{
			return _contrast;
		}
		set
		{
			SetValue("Contrast", ref _contrast, value, OnColorAdjustmentChanged);
		}
	}

	public event Action<ColorAdjustmentOptions>? ColorAdjustmentChanged;

	public ObjectBinder<ColorAdjustmentOptions, IScreen.Types.IColorAdjustment> Bind(IScreen.Types.IColorAdjustment right)
	{
		ObjectBinder<ColorAdjustmentOptions, IScreen.Types.IColorAdjustment> objectBinder = new ObjectBinder<ColorAdjustmentOptions, IScreen.Types.IColorAdjustment>(this, right);
		objectBinder.Bind((ColorAdjustmentOptions l) => l.WhenPropertyChanges("Gamma"), (IScreen.Types.IColorAdjustment r) => r.Gamma.WhenValueChanges, delegate(ColorAdjustmentOptions l, IScreen.Types.IColorAdjustment r)
		{
			r.Gamma.Set(l.Gamma);
		}, delegate(IScreen.Types.IColorAdjustment r, ColorAdjustmentOptions l)
		{
			l.Gamma = r.Gamma.Value;
		}).Bind((ColorAdjustmentOptions l) => l.WhenPropertyChanges("BlackLevel"), (IScreen.Types.IColorAdjustment r) => r.BlackLevel.WhenValueChanges, delegate(ColorAdjustmentOptions l, IScreen.Types.IColorAdjustment r)
		{
			r.BlackLevel.Set(l.BlackLevel);
		}, delegate(IScreen.Types.IColorAdjustment r, ColorAdjustmentOptions l)
		{
			l.BlackLevel = r.BlackLevel.Value;
		}).Bind((ColorAdjustmentOptions l) => l.WhenPropertyChanges("RedLevel"), (IScreen.Types.IColorAdjustment r) => r.RedLevel.WhenValueChanges, delegate(ColorAdjustmentOptions l, IScreen.Types.IColorAdjustment r)
		{
			r.RedLevel.Set(l.RedLevel);
		}, delegate(IScreen.Types.IColorAdjustment r, ColorAdjustmentOptions l)
		{
			l.RedLevel = r.RedLevel.Value;
		})
			.Bind((ColorAdjustmentOptions l) => l.WhenPropertyChanges("GreenLevel"), (IScreen.Types.IColorAdjustment r) => r.GreenLevel.WhenValueChanges, delegate(ColorAdjustmentOptions l, IScreen.Types.IColorAdjustment r)
			{
				r.GreenLevel.Set(l.GreenLevel);
			}, delegate(IScreen.Types.IColorAdjustment r, ColorAdjustmentOptions l)
			{
				l.GreenLevel = r.GreenLevel.Value;
			})
			.Bind((ColorAdjustmentOptions l) => l.WhenPropertyChanges("BlueLevel"), (IScreen.Types.IColorAdjustment r) => r.BlueLevel.WhenValueChanges, delegate(ColorAdjustmentOptions l, IScreen.Types.IColorAdjustment r)
			{
				r.BlueLevel.Set(l.BlueLevel);
			}, delegate(IScreen.Types.IColorAdjustment r, ColorAdjustmentOptions l)
			{
				l.BlueLevel = r.BlueLevel.Value;
			});
		return objectBinder;
	}

	private void OnColorAdjustmentChanged()
	{
		this.ColorAdjustmentChanged?.Invoke(this);
	}

	protected internal Pro.SerializationInterop.RVProtoData.Screen.Types.ColorAdjustment Serialize()
	{
		return new Pro.SerializationInterop.RVProtoData.Screen.Types.ColorAdjustment
		{
			Gamma = Gamma,
			BlackLevel = BlackLevel,
			RedLevel = RedLevel,
			GreenLevel = GreenLevel,
			BlueLevel = BlueLevel,
			Brightness = Brightness,
			Contrast = Contrast
		};
	}

	protected internal void Deserialize(Pro.SerializationInterop.RVProtoData.Screen.Types.ColorAdjustment colorAdjustment)
	{
		if (colorAdjustment != null)
		{
			Gamma = colorAdjustment.Gamma;
			BlackLevel = colorAdjustment.BlackLevel;
			RedLevel = colorAdjustment.RedLevel;
			GreenLevel = colorAdjustment.GreenLevel;
			BlueLevel = colorAdjustment.BlueLevel;
			Brightness = colorAdjustment.Brightness;
			Contrast = colorAdjustment.Contrast;
		}
	}

	public ColorAdjustmentOptions Clone()
	{
		return new ColorAdjustmentOptions
		{
			Gamma = Gamma,
			BlackLevel = BlackLevel,
			RedLevel = RedLevel,
			GreenLevel = GreenLevel,
			BlueLevel = BlueLevel
		};
	}
}
