using System;

namespace ProPresenter.DO.Resi;

[Flags]
public enum ErrorCode
{
	None = 0,
	CentralStartError = 1,
	FolderStartError = 2,
	UnknownStartError = 4,
	CentralStopError = 8,
	FolderStopError = 0x10,
	UnknownStopError = 0x20,
	DestinationGroupInUse = 0x40,
	NetworkOffline = 0x80,
	Unknown = 0x100,
	DestinationGroupDeleted = 0x200
}
