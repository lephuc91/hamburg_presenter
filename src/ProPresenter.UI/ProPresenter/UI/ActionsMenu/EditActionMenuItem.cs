using System.Windows;
using System.Windows.Controls;
using Pro.DO.Triggering;

namespace ProPresenter.UI.ActionsMenu;

public class EditActionMenuItem : MenuItem
{
	public static readonly DependencyProperty ActionProperty = DependencyProperty.Register("Action", typeof(ActionBase), typeof(EditActionMenuItem));

	public ActionBase Action
	{
		get
		{
			return (ActionBase)((DependencyObject)this).GetValue(ActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionProperty, (object)value);
		}
	}
}
