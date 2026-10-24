using System.ComponentModel;
using Pro.Common.Collections;

namespace Pro.ssAPI.Devices;

public interface IAudioInputDevice : IAudioDevice, IDevice, INotifyPropertyChanged
{
	ImmutableObservableCollection<IAudioChannelLevel> ChannelLevels { get; }
}
