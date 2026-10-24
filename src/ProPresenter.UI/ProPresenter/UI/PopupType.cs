using System;

namespace ProPresenter.UI;

[Flags]
public enum PopupType
{
	None = 1,
	ClocksTimers = 2,
	ActionPalette = 4,
	Message = 8,
	NewPresentation = 0x10,
	PCOLive = 0x20,
	Props = 0x40,
	Scheduler = 0x80,
	StageDisplayControl = 0x100,
	QuickEdit = 0x200
}
