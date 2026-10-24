using System;

namespace ProPresenterCore.ProCore.Interop;

[Flags]
public enum ProResiErrorCode : uint
{
	None = 0u,
	CentralStartError = 1u,
	FolderStartError = 2u,
	UnknownStartError = 4u,
	CentralStopError = 8u,
	FolderStopError = 0x10u,
	UnknownStopError = 0x20u,
	DestinationGroupInUse = 0x40u,
	NetworkOffline = 0x80u,
	Unknown = 0x100u,
	DestinationGroupDeleted = 0x200u,
	MaxValue = 0x7FFFFFFFu
}
