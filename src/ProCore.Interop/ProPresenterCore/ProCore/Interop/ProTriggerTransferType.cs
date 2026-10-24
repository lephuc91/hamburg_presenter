namespace ProPresenterCore.ProCore.Interop;

public enum ProTriggerTransferType
{
	ClientImage = 0,
	SlideElement = 1,
	MessageSlide = 2,
	NextCue = 3,
	RemoteStageSlideData = 4,
	AltSlide = 5,
	CCLISlide = 6,
	Timer = 7,
	PlaylistCue = 8,
	NewAction = 9,
	StartExternalMonitor = 10,
	StopExternalMonitor = 11,
	GetNewContext = 12,
	GetNetworkTriggerData = 13,
	MaxValue = int.MaxValue
}
