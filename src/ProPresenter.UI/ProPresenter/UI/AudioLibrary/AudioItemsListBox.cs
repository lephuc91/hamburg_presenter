using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
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

namespace ProPresenter.UI.AudioLibrary;

public class AudioItemsListBox : DragDropListBox<MediaCue>
{
	private int _dropIndex;

	public static readonly DependencyProperty SortProperty = DependencyProperty.Register("Sort", typeof(AudioSortType), typeof(AudioItemsListBox));

	public static readonly DependencyProperty DragDropSourceProperty = DependencyProperty.Register("DragDropSource", typeof(IDragDropCollection<MediaCue>), typeof(AudioItemsListBox));

	public static readonly DependencyProperty DropAudioFilesCommandProperty = DependencyProperty.Register("DropAudioFilesCommand", typeof(ICommand<DropAudioFilesCommandParameter>), typeof(AudioItemsListBox));

	public AudioSortType Sort
	{
		get
		{
			return (AudioSortType)((DependencyObject)this).GetValue(SortProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SortProperty, (object)value);
		}
	}

	public IDragDropCollection<MediaCue> DragDropSource
	{
		get
		{
			return (IDragDropCollection<MediaCue>)((DependencyObject)this).GetValue(DragDropSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropSourceProperty, (object)value);
		}
	}

	protected override IDragDropCollection<MediaCue> SourceCollection => DragDropSource;

	public ICommand<DropAudioFilesCommandParameter> DropAudioFilesCommand
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

	public AudioItemsListBox()
	{
		AddDropType((IEnumerable<MediaCue> i) => i.Collect((MediaCue a) => (MediaCue)a.Clone()), IsDropValid, null, (DraggedItems<MediaCue> _, DragEventArgs _) => true);
		AddFileDrop(OnAudioFileDrop, delegate(FileInfo[] s, DragEventArgs e)
		{
			OnFileDrag(e);
		}, (FileInfo[] i, DragEventArgs e) => IsValidFilesDrop(i.Select((FileInfo f) => f.FullName)));
		AddRemoteFileDrop(OnRemoteFileDrop, delegate(IRemoteFile s, DragEventArgs e)
		{
			OnFileDrag(e);
		}, (IRemoteFile i, DragEventArgs e) => IsValidFilesDrop(new string[1] { i.Filename }));
	}

	private bool IsDropValid(IEnumerable<MediaCue> cues, DragEventArgs e)
	{
		return cues.All(delegate(MediaCue c)
		{
			MediaAction? mediaAction = c.MediaAction;
			return mediaAction != null && mediaAction.Media.MediaType == MediaType.Audio;
		});
	}

	private bool IsValidFilesDrop(IEnumerable<string> filenames)
	{
		return filenames.All((string f) => f.IsAudioFile());
	}

	private void OnFileDrag(DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (e.FindHitElement<DropIndicator>(this) == null)
		{
			_dropIndex = FindDropIndex(e);
			int num = (base.ItemsSource as IEnumerable<MediaCue>)?.Count() ?? 0;
			FrameworkElement frameworkElement = base.ItemContainerGenerator.ContainerFromIndex(_dropIndex) as FrameworkElement;
			if (_dropIndex >= num)
			{
				frameworkElement = base.ItemContainerGenerator.ContainerFromIndex(Math.Max(num - 1, 0)) as FrameworkElement;
			}
			frameworkElement?.ShowDropIndicator((_dropIndex < num) ? AdornerPosition.Top : AdornerPosition.Bottom);
		}
	}

	private void OnAudioFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		DropAudioFilesCommand?.Invoke(new DropAudioFilesCommandParameter(files.Select((FileInfo f) => f.FullName), null, _dropIndex));
	}

	private void OnRemoteFileDrop(IRemoteFile remoteFile, int dropIndex, bool dropInside)
	{
		DropAudioFilesCommand?.Invoke(new DropAudioFilesCommandParameter(remoteFile, null, _dropIndex));
	}
}
