using ProPresenter.DO.Media;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.DO.Events;

public record MediaUpdated(MediaBase? Media, ProLayerIndex LayerIndex, bool IsPlaying) : IApplicationEvent
{
	public static void Publish(MediaBase? media, ProLayerIndex layerIndex, bool isPlaying)
	{
		ApplicationEventPublisher.Publish(new MediaUpdated(media, layerIndex, isPlaying));
	}
}
