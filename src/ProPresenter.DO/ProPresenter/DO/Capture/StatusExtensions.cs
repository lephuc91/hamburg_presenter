using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

public static class StatusExtensions
{
	public static StreamStatus ToStatus(this ProScreenCaptureStreamStatus status)
	{
		return status switch
		{
			ProScreenCaptureStreamStatus.Inactive => StreamStatus.Inactive, 
			ProScreenCaptureStreamStatus.Connecting => StreamStatus.Connecting, 
			ProScreenCaptureStreamStatus.Connected => StreamStatus.Connected, 
			ProScreenCaptureStreamStatus.Reconnecting => StreamStatus.Reconnecting, 
			ProScreenCaptureStreamStatus.ConnectionDropped => StreamStatus.ConnectionDropped, 
			_ => StreamStatus.ConnectionFailed, 
		};
	}
}
