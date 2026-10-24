using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Components.Reversibility;
using Pro.DO.Storage;
using Pro.UI.Components;
using ProPresenter.DO.Analytics.Events.Capture;
using ProPresenter.DO.Capture;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Resi;

namespace ProPresenter.UI.ViewModels;

public interface ICaptureVM : INotifyPropertyChanged
{
	IDiskCaptureVM DiskVM { get; }

	IRtmpCaptureVM RtmpVM { get; }

	IResiCaptureVM ResiVM { get; }

	State State { get; }

	SolidColorBrush StateColor { get; }

	StreamStatus StreamStatus { get; }

	string CaptureStreamStatusText { get; }

	string ResiStreamStatusText { get; }

	DiskStatus DiskStatus { get; }

	bool IsLive { get; }

	string CaptureTimeLapse { get; }

	int DroppedFrames { get; }

	double PercentDroppedFrames { get; }

	double BitRate { get; }

	Guid ScreenID { get; }

	string ScreenName { get; }

	AudienceScreenArrangementCollection AudienceScreens { get; }

	StageScreenArrangementCollection StageScreens { get; }

	DestinationType Destination { get; }

	IEnumerable<DestinationType> Destinations { get; }

	RelativePath CaptureFile { get; }

	string StartStopButtonLabel { get; }

	ResiStreamStatus ResiStreamStatus { get; }

	UploadHealth UploadHealth { get; }

	ErrorCode ErrorCodes { get; }

	bool SelectedScreenSupportsHdr { get; }

	ICommand<ScreenArrangementBase> SelectScreenCommand { get; }

	ICommand StartCaptureCommand { get; }

	ICommand StopCaptureCommand { get; }

	ICommand<CaptureShownSource> OpenCaptureSettingsCommand { get; }

	ICommand<DestinationType> ChangeDestinationCommand { get; }

	ICommand GotFocusCommand { get; }

	event Action<UndoStack?>? StackChanged;

	void CheckResumeCapture();

	void RemoveLastCaptureInfo();
}
