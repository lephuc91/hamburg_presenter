using System;

namespace ProPresenter.DO.Settings;

[Flags]
public enum FirstSyncActionType
{
	Invalid = 0,
	PC = 1,
	Cloud = 2,
	Merge = 3
}
