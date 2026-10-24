using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace Pro.UI.Controls;

public class ByteUpDown : Xceed.Wpf.Toolkit.ByteUpDown
{
	static ByteUpDown()
	{
		UpDownBase<byte?>.UpdateValueOnEnterKeyProperty.OverrideMetadata(typeof(ByteUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		UpDownBase<byte?>.ClipValueToMinMaxProperty.OverrideMetadata(typeof(ByteUpDown), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
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
		this.StepValue(base.TextBox.Text, base.OnIncrement, (byte v) => IncrementValue(v, base.Increment.GetValueOrDefault()));
	}

	protected override void OnDecrement()
	{
		this.StepValue(base.TextBox.Text, base.OnDecrement, (byte v) => DecrementValue(v, base.Increment.GetValueOrDefault()));
	}
}
