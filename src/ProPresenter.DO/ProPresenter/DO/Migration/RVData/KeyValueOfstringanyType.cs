using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class KeyValueOfstringanyType
{
	[Child]
	[Alias("Key", typeof(string), false)]
	public string? Key { get; set; }

	[Child]
	[Alias("Value", typeof(string), false)]
	public string? Value { get; set; }
}
