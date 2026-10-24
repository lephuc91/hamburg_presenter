using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace Pro.UI.Controls;

public class IntegerUpDown : Xceed.Wpf.Toolkit.IntegerUpDown
{
	public static readonly DependencyProperty LargeIncrementProperty;

	public int? LargeIncrement
	{
		get
		{
			return (int?)((DependencyObject)this).GetValue(LargeIncrementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LargeIncrementProperty, (object)value);
		}
	}

	static IntegerUpDown()
	{
		LargeIncrementProperty = DependencyProperty.Register("LargeIncrement", typeof(int?), typeof(IntegerUpDown));
		UpDownBase<int?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(IntegerUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UpDownBase<int?>.ClipValueToMinMaxProperty.OverrideMetadata(typeof(IntegerUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
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
		this.StepValue(base.TextBox.Text, base.OnIncrement, (int v) => IncrementValue(v, GetValue()));
	}

	protected override void OnDecrement()
	{
		this.StepValue(base.TextBox.Text, base.OnDecrement, (int v) => DecrementValue(v, GetValue()));
	}

	private int GetValue()
	{
		if (Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117))
		{
			return LargeIncrement ?? base.Increment.GetValueOrDefault();
		}
		return base.Increment.GetValueOrDefault();
	}
}
