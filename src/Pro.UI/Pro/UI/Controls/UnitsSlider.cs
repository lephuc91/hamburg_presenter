using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Pro.UI.Controls;

public class UnitsSlider : Slider
{
	private static readonly DependencyPropertyKey ActualFillBrushPropertyKey = DependencyProperty.RegisterReadOnly("ActualFillBrush", typeof(Brush), typeof(UnitsSlider), new PropertyMetadata());

	public static readonly DependencyProperty ActualFillBrushProperty = ActualFillBrushPropertyKey.DependencyProperty;

	private static readonly DependencyPropertyKey FillBarOpacityPropertyKey = DependencyProperty.RegisterReadOnly("FillBarOpacity", typeof(double), typeof(UnitsSlider), new PropertyMetadata());

	public static readonly DependencyProperty FillBarOpacityProperty = FillBarOpacityPropertyKey.DependencyProperty;

	public static readonly DependencyProperty FillBrushProperty = DependencyProperty.Register("FillBrush", typeof(SolidColorBrush), typeof(UnitsSlider), new PropertyMetadata(new PropertyChangedCallback(OnFillBrushPropertyChanged)));

	public static readonly DependencyProperty FillModeProperty = DependencyProperty.Register("FillMode", typeof(UnitsSliderFillBarMode), typeof(UnitsSlider), new PropertyMetadata((object)UnitsSliderFillBarMode.None, new PropertyChangedCallback(OnFillModePropertyChanged)));

	public static readonly DependencyProperty UnitsProperty = DependencyProperty.Register("Units", typeof(string), typeof(UnitsSlider));

	private LinearGradientBrush? _featherBrush;

	private GradientStop? _featherStop1;

	private GradientStop? _featherStop2;

	public Brush ActualFillBrush
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(ActualFillBrushProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(ActualFillBrushPropertyKey, (object)value);
		}
	}

	public double FillBarOpacity
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(FillBarOpacityProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(FillBarOpacityPropertyKey, (object)value);
		}
	}

	public SolidColorBrush FillBrush
	{
		get
		{
			return (SolidColorBrush)((DependencyObject)this).GetValue(FillBrushProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillBrushProperty, (object)value);
		}
	}

	public UnitsSliderFillBarMode FillMode
	{
		get
		{
			return (UnitsSliderFillBarMode)((DependencyObject)this).GetValue(FillModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillModeProperty, (object)value);
		}
	}

	public string Units
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(UnitsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnitsProperty, (object)value);
		}
	}

	protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
	{
		base.OnMaximumChanged(oldMaximum, newMaximum);
		UpdateFillBar();
	}

	protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
	{
		base.OnMinimumChanged(oldMinimum, newMinimum);
		UpdateFillBar();
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		UpdateFillBar();
	}

	private static void OnFillBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		OnFillModePropertyChanged(d, e);
	}

	private static void OnFillModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		UnitsSlider obj = (UnitsSlider)(object)d;
		obj.UpdateFillBrush();
		obj.UpdateFillBar();
	}

	private void UpdateFillBar()
	{
		switch (FillMode)
		{
		case UnitsSliderFillBarMode.None:
			FillBarOpacity = 1.0;
			break;
		case UnitsSliderFillBarMode.Feather:
			if (_featherStop1 != null)
			{
				double num = base.Maximum - base.Minimum;
				double num2 = (base.Value - base.Minimum) / num;
				_featherStop1.Offset = (1.0 - num2) * 0.5;
				FillBarOpacity = 1.0;
			}
			break;
		case UnitsSliderFillBarMode.Opacity:
			FillBarOpacity = base.Value / (base.Maximum - base.Minimum);
			break;
		}
	}

	private void UpdateFillBrush()
	{
		SolidColorBrush solidColorBrush = FillBrush ?? Brushes.Transparent;
		switch (FillMode)
		{
		case UnitsSliderFillBarMode.None:
		case UnitsSliderFillBarMode.Opacity:
			ActualFillBrush = solidColorBrush;
			break;
		case UnitsSliderFillBarMode.Feather:
			_featherStop1 = new GradientStop(solidColorBrush.Color, 1.0);
			_featherStop2 = new GradientStop(Colors.Transparent, 1.0);
			_featherBrush = new LinearGradientBrush();
			_featherBrush.GradientStops.Add(_featherStop1);
			_featherBrush.GradientStops.Add(_featherStop2);
			ActualFillBrush = _featherBrush;
			break;
		}
	}
}
