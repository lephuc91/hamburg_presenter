using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Pro.Common.Mathematics;

namespace Pro.Common.Effects;

public class CircularBlurEffect : ShaderEffect
{
	private const string PixelShaderFile = "pack://application:,,,/Pro.Common;component/Effects/Resources/CircularBlurEffect.fx.ps";

	private static readonly PixelShader _shader;

	public static readonly DependencyProperty InputProperty;

	private static readonly DependencyProperty CenterProperty;

	private static readonly DependencyProperty CenterInternalProperty;

	private static readonly DependencyProperty RadiusProperty;

	private static readonly DependencyProperty TargetProperty;

	private static readonly DependencyProperty RadiusInternalProperty;

	private static readonly DependencyProperty InputSizeProperty;

	public Brush Input
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(InputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InputProperty, (object)value);
		}
	}

	public Vector2<double> Center
	{
		get
		{
			return (Vector2<double>)((DependencyObject)this).GetValue(CenterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CenterProperty, (object)value);
		}
	}

	private Point CenterInternal
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(CenterInternalProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(CenterInternalProperty, (object)value);
		}
	}

	public double Radius
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(RadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RadiusProperty, (object)value);
		}
	}

	private float RadiusInternal
	{
		get
		{
			return (float)((DependencyObject)this).GetValue(RadiusInternalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RadiusInternalProperty, (object)value);
		}
	}

	public FrameworkElement? Target
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(TargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TargetProperty, (object)value);
		}
	}

	private Point InputSize
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return (Point)((DependencyObject)this).GetValue(InputSizeProperty);
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((DependencyObject)this).SetValue(InputSizeProperty, (object)value);
		}
	}

	static CircularBlurEffect()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(CircularBlurEffect), 0);
		CenterProperty = DependencyProperty.Register("Center", typeof(Vector2<double>), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Vector2<double>.Zero, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			if (d is CircularBlurEffect circularBlurEffect)
			{
				circularBlurEffect.CenterInternal = circularBlurEffect.Center;
				circularBlurEffect.UpdateEffect();
			}
		}));
		CenterInternalProperty = DependencyProperty.Register("CenterInternal", typeof(Point), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Point(0.0, 0.0), ShaderEffect.PixelShaderConstantCallback(0)));
		RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is CircularBlurEffect circularBlurEffect2)
			{
				circularBlurEffect2.RadiusInternal = (float)circularBlurEffect2.Radius;
				circularBlurEffect2.UpdateEffect();
			}
		}));
		TargetProperty = DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is CircularBlurEffect circularBlurEffect3)
			{
				circularBlurEffect3.UpdateEffect();
			}
		}));
		RadiusInternalProperty = DependencyProperty.Register("RadiusInternal", typeof(float), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0f, ShaderEffect.PixelShaderConstantCallback(1)));
		InputSizeProperty = DependencyProperty.Register("InputSize", typeof(Point), typeof(CircularBlurEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new Point(0.0, 0.0), ShaderEffect.PixelShaderConstantCallback(2)));
		_shader = new PixelShader
		{
			UriSource = new Uri("pack://application:,,,/Pro.Common;component/Effects/Resources/CircularBlurEffect.fx.ps")
		};
		((Freezable)_shader).Freeze();
	}

	public CircularBlurEffect()
	{
		base.PixelShader = _shader;
		UpdateShaderValue(InputProperty);
		UpdateShaderValue(CenterInternalProperty);
		UpdateShaderValue(RadiusInternalProperty);
		UpdateShaderValue(InputSizeProperty);
	}

	private void UpdateEffect()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		FrameworkElement target = Target;
		if (target == null)
		{
			InputSize = Vector2<double>.Zero;
		}
		else
		{
			InputSize = (Vector2<double>)target.RenderSize;
		}
	}
}
