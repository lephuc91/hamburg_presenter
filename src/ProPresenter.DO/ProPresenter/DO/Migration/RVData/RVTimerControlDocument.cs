using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVTimerControlDocument
{
	[Collection]
	[Alias("CountdownTimers", typeof(RVTimer), false)]
	public List<RVTimer>? CountdownTimers { get; set; }

	[Child]
	[Alias("DateFormat", typeof(string), false)]
	public string? DateFormat { get; set; }

	[Child]
	[Alias("Is24HourClock", typeof(bool), false)]
	public bool Is24HourClock { get; set; }

	[Child]
	[Alias("TimeFormat", typeof(string), false)]
	public string? TimeFormat { get; set; }
}
