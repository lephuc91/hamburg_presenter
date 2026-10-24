using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO;

namespace ProPresenter.UI.Controls;

public partial class GridOrList : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ListElementProperty = DependencyProperty.Register("ListElement", typeof(FrameworkElement), typeof(GridOrList));

	public static readonly DependencyProperty GridElementProperty = DependencyProperty.Register("GridElement", typeof(FrameworkElement), typeof(GridOrList));

	public static readonly DependencyProperty HeaderElementProperty = DependencyProperty.Register("HeaderElement", typeof(FrameworkElement), typeof(GridOrList));

	public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(GridOrList));

	public static readonly DependencyProperty ViewTypeProperty = DependencyProperty.Register("ViewType", typeof(PanelViewType), typeof(GridOrList));

	public FrameworkElement? ListElement
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ListElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ListElementProperty, (object)value);
		}
	}

	public FrameworkElement? GridElement
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(GridElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GridElementProperty, (object)value);
		}
	}

	public FrameworkElement? HeaderElement
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(HeaderElementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderElementProperty, (object)value);
		}
	}

	public string? SearchText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(SearchTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SearchTextProperty, (object)value);
		}
	}

	public PanelViewType? ViewType
	{
		get
		{
			return (PanelViewType?)((DependencyObject)this).GetValue(ViewTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewTypeProperty, (object)value);
		}
	}

	public GridOrList()
	{
		InitializeComponent();
	}
}
