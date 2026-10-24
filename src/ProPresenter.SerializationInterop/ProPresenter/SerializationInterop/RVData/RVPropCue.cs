using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPropCue : RVCue
{
	[Trait]
	public Guid propUUID { get; set; }

	[Child]
	[Optional]
	public RVTransition selectedTransition { get; set; }
}
