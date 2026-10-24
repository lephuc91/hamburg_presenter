using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.Triggering;

public interface ISlideCueInfo
{
	TimelineSlideInfo? TimelineSlideInfo { get; }

	IDocumentCue? OriginalDocumentCue { get; }

	ArrangedCue? OriginalCurrentSlide { get; }

	SlideCue? OriginalNextSlide { get; }

	Playlist<ProPresenterCue>? OriginalPlaylist { get; }
}
