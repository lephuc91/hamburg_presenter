using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.PresentationView;

public partial class CustomSlideShowDuration : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CustomDurationProperty = DependencyProperty.Register("CustomDuration", typeof(double), typeof(CustomSlideShowDuration));

	public double CustomDuration
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(CustomDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomDurationProperty, (object)value);
		}
	}

	public CustomSlideShowDuration(double customDuration)
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(CustomDurationProperty, (object)customDuration);
	}
}
