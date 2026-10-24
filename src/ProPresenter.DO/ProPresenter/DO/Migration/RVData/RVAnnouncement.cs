using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVAnnouncement
{
	[Child]
	[Alias("Duration", typeof(string), false)]
	public string? Duration { get; set; }

	[Child]
	[Alias("MessageBody", typeof(string), false)]
	public string? MessageBody { get; set; }

	[Child]
	[Alias("MessageId", typeof(Guid), false)]
	public Guid MessageId { get; set; }

	[Child]
	[Alias("MessageTitle", typeof(string), false)]
	public string? MessageTitle { get; set; }

	[Child]
	[Alias("VisibleOnNetwork", typeof(bool), false)]
	public bool VisibleOnNetwork { get; set; }

	[Collection]
	[Alias("Placeholders", typeof(RVPlaceholder), false)]
	public List<RVPlaceholder>? Placeholders { get; set; }

	[Child]
	[Alias("MessageTemplate", typeof(RVMessageTemplate), false)]
	public RVMessageTemplate? MessageTemplate { get; set; }
}
