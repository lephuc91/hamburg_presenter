using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Settings.PageTemplates.Screen;

public partial class RenderClockSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShowTitleProperty = DependencyProperty.Register("ShowTitle", typeof(bool), typeof(RenderClockSelector), new PropertyMetadata((object)true));

	public bool ShowTitle
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTitleProperty, (object)value);
		}
	}

	public RenderClockSelector()
	{
		InitializeComponent();
	}
}
