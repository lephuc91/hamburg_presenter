using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Pro.CoreApplication.Media;
using ProPresenter.DO.CCLI;

namespace ProPresenter.DO.Settings;

public interface IGeneral : INotifyPropertyChanged, IEnableAnalyticsProvider
{
	bool AutoUpdateCheck { get; set; }

	bool EnableCrashReporting { get; set; }

	bool ShowOutputAtLaunch { get; set; }

	bool AudienceScreensEnabled { get; set; }

	bool StageScreensEnabled { get; set; }

	bool ContiguousViewEnabled { get; set; }

	bool ShowHoW { get; set; }

	string LogoFilename { get; set; }

	bool PreserveLogoAspect { get; set; }

	ICCLILayoutData CCLILayoutData { get; }

	CultureInfo SelectedLanguage { get; set; }

	IReadOnlyCollection<CultureInfo> AvailableLanguages { get; }

	void Reload();

	void UpdateSettingsFile();
}
