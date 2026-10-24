using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Settings;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaView : UserControl, IComponentConnector
{
	private const double DragCollapseThreshold = 20.0;

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(MediaView));

	public static readonly DependencyProperty SortMediaItemsCommandProperty = DependencyProperty.Register("SortMediaItemsCommand", typeof(ICommand<SortMediaItemsCommandParameter>), typeof(MediaView));

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(MediaView));

	public static readonly DependencyProperty SetMediaTransitionCommandProperty = DependencyProperty.Register("SetMediaTransitionCommand", typeof(ICommand<TransitionParameters>), typeof(MediaView));

	public static readonly DependencyProperty MediaContextMenuPlacementTargetProperty = DependencyProperty.Register("MediaContextMenuPlacementTarget", typeof(UIElement), typeof(MediaView));

	public IEnumerable<TimeSlice> SoftLoopDurations { get; } = SoftLoopHelper.Durations;

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

	public ICommand<SortMediaItemsCommandParameter>? SortMediaItemsCommand
	{
		get
		{
			return (ICommand<SortMediaItemsCommandParameter>)((DependencyObject)this).GetValue(SortMediaItemsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SortMediaItemsCommandProperty, (object)value);
		}
	}

	public ICommand? GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public ICommand<TransitionParameters>? SetMediaTransitionCommand
	{
		get
		{
			return (ICommand<TransitionParameters>)((DependencyObject)this).GetValue(SetMediaTransitionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaTransitionCommandProperty, (object)value);
		}
	}

	private UIElement? MediaContextMenuPlacementTarget
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(MediaContextMenuPlacementTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaContextMenuPlacementTargetProperty, (object)value);
		}
	}

	public MediaView()
	{
		InitializeComponent();
	}

	private void MediaView_GotFocus(object? sender, RoutedEventArgs e)
	{
		GotFocusCommand?.Invoke();
	}

	private void MediaColumnSplitter_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		if (0.0 - e.HorizontalChange >= LeftColumn.ActualWidth - 20.0)
		{
			Layout.Settings.MediaPlaylistsCollapsed = true;
		}
		else if (e.HorizontalChange >= LeftColumn.MinWidth)
		{
			Layout.Settings.MediaPlaylistsCollapsed = false;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
