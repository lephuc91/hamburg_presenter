using System.ComponentModel;

namespace ProPresenter.DO.Settings;

public interface IStoredPcoOptions : INotifyPropertyChanged
{
	string OrganizationName { get; }

	bool AutoPlanUpdate { get; set; }

	bool AutoUpload { get; set; }

	bool AutoDownload { get; set; }

	bool MatchSongs { get; set; }

	bool ShowHistoricalPlans { get; set; }

	bool ArrangementFromSequences { get; set; }

	string TargetLibrary { get; set; }
}
