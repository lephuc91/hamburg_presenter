using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProSlideElementPixelCopyCallback(nint pixelCopyUserData, int pixelWidth, int pixelHeight, int pixelStride, int scrollingSegmentIndex, nint pixels);
