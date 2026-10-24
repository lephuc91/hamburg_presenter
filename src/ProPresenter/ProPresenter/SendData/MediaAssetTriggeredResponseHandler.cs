using System.Threading.Tasks;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V1;
using Pro.CoreApplication.Media.V2;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class MediaAssetTriggeredResponseHandler : ISendDataResponseHandler
{
	private readonly IMediaService _mediaService;

	public MediaAssetTriggeredResponseHandler(IMediaService coreMediaService)
	{
		_mediaService = coreMediaService;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.MediaAssetTriggered;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		string @string = sendDataResponse.MediaAssetTriggered.MediaUuid.String;
		if (_mediaService is IMediaServiceV1 mediaServiceV)
		{
			await mediaServiceV.SendTriggeredMedia(@string);
		}
		else if (_mediaService is IMediaServiceV2 mediaServiceV2)
		{
			string containerId = sendDataResponse.MediaAssetTriggered.ContainerId;
			await mediaServiceV2.SendTriggeredMedia(containerId, @string);
		}
	}
}
