using System;

namespace ProPresenter.DO.Slide.Custom.Elements;

[Flags]
public enum AdditionalInfo : uint
{
	None = 0u,
	Template = 1u,
	Text = 2u,
	Ticker = 4u
}
