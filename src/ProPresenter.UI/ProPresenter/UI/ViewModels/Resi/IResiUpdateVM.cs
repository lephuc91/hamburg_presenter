using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ProPresenter.DO.Resi;

namespace ProPresenter.UI.ViewModels.Resi;

public interface IResiUpdateVM : INotifyPropertyChanged
{
	UpdateStatus UpdateStatus { get; }

	string UpdateDisplayText { get; set; }

	double DownloadProgress { get; }

	ICommand InstallNowCommand { get; }

	ICommand InstallLaterCommand { get; }

	ICommand CancelDownloadCommand { get; }

	Task CheckForUpdateAsync(bool manualCheck);
}
