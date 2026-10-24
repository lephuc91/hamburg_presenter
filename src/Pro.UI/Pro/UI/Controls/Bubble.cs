using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class Bubble : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(Bubble));

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	public Bubble()
	{
		InitializeComponent();
	}
}
