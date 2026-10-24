using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.MediaLibrary;

public class AddMediaCueParameters : DragDropCommandParameters<SlideCue?, CustomPresentation>
{
	public IEnumerable<MediaCue> MediaCues { get; }

	public AddMediaCueParameters(CustomPresentation? targetPresentation, SlideCue? targetCue, IEnumerable<MediaCue> mediaCues, bool droppedBefore, bool droppedOutside)
		: base(targetPresentation, Enumerable.Empty<SlideCue>(), targetCue, -1, droppedBefore, droppedOutside, copy: false)
	{
		MediaCues = mediaCues;
	}
}
