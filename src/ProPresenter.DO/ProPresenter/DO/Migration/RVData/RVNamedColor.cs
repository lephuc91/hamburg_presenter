using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class RVNamedColor
{
	[Child]
	[Alias("Color", typeof(ScreenColor), false)]
	public ScreenColor? Color { get; set; }

	[Child]
	[Alias("Name", typeof(string), false)]
	public string? Name { get; set; }
}
