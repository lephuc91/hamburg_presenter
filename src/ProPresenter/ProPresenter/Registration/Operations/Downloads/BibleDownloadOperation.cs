using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Operations.Downloads;

public class BibleDownloadOperation : DownloadOperationBase
{
	private readonly string _fileName;

	private readonly string _bibleId;

	public BibleDownloadOperation(string filename, string bibleId)
	{
		_fileName = filename;
		_bibleId = bibleId;
	}

	public override RegistrationOperationHandleResponse HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.BibleDownloadProgress)
		{
			BibleDownloadProgress bibleDownloadProgress = responseCallback.BibleDownloadProgress;
			if (bibleDownloadProgress.BibleId != _bibleId)
			{
				return RegistrationOperationHandleResponse.Unhandled;
			}
			return new RegistrationOperationHandleResponse(MessageHandled: true, HandleDownloadProgress(bibleDownloadProgress.Status, bibleDownloadProgress.Progress, bibleDownloadProgress.Complete));
		}
		return RegistrationOperationHandleResponse.Unhandled;
	}

	public override Request Start()
	{
		return new Request
		{
			DownloadBible = new DownloadBible
			{
				Filename = _fileName,
				BibleId = _bibleId
			}
		};
	}
}
