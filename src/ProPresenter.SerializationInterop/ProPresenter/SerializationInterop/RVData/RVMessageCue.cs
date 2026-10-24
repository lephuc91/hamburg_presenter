using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVMessageCue : RVCue
{
	[Trait]
	public Guid messageUUID { get; set; }
}
