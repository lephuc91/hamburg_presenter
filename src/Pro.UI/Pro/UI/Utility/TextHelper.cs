using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Pro.UI.Utility;

public static class TextHelper
{
	private const string Capitalize = "Capitalize";

	private const string TextProxy = "TextProxy";

	private const string SetTextExplicitly = "SetTextExplicitly";

	public static readonly DependencyProperty CapitalizeProperty = DependencyProperty.RegisterAttached("Capitalize", typeof(bool), typeof(TextHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(CapitalizeChanged)));

	private static readonly DependencyProperty TextProxyProperty = DependencyProperty.RegisterAttached("TextProxy", typeof(string), typeof(TextBlock), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(TextProxyChanged)));

	public static readonly DependencyProperty SetTextExplicitlyProperty = DependencyProperty.RegisterAttached("SetTextExplicitly", typeof(bool), typeof(TextHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SetTextExplicitlyChanged)));

	private static void CapitalizeChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnCapitalizeChanged((TextBlock)(object)callerObject);
	}

	private static void TextProxyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnTextProxyChanged((TextBlock)(object)callerObject, (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	private static void SetTextExplicitlyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnSetTextExplicitlyChanged((TextBox)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static bool GetCapitalize(TextBlock element)
	{
		return (bool)((DependencyObject)element).GetValue(CapitalizeProperty);
	}

	public static void SetCapitalize(TextBlock element, bool value)
	{
		((DependencyObject)element).SetValue(CapitalizeProperty, (object)value);
	}

	public static bool GetSetTextExplicitly(TextBox element)
	{
		return (bool)((DependencyObject)element).GetValue(SetTextExplicitlyProperty);
	}

	public static void SetSetTextExplicitly(TextBox element, bool value)
	{
		((DependencyObject)element).SetValue(SetTextExplicitlyProperty, (object)value);
	}

	private static void OnCapitalizeChanged(TextBlock textBlock)
	{
		BindingOperations.SetBinding((DependencyObject)(object)textBlock, TextProxyProperty, new Binding("Text")
		{
			RelativeSource = RelativeSource.Self,
			Mode = BindingMode.OneWay
		});
	}

	private static void OnTextProxyChanged(TextBlock textBlock, string text)
	{
		((DependencyObject)textBlock).SetCurrentValue(TextBlock.TextProperty, (object)((!GetCapitalize(textBlock)) ? text : text?.ToUpper()));
	}

	private static void OnSetTextExplicitlyChanged(TextBox textBox, bool value)
	{
		if (value)
		{
			textBox.LostFocus += TextBox_LostFocus;
			textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
		}
		else
		{
			textBox.LostFocus -= TextBox_LostFocus;
			textBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
		}
	}

	private static void TextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6 && sender is TextBox textBox)
		{
			textBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
		}
	}

	private static void TextBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		(sender as TextBox)?.GetBindingExpression(TextBox.TextProperty).UpdateSource();
	}
}
