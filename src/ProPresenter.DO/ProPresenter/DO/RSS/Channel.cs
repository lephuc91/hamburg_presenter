using System.Collections.Generic;
using System.Diagnostics;
using Pro.Serialization.Control;

namespace ProPresenter.DO.RSS;

[DebuggerDisplay("{Title,nq}")]
public class Channel
{
	[Child]
	[Alias("title", typeof(string), false)]
	public string? Title { get; set; }

	[Child]
	[Alias("description", typeof(string), false)]
	public string? Description { get; set; }

	[MixedCollection]
	public List<Item>? Items { get; set; }
}
