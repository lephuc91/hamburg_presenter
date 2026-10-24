using System.Diagnostics;
using Pro.Serialization.Control;

namespace ProPresenter.DO.RSS;

[DebuggerDisplay("{Title,nq}")]
public class Item
{
	[Child]
	[Alias("title", typeof(string), false)]
	public string Title { get; set; } = string.Empty;

	[Child]
	[Alias("description", typeof(string), false)]
	public string Description { get; set; } = string.Empty;
}
