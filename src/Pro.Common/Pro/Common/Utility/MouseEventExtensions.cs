using System.Windows;
using System.Windows.Input;
using Pro.Common.Mathematics;

namespace Pro.Common.Utility;

public static class MouseEventExtensions
{
	private static readonly Vector2<double> MinimumDragDistance = new Vector2<double>(SystemParameters.MinimumHorizontalDragDistance, SystemParameters.MinimumVerticalDragDistance) * 2.0;

	public static bool CanDrag(this MouseEventArgs e, IInputElement elem, Vector2<double> start)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return CanDrag((Vector2<double>)e.GetPosition(elem), start);
	}

	public static bool CanDrag(Vector2<double> move, Vector2<double> start)
	{
		return !move.IsWithin(start, MinimumDragDistance.X, MinimumDragDistance.Y);
	}
}
