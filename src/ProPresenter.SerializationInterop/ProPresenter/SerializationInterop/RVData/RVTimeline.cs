using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTimeline
{
	[Trait]
	public float timeOffset { get; set; }

	[Trait]
	public float duration { get; set; }

	[Trait]
	public sbyte selectedMediaTrackIndex { get; set; }

	[Trait]
	public bool loop { get; set; }

	[Optional]
	[Collection]
	[KnownTypes(typeof(RVTimelineCue), new Type[] { typeof(RVMediaCue) })]
	public List<RVCue> timeCues { get; set; }

	[Optional]
	[Collection]
	public List<NSURL> mediaTracks { get; set; }
}
