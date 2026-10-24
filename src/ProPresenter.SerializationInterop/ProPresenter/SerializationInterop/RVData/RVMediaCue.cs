using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVMediaCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Trait]
	public RVMediaCueBehaviorType behavior { get; set; }

	[Trait]
	public Guid nextCueUUID { get; set; }

	[Trait]
	public RVAlignment alignment { get; set; }

	[Trait]
	public DateTime? dateAdded { get; set; }

	[Trait]
	public string tags { get; set; }

	[Child]
	[Optional]
	[KnownTypes(typeof(RVVideoElement), new Type[] { })]
	public RVImageElement element { get; set; }

	[Child]
	[Optional]
	public RVTransition selectedTransition { get; set; }
}
