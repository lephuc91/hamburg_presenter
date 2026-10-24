using System;
using System.Collections.Generic;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVSongArrangement
{
	[Trait]
	public Color color { get; set; }

	[Trait]
	public string name { get; set; }

	[Trait]
	public Guid uuid { get; set; }

	[Optional]
	[Collection]
	public List<Guid> groupIDs { get; set; }
}
