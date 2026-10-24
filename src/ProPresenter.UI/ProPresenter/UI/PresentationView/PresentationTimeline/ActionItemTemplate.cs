using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public partial class ActionItemTemplate : UserControl, IComponentConnector
{
	private static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(ActionItemTemplate));

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public ActionItemTemplate()
	{
		InitializeComponent();
	}
}
