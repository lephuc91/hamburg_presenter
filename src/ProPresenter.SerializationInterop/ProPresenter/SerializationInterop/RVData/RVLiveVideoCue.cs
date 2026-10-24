using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVLiveVideoCue : RVCue
{
	[Trait]
	public RVMediaCueBehaviorType behavior { get; set; }

	[Trait]
	public RVAlignment alignment { get; set; }

	[Trait]
	public DateTime? dateAdded { get; set; }

	[Child]
	[Optional]
	public RVLiveVideoElement videoElement { get; set; }

	[Child]
	[Optional]
	public RVTransition transition { get; set; }
}
