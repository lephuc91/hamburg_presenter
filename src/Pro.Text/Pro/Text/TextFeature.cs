using System;

namespace Pro.Text;

[Flags]
internal enum TextFeature
{
	None = 0,
	Kerning = 1,
	SmallCaps = 2,
	TabularNumbers = 4,
	NoLigatures = 8
}
