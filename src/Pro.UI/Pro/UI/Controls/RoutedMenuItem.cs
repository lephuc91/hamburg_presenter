using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.UI.Components;

namespace Pro.UI.Controls;

public class RoutedMenuItem : MenuItem
{
	private static void OnCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((RoutedMenuItem)(object)d).OnCommandChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as ICommand, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand);
	}

	static RoutedMenuItem()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		MenuItem.CommandProperty.OverrideMetadata(typeof(RoutedMenuItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCommandPropertyChanged)));
	}

	public RoutedMenuItem()
	{
		base.Style = Application.Current?.Resources[typeof(MenuItem)] as Style;
	}

	private void OnCommandChanged(ICommand? oldValue, ICommand? newValue)
	{
		if (oldValue is BindableRoutedCommand bindableRoutedCommand)
		{
			bindableRoutedCommand.InputGestureUpdated -= UpdateGestureText;
		}
		if (newValue is BindableRoutedCommand bindableRoutedCommand2)
		{
			bindableRoutedCommand2.InputGestureUpdated += UpdateGestureText;
		}
		UpdateGestureText();
	}

	private void UpdateGestureText()
	{
		((DependencyObject)this).CoerceValue(MenuItem.InputGestureTextProperty);
	}
}
