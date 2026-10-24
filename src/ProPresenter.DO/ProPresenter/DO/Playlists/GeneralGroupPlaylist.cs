using System;
using System.Linq;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;

namespace ProPresenter.DO.Playlists;

public class GeneralGroupPlaylist : GroupPlaylist<ProPresenterCue>
{
	private readonly IProPresenterResourceService _resourceService;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly ILogger _logger;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly IMediaFactory _mediaFactory;

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		IPlaylist.Types.IChildrenType.IPlaylists playlists = playlist.ChildrenType.Value as IPlaylist.Types.IChildrenType.IPlaylists;
		if (playlists == null)
		{
			playlists = entityFactory.Create<IPlaylist.Types.IChildrenType.IPlaylists>();
			playlist.ChildrenType.Set(playlists);
		}
		ObjectBinder<GeneralGroupPlaylist, IPlaylist> objectBinder = new ObjectBinder<GeneralGroupPlaylist, IPlaylist>(this, playlist);
		GroupPlaylist<ProPresenterCue>.Bind(objectBinder);
		ObjectBinder<GeneralGroupPlaylist, IComplexCollection<IPlaylist>> playlistsBinder = new ObjectBinder<GeneralGroupPlaylist, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		playlistsBinder.Bind((GeneralGroupPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(GeneralGroupPlaylist l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items, (IPlaylist<ProPresenterCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<ProPresenterCue> m)
			{
				IPlaylist playlist2 = entityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlist2);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist2.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist2;
			});
		}, delegate(IComplexCollection<IPlaylist> r, GeneralGroupPlaylist l)
		{
			r.Items.SynchronizeTo(l, (IPlaylist e, IPlaylist<ProPresenterCue> m) => m.ID == e.Uuid.Value, delegate(IPlaylist e, int i)
			{
				IPlaylist<ProPresenterCue> playlist3 = ConstructPlaylist(e);
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> readOnlyObjectBinder2 = playlist3.Bind(scheduler, entityFactory, actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.AddChild(i, playlist3);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaylist<ProPresenterCue> playlist4 = l.Children.ElementAtOrDefault(i);
				if (playlist4 != null)
				{
					l.RemoveChild(playlist4);
				}
			});
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeLeftFromRight(playlistsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(playlistsBinder.InitializeRightFromLeft).RegisterChildDisposable(() => playlistsBinder);
		return objectBinder;
	}

	private IPlaylist<ProPresenterCue> ConstructPlaylist(IPlaylist entityPlaylist)
	{
		if (entityPlaylist.ChildrenType.Value is IPlaylist.Types.IChildrenType.IPlaylists)
		{
			return new GeneralGroupPlaylist(_resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, base.UndoStack);
		}
		if (entityPlaylist.LinkData.Value is IPlaylist.Types.ILinkData.IPcoPlan { Value: var value })
		{
			PCOPlan pcoPlan2 = new PCOPlan(string.IsNullOrEmpty(value.ParentIdStr.Value) ? (value.ParentIdNum.Value.ToString() ?? string.Empty) : value.ParentIdStr.Value, string.IsNullOrEmpty(value.PlanIdStr.Value) ? value.PlanIdNum.Value.ToString() : value.PlanIdStr.Value.ToLower(), value.PlanTitle.Value, value.UpdateDate.Value.Seconds.FromUnixTimestamp(), value.DateList.Value, value.SeriesTitle.Value, value.CreatedDate.Value.Seconds.FromUnixTimestamp());
			return new PCOPlaylist(_resourceService, _importProcessFactory, pcoPlan2, base.UndoStack, _cueFactory, _mediaFactory);
		}
		return new GeneralPlaylist(_logger, _cueFactory, base.UndoStack);
	}

	public override IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		throw new NotSupportedException("GeneralGroupPlaylist does not contain playlist items");
	}

	public GeneralGroupPlaylist(IProPresenterResourceService resourceService, IImportProcessFactory importProcessFactory, ILogger logger, IProPresenterCueFactory cueFactory, IMediaFactory mediaFactory, UndoStack? undoStack = null)
		: base(undoStack)
	{
		_resourceService = resourceService;
		_importProcessFactory = importProcessFactory;
		_logger = logger;
		_cueFactory = cueFactory;
		_mediaFactory = mediaFactory;
	}

	public override IPlaylist<ProPresenterCue> Clone()
	{
		return CopyProperties(new GeneralGroupPlaylist(_resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, base.UndoStack));
	}

	public void ReplaceChildPlaylist(IPlaylist<ProPresenterCue> oldChild, IPlaylist<ProPresenterCue> newChild)
	{
		if (base.Collection.Contains(oldChild))
		{
			oldChild.DataModified -= base.OnDataModified;
			newChild.DataModified += base.OnDataModified;
			int index = base.Collection.IndexOf(oldChild);
			base.Collection[index] = newChild;
		}
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		PlaylistLibraryHelper.DeserializePlaylists(base.Collection, data.Playlists.Playlists, base.OnDataModified, base.UndoStack, this, applicationData, _resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, removeExisting);
	}

	protected override void RemoveFromRoot(IPlaylist<ProPresenterCue> playlist)
	{
		DataVault.LibraryPlaylistCollection?.RemovePlaylist(playlist);
	}
}
