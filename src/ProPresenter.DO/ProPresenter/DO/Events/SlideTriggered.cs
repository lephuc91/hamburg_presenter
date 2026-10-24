using ProPresenter.DO.Arrangements;

namespace ProPresenter.DO.Events;

public record SlideTriggered(IArrangedCue Slide, OutputDestination Destination, int Index) : IApplicationEvent
{
	public static void Publish(IArrangedCue slide, OutputDestination destination, int index)
	{
		ApplicationEventPublisher.Publish(new SlideTriggered(slide, destination, index));
	}
}
