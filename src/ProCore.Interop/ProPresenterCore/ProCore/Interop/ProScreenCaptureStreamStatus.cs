namespace ProPresenterCore.ProCore.Interop;

public enum ProScreenCaptureStreamStatus
{
	Inactive = 0,
	Connecting = 1,
	Connected = 2,
	ConnectionFailed = 3,
	Reconnecting = 4,
	ConnectionDropped = 5,
	MaxValue = int.MaxValue
}
