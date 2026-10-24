using System.Windows;
using System.Windows.Controls;

namespace Pro.UI.Utility;

public static class ComboBoxHelper
{
	private const string MaxLength = "MaxLength";

	public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.RegisterAttached("MaxLength", typeof(int), typeof(ComboBoxHelper), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMaxLengthChanged)));

	private static void OnMaxLengthChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		ComboBox comboBox = callerObject as ComboBox;
		if (comboBox == null)
		{
			return;
		}
		comboBox.Loaded += delegate
		{
			if (((DependencyObject)(object)comboBox).FindVisualChild<FrameworkElement>()?.FindName("PART_EditableTextBox") is TextBox textBox)
			{
				((DependencyObject)textBox).SetValue(TextBox.MaxLengthProperty, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
			}
		};
	}

	public static int GetMaxLength(ComboBox element)
	{
		return (int)((DependencyObject)element).GetValue(MaxLengthProperty);
	}

	public static void SetMaxLength(ComboBox element, int value)
	{
		((DependencyObject)element).SetValue(MaxLengthProperty, (object)value);
	}
}
