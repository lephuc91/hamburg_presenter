using System;
using Pro.Common.Components;

namespace ProPresenter.DO.Actions;

public interface ITargetPlaylistCollection
{
	event Action CollectionModified;

	IIdentifiable? GetPlaylist(Guid id, string name);
}
