using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class CommandHelper
{
	public static DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(CommandHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(CommandParameter_Changed)));

	private static void CommandParameter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ButtonBase buttonBase)
		{
			buttonBase.CommandParameter = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			ICommand command = buttonBase.Command;
			buttonBase.Command = null;
			buttonBase.Command = command;
		}
		else if (d is MenuItem menuItem)
		{
			menuItem.CommandParameter = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
			ICommand command2 = menuItem.Command;
			menuItem.Command = null;
			menuItem.Command = command2;
		}
	}

	public static object GetCommandParameter(FrameworkElement target)
	{
		return ((DependencyObject)target).GetValue(CommandParameterProperty);
	}

	public static void SetCommandParameter(FrameworkElement target, object value)
	{
		((DependencyObject)target).SetValue(CommandParameterProperty, value);
	}
}
