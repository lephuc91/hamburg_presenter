using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.Network;

public partial class PendingConnectionView : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(PendingConnectionView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty));

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

	public PendingConnectionView()
	{
		InitializeComponent();
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}
}
