using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.Triggering;

public class PresentationSlideCueInfo : SlideCueInfo
{
	public PresentationSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, bool isBibleSlide, TimelineSlideInfo? timelineSlideInfo = null)
		: base(CueLocation.Presentation, Action.Types.ContentDestination.Global, originalCurrentSlide, originalNextSlide, protoSlide, linkedCurrentSlide, linkedNextSlide, originalPlaylist, originalDocumentCue, isBibleSlide, timelineSlideInfo)
	{
	}
}
