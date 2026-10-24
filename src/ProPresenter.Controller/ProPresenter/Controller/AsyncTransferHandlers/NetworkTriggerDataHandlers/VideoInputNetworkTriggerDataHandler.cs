using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO.Playlists;

namespace ProPresenter.Controller.AsyncTransferHandlers.NetworkTriggerDataHandlers;

public class VideoInputNetworkTriggerDataHandler : INetworkTriggerDataHandler
{
	private readonly ProPresenter.DO.Playlists.LiveVideoPlaylist _videoInputs;

	public VideoInputNetworkTriggerDataHandler(ProPresenter.DO.Playlists.LiveVideoPlaylist videoIputs)
	{
		_videoInputs = videoIputs;
	}

	public NetworkTriggerDataItem? Handle(NetworkIdentifier id, ITriggerOperation op)
	{
		if (_videoInputs == null)
		{
			return null;
		}
		return id.FindItem(_videoInputs)?.ToTriggerDataItem(op, null);
	}
}
