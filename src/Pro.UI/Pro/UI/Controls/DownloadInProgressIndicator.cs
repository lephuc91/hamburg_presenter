using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class DownloadInProgressIndicator : UserControl, IComponentConnector
{
	public static readonly DependencyProperty UseSmallRingProperty = DependencyProperty.Register("UseSmallRing", typeof(bool), typeof(DownloadInProgressIndicator));

	public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(DownloadInProgressIndicator), new PropertyMetadata((object)new Thickness(0.0)));

	public bool UseSmallRing
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(UseSmallRingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UseSmallRingProperty, (object)value);
		}
	}

	public Thickness ContentMargin
	{
		get
		{
			return (Thickness)((DependencyObject)this).GetValue(ContentMarginProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContentMarginProperty, (object)value);
		}
	}

	public DownloadInProgressIndicator()
	{
		InitializeComponent();
	}
}
