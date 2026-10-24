using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI;

public partial class CustomSizeDialog : UserControl, IComponentConnector
{
	public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(double), typeof(CustomSizeDialog));

	public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", typeof(double), typeof(CustomSizeDialog));

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

	public CustomSizeDialog(double width, double height)
	{
		((DependencyObject)this).SetValue(XProperty, (object)width);
		((DependencyObject)this).SetValue(YProperty, (object)height);
		InitializeComponent();
	}
}
