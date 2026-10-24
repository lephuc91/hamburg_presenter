namespace Pro.Common.Win32;

public enum PAGE : uint
{
	READ = 2u,
	READWRITE = 4u,
	WRITECOPY = 8u,
	EXECUTE_READ = 0x20u,
	EXECUTE_READWRITE = 0x40u,
	EXECUTE_WRITECOPY = 0x80u
}
