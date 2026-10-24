using Pro.Common.Time;
using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

internal class VideoCountdownEventHandler : EventSender, IApplicationEventHandler
{
	private TimeSlice _previousTime;

	public VideoCountdownEventHandler()
	{
		ApplicationEventPublisher.AddHandler(this);
	}

	public void Handle(IApplicationEvent @event)
	{
		if (@event is VideoCountdownTimeChanged videoCountdownTimeChanged && _previousTime.Seconds != videoCountdownTimeChanged.Time.Seconds)
		{
			OnSend(TimerHandler.VideoCountdown(_previousTime = videoCountdownTimeChanged.Time));
		}
	}
}
