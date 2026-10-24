using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class InputListItemTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(InputListItemTemplate));

	public ImageSource? Icon
	{
		get
		{
			return (ImageSource)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public InputListItemTemplate()
	{
		InitializeComponent();
	}
}
