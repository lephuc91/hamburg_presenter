using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProMessageCallback(ProMessageType messageType, [MarshalAs(UnmanagedType.LPUTF8Str)] string message, nint userData);
