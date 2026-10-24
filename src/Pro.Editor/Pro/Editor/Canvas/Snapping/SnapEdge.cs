using System;

namespace Pro.Editor.Canvas.Snapping;

[Flags]
public enum SnapEdge
{
	None = 0,
	Near = 1,
	Center = 2,
	Far = 4,
	All = 7
}
