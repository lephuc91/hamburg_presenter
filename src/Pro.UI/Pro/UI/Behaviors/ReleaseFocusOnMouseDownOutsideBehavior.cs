using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using Pro.Common.Mathematics;

namespace Pro.UI.Behaviors;

public class ReleaseFocusOnMouseDownOutsideBehavior : Behavior<TextBox>
{
	private Window? _window;

	protected override void OnAttached()
	{
		base.OnAttached();
		base.AssociatedObject.GotFocus += AssociatedObjectOnGotFocus;
		base.AssociatedObject.LostFocus += AssociatedObjectOnLostFocus;
	}

	protected override void OnDetaching()
	{
		base.OnDetaching();
		base.AssociatedObject.GotFocus -= AssociatedObjectOnGotFocus;
		base.AssociatedObject.LostFocus -= AssociatedObjectOnLostFocus;
	}

	private void AssociatedObjectOnGotFocus(object? sender, RoutedEventArgs e)
	{
		_window = Window.GetWindow((DependencyObject)(object)base.AssociatedObject);
		if (_window != null)
		{
			_window.PreviewMouseDown += OnWindowMouseDown;
		}
	}

	private void AssociatedObjectOnLostFocus(object? sender, RoutedEventArgs e)
	{
		if (_window != null)
		{
			_window.PreviewMouseDown -= OnWindowMouseDown;
			_window = null;
		}
	}

	private void OnWindowMouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		if (new Rect<double>((Vector2<double>)base.AssociatedObject.RenderSize).Contains((Vector2<double>)e.GetPosition(base.AssociatedObject)))
		{
			base.AssociatedObject.MoveFocus(new TraversalRequest((FocusNavigationDirection)1));
		}
	}
}
