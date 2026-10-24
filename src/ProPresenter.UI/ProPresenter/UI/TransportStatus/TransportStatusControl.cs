using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.TransportStatus;

public partial class TransportStatusControl : UserControl, IComponentConnector
{
	public TransportStatusControl()
	{
		InitializeComponent();
	}

	private void PlaybackControl_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is PlaybackControl { IsVisible: not false } playbackControl)
		{
			playbackControl.Focus();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
