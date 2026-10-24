using System;

namespace ProPresenter.DO.Events;

public record LayerStatusRequest(Action<LayerStatus> Callback) : IApplicationEvent
{
	public static void Publish(Action<LayerStatus> callback)
	{
		ApplicationEventPublisher.Publish(new LayerStatusRequest(callback));
	}
}
