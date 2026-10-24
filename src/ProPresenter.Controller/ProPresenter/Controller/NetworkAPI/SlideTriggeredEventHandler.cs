using Pro.Common.FeatureFlag;
using ProPresenter.DO.Events;
using ProPresenter.DO.Presentation;

namespace ProPresenter.Controller.NetworkAPI;

internal class SlideTriggeredEventHandler : DebouncedEventSender
{
	private readonly IAPIv1Service _service;

	private APIv1Service.SlideIndex? _oldPresentationSlide;

	private APIv1Service.SlideIndex? _oldAnnouncementsSlide;

	private IPresentation? _oldPresentation;

	private IPresentation? _oldAnnouncements;

	public SlideTriggeredEventHandler(IAPIv1Service service)
	{
		_service = service;
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override bool CanHandle(IApplicationEvent @event)
	{
		if (!(@event is SlideTriggered))
		{
			return @event is SlideCleared;
		}
		return true;
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		return EventResult.Debounce;
	}

	protected override void Publish()
	{
		if (!_service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation))
		{
			APIv1Service.SlideIndex activePresentationSlideInfo = _service.ActivePresentationSlideInfo;
			if (_oldPresentationSlide != activePresentationSlideInfo)
			{
				OnSend(PresentationHandler.UpdateSlideIndex(_service, activePresentationSlideInfo));
				_oldPresentationSlide = activePresentationSlideInfo;
			}
		}
		APIv1Service.SlideIndex activeAnnouncementsSlideInfo = _service.ActiveAnnouncementsSlideInfo;
		if (_oldAnnouncementsSlide != activeAnnouncementsSlideInfo)
		{
			OnSend(PresentationHandler.UpdateAnnouncementSlideIndex(_service, activeAnnouncementsSlideInfo));
			_oldAnnouncementsSlide = activeAnnouncementsSlideInfo;
		}
		if (!_service.Dependencies.FlagService.IsFlagEnabled(Flag.CoreNetworkapiPresentation))
		{
			IPresentation presentation = _service.ActivePresentationSlideInfo?.Slide.Source.ParentPresentation;
			if (_oldPresentation != presentation)
			{
				OnSend(PresentationHandler.UpdateCurrentPresentation(_service, presentation));
				_oldPresentation = presentation;
			}
		}
		IPresentation presentation2 = _service.ActiveAnnouncementsSlideInfo?.Slide.Source.ParentPresentation;
		if (_oldAnnouncements != presentation2)
		{
			OnSend(PresentationHandler.UpdateActiveAnnouncement(_service, presentation2));
			_oldAnnouncements = presentation2;
		}
	}
}
