using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate uint ProSelectItemCallback(ProDataRequestSource source, ProDataRequestIdentifierType type, [MarshalAs(UnmanagedType.LPUTF8Str)] string identifier);
