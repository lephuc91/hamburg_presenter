using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Playlist;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.MediaLibrary;

public class MediaPlaylistTreeView : PlaylistTreeViewBase<MediaCue, VisualPlaylistCollection>
{
	public static readonly DependencyProperty AddFilesCommandProperty = DependencyProperty.Register("AddFilesCommand", typeof(ICommand<ImportMediaCommandParameters>), typeof(MediaPlaylistTreeView));

	public static readonly DependencyProperty DropProContentAssetCommandProperty = DependencyProperty.Register("DropProContentAssetCommand", typeof(ICommand<ProContentDropParameter<VisualPlaylist>>), typeof(MediaPlaylistTreeView));

	public static readonly DependencyProperty ShouldSetNewPlaylistActiveProperty = DependencyProperty.Register("ShouldSetNewPlaylistActive", typeof(bool), typeof(MediaPlaylistTreeView), new PropertyMetadata((object)false));

	public ICommand<ImportMediaCommandParameters>? AddFilesCommand
	{
		get
		{
			return (ICommand<ImportMediaCommandParameters>)((DependencyObject)this).GetValue(AddFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddFilesCommandProperty, (object)value);
		}
	}

	public ICommand<ProContentDropParameter<VisualPlaylist?>>? DropProContentAssetCommand
	{
		get
		{
			return (ICommand<ProContentDropParameter<VisualPlaylist>>)((DependencyObject)this).GetValue(DropProContentAssetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropProContentAssetCommandProperty, (object)value);
		}
	}

	public bool ShouldSetNewPlaylistActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShouldSetNewPlaylistActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShouldSetNewPlaylistActiveProperty, (object)value);
		}
	}

	public MediaPlaylistTreeView()
	{
		AddDropType((IEnumerable<IMediaCueThumbnailVM> i) => i.Select((IMediaCueThumbnailVM vm) => vm.MediaCue).CloneItems(), (IDragDropTreeCollection<IPlaylist<MediaCue>>? p) => p as VisualPlaylist, IsDropValid, null, (DraggedItems<IMediaCueThumbnailVM> i, DragEventArgs e) => true, (DraggedItems<IMediaCueThumbnailVM> i, DragEventArgs e) => !(i.SourceCollection is SmartPlaylist));
		AddFileDrop(FileDropAction, null, IsDropValid);
		AddRemoteFileDrop(RemoteFileDropAction, null, IsDropValid);
		AddDropType(OnDropProContentAsset, null, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => IsDropValid(e));
		AddWebDropType(FileDropAction, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()));
	}

	private void OnDropProContentAsset(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		IProContentAssetVM droppedItem = items.Items.FirstOrDefault();
		if (droppedItem != null)
		{
			((DispatcherObject)this).Dispatcher.InvokeAsync<bool?>((Func<bool?>)(() => DropProContentAssetCommand?.Invoke<ProContentDropParameter<VisualPlaylist>>(new ProContentDropParameter<VisualPlaylist>(droppedItem, base.TargetItem?.DataContext as VisualPlaylist))));
		}
	}

	protected override bool IsDraggableItem(IPlaylist<MediaCue>? item)
	{
		if (item != null)
		{
			return !(item is LiveVideoPlaylist);
		}
		return false;
	}

	protected override bool CanSelectOnDragOver(IPlaylist<MediaCue> targetItemData)
	{
		if (targetItemData is VisualPlaylist visualPlaylist)
		{
			return !visualPlaylist.Type.IsAnyOf(PlaylistType.Smart, PlaylistType.Download, PlaylistType.LiveVideo);
		}
		return false;
	}

	protected override bool CanInsertPlaylist(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, DragEventArgs e)
	{
		TreeViewItem treeViewItem = e.FindHitElement<TreeViewItem>(this);
		if (treeViewItem != null && !(treeViewItem.DataContext is LiveVideoPlaylist))
		{
			return items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> t) => t.Items).All((IPlaylist<MediaCue> p) => p is VisualPlaylist || p is VisualGroupPlaylist);
		}
		return false;
	}

	private bool IsDropValid(IEnumerable<IMediaCueThumbnailVM> cues, DragEventArgs e)
	{
		if (IsDropValid(e))
		{
			return cues.None(delegate(IMediaCueThumbnailVM c)
			{
				MediaAction? mediaAction = c.MediaCue.MediaAction;
				return mediaAction != null && mediaAction.Media.MediaType == MediaType.Audio;
			});
		}
		return false;
	}

	private bool IsDropValid(FileInfo[] files, DragEventArgs e)
	{
		if (IsDropValid(e))
		{
			return files.All((FileInfo f) => f.FullName.IsVisualMediaFile());
		}
		return false;
	}

	private bool IsDropValid(IRemoteFile remoteFile, DragEventArgs e)
	{
		if (IsDropValid(e))
		{
			return remoteFile.Filename.IsVisualMediaFile();
		}
		return false;
	}

	private bool IsDropValid(DragEventArgs e)
	{
		TreeViewItem treeViewItem = e.FindHitElement<TreeViewItem>(this);
		if (treeViewItem != null)
		{
			return CanSelectOnDragOver((IPlaylist<MediaCue>)treeViewItem.DataContext);
		}
		return false;
	}

	private void FileDropAction(FileInfo[] files, DragEventArgs e)
	{
		if (base.TargetItem?.DataContext is IPlaylist<MediaCue> targetPlaylist)
		{
			AddFilesCommand?.Invoke(new ImportMediaCommandParameters(targetPlaylist, files, null, droppedBefore: false));
		}
	}

	private void RemoteFileDropAction(IRemoteFile remoteFile, DragEventArgs e)
	{
		if (base.TargetItem?.DataContext is IPlaylist<MediaCue> targetPlaylist)
		{
			AddFilesCommand?.Invoke(new ImportMediaCommandParameters(targetPlaylist, remoteFile, null, droppedBefore: false));
		}
	}

	protected override bool SetNewPlaylistActive()
	{
		return ShouldSetNewPlaylistActive;
	}
}
