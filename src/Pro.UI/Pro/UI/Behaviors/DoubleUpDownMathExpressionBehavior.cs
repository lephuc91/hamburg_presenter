using System.CodeDom.Compiler;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using Pro.UI.Controls;
using org.matheval;

namespace Pro.UI.Behaviors;

public class DoubleUpDownMathExpressionBehavior : Behavior<DoubleUpDown>
{
	protected override void OnAttached()
	{
		base.OnAttached();
		base.AssociatedObject.PreviewTextInput += AssociatedObjectOnPreviewTextInput;
		base.AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();
		base.AssociatedObject.PreviewTextInput -= AssociatedObjectOnPreviewTextInput;
		base.AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
	}

	private void AssociatedObjectOnPreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		try
		{
			if ((int)e.Key == 6)
			{
				double num = new Expression(base.AssociatedObject.Text).Eval<double>();
				base.AssociatedObject.Text = num.ToString(CultureInfo.InvariantCulture);
			}
		}
		catch
		{
		}
	}

	private static void AssociatedObjectOnPreviewTextInput(object? sender, TextCompositionEventArgs e)
	{
		e.Handled = Pattern().IsMatch(e.Text);
	}

	[GeneratedRegex("^([-+]? ?(\\\\d+|\\\\(\\\\g<1>\\\\))( ?[-+*\\\\/] ?\\\\g<1>)?)$")]
	[GeneratedCode("System.Text.RegularExpressions.Generator", "9.0.12.47515")]
	private static Regex Pattern()
	{
		return _003CRegexGenerator_g_003EFF0114E4F058D459C4F0C22ECC66F91649A887A5A81F2274826D1858393A61A2A__Pattern_0.Instance;
	}
}
