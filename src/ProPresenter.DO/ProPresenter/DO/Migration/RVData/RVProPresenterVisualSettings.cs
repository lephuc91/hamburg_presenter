using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVProPresenterVisualSettings
{
	[Child]
	[Alias("PropTrasitionData", typeof(RVPropTransitionData), false)]
	public RVPropTransitionData? PropTransitionData { get; set; }
}
