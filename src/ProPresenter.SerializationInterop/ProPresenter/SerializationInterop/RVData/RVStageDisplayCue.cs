using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVStageDisplayCue : RVCue
{
	[Trait]
	public Guid layoutUUID { get; set; }
}
