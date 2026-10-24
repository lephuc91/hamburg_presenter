using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO.Analytics.Events.Settings.CCLIReport;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.GeneralSettings;
using ProPresenter.DO.SongSelect;
using ProPresenter.UI.ViewModels.Settings.Pages.Integrations.CCLI;

namespace ProPresenter.ViewModels.Settings.Pages.Integrations.CCLI;

public class CCLIReportCollectionVM : LinkedNotifyPropertyChangedBase, ICCLIReportCollectionVM, INotifyPropertyChanged
{
	private readonly IReportRepository _reportRepository;

	private readonly PairedCollection<CCLIReport, ICCLIReportVM> _reports;

	private readonly ICCLIReportPrompt _prompt;

	private readonly IApp _appSettings;

	private readonly ICCLIReportAnalyticsEvents _ccliAnalyticEvents;

	public FilteredObservableCollection<ICCLIReportVM> FilteredReports { get; }

	public bool AutoReportUsage
	{
		get
		{
			return _appSettings?.SongSelectAutoReportSongUsage ?? false;
		}
		set
		{
			if (_appSettings != null)
			{
				_appSettings.SongSelectAutoReportSongUsage = value;
			}
		}
	}

	public ICommand ResetCommand => new AsyncRelayCommand(OnResetCommandExecutedAsync, () => _reports.Any());

	public ICommand ExportCommand => new AsyncRelayCommand(OnExportCommandExecutedAsync, () => _reports.Any());

	public CCLIReportCollectionVM(IReportRepository reportRepository, IApp app, ICCLIReportAnalyticsEvents ccliAnalyticEvents, ICCLIReportPrompt prompt, ISongSelectConsumer songSelectConsumer, IInternetAccess internetAccess)
	{
		_reportRepository = reportRepository;
		_appSettings = app;
		_ccliAnalyticEvents = ccliAnalyticEvents;
		_prompt = prompt;
		_reports = new PairedCollection<CCLIReport, ICCLIReportVM>(_reportRepository.Reports, (CCLIReport r) => new CCLIReportVM(r, songSelectConsumer, internetAccess));
		FilteredReports = new FilteredObservableCollection<ICCLIReportVM>(_reports, FilterReports);
		LinkProperties("SongSelectAutoReportSongUsage", "AutoReportUsage");
		_appSettings.PropertyChanged += base.RaiseLinkedValues;
	}

	private bool FilterReports(ICCLIReportVM reportVM)
	{
		return true;
	}

	private async Task OnResetCommandExecutedAsync()
	{
		_ccliAnalyticEvents?.Reset();
		if (_prompt.ConfirmReset())
		{
			await _reportRepository.ClearAsync();
		}
	}

	private async Task OnExportCommandExecutedAsync()
	{
		if (_prompt.TryGetExportFile(out string fileName, out bool excludeAutoReported))
		{
			await _reportRepository.ExportAsync(fileName, excludeAutoReported);
		}
	}
}
