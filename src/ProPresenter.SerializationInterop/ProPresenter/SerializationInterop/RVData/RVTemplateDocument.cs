using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVTemplateDocument
{
	[Trait]
	public int versionNumber { get; set; }

	[Trait]
	public RVPresentationType docType { get; set; }

	[Trait]
	public int width { get; set; }

	[Trait]
	public int height { get; set; }

	[Trait]
	[Optional]
	public string os { get; set; }

	[Optional]
	[Trait]
	public string buildNumber { get; set; }

	[Optional]
	[Collection]
	public List<RVDisplaySlide> slides { get; set; }
}
