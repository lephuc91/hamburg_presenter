using System.Windows;
using System.Windows.Media;

namespace Pro.UI.Themes;

public static class Geometry
{
	public static ComponentResourceKey MediaTrackGeometry => new ComponentResourceKey(typeof(Icons), "Geometry_MediaTrackGeometry");

	public static DrawingImage? GetIcon(ComponentResourceKey key)
	{
		return Application.Current?.TryFindResource(key) as DrawingImage;
	}
}
