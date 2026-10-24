using System;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVMultiScreenConfiguration
{
	[Child]
	[Alias("CenterScreenTemplateId", typeof(Guid), false)]
	public Guid CenterScreenTemplateId { get; internal set; }

	[Child]
	[Alias("ID", typeof(Guid), false)]
	public Guid ID { get; internal set; }

	[Child]
	[Alias("IsBackgroundTiled", typeof(bool), false)]
	public bool IsBackgroundTiled { get; internal set; }

	[Child]
	[Alias("LeftScreenTemplateId", typeof(Guid), false)]
	public Guid LeftScreenTemplateId { get; internal set; }

	[Child]
	[Alias("LiveVideoScreenPosition", typeof(string), false)]
	public string? LiveVideoScreenPosition { get; internal set; }

	[Child]
	[Alias("Name", typeof(string), false)]
	public string? Name { get; internal set; }

	[Child]
	[Alias("PropScreenPosition", typeof(string), false)]
	public string? PropScreenPosition { get; internal set; }

	[Child]
	[Alias("RightScreenTemplateId", typeof(Guid), false)]
	public Guid RightScreenTemplateId { get; internal set; }

	[Child]
	[Alias("SlideScreenPosition", typeof(string), false)]
	public string? SlideScreenPosition { get; internal set; }

	[Child]
	[Alias("VideoImageScreenPosition", typeof(string), false)]
	public string? VideoImageScreenPosition { get; internal set; }
}
