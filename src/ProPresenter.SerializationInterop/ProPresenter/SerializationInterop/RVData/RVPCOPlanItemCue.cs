using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlanItemCue : RVPCOPlanItemCueBase
{
	public override RVPCOItemType PCOItemType => RVPCOItemType.Plan;

	[Child]
	[Optional]
	public RVMediaCue mediaCue { get; set; }

	[Child]
	[Optional]
	public RVDocumentCue documentCue { get; set; }
}
