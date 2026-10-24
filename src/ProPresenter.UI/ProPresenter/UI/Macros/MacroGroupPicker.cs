using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.DragDropHelper;

namespace ProPresenter.UI.Macros;

public partial class MacroGroupPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsDraggingProperty = DependencyProperty.Register("IsDragging", typeof(bool), typeof(MacroGroupPicker));

	public bool IsDragging
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDraggingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDraggingProperty, (object)value);
		}
	}

	public event DragEventHandler? MacroGroupList_DragEnter;

	public event DragEventHandler? MacroGroupList_DragLeave;

	public MacroGroupPicker()
	{
		InitializeComponent();
		MacroGroupList.DragStarted += delegate(object s, DragEventArgs e)
		{
			this.MacroGroupList_DragEnter?.Invoke(s, e);
		};
		MacroGroupList.DragEnded += delegate(object s, DragEventArgs e)
		{
			this.MacroGroupList_DragLeave?.Invoke(s, e);
		};
		DragSource.DragStarted += DragSource_DragStarted;
		DragSource.DragCompleted += DragSource_DragCompleted;
	}

	private void DragSource_DragStarted(DependencyObject obj)
	{
		if (obj is MacroGroupList)
		{
			((DependencyObject)this).SetCurrentValue(IsDraggingProperty, (object)true);
		}
	}

	private void DragSource_DragCompleted(DragResult obj)
	{
		((DependencyObject)this).SetCurrentValue(IsDraggingProperty, (object)false);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
