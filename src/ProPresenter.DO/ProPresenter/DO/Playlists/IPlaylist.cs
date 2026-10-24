using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Playlists;

public interface IPlaylist<T> : ITriggerable, IIdentifiable, INotifyPropertyChanged, ICloneable<IPlaylist<T>>, IDragDropTreeCollection<IPlaylist<T>>, ITreeNode<IPlaylist<T>>, IEnumerable<T>, IEnumerable where T : ProPresenterCue
{
	new string Name { get; set; }

	PlaylistType Type { get; }

	IPlaylist<T>? PlaylistParent { get; set; }

	bool IsExpanded { get; set; }

	string ContainerId { get; }

	event System.Action DataModified;

	Playlist ProtoSerialize();

	void ProtoDeserialize(Playlist data, ApplicationData? applicationData, bool removeExisting = true);

	IReadOnlyObjectBinder<IPlaylist<T>, IPlaylist> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylist playlist);

	IReadOnlyObjectBinder<IPlaylist<T>, IComplexCollection<IPlaylistItem>> BindItems(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IComplexCollection<IPlaylistItem> items);
}
