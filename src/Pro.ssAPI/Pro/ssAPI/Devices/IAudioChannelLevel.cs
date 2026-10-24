using System.ComponentModel;

namespace Pro.ssAPI.Devices;

public interface IAudioChannelLevel : INotifyPropertyChanged
{
	double RMS { get; }

	double Peak { get; }

	bool Clip { get; }
}
