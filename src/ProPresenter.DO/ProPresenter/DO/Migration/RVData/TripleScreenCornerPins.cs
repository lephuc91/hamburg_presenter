using Pro.Serialization.Control;

namespace ProPresenter.DO.Migration.RVData;

public class TripleScreenCornerPins
{
	[Child]
	[Alias("LeftScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins? LeftScreen { get; set; }

	[Child]
	[Alias("CenterScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins? CenterScreen { get; set; }

	[Child]
	[Alias("RightScreen", typeof(ScreenCornerPins), false)]
	public ScreenCornerPins? RightScreen { get; set; }
}
