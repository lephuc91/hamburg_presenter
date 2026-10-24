using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate uint ProWSConnectedCallback(ulong clientHandle, nint userData, ProNetworkEndpointType endpoint, void** clientUserData);
