using System.Threading.Tasks;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class TimerSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly ICoreManager _coreManager;

	public TimerSendDataResponseHandler(ICoreManager coreManager)
	{
		_coreManager = coreManager;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.TimerState;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse.TimerState != null)
		{
			_coreManager.HandleTimerStateUpdate(sendDataResponse.TimerState);
			await Task.CompletedTask;
		}
	}
}
