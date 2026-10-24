using System;
using ProPresenter.Controller;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.UI.TransportStatus;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.TransportStatus;

public class TransportMediaProvider : ITransportMediaProvider
{
	private readonly TransportStatusView _view;

	public event Action<MediaCue?, MediaAction?, PlaybackMarkerCollection?>? MediaTriggered;

	public TransportMediaProvider(ICoreManager manager, TransportStatusView view)
	{
		_view = view;
		manager.MediaTriggered += CoreManager_MediaTriggered;
	}

	private void CoreManager_MediaTriggered(MediaTriggeredParameters parameters)
	{
		ProLayerIndex layer = parameters.Layer;
		ProResourceState resourceState = parameters.ResourceState;
		bool flag = layer.ToTransportStatusView() == _view;
		if (flag)
		{
			bool flag2 = ((layer == ProLayerIndex.PresentationBackground || layer == ProLayerIndex.AnnouncementsBackground || layer == ProLayerIndex.Music) ? true : false);
			flag = flag2;
		}
		if (!flag)
		{
			return;
		}
		switch (resourceState)
		{
		case ProResourceState.Activated:
			if (parameters.MediaAction != null)
			{
				this.MediaTriggered?.Invoke(parameters.OriginalMediaCue, parameters.MediaAction, parameters.MediaAction.PlaybackMarkers);
			}
			break;
		case ProResourceState.Deactivated:
			this.MediaTriggered?.Invoke(parameters.OriginalMediaCue, null, null);
			break;
		}
	}
}
