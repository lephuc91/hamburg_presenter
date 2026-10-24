using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Props;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.Props;

public class PropList : DragDropListBox<IPropCue>
{
	public static readonly DependencyProperty DragDropCollectionProperty = DependencyProperty.Register("DragDropCollection", typeof(IDragDropCollection<IPropCue>), typeof(PropList));

	public static readonly DependencyProperty DropFilesCommandProperty = DependencyProperty.Register("DropFilesCommand", typeof(ICommand<DropMediaCommandParameters>), typeof(PropList));

	public static readonly DependencyProperty DropMediaCueCommandProperty = DependencyProperty.Register("DropMediaCueCommand", typeof(ICommand<DropMediaCommandParameters>), typeof(PropList));

	public IDragDropCollection<IPropCue> DragDropCollection
	{
		get
		{
			return (IDragDropCollection<IPropCue>)((DependencyObject)this).GetValue(DragDropCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropCollectionProperty, (object)value);
		}
	}

	protected override IDragDropCollection<IPropCue> SourceCollection => DragDropCollection;

	public ICommand<DropMediaCommandParameters> DropFilesCommand
	{
		get
		{
			return (ICommand<DropMediaCommandParameters>)((DependencyObject)this).GetValue(DropFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropFilesCommandProperty, (object)value);
		}
	}

	public ICommand<DropMediaCommandParameters> DropMediaCueCommand
	{
		get
		{
			return (ICommand<DropMediaCommandParameters>)((DependencyObject)this).GetValue(DropMediaCueCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropMediaCueCommandProperty, (object)value);
		}
	}

	public PropList()
	{
		AddDropType(null, null, null, (DraggedItems<IPropCue> _, DragEventArgs _) => true);
		AddFileDrop(OnFileDrop, null, CanDropFile, canDropInside: true);
		AddDropType((IEnumerable<MediaCue> c, DragEventArgs d) => c, (IDragDropCollection<IPropCue>? d) => (IDragDropCollection<MediaCue>?)null, CanDropMediaCue, null, OnMediaCueDrop, insideOnly: false, canDropInside: true);
		AddDropType((IEnumerable<IMediaCueThumbnailVM> c, DragEventArgs d) => c.Select((IMediaCueThumbnailVM m) => m.MediaCue), (IDragDropCollection<IPropCue>? d) => (IDragDropCollection<MediaCue>?)null, CanDropMediaCue, null, OnMediaCueDrop, insideOnly: false, canDropInside: true);
	}

	protected override bool CanSelect(IPropCue item, MouseButtonEventArgs? e)
	{
		return KeyboardHelper.IsModifierPressed((ModifierKeys)2);
	}

	private void OnFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		DropFilesCommand?.Invoke(new DropMediaCommandParameters(files.Select((FileInfo f) => f.FullName), null, dropIndex, GetTarget(dropInside, dropIndex)?.DataContext as IPropCue, dropInside));
	}

	private void OnMediaCueDrop(DraggedItems<MediaCue> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		OnMediaCueDrop(items.Items, dropIndex, dropInside);
	}

	private void OnMediaCueDrop(DraggedItems<IMediaCueThumbnailVM> items, int dropIndex, bool dropInside, DragEventArgs e)
	{
		OnMediaCueDrop(items.Items.Select((IMediaCueThumbnailVM i) => i.MediaCue), dropIndex, dropInside);
	}

	private void OnMediaCueDrop(IEnumerable<MediaCue>? cues, int dropIndex, bool dropInside)
	{
		DropMediaCueCommand?.Invoke(new DropMediaCommandParameters(null, cues, dropIndex, GetTarget(dropInside, dropIndex)?.DataContext as IPropCue, dropInside));
	}

	private FrameworkElement? GetTarget(bool dropInside, int dropIndex)
	{
		FrameworkElement result = null;
		if (dropInside)
		{
			IPropCue item = base.ItemsSource.OfType<IPropCue>().ElementAtOrDefault(dropIndex);
			result = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
		}
		return result;
	}

	private bool CanDropFile(FileInfo[] files, DragEventArgs e)
	{
		return files.All((FileInfo f) => f.FullName.IsVisualMediaFile());
	}

	private bool CanDropMediaCue(DraggedItems<IMediaCueThumbnailVM> items, DragEventArgs e)
	{
		return CanDropMediaCue(items.Items.Select((IMediaCueThumbnailVM m) => m.MediaCue));
	}

	private bool CanDropMediaCue(DraggedItems<MediaCue> items, DragEventArgs e)
	{
		return CanDropMediaCue(items.Items);
	}

	private bool CanDropMediaCue(IEnumerable<MediaCue> cues)
	{
		return cues.All((MediaCue c) => c.MediaAction != null && c.MediaAction.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video));
	}
}
