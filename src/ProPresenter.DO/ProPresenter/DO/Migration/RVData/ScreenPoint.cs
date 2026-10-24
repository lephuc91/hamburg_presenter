using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class ScreenPoint
{
	[Child]
	[Alias("X", typeof(int), false)]
	public int X { get; set; }

	[Child]
	[Alias("Y", typeof(int), false)]
	public int Y { get; set; }
}
