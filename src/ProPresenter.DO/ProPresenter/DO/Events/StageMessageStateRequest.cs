using System;

namespace ProPresenter.DO.Events;

public record StageMessageStateRequest(Action<StageMessageState> Callback) : IApplicationEvent
{
	public static void Publish(Action<StageMessageState> callback)
	{
		ApplicationEventPublisher.Publish(new StageMessageStateRequest(callback));
	}
}
