using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.DragDropHelper;

namespace ProPresenter.UI.Props;

public partial class PropGroupPicker : UserControl, IComponentConnector
{
	public static readonly DependencyProperty IsDraggingProperty = DependencyProperty.Register("IsDragging", typeof(bool), typeof(PropGroupPicker));

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

	public event DragEventHandler? GroupList_DragEnter;

	public event DragEventHandler? GroupList_DragLeave;

	public PropGroupPicker()
	{
		InitializeComponent();
		PropGroupList.DragStarted += delegate(object s, DragEventArgs e)
		{
			this.GroupList_DragEnter?.Invoke(s, e);
		};
		PropGroupList.DragEnded += delegate(object s, DragEventArgs e)
		{
			this.GroupList_DragLeave?.Invoke(s, e);
		};
		DragSource.DragStarted += DragSource_DragStarted;
		DragSource.DragCompleted += DragSource_DragCompleted;
	}

	private void DragSource_DragStarted(DependencyObject obj)
	{
		if (obj is PropGroupList)
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
