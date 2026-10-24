namespace ProPresenter.DO.Events;

public record StageMessageState(bool IsShowing, string Message) : IApplicationEvent
{
	public static void Publish(bool isShowing, string message)
	{
		ApplicationEventPublisher.Publish(new StageMessageState(isShowing, message));
	}
}
