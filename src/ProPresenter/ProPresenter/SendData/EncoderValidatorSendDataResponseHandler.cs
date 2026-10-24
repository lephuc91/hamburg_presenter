using System.Threading.Tasks;
using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Capture;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class EncoderValidatorSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly IEncoderValidator _encoderValidator;

	private readonly IUiDispatcher _uiDispatcher;

	public EncoderValidatorSendDataResponseHandler(IEncoderValidator encoderValidator, IUiDispatcher uiDispatcher)
	{
		_encoderValidator = encoderValidator;
		_uiDispatcher = uiDispatcher;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.ValidateEncoderResponse;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		if (sendDataResponse?.ValidateEncoderResponse != null)
		{
			await _uiDispatcher.InvokeAsync(delegate
			{
				_encoderValidator.OnValidationDone(sendDataResponse.MessageId, sendDataResponse.ValidateEncoderResponse.IsValid);
			});
		}
	}
}
