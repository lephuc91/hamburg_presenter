using System.Collections.Concurrent;
using System.Linq;
using Pro.Common.Time;
using Pro.DO.Transitions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.Controller.Triggering;

public class TriggerOperation : ITriggerOperation
{
	public ISlidePool SlidePool { get; }

	public TriggerHandle Handle { get; }

	public TriggerEnvironment Environment { get; }

	public CueInfo? CueInfo { get; private set; }

	public ConcurrentBag<MacroInfo> MacroInfos { get; } = new ConcurrentBag<MacroInfo>();

	public ConcurrentBag<MessageInfo> MessageInfo { get; } = new ConcurrentBag<MessageInfo>();

	public StageInfo? StageInfo { get; set; }

	public ConcurrentBag<TimerInfo> TimerActionData { get; } = new ConcurrentBag<TimerInfo>();

	public Pro.Common.Time.Clock? Clock { get; set; }

	public ProOperationState State { get; internal set; }

	public TriggerOperation(TriggerEnvironment environment, TriggerHandle handle, IGeneral general, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		Environment = environment;
		Handle = handle;
		SlidePool = new SlidePool(factoryProvider, transitionDescriptions);
	}

	public PresentationSlideCueInfo AttachPresentationSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, bool isBibleSlide = false, TimelineSlideInfo? timelineSlideInfo = null)
	{
		PresentationSlideCueInfo presentationSlideCueInfo = new PresentationSlideCueInfo(originalCurrentSlide, originalNextSlide, protoSlide, linkedCurrentSlide, linkedNextSlide, originalPlaylist, originalDocumentCue, isBibleSlide, timelineSlideInfo);
		SetupSlideCueInfo(presentationSlideCueInfo, originalCurrentSlide);
		return presentationSlideCueInfo;
	}

	public SlideCueInfo AttachAnnouncementSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, TimelineSlideInfo? timelineSlideInfo = null)
	{
		return AttachSlideCueInfo(originalCurrentSlide, originalNextSlide, protoSlide, linkedCurrentSlide, linkedNextSlide, CueLocation.Presentation, Action.Types.ContentDestination.Announcements, originalPlaylist, originalDocumentCue, timelineSlideInfo);
	}

	public PropCueInfo AttachPropCueInfo(IPropCue? originalPropCue, Slide? protoSlide)
	{
		return (PropCueInfo)(CueInfo = new PropCueInfo(CueLocation.Props, originalPropCue, protoSlide));
	}

	private SlideCueInfo AttachSlideCueInfo(ArrangedCue? originalCurrentSlide, SlideCue? originalNextSlide, Slide? protoSlide, CustomSlide? linkedCurrentSlide, CustomSlide? linkedNextSlide, CueLocation location, Action.Types.ContentDestination destination, Playlist<ProPresenterCue>? originalPlaylist, IDocumentCue? originalDocumentCue, TimelineSlideInfo? timelineSlideInfo = null)
	{
		SlideCueInfo slideCueInfo = new SlideCueInfo(location, destination, originalCurrentSlide, originalNextSlide, protoSlide, linkedCurrentSlide, linkedNextSlide, originalPlaylist, originalDocumentCue, isBibleSlide: false, timelineSlideInfo);
		SetupSlideCueInfo(slideCueInfo, originalCurrentSlide);
		return slideCueInfo;
	}

	private void SetupSlideCueInfo(SlideCueInfo cueInfo, ArrangedCue? originalCurrentSlide)
	{
		CueInfo = cueInfo;
		StageInfo = new StageInfo(originalCurrentSlide?.Source?.Actions.OfType<StageAction>().FirstOrDefault()?.ScreenAssignments?.Serialize());
	}

	public MediaCueInfo<T> AttachMediaCueInfo<T>(CueLocation location, MediaCue mediaCue, Playlist<T>? playlist) where T : ProPresenterCue
	{
		return (MediaCueInfo<T>)(CueInfo = new MediaCueInfo<T>(location, mediaCue, playlist));
	}

	public MacroInfo? AttachMacroInfo(ProPresenterMacro macro)
	{
		if (macro == null || MacroInfos.Any((MacroInfo m) => m.OriginalMacro.ID == macro.ID))
		{
			return null;
		}
		MacroInfo macroInfo = new MacroInfo(macro);
		MacroInfos.Add(macroInfo);
		return macroInfo;
	}
}
