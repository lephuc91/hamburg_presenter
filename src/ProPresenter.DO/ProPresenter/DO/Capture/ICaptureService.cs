using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using Pro.Common.Time;
using Pro.DO.Storage;
using ProPresenter.DO.OutputConfiguration;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Capture;

public interface ICaptureService : INotifyPropertyChanged
{
	CaptureStatus CaptureStatus { get; }

	AudienceScreenArrangementCollection AudienceScreens { get; }

	StageScreenArrangementCollection StageScreens { get; }

	IStream? Stream { get; }

	ICaptureSettingsDocument CaptureSettings { get; }

	IDiskDestination? DiskDestination { get; }

	IRtmpDestination? RTMPDestination { get; }

	IResiDestination? ResiDestination { get; }

	string CaptureTimeLapse { get; }

	bool IsLive { get; }

	State State { get; }

	SolidColorBrush StateColor { get; }

	string StreamStatusText { get; }

	string ResiStreamStatusText { get; }

	string StatusText { get; }

	StreamStatus StreamStatus { get; }

	int DroppedFrames { get; }

	double PercentDroppedFrames { get; }

	double BitRate { get; }

	DiskStatus DiskStatus { get; }

	RelativePath CaptureFile { get; set; }

	string StartStopButtonLabel { get; }

	event Action? StreamPropertyChanged;

	event EventHandler<ScreenCaptureStatusEventArgs>? ScreenCaptureStatusChanged;

	event Action<(TimeSlice? elapsedTime, string statusText, Color statusColor)>? CaptureInformationUpdated;

	IEnumerable<Codec> GetAvailableCodecs(DestinationType destination);

	bool CanStartCapture();

	bool CanStopCapture();

	void StartScreenCapture();

	void StopScreenCapture();

	void StopLocalCapture();

	bool IsResiBusy();

	void RemoveLastCaptureInfo();

	void CheckResumeCapture();
}
