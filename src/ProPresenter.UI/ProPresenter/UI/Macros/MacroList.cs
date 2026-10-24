using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
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
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Macros;

public class MacroList : DragDropListBox<IMacroItemVM>
{
	private bool _showDialog;

	public static readonly DependencyProperty DragDropItemsSourceProperty = DependencyProperty.Register("DragDropItemsSource", typeof(IDragDropCollection<IMacroItemVM>), typeof(MacroList));

	public static readonly DependencyProperty DropActionCommandProperty = DependencyProperty.Register("DropActionCommand", typeof(ICommand<MacroDropParameter>), typeof(MacroList));

	public static readonly DependencyProperty UpdateDialogPlacementCommandProperty = DependencyProperty.Register("UpdateDialogPlacementCommand", typeof(ICommand<FrameworkElement>), typeof(MacroList));

	protected override IDragDropCollection<IMacroItemVM> SourceCollection => DragDropItemsSource;

	public IDragDropCollection<IMacroItemVM> DragDropItemsSource
	{
		get
		{
			return (IDragDropCollection<IMacroItemVM>)((DependencyObject)this).GetValue(DragDropItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropItemsSourceProperty, (object)value);
		}
	}

	public ICommand<MacroDropParameter> DropActionCommand
	{
		get
		{
			return (ICommand<MacroDropParameter>)((DependencyObject)this).GetValue(DropActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropActionCommandProperty, (object)value);
		}
	}

	public ICommand<FrameworkElement> UpdateDialogPlacementCommand
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

	public MacroList()
	{
		AddDropType(null, null, null, (DraggedItems<IMacroItemVM> _, DragEventArgs _) => true, OnDropMacInside);
		AddDropType((IEnumerable<MediaCue> c, DragEventArgs _) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<MediaCue>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IMediaCueThumbnailVM> c, DragEventArgs d) => c.Select((IMediaCueThumbnailVM v) => v.MediaCue), (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<MediaCue>?)null, null, null, OnDropMediaBinCue, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ClearType> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<ClearType>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ActionType> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<ActionType>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<MediaType> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<MediaType>?)null, null, null, OnDropMediaType, insideOnly: false, canDropInside: true);
		AddDropType(OnDropPlaylist, (DraggedTreeItemsCollection<IPlaylist<MediaCue>> i, DragEventArgs e) => true, insideOnly: false, canDropInside: true);
		AddFileDrop(OnFileDrop, null, CanDropFile, canDropInside: true);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()), canDropInside: true);
		AddDropType((IEnumerable<ScreenArrangementBase> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<ScreenArrangementBase>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<ITimerVM> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<ITimerVM>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<Message> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<Message>?)null, null, null, OnDropDataShowDialog, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IPropCue> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<IPropCue>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IClearGroupItemVM> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<IClearGroupItemVM>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IPropCueVM> c, DragEventArgs d) => c, (IDragDropCollection<IMacroItemVM>? d) => (IDragDropCollection<IPropCueVM>?)null, null, null, OnDropData, insideOnly: false, canDropInside: true);
	}

	protected override bool CanSelect(IMacroItemVM item, MouseButtonEventArgs? e)
	{
		return KeyboardHelper.IsModifierPressed((ModifierKeys)2);
	}

	private void OnDropMacInside(DraggedItems<IMacroItemVM> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		IEnumerable enumerable;
		if (!(e.Effects == DragDropEffects.Copy && dropInside))
		{
			IEnumerable items2 = items.Items;
			enumerable = items2;
		}
		else
		{
			IEnumerable items2 = items.Items.SelectMany((IMacroItemVM m) => m.Macro.Actions);
			enumerable = items2;
		}
		IEnumerable dropData = enumerable;
		DoDrop(dropData, dropIndex, dropInside, canShowDialog: false);
	}

	private void OnDropMediaBinCue(DraggedItems<IMediaCueThumbnailVM> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items.Select((IMediaCueThumbnailVM v) => v.MediaCue), dropIndex, dropInside, canShowDialog: false);
	}

	private void OnDropMediaType(DraggedItems<MediaType> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		bool canShowDialog = items.Items.All((MediaType m) => m == MediaType.LiveVideo);
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog);
	}

	private void OnDropData<T>(DraggedItems<T> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog: false);
	}

	private void OnDropDataShowDialog<T>(DraggedItems<T> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.Items, dropIndex, dropInside, canShowDialog: true);
	}

	private void OnDropPlaylist(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		DoDrop(items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> d) => d.Items).ToArray(), dropIndex, dropInside, canShowDialog: true);
	}

	private void DoDrop(IEnumerable dropData, int dropIndex, bool dropInside, bool canShowDialog)
	{
		_showDialog = canShowDialog;
		IMacroItemVM item = base.ItemsSource.OfType<IMacroItemVM>().ElementAtOrDefault(dropIndex);
		FrameworkElement frameworkElement = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
		bool dropBefore = true;
		if (frameworkElement != null && frameworkElement.DataContext is IMacroItemVM targetItem)
		{
			dropBefore = base.Items.OfType<IMacroItemVM>().IndexOf(targetItem) == dropIndex;
		}
		DropActionCommand?.Invoke(new MacroDropParameter(dropData, frameworkElement, dropBefore, !dropInside));
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
		if (!base.IsLoaded)
		{
			return;
		}
		IMacroItemVM newItem = e.NewItems?.Cast<IMacroItemVM>().FirstOrDefault();
		if (newItem != null)
		{
			if (_showDialog)
			{
				base.ItemContainerGenerator.StatusChanged += statusChanged;
			}
			ScrollIntoView(newItem);
		}
		void loaded(object? sender, EventArgs arg)
		{
			if (sender is Pro.UI.Controls.ListBoxItem listBoxItem2)
			{
				listBoxItem2.Loaded -= loaded;
				UpdateDialogPlacementCommand?.Invoke(listBoxItem2);
				_showDialog = false;
			}
		}
		void statusChanged(object? sender, EventArgs arg)
		{
			Pro.UI.Controls.ListBoxItem listBoxItem = (Pro.UI.Controls.ListBoxItem)(object)base.ItemContainerGenerator.ContainerFromItem(newItem);
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

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		if (e.OriginalSource is FrameworkElement frameworkElement && frameworkElement.DataContext is IMacroGroupVM)
		{
			((DependencyObject)this).SetCurrentValue(ListBoxBase<IMacroItemVM, Pro.UI.Controls.ListBoxItem>.SelectedListItemProperty, (object)null);
			base.SelectedListItems?.Clear();
		}
		base.OnContextMenuOpening(e);
	}
}
