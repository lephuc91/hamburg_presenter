using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Cues;

public class DocumentCue : ProPresenterCue, IDocumentCue, IFileResource, INotifyPropertyChanged, IActionRepoContainer, IHasMediaContainerId, IMaybeUnresolvedCue
{
	public override string Name
	{
		get
		{
			return DocumentAction?.Presentation?.Name ?? DocumentAction?.Name ?? string.Empty;
		}
		set
		{
			if (DocumentAction != null && DocumentAction.Presentation != null)
			{
				DocumentAction.Presentation.Name = value;
			}
		}
	}

	public override CueType Type => CueType.Document;

	public override UndoStack? UndoStack
	{
		get
		{
			return base.Actions.OfType<IDocumentAction>().FirstOrDefault()?.Presentation?.UndoStack ?? base.UndoStack;
		}
		set
		{
			base.UndoStack = value;
		}
	}

	public IDocumentAction DocumentAction => base.Actions.FirstOf<IDocumentAction>();

	public string LibraryName => DocumentAction.LibraryName;

	public RelativePath Path => DocumentAction.Presentation?.SourceFile ?? RelativePath.Empty();

	public Playlist<ProPresenterCue>? PlaylistParent { get; set; }

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		IPlaylistItem.Types.IItemType.IPresentation presentation = right.ItemType.Value as IPlaylistItem.Types.IItemType.IPresentation;
		if (presentation == null)
		{
			presentation = entityFactory.Create<IPlaylistItem.Types.IItemType.IPresentation>();
			right.ItemType.Set(presentation);
		}
		ObjectBinder<DocumentCue, IPlaylistItem.Types.IItemType.IPresentation> presentationBinder = new ObjectBinder<DocumentCue, IPlaylistItem.Types.IItemType.IPresentation>(this, presentation);
		presentationBinder.Bind((DocumentCue l) => l.WhenPropertyChanges("DocumentAction"), (IPlaylistItem.Types.IItemType.IPresentation r) => r.WhenValueChanges, delegate(DocumentCue l, IPlaylistItem.Types.IItemType.IPresentation r)
		{
			IPlaylistItem.Types.IPresentation presentation2 = entityFactory.Create<IPlaylistItem.Types.IPresentation>();
			r.Set(presentation2);
			ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder = l.DocumentAction.CreatePlaylistBinder(scheduler, entityFactory, presentation2);
			objectBinder.InitializeRightFromLeft();
			presentation2.RegisterLinkedDisposable(objectBinder);
		}, delegate(IPlaylistItem.Types.IItemType.IPresentation r, DocumentCue l)
		{
			ObjectBinder<DocumentAction, IPlaylistItem.Types.IPresentation> objectBinder2 = l.DocumentAction.CreatePlaylistBinder(scheduler, entityFactory, r.Value);
			objectBinder2.InitializeLeftFromRight();
			r.Value.RegisterLinkedDisposable(objectBinder2);
		});
		return new ObjectBinder<DocumentCue, IPlaylistItem>(this, right).Bind((DocumentCue l) => l.WhenPropertyChanges("ID"), (IPlaylistItem r) => r.Uuid.WhenValueChanges, delegate(DocumentCue l, IPlaylistItem r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IPlaylistItem r, DocumentCue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((DocumentCue l) => l.DocumentAction.WhenPropertyChanges("Name"), (IPlaylistItem r) => r.Name.WhenValueChanges, delegate(DocumentCue l, IPlaylistItem r)
		{
			r.Name.Set(l.DocumentAction.Name);
		}, delegate
		{
		}).Bind((DocumentCue l) => l.WhenPropertyChanges("IsHidden"), (IPlaylistItem r) => r.IsHidden.WhenValueChanges, delegate(DocumentCue l, IPlaylistItem r)
		{
			r.IsHidden.Set(l.IsHidden);
		}, delegate(IPlaylistItem r, DocumentCue l)
		{
			l.IsHidden = r.IsHidden.Value;
		})
			.Bind<Unit, Unit>(null, (IPlaylistItem r) => r.ItemType.WhenValueChanges.ToUnit(), delegate
			{
				Log.Error("[{0}] Attempting to change the type of the cue from within ProPresenter.", typeof(PlaceholderCue));
			}, delegate(IPlaylistItem r, DocumentCue l)
			{
				Log.Error("[{0}] Attempting to change the type of the cue via CRDT to {1}. This is not supported currently.", typeof(PlaceholderCue), r.ItemType.Value);
			})
			.DoOnInitializeLeftFromRight(presentationBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(presentationBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => presentationBinder);
	}

	public DocumentCue(IDocumentAction action, bool newID = true)
		: base(newID)
	{
		if (!newID)
		{
			ProPresenter.DO.Presentation.IPresentation? presentation = action.Presentation;
			if (presentation != null)
			{
				_ = presentation.ID;
				if (true)
				{
					base.ID = action.Presentation.ID;
				}
			}
		}
		AddAction(action);
		Name = action.Presentation?.Name ?? string.Empty;
		LinkProperties("Name", "Name");
		LinkAction("SourceFile", base.OnDataModified);
		if (action.Presentation != null)
		{
			action.Presentation.PropertyChanged += base.RaiseLinkedValues;
		}
	}

	public DocumentCue(ProPresenter.DO.Presentation.IPresentation presentation, bool supportsArrangement = true, bool newID = true)
		: this(new DocumentAction(presentation, supportsArrangement), newID)
	{
	}

	public DocumentCue(RelativePath documentPath, bool newId = true)
		: this(new DocumentAction(documentPath), newId)
	{
	}

	private DocumentCue()
	{
	}

	public override Pro.DO.Triggering.Cue Clone()
	{
		return CopyProperties(new DocumentCue());
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		Name = DocumentAction.Presentation?.Name ?? string.Empty;
		playlistItem.Presentation = DocumentAction.OnProtoSerializePlaylistItem();
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		DocumentAction.OnProtoDeserializePlaylistItem(playlistItem);
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (newRepos == null || !(DocumentAction?.Presentation is CustomPresentation customPresentation))
		{
			return;
		}
		IEnumerable<SlideCue> cues = newRepos.OfType<SlideCue>();
		SlideCue target = repo as SlideCue;
		if (target != null)
		{
			ArrangedCue arrangedCue = DocumentAction.ActiveArrangement?.ArrangedCues.FirstOrDefault((ArrangedCue c) => c.Source == target);
			bool insertNewGroup = ((arrangedCue?.IsGroupHead ?? false) && insertBefore) || (arrangedCue != null && arrangedCue.IsGroupTail && !insertBefore);
			CueGroup cueGroup = customPresentation.ArrangementGroups.FirstOrDefault((CueGroup g) => g.Cues.Contains(target));
			if (cueGroup != null)
			{
				customPresentation.CuesDroppedInto(cues, target, insertBefore, insertNewGroup, cueGroup);
			}
		}
		else
		{
			customPresentation.InsertCues(cues, target, DocumentAction.ActiveArrangement, insertBefore);
		}
	}

	public bool NeedsResolve()
	{
		return DocumentAction?.Presentation == null;
	}

	public ProPresenterCue? Resolve(ILibraryCollection libraries)
	{
		DocumentAction?.EnsurePresentationResolved(libraries);
		return this;
	}
}
