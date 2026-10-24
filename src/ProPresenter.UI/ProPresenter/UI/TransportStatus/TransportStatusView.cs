using System;

namespace ProPresenter.UI.TransportStatus;

[Flags]
public enum TransportStatusView
{
	Unknown = 0,
	Presentation = 1,
	Announcement = 2,
	Audio = 4
}
