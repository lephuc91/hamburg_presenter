using System.Windows;

namespace Pro.UI.Controls;

public class ResizeableModalPopup : ResizeablePopup<ModalPopup>
{
	public static readonly DependencyProperty IsModalProperty = DependencyProperty.Register("IsModal", typeof(bool), typeof(ResizeableModalPopup));

	public bool IsModal
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsModalProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsModalProperty, (object)value);
		}
	}

	public ResizeableModalPopup()
	{
		SetupBinding(ModalPopup.IsModalProperty);
	}
}
