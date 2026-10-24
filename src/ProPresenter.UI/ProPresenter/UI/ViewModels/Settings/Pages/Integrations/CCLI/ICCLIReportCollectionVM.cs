using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;

public interface ICCLIReportCollectionVM : INotifyPropertyChanged
{
	FilteredObservableCollection<ICCLIReportVM> FilteredReports { get; }

	bool AutoReportUsage { get; set; }

	ICommand ResetCommand { get; }

	ICommand ExportCommand { get; }
}
