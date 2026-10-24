namespace Pro.Common.Win32;

public enum CFS : uint
{
	DEFAULT = 0u,
	RECT = 1u,
	POINT = 2u,
	FORCEPOSITION = 0x20u,
	CANDIDATEPOS = 0x40u,
	EXCLUDE = 0x80u
}
