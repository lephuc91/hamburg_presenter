using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public partial class TimelineViewer : UserControl, IComponentConnector
{
	private TimeSlice _menuOpenedTime = TimeSlice.Zero;

	private readonly IActionDialogService _actionDialogService;

	private readonly ITimelineVM _vm;

	public static readonly DependencyProperty DocumentCueProperty = DependencyProperty.Register("DocumentCue", typeof(IDocumentCue), typeof(TimelineViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TimelineViewer timelineViewer && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is IDocumentCue parameter)
		{
			timelineViewer.DocumentCueUpdatedCommand?.Invoke(parameter);
			timelineViewer.SelectedItems?.Clear();
		}
	}));

	public static readonly DependencyProperty TimelineActionsMenuVMProperty = DependencyProperty.Register("TimelineActionsMenuVM", typeof(IActionsMenuVM), typeof(TimelineViewer), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TimelineViewer timelineViewer2)
		{
			if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue is IActionsMenuVM actionsMenuVM)
			{
				actionsMenuVM.ShowActionDialog -= timelineViewer2.EditAction;
			}
			timelineViewer2.ActionsMenuVM = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IActionsMenuVM;
			if (timelineViewer2.ActionsMenuVM != null)
			{
				timelineViewer2.ActionsMenuVM.ShowActionDialog += timelineViewer2.EditAction;
			}
		}
	}));

	public static readonly DependencyProperty ActionsMenuVMProperty = DependencyProperty.Register("ActionsMenuVM", typeof(IActionsMenuVM), typeof(TimelineViewer));

	public static readonly DependencyProperty DocumentCueUpdatedCommandProperty = DependencyProperty.Register("DocumentCueUpdatedCommand", typeof(ICommand<IDocumentCue>), typeof(TimelineViewer));

	public static readonly DependencyProperty ActionsViewProperty = DependencyProperty.Register("ActionsView", typeof(ICollectionView), typeof(TimelineViewer));

	public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register("CurrentTime", typeof(TimeSlice), typeof(TimelineViewer), new PropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnCurrentTimeChanged)));

	public static readonly DependencyProperty DeselectAllCommandProperty = DependencyProperty.Register("DeselectAllCommand", typeof(ICommand), typeof(TimelineViewer));

	public static readonly DependencyProperty SelectAllCommandProperty = DependencyProperty.Register("SelectAllCommand", typeof(ICommand), typeof(TimelineViewer));

	public static readonly DependencyProperty SelectedActionsProperty = DependencyProperty.Register("SelectedActions", typeof(ObservableCollection<IActionRepository>), typeof(TimelineViewer));

	public static readonly DependencyProperty AddMediaActionCommandProperty = DependencyProperty.Register("AddMediaActionCommand", typeof(ICommand<TimeSlice>), typeof(TimelineViewer));

	public static readonly DependencyProperty AddAudioActionCommandProperty = DependencyProperty.Register("AddAudioActionCommand", typeof(ICommand<TimeSlice>), typeof(TimelineViewer));

	public static readonly DependencyProperty SelectedMediaItemProperty = DependencyProperty.Register("SelectedMediaItem", typeof(MediaAction), typeof(TimelineViewer));

	public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<ITimelineItemVM>), typeof(TimelineViewer));

	public IDocumentCue? DocumentCue
	{
		get
		{
			return (IDocumentCue)((DependencyObject)this).GetValue(DocumentCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentCueProperty, (object)value);
		}
	}

	public IActionsMenuVM? TimelineActionsMenuVM
	{
		get
		{
			return (IActionsMenuVM)((DependencyObject)this).GetValue(TimelineActionsMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimelineActionsMenuVMProperty, (object)value);
		}
	}

	public MediaAction? SelectedMediaItem
	{
		get
		{
			return (MediaAction)((DependencyObject)this).GetValue(SelectedMediaItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedMediaItemProperty, (object)value);
		}
	}

	public ObservableCollection<ITimelineItemVM>? SelectedItems
	{
		get
		{
			return (ObservableCollection<ITimelineItemVM>)((DependencyObject)this).GetValue(SelectedItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemsProperty, (object)value);
		}
	}

	public ObservableCollection<IActionRepository>? SelectedActions
	{
		get
		{
			return (ObservableCollection<IActionRepository>)((DependencyObject)this).GetValue(SelectedActionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedActionsProperty, (object)value);
		}
	}

	public ICommand<TimeSlice>? AddAudioActionCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(AddAudioActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddAudioActionCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice>? AddMediaActionCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(AddMediaActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddMediaActionCommandProperty, (object)value);
		}
	}

	public ICommand? SelectAllCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectAllCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAllCommandProperty, (object)value);
		}
	}

	public ICommand? DeselectAllCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DeselectAllCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeselectAllCommandProperty, (object)value);
		}
	}

	public TimeSlice CurrentTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(CurrentTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentTimeProperty, (object)value);
		}
	}

	public ICollectionView? ActionsView
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ICollectionView)((DependencyObject)this).GetValue(ActionsViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionsViewProperty, (object)value);
		}
	}

	public ICommand<IDocumentCue>? DocumentCueUpdatedCommand
	{
		get
		{
			return (ICommand<IDocumentCue>)((DependencyObject)this).GetValue(DocumentCueUpdatedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentCueUpdatedCommandProperty, (object)value);
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

	public TimelineViewer()
	{
		ITimelineVMFactory service = UIServiceProvider.GetService<ITimelineVMFactory>();
		_vm = service.CreateVM();
		base.DataContext = _vm;
		InitializeComponent();
		LoadBindings();
		_actionDialogService = UIServiceProvider.GetService<IActionDialogService>();
	}

	private void LoadBindings()
	{
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, SelectAllCommand);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, DeselectAllCommand);
		if (base.DataContext != null)
		{
			SetBinding(SelectedItemsProperty, new Binding("SelectedItems"));
			SetBinding(SelectedMediaItemProperty, new Binding("SelectedMediaItem"));
			SetBinding(AddMediaActionCommandProperty, "AddMediaActionCommand");
			SetBinding(AddAudioActionCommandProperty, "AddAudioActionCommand");
			SetBinding(SelectAllCommandProperty, "SelectAllCommand");
			SetBinding(DeselectAllCommandProperty, "DeselectAllCommand");
			SetBinding(CurrentTimeProperty, "CurrentTime");
			SetBinding(ActionsViewProperty, new Binding("ActionsView"));
			SetBinding(DocumentCueUpdatedCommandProperty, "DocumentCueUpdatedCommand");
			SetBinding(ActionsMenuVMProperty, new Binding("ActionsMenuVM")
			{
				Mode = BindingMode.TwoWay
			});
			SetBinding(SelectedActionsProperty, "SelectedActions");
		}
	}

	private FrameworkElement? GetActionDialogElement(IAction? action)
	{
		TimelineRow? obj = TimelineControl.Rows?.LastOrDefault();
		ITimelineItemVM item = ((IEnumerable)ActionsView)?.OfType<ITimelineItemVM>().FirstOrDefault((ITimelineItemVM i) => i.Item != null && i.Item.Item == action);
		return ((DependencyObject)(object)(obj?.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement))?.FindVisualChild<ActionItemTemplate>();
	}

	private void EditAction(IAction? action, IActionRepository? repo, IEnumerable<IActionRepository> otherRepo)
	{
		_actionDialogService?.ShowEditActionDialog(new ActionDialogParameter(GetActionDialogElement(action), action, DocumentCue?.DocumentAction?.Presentation?.PresentationTimeline, null));
	}

	private static void OnCurrentTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TimelineViewer timelineViewer)
		{
			timelineViewer.InvalidateVisual();
		}
	}

	private void OnActionItemTemplateLoaded(object? sender, RoutedEventArgs e)
	{
		if (sender is FrameworkElement placement)
		{
			_actionDialogService?.UpdateDialogPlacementTarget(placement);
		}
	}

	private void OnActionsContextMenuOpened(object? sender, RoutedEventArgs e)
	{
		if (!(sender is ContextMenu contextMenu))
		{
			return;
		}
		TimeSlice addTimelineItemLocationTime = TimelineControl.GetAddTimelineItemLocationTime();
		TimelineActions timelineActions = null;
		Timeline timeline = DocumentCue?.DocumentAction?.Presentation?.PresentationTimeline;
		if (timeline != null)
		{
			if (contextMenu.PlacementTarget is TimelineRow)
			{
				timelineActions = new TimelineActions(timeline);
			}
			else if (contextMenu.PlacementTarget is ActionItemTemplate { DataContext: ITimelineItemVM dataContext } actionItemTemplate)
			{
				IEnumerable<ActionBase> enumerable = (dataContext.Item?.Item as ActionBase)?.ToEnumerable();
				TimelineRow parentRow = ((DependencyObject)(object)actionItemTemplate).FindVisualParent<TimelineRow>();
				if (parentRow != null)
				{
					IEnumerable<ActionBase> second = (from i in (from i in parentRow.Items.OfType<ITimelineItemVM>()
							select parentRow.ItemContainerGenerator.ContainerFromItem(i)).OfType<TimelineSection>()
						where i.IsSelected
						select i.Item?.Item?.Item).OfType<ActionBase>();
					enumerable = (enumerable ?? Enumerable.Empty<ActionBase>()).Concat(second).NonNull().Distinct();
				}
				timelineActions = new TimelineActions(timeline, enumerable);
			}
		}
		if (timelineActions != null)
		{
			timelineActions.TargetTime = addTimelineItemLocationTime;
			SelectedActions?.Clear();
			SelectedActions?.Add(timelineActions);
		}
	}

	private void OnMediaRowContextMenuOpened(object? sender, RoutedEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		TimelineControl timelineControl = TimelineControl;
		Point position = Mouse.GetPosition(TimelineControl);
		_menuOpenedTime = timelineControl.CanvasLocationToTime(((Point)(ref position)).X);
	}

	private void OnAddMediaActionClicked(object? sender, RoutedEventArgs e)
	{
		AddMediaActionCommand?.Invoke(_menuOpenedTime);
	}

	private void OnAddAudioActionClicked(object? sender, RoutedEventArgs e)
	{
		AddAudioActionCommand?.Invoke(_menuOpenedTime);
	}

	private void OnMediaRowTransitionClicked(object? sender, RoutedEventArgs e)
	{
		UIElement uIElement = ((DependencyObject)(object)(sender as MenuItem))?.FindVisualParent<ContextMenu>()?.PlacementTarget;
		MediaAction selectedMediaItem = SelectedMediaItem;
		IEnumerable<MediaAction> others = SelectedItems?.Select((ITimelineItemVM i) => i.Item?.Item as MediaAction).NonNull() ?? Enumerable.Empty<MediaAction>();
		if ((object)selectedMediaItem?.SelectedTransition == null || uIElement == null)
		{
			return;
		}
		_vm.SetTransition(selectedMediaItem.SelectedTransition, uIElement, delegate(TransitionParameters n)
		{
			foreach (MediaAction item in others)
			{
				item.SelectedTransition = n;
			}
		});
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
