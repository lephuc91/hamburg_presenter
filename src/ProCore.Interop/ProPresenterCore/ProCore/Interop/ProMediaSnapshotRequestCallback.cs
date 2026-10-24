using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

[SuppressUnmanagedCodeSecurity]
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ProMediaSnapshotRequestCallback(nint generatedBitmapData, int generatedBitmapWidth, int generatedBitmapHeight, nint userData);
