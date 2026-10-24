using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Registration.PopUpAlerts;

public sealed partial class ProgressSpinner : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(ProgressSpinner), new PropertyMetadata((object)string.Empty));

	public string Message
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MessageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MessageProperty, (object)value);
		}
	}

	public ProgressSpinner()
	{
		InitializeComponent();
	}
}
