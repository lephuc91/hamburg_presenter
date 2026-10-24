using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesMultiScreen
{
	[Collection]
	[Alias("Configurations", typeof(RVMultiScreenConfiguration), false)]
	public List<RVMultiScreenConfiguration>? Configurations { get; internal set; }

	[Child]
	[Alias("IsMultiScreenEnabled", typeof(bool), false)]
	public bool IsMultiScreenEnabled { get; internal set; }

	[Child]
	[Alias("SelectedConfigurationIndex", typeof(int), false)]
	public int SelectedConfigurationIndex { get; internal set; }

	[Child]
	[Alias("SelectedMultiScreenLayout", typeof(string), false)]
	public string? SelectedMultiScreenLayout { get; internal set; }
}
