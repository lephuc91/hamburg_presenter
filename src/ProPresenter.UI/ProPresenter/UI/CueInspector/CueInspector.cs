using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.CueInspector;

public partial class CueInspector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(CueInspector));

	public static readonly DependencyProperty LoadCIOutputCommandProperty = DependencyProperty.Register("LoadCIOutputCommand", typeof(ICommand<CreateRenderViewParameters>), typeof(CueInspector));

	public static readonly DependencyProperty UnloadCIOutputCommandProperty = DependencyProperty.Register("UnloadCIOutputCommand", typeof(ICommand<DestroyRenderViewParameters>), typeof(CueInspector));

	public static readonly DependencyProperty CloseCICommandProperty = DependencyProperty.Register("CloseCICommand", typeof(ICommand), typeof(CueInspector));

	public static readonly DependencyProperty SelectedInspectorTabProperty = DependencyProperty.Register("SelectedInspectorTab", typeof(int), typeof(CueInspector), new PropertyMetadata((object)0));

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public ICommand<CreateRenderViewParameters>? LoadCIOutputCommand
	{
		get
		{
			return (ICommand<CreateRenderViewParameters>)((DependencyObject)this).GetValue(LoadCIOutputCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoadCIOutputCommandProperty, (object)value);
		}
	}

	public ICommand<DestroyRenderViewParameters>? UnloadCIOutputCommand
	{
		get
		{
			return (ICommand<DestroyRenderViewParameters>)((DependencyObject)this).GetValue(UnloadCIOutputCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnloadCIOutputCommandProperty, (object)value);
		}
	}

	public ICommand? CloseCICommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CloseCICommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CloseCICommandProperty, (object)value);
		}
	}

	public int SelectedInspectorTab
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(SelectedInspectorTabProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedInspectorTabProperty, (object)value);
		}
	}

	public CueInspector()
	{
		InitializeComponent();
		((DependencyObject)(object)this).FindVisualChildren<Grid>().ForEach(delegate(Grid g)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			g.Measure(default(Size));
		});
	}

	public void CloseCI()
	{
		CloseCICommand?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
