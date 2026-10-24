using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.License;

public partial class LicenseViewer : UserControl, IComponentConnector
{
	public static readonly DependencyProperty LicenseContentProperty = DependencyProperty.Register("LicenseContent", typeof(string), typeof(LicenseViewer));

	public string? LicenseContent
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LicenseContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LicenseContentProperty, (object)value);
		}
	}

	public LicenseViewer()
	{
		InitializeComponent();
	}
}
