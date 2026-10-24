using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Recording;

public partial class CustomResolutionDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(double), typeof(CustomResolutionDialog), new PropertyMetadata((object)0.0));

	public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", typeof(double), typeof(CustomResolutionDialog), new PropertyMetadata((object)0.0));

	public double CapSizeValue => 30000.0;

	public double X
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(XProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(XProperty, (object)value);
		}
	}

	public double Y
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(YProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(YProperty, (object)value);
		}
	}

	public CustomResolutionDialog(double width, double height)
	{
		((DependencyObject)this).SetValue(XProperty, (object)width);
		((DependencyObject)this).SetValue(YProperty, (object)height);
		InitializeComponent();
	}
}
