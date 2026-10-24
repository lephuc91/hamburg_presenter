using System;
using System.Collections.Generic;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class item
{
	[Child]
	[Alias("id", typeof(int), false)]
	public int id { get; set; }

	[Child]
	[Alias("parent_id", typeof(int), false)]
	public int parentID { get; set; }

	[Child]
	[Alias("updated_at", typeof(DateTime), false)]
	[StaticHeader("type", "datetime")]
	public DateTime updatedAt { get; set; }

	[Child]
	[Alias("title", typeof(string), false)]
	public string title { get; set; }

	[Child]
	[Alias("itemType", typeof(RVDataPCOItemType), false)]
	public RVDataPCOItemType itemType { get; set; }

	[Child]
	[Alias("service_id", typeof(int), false)]
	public int serviceID { get; set; }

	[Collection]
	[Alias("attachments", typeof(attachment), false)]
	[StaticHeader("type", "array")]
	public List<attachment> attachments { get; set; }
}
