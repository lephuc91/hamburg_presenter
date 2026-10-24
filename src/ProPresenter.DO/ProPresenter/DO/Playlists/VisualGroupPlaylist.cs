using System;
using System.Linq;
using Google.Protobuf.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class VisualGroupPlaylist : GroupPlaylist<MediaCue>
{
	private readonly IApp _app;

	private readonly IMediaImportService _mediaImportService;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IFlagService _flagService;

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist)
	{
		IPlaylist.Types.IChildrenType.IPlaylists playlists = playlist.ChildrenType.Value as IPlaylist.Types.IChildrenType.IPlaylists;
		if (playlists == null)
		{
			playlists = entityFactory.Create<IPlaylist.Types.IChildrenType.IPlaylists>();
			playlist.ChildrenType.Set(playlists);
		}
		ObjectBinder<VisualGroupPlaylist, IPlaylist> objectBinder = new ObjectBinder<VisualGroupPlaylist, IPlaylist>(this, playlist);
		GroupPlaylist<MediaCue>.Bind(objectBinder);
		ObjectBinder<VisualGroupPlaylist, IComplexCollection<IPlaylist>> playlistsBinder = new ObjectBinder<VisualGroupPlaylist, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		playlistsBinder.Bind((VisualGroupPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(VisualGroupPlaylist l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items, (IPlaylist<MediaCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<MediaCue> m)
			{
				IPlaylist playlist2 = entityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlist2);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist2.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist2;
			});
		}, delegate(IComplexCollection<IPlaylist> r, VisualGroupPlaylist l)
		{
			r.Items.SynchronizeTo(l, (IPlaylist e, IPlaylist<MediaCue> m) => m.ID == e.Uuid.Value, delegate(IPlaylist e, int i)
			{
				IPlaylist<MediaCue> playlist3 = ConstuctPlaylist(e);
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder2 = playlist3.Bind(scheduler, entityFactory, actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.AddChild(i, playlist3);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaylist<MediaCue> playlist4 = l.Children.ElementAtOrDefault(i);
				if (playlist4 != null)
				{
					l.RemoveChild(playlist4);
				}
			});
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeLeftFromRight(playlistsBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(playlistsBinder.InitializeRightFromLeft).RegisterChildDisposable(() => playlistsBinder);
		return objectBinder;
	}

	private IPlaylist<MediaCue> ConstuctPlaylist(IPlaylist entityPlaylist)
	{
		if (entityPlaylist.ChildrenType.Value is IPlaylist.Types.IChildrenType.IPlaylists)
		{
			return new VisualGroupPlaylist(_app, _mediaImportService, _mediaFactory, base.UndoStack, _transitionDescriptions, _flagService);
		}
		return new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack);
	}

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		throw new NotSupportedException("VisualGroupPlaylist does not contain playlist items");
	}

	public VisualGroupPlaylist(IApp app, IMediaImportService mediaImportService, IMediaFactory mediaFactory, UndoStack? undoStack, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
		: base(undoStack)
	{
		_app = app;
		_mediaImportService = mediaImportService;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
	}

	public override IPlaylist<MediaCue> Clone()
	{
		return CopyProperties(new VisualGroupPlaylist(_app, _mediaImportService, _mediaFactory, base.UndoStack, _transitionDescriptions, _flagService));
	}

	public void OnDeserializeVisualPlaylist(Playlist data, ApplicationData? applicationData)
	{
		ProtoDeserialize(data, applicationData);
		MediaBinHelper.DeserializePlaylists(base.Collection, data.Playlists?.Playlists ?? new RepeatedField<Playlist>(), base.OnDataModified, base.UndoStack, this, applicationData, _app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService);
	}

	protected override void RemoveFromRoot(IPlaylist<MediaCue> playlist)
	{
		DataVault.VisualPlaylistCollection.RemovePlaylist(playlist);
	}
}
