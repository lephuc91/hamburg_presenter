using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class GenericTextBoxDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(GenericTextBoxDialog));

	public string? ItemName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ItemNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemNameProperty, (object)value);
		}
	}

	public GenericTextBoxDialog()
	{
		InitializeComponent();
	}

	private void GenericTextBoxDialog_OnLoaded(object sender, RoutedEventArgs e)
	{
		GenericTextBox.Focus();
	}
}
