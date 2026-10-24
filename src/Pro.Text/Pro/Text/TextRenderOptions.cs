using System;

namespace Pro.Text;

[Flags]
public enum TextRenderOptions
{
	None = 0,
	UnderlineOnly = 1,
	NoUnderline = 2,
	MaskOnly = 4,
	NoMask = 8
}
