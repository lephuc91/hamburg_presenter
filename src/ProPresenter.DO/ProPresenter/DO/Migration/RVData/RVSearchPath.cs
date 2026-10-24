using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVSearchPath
{
	[Child]
	[Alias("string", typeof(string), false)]
	public string? Path { get; set; }
}
