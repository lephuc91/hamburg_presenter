using Pro.Common.Mathematics;
using Pro.Common.Win32;

namespace Pro.UI.Controls.Windowing;

public interface INonClientSpace
{
	HT DoHitTest(Vector2<double> point);
}
