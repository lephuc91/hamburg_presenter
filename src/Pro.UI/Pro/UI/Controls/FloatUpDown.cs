using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace Pro.UI.Controls;

public class FloatUpDown : SingleUpDown
{
	public static readonly DependencyProperty LargeIncrementProperty;

	public float? LargeIncrement
	{
		get
		{
			return (float?)((DependencyObject)this).GetValue(LargeIncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LargeIncrementProperty, (object)value);
		}
	}

	static FloatUpDown()
	{
		LargeIncrementProperty = DependencyProperty.Register("LargeIncrement", typeof(float?), typeof(FloatUpDown));
		UpDownBase<float?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(FloatUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UpDownBase<float?>.ClipValueToMinMaxProperty.OverrideMetadata(typeof(FloatUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
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
		this.StepValue(base.TextBox.Text, base.OnIncrement, (float v) => IncrementValue(v, GetValue()));
	}

	protected override void OnDecrement()
	{
		this.StepValue(base.TextBox.Text, base.OnDecrement, (float v) => DecrementValue(v, GetValue()));
	}

	private float GetValue()
	{
		if (Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117))
		{
			return LargeIncrement ?? base.Increment.GetValueOrDefault();
		}
		return base.Increment.GetValueOrDefault();
	}
}
