using System;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace Pro.UI.Controls;

public class DoubleUpDown : Xceed.Wpf.Toolkit.DoubleUpDown
{
	public static readonly DependencyProperty LargeIncrementProperty;

	public static readonly DependencyProperty RoundToDigitsProperty;

	public double? LargeIncrement
	{
		get
		{
			return (double?)((DependencyObject)this).GetValue(LargeIncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LargeIncrementProperty, (object)value);
		}
	}

	public int RoundToDigits
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RoundToDigitsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RoundToDigitsProperty, (object)value);
		}
	}

	static DoubleUpDown()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		LargeIncrementProperty = DependencyProperty.Register("LargeIncrement", typeof(double?), typeof(DoubleUpDown));
		RoundToDigitsProperty = DependencyProperty.Register("RoundToDigits", typeof(int), typeof(DoubleUpDown), new PropertyMetadata((object)(-1)));
		UpDownBase<double?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(DoubleUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UpDownBase<double?>.ClipValueToMinMaxProperty.OverrideMetadata(typeof(DoubleUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		base.OnKeyDown(e);
		if ((int)e.Key == 13)
		{
			base.TextBox.Text = ConvertValueToText();
		}
	}

	protected override void OnIncrement()
	{
		this.StepValue(base.TextBox.Text, base.OnIncrement, (double v) => IncrementValue(v, GetValue()));
	}

	protected override void OnDecrement()
	{
		this.StepValue(base.TextBox.Text, base.OnDecrement, (double v) => DecrementValue(v, GetValue()));
	}

	private double GetValue()
	{
		if (Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117))
		{
			return LargeIncrement ?? base.Increment.GetValueOrDefault();
		}
		return base.Increment.GetValueOrDefault();
	}

	protected override double? ConvertTextToValue(string text)
	{
		double? result = base.ConvertTextToValue(text);
		if (result.HasValue && RoundToDigits > -1)
		{
			return Math.Round(result.Value, RoundToDigits);
		}
		return result;
	}
}
