using System.ComponentModel;
using System.IO;
using Pro.Common.DataStore;

namespace ProPresenter.DO.Settings;

public class StoredPcoOptions : StoreBase, IStoredPcoOptions, INotifyPropertyChanged
{
	private const string SettingsFile = "ServicesPreferences.proPref";

	public static StoredPcoOptions Settings { get; } = new StoredPcoOptions();

	public bool AutoPlanUpdate
	{
		get
		{
			return GetValue("AutoPlanUpdate", defaultValue: false);
		}
		set
		{
			SetValue("AutoPlanUpdate", value);
			OnPropertyChanged("AutoPlanUpdate");
		}
	}

	public bool AutoUpload
	{
		get
		{
			return GetValue("AutoUpload", defaultValue: false);
		}
		set
		{
			SetValue("AutoUpload", value);
			OnPropertyChanged("AutoUpload");
		}
	}

	public bool AutoDownload
	{
		get
		{
			return GetValue("AutoDownload", defaultValue: false);
		}
		set
		{
			SetValue("AutoDownload", value);
			OnPropertyChanged("AutoDownload");
		}
	}

	public bool MatchSongs
	{
		get
		{
			return GetValue("MatchSongs", defaultValue: false);
		}
		set
		{
			SetValue("MatchSongs", value);
			OnPropertyChanged("MatchSongs");
		}
	}

	public bool ShowHistoricalPlans
	{
		get
		{
			return GetValue("ShowHistoricalPlans", defaultValue: false);
		}
		set
		{
			SetValue("ShowHistoricalPlans", value);
			OnPropertyChanged("ShowHistoricalPlans");
		}
	}

	public bool ArrangementFromSequences
	{
		get
		{
			return GetValue("ArrangementFromSequences", defaultValue: false);
		}
		set
		{
			SetValue("ArrangementFromSequences", value);
			OnPropertyChanged("ArrangementFromSequences");
		}
	}

	public string TargetLibrary
	{
		get
		{
			return GetValue("TargetLibrary", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("TargetLibrary", value);
			OnPropertyChanged("TargetLibrary");
		}
	}

	public string OrganizationName => DataVault.PCOOrganization.Name ?? string.Empty;

	private StoredPcoOptions()
		: base(Path.Combine(CommonPaths.Preferences, "ServicesPreferences.proPref"))
	{
		DataVault.VaultInitialized += DataValueInitialized;
	}

	private void PcoOrganizationPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			OnPropertyChanged("OrganizationName");
		}
	}

	private void DataValueInitialized()
	{
		if (DataVault.PCOOrganization != null)
		{
			DataVault.PCOOrganization.PropertyChanged += PcoOrganizationPropertyChanged;
		}
	}
}
