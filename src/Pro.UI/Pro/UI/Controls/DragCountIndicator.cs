using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class DragCountIndicator : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(DragCountIndicator));

	public int Count
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CountProperty, (object)value);
		}
	}

	public DragCountIndicator()
	{
		InitializeComponent();
	}
}
