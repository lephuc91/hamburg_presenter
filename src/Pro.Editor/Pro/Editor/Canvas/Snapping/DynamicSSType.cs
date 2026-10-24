using System;

namespace Pro.Editor.Canvas.Snapping;

[Flags]
public enum DynamicSSType
{
	None = 0,
	CenterSpacing = 1,
	EqualSpacing = 2,
	EqualSizing = 4,
	All = 7
}
