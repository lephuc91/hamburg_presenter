using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public abstract class RVDisplayElement
{
	[Trait]
	public string displayName { get; set; }

	[Trait]
	public Guid UUID { get; set; }

	[Trait]
	public int typeID { get; set; }

	[Trait]
	public float displayDelay { get; set; }

	[Trait]
	public bool locked { get; set; }

	[Trait]
	public bool persistent { get; set; }

	[Trait]
	public bool fromTemplate { get; set; }

	[Trait]
	[Optional]
	public float opacity { get; set; }
}
