using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProResourceStateChangedCallback(nint resourceAddress, ProResourceState resourceState, nint updateInfo, nint callbackUserData);
