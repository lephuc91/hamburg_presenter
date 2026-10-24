namespace Pro.Common.Win32;

public enum EXCEPTION_MODE : uint
{
	CONTINUE_SEARCH = 0u,
	EXECUTE_HANDLER = 1u,
	CONTINUE_EXECUTION = uint.MaxValue
}
