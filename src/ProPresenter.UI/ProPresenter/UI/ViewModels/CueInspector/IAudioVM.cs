using System.ComponentModel;
using Pro.Common.Time;
using Pro.DO.Audio;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;

namespace ProPresenter.UI.ViewModels.CueInspector;

public interface IAudioVM : INotifyPropertyChanged
{
	MediaCue? ActiveMediaCue { get; set; }

	MediaBase? Media { get; }

	TimeSlice FadeIn { get; set; }

	TimeSlice FadeOut { get; set; }

	AudioMap<MediaChannel, Bus>? AudioMap { get; }

	ChannelSet<MediaChannel>? InputChannelSet { get; }
}
