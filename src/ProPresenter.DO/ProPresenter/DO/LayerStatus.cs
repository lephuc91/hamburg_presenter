using System;

namespace ProPresenter.DO;

[Flags]
public enum LayerStatus
{
	None = 0,
	VideoInput = 1,
	Slide = 2,
	Media = 4,
	Announcements = 8,
	Prop = 0x10,
	Messages = 0x20,
	Audio = 0x40
}
