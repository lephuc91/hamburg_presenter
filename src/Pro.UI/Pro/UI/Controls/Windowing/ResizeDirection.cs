using System;

namespace Pro.UI.Controls.Windowing;

[Flags]
public enum ResizeDirection
{
	None = 0,
	Left = 1,
	Top = 2,
	Right = 4,
	Bottom = 8,
	TopLeft = 3,
	TopRight = 6,
	Horizontal = 5,
	Vertical = 0xA,
	BottomRight = 0xC,
	BottomLeft = 9,
	All = 0xF
}
