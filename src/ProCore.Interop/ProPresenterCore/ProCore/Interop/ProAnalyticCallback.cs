using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProAnalyticCallback([MarshalAs(UnmanagedType.LPUTF8Str)] string eventName, nint properties, int propertyCount, nint userData);
