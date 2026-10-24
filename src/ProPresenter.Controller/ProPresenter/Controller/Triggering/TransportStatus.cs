using System;
using System.Collections.Generic;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller.Triggering;

public class TransportStatus : ITransportStatus
{
	private readonly Dictionary<ProLayerIndex, TransportStatusEntry> _statuses = new Dictionary<ProLayerIndex, TransportStatusEntry>();

	public void UpdateTime(ProLayerIndex layer, double elapsed, double remaining)
	{
		TransportStatusEntry status = GetStatus(layer);
		_statuses[layer] = new TransportStatusEntry(status?.Media, status?.PlaybackMarkers ?? Array.Empty<PlaybackMarker>(), status?.IsPlaying ?? false, elapsed, remaining);
	}

	public void UpdateMedia(ProLayerIndex layer, MediaBase? media, IPlaybackMarker[] playbackMarkers, ProResourceState state)
	{
		TransportStatusEntry status = GetStatus(layer);
		_statuses[layer] = new TransportStatusEntry(media ?? status?.Media, playbackMarkers, state == ProResourceState.Activated && (media ?? status?.Media) is ITransportMedia, status?.Elapsed ?? 0.0, status?.Remaining ?? 0.0);
	}

	public TransportStatusEntry? GetStatus(ProLayerIndex layer)
	{
		if (!_statuses.TryGetValue(layer, out TransportStatusEntry value))
		{
			return null;
		}
		return value;
	}

	public void Remove(ProLayerIndex layer)
	{
		_statuses.Remove(layer);
	}
}
