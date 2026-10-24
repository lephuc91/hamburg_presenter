using System;

namespace ProPresenter.SerializationInterop.RVData;

public interface IPlaylistChild
{
	Guid UUID { get; set; }

	PlaylistChildType ChildType { get; }
}
