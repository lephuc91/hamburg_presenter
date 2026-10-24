using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.UI.CueInspector;

public partial class PlaybackMarkers : UserControl, IComponentConnector
{
	public PlaybackMarkers()
	{
		InitializeComponent();
	}

	private void MarkerMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } && placementTarget.DataContext is IPlaybackMarkerItemVM && base.DataContext is IPlaybackMarkersVM playbackMarkersVM)
		{
			playbackMarkersVM.ContextMenuTarget = placementTarget;
		}
	}

	private void MarkerMenu_Closed(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IPlaybackMarkersVM playbackMarkersVM)
		{
			playbackMarkersVM.ContextMenuTarget = null;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
