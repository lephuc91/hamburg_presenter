using System.Windows.Media;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.Triggering;

public class SlideCueInfo : CueInfo, ISlideCueInfo
{
	public Action.Types.ContentDestination ContentDestination { get; }

	public ArrangedCue? OriginalCurrentSlide { get; }

	public SlideCue? OriginalNextSlide { get; }

	public Slide? ProtoSlide { get; }

	public CustomSlide? LinkedCurrentSlide { get; }

	public CustomSlide? LinkedNextSlide { get; }

	public Playlist<ProPresenterCue>? OriginalPlaylist { get; }

	public IDocumentCue? OriginalDocumentCue { get; }

	public bool HasPresentationColor { get; }

	public System.Windows.Media.Color PresentationColor { get; }

	public bool IsBibleSlide { get; }

	public TimelineSlideInfo? TimelineSlideInfo { get; }

	public SlideCueInfo(CueLocation location, Action.Types.ContentDestination destination, ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, bool isBibleSlide, TimelineSlideInfo? timelineSlideInfo = null)
		: base(location)
	{
		ContentDestination = destination;
		OriginalCurrentSlide = originalCurrentSlide;
		OriginalNextSlide = originalNextSlide;
		ProtoSlide = protoSlide;
		LinkedCurrentSlide = linkedCurrentSlide;
		LinkedNextSlide = linkedNextSlide;
		OriginalPlaylist = originalPlaylist;
		OriginalDocumentCue = originalDocumentCue;
		IsBibleSlide = isBibleSlide;
		TimelineSlideInfo = timelineSlideInfo;
		IPresentation presentation = originalDocumentCue?.DocumentAction?.Presentation;
		if (presentation != null && presentation.UseBackgroundColor)
		{
			HasPresentationColor = true;
			PresentationColor = presentation.BackgroundColor;
		}
	}
}
