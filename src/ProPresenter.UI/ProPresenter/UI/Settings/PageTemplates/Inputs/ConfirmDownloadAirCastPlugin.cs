using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.HTTP;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO.Web;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class ConfirmDownloadAirCastPlugin : ChromedWindow, IComponentConnector
{
	private static readonly DependencyProperty HelpCommandProperty = DependencyProperty.Register("HelpCommand", typeof(ICommand), typeof(ConfirmDownloadAirCastPlugin));

	private ICommand HelpCommand
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

	public ConfirmDownloadAirCastPlugin(IWebSourceProvider webSourceProvider, IHyperlinkService hyperlinkService)
	{
		InitializeComponent();
		Uri url = webSourceProvider.GenerateLink(ResourceType.HelpAirCast);
		((DependencyObject)this).SetCurrentValue(HelpCommandProperty, (object)new RelayCommand(delegate
		{
			hyperlinkService.Open(url);
		}));
	}

	private void Download_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}

	private void Cancel_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
	}
}
