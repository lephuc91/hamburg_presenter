using System;

namespace ProPresenterCore.ProCore.Interop;

public class ScreenCaptureStatusEventArgs : EventArgs
{
	public ProScreenCaptureStatus ScreenCaptureStatus { get; }

	public ScreenCaptureStatusEventArgs(ProScreenCaptureStatus screenCaptureStatus)
	{
		ScreenCaptureStatus = screenCaptureStatus;
	}
}
