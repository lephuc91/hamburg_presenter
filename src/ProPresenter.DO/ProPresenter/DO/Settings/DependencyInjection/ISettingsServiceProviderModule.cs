using Jab;
using Pro.CoreApplication.Media;
using Pro.Data.SQLite.Migration;
using ProPresenter.DO.Settings.GeneralSettings;

namespace ProPresenter.DO.Settings.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<App>]
[Jab.Transient<IApp>(Factory = "GetApp")]
[Jab.Transient<IMigrationSource>(Factory = "GetApp")]
[Jab.Singleton<INetwork, Network>]
[Jab.Transient<ITimecodeSettingsRepository, TimecodeSettingsRepository>]
[Jab.Transient<IAdvanced>(Factory = "GetAdvanced")]
[Jab.Transient<IManageMediaAutoMaticallyProvider>(Factory = "GetAdvanced")]
[Jab.Transient<IImport>(Factory = "GetImport")]
[Jab.Transient<IStoredPcoOptions>(Factory = "GetStoredPcoOptions")]
[Jab.Singleton<IReportRepository, ReportRepository>]
[Jab.Transient<IGeneral>(Factory = "GetGeneral")]
[Jab.Transient<IEnableAnalyticsProvider>(Factory = "GetGeneral")]
[Jab.Transient<IDisplay>(Factory = "GetDisplay")]
[Jab.Transient<ISync>(Factory = "GetSync")]
[Jab.Transient<ILayout>(Factory = "GetLayout")]
public interface ISettingsServiceProviderModule
{
	static App GetApp(App app)
	{
		return app;
	}

	static IAdvanced GetAdvanced()
	{
		return Advanced.Settings;
	}

	static IImport GetImport()
	{
		return Import.Settings;
	}

	static IStoredPcoOptions GetStoredPcoOptions()
	{
		return StoredPcoOptions.Settings;
	}

	static IGeneral GetGeneral()
	{
		return General.Settings;
	}

	static IDisplay GetDisplay()
	{
		return Display.Settings;
	}

	static ISync GetSync()
	{
		return Sync.Settings;
	}

	static ILayout GetLayout()
	{
		return Layout.Settings;
	}
}
