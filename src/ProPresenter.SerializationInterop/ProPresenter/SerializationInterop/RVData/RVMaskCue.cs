using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVMaskCue : RVCue
{
	[Trait]
	public Guid maskUUID { get; set; }
}
