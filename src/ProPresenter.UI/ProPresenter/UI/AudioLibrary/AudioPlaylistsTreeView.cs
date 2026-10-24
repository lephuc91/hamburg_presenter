using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Playlist;

namespace ProPresenter.UI.AudioLibrary;

public class AudioPlaylistsTreeView : PlaylistTreeViewBase<MediaCue, AudioPlaylistCollection>
{
	public static readonly DependencyProperty DropAudioFilesCommandProperty = DependencyProperty.Register("DropAudioFilesCommand", typeof(ICommand<DropAudioFilesCommandParameter>), typeof(AudioPlaylistsTreeView));

	public ICommand<DropAudioFilesCommandParameter>? DropAudioFilesCommand
	{
		get
		{
			return (ICommand<DropAudioFilesCommandParameter>)((DependencyObject)this).GetValue(DropAudioFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropAudioFilesCommandProperty, (object)value);
		}
	}

	public AudioPlaylistsTreeView()
	{
		AddDropType((IEnumerable<MediaCue> i) => i.CloneItems(), (IDragDropTreeCollection<IPlaylist<MediaCue>>? p) => p as Playlist<MediaCue>, IsDropValid, null, (DraggedItems<MediaCue> i, DragEventArgs e) => true);
		AddFileDrop(OnAudioFilesDrop, null, (FileInfo[] i, DragEventArgs e) => IsDropValid(i.Select((FileInfo f) => f.FullName), e));
		AddRemoteFileDrop(OnRemoteFilesDrop, null, (IRemoteFile i, DragEventArgs e) => IsDropValid(new string[1] { i.Filename }, e));
	}

	protected override bool CanSelectOnDragOver(IPlaylist<MediaCue> targetItemData)
	{
		return targetItemData is AudioPlaylist;
	}

	protected override bool CanInsertPlaylist(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, DragEventArgs e)
	{
		return items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> t) => t.Items).All((IPlaylist<MediaCue> p) => p is AudioPlaylist || p is AudioGroupPlaylist);
	}

	private bool IsDropValid(IEnumerable<MediaCue> cues, DragEventArgs e)
	{
		if (IsDropValid(e))
		{
			return cues.All(delegate(MediaCue c)
			{
				MediaAction? mediaAction = c.MediaAction;
				return mediaAction != null && mediaAction.Media.MediaType == MediaType.Audio;
			});
		}
		return false;
	}

	private bool IsDropValid(IEnumerable<string> filenames, DragEventArgs e)
	{
		if (IsDropValid(e))
		{
			return filenames.All((string f) => f.IsAudioFile());
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

	private void OnAudioFilesDrop(FileInfo[] files, DragEventArgs e)
	{
		if (base.TargetItem?.DataContext is AudioPlaylist audioPlaylist)
		{
			DropAudioFilesCommand?.Invoke(new DropAudioFilesCommandParameter(files.Select((FileInfo f) => f.FullName), audioPlaylist, audioPlaylist.Count));
		}
	}

	private void OnRemoteFilesDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		if (base.TargetItem?.DataContext is AudioPlaylist audioPlaylist)
		{
			DropAudioFilesCommand?.Invoke(new DropAudioFilesCommandParameter(remoteFile, audioPlaylist, audioPlaylist.Count));
		}
	}
}
