using System.Windows.Media;
using Pro.Common.Time;
using ProPresenter.DO.Actions;

namespace ProPresenter.DO.Slide.Links;

public interface IPlaybackMarkerInformation
{
	IPlaybackMarker[]? Markers { get; }

	TimeSlice Elapsed { get; }

	TimeSlice LoopDuration { get; }

	TimeSlice TotalDuration { get; }

	IPlaybackMarker? FindMarker(PlaybackMarkerIdentifier identifier, Color implicitColor);
}
