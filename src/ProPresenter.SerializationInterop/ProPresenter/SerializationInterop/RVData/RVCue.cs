using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public abstract class RVCue
{
	[Trait]
	public Guid UUID { get; set; }

	[Trait]
	public string displayName { get; set; }

	[Trait]
	public RVCueAction actionType { get; set; }

	[Trait]
	public bool enabled { get; set; }

	[Trait]
	public float timeStamp { get; set; }

	[Trait]
	public float delayTime { get; set; }
}
