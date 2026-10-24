using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Slide;

namespace ProPresenter.UI.PresentationView.GoToNext;

public partial class SlideSettingsIndicatorControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty GotoNextProperty = DependencyProperty.Register("GotoNext", typeof(GotoNext), typeof(SlideSettingsIndicatorControl));

	public GotoNext GotoNext
	{
		get
		{
			return (GotoNext)((DependencyObject)this).GetValue(GotoNextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotoNextProperty, (object)value);
		}
	}

	public SlideSettingsIndicatorControl()
	{
		InitializeComponent();
	}
}
