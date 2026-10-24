using System;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.CoreInteraction;

namespace ProPresenter.DO.Analytics.Events.MediaManagement;

public class MediaAnalyticsSender : IMediaAnalyticsSender
{
	public void BootstrapComplete(Exception? exception)
	{
		BootstrappingCompleteEvent.Publish((exception != null) ? (exception.GetType().Name + ": " + exception.Message) : null);
	}

	public void ConnectionStateChanged(ConnectionStatus status)
	{
		if (status == ConnectionStatus.Unresponsive)
		{
			UnresponsiveEvent.Publish();
		}
		else
		{
			ConnectionStateChangedEvent.Publish(status == ConnectionStatus.Connected);
		}
	}

	public void MediaAdded(uint width, uint height)
	{
		AddedMediaReferenceEvent.Publish(width, height);
	}

	public void RequestError(string uuid, string? error)
	{
		MessageFailureEvent.Publish(uuid + " - " + error);
	}
}
