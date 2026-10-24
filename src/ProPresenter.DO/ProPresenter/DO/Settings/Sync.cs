using System.ComponentModel;
using System.IO;
using Pro.Common.DataStore;

namespace ProPresenter.DO.Settings;

public class Sync : StoreBase, ISync, INotifyPropertyChanged
{
	private const string SettingsFile = "SyncPreferences.proPref";

	private static readonly Sync _settings = new Sync();

	public static Sync Settings => _settings;

	public string AccessToken
	{
		get
		{
			return GetValue("AccessToken", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("AccessToken", value);
			OnPropertyChanged("AccessToken");
		}
	}

	public string AccessTokenSecret
	{
		get
		{
			return GetValue("AccessTokenSecret", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("AccessTokenSecret", value);
			OnPropertyChanged("AccessTokenSecret");
		}
	}

	public string AuthorizationInfoHash
	{
		get
		{
			return GetValue("AuthorizationInfoHash", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("AuthorizationInfoHash", value);
			OnPropertyChanged("AuthorizationInfoHash");
		}
	}

	public string LastSyncDateTime
	{
		get
		{
			return GetValue("LastSyncDateTime", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("LastSyncDateTime", value);
			OnPropertyChanged("LastSyncDateTime");
		}
	}

	public int? AccountID
	{
		get
		{
			int value = GetValue("AccountID", -1);
			if (value == -1)
			{
				return null;
			}
			return value;
		}
		set
		{
			SetValue("AccountID", value ?? (-1));
			OnPropertyChanged("AccountID");
		}
	}

	public int? CollectionID
	{
		get
		{
			int value = GetValue("CollectionID", -1);
			if (value == -1)
			{
				return null;
			}
			return value;
		}
		set
		{
			SetValue("CollectionID", value ?? (-1));
			OnPropertyChanged("CollectionID");
		}
	}

	public int? ApplicationID
	{
		get
		{
			int value = GetValue("ApplicationID", -1);
			if (value == -1)
			{
				return null;
			}
			return value;
		}
		set
		{
			SetValue("ApplicationID", value ?? (-1));
			OnPropertyChanged("ApplicationID");
		}
	}

	public string LocalSyncSource
	{
		get
		{
			return GetValue("LocalSyncSource", string.Empty) ?? string.Empty;
		}
		set
		{
			SetValue("LocalSyncSource", value);
			OnPropertyChanged("LocalSyncSource");
		}
	}

	public bool LocalSyncIncludeLibraryDoc
	{
		get
		{
			return GetValue("LocalSyncIncludeLibraryDoc", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncIncludeLibraryDoc", value);
			OnPropertyChanged("LocalSyncIncludeLibraryDoc");
		}
	}

	public bool LocalSyncIncludePlaylists
	{
		get
		{
			return GetValue("LocalSyncIncludePlaylists", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncIncludePlaylists", value);
			OnPropertyChanged("LocalSyncIncludePlaylists");
		}
	}

	public bool LocalSyncIncludeTemplates
	{
		get
		{
			return GetValue("LocalSyncIncludeTemplates", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncIncludeTemplates", value);
			OnPropertyChanged("LocalSyncIncludeTemplates");
		}
	}

	public bool LocalSyncIncludeMedia
	{
		get
		{
			return GetValue("LocalSyncIncludeMedia", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncIncludeMedia", value);
			OnPropertyChanged("LocalSyncIncludeMedia");
		}
	}

	public bool LocalSyncIncludeUserData
	{
		get
		{
			return GetValue("LocalSyncIncludeUserData", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncIncludeUserData", value);
			OnPropertyChanged("LocalSyncIncludeUserData");
		}
	}

	public bool LocalSyncDown
	{
		get
		{
			return GetValue("LocalSyncDown", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncDown", value);
			OnPropertyChanged("LocalSyncDown");
		}
	}

	public bool LocalSyncUp
	{
		get
		{
			return GetValue("LocalSyncUp", defaultValue: false);
		}
		set
		{
			SetValue("LocalSyncUp", value);
			OnPropertyChanged("LocalSyncUp");
		}
	}

	public bool ReplaceFiles
	{
		get
		{
			return GetValue("ReplaceFiles", defaultValue: false);
		}
		set
		{
			SetValue("ReplaceFiles", value);
			OnPropertyChanged("ReplaceFiles");
		}
	}

	public bool AllowMultipleTransfer
	{
		get
		{
			return GetValue("AllowMultipleTransfer", defaultValue: true);
		}
		set
		{
			SetValue("AllowMultipleTransfer", value);
			OnPropertyChanged("AllowMultipleTransfer");
		}
	}

	public bool PreventUploads
	{
		get
		{
			return GetValue("PreventUploads", defaultValue: false);
		}
		set
		{
			SetValue("PreventUploads", value);
			OnPropertyChanged("PreventUploads");
		}
	}

	public bool CloudSyncIncludeLibraryDoc
	{
		get
		{
			return GetValue("CloudSyncIncludeLibraryDoc", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeLibraryDoc", value);
			if (!value)
			{
				CloudSyncIncludeLibraryPlaylists = value;
			}
			OnPropertyChanged("CloudSyncIncludeLibraryDoc");
		}
	}

	public bool CloudSyncIncludeLibraryPlaylists
	{
		get
		{
			return GetValue("CloudSyncIncludeLibraryPlaylists", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeLibraryPlaylists", value);
			OnPropertyChanged("CloudSyncIncludeLibraryPlaylists");
		}
	}

	public bool CloudSyncIncludeMedia
	{
		get
		{
			return GetValue("CloudSyncIncludeMedia", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeMedia", value);
			OnPropertyChanged("CloudSyncIncludeMedia");
		}
	}

	public bool CloudSyncIncludeAudio
	{
		get
		{
			return GetValue("CloudSyncIncludeAudio", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeAudio", value);
			OnPropertyChanged("CloudSyncIncludeAudio");
		}
	}

	public bool CloudSyncIncludeTemplates
	{
		get
		{
			return GetValue("CloudSyncIncludeTemplates", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeTemplates", value);
			OnPropertyChanged("CloudSyncIncludeTemplates");
		}
	}

	public bool CloudSyncIncludeSupportFiles
	{
		get
		{
			return GetValue("CloudSyncIncludeSupportFiles", defaultValue: true);
		}
		set
		{
			SetValue("CloudSyncIncludeSupportFiles", value);
			OnPropertyChanged("CloudSyncIncludeSupportFiles");
		}
	}

	public bool SetupFinished
	{
		get
		{
			return GetValue("SetupFinished", defaultValue: false);
		}
		set
		{
			SetValue("SetupFinished", value);
			OnPropertyChanged("SetupFinished");
		}
	}

	public FirstSyncActionType FirstSyncActionType
	{
		get
		{
			return GetValue("FirstSyncActionType", FirstSyncActionType.Merge);
		}
		set
		{
			SetValue("FirstSyncActionType", value);
			OnPropertyChanged("FirstSyncActionType");
		}
	}

	public FirstSyncMergeType FirstSyncMergeType
	{
		get
		{
			return GetValue("FirstSyncMergeType", FirstSyncMergeType.TakeLatest);
		}
		set
		{
			SetValue("FirstSyncMergeType", value);
			OnPropertyChanged("FirstSyncMergeType");
		}
	}

	private Sync()
		: base(Path.Combine(CommonPaths.Preferences, "SyncPreferences.proPref"))
	{
		RegisterCustomType((int? v) => v?.ToString() ?? "-1", (string v) => int.TryParse(v, out var result) ? new int?(result) : new int?(-1));
		RegisterEnumType<FirstSyncActionType>();
		RegisterEnumType<FirstSyncMergeType>();
	}
}
