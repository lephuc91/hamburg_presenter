using System.Threading.Tasks;
using Pro.Common.ErrorReporting;
using Pro.SerializationInterop.RVProtoData;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class ExceptionLogSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly IErrorPublisher _errorPublisher;

	public ExceptionLogSendDataResponseHandler(IErrorPublisher errorPublisher)
	{
		_errorPublisher = errorPublisher;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.HandledException;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse.HandledException != null)
		{
			string description = sendDataResponse.HandledException.Description;
			_errorPublisher.Error(description);
			await Task.CompletedTask;
		}
	}
}
