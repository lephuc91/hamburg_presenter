using System;

namespace Pro.Editor.Canvas.Transforming;

[Flags]
public enum HandleLocation : uint
{
	None = 0u,
	TopLeft = 1u,
	TopCenter = 2u,
	TopRight = 4u,
	RightCenter = 8u,
	BottomRight = 0x10u,
	BottomCenter = 0x20u,
	BottomLeft = 0x40u,
	LeftCenter = 0x80u,
	All = 0xFFu
}
