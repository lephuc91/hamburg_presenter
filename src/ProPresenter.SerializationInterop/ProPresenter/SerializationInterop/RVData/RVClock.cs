using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVClock
{
	[Trait]
	public Guid uuid { get; set; }

	[Trait]
	public string name { get; set; }

	[Trait]
	public string duration { get; set; }

	[Trait]
	public string endTime { get; set; }

	[Trait]
	public RVTimerType type { get; set; }

	[Trait]
	public RVCountDownToTimeFormat countDownToTimeFormat { get; set; }

	[Trait]
	public bool allowOverrun { get; set; }
}
