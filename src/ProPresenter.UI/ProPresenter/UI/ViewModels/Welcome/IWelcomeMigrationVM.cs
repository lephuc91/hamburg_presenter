using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.DO.Migration;
using ProPresenter.UI.Welcome;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IWelcomeMigrationVM : INotifyPropertyChanged
{
	MigrationLibraryCollection Libraries { get; }

	bool Playlists { get; set; }

	bool MediaBin { get; set; }

	bool AudioBin { get; set; }

	bool SettingsSupportFiles { get; set; }

	MigrationStatus Status { get; set; }

	double ImportProgress { get; }

	bool IsPro6Available { get; }

	bool CanMigrateLibraryPlaylists { get; }

	ICommand MigrationHelpCommand { get; }

	void Initialize();

	void Complete();
}
