using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlanSongItemCue : RVPCOPlanItemCueBase
{
	public override RVPCOItemType PCOItemType => RVPCOItemType.Song;

	[Child]
	[Optional]
	public RVDocumentCue documentCue { get; set; }
}
