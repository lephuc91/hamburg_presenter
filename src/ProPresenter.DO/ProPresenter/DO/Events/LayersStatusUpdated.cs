using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Events;

public record LayersStatusUpdated(ProLayerIndex Layer, bool IsActive) : IApplicationEvent
{
	public static void Publish(ProLayerIndex layer, bool isActive)
	{
		ApplicationEventPublisher.Publish(new LayersStatusUpdated(layer, isActive));
	}
}
