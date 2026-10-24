using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVEvent
{
	[Trait]
	public string name { get; set; }

	[Trait]
	public Guid documentCueUUID { get; set; }

	[Trait]
	public DateTime? date { get; set; }

	[Trait]
	public RVRepeatType repeatType { get; set; }
}
