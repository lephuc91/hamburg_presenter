using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProAudioInputStatusChangedCallback(nint audioInputStatus, nint userData);
