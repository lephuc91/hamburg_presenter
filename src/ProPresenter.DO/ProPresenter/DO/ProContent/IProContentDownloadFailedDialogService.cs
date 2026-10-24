using ProPresenter.DO.ProContent.Consumer.Model.Result;

namespace ProPresenter.DO.ProContent;

public interface IProContentDownloadFailedDialogService
{
	void ShowInternetUnavailable();

	void ShowNotSignedIn();

	void Show(IRequestResult result);
}
