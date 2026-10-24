using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlaylistNode : RVPlaylistNode
{
	[Child]
	public RVPCOPlanCue planCue { get; set; }
}
