using System.Collections.Concurrent;
using Pro.Common.Time;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Triggering;

public interface ITriggerOperation
{
	Pro.Common.Time.Clock? Clock { get; set; }

	CueInfo? CueInfo { get; }

	TriggerEnvironment Environment { get; }

	TriggerHandle Handle { get; }

	ConcurrentBag<MacroInfo> MacroInfos { get; }

	ConcurrentBag<MessageInfo> MessageInfo { get; }

	ISlidePool SlidePool { get; }

	StageInfo? StageInfo { get; set; }

	ProOperationState State { get; }

	ConcurrentBag<TimerInfo> TimerActionData { get; }

	SlideCueInfo AttachAnnouncementSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, TimelineSlideInfo? timelineSlideInfo = null);

	MacroInfo? AttachMacroInfo(ProPresenterMacro macro);

	MediaCueInfo<T> AttachMediaCueInfo<T>(CueLocation location, MediaCue mediaCue, Playlist<T>? playlist) where T : ProPresenterCue;

	PresentationSlideCueInfo AttachPresentationSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, bool isBibleSlide = false, TimelineSlideInfo? timelineSlideInfo = null);

	PropCueInfo AttachPropCueInfo(IPropCue? originalPropCue, Slide? protoSlide);
}
