using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPropTransitionData
{
	[Child]
	[Alias("Duration", typeof(double), false)]
	public double Duration { get; set; }

	[Child]
	[Alias("TransitionType", typeof(string), false)]
	public string? TransitionType { get; set; }
}
