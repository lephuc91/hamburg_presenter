using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVAnnouncementDocument
{
	[Collection]
	[Alias("Fields", typeof(RVPlaceholder), false)]
	public List<RVPlaceholder>? Fields { get; set; }

	[Collection]
	[Alias("Messages", typeof(RVAnnouncement), false)]
	public List<RVAnnouncement>? Messages { get; set; }
}
