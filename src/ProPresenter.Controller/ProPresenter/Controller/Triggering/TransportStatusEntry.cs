using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;

namespace ProPresenter.Controller.Triggering;

public record TransportStatusEntry(MediaBase? Media, IPlaybackMarker[] PlaybackMarkers, bool IsPlaying, double Elapsed, double Remaining);
