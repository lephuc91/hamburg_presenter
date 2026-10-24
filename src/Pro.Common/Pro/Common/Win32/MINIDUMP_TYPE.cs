using System;

namespace Pro.Common.Win32;

[Flags]
public enum MINIDUMP_TYPE
{
	Normal = 0,
	WithDataSegs = 1,
	WithFullMemory = 2,
	WithHandleData = 4,
	FilterMemory = 8,
	ScanMemory = 0x10,
	WithUnloadedModules = 0x20,
	WithIndirectlyReferencedMemory = 0x40,
	FilterModulePaths = 0x80,
	WithProcessThreadData = 0x100,
	WithPrivateReadWriteMemory = 0x200,
	WithoutOptionalData = 0x400,
	WithFullMemoryInfo = 0x800,
	WithThreadInfo = 0x1000,
	WithCodeSegs = 0x2000,
	WithoutAuxiliaryState = 0x4000,
	WithFullAuxiliaryState = 0x8000,
	WithPrivateWriteCopyMemory = 0x10000,
	IgnoreInaccessibleMemory = 0x20000,
	WithTokenInformation = 0x40000,
	WithModuleHeaders = 0x80000,
	FilterTriage = 0x100000,
	ValidTypeFlags = 0x1FFFFF
}
