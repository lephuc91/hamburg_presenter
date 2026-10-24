using System;
using System.Windows.Input;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas;

public interface IPenTool
{
	Cursor MouseCursor { get; }

	event Action DeactivatePen;

	void MouseDown(Vector2<double> point, MouseButtonEventArgs e);

	void MouseMove(Vector2<double> point, MouseEventArgs e);

	void MouseUp(Vector2<double> point, MouseButtonEventArgs e);
}
