using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void ProScreenCaptureCodecCallback(ProScreenCaptureCodec* availableCodecs, int count, nint userData);
