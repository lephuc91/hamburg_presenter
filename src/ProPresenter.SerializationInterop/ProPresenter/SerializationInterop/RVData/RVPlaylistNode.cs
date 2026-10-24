using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPlaylistNode : IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Node;

	[Trait]
	public Guid UUID { get; set; }

	[Trait]
	public string displayName { get; set; }

	[Trait]
	public DateTime? modifiedDate { get; set; }

	[Trait]
	public RVPlaylistType type { get; set; }

	[Trait]
	public bool isExpanded { get; set; }

	[Trait]
	public string smartDirectoryURL { get; set; }

	[Trait]
	public RVHotFolderType hotFolderType { get; set; }

	[Collection]
	[Optional]
	public List<RVEvent> events { get; set; }

	[Collection]
	[Optional]
	[KnownTypes(typeof(RVPlaylistNode), new Type[]
	{
		typeof(RVPCOPlaylistNode),
		typeof(RVDocumentCue),
		typeof(RVHeaderCue),
		typeof(RVMediaCue),
		typeof(RVAudioCue),
		typeof(RVWebBrowserCue),
		typeof(RVPCOPlanItemCue),
		typeof(RVPCOPlanSongItemCue),
		typeof(RVPCOPlanMediaItemCue)
	})]
	public List<IPlaylistChild> children { get; set; }
}
