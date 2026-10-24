using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProMediaMetadataRequestCallback(nint serializedMetadataResponse, int serializedMetadataResponseSize, nint generatedBitmapData, nint userData);
