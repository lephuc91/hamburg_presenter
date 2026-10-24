using Pro.DO.Storage;
using ProPresenter.DO.Events;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.NetworkAPI;

internal class ChordChartEventHandler : DebouncedEventSender<SlideTriggered>
{
	private RelativePath? _previousChordChart;

	private RelativePath? _currentChordChart;

	public ChordChartEventHandler()
	{
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(SlideTriggered @event)
	{
		_currentChordChart = (@event.Slide?.Source.SlideAction?.Slide as CustomSlide)?.ChordChart;
		if (!(_currentChordChart == _previousChordChart))
		{
			return EventResult.Debounce;
		}
		return EventResult.Continue;
	}

	protected override void Publish()
	{
		if (_currentChordChart != _previousChordChart)
		{
			OnSend(PresentationHandler.UpdateChordChart());
		}
		_previousChordChart = _currentChordChart;
	}
}
