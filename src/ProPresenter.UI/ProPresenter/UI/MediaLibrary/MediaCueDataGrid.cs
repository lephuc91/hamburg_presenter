using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.MediaLibrary;

public class MediaCueDataGrid : DragDropDataGrid<IMediaCueThumbnailVM>
{
	private bool _canTrigger;

	public static readonly DependencyProperty SelectedPlaylistProperty;

	public static readonly DependencyProperty AddFilesCommandProperty;

	public static readonly DependencyProperty TriggerThumbnailCommandProperty;

	public static readonly DependencyProperty CopyCommandProperty;

	public static readonly DependencyProperty DeleteItemCommandProperty;

	private static readonly DependencyProperty DragDropSourceProperty;

	public VisualPlaylist? SelectedPlaylist
	{
		get
		{
			return (VisualPlaylist)((DependencyObject)this).GetValue(SelectedPlaylistProperty);
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

	public ICommand<IMediaCueThumbnailVM>? TriggerThumbnailCommand
	{
		get
		{
			return (ICommand<IMediaCueThumbnailVM>)((DependencyObject)this).GetValue(TriggerThumbnailCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerThumbnailCommandProperty, (object)value);
		}
	}

	public ICommand? CopyCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CopyCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CopyCommandProperty, (object)value);
		}
	}

	public ICommand? DeleteItemCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DeleteItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteItemCommandProperty, (object)value);
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

	private bool IsSelecting
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			if (!((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)4))
			{
				return ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
			}
			return true;
		}
	}

	protected override IDragDropCollection<IMediaCueThumbnailVM>? SourceCollection => DragDropSource;

	private static void SelectedPlaylistPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is MediaCueDataGrid mediaCueDataGrid && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is VisualPlaylist playlist)
		{
			((DependencyObject)mediaCueDataGrid).SetCurrentValue(DragDropSourceProperty, (object)new MediaCueDragDropSourceCollection(playlist));
		}
	}

	public MediaCueDataGrid()
	{
		RegisterDropType();
	}

	private void RegisterDropType()
	{
		AddDropType((IEnumerable<IMediaCueThumbnailVM> i) => i, (IEnumerable<IMediaCueThumbnailVM> i, DragEventArgs e) => true, (DraggedItems<IMediaCueThumbnailVM> _, DragEventArgs _) => true);
		AddFileDrop(FileDropAction, IsValidFileDrop);
		AddRemoteFileDrop(RemoteFileDropAction, IsValidRemoteFileDrop);
	}

	private bool IsValidFileDrop(FileInfo[] files, DragEventArgs e)
	{
		return MediaHelper.CanDropFile(files, SelectedPlaylist);
	}

	private void FileDropAction(FileInfo[] files)
	{
		AddFilesCommand?.Invoke(new ImportMediaCommandParameters(SelectedPlaylist, files, base.TargetItem?.MediaCue, base.DroppedBefore));
	}

	private bool IsValidRemoteFileDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		return MediaHelper.CanDropFile(new string[1] { remoteFile.Filename }, SelectedPlaylist);
	}

	private void RemoteFileDropAction(IRemoteFile remoteFile)
	{
		AddFilesCommand?.Invoke(new ImportMediaCommandParameters(SelectedPlaylist, remoteFile, base.TargetItem?.MediaCue, base.DroppedBefore));
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		Pro.UI.Controls.DataGridRow dataGridRow = e.FindHitElement<Pro.UI.Controls.DataGridRow>(this);
		if (e.FindHitElement<BorderlessButton>(this) == null && dataGridRow?.DataContext is IMediaCueThumbnailVM parameter && !IsSelecting && _canTrigger)
		{
			TriggerThumbnailCommand?.Invoke(parameter);
			DeselectAll();
		}
		else
		{
			base.OnPreviewMouseLeftButtonUp(e);
		}
		_canTrigger = false;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		_canTrigger = e.FindHitElement<Pro.UI.Controls.DataGridRow>(this)?.DataContext is IMediaCueThumbnailVM;
		base.OnPreviewMouseLeftButtonDown(e);
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		base.OnContextMenuOpening(e);
		Focus();
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		base.OnMouseUp(e);
		Focus();
	}

	protected override void OnExecutedCopy(ExecutedRoutedEventArgs args)
	{
		CopyCommand?.Invoke();
	}

	protected override void OnCanExecuteCopy(CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = CopyCommand?.CanExecute(null) ?? false;
	}

	protected override void OnExecutedDelete(ExecutedRoutedEventArgs e)
	{
		DeleteItemCommand?.Invoke();
	}

	protected override void OnCanExecuteDelete(CanExecuteRoutedEventArgs e)
	{
		e.CanExecute = DeleteItemCommand?.CanExecute(null) ?? false;
	}

	static MediaCueDataGrid()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Type? typeFromHandle = typeof(VisualPlaylist);
		Type? typeFromHandle2 = typeof(MediaCueDataGrid);
		FrameworkPropertyMetadata frameworkPropertyMetadata = new FrameworkPropertyMetadata();
		((PropertyMetadata)frameworkPropertyMetadata).PropertyChangedCallback = new PropertyChangedCallback(SelectedPlaylistPropertyChanged);
		SelectedPlaylistProperty = DependencyProperty.Register("SelectedPlaylist", typeFromHandle, typeFromHandle2, (PropertyMetadata)(object)frameworkPropertyMetadata);
		AddFilesCommandProperty = DependencyProperty.Register("AddFilesCommand", typeof(ICommand<ImportMediaCommandParameters>), typeof(MediaCueDataGrid));
		TriggerThumbnailCommandProperty = DependencyProperty.Register("TriggerThumbnailCommand", typeof(ICommand<IMediaCueThumbnailVM>), typeof(MediaCueDataGrid));
		CopyCommandProperty = DependencyProperty.Register("CopyCommand", typeof(ICommand), typeof(MediaCueDataGrid));
		DeleteItemCommandProperty = DependencyProperty.Register("DeleteItemCommand", typeof(ICommand), typeof(MediaCueDataGrid));
		DragDropSourceProperty = DependencyProperty.Register("DragDropSource", typeof(IDragDropCollection<IMediaCueThumbnailVM>), typeof(MediaCueDataGrid));
	}
}
