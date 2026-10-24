using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public interface IVirtualizableControl
{
	bool InView { get; set; }

	Rect<double> Viewport { get; set; }
}
