using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public delegate EXCEPTION_MODE LPTOP_LEVEL_EXCEPTION_FILTER(nint exceptionInfo);
