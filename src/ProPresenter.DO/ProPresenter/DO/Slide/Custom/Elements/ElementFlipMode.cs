using System;

namespace ProPresenter.DO.Slide.Custom.Elements;

[Flags]
public enum ElementFlipMode
{
	None = 0,
	Horizontal = 1,
	Vertical = 4,
	Both = 5
}
