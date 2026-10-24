using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.Thumbnails;

public class MediaThumbnailPanel : DragDropThumbnailPanel<IMediaCueThumbnailVM>
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(MediaThumbnailPanel));

	public static readonly DependencyProperty SelectedPlaylistProperty;

	public static readonly DependencyProperty AddFilesCommandProperty;

	public static readonly DependencyProperty DropProContentAssetCommandProperty;

	private static readonly DependencyProperty DragDropSourceProperty;

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			return (IPlaylist<MediaCue>)((DependencyObject)this).GetValue(SelectedPlaylistProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedPlaylistProperty, (object)value);
		}
	}

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

	private IDragDropCollection<IMediaCueThumbnailVM>? DragDropSource
	{
		get
		{
			return (IDragDropCollection<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(DragDropSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropSourceProperty, (object)value);
		}
	}

	protected override IDragDropCollection<IMediaCueThumbnailVM>? SourceCollection => DragDropSource;

	private static void SelectedPlaylistPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MediaThumbnailPanel mediaThumbnailPanel)
		{
			((DependencyObject)mediaThumbnailPanel).SetCurrentValue(DragDropSourceProperty, (object)new MediaCueDragDropSourceCollection((VisualPlaylist)((DependencyPropertyChangedEventArgs)(ref e)).NewValue));
		}
	}

	public MediaThumbnailPanel()
	{
		AddDropType((IEnumerable<IMediaCueThumbnailVM> i) => i, IsValidDrop, (DraggedItems<IMediaCueThumbnailVM> _, DragEventArgs _) => true);
		AddWebDropType(FileDropAction, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()));
		AddFileDrop(FileDropAction, IsValidFileDrop);
		AddRemoteFileDrop(RemoteFileDropAction, IsValidRemoteFileDrop);
		AddCustomDrop(OnDropProContentAsset, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => true, null, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => false);
	}

	private void OnDropProContentAsset(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		IProContentAssetVM droppedItems = items.Items.FirstOrDefault();
		if (droppedItems != null)
		{
			((DispatcherObject)this).Dispatcher.InvokeAsync<bool?>((Func<bool?>)(() => DropProContentAssetCommand?.Invoke<ProContentDropParameter<VisualPlaylist>>(new ProContentDropParameter<VisualPlaylist>(droppedItems, SelectedPlaylist as VisualPlaylist, base.DropIndex, base.DroppedBefore, base.DroppedOutside))));
		}
	}

	protected override void OnRenderThumbnailPreview(IMediaCueThumbnailVM cue, Vector2<int> size, Action<IMediaCueThumbnailVM, IBitmapHandle> completedCallback)
	{
	}

	protected override void OnRenderBackgroundContent(IMediaCueThumbnailVM cue, Vector2<int> size, Action<IMediaCueThumbnailVM, IBitmapHandle?> completedCallback)
	{
		completedCallback?.Invoke(cue, (cue.MediaCue?.MediaAction?.Media as IDrawMedia)?.Drawing?.PreviewImage?.ToBitmapHandle());
	}

	private bool IsValidDrop(IEnumerable<IMediaCueThumbnailVM> mediaCues)
	{
		return mediaCues.All(delegate(IMediaCueThumbnailVM m)
		{
			MediaAction? mediaAction = m.MediaCue.MediaAction;
			return mediaAction == null || mediaAction.Media.MediaType != MediaType.Audio;
		});
	}

	private bool IsValidFileDrop(FileInfo[] files, DragEventArgs e)
	{
		return MediaHelper.CanDropFile(files, SelectedPlaylist);
	}

	private void FileDropAction(FileInfo[] files, DragEventArgs e)
	{
		FileInfo[] files2 = files.SelectMany((FileInfo x) => x.Attributes.HasFlag(FileAttributes.Directory) ? (from y in Directory.GetFiles(x.FullName, "*.*", SearchOption.AllDirectories)
			select new FileInfo(y)) : new global::_003C_003Ez__ReadOnlySingleElementList<FileInfo>(x)).OrderBy((FileInfo f) => f.Name, new NaturalStringComparer()).ToArray();
		AddFilesCommand?.Invoke(new ImportMediaCommandParameters(SelectedPlaylist, files2, base.TargetItem?.MediaCue, base.DroppedBefore));
	}

	private bool IsValidRemoteFileDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		return MediaHelper.CanDropFile(new string[1] { remoteFile.Filename }, SelectedPlaylist);
	}

	private void RemoteFileDropAction(IRemoteFile remoteFile, DragEventArgs e)
	{
		AddFilesCommand?.Invoke(new ImportMediaCommandParameters(SelectedPlaylist, remoteFile, base.TargetItem?.MediaCue, base.DroppedBefore));
	}

	protected override Color OnGetItemBackgroundColor(IMediaCueThumbnailVM source, Color? settingsColor)
	{
		return Colors.Transparent;
	}

	protected override Color OnGetItemPreviewColor(IMediaCueThumbnailVM source, Color? settingsColor)
	{
		return Colors.Transparent;
	}

	static MediaThumbnailPanel()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		Type? typeFromHandle = typeof(IPlaylist<MediaCue>);
		Type? typeFromHandle2 = typeof(MediaThumbnailPanel);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = new PropertyChangedCallback(SelectedPlaylistPropertyChanged);
		SelectedPlaylistProperty = DependencyProperty.Register("SelectedPlaylist", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		AddFilesCommandProperty = DependencyProperty.Register("AddFilesCommand", typeof(ICommand<ImportMediaCommandParameters>), typeof(MediaThumbnailPanel));
		DropProContentAssetCommandProperty = DependencyProperty.Register("DropProContentAssetCommand", typeof(ICommand<ProContentDropParameter<VisualPlaylist>>), typeof(MediaThumbnailPanel));
		DragDropSourceProperty = DependencyProperty.Register("DragDropSource", typeof(IDragDropCollection<IMediaCueThumbnailVM>), typeof(MediaThumbnailPanel));
	}
}
