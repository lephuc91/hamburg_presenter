using System.Collections.Generic;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.CueInspector;

public class InspectorParameter
{
	public IEnumerable<MediaCue>? Cues { get; }

	public InlineType ActiveInlineView { get; set; } = InlineType.Presentation;

	public InspectorOptions Options { get; }

	public InspectorParameter(IEnumerable<MediaCue>? cues)
		: this(cues, InspectorOptions.Default)
	{
	}

	public InspectorParameter(IEnumerable<MediaCue>? cues, InspectorOptions options)
	{
		Cues = cues;
		Options = options;
	}
}
