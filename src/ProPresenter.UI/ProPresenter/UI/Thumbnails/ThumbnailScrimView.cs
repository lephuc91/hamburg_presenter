using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO;

namespace ProPresenter.UI.Thumbnails;

public partial class ThumbnailScrimView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable<IScrimSource>), typeof(ThumbnailScrimView));

	public IEnumerable<IScrimSource>? Items
	{
		get
		{
			return (IEnumerable<IScrimSource>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public ThumbnailScrimView()
	{
		InitializeComponent();
	}
}
