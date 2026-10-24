using System.ComponentModel;
using System.Threading.Tasks;
using Pro.Common.Collections;

namespace ProPresenter.DO.Settings.GeneralSettings;

public interface IReportRepository : INotifyPropertyChanged
{
	INotifyEnumerableChanged<CCLIReport> Reports { get; }

	void Add(CCLIReport report);

	Task ClearAsync();

	Task ExportAsync(string file, bool excludeAutoReported);
}
