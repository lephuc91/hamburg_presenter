using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate uint ProRequestCueDataCallback(ProDataRequestSource source, ProDataRequestIdentifierType type, [MarshalAs(UnmanagedType.LPUTF8Str)] string identifier, nint data);
