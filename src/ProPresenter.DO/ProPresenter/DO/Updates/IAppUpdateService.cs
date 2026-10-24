using System.ComponentModel;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Updates;

public interface IAppUpdateService : INotifyPropertyChanged
{
	string ReleaseNotes { get; }

	BuildInformation? BuildAvailable { get; }

	BuildInformation? BetaBuildAvailable { get; }

	BuildInformation? ReleaseBuildAvailable { get; }

	BuildInformation? ReleaseBuildAvailableForPurchase { get; }

	BuildInformation? BetaBuildAvailableForPurchase { get; }

	void InitiateCheckForUpgrades();

	void InstallVersion(BuildInformation build);

	void ShowUpdateViewer();

	void SkipVersion(BuildInformation build);

	void Start();
}
