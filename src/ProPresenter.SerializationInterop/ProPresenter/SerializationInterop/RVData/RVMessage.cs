using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVMessage
{
	[Trait]
	public string title { get; set; }

	[Trait]
	public Guid uuid { get; set; }

	[Trait]
	public bool visibleToNetwork { get; set; }

	[Trait]
	public RVTimeToRemoveType timeToRemove { get; set; }

	[Child]
	[Optional]
	public RVTemplatePath templatePath { get; set; }

	[Collection]
	[Optional]
	[Escaped]
	public List<string> components { get; set; }
}
