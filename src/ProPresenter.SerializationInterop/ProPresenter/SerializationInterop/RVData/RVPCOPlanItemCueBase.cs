using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public abstract class RVPCOPlanItemCueBase : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	public abstract RVPCOItemType PCOItemType { get; }

	[Child]
	[Alias("item", typeof(item), true)]
	public item planItem { get; set; }
}
