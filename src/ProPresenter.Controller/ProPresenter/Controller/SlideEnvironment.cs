using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller;

public class SlideEnvironment
{
	public ArrangedCue? Current { get; private set; }

	public ArrangedCue? NextPhysical { get; private set; }

	public ArrangedCue? NextLogical { get; private set; }

	public ArrangedCue? PreviousPhysical { get; private set; }

	public ArrangedCue? PreviousLogical { get; private set; }

	public ProPresenterCue? PlaylistItem { get; private set; }

	public void Update(Playlist<ProPresenterCue>? playlist, ProPresenterCue? cue, ArrangedCue? slide, bool ignoreBuilds)
	{
		Current = slide;
		NextPhysical = TriggerHelper.FindNextPhysicalSlide(playlist, cue, slide, allowLooping: true, includeNextPresentation: true, includeFirst: false);
		NextLogical = TriggerHelper.FindNextLogicalSlide(playlist, cue, slide, ignoreBuilds);
		PreviousPhysical = TriggerHelper.FindPreviousPhysicalSlide(playlist, cue, slide, allowLooping: true, includePreviousPresentation: true);
		PreviousLogical = TriggerHelper.FindPreviousLogicalSlide(playlist, cue, slide, ignoreBuilds);
		PlaylistItem = cue;
	}
}
