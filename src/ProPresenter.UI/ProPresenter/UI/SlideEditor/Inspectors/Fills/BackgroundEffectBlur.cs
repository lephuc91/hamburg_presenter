using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Slide;

namespace ProPresenter.UI.SlideEditor.Inspectors.Fills;

public partial class BackgroundEffectBlur : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SlideProperty = DependencyProperty.Register("Slide", typeof(SlideBase), typeof(BackgroundEffectBlur));

	public SlideBase? Slide
	{
		get
		{
			return (SlideBase)((DependencyObject)this).GetValue(SlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SlideProperty, (object)value);
		}
	}

	public BackgroundEffectBlur()
	{
		InitializeComponent();
	}
}
