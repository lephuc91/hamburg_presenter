using System.Threading.Tasks;
using Pro.Common.Dispatcher;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Resi;
using ProPresenter.ViewModels.Capture;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.SendDataHandlers;

namespace ProPresenter.SendData;

public class CaptureActionSendDataResponseHandler : ISendDataResponseHandler
{
	private readonly IProCoreInstance _proCoreInstance;

	private readonly ICapturePrompt _capturePrompt;

	private readonly IUiDispatcher _uiDispatcher;

	private readonly ICrashRecovery _crashRecovery;

	public CaptureActionSendDataResponseHandler(IProCoreInstance proCoreInstance, ICapturePrompt capturePrompt, IUiDispatcher uiDispatcher, ICrashRecovery crashRecovery)
	{
		_proCoreInstance = proCoreInstance;
		_capturePrompt = capturePrompt;
		_uiDispatcher = uiDispatcher;
		_crashRecovery = crashRecovery;
	}

	public bool CanHandle(SendDataResponse.MessageTypeOneofCase sendDataResponseType)
	{
		return sendDataResponseType == SendDataResponse.MessageTypeOneofCase.CaptureActionRequest;
	}

	public async Task Handle(SendDataResponse sendDataResponse)
	{
		await _uiDispatcher.InvokeAsync(delegate
		{
			if (sendDataResponse.CaptureActionRequest != null)
			{
				Pro.SerializationInterop.RVProtoData.SendData sendData = null;
				switch (sendDataResponse.CaptureActionRequest.RequestTypeCase)
				{
				case CaptureActionRequest.RequestTypeOneofCase.StartResi:
				{
					ResiDetails resiEventDetails = _capturePrompt.GetResiEventDetails();
					sendData = (((object)resiEventDetails == null || !resiEventDetails.StartStream) ? new Pro.SerializationInterop.RVProtoData.SendData
					{
						MessageId = sendDataResponse.MessageId,
						CaptureActionResponse = new CaptureActionResponse
						{
							CancelCaptureAction = new CaptureActionResponse.Types.CancelCaptureAction()
						}
					} : new Pro.SerializationInterop.RVProtoData.SendData
					{
						MessageId = sendDataResponse.MessageId,
						CaptureActionResponse = new CaptureActionResponse
						{
							StartResi = new CaptureActionResponse.Types.StartResi
							{
								EventName = resiEventDetails.Name,
								EventDescription = resiEventDetails.Description
							}
						}
					});
					break;
				}
				case CaptureActionRequest.RequestTypeOneofCase.StopCapture:
				{
					bool stopCapture_ = _capturePrompt.ConfirmStopCapture();
					sendData = new Pro.SerializationInterop.RVProtoData.SendData
					{
						MessageId = sendDataResponse.MessageId,
						CaptureActionResponse = new CaptureActionResponse
						{
							StopCapture = new CaptureActionResponse.Types.StopCapture
							{
								StopCapture_ = stopCapture_
							}
						}
					};
					break;
				}
				case CaptureActionRequest.RequestTypeOneofCase.Error:
				{
					_crashRecovery.RemoveLastCaptureInfo();
					CaptureActionRequest.Types.Error error = sendDataResponse.CaptureActionRequest.Error;
					string presetName = null;
					if (error.CaptureAction.Start != null)
					{
						presetName = error.CaptureAction.Start.PresetIdentification?.ParameterName;
					}
					_capturePrompt.ShowStartCaptureActionError(error.ErrorCode, presetName);
					break;
				}
				}
				if (sendData != null)
				{
					_proCoreInstance.SendData(sendData, out var _);
				}
			}
		});
	}
}
