using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPCOPlan
{
	[Child]
	[Alias("id", typeof(int), false)]
	public int id { get; set; }

	[Child]
	[Alias("parent_id", typeof(int), false)]
	public int parentId { get; set; }

	[Child]
	[Alias("updated_at", typeof(DateTime), false)]
	[StaticHeader("type", "datetime")]
	public DateTime updatedAt { get; set; }

	[Child]
	[Alias("series_title", typeof(string), false)]
	public string seriesTitle { get; set; }

	[Child]
	[Alias("dates", typeof(string), false)]
	public string dates { get; set; }

	[Collection]
	[Alias("items", typeof(item), false)]
	[StaticHeader("type", "array")]
	public List<item> items { get; set; }
}
