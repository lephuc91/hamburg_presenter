using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Props;

public class DropMediaCommandParameters
{
	public IEnumerable<string>? Files { get; }

	public IEnumerable<MediaCue>? MediaCues { get; }

	public int DropIndex { get; }

	public IPropCue? TargetProp { get; }

	public bool IsDropInside { get; }

	public DropMediaCommandParameters(IEnumerable<string>? files, IEnumerable<MediaCue>? mediaCues, int dropIndex, IPropCue? arrangedCue, bool isDropInside)
	{
		Files = files;
		MediaCues = mediaCues;
		DropIndex = dropIndex;
		TargetProp = arrangedCue;
		IsDropInside = isDropInside;
	}
}
