using System;
using Pro.CoreApplication.Media.CoreInteraction;

namespace Pro.CoreApplication.Media;

public interface IMediaAnalyticsSender
{
	void BootstrapComplete(Exception? exception);

	void ConnectionStateChanged(ConnectionStatus status);

	void RequestError(string uuid, string? error);

	void MediaAdded(uint width, uint height);
}
