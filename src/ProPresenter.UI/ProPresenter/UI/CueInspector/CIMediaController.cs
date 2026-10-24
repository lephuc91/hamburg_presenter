using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.UI.CueInspector;

public partial class CIMediaController : UserControl, IComponentConnector
{
	public static readonly DependencyProperty PlaybackMarkersProperty = DependencyProperty.Register("PlaybackMarkers", typeof(INotifyEnumerableChanged<IPlaybackMarkerItemVM>), typeof(CIMediaController));

	public static readonly DependencyProperty MarkerColorProperty = DependencyProperty.Register("MarkerColor", typeof(Color), typeof(CIMediaController), new PropertyMetadata((object)default(Color)));

	public static readonly DependencyProperty MarkerNameProperty = DependencyProperty.Register("MarkerName", typeof(string), typeof(CIMediaController));

	public static readonly DependencyProperty AddPlaybackMarkerCommandProperty = DependencyProperty.Register("AddPlaybackMarkerCommand", typeof(ICommand), typeof(CIMediaController));

	public static readonly DependencyProperty MoveToPlayheadCommandProperty = DependencyProperty.Register("MoveToPlayheadCommand", typeof(ICommand), typeof(CIMediaController));

	public static readonly DependencyProperty ActionsMenuVMProperty = DependencyProperty.Register("ActionsMenuVM", typeof(IActionsMenuVM), typeof(CIMediaController));

	public static readonly DependencyProperty SelectMarkerCommandProperty = DependencyProperty.Register("SelectMarkerCommand", typeof(ICommand<IPlaybackMarkerItemVM>), typeof(CIMediaController));

	public static readonly DependencyProperty SetContextMenuPositionCommandProperty = DependencyProperty.Register("SetContextMenuPositionCommand", typeof(ICommand<TimeSlice?>), typeof(CIMediaController));

	public static readonly DependencyProperty ContextMenuTargetProperty = DependencyProperty.Register("ContextMenuTarget", typeof(FrameworkElement), typeof(CIMediaController));

	public INotifyEnumerableChanged<IPlaybackMarkerItemVM>? PlaybackMarkers
	{
		get
		{
			return (INotifyEnumerableChanged<IPlaybackMarkerItemVM>)((DependencyObject)this).GetValue(PlaybackMarkersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaybackMarkersProperty, (object)value);
		}
	}

	public Color MarkerColor
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(MarkerColorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerColorProperty, (object)value);
		}
	}

	public string? MarkerName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MarkerNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerNameProperty, (object)value);
		}
	}

	public ICommand? AddPlaybackMarkerCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddPlaybackMarkerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddPlaybackMarkerCommandProperty, (object)value);
		}
	}

	public ICommand? MoveToPlayheadCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(MoveToPlayheadCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MoveToPlayheadCommandProperty, (object)value);
		}
	}

	public IActionsMenuVM? ActionsMenuVM
	{
		get
		{
			return (IActionsMenuVM)((DependencyObject)this).GetValue(ActionsMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionsMenuVMProperty, (object)value);
		}
	}

	public ICommand<IPlaybackMarkerItemVM>? SelectMarkerCommand
	{
		get
		{
			return (ICommand<IPlaybackMarkerItemVM>)((DependencyObject)this).GetValue(SelectMarkerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectMarkerCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice?>? SetContextMenuPositionCommand
	{
		get
		{
			return (ICommand<TimeSlice?>)((DependencyObject)this).GetValue(SetContextMenuPositionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetContextMenuPositionCommandProperty, (object)value);
		}
	}

	public FrameworkElement? ContextMenuTarget
	{
		get
		{
			return (FrameworkElement)((DependencyObject)this).GetValue(ContextMenuTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextMenuTargetProperty, (object)value);
		}
	}

	public CIMediaController()
	{
		InitializeComponent();
	}

	private void MarkerMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } && placementTarget.DataContext is IPlaybackMarkerItemVM)
		{
			((DependencyObject)this).SetCurrentValue(ContextMenuTargetProperty, (object)placementTarget);
		}
	}

	private void MarkerMenu_Closed(object? sender, RoutedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(ContextMenuTargetProperty, (object)null);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
