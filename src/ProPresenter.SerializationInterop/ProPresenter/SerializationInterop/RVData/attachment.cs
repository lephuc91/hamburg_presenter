using System;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class attachment
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
	[Alias("filename", typeof(string), false)]
	public string filename { get; set; }

	[Child]
	[Optional]
	[Alias("url", typeof(string), false)]
	public string url { get; set; }

	[Child]
	[Alias("needs_update", typeof(int), false)]
	public int needsUpdate { get; set; }
}
