namespace Pro.Common.FileSystem;

public enum IOResult
{
	Unknown = -1,
	Success,
	TimedOut,
	NotFound,
	Unauthorized,
	InvalidArgument,
	InvalidOperation,
	Error
}
