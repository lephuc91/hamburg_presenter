using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class DualScreenCornerPins
{
	[Child]
	[Alias("LeftScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins? LeftScreen { get; set; }

	[Child]
	[Alias("RightScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins? RightScreen { get; set; }
}
