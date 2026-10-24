using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTimerCue : RVCue
{
	[Trait]
	public Guid timerUUID { get; set; }
}
