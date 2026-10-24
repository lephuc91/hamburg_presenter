using System.Runtime.InteropServices;

namespace Pro.Common.Win32;

[UnmanagedFunctionPointer(CallingConvention.Winapi)]
public delegate nint HOOKPROC(int code, nint wParam, nint lParam);
