using System.ComponentModel;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public interface IVideoInputDevice : IDevice, INotifyPropertyChanged
{
	VideoModeCollection? Modes { get; }

	IVideoMode? CurrentMode { get; }

	bool IsActive { get; }

	bool HasSignal { get; }

	bool SupportsAutoModeSelection { get; }

	bool SupportsAudio { get; }

	int AudioChannelCount { get; }

	IImmutableObservableCollection<IAudioChannelLevel>? ChannelLevels { get; }

	bool SupportsAlphaChannel { get; }

	bool ShouldAutoMap { get; set; }

	VideoDeviceType Type { get; }

	ColorFormat ColorFormat { get; }
}
