using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using Pro.Common.DataStore;
using Pro.Common.Utility;
using Pro.CoreApplication.Media;
using Pro.Reporting;
using ProPresenter.DO.CCLI;

namespace ProPresenter.DO.Settings;

public class General : StoreBase, IGeneral, INotifyPropertyChanged, IEnableAnalyticsProvider
{
	private const string SettingsFile = "GeneralPreferences.proPref";

	private readonly CCLIToken[] _defaultCCLITokens = new CCLIToken[5]
	{
		new CCLIToken(CCLITokenType.Title)
		{
			Index = 0
		},
		new CCLIToken(CCLITokenType.Artist)
		{
			Index = 2
		},
		new CCLIToken(CCLITokenType.Publisher)
		{
			Index = 4
		},
		new CCLIToken(CCLITokenType.CopyrightYear)
		{
			Index = 8
		},
		new CCLIToken(CCLITokenType.LicenseNumber)
		{
			Index = 10
		}
	};

	private const string _defaultCCLILayoutText = "\n\n © \n";

	private const string CCLILayoutText = "CCLILayoutText";

	private const string CCLITokens = "CCLITokens";

	private ICCLILayoutData? _cCLILayoutData;

	public static General Settings { get; } = new General();

	public bool AutoUpdateCheck
	{
		get
		{
			return GetValue("AutoUpdateCheck", defaultValue: true);
		}
		set
		{
			SetValue("AutoUpdateCheck", value);
		}
	}

	public bool EnableCrashReporting
	{
		get
		{
			return GetValue("EnableCrashReporting", defaultValue: true);
		}
		set
		{
			SetValue("EnableCrashReporting", value);
			OnPropertyChanged("EnableCrashReporting");
			Stargazer.EnableCrashReporting = value;
		}
	}

	public bool EnableAnalytics
	{
		get
		{
			return GetValue("EnableAnalytics", defaultValue: true);
		}
		set
		{
			SetValue("EnableAnalytics", value);
			OnPropertyChanged("EnableAnalytics");
			Stargazer.EnableAnalytics = value;
		}
	}

	public IObservable<bool> WhenEnableAnalyticsChanged => (from _ in this.WhenPropertyChanges("EnableAnalytics")
		select EnableAnalytics).StartWith(EnableAnalytics);

	public bool ShowOutputAtLaunch
	{
		get
		{
			return GetValue("ShowOutputAtLaunch", defaultValue: false);
		}
		set
		{
			SetValue("ShowOutputAtLaunch", value);
			OnPropertyChanged("ShowOutputAtLaunch");
		}
	}

	public bool AudienceScreensEnabled
	{
		get
		{
			return GetValue("AudienceScreensEnabled", defaultValue: false);
		}
		set
		{
			SetValue("AudienceScreensEnabled", value);
			OnPropertyChanged("AudienceScreensEnabled");
		}
	}

	public bool StageScreensEnabled
	{
		get
		{
			return GetValue("StageScreensEnabled", defaultValue: false);
		}
		set
		{
			SetValue("StageScreensEnabled", value);
			OnPropertyChanged("StageScreensEnabled");
		}
	}

	public bool ContiguousViewEnabled
	{
		get
		{
			return GetValue("ContiguousViewEnabled", defaultValue: true);
		}
		set
		{
			SetValue("ContiguousViewEnabled", value);
			OnPropertyChanged("ContiguousViewEnabled");
		}
	}

	public bool ShowHoW
	{
		get
		{
			return GetValue("ShowHoW", defaultValue: true);
		}
		set
		{
			SetValue("ShowHoW", value);
			OnPropertyChanged("ShowHoW");
		}
	}

	public string LogoFilename
	{
		get
		{
			return GetValue("LogoFilename", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("LogoFilename", value);
			OnPropertyChanged("LogoFilename");
		}
	}

	public bool PreserveLogoAspect
	{
		get
		{
			return GetValue("PreserveLogoAspect", defaultValue: false);
		}
		set
		{
			SetValue("PreserveLogoAspect", value);
			OnPropertyChanged("PreserveLogoAspect");
		}
	}

	public ICCLILayoutData CCLILayoutData
	{
		get
		{
			if (_cCLILayoutData == null)
			{
				_cCLILayoutData = new CCLILayoutData(GetValue("CCLILayoutText", "\n\n © \n"), GetValue("CCLITokens", _defaultCCLITokens));
				_cCLILayoutData.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
				{
					if (e.PropertyName == "Text")
					{
						SetValue("CCLILayoutText", _cCLILayoutData.Text);
					}
				};
				_cCLILayoutData.Tokens.CollectionChanged += delegate
				{
					SetValue("CCLITokens", _cCLILayoutData.Tokens.Cast<CCLIToken>().ToArray());
				};
			}
			return _cCLILayoutData;
		}
	}

	public CultureInfo SelectedLanguage
	{
		get
		{
			return GetCulture(GetValue<string>("SelectedLanguage"));
		}
		set
		{
			SetValue("SelectedLanguage", value.Name);
			OnPropertyChanged("SelectedLanguage");
		}
	}

	public IReadOnlyCollection<CultureInfo> AvailableLanguages { get; } = GetAvailableLanguages();

	private General()
		: base(Path.Combine(CommonPaths.Preferences, "GeneralPreferences.proPref"))
	{
		RegisterCustomType((CCLIToken t) => $"{((int?)t?.TokenType).GetValueOrDefault()}|{t?.Index ?? 0}", delegate(string d)
		{
			string[] array = d.Split('|');
			return new CCLIToken((CCLITokenType)int.Parse(array[0]))
			{
				Index = int.Parse(array[1])
			};
		});
		RegisterArrayType<CCLIToken>();
	}

	private CultureInfo GetCulture(string? selectedLanguage)
	{
		foreach (CultureInfo availableLanguage in AvailableLanguages)
		{
			if (availableLanguage.Name == selectedLanguage || availableLanguage.EnglishName == selectedLanguage)
			{
				return availableLanguage;
			}
		}
		return CultureInfo.InvariantCulture;
	}

	private static IReadOnlyCollection<CultureInfo> GetAvailableLanguages()
	{
		return (IReadOnlyCollection<CultureInfo>)(object)(from f in Directory.GetDirectories("resources\\Localizations")
			select new CultureInfo(Path.GetFileNameWithoutExtension(f))).Prepend(CultureInfo.InvariantCulture).ToArray();
	}

	void IGeneral.UpdateSettingsFile()
	{
		UpdateSettingsFile();
	}
}
