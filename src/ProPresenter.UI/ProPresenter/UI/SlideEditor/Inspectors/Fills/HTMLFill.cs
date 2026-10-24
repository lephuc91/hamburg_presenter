using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Utility;

namespace ProPresenter.UI.SlideEditor.Inspectors.Fills;

public partial class HTMLFill : UserControl, IComponentConnector
{
	public HTMLFill()
	{
		InitializeComponent();
	}

	private void WebAddressNavigate(object? sender, RoutedEventArgs e)
	{
		Uri uriResult = default(Uri);
		if (!validateAddress(UrlInputTextBox.Text))
		{
			validateAddress("http://" + UrlInputTextBox.Text);
		}
		ProcessHelper.StartProcess(uriResult?.ToString());
		bool validateAddress(string address)
		{
			if (Uri.TryCreate(address, UriKind.Absolute, out uriResult))
			{
				if (!(uriResult.Scheme == Uri.UriSchemeHttp))
				{
					return uriResult.Scheme == Uri.UriSchemeHttps;
				}
				return true;
			}
			return false;
		}
	}
}
