using System.Runtime.InteropServices;
using System.Security;

namespace ProPresenterCore.ProCore.Interop;

public class ProAnalytics
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct __Internal
	{
		[DllImport("ProCore.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "proAnalyticRecord")]
		[SuppressUnmanagedCodeSecurity]
		internal static extern void AnalyticRecord(nint serializedEvent, int serializedEventSize);
	}

	public static void AnalyticRecord(nint serializedEvent, int serializedEventSize)
	{
		__Internal.AnalyticRecord(serializedEvent, serializedEventSize);
	}
}
