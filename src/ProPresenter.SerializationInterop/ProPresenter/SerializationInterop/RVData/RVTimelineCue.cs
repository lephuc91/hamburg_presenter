using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTimelineCue : RVCue
{
	[Trait]
	public Guid representedObjectUUID { get; set; }

	[Trait]
	public int slideIndex { get; set; }
}
