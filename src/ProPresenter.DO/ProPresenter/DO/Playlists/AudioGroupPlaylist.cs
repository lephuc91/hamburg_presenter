using System;
using System.Linq;
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
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Playlists;

public class AudioGroupPlaylist : GroupPlaylist<MediaCue>
{
	private readonly IApp _app;

	private readonly IAsyncFileImporter _importer;

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
		ObjectBinder<AudioGroupPlaylist, IPlaylist> objectBinder = new ObjectBinder<AudioGroupPlaylist, IPlaylist>(this, playlist);
		GroupPlaylist<MediaCue>.Bind(objectBinder);
		ObjectBinder<AudioGroupPlaylist, IComplexCollection<IPlaylist>> playlistsBinder = new ObjectBinder<AudioGroupPlaylist, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		playlistsBinder.Bind((AudioGroupPlaylist l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(AudioGroupPlaylist l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items, (IPlaylist<MediaCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<MediaCue> m)
			{
				IPlaylist playlist2 = entityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlist2);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist2.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist2;
			});
		}, delegate(IComplexCollection<IPlaylist> r, AudioGroupPlaylist l)
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
			return new AudioGroupPlaylist(base.UndoStack, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService);
		}
		return new AudioPlaylist(_app, _importer, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack);
	}

	public override IReadOnlyObjectBinder<IPlaylist<MediaCue>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items)
	{
		throw new NotSupportedException("AudioGroupPlaylist does not contain playlist items");
	}

	public AudioGroupPlaylist(UndoStack? undoStack, IApp app, IAsyncFileImporter importer, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService)
		: base(undoStack)
	{
		_app = app;
		_importer = importer;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_flagService = flagService;
	}

	public override IPlaylist<MediaCue> Clone()
	{
		return CopyProperties(new AudioGroupPlaylist(base.UndoStack, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService));
	}

	public override void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true)
	{
		base.ProtoDeserialize(data, applicationData, removeExisting);
		AudioBinHelper.DeserializePlaylists(base.Collection, data.Playlists.Playlists, base.OnDataModified, base.UndoStack, this, applicationData, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService, removeExisting);
	}

	protected override void RemoveFromRoot(IPlaylist<MediaCue> playlist)
	{
		DataVault.AudioPlaylistCollection?.Remove(playlist);
	}
}
