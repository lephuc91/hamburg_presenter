using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPlaylistDocument
{
	[Trait]
	public int versionNumber { get; set; }

	[Optional]
	[Trait]
	public string os { get; set; }

	[Optional]
	[Trait]
	public string buildNumber { get; set; }

	[Optional]
	[Child]
	public RVPlaylistNode rootNode { get; set; }

	[Optional]
	[Collection]
	public List<RVTag> tags { get; set; }
}
