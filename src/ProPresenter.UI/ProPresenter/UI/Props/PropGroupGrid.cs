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
using Pro.UI;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public class PropGroupGrid : UniformDragDropViewPanel<IPropCueVM, PropGridItemTemplate>
{
	public static readonly DependencyProperty MinItemWidthProperty = DependencyProperty.Register("MinItemWidth", typeof(double), typeof(PropGroupGrid));

	public static readonly DependencyProperty DragDropItemsSourceProperty = DependencyProperty.Register("DragDropItemsSource", typeof(IDragDropCollection<IPropCueVM>), typeof(PropGroupGrid));

	public static readonly DependencyProperty DropActionCommandProperty = DependencyProperty.Register("DropActionCommand", typeof(ICommand<PropsDropParameter>), typeof(UniformDragDropViewPanel<IPropCueVM, PropGridItemTemplate>));

	public static readonly DependencyProperty RenameNextItemProperty = DependencyProperty.Register("RenameNextItem", typeof(bool), typeof(UniformDragDropViewPanel<IPropCueVM, PropGridItemTemplate>));

	protected override IDragDropCollection<IPropCueVM> SourceCollection => DragDropItemsSource;

	public IDragDropCollection<IPropCueVM> DragDropItemsSource
	{
		get
		{
			return (IDragDropCollection<IPropCueVM>)((DependencyObject)this).GetValue(DragDropItemsSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropItemsSourceProperty, (object)value);
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

	public ICommand<PropsDropParameter> DropActionCommand
	{
		get
		{
			return (ICommand<PropsDropParameter>)((DependencyObject)this).GetValue(DropActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropActionCommandProperty, (object)value);
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

	public PropGroupGrid()
	{
		base.AllowDrag = true;
		base.AllowDrop = true;
		AddDropType(null, (DraggedItems<IPropCueVM> _, DragEventArgs _) => true);
		AddFileDrop(OnFileDrop, CanDropFile, canDropInside: true);
		AddCustomDrop(OnDropMediaBinCue, null, null, (DraggedItems<IMediaCueThumbnailVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropMediaCue, null, null, (DraggedItems<MediaCue> s, DragEventArgs e) => true);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()), canDropInside: true);
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		return files.All((FileInfo f) => f.FullName.IsVisualMediaFile());
	}

	private void OnFileDrop(FileInfo[] files, DragEventArgs e)
	{
		DropData(files);
	}

	private void OnDropMediaBinCue(DraggedItems<IMediaCueThumbnailVM> items, DragEventArgs e)
	{
		DropData(items.Items.Select((IMediaCueThumbnailVM v) => v.MediaCue));
	}

	private void OnDropMediaCue(DraggedItems<MediaCue> items, DragEventArgs e)
	{
		DropData(items.Items);
	}

	private void DropData(IEnumerable dropData)
	{
		DropActionCommand?.Invoke(new PropsDropParameter(dropData, base.DropIndex, base.TargetThumbnail, base.DroppedBefore, base.DroppedOutside));
		InvalidateVisual();
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		if (e.Source is PropGroupGrid)
		{
			((DependencyObject)this).SetCurrentValue(UniformViewPanel<IPropCueVM, PropGridItemTemplate>.SelectedItemProperty, (object)null);
			base.SelectedItems?.Clear();
		}
		base.OnContextMenuOpening(e);
	}

	protected override void OnSetupThumbnailControl(PropGridItemTemplate thumbnailControl, IPropCueVM item)
	{
		thumbnailControl.ContextMenu = base.ThumbnailContextMenu;
		thumbnailControl.ContextMenuOpening += delegate
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			OnThumbnailMenuOpening(thumbnailControl, Keyboard.Modifiers);
		};
		thumbnailControl.ClickedDelegate = base.OnThumbnailClicked;
	}

	protected override Visual CreateDragVisual(IEnumerable<IPropCueVM> draggedItems, PropGridItemTemplate draggedThumbnail)
	{
		return draggedThumbnail.ToDragVisual(draggedItems.Count(), new Vector2<double>(draggedThumbnail.MainBorder.ActualWidth, draggedThumbnail.MainBorder.ActualHeight));
	}

	public void FocusAndRenameItem(IPropCueVM itemVM)
	{
		if (RenameNextItem)
		{
			PropGridItemTemplate propGridItemTemplate = FindThumbnail(itemVM)?.Control;
			if (propGridItemTemplate != null)
			{
				Focus();
				propGridItemTemplate.Focus();
				CommonApplicationCommands.Rename.Invoke();
			}
		}
		((DependencyObject)this).SetCurrentValue(RenameNextItemProperty, (object)false);
	}
}
