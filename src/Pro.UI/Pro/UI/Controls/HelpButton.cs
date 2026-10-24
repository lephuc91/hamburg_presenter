using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.HTTP;
using Pro.UI.DependencyInjection;
using Pro.Web.Services;

namespace Pro.UI.Controls;

public partial class HelpButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HelpCommandProperty = DependencyProperty.Register("HelpCommand", typeof(ICommand), typeof(HelpButton));

	public static readonly DependencyProperty HelpResourceProperty = DependencyProperty.Register("HelpResource", typeof(string), typeof(HelpButton));

	public ICommand HelpCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(HelpCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpCommandProperty, (object)value);
		}
	}

	public string HelpResource
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HelpResourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HelpResourceProperty, (object)value);
		}
	}

	public HelpButton()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		if (!string.IsNullOrEmpty(HelpResource))
		{
			IHyperlinkService service = UIServiceProvider.GetService<IHyperlinkService>();
			IApiService service2 = UIServiceProvider.GetService<IApiService>();
			service.Open(new Uri(service2.GetTargetRedirectHost(includeProtocol: true) + HelpResource));
		}
	}
}
