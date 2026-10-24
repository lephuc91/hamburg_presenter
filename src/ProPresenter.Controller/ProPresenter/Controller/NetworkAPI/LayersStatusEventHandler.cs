using System;
using ProPresenter.DO;
using ProPresenter.DO.Events;

namespace ProPresenter.Controller.NetworkAPI;

internal class LayersStatusEventHandler : DebouncedEventSender
{
	private LayerStatus _previous;

	private LayerStatus _current;

	public LayersStatusEventHandler()
	{
		ApplicationEventPublisher.AddHandler(this);
	}

	protected override EventResult OnEventReceived(IApplicationEvent @event)
	{
		EventResult result = EventResult.Continue;
		if (@event is LayersStatusUpdated layersStatusUpdated)
		{
			layersStatusUpdated.Deconstruct(out var Layer, out var IsActive);
			LayerStatus layerStatus = (IsActive ? (_current | Layer.ToLayerStatus()) : (_current & ~Layer.ToLayerStatus()));
			if (_current != layerStatus)
			{
				result = EventResult.Debounce;
			}
			_current = layerStatus;
		}
		else if (@event is LayerStatusRequest layerStatusRequest)
		{
			layerStatusRequest.Deconstruct(out Action<LayerStatus> Callback);
			Callback(_current);
		}
		return result;
	}

	protected override void Publish()
	{
		if (_previous != _current)
		{
			OnSend(StatusHandler.LayerStatusChanged(_current));
		}
		_previous = _current;
	}
}
