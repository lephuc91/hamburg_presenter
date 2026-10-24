using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Collections;
using Pro.Common.Dispatcher;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Events;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class CoreManagerSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly ICoreManager _coreManager;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly IProPresenterResourceService _resourceService;

	private readonly IApp _app;

	public CoreManagerSendDataResponseHandler(ICoreManager coreManager, IUiDispatcher uiDispatcher, IProPresenterResourceService resourceService, IApp app)
	{
		_coreManager = coreManager;
		_uiDispatcher = uiDispatcher;
		_resourceService = resourceService;
		_app = app;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType.IsAnyOf(SendDataResponse.MessageTypeOneofCase.AudioPlaylistFocusUuid, SendDataResponse.MessageTypeOneofCase.MediaPlaylistFocusUuid, SendDataResponse.MessageTypeOneofCase.ShowMessage, SendDataResponse.MessageTypeOneofCase.HideMessage);
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		await _uiDispatcher.InvokeAsync(delegate
		{
			if (sendDataResponse?.AudioPlaylistFocusUuid != null)
			{
				if (_resourceService.AudioPlaylists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == sendDataResponse.AudioPlaylistFocusUuid.ToGuid()).FirstOrDefault() is AudioPlaylist activeAudioPlaylist)
				{
					_coreManager.ActiveAudioPlaylist = activeAudioPlaylist;
				}
			}
			else if (sendDataResponse?.MediaPlaylistFocusUuid != null)
			{
				if (_resourceService.VisualPlaylists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == sendDataResponse.MediaPlaylistFocusUuid.ToGuid()).FirstOrDefault() is VisualPlaylist activeVisualPlaylist)
				{
					_coreManager.ActiveVisualPlaylist = activeVisualPlaylist;
				}
			}
			else if (sendDataResponse?.ShowMessage != null)
			{
				_app.StageMessage = sendDataResponse.ShowMessage.Message;
				StageMessageState.Publish(isShowing: true, sendDataResponse.ShowMessage.Message);
			}
			else if (sendDataResponse?.HideMessage != null)
			{
				StageMessageState.Publish(isShowing: false, _app.StageMessage);
			}
		});
	}
}
