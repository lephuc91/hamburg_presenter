namespace ProPresenterCore.ProCore.Interop;

public enum ProHTTPResponseStatusCode
{
	Success = 0,
	Malformed = 1,
	NotAuthorized = 2,
	NotFound = 3,
	InternalError = 4,
	NotImplemented = 5,
	MaxValue = int.MaxValue
}
