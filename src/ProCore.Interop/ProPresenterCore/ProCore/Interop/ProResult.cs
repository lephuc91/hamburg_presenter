namespace ProPresenterCore.ProCore.Interop;

public enum ProResult
{
	Success = 0,
	Duplicate = 1,
	NoEffect = 2,
	InvalidArgument = -1,
	OutOfMemory = -2,
	AccessDenied = -3,
	BadData = -4,
	NotFound = -5,
	Timeout = -6,
	InvalidFile = -7,
	WrongThread = -8,
	NoGraphicsDevice = -9,
	InsufficientDiskSpace = -10,
	UnknownError = -1000000000,
	MaxValue = int.MaxValue
}
