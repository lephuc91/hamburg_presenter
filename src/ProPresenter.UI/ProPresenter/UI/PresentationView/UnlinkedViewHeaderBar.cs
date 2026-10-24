using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.Library.Cue;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.UI.PresentationView;

public partial class UnlinkedViewHeaderBar : UserControl, IComponentConnector
{
	private readonly DropTarget _dropTarget;

	public static readonly DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(ProPresenterCue), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkNewPresentationCommandProperty = DependencyProperty.Register("LinkNewPresentationCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkImportCommandProperty = DependencyProperty.Register("LinkImportCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkDocumentCommandProperty = DependencyProperty.Register("LinkDocumentCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkMediaCommandProperty = DependencyProperty.Register("LinkMediaCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkDropFilesCommandProperty = DependencyProperty.Register("LinkDropFilesCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkSongSelectItemCommandProperty = DependencyProperty.Register("LinkSongSelectItemCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty LinkMultiTracksItemCommandProperty = DependencyProperty.Register("LinkMultiTracksItemCommand", typeof(ICommand<LinkCommandParameters>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty OpenAttachmentsCommandProperty = DependencyProperty.Register("OpenAttachmentsCommand", typeof(ICommand<ProPresenterCue>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty OpenSearchCommandProperty = DependencyProperty.Register("OpenSearchCommand", typeof(ICommand<ProPresenterCue>), typeof(UnlinkedViewHeaderBar));

	public static readonly DependencyProperty ItemActivatedCommandProperty = DependencyProperty.Register("ItemActivatedCommand", typeof(ICommand<ProPresenterCue>), typeof(UnlinkedViewHeaderBar));

	public ProPresenterCue? Cue
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(CueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CueProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkNewPresentationCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkNewPresentationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkNewPresentationCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkImportCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkImportCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkImportCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkDocumentCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkDocumentCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkDocumentCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkMediaCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkMediaCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkMediaCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkDropFilesCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkDropFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkDropFilesCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkSongSelectItemCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkSongSelectItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkSongSelectItemCommandProperty, (object)value);
		}
	}

	public ICommand<LinkCommandParameters>? LinkMultiTracksItemCommand
	{
		get
		{
			return (ICommand<LinkCommandParameters>)((DependencyObject)this).GetValue(LinkMultiTracksItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LinkMultiTracksItemCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue?>? OpenAttachmentsCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(OpenAttachmentsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenAttachmentsCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue?>? OpenSearchCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(OpenSearchCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OpenSearchCommandProperty, (object)value);
		}
	}

	public ICommand<ProPresenterCue?>? ItemActivatedCommand
	{
		get
		{
			return (ICommand<ProPresenterCue>)((DependencyObject)this).GetValue(ItemActivatedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemActivatedCommandProperty, (object)value);
		}
	}

	public UnlinkedViewHeaderBar()
	{
		InitializeComponent();
		_dropTarget = new DropTarget((DependencyObject)(object)this);
		DropAction<DraggedItems<IProPresenterCueVM>> dropAction = _dropTarget.AddDropType<DraggedItems<IProPresenterCueVM>>();
		dropAction.SetOnDataEnteredAction(OnCuesEntered);
		dropAction.SetOnDataDroppedAction(OnCuesDropped);
		dropAction.SetOnDataLeftAction(OnCuesLeft);
		dropAction.SetIsValidDataPredicate(AreCuesValid);
		DropAction<DraggedItems<MediaCue>> dropAction2 = _dropTarget.AddDropType<DraggedItems<MediaCue>>();
		dropAction2.SetOnDataEnteredAction(delegate
		{
			OnMediaEntered();
		});
		dropAction2.SetOnDataDroppedAction(delegate(DraggedItems<MediaCue> draggedItems, DragEventArgs dragEventArgs)
		{
			OnMediaDropped(draggedItems.Items, dragEventArgs);
		});
		dropAction2.SetOnDataLeftAction(delegate
		{
			OnMediaLeft();
		});
		dropAction2.SetIsValidDataPredicate((DraggedItems<MediaCue> draggedItems, DragEventArgs dragEventArgs) => AreMediaValid(draggedItems.Items, dragEventArgs));
		DropAction<DraggedItems<IMediaCueThumbnailVM>> dropAction3 = _dropTarget.AddDropType<DraggedItems<IMediaCueThumbnailVM>>();
		dropAction3.SetOnDataEnteredAction(delegate
		{
			OnMediaEntered();
		});
		dropAction3.SetOnDataDroppedAction(delegate(DraggedItems<IMediaCueThumbnailVM> draggedItems, DragEventArgs dragEventArgs)
		{
			OnMediaDropped(draggedItems.Items.Select((IMediaCueThumbnailVM i) => i.MediaCue), dragEventArgs);
		});
		dropAction3.SetOnDataLeftAction(delegate
		{
			OnMediaLeft();
		});
		dropAction3.SetIsValidDataPredicate((DraggedItems<IMediaCueThumbnailVM> draggedItems, DragEventArgs dragEventArgs) => AreMediaValid(draggedItems.Items.Select((IMediaCueThumbnailVM i) => i.MediaCue), dragEventArgs));
		DropAction<FileInfo[]> dropAction4 = _dropTarget.AddFileDrop();
		dropAction4.SetOnDataEnteredAction(OnFilesEntered);
		dropAction4.SetOnDataDroppedAction(OnFilesDropped);
		dropAction4.SetOnDataLeftAction(OnFilesLeft);
		dropAction4.SetIsValidDataPredicate(AreFilesValid);
		DropAction<IRemoteFile> dropAction5 = _dropTarget.AddDropType<IRemoteFile>();
		dropAction5.SetOnDataEnteredAction(OnRemoteFileEntered);
		dropAction5.SetOnDataDroppedAction(OnRemoteFileDropped);
		dropAction5.SetOnDataLeftAction(OnRemoteFileLeft);
		dropAction5.SetIsValidDataPredicate(IsRemoteFileValid);
		DropAction<DraggedItems<ISongSelectSearchResult>> dropAction6 = _dropTarget.AddDropType<DraggedItems<ISongSelectSearchResult>>();
		dropAction6.SetOnDataEnteredAction(OnSongSelectItemEntered);
		dropAction6.SetOnDataDroppedAction(OnSongSelectItemDropped);
		dropAction6.SetOnDataLeftAction(OnSongSelectItemLeft);
		dropAction6.SetIsValidDataPredicate(AreSongSelectItemValid);
		DropAction<DraggedItems<IMultiTracksSearchResult>> dropAction7 = _dropTarget.AddDropType<DraggedItems<IMultiTracksSearchResult>>();
		dropAction7.SetOnDataEnteredAction(OnMultiTracksItemEntered);
		dropAction7.SetOnDataDroppedAction(OnMultiTracksItemDropped);
		dropAction7.SetOnDataLeftAction(OnMultiTracksItemLeft);
		dropAction7.SetIsValidDataPredicate(AreMultiTracksItemValid);
		base.AllowDrop = true;
	}

	private void OnCuesEntered(DraggedItems<IProPresenterCueVM> draggedItems, DragEventArgs e)
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnCuesLeft(DraggedItems<IProPresenterCueVM> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnCuesDropped(DraggedItems<IProPresenterCueVM> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		LinkDocumentCue((DocumentCue)draggedItems.Items.First(IsCueValid).Cue);
	}

	private bool AreCuesValid(DraggedItems<IProPresenterCueVM> draggedItems, DragEventArgs e)
	{
		return draggedItems?.Items?.Any(IsCueValid) == true;
	}

	private bool IsCueValid(IProPresenterCueVM i)
	{
		return i.Cue is DocumentCue;
	}

	private void OnMediaEntered()
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnMediaLeft()
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnMediaDropped(IEnumerable<MediaCue> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		LinkMedia(draggedItems.First((MediaCue m) => m.MediaAction != null && m.MediaAction.LiveVideo == null).MediaAction?.Media.Clone());
	}

	private bool AreMediaValid(IEnumerable<MediaCue> draggedItems, DragEventArgs e)
	{
		return draggedItems.All((MediaCue m) => m.MediaAction?.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video, MediaType.Audio) ?? false);
	}

	private void OnFilesEntered(FileInfo[] files, DragEventArgs e)
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnFilesLeft(FileInfo[] files, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnFilesDropped(FileInfo[] files, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (Cue != null)
		{
			LinkDropFilesCommand?.Invoke(new LinkCommandParameters(Cue, files));
		}
	}

	private bool AreFilesValid(FileInfo[] files, DragEventArgs e)
	{
		return files.All((FileInfo f) => f.FullName.IsMediaFile() || f.FullName.IsProPresentationFile() || f.FullName.IsProBundleFile() || f.FullName.IsPowerPointFile());
	}

	private void OnRemoteFileEntered(IRemoteFile file, DragEventArgs e)
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnRemoteFileLeft(IRemoteFile file, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnRemoteFileDropped(IRemoteFile file, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (Cue != null)
		{
			LinkDropFilesCommand?.Invoke(new LinkCommandParameters(Cue, file));
		}
	}

	private bool IsRemoteFileValid(IRemoteFile file, DragEventArgs e)
	{
		if (!file.Filename.IsMediaFile() && !file.Filename.IsProPresentationFile())
		{
			return file.Filename.IsProBundleFile();
		}
		return true;
	}

	private void OnSongSelectItemEntered(DraggedItems<ISongSelectSearchResult> draggedItems, DragEventArgs e)
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnSongSelectItemLeft(DraggedItems<ISongSelectSearchResult> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnSongSelectItemDropped(DraggedItems<ISongSelectSearchResult> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (Cue != null)
		{
			LinkSongSelectItemCommand?.Invoke(new LinkCommandParameters(Cue, draggedItems.Items.First()));
		}
	}

	private bool AreSongSelectItemValid(DraggedItems<ISongSelectSearchResult> draggedItems, DragEventArgs e)
	{
		return true;
	}

	private void OnMultiTracksItemEntered(DraggedItems<IMultiTracksSearchResult> draggedItems, DragEventArgs e)
	{
		this.ShowDropIndicator(AdornerPosition.Inside);
	}

	private void OnMultiTracksItemLeft(DraggedItems<IMultiTracksSearchResult> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
	}

	private void OnMultiTracksItemDropped(DraggedItems<IMultiTracksSearchResult> draggedItems, DragEventArgs e)
	{
		((DependencyObject)(object)this).ResetDropIndicator();
		if (Cue != null)
		{
			LinkMultiTracksItemCommand?.Invoke(new LinkCommandParameters(Cue, draggedItems.Items.First()));
		}
	}

	private bool AreMultiTracksItemValid(DraggedItems<IMultiTracksSearchResult> draggedItems, DragEventArgs e)
	{
		return true;
	}

	private void LinkMedia(MediaBase? media)
	{
		LinkMediaCommand?.Invoke(new LinkCommandParameters(Cue, media));
	}

	private void LinkDocumentCue(DocumentCue documentCue)
	{
		LinkDocumentCommand?.Invoke(new LinkCommandParameters(Cue, documentCue.DocumentAction.Presentation));
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		ItemActivatedCommand?.Invoke<ProPresenterCue>(Cue);
	}

	private void LinkNewPresentationClick(object? sender, RoutedEventArgs e)
	{
		LinkNewPresentationCommand?.Invoke(new LinkCommandParameters(Cue));
		PresentationCreateEvent.Publish(PresentationCreateSource.UnlinkedHeader);
	}

	private void LinkImportClick(object? sender, RoutedEventArgs e)
	{
		LinkImportCommand?.Invoke(new LinkCommandParameters(Cue));
	}

	private void OpenAttachmentsClick(object? sender, RoutedEventArgs e)
	{
		OpenAttachmentsCommand?.Invoke<ProPresenterCue>(Cue);
	}

	private void OpenSearchClick(object? sender, RoutedEventArgs e)
	{
		ICommand<ProPresenterCue?>? openSearchCommand = OpenSearchCommand;
		if (openSearchCommand != null && openSearchCommand.Invoke<ProPresenterCue>(Cue))
		{
			QuickSearchShownEvent.Publish(QuickSearchShownSource.UnlinkedHeader);
		}
	}
}
