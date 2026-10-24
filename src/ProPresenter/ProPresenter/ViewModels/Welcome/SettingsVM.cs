using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Pro.Common.Components;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.ViewModels.Welcome;

public class SettingsVM : LinkedNotifyPropertyChangedBase, ISettingsVM, INotifyPropertyChanged
{
	private readonly IGeneral _general;

	public bool IncludeHoWIntegrations
	{
		get
		{
			return _general.ShowHoW;
		}
		set
		{
			_general.ShowHoW = value;
		}
	}

	public bool EnableCrashReporting
	{
		get
		{
			return _general.EnableCrashReporting;
		}
		set
		{
			_general.EnableCrashReporting = value;
		}
	}

	public bool EnableAnalytics
	{
		get
		{
			return _general.EnableAnalytics;
		}
		set
		{
			_general.EnableAnalytics = value;
		}
	}

	public CultureInfo SelectedLanguage
	{
		get
		{
			return _general.SelectedLanguage;
		}
		set
		{
			_general.SelectedLanguage = value;
		}
	}

	public IReadOnlyCollection<CultureInfo> AvailableLanguages => _general.AvailableLanguages;

	public SettingsVM(IGeneral general)
	{
		_general = general;
		LinkProperties("ShowHoW", "IncludeHoWIntegrations");
		LinkProperties("EnableCrashReporting", "EnableCrashReporting");
		LinkProperties("EnableAnalytics", "EnableAnalytics");
		_general.PropertyChanged += base.RaiseLinkedValues;
	}
}
