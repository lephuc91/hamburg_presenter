using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public partial class ShapeInspector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty EditMediaCommandProperty = DependencyProperty.Register("EditMediaCommand", typeof(ICommand), typeof(ShapeInspector));

	public ICommand? EditMediaCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(EditMediaCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EditMediaCommandProperty, (object)value);
		}
	}

	public ShapeInspector()
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
