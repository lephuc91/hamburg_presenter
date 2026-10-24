namespace ProPresenterCore.ProCore.Interop;

public enum ProAudioDeviceType
{
	Unknown = 0,
	AudioUnit = 1,
	WaveOut = 2,
	ASIO = 3,
	SDI = 4,
	NDI = 5,
	AVFoundation = 6,
	AirCast = 7,
	MaxValue = int.MaxValue
}
