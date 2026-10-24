using System;

namespace Pro.Common.Win32;

[Flags]
public enum GR
{
	GDIOBJECTS = 0,
	GDIOBJECTS_PEAK = 2,
	USEROBJECTS = 1,
	USEROBJECTS_PEAK = 4
}
