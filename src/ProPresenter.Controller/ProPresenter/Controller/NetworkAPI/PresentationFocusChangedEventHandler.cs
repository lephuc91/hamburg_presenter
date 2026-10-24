using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

internal class PresentationFocusChangedEventHandler : DebouncedEventSender
{
	private readonly IAPIv1Service _service;

	public PresentationFocusChangedEventHandler(IAPIv1Service service)
	{
		_service = service;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override bool CanHandle(IApplicationEvent @event)
	{
		return @event is CueFocusChange;
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		return EventResult.Debounce;
	}

	protected override void Publish()
	{
		OnSend(PresentationHandler.UpdateFocusedPresentation(_service));
	}
}
