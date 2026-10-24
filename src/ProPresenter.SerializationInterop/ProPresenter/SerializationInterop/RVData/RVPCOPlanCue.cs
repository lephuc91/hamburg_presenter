using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlanCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Trait]
	public bool isOffline { get; set; }

	[Trait]
	public DateTime? lastUpdated { get; set; }

	[Collection]
	[Optional]
	[KnownTypes(typeof(RVPCOPlanHeaderItemCue), new Type[]
	{
		typeof(RVPCOPlanSongItemCue),
		typeof(RVPCOPlanMediaItemCue),
		typeof(RVPCOPlanItemCue)
	})]
	public List<IPlaylistChild> itemCues { get; set; }

	[Child]
	[Alias("plan", typeof(RVPCOPlan), true)]
	public RVPCOPlan plan { get; set; }
}
