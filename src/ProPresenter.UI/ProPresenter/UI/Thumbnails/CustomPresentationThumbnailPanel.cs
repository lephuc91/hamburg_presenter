using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.UI.ActionPalette;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Thumbnails;

public class CustomPresentationThumbnailPanel : PresentationThumbnailPanel
{
	private readonly IEntityFactory _entityFactory;

	public static readonly DependencyProperty DocumentCueProperty = DependencyProperty.Register("DocumentCue", typeof(IDocumentCue), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty AddMediaActionCommandProperty = DependencyProperty.Register("AddMediaActionCommand", typeof(ICommand<(IDocumentCue, AddMediaCueParameters)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty AddMediaPlaylistActionCommandProperty = DependencyProperty.Register("AddMediaPlaylistActionCommand", typeof(ICommand<(IDocumentCue, AddMediaPlaylistParameters)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty AddDroppedActionCommandProperty = DependencyProperty.Register("AddDroppedActionCommand", typeof(ICommand<(IDocumentCue, ActionCommandParameters)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty AddDroppedMediaActionCommandProperty = DependencyProperty.Register("AddDroppedMediaActionCommand", typeof(ICommand<(IDocumentCue, MediaActionCommandParameters)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty DropMediaFilesCommandProperty = DependencyProperty.Register("DropMediaFilesCommand", typeof(ICommand<(IDocumentCue, DropMediaFilesCommandParameters)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty DropProContentAssetCommandProperty = DependencyProperty.Register("DropProContentAssetCommand", typeof(ICommand<(IDocumentCue, ProContentDropParameter<ArrangedCue>)>), typeof(CustomPresentationThumbnailPanel));

	public static readonly DependencyProperty DropPropCommandProperty = DependencyProperty.Register("DropPropCommand", typeof(ICommand<DropPropCommandParameter>), typeof(CustomPresentationThumbnailPanel));

	public IDocumentCue? DocumentCue
	{
		get
		{
			return (IDocumentCue)((DependencyObject)this).GetValue(DocumentCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentCueProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, AddMediaCueParameters)>? AddMediaActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, AddMediaCueParameters)>)((DependencyObject)this).GetValue(AddMediaActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddMediaActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, AddMediaPlaylistParameters)>? AddMediaPlaylistActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, AddMediaPlaylistParameters)>)((DependencyObject)this).GetValue(AddMediaPlaylistActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddMediaPlaylistActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, ActionCommandParameters)>? AddDroppedActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, ActionCommandParameters)>)((DependencyObject)this).GetValue(AddDroppedActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddDroppedActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, MediaActionCommandParameters)>? AddDroppedMediaActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, MediaActionCommandParameters)>)((DependencyObject)this).GetValue(AddDroppedMediaActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddDroppedMediaActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, DropMediaFilesCommandParameters)>? DropMediaFilesCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, DropMediaFilesCommandParameters)>)((DependencyObject)this).GetValue(DropMediaFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropMediaFilesCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, ProContentDropParameter<ArrangedCue?>)>? DropProContentAssetCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, ProContentDropParameter<ArrangedCue>)>)((DependencyObject)this).GetValue(DropProContentAssetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropProContentAssetCommandProperty, (object)value);
		}
	}

	public ICommand<DropPropCommandParameter>? DropPropCommand
	{
		get
		{
			return (ICommand<DropPropCommandParameter>)((DependencyObject)this).GetValue(DropPropCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropPropCommandProperty, (object)value);
		}
	}

	public event Action? InvalidateParentMeasure;

	public CustomPresentationThumbnailPanel()
	{
		_entityFactory = UIServiceProvider.GetService<IEntityFactory>();
		AddCustomDrop(OnMediaDropAction, null, null, (DraggedItems<MediaCue> s, DragEventArgs e) => true);
		AddCustomDrop(OnMediaDropAction, null, null, (DraggedItems<IMediaCueThumbnailVM> s, DragEventArgs e) => true);
		AddCustomDrop<IPlaylist<MediaCue>>(OnMediaPlaylistDropAction, null, canDropInside: true);
		AddCustomDrop(OnClearActionDropped, (DraggedItems<ClearType> s, DragEventArgs e) => true, null, (DraggedItems<ClearType> s, DragEventArgs e) => true);
		AddCustomDrop(OnActionTypeDropped, (DraggedItems<ActionType> s, DragEventArgs e) => true, null, (DraggedItems<ActionType> s, DragEventArgs e) => true);
		AddCustomDrop(OnMediaActionPaletteItemDropped, (DraggedItems<MediaType> s, DragEventArgs e) => true, null, (DraggedItems<MediaType> s, DragEventArgs e) => true);
		AddFileDrop(OnFileDrop, IsValidFileDrop, canDropInside: true);
		AddWebDropType(OnFileDrop, (FileInfo[] f, DragEventArgs e) => f.All((FileInfo i) => i.FullName.IsImageFile()));
		AddRemoteFileDrop(OnRemoteFileDrop, IsValidRemoteFileDrop, canDropInside: true);
		AddCustomDrop(OnDropPropSlide, CanDropPropSlide, null, (DraggedItems<IPropCue> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropPropSlide, (DraggedItems<IPropCueVM> i, DragEventArgs e) => true, null, (DraggedItems<IPropCueVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropMessage, (DraggedItems<Message> s, DragEventArgs e) => true, null, (DraggedItems<Message> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropTimer, (DraggedItems<ITimerVM> s, DragEventArgs e) => true, null, (DraggedItems<ITimerVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropStageLayout, CanDropStageScreen, null, (DraggedItems<ScreenArrangementBase> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropMacro, null, (DraggedItems<IMacroItemVM> s, DragEventArgs e) => true, (DraggedItems<IMacroItemVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropClearGroup, (DraggedItems<IClearGroupItemVM> s, DragEventArgs e) => true, null, (DraggedItems<IClearGroupItemVM> s, DragEventArgs e) => true);
		AddCustomDrop(OnDropProContentAsset, (DraggedItems<IProContentAssetVM> s, DragEventArgs e) => true, null, CanDropAssetInside);
	}

	private static bool CanDropPropSlide(DraggedItems<IPropCue> items, DragEventArgs e)
	{
		return items.Items.All(delegate(IPropCue i)
		{
			PropSlideAction? slideAction = i.SlideAction;
			return slideAction != null && slideAction.ActionType == ActionType.PropSlide;
		});
	}

	private void OnDropPropSlide(DraggedItems<IPropCue> items, DragEventArgs e)
	{
		IEnumerable<ActionBase> actions = items.Items.Select((IPropCue c) => c.ToAction(null));
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private void OnDropPropSlide(DraggedItems<IPropCueVM> items, DragEventArgs e)
	{
		Thumbnail targetThumbnail = FindThumbnail(e)?.Control;
		DropPropCommand?.Invoke(new DropPropCommandParameter(DocumentCue, targetThumbnail, base.DroppedBefore, base.DroppedOutside, items.Items));
	}

	private void OnDropMessage(DraggedItems<Message> items, DragEventArgs e)
	{
		IEnumerable<ActionBase> actions = items.Items.Select((Message m) => m.ToAction());
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private void OnDropTimer(DraggedItems<ITimerVM> items, DragEventArgs e)
	{
		IEnumerable<TimerAction> actions = items.Items.Select((ITimerVM t) => new TimerAction(t.ID));
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private static bool CanDropStageScreen(DraggedItems<ScreenArrangementBase> items, DragEventArgs e)
	{
		return items.Items.All((ScreenArrangementBase s) => s.ScreenTargetType == ScreenTargetType.Stage);
	}

	private void OnDropStageLayout(DraggedItems<ScreenArrangementBase> items, DragEventArgs e)
	{
		IEnumerable<ActionBase> actions = items.Items.Select((ScreenArrangementBase s) => s.ToAction());
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private void OnDropMacro(DraggedItems<IMacroItemVM> items, DragEventArgs e)
	{
		IEnumerable<Pro.DO.Triggering.IAction> actions = items.Items.Select((IMacroItemVM m) => m.Macro.ToAction()).NotNull();
		if (e.Effects == DragDropEffects.Copy)
		{
			actions = from a in items.Items.SelectMany((IMacroItemVM m) => m.Macro.Actions)
				select a.Clone();
		}
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private void OnDropClearGroup(DraggedItems<IClearGroupItemVM> items, DragEventArgs e)
	{
		IEnumerable<Pro.DO.Triggering.IAction> actions = items.Items.Select((IClearGroupItemVM c) => c.Item.ToAction()).NotNull();
		OnDropActions(actions, FindThumbnail(e)?.Control);
	}

	private void OnDropProContentAsset(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		IProContentAssetVM droppedItem = items.Items.FirstOrDefault();
		if (droppedItem != null)
		{
			bool droppedOutside = base.DroppedOutside;
			if (!droppedOutside && !CanDropAssetInside(items, e))
			{
				droppedOutside = true;
			}
			((DispatcherObject)this).Dispatcher.InvokeAsync<bool?>((Func<bool?>)(() => DropProContentAssetCommand?.Invoke((DocumentCue, new ProContentDropParameter<ArrangedCue>(droppedItem, FindThumbnail(e)?.Source, base.DropIndex, base.DroppedBefore, droppedOutside)))));
		}
	}

	private static bool CanDropAssetInside(DraggedItems<IProContentAssetVM> items, DragEventArgs e)
	{
		return items.Items.All((IProContentAssetVM a) => !(a is IProContentPackAssetVM));
	}

	private void OnDropActions(IEnumerable<Pro.DO.Triggering.IAction> actions, Thumbnail? targetThumbnail)
	{
		AddDroppedActionCommand?.Invoke((DocumentCue, new ActionCommandParameters(targetThumbnail, base.DroppedBefore, base.DroppedOutside, actions)));
	}

	protected override void OnInvalidateParentMeasure()
	{
		if (this.InvalidateParentMeasure != null)
		{
			this.InvalidateParentMeasure();
		}
		else
		{
			base.OnInvalidateParentMeasure();
		}
	}

	protected override string OnGetItemContent(ArrangedCue? source)
	{
		return string.Join("\n", source?.Source.SlideAction?.Slide.GetAllText() ?? Array.Empty<string>());
	}

	protected override string OnGetItemSecondaryContent(ArrangedCue source)
	{
		return source.Source?.SlideAction?.Slide.Note?.AllText ?? string.Empty;
	}

	private void OnMediaDropAction(DraggedItems<IMediaCueThumbnailVM> items, DragEventArgs e)
	{
		Focus();
		OnMediaDropAction(items.Items.Select((IMediaCueThumbnailVM m) => m.MediaCue));
	}

	private void OnMediaDropAction(DraggedItems<MediaCue> items, DragEventArgs e)
	{
		OnMediaDropAction(items.Items);
	}

	private void OnMediaDropAction(IEnumerable<MediaCue> cues)
	{
		AddMediaActionCommand?.Invoke((DocumentCue, new AddMediaCueParameters(base.Source as CustomPresentation, base.TargetItem?.Source, cues, base.DroppedBefore, base.DroppedOutside)));
	}

	private void OnMediaPlaylistDropAction(DraggedTreeItemsCollection<IPlaylist<MediaCue>> items, DragEventArgs e)
	{
		AddMediaPlaylistActionCommand?.Invoke((DocumentCue, new AddMediaPlaylistParameters(base.Source as CustomPresentation, base.TargetItem?.Source, items.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> t) => t.Items), base.DroppedBefore, base.DroppedOutside)));
	}

	private void OnClearActionDropped(DraggedItems<ClearType> draggedItems, DragEventArgs e)
	{
		Focus();
		AddDroppedActionCommand?.Invoke((DocumentCue, new ActionCommandParameters(FindThumbnail(e)?.Control, base.DroppedBefore, base.DroppedOutside, draggedItems.Items.Select((ClearType a) => new ClearAction(a)))));
	}

	private void OnActionTypeDropped(DraggedItems<ActionType> draggedItems, DragEventArgs e)
	{
		OnActionTypeDropped(draggedItems.Items, e);
	}

	private void OnActionTypeDropped(IEnumerable<ActionType> actionTypes, DragEventArgs e)
	{
		Focus();
		AddDroppedActionCommand?.Invoke((DocumentCue, new ActionCommandParameters(FindThumbnail(e)?.Control, base.DroppedBefore, base.DroppedOutside, null, actionTypes)));
	}

	private void OnMediaActionPaletteItemDropped(DraggedItems<MediaType> draggedItems, DragEventArgs e)
	{
		Focus();
		AddDroppedMediaActionCommand?.Invoke((DocumentCue, new MediaActionCommandParameters(FindThumbnail(e)?.Control, draggedItems.Items.FirstOrDefault(), base.DroppedBefore, base.DroppedOutside)));
	}

	private void OnFileDrop(FileInfo[] files, DragEventArgs e)
	{
		DropMediaFilesCommand?.Invoke((DocumentCue, new DropMediaFilesCommandParameters(base.Source as CustomPresentation, base.TargetItem?.Source, files.OrderBy((FileInfo f) => f.Name, new NaturalStringComparer()), base.DroppedBefore, base.DroppedOutside)));
	}

	private static bool IsValidFileDrop(FileInfo[] files, DragEventArgs e)
	{
		if (!files.Any((FileInfo f) => f.Attributes == FileAttributes.Directory))
		{
			return files.All((FileInfo f) => f.FullName.IsVisualMediaFile() || f.FullName.IsAudioFile());
		}
		return true;
	}

	private void OnRemoteFileDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		DropMediaFilesCommand?.Invoke((DocumentCue, new DropMediaFilesCommandParameters(base.Source as CustomPresentation, base.TargetItem?.Source, remoteFile, base.DroppedBefore, base.DroppedOutside)));
	}

	private static bool IsValidRemoteFileDrop(IRemoteFile remoteFile, DragEventArgs e)
	{
		if (!remoteFile.Filename.IsVisualMediaFile())
		{
			return remoteFile.Filename.IsAudioFile();
		}
		return true;
	}

	public Thumbnail? GetThumbnail(ArrangedCue arrangedCue)
	{
		Thumbnail thumbnail = FindThumbnail(arrangedCue)?.Control;
		if (thumbnail == null)
		{
			UpdateThumbnails();
			thumbnail = FindThumbnail(arrangedCue)?.Control;
		}
		return thumbnail;
	}
}
