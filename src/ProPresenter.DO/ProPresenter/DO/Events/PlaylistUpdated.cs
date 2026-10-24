using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Events;

public record PlaylistUpdated<T>(T? Item, Playlist<T>? Playlist) where T : ProPresenterCue;
