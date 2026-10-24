using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate uint ProWSMessageCallback(ulong clientHandle, ProNetworkEndpointType endpoint, nint userData, nint clientUserData, nint messageData, nint responseData);
