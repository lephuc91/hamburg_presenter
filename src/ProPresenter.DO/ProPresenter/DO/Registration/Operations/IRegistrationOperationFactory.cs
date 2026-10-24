using System;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Registration.Operations;

public interface IRegistrationOperationFactory
{
	IAwaitableOperation<bool> RegisterWithUnlockCode(string userName, string unlockCode, string deviceName);

	IAwaitableOperation Activate(string confirmationCode, bool showVisualIndication = true);

	IAwaitableOperation Unregister();

	IAwaitableOperation Signout();

	IAwaitableOperation Refresh();

	IAwaitableOperation RefreshBibles();

	IAwaitableOperation ActivateBible(string bibleId);

	IAwaitableOperation DeactivateBible(string bibleId);

	IDownloadOperation DownloadBible(string bibleId, string fileName);

	IAwaitableOperation ChangeSeatType(bool isActive);

	IAwaitableOperation<AvailableSoftware> GetAvailableUpgrades(bool isBeta);

	IDownloadOperation DownloadApp(string url, string fileName);

	void SetOAuthToken(string token, string refreshToken, DateTimeOffset expiresAt);

	IAwaitableOperation SetDeviceName(string deviceName);

	IAwaitableOperation RefreshAccessToken();
}
