using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVDocumentCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Trait]
	public string filePath { get; set; }

	[Trait]
	public Guid selectedArrangementID { get; set; }
}
