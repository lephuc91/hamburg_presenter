using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.DO.Triggering;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.CueInspector;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.CueInspector;

public partial class PlaybackMarkerList : DragDropListBox<IPlaybackMarkerItemVM>, IComponentConnector
{
	private bool _showDialog;

	public static readonly DependencyProperty MovePlayheadToMarkerCommandProperty = DependencyProperty.Register("MovePlayheadToMarkerCommand", typeof(ICommand<IPlaybackMarkerItemVM>), typeof(PlaybackMarkerList));

	public static readonly DependencyProperty DropActionCommandProperty = DependencyProperty.Register("DropActionCommand", typeof(ICommand<PlaybackMarkerDropParameter>), typeof(PlaybackMarkerList));

	public static readonly DependencyProperty UpdateDialogPlacementCommandProperty = DependencyProperty.Register("UpdateDialogPlacementCommand", typeof(ICommand<FrameworkElement>), typeof(PlaybackMarkerList));

	protected override IDragDropCollection<IPlaybackMarkerItemVM>? SourceCollection => base.ItemsSource as IDragDropCollection<IPlaybackMarkerItemVM>;

	public ICommand<IPlaybackMarkerItemVM>? MovePlayheadToMarkerCommand
	{
		get
		{
			return (ICommand<IPlaybackMarkerItemVM>)((DependencyObject)this).GetValue(MovePlayheadToMarkerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MovePlayheadToMarkerCommandProperty, (object)value);
		}
	}

	public ICommand<PlaybackMarkerDropParameter>? DropActionCommand
	{
		get
		{
			return (ICommand<PlaybackMarkerDropParameter>)((DependencyObject)this).GetValue(DropActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropActionCommandProperty, (object)value);
		}
	}

	public ICommand<FrameworkElement>? UpdateDialogPlacementCommand
	{
		get
		{
			return (ICommand<FrameworkElement>)((DependencyObject)this).GetValue(UpdateDialogPlacementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UpdateDialogPlacementCommandProperty, (object)value);
		}
	}

	public PlaybackMarkerList()
	{
		InitializeComponent();
		AddDropType((IEnumerable<IMacroItemVM> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<IMacroItemVM>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<MediaCue> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<MediaCue>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ClearType> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<ClearType>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ActionType> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<ActionType>?)null, CanDropActionType, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<MediaType> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<MediaType>?)null, null, null, OnDropMediaType, insideOnly: false, canDropInside: true);
		AddDropType(OnDropPlaylist, (DraggedTreeItemsCollection<IPlaylist<MediaCue>> i, DragEventArgs e) => true, insideOnly: false, canDropInside: true);
		AddFileDrop(OnFileDrop, null, CanDropFile, canDropInside: true);
		AddDropType((IEnumerable<ScreenArrangementBase> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<ScreenArrangementBase>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ITimerVM> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<ITimerVM>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<Message> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<Message>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IPropCue> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<IPropCue>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IClearGroupItemVM> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<IClearGroupItemVM>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IPropCueVM> c, DragEventArgs d) => c, (IDragDropCollection<IPlaybackMarkerItemVM>? d) => (IDragDropCollection<IPropCueVM>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
	}

	protected override bool CanDrag()
	{
		return false;
	}

	private void OnDropData<T>(DraggedItems<T> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog: false);
	}

	private bool CanDropActionType(DraggedItems<ActionType> draggedItems, DragEventArgs e)
	{
		return draggedItems.Items.All((ActionType a) => a != ActionType.Capture);
	}

	private void OnDropDataShowDialog<T>(DraggedItems<T> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog: true);
	}

	private void OnDropPlaylist(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> d) => d.Items).ToArray(), dropIndex, dropInside, canShowDialog: true);
	}

	private void OnDropMediaType(DraggedItems<MediaType> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		bool canShowDialog = items.Items.All((MediaType m) => m == MediaType.LiveVideo);
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog);
	}

	private void DoDrop(IEnumerable dropData, int dropIndex, bool dropInside, bool canShowDialog)
	{
		_showDialog = canShowDialog;
		IPlaybackMarkerItemVM item = base.ItemsSource.OfType<IPlaybackMarkerItemVM>().ElementAtOrDefault(dropIndex);
		FrameworkElement frameworkElement = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
		bool dropBefore = true;
		if (frameworkElement != null && frameworkElement.DataContext is IPlaybackMarkerItemVM targetItem)
		{
			dropBefore = base.Items.OfType<IPlaybackMarkerItemVM>().IndexOf(targetItem) == dropIndex;
		}
		DropActionCommand?.Invoke(new PlaybackMarkerDropParameter(dropData, frameworkElement, dropBefore, !dropInside));
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		return files.All((FileInfo f) => f.FullName.IsMediaFile());
	}

	private void OnFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		DoDrop(files, dropIndex, dropInside, canShowDialog: false);
	}

	protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnItemsChanged(e);
		IPlaybackMarkerItemVM newItem;
		if (base.IsLoaded && _showDialog)
		{
			newItem = e.NewItems?.Cast<IPlaybackMarkerItemVM>().FirstOrDefault();
			if (newItem != null)
			{
				base.ItemContainerGenerator.StatusChanged += statusChanged;
			}
		}
		void loaded(object? sender, EventArgs arg)
		{
			if (sender is ListBoxItem listBoxItem2)
			{
				listBoxItem2.Loaded -= loaded;
				UpdateDialogPlacementCommand?.Invoke(listBoxItem2);
				_showDialog = false;
			}
		}
		void statusChanged(object? sender, EventArgs arg)
		{
			ListBoxItem listBoxItem = (ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(newItem);
			if (listBoxItem != null)
			{
				base.ItemContainerGenerator.StatusChanged -= statusChanged;
				if (listBoxItem.IsLoaded)
				{
					UpdateDialogPlacementCommand?.Invoke(listBoxItem);
					_showDialog = false;
				}
				else
				{
					listBoxItem.Loaded += loaded;
				}
			}
		}
	}

	protected override void OnUpdateDropIndicator(bool insideOnly, bool canDropInside, int dropIndex, IPlaybackMarkerItemVM? dropTargetItem, bool dropInside)
	{
		if (!dropInside)
		{
			this.ShowDropIndicator(AdornerPosition.Inside);
		}
		else
		{
			base.OnUpdateDropIndicator(insideOnly, canDropInside, dropIndex, dropTargetItem, dropInside);
		}
	}

	protected override void SetSelection(IEnumerable<IPlaybackMarkerItemVM> selectedItems, bool leftClick)
	{
		base.SetSelection(selectedItems, leftClick);
		if (leftClick && selectedItems.Any())
		{
			MovePlayheadToMarkerCommand?.Invoke(selectedItems.First());
		}
	}
}
