using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public class SelectOnMouseUpListBoxItem : System.Windows.Controls.ListBoxItem
{
	private bool EditTextBoxClicked(MouseEventArgs e)
	{
		return e.FindHitElement<EditableTextBlock>(this)?.IsInEditMode ?? false;
	}

	private bool CloseButtonClicked(MouseButtonEventArgs e)
	{
		return ((DependencyObject)(object)e.FindHitElement<UIElement>(this))?.FindVisualParent<ButtonBase>() != null;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		e.Handled = e.ClickCount < 2 && !CloseButtonClicked(e) && !EditTextBoxClicked(e);
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!EditTextBoxClicked(e))
		{
			OnMouseLeftButtonDown(e);
			Focus();
		}
	}
}
