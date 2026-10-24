using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO.Migration;

namespace ProPresenter.UI.ViewModels;

public interface IMigrationVM : INotifyPropertyChanged
{
	bool MigrateLibraries { get; set; }

	bool AddToCloud { get; set; }

	bool MigratePlaylists { get; set; }

	bool MigrateMedia { get; set; }

	bool MigrateSettings { get; set; }

	MigrationLibraryCollection Libraries { get; }

	ICommand ImportPresentationCommand { get; }

	ICommand ImportFromClipboardCommand { get; }

	ICommand ImportPowerPointCommand { get; }

	ICommand ImportPowerPointLegacyCommand { get; }

	ICommand ImportMediaCommand { get; }

	ICommand ImportFromPreviousVersionCommand { get; }

	ICommand<MigrationLibrary?> ReplaceLibraryCommand { get; }
}
