using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Pro.UI.Utility;

public class TextBoxHelper
{
	private const string UpdateOnEnterKey = "UpdateOnEnterKey";

	public static readonly DependencyProperty UpdateOnEnterKeyProperty = DependencyProperty.RegisterAttached("UpdateOnEnterKey", typeof(bool), typeof(TextBoxHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, new PropertyChangedCallback(UpdateOnEnterKeyChanged)));

	private static void UpdateOnEnterKeyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		OnUpdateOnEnterKeyChanged((TextBox)(object)callerObject, (bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public static bool GetUpdateOnEnterKey(TextBox textBox)
	{
		return (bool)((DependencyObject)textBox).GetValue(UpdateOnEnterKeyProperty);
	}

	public static void SetUpdateOnEnterKey(TextBox textBox, bool value)
	{
		((DependencyObject)textBox).SetValue(UpdateOnEnterKeyProperty, (object)value);
	}

	private static void OnUpdateOnEnterKeyChanged(TextBox textBox, bool updateOnEnterKey)
	{
		if (updateOnEnterKey)
		{
			textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
		}
		else
		{
			textBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
		}
	}

	private static void TextBox_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (sender is TextBox { AcceptsReturn: false } textBox && (int)e.Key == 6)
		{
			textBox.GetBindingExpression(TextBox.TextProperty)?.UpdateSource();
			e.Handled = true;
		}
	}
}
