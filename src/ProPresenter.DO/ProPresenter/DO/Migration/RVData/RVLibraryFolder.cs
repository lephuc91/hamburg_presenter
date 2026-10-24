using System;
using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVLibraryFolder
{
	[Child]
	[Alias("ID", typeof(Guid), false)]
	public Guid ID { get; set; }

	[Child]
	[Alias("Location", typeof(string), false)]
	public string Location { get; set; } = string.Empty;

	[Child]
	[Alias("Name", typeof(string), false)]
	public string Name { get; set; } = string.Empty;
}
