using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ProPresenter.UI.CueInspector.Crop;

public partial class PreviewOverlay : UserControl, IComponentConnector
{
	public PreviewOverlay()
	{
		InitializeComponent();
	}

	protected override Size ArrangeOverride(Size arrangeBounds)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		CropControl.InvalidateVisual();
		return base.ArrangeOverride(arrangeBounds);
	}

	private void CropControl_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		OnMouseDown(e);
	}

	private void CropControl_MouseMove(object? sender, MouseEventArgs e)
	{
		OnMouseMove(e);
	}

	private void CropControl_MouseUp(object? sender, MouseButtonEventArgs e)
	{
		OnMouseUp(e);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
