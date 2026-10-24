using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void ProSlideElementTransferFunc(nint requester, float xOffset, float yOffset, int pixelWidth, int pixelHeight, ProSlideElementPixelCopyCallback pixelCopyFunc, int segmentCount, int* segmentSizes, nint pixelCopyUserData);
