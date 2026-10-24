using System;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;

namespace ProPresenter.ViewModels.TransportStatus;

public interface ITransportMediaProvider
{
	event Action<MediaCue?, MediaAction?, PlaybackMarkerCollection?>? MediaTriggered;
}
