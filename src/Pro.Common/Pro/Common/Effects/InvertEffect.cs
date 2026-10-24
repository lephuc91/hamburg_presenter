using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Pro.Common.Effects;

public class InvertEffect : ShaderEffect
{
	private static readonly PixelShader _shader;

	public static readonly DependencyProperty InputProperty;

	public static readonly DependencyProperty InvertRGBProperty;

	public static readonly DependencyProperty InvertTransparencyProperty;

	private static readonly DependencyProperty InvertRGBInternalProperty;

	private static readonly DependencyProperty InvertTransparencyInternalProperty;

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

	public bool InvertRGB
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(InvertRGBProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InvertRGBProperty, (object)value);
		}
	}

	public bool InvertTransparency
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(InvertTransparencyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InvertTransparencyProperty, (object)value);
		}
	}

	private float InvertRGBInternal
	{
		get
		{
			return (float)((DependencyObject)this).GetValue(InvertRGBInternalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InvertRGBInternalProperty, (object)value);
		}
	}

	private float InvertTransparencyInternal
	{
		get
		{
			return (float)((DependencyObject)this).GetValue(InvertTransparencyInternalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InvertTransparencyInternalProperty, (object)value);
		}
	}

	static InvertEffect()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(InvertEffect), 0);
		InvertRGBProperty = DependencyProperty.Register("InvertRGB", typeof(bool), typeof(InvertEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, new PropertyChangedCallback(InvertRgbPropertyChanged)));
		InvertTransparencyProperty = DependencyProperty.Register("InvertTransparency", typeof(bool), typeof(InvertEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(InverTransparencyPropertyChanged)));
		InvertRGBInternalProperty = DependencyProperty.Register("InvertRGBInternal", typeof(float), typeof(InvertEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1f, ShaderEffect.PixelShaderConstantCallback(0)));
		InvertTransparencyInternalProperty = DependencyProperty.Register("InvertTransparencyInternal", typeof(float), typeof(InvertEffect), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0f, ShaderEffect.PixelShaderConstantCallback(1)));
		_shader = new PixelShader
		{
			UriSource = new Uri("pack://application:,,,/Pro.Common;component/Effects/Resources/InvertEffect.fx.ps")
		};
		((Freezable)_shader).Freeze();
	}

	public InvertEffect()
	{
		base.PixelShader = _shader;
		UpdateShaderValue(InputProperty);
		UpdateShaderValue(InvertRGBInternalProperty);
		UpdateShaderValue(InvertTransparencyInternalProperty);
	}

	private static void InverTransparencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is InvertEffect invertEffect)
		{
			invertEffect.InvertTransparencyInternal = (invertEffect.InvertTransparency ? 1f : 0f);
		}
	}

	private static void InvertRgbPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is InvertEffect invertEffect)
		{
			invertEffect.InvertRGBInternal = (invertEffect.InvertRGB ? 1f : 0f);
		}
	}
}
