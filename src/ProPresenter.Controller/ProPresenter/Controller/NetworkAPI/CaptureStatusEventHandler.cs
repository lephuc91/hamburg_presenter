using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

internal class CaptureStatusEventHandler : EventSender, IApplicationEventHandler
{
	private CaptureStatusUpdated? _previous;

	public CaptureStatusEventHandler()
	{
		ApplicationEventPublisher.AddHandler(this);
	}

	public void Handle(IApplicationEvent @event)
	{
		if (@event is CaptureStatusUpdated captureStatusUpdated && _previous != captureStatusUpdated)
		{
			var (state2, captureTime, status_text) = captureStatusUpdated;
			OnSend(CaptureHandler.GetStatus(state2, captureTime, status_text));
			_previous = captureStatusUpdated;
		}
	}
}
