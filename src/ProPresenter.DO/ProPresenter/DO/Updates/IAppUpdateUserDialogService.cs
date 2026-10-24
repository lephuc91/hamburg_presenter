using System;

namespace ProPresenter.DO.Updates;

public interface IAppUpdateUserDialogService
{
	bool CheckIfUserReallyWantsToDowngrade();

	void EnsureUpdateViewerIsShown(IAppUpdateService appUpdateService);

	IDisposable ShowCheckingForUpdates();

	void ShowInternetUnavailable();

	void ShowNoUpdatesAvailable();

	void ShowRevertToProduction();

	void ShowUpdateProgress(IAppDownload appDownload);

	void ShowLicenseDoesNotCoverCurrentVersion();

	void ShowOnlyLicensesNotCoveredByLicenseAvailable();

	bool ShowNotAllLicesnesAvailableForLicense(string latestAvailableVersion, int availableUpdates);
}
