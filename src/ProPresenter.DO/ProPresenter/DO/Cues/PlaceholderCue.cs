using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Cues;

public class PlaceholderCue : ProPresenterCue, IDocumentCue, IFileResource, INotifyPropertyChanged, IActionRepoContainer, IHasMediaContainerId, IMediaCue, ILinkableCue, IMaybeUnresolvedCue
{
	public override CueType Type => CueType.Placeholder;

	public override string Name
	{
		get
		{
			return (string)((PlaceholderAction?.State switch
			{
				LinkState.Unlinked => base.Name, 
				LinkState.DocumentLinked => DocumentAction?.Name, 
				LinkState.MediaLinked => MediaAction?.Name, 
				_ => base.Name, 
			}) ?? string.Empty);
		}
		set
		{
			base.Name = value;
			OnPropertyChanged("PlaceholderName");
		}
	}

	public string PlaceholderName => base.Name;

	public PlaceholderAction? PlaceholderAction => base.Actions.FirstOrDefaultOf<PlaceholderAction>();

	public bool IsLinked
	{
		get
		{
			if (PlaceholderAction != null)
			{
				return PlaceholderAction.State != LinkState.Unlinked;
			}
			return false;
		}
	}

	public IDocumentAction? DocumentAction => PlaceholderAction?.DocumentAction;

	public string? LibraryName => PlaceholderAction?.DocumentAction?.LibraryName;

	public MediaAction? MediaAction => PlaceholderAction?.MediaAction;

	public RelativePath? Path => PlaceholderAction?.State switch
	{
		LinkState.DocumentLinked => DocumentAction?.Presentation?.SourceFile, 
		LinkState.MediaLinked => MediaAction?.FileMedia?.SourceFile, 
		_ => null, 
	};

	public Playlist<ProPresenterCue>? PlaylistParent { get; set; }

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		IPlaylistItem.Types.IItemType.IPlaceholder placeholder = right.ItemType.Value as IPlaylistItem.Types.IItemType.IPlaceholder;
		if (placeholder == null)
		{
			placeholder = entityFactory.Create<IPlaylistItem.Types.IItemType.IPlaceholder>();
			right.ItemType.Set(placeholder);
		}
		PlaceholderAction.ThrowWhenNull("PlaceholderAction");
		ObjectBinder<PlaceholderAction, IPlaylistItem.Types.IPlaceholder> placeholderCueBinder = PlaceholderAction.CreateBinder(scheduler, entityFactory, actionBinderFactory, placeholder.Value);
		return new ObjectBinder<PlaceholderCue, IPlaylistItem>(this, right).Bind((PlaceholderCue l) => l.WhenPropertyChanges("ID"), (IPlaylistItem r) => r.Uuid.WhenValueChanges, delegate(PlaceholderCue l, IPlaylistItem r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IPlaylistItem r, PlaceholderCue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PlaceholderCue l) => l.WhenPropertyChanges("Name"), (IPlaylistItem r) => r.Name.WhenValueChanges, delegate(PlaceholderCue l, IPlaylistItem r)
		{
			r.Name.Set(l.Name);
		}, delegate(IPlaylistItem r, PlaceholderCue l)
		{
			l.Name = r.Name.Value;
		}).Bind((PlaceholderCue l) => l.WhenPropertyChanges("IsHidden"), (IPlaylistItem r) => r.IsHidden.WhenValueChanges, delegate(PlaceholderCue l, IPlaylistItem r)
		{
			r.IsHidden.Set(l.IsHidden);
		}, delegate(IPlaylistItem r, PlaceholderCue l)
		{
			l.IsHidden = r.IsHidden.Value;
		})
			.Bind<Unit, Unit>(null, (IPlaylistItem r) => r.ItemType.WhenValueChanges.ToUnit(), delegate
			{
				Log.Error("[{0}] Attempting to change the type of the cue from within ProPresenter.", typeof(PlaceholderCue));
			}, delegate(IPlaylistItem r, PlaceholderCue l)
			{
				Log.Error("[{0}] Attempting to change the type of the cue via CRDT to {1}. This is not supported currently.", typeof(PlaceholderCue), r.ItemType.Value);
			})
			.DoOnInitializeLeftFromRight(placeholderCueBinder.InitializeLeftFromRight)
			.DoOnInitializeRightFromLeft(placeholderCueBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => placeholderCueBinder);
	}

	public PlaceholderCue(IApp app, IProPresenterResourceService resourceService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: this(string.Empty, app, resourceService, mediaFactory, transitionDescriptions)
	{
	}

	public PlaceholderCue(string name, IApp app, IProPresenterResourceService resourceService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions)
		: this(name, new PlaceholderAction(app, resourceService, mediaFactory, transitionDescriptions))
	{
	}

	public PlaceholderCue(string name, PlaceholderAction? action)
	{
		Name = name;
		if (action != null)
		{
			AddAction(action);
			SetUpAction(action);
		}
	}

	public override Pro.DO.Triggering.Cue Clone()
	{
		PlaceholderCue placeholderCue = (PlaceholderCue)CopyProperties(new PlaceholderCue(string.Empty, null)
		{
			ContainerId = base.ContainerId
		});
		if (placeholderCue.PlaceholderAction != null)
		{
			placeholderCue.SetUpAction(placeholderCue.PlaceholderAction);
		}
		return placeholderCue;
	}

	private void SetUpAction(PlaceholderAction action)
	{
		LinkProperties("State", new string[2] { "Name", "IsLinked" });
		LinkProperties("DocumentAction", new string[2] { "DocumentAction", "Path" });
		LinkProperties("MediaAction", new string[2] { "MediaAction", "Path" });
		action.DataModified += base.OnDataModified;
		action.PropertyChanged += base.RaiseLinkedValues;
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (newRepos != null && PlaceholderAction?.DocumentAction?.Presentation is CustomPresentation customPresentation)
		{
			customPresentation.InsertCues(newRepos.OfType<SlideCue>(), repo as SlideCue, PlaceholderAction.DocumentAction.ActiveArrangement, insertBefore);
		}
	}

	protected override void OnProtoSerializePlaylistItem(PlaylistItem playlistItem)
	{
		playlistItem.Placeholder = PlaceholderAction?.ProtoSerializePlaylistItemPlaceholder();
		playlistItem.Name = PlaceholderName;
	}

	protected override void OnProtoDeserializePlaylistItem(PlaylistItem playlistItem, ApplicationData? applicationData, string containerId)
	{
		PlaceholderAction?.ProtoDeserializePlaylistItemPlaceholder(playlistItem.Placeholder, applicationData, containerId);
		base.OnProtoDeserializePlaylistItem(playlistItem, applicationData, containerId);
	}

	public bool NeedsResolve()
	{
		return PlaceholderAction?.NeedsResolve() ?? false;
	}

	public ProPresenterCue? Resolve(ILibraryCollection libraryCollection)
	{
		PlaceholderAction?.Resolve(libraryCollection);
		return this;
	}
}
