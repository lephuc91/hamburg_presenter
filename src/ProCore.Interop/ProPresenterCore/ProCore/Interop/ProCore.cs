using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace ProPresenterCore.ProCore.Interop;

public class ProCore
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct __Internal
	{
		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proDataTransferAlloc")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern nint DataTransferAlloc(uint size);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proInitializeGPU")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void InitializeGPU(nint appName);

		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proStackWalkWin")]
		[SuppressUnmanagedCodeSecurity]
		internal unsafe static extern void StackWalkWin(nint context, char* buffer, int bufferSize);
	}

	public unsafe static void InitializeGPU(string appName)
	{
		fixed (byte* bytes = Encoding.UTF8.GetBytes(appName))
		{
			__Internal.InitializeGPU(new IntPtr(bytes));
		}
	}

	public static nint DataTransferAlloc(uint size)
	{
		return __Internal.DataTransferAlloc(size);
	}

	public static void InitializeGPU(nint appName)
	{
		__Internal.InitializeGPU(appName);
	}

	public unsafe static void StackWalkWin(nint context, char* buffer, int bufferSize)
	{
		__Internal.StackWalkWin(context, buffer, bufferSize);
	}
}
