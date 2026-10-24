using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProWSDisconnectedCallback(ulong clientHandle, ProNetworkEndpointType endpoint, nint userData, nint clientUserData);
