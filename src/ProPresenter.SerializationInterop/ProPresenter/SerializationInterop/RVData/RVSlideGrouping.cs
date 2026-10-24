using System;
using System.Collections.Generic;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVSlideGrouping
{
	[Trait]
	public Guid uuid { get; set; }

	[Trait]
	public Color color { get; set; }

	[Trait]
	public string name { get; set; }

	[Collection]
	public List<RVDisplaySlide> slides { get; set; }
}
