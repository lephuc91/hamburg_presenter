using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class MenuItemHelper
{
	private const string GestureTextVisibility = "GestureTextVisibility";

	private const string InvokeCommandWithChildren = "InvokeCommandWithChildren";

	public static readonly DependencyProperty GestureTextVisibilityProperty = DependencyProperty.RegisterAttached("GestureTextVisibility", typeof(Visibility), typeof(MenuItemHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Visibility.Visible));

	public static readonly DependencyProperty InvokeCommandWithChildrenProperty = DependencyProperty.RegisterAttached("InvokeCommandWithChildren", typeof(bool), typeof(MenuItemHelper), new PropertyMetadata((object)false, new PropertyChangedCallback(InvokeCommandWithChildrenChanged)));

	private static void InvokeCommandWithChildrenChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnInvokeCommandWithChildrenChanged((MenuItem)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static Visibility GetGestureTextVisibility(MenuItem menuItem)
	{
		return (Visibility)((DependencyObject)menuItem).GetValue(GestureTextVisibilityProperty);
	}

	public static void SetGestureTextVisibility(MenuItem menuItem, Visibility value)
	{
		((DependencyObject)menuItem).SetValue(GestureTextVisibilityProperty, (object)value);
	}

	public static bool GetInvokeCommandWithChildren(MenuItem menuItem)
	{
		return (bool)((DependencyObject)menuItem).GetValue(InvokeCommandWithChildrenProperty);
	}

	public static void SetInvokeCommandWithChildren(MenuItem menuItem, bool value)
	{
		((DependencyObject)menuItem).SetValue(InvokeCommandWithChildrenProperty, (object)value);
	}

	private static void OnInvokeCommandWithChildrenChanged(MenuItem menuItem, bool value)
	{
		if (value)
		{
			menuItem.PreviewMouseLeftButtonUp += OnInvokeCommand;
		}
		else
		{
			menuItem.PreviewMouseLeftButtonUp -= OnInvokeCommand;
		}
	}

	private static void OnInvokeCommand(object? sender, RoutedEventArgs e)
	{
		MenuItem menuItem = ((DependencyObject)(object)(e.Source as UIElement))?.FindVisualParent<MenuItem>();
		if (menuItem == null || !menuItem.HasItems)
		{
			return;
		}
		MenuBase menuBase = ((DependencyObject)(object)menuItem).FindVisualParent<MenuBase>() ?? ((DependencyObject)(object)menuItem).FindLogicalParent<MenuBase>();
		if (menuBase is Menu menu)
		{
			menu.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
			{
				RoutedEvent = Mouse.MouseUpEvent
			});
		}
		else if (menuBase is ContextMenu contextMenu)
		{
			contextMenu.IsOpen = false;
		}
		if (!(e.OriginalSource is FrameworkElement depObj))
		{
			return;
		}
		MenuItem menuItem2 = ((DependencyObject)(object)depObj).FindVisualParent<MenuItem>();
		if (menuItem2 != null && menuItem.DataContext == menuItem2.DataContext)
		{
			ICommand command = menuItem.Command;
			if (command != null && command.CanExecute(menuItem.CommandParameter))
			{
				menuItem.Command.Execute(menuItem.CommandParameter);
			}
			e.Handled = true;
		}
	}
}
