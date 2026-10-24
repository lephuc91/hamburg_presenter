using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Downloads;

namespace ProPresenter.UI.ThumbnailOverlay;

public partial class ProContentDownloadProgress : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DownloadProgressProperty = DependencyProperty.Register("DownloadProgress", typeof(DownloadProgress), typeof(ProContentDownloadProgress), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty UseSmallRingProperty = DependencyProperty.Register("UseSmallRing", typeof(bool), typeof(ProContentDownloadProgress), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ShowValueProperty = DependencyProperty.Register("ShowValue", typeof(bool), typeof(ProContentDownloadProgress), new PropertyMetadata((object)true));

	public DownloadProgress? DownloadProgress
	{
		get
		{
			return (DownloadProgress?)((DependencyObject)this).GetValue(DownloadProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DownloadProgressProperty, (object)value);
		}
	}

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

	public bool ShowValue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowValueProperty, (object)value);
		}
	}

	public ProContentDownloadProgress()
	{
		InitializeComponent();
	}
}
