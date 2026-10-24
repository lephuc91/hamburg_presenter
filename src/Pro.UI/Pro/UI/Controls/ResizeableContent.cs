using System;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class ResizeableContent : ContentControl, IComponentConnector, IStyleConnector
{
	public event Action<DragDeltaEventArgs>? Resized;

	public ResizeableContent()
	{
		InitializeComponent();
	}

	private void OnDragged(object? sender, DragDeltaEventArgs e)
	{
		this.Resized?.Invoke(e);
	}
}
