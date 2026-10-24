using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlanMediaItemCue : RVPCOPlanItemCueBase
{
	public override RVPCOItemType PCOItemType => RVPCOItemType.Media;

	[Child]
	[Optional]
	public RVMediaCue mediaCue { get; set; }

	[Child]
	[Optional]
	public RVDocumentCue documentCue { get; set; }
}
