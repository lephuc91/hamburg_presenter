using System;

namespace Pro.Common.Time;

[Flags]
public enum TimeComponents
{
	None = 0,
	Hours = 1,
	Minutes = 2,
	Seconds = 4,
	Milliseconds = 8,
	All = 0xF
}
