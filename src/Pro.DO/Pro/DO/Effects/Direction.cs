using System;

namespace Pro.DO.Effects;

[Flags]
public enum Direction
{
	None = 0,
	TopLeft = 1,
	Top = 2,
	TopRight = 4,
	Left = 8,
	Center = 0x10,
	Right = 0x20,
	BottomLeft = 0x40,
	Bottom = 0x80,
	BottomRight = 0x100
}
