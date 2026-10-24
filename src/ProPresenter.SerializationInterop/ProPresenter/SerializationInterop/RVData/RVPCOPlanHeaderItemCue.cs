using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlanHeaderItemCue : RVPCOPlanItemCueBase
{
	public override RVPCOItemType PCOItemType => RVPCOItemType.Header;

	[Child]
	public RVHeaderCue headerCue { get; set; }
}
