using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.DO.Triggering;
using Pro.UI;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Macros;

public class MacroGridPanel : UniformDragDropViewPanel<IMacroItemVM, MacroGridItemTemplate>
{
	private bool _showDialog;

	public static readonly DependencyProperty MinItemWidthProperty = DependencyProperty.Register("MinItemWidth", typeof(double), typeof(MacroGridPanel));

	public static readonly DependencyProperty DragDropItemsSourceProperty = DependencyProperty.Register("DragDropItemsSource", typeof(IDragDropCollection<IMacroItemVM>), typeof(UniformDragDropViewPanel<IMacroItemVM, MacroGridItemTemplate>));

	public static readonly DependencyProperty DropActionCommandProperty = DependencyProperty.Register("DropActionCommand", typeof(ICommand<MacroDropParameter>), typeof(UniformDragDropViewPanel<IMacroItemVM, MacroGridItemTemplate>));

	public static readonly DependencyProperty UpdateDialogPlacementCommandProperty = DependencyProperty.Register("UpdateDialogPlacementCommand", typeof(ICommand<FrameworkElement>), typeof(UniformDragDropViewPanel<IMacroItemVM, MacroGridItemTemplate>));

	public static readonly DependencyProperty RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(UniformDragDropViewPanel<IMacroItemVM, MacroGridItemTemplate>));

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

	public double MinItemWidth
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(MinItemWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MinItemWidthProperty, (object)value);
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenameNextItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenameNextItemProperty, (object)value);
		}
	}

	public MacroGridPanel()
	{
		base.AllowDrag = true;
		base.AllowDrop = true;
		AddDropType(null, (DraggedItems<IMacroItemVM> _, DragEventArgs _) => true, OnDropMacroInside);
		AddCustomDrop(OnDropMediaBinCue, null, null, (DraggedItems<IMediaCueThumbnailVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropMediaCue, null, null, (DraggedItems<MediaCue> s, DragEventArgs e) => true);
		AddCustomDrop<IPlaylist<MediaCue>>(OnDropPlaylist, null, canDropInside: true);
		AddCustomDrop(OnDropDataShowDialog, (DraggedItems<ClearType> s, DragEventArgs e) => true, null, (DraggedItems<ClearType> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropDataShowDialog, (DraggedItems<ActionType> s, DragEventArgs e) => true, null, (DraggedItems<ActionType> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropMediaType, (DraggedItems<MediaType> s, DragEventArgs e) => true, null, (DraggedItems<MediaType> s, DragEventArgs e) => true);
		AddFileDrop(OnFileDrop, CanDropFile, canDropInside: true);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()), canDropInside: true);
		AddCustomDrop(OnDropDataShowDialog, (DraggedItems<Message> s, DragEventArgs e) => true, null, (DraggedItems<Message> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropDataShowDialog, (DraggedItems<ITimerVM> s, DragEventArgs e) => true, null, (DraggedItems<ITimerVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropDataShowDialog, CanDropStageScreen, null, (DraggedItems<ScreenArrangementBase> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropData, (DraggedItems<IClearGroupItemVM> s, DragEventArgs e) => true, null, (DraggedItems<IClearGroupItemVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropData, (DraggedItems<IPropCue> s, DragEventArgs e) => true, null, (DraggedItems<IPropCue> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropData, (DraggedItems<IPropCueVM> s, DragEventArgs e) => true, null, (DraggedItems<IPropCueVM> s, DragEventArgs e) => true);
		base.RequestBringIntoView += MacroGridPanel_RequestBringIntoView;
	}

	private void OnDropMacroInside(DraggedItems<IMacroItemVM> items, DragEventArgs e)
	{
		IEnumerable enumerable;
		if (e.Effects != DragDropEffects.Copy || !base.DroppedInside)
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
		OnDropData(dropData);
	}

	private void OnDropMediaBinCue(DraggedItems<IMediaCueThumbnailVM> items, DragEventArgs e)
	{
		OnDropData(items.Items.Select((IMediaCueThumbnailVM v) => v.MediaCue));
	}

	private void OnDropMediaCue(DraggedItems<MediaCue> items, DragEventArgs e)
	{
		OnDropData(items.Items);
	}

	private void OnDropPlaylist(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, DragEventArgs e)
	{
		OnDropData(items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> d) => d.Items).ToArray(), canShowDialog: true);
	}

	private void OnDropMediaType(DraggedItems<MediaType> items, DragEventArgs e)
	{
		bool canShowDialog = Array.TrueForAll(items.Items, (MediaType m) => m == MediaType.LiveVideo);
		OnDropData(items.Items, canShowDialog);
	}

	private bool CanDropStageScreen(DraggedItems<ScreenArrangementBase> items, DragEventArgs e)
	{
		return Array.TrueForAll(items.Items, (ScreenArrangementBase s) => s.ScreenTargetType == ScreenTargetType.Stage);
	}

	private void OnDropDataShowDialog<T>(DraggedItems<T> items, DragEventArgs e)
	{
		OnDropData(items.Items, canShowDialog: true);
	}

	private void OnDropData<T>(DraggedItems<T> items, DragEventArgs e)
	{
		OnDropData(items.Items);
	}

	private void OnDropData(IEnumerable dropData, bool canShowDialog = false)
	{
		_showDialog = canShowDialog;
		DropActionCommand?.Invoke(new MacroDropParameter(dropData, base.TargetThumbnail, base.DroppedBefore, base.DroppedOutside));
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		return Array.TrueForAll(files, (FileInfo f) => f.FullName.IsMediaFile());
	}

	private void OnFileDrop(FileInfo[] files, DragEventArgs e)
	{
		OnDropData(files);
	}

	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		SetRowCapacity();
		base.OnRenderSizeChanged(sizeInfo);
	}

	protected override void OnSetupThumbnailControl(MacroGridItemTemplate thumbnailControl, IMacroItemVM item)
	{
		thumbnailControl.ContextMenu = base.ThumbnailContextMenu;
		thumbnailControl.ContextMenuOpening += delegate
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			OnThumbnailMenuOpening(thumbnailControl, Keyboard.Modifiers);
		};
		if (thumbnailControl.IsLoaded)
		{
			if (_showDialog)
			{
				UpdateDialogPlacementCommand?.Invoke(thumbnailControl);
			}
			_showDialog = false;
		}
		thumbnailControl.Loaded += ThumbnailControl_Loaded;
		thumbnailControl.ClickedDelegate = base.OnThumbnailClicked;
	}

	private void ThumbnailControl_Loaded(object? sender, RoutedEventArgs e)
	{
		if (sender is MacroGridItemTemplate macroGridItemTemplate)
		{
			if (_showDialog)
			{
				UpdateDialogPlacementCommand?.Invoke(macroGridItemTemplate);
			}
			macroGridItemTemplate.Loaded -= ThumbnailControl_Loaded;
		}
	}

	public void FocusAndRenameItem(IMacroItemVM macroItemVM)
	{
		if (RenameNextItem)
		{
			MacroGridItemTemplate macroGridItemTemplate = FindThumbnail(macroItemVM)?.Control;
			if (macroGridItemTemplate != null)
			{
				Focus();
				macroGridItemTemplate.Focus();
				CommonApplicationCommands.Rename.Invoke();
			}
		}
		((DependencyObject)this).SetCurrentValue(RenameNextItemProperty, (object)false);
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		if (e.Source is MacroGridPanel)
		{
			((DependencyObject)this).SetCurrentValue(UniformViewPanel<IMacroItemVM, MacroGridItemTemplate>.SelectedItemProperty, (object)null);
			base.SelectedItems?.Clear();
		}
		base.OnContextMenuOpening(e);
	}

	private void SetRowCapacity()
	{
		((DependencyObject)this).SetCurrentValue(UniformViewPanel<IMacroItemVM, MacroGridItemTemplate>.RowCapacityProperty, (object)GetRowCapacity(base.ActualWidth));
	}

	private static int GetRowCapacity(double availableWidth)
	{
		availableWidth = Math.Max(0.0, availableWidth);
		return (int)Math.Max(1.0, Math.Ceiling(availableWidth / 95.0));
	}

	protected override Visual CreateDragVisual(IEnumerable<IMacroItemVM> draggedItems, MacroGridItemTemplate draggedThumbnail)
	{
		return draggedThumbnail.ToDragVisual(draggedItems.Count(), new Vector2<double>(draggedThumbnail.MainBorder.ActualWidth, draggedThumbnail.MainBorder.ActualHeight));
	}

	private void MacroGridPanel_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}
}
