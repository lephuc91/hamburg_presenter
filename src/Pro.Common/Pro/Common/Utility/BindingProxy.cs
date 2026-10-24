using System.Windows;

namespace Pro.Common.Utility;

public class BindingProxy : Freezable
{
	public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy));

	public object Data
	{
		get
		{
			return ((DependencyObject)this).GetValue(DataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DataProperty, value);
		}
	}

	protected override Freezable CreateInstanceCore()
	{
		return (Freezable)(object)new BindingProxy();
	}
}
