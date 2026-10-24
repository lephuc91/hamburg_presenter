using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace Pro.UI.Behaviors;

public class UpdateTextOnEnterKeyBehavior : Behavior<TextBox>
{
	protected override void OnAttached()
	{
		base.OnAttached();
		base.AssociatedObject.PreviewKeyDown += AssociatedObjectOnPreviewKeyDown;
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();
		base.AssociatedObject.PreviewKeyDown -= AssociatedObjectOnPreviewKeyDown;
	}

	private void AssociatedObjectOnPreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		if (sender is TextBox textBox && (int)e.Key == 6)
		{
			textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
		}
	}
}
