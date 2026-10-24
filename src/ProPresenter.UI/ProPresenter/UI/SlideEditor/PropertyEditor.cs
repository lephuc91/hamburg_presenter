using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor;

public partial class PropertyEditor : UserControl, IComponentConnector
{
	public static readonly DependencyProperty EditMediaCommandProperty = DependencyProperty.Register("EditMediaCommand", typeof(ICommand), typeof(PropertyEditor));

	public static readonly DependencyProperty SelectedInspectorTabProperty = DependencyProperty.Register("SelectedInspectorTab", typeof(InspectorTab), typeof(PropertyEditor));

	public static readonly DependencyProperty AvailableInspectorTabsProperty = DependencyProperty.Register("AvailableInspectorTabs", typeof(InspectorTab), typeof(PropertyEditor));

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

	public InspectorTab SelectedInspectorTab
	{
		get
		{
			return (InspectorTab)((DependencyObject)this).GetValue(SelectedInspectorTabProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedInspectorTabProperty, (object)value);
		}
	}

	public InspectorTab AvailableInspectorTabs
	{
		get
		{
			return (InspectorTab)((DependencyObject)this).GetValue(AvailableInspectorTabsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableInspectorTabsProperty, (object)value);
		}
	}

	public PropertyEditor()
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
