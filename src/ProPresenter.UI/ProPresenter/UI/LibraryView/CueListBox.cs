using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Cues.PCO;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.Library;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.LibraryView;

public class CueListBox : DragDropListBox<IProPresenterCueVM>
{
	private int _dropIndex;

	private readonly IProPresenterCueVMFactory _cueVMFactory;

	public static readonly DependencyProperty DropFilesCommandProperty = DependencyProperty.Register("DropFilesCommand", typeof(ICommand<DropFilesCommandParameters>), typeof(CueListBox));

	public static readonly DependencyProperty DragDropCollectionProperty = DependencyProperty.Register("DragDropCollection", typeof(IDragDropCollection<IProPresenterCueVM>), typeof(CueListBox));

	public static readonly DependencyProperty DropProContentAssetCommandProperty = DependencyProperty.Register("DropProContentAssetCommand", typeof(ICommand<ProContentDropParameter<GeneralPlaylist>>), typeof(CueListBox));

	protected override IDragDropCollection<IProPresenterCueVM>? SourceCollection => DragDropCollection;

	public IDragDropCollection<IProPresenterCueVM>? DragDropCollection
	{
		get
		{
			return (IDragDropCollection<IProPresenterCueVM>)((DependencyObject)this).GetValue(DragDropCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DragDropCollectionProperty, (object)value);
		}
	}

	public ICommand<DropFilesCommandParameters>? DropFilesCommand
	{
		get
		{
			return (ICommand<DropFilesCommandParameters>)((DependencyObject)this).GetValue(DropFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropFilesCommandProperty, (object)value);
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

	public CueListBox()
	{
		_cueVMFactory = UIServiceProvider.GetService<IProPresenterCueVMFactory>();
		AddDropType((IEnumerable<IProPresenterCueVM> i) => i.Select((IProPresenterCueVM c) => c.Cue).CloneItems().Select(_cueVMFactory.Create), CanDropProPresenterCue, (IDragDropCollection<IProPresenterCueVM>? s) => false, (DraggedItems<IProPresenterCueVM> _, DragEventArgs _) => true);
		AddDropType((IEnumerable<ProPresenterCue> i) => i.CloneItems().Select(_cueVMFactory.Create), CanDropProPresenterCue, (IDragDropCollection<ProPresenterCue>? s) => !(s is ILibrary), (DraggedItems<ProPresenterCue> _, DragEventArgs _) => true);
		AddDropType(ConvertMediaCues, (IEnumerable<MediaCue> i, DragEventArgs e) => CanDrop(), (IDragDropCollection<MediaCue>? s) => false);
		AddDropType(ConvertMediaCues, (IEnumerable<IMediaCueThumbnailVM> i, DragEventArgs e) => CanDrop(), (IDragDropCollection<IMediaCueThumbnailVM>? s) => false);
		AddFileDrop(OnFileDrop, OnFileDrag, IsFileValid);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()), canDropInside: true);
		AddRemoteFileDrop(OnRemoteFileDrop, OnRemoteFileDrag, IsRemoteFileValid);
		AddCustomDrop(DropAsset, DragAsset, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => CanDrop());
	}

	private void DropAsset(DraggedItems<IProContentAssetVM> items)
	{
		IProContentAssetVM item = items.Items.FirstOrDefault();
		if (item != null)
		{
			((DispatcherObject)this).Dispatcher.InvokeAsync<bool?>((Func<bool?>)(() => DropProContentAssetCommand?.Invoke<ProContentDropParameter<GeneralPlaylist>>(new ProContentDropParameter<GeneralPlaylist>(item, DragDropCollection as GeneralPlaylist, _dropIndex))));
		}
	}

	private void DragAsset(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		_dropIndex = FindDropIndex(e);
		UpdateDropIndex(e);
	}

	private bool CanDrop()
	{
		if (base.DataContext is ILibraryVM libraryVM)
		{
			return libraryVM.ActiveLibrary == null;
		}
		return false;
	}

	private bool CanDropProPresenterCue(IEnumerable<IProPresenterCueVM> cues, DragEventArgs e)
	{
		return CanDropProPresenterCue(cues.Select((IProPresenterCueVM c) => c.Cue), e);
	}

	private bool CanDropProPresenterCue(IEnumerable<ProPresenterCue> cues, DragEventArgs e)
	{
		if (!CanDrop())
		{
			return false;
		}
		if (base.DataContext is ILibraryVM { ActivePlaylist: PCOPlaylist activePlaylist })
		{
			int num = FindDropIndex(e);
			foreach (PCOCueBase item in cues.OfType<PCOCueBase>())
			{
				ProPresenterCue previous = activePlaylist.GetPrevious(item, (ProPresenterCue p) => p.Type == CueType.PCO);
				ProPresenterCue next = activePlaylist.GetNext(item, (ProPresenterCue p) => p.Type == CueType.PCO);
				if (previous != null && num <= activePlaylist.IndexOf(previous))
				{
					return false;
				}
				if (next != null && num > activePlaylist.IndexOf(next))
				{
					return false;
				}
			}
		}
		return true;
	}

	private IEnumerable<IProPresenterCueVM> ConvertMediaCues(IEnumerable<IMediaCueThumbnailVM> cues)
	{
		return ConvertMediaCues(cues.Select((IMediaCueThumbnailVM i) => i.MediaCue));
	}

	private IEnumerable<IProPresenterCueVM> ConvertMediaCues(IEnumerable<MediaCue> i)
	{
		IEnumerable<MediaCue> source = i.CloneItems();
		source.ForEach(delegate(MediaCue c)
		{
			c.MediaAction?.ToForeground();
		});
		List<IProPresenterCueVM> list = new List<IProPresenterCueVM>();
		list.AddRange(source.Select(_cueVMFactory.Create));
		return new global::_003C_003Ez__ReadOnlyList<IProPresenterCueVM>(list);
	}

	private bool IsValid(IEnumerable<string> filenames)
	{
		if (CanDrag())
		{
			return filenames.All((string f) => f.IsMediaFile() || f.IsProDocumentFile() || f.IsPro6DocumentFile() || f.IsDocumentBundleFile() || f.IsPowerPointFile());
		}
		return false;
	}

	private bool IsFileValid(FileInfo[] files, DragEventArgs e)
	{
		return IsValid(files.Select((FileInfo f) => f.FullName));
	}

	private bool IsRemoteFileValid(IRemoteFile remoteFile, DragEventArgs e)
	{
		return IsValid(new global::_003C_003Ez__ReadOnlySingleElementList<string>(remoteFile.Filename));
	}

	private void OnFileDrag(FileInfo[] files, DragEventArgs e)
	{
		OnDrag(e);
	}

	private void OnRemoteFileDrag(IRemoteFile remoteFile, DragEventArgs e)
	{
		OnDrag(e);
	}

	private void OnDrag(DragEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		((DependencyObject)(object)this).ResetDropIndicator();
		if (!(VisualTreeHelper.HitTest(this, e.GetPosition(this))?.VisualHit is DropIndicator))
		{
			_dropIndex = FindDropIndex(e);
			(base.ItemContainerGenerator.ContainerFromIndex(_dropIndex.Clamp(0, base.Items.Count - 1)) as ListBoxItem)?.ShowDropIndicator((_dropIndex < base.Items.Count) ? AdornerPosition.Top : AdornerPosition.Bottom);
		}
	}

	private void OnFileDrop(FileInfo[] files, int dropIndex, bool dropInside)
	{
		DropFilesCommand?.Invoke(new DropFilesCommandParameters(files.Select((FileInfo f) => f.FullName), _dropIndex));
	}

	private void OnRemoteFileDrop(IRemoteFile remoteFile, int dropIndex, bool dropInside)
	{
		DropFilesCommand?.Invoke(new DropFilesCommandParameters(remoteFile, _dropIndex));
	}

	protected override void OnActiveItemChanged(IProPresenterCueVM? activeItem)
	{
		base.OnActiveItemChanged(activeItem);
		(base.ItemContainerGenerator.ContainerFromItem(activeItem)?.FindVisualChild<EditableTextBlock>())?.SelectAll();
	}

	protected override bool CanDrag()
	{
		if (base.SelectedItem is IPcoCueVM)
		{
			return false;
		}
		return !(base.SelectedItems?.AnyOf<IPcoCueVM>() ?? false);
	}
}
