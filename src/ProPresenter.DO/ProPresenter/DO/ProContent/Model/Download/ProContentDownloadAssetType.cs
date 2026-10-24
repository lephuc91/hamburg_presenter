using System;

namespace ProPresenter.DO.ProContent.Model.Download;

[Flags]
public enum ProContentDownloadAssetType
{
	Loop = 1,
	Countdown = 2,
	Image = 4,
	MotionTitle = 8,
	Pack = 0x10,
	Theme = 0x20
}
