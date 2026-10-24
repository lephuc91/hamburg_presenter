using System;
using Google.Protobuf;

namespace ProPresenterCore.ProCore.Interop;

public class ProAnalyticsInstance
{
	public static Action<Exception>? ExceptionHandler { get; set; }

	public static AnalyticsCallbackDelegate? AnalyticsHandler { get; set; }

	public unsafe static void SendEvent(IMessage proto)
	{
		try
		{
			if (proto == null)
			{
				return;
			}
			byte[] array = proto.ToByteArray();
			fixed (byte* value = array)
			{
				ProAnalytics.AnalyticRecord(new IntPtr(value), array.Length);
			}
		}
		catch (Exception obj)
		{
			ExceptionHandler?.Invoke(obj);
		}
	}
}
