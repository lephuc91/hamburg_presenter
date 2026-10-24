using System.ComponentModel;

namespace ProPresenter.DO.Media;

public enum NativeRotation
{
	[Description("0")]
	RotateStandard,
	[Description("90")]
	Rotate90,
	[Description("180")]
	Rotate180,
	[Description("270")]
	Rotate270
}
