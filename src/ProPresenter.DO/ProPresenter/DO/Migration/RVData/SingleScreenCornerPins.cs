using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class SingleScreenCornerPins
{
	[Child]
	[Alias("SingleScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins SingleScreen { get; set; } = new ScreenCornerPins();
}
