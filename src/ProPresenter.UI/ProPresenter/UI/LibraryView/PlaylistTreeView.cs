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
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Playlist;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.LibraryView;

public class PlaylistTreeView : PlaylistTreeViewBase<ProPresenterCue, LibraryPlaylistCollection>
{
	public static readonly DependencyProperty DropPlaylistItemFilesCommandProperty = DependencyProperty.Register("DropPlaylistItemFilesCommand", typeof(ICommand<DropFilesCommandParameters>), typeof(PlaylistTreeView));

	public static readonly DependencyProperty DropPlaylistFilesCommandProperty = DependencyProperty.Register("DropPlaylistFilesCommand", typeof(ICommand<DropFilesCommandParameters>), typeof(PlaylistTreeView));

	public static readonly DependencyProperty DropProContentAssetCommandProperty = DependencyProperty.Register("DropProContentAssetCommand", typeof(ICommand<ProContentDropParameter<GeneralPlaylist>>), typeof(PlaylistTreeView));

	private Playlist<ProPresenterCue>? TargetPlaylist => base.TargetItem?.DataContext as Playlist<ProPresenterCue>;

	public ICommand<DropFilesCommandParameters>? DropPlaylistItemFilesCommand
	{
		get
		{
			return (ICommand<DropFilesCommandParameters>)((DependencyObject)this).GetValue(DropPlaylistItemFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropPlaylistItemFilesCommandProperty, (object)value);
		}
	}

	public ICommand<DropFilesCommandParameters>? DropPlaylistFilesCommand
	{
		get
		{
			return (ICommand<DropFilesCommandParameters>)((DependencyObject)this).GetValue(DropPlaylistFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropPlaylistFilesCommandProperty, (object)value);
		}
	}

	public ICommand<ProContentDropParameter<GeneralPlaylist?>>? DropProContentAssetCommand
	{
		get
		{
			return (ICommand<ProContentDropParameter<GeneralPlaylist>>)((DependencyObject)this).GetValue(DropProContentAssetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropProContentAssetCommandProperty, (object)value);
		}
	}

	public PlaylistTreeView()
	{
		AddDropType((IEnumerable<ProPresenterCue> i) => i.CloneItems(), (IDragDropTreeCollection<IPlaylist<ProPresenterCue>>? p) => p as Playlist<ProPresenterCue>, (IEnumerable<ProPresenterCue> c, DragEventArgs e) => IsDropValid(e) && c.All((ProPresenterCue i) => i.Type != CueType.PCO), (IDragDropCollection<ProPresenterCue>? s) => !(s is ILibrary), (DraggedItems<ProPresenterCue> i, DragEventArgs e) => true);
		AddDropType(delegate(IEnumerable<IProPresenterCueVM> i)
		{
			List<ProPresenterCue> list = new List<ProPresenterCue>();
			list.AddRange(i.Select((IProPresenterCueVM c) => c.Cue).CloneItems());
			return new global::_003C_003Ez__ReadOnlyList<ProPresenterCue>(list);
		}, (IDragDropTreeCollection<IPlaylist<ProPresenterCue>>? p) => p as Playlist<ProPresenterCue>, (IEnumerable<IProPresenterCueVM> c, DragEventArgs e) => IsDropValid(e) && c.All((IProPresenterCueVM i) => i.Type != CueType.PCO), (IDragDropCollection<IProPresenterCueVM>? s) => false, (DraggedItems<IProPresenterCueVM> i, DragEventArgs e) => true);
		AddDropType((IEnumerable<MediaCue> i) => i.CloneItems(), (IDragDropTreeCollection<IPlaylist<ProPresenterCue>>? p) => p as Playlist<ProPresenterCue>, (IEnumerable<MediaCue> c, DragEventArgs e) => IsDropValid(e), (IDragDropCollection<MediaCue>? s) => false);
		AddDropType((IEnumerable<IMediaCueThumbnailVM> i) => i.Select((IMediaCueThumbnailVM v) => v.MediaCue).CloneItems(), (IDragDropTreeCollection<IPlaylist<ProPresenterCue>>? p) => p as Playlist<ProPresenterCue>, (IEnumerable<IMediaCueThumbnailVM> c, DragEventArgs e) => IsDropValid(e), (IDragDropCollection<IMediaCueThumbnailVM>? s) => false);
		AddFileDrop(OnFileDrop, null, (FileInfo[] i, DragEventArgs e) => IsDropValid(i.Select((FileInfo f) => f.FullName), e));
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()));
		AddRemoteFileDrop(OnRemoteFileDrop, null, (IRemoteFile i, DragEventArgs e) => IsDropValid(new global::_003C_003Ez__ReadOnlySingleElementList<string>(i.Filename), e));
		AddDropType(OnDropAsset, null, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => IsDropValid(e));
	}

	private void OnDropAsset(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		IProContentAssetVM droppedItem = items.Items.FirstOrDefault();
		if (droppedItem != null)
		{
			((DispatcherObject)this).Dispatcher.InvokeAsync<bool?>((Func<bool?>)(() => DropProContentAssetCommand?.Invoke<ProContentDropParameter<GeneralPlaylist>>(new ProContentDropParameter<GeneralPlaylist>(droppedItem, base.TargetItem?.DataContext as GeneralPlaylist))));
		}
	}

	protected override bool CanSelectOnDragOver(IPlaylist<ProPresenterCue> targetItemData)
	{
		if (!(targetItemData is GeneralPlaylist))
		{
			return targetItemData is PCOPlaylist;
		}
		return true;
	}

	private bool IsDropValid(DragEventArgs e)
	{
		return e.FindHitElement<TreeViewItem>(this) != null;
	}

	private bool IsDropValid(IEnumerable<string> filenames, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (!filenames.All(IsSupportedPlaylistFile))
		{
			if (IsDropValid(e))
			{
				return filenames.All((string f) => f.IsImageFile() || f.IsVideoFile() || f.IsAudioFile() || f.IsProDocumentFile() || f.IsDocumentBundleFile() || f.IsPowerPointFile());
			}
			return false;
		}
		return true;
	}

	private void OnFileDrop(FileInfo[] files, DragEventArgs e)
	{
		OnDrop(files.Select((FileInfo f) => f.FullName), (int dropIndex, IPlaylist<ProPresenterCue> targetPlaylist) => new DropFilesCommandParameters(files.Select((FileInfo f) => f.FullName), dropIndex, targetPlaylist));
	}

	private void OnRemoteFileDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		OnDrop(new string[1] { remoteFile.Filename }, (int dropIndex, IPlaylist<ProPresenterCue> targetPlaylist) => new DropFilesCommandParameters(remoteFile, dropIndex, targetPlaylist));
	}

	private void OnDrop(IEnumerable<string> filenames, Func<int, IPlaylist<ProPresenterCue>, DropFilesCommandParameters> paramsProvider)
	{
		if (filenames.All(IsSupportedPlaylistFile) && base.TargetItem?.DataContext is IPlaylist<ProPresenterCue> arg)
		{
			DropPlaylistFilesCommand?.Invoke(paramsProvider(base.DropIndex, arg));
		}
		else if (TargetPlaylist != null)
		{
			DropPlaylistItemFilesCommand?.Invoke(paramsProvider(TargetPlaylist.Count, TargetPlaylist));
		}
	}

	protected override bool FileDropOnlyInside(IEnumerable<string> filenames)
	{
		return !filenames.All(IsSupportedPlaylistFile);
	}

	private static bool IsSupportedPlaylistFile(string filename)
	{
		if (!filename.IsProPlaylistFile() && !filename.IsPro6PlaylistFile())
		{
			return filename.IsPro6PlaylistBundleFile();
		}
		return true;
	}
}
