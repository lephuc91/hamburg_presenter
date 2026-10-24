using System;

namespace ProPresenter.SendData.Props;

public interface IPropAutoClearService
{
	IObservable<PropStatus> WhenPropStatusChangedSubject { get; }

	void Play(Guid propId);

	void Pause(Guid propId);

	void GetStatus(Guid propId);
}
