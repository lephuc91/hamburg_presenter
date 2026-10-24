using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Props;

public partial class PropListView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(PropListView));

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

	public PropListView()
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
