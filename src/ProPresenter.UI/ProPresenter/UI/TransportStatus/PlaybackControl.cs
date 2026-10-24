using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.UI.Utility;
using ProPresenter.DO.Media;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.TransportStatus;

namespace ProPresenter.UI.TransportStatus;

public partial class PlaybackControl : UserControl, IComponentConnector
{
	private static readonly DependencyProperty ContextMenuTargetProperty = DependencyProperty.Register("ContextMenuTarget", typeof(FrameworkElement), typeof(PlaybackControl));

	private FrameworkElement? ContextMenuTarget
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

	public PlaybackControl()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		InitializeComponent();
		base.Focusable = true;
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(OnDataContextChanged);
	}

	private void OnDataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IPlaybackStatusVM playbackStatusVM)
		{
			playbackStatusVM.PropertyChanged -= OnPlaybackStatusVM_PropertyChanged;
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IPlaybackStatusVM playbackStatusVM2)
		{
			playbackStatusVM2.PropertyChanged += OnPlaybackStatusVM_PropertyChanged;
		}
		RefreshFilteredMarkers();
	}

	private void OnPlaybackStatusVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "TriggeredMedia" || propertyName == "Duration")
		{
			RefreshFilteredMarkers();
		}
	}

	private void RefreshFilteredMarkers()
	{
		CollectionViewSource obj = TryFindResource("FilteredMarkerItems") as CollectionViewSource;
		if (obj != null)
		{
			ICollectionView view = obj.View;
			if (view != null)
			{
				view.Refresh();
			}
		}
	}

	private void MarkerItem_OnFilter(object? sender, FilterEventArgs e)
	{
		if (base.DataContext is IPlaybackStatusVM playbackStatusVM && e.Item is IPlaybackMarkerItemVM playbackMarkerItemVM)
		{
			TimeSlice timeSlice = (playbackStatusVM.TriggeredMedia as ITransportMedia)?.Transport?.InPoint ?? TimeSlice.Zero;
			TimeSlice timeSlice2 = (playbackStatusVM.TriggeredMedia as ITransportMedia)?.Transport?.OutPoint ?? TimeSlice.Zero;
			e.Accepted = playbackMarkerItemVM.Timestamp >= timeSlice && playbackMarkerItemVM.Timestamp <= timeSlice2;
		}
	}

	private void MarkerMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } && placementTarget.DataContext is IPlaybackMarkerItemVM && base.DataContext is IPlaybackStatusVM playbackStatusVM)
		{
			playbackStatusVM.ContextMenuTarget = placementTarget;
			((DependencyObject)this).SetCurrentValue(ContextMenuTargetProperty, (object)placementTarget);
		}
	}

	private void MarkerMenu_Closed(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IPlaybackStatusVM playbackStatusVM)
		{
			playbackStatusVM.ContextMenuTarget = null;
			((DependencyObject)this).SetCurrentValue(ContextMenuTargetProperty, (object)null);
		}
	}

	protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
	{
		Focus();
		base.OnPreviewMouseDown(e);
	}

	private void PlaybackControl_GotFocus(object? sender, RoutedEventArgs e)
	{
		(base.DataContext as IPlaybackStatusVM)?.GotFocusCommand?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
