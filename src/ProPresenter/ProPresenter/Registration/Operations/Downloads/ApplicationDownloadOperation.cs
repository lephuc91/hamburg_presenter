using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.Downloads;

public class ApplicationDownloadOperation : DownloadOperationBase
{
	private readonly string _fileName;

	private readonly string _downloadUrl;

	public ApplicationDownloadOperation(string filename, string downloadUrl)
	{
		_fileName = filename;
		_downloadUrl = downloadUrl;
	}

	public override RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.DownloadProgress)
		{
			DownloadProgress downloadProgress = responseCallback.DownloadProgress;
			return new RegistrationOperationHandleResponse(MessageHandled: true, HandleDownloadProgress(downloadProgress.Status, downloadProgress.Progress, downloadProgress.Complete));
		}
		return RegistrationOperationHandleResponse.Unhandled;
	}

	public override Request Start()
	{
		return new Request
		{
			DownloadNewVersion = new DownloadNewVersion
			{
				Filename = _fileName,
				Url = _downloadUrl
			}
		};
	}
}
