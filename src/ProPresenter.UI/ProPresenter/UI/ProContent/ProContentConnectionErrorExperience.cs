using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.ProContent;

public partial class ProContentConnectionErrorExperience : UserControl, IComponentConnector
{
	public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.Register("RefreshCommand", typeof(ICommand), typeof(ProContentConnectionErrorExperience));

	public static readonly DependencyProperty ShowSupportWebsiteUrlProperty = DependencyProperty.Register("ShowSupportWebsiteUrl", typeof(string), typeof(ProContentConnectionErrorExperience));

	public static readonly DependencyProperty ShowSupportWebsiteLinkTextKeyProperty = DependencyProperty.Register("ShowSupportWebsiteLinkTextKey", typeof(string), typeof(ProContentConnectionErrorExperience));

	public ICommand? RefreshCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RefreshCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RefreshCommandProperty, (object)value);
		}
	}

	public string? ShowSupportWebsiteUrl
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ShowSupportWebsiteUrlProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSupportWebsiteUrlProperty, (object)value);
		}
	}

	public string? ShowSupportWebsiteLinkTextKey
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ShowSupportWebsiteLinkTextKeyProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSupportWebsiteLinkTextKeyProperty, (object)value);
		}
	}

	public ProContentConnectionErrorExperience()
	{
		InitializeComponent();
	}
}
