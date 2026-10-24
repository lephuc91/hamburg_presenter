using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Pro.UI.Utility;

public class SelectionChangedBehaviour
{
	public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SelectionChangedBehaviour), new PropertyMetadata(new PropertyChangedCallback(PropertyChangedCallback)));

	public static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		if (dependencyObject is Selector selector)
		{
			selector.SelectionChanged += SelectionChanged;
		}
	}

	public static ICommand GetCommand(UIElement element)
	{
		return (ICommand)((DependencyObject)element).GetValue(CommandProperty);
	}

	public static void SetCommand(UIElement element, ICommand command)
	{
		((DependencyObject)element).SetValue(CommandProperty, (object)command);
	}

	private static void SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		Selector selector = (Selector)sender;
		if (selector != null && (selector.IsMouseCaptured || selector.IsKeyboardFocused) && ((DependencyObject)selector).GetValue(CommandProperty) is ICommand command)
		{
			command.Execute(selector.SelectedItem);
		}
	}
}
