namespace Pro.Common.Win32;

public struct EXCEPTION_POINTERS
{
	private nint _exceptionRecord;

	private nint _contextRecord;

	public nint ExceptionRecord => _exceptionRecord;

	public nint ContextRecord => _contextRecord;
}
