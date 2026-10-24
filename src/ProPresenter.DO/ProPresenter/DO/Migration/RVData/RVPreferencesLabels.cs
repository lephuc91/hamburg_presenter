using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVPreferencesLabels
{
	[Collection]
	[Alias("ColorPallette", typeof(RVNamedColor), false)]
	public List<RVNamedColor>? ColorPallette { get; internal set; }

	[Child]
	[Alias("GroupChangedID", typeof(Guid), false)]
	public Guid GroupChangedID { get; internal set; }

	[Child]
	[Alias("GroupHotKeyChanged", typeof(string), false)]
	public string? GroupHotKeyChanged { get; internal set; }

	[Collection]
	[Alias("GroupLabels", typeof(RVColoredLabel), false)]
	public List<RVColoredLabel>? GroupLabels { get; internal set; }

	[Collection]
	[Alias("SlideLabels", typeof(RVColoredLabel), false)]
	public List<RVColoredLabel>? SlideLabels { get; internal set; }
}
