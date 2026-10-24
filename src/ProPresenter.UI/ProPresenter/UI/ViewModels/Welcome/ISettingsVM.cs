using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface ISettingsVM : INotifyPropertyChanged
{
	bool IncludeHoWIntegrations { get; set; }

	bool EnableCrashReporting { get; set; }

	bool EnableAnalytics { get; set; }
}
