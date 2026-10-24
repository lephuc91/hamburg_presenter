using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO;

namespace ProPresenter.UI.Props;

public partial class PropsGridOrList : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ListElementProperty = DependencyProperty.Register("ListElement", typeof(FrameworkElement), typeof(PropsGridOrList));

	public static readonly DependencyProperty GridElementProperty = DependencyProperty.Register("GridElement", typeof(FrameworkElement), typeof(PropsGridOrList));

	public static readonly DependencyProperty HeaderElementProperty = DependencyProperty.Register("HeaderElement", typeof(FrameworkElement), typeof(PropsGridOrList));

	public static readonly DependencyProperty SearchTextProperty = DependencyProperty.Register("SearchText", typeof(string), typeof(PropsGridOrList));

	public static readonly DependencyProperty ViewTypeProperty = DependencyProperty.Register("ViewType", typeof(PanelViewType), typeof(PropsGridOrList));

	public static readonly DependencyProperty FooterVisiblilityProperty = DependencyProperty.Register("FooterVisiblility", typeof(Visibility), typeof(PropsGridOrList));

	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(PropsGridOrList));

	public FrameworkElement ListElement
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

	public FrameworkElement GridElement
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

	public FrameworkElement HeaderElement
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

	public string SearchText
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

	public Visibility FooterVisiblility
	{
		get
		{
			return (Visibility)((DependencyObject)this).GetValue(FooterVisiblilityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FooterVisiblilityProperty, (object)value);
		}
	}

	public PanelViewType ViewType
	{
		get
		{
			return (PanelViewType)((DependencyObject)this).GetValue(ViewTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewTypeProperty, (object)value);
		}
	}

	public int RowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowCapacityProperty, (object)value);
		}
	}

	public PropsGridOrList()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
