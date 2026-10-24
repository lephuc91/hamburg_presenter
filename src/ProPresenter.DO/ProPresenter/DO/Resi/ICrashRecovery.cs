using System;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Resi;

public interface ICrashRecovery
{
	Recording.Types.Stream? LastCapture { get; }

	DestinationType LastCaptureDestinationType { get; }

	bool CaptureStopped { get; }

	bool CanStart { get; }

	event System.Action StartCapture;

	void CheckResumeCapture();

	void SaveLastCaptureInfo();

	void RemoveLastCaptureInfo();
}
