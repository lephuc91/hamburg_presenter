using System.Collections.Generic;
using System.IO;
using System.Linq;
using Pro.Common.Logging;
using Pro.Serialization.Utility;
using ProPresenter.DO.Migration.RVData;

namespace ProPresenter.DO.Migration;

public class Pro6Settings
{
	private const string Pro6PreferencesFolder = "Preferences";

	private const string Pro6PlaylistFolder = "PlaylistData";

	private const string Pro6TemplatesFolder = "Templates";

	private const string Pro6TemplateImagesFolder = "Template Images";

	private const string Pro6PurchasedMediaFolder = "PurchasedMedia";

	private IEnumerable<string>? _pro6AppDataFolders;

	public RVProPresenterVisualSettings? UISettings { get; private set; }

	public RVPreferencesGeneral? GeneralPref { get; private set; }

	public RVPreferencesAdvanced? AdvancedPref { get; private set; }

	public RVPreferencesDisplay? DisplayPref { get; private set; }

	public RVPreferencesLabels? LabelsPref { get; private set; }

	public RVPreferencesLiveVideo? LiveVideoPref { get; private set; }

	public RVPreferencesMultiScreen? MultiScreenPref { get; private set; }

	public RVPreferencesNetwork? NetworkPref { get; private set; }

	public RVPreferencesSynchronization? SyncPref { get; set; }

	public RVPreferencesSDI? SDIPref { get; set; }

	public string? PlaylistFolder { get; private set; }

	public string? TemplatesFolder { get; private set; }

	public string? TemplatesImagesFolder { get; private set; }

	public string? MediaPlaylist { get; private set; }

	public string? AudioPlaylist { get; private set; }

	public string? Messages { get; private set; }

	public string? Props { get; private set; }

	public string? Stage { get; private set; }

	public string? Timers { get; private set; }

	public string? CCLI { get; private set; }

	public string? MediaFolder { get; private set; }

	public string? PurchasedMediaFolder { get; private set; }

	public string? Masks { get; private set; }

	public bool Load()
	{
		_pro6AppDataFolders = MigrationHelper.GetPro6AppDataLocations();
		if (_pro6AppDataFolders == null || !_pro6AppDataFolders.Any((string l) => Directory.Exists(l)))
		{
			return false;
		}
		UISettings = LoadPrefFile<RVProPresenterVisualSettings>(FindPro6File(string.Empty, "UISettings.pro6data"));
		GeneralPref = LoadPrefFile<RVPreferencesGeneral>(FindPro6File("Preferences", "GeneralPreferences.pro6pref"));
		AdvancedPref = LoadPrefFile<RVPreferencesAdvanced>(FindPro6File("Preferences", "AdvancedPreferences.pro6pref"));
		DisplayPref = LoadPrefFile<RVPreferencesDisplay>(FindPro6File("Preferences", "DisplayPreferences.pro6pref"));
		LabelsPref = LoadPrefFile<RVPreferencesLabels>(FindPro6File("Preferences", "LabelsPreferences.pro6pref"));
		LiveVideoPref = LoadPrefFile<RVPreferencesLiveVideo>(FindPro6File("Preferences", "LiveVideoPreferences.pro6pref"));
		MultiScreenPref = LoadPrefFile<RVPreferencesMultiScreen>(FindPro6File("Preferences", "MultiScreenPreferences.pro6pref"));
		NetworkPref = LoadPrefFile<RVPreferencesNetwork>(FindPro6File("Preferences", "NetworkPreferences.pro6pref"));
		SyncPref = LoadPrefFile<RVPreferencesSynchronization>(FindPro6File("Preferences", "SyncPreferences.pro6pref"));
		SDIPref = LoadPrefFile<RVPreferencesSDI>(FindPro6File("Preferences", "SDIPreferences.pro6pref"));
		PlaylistFolder = FindPro6Folder("PlaylistData");
		TemplatesFolder = FindPro6Folder("Templates");
		TemplatesImagesFolder = FindPro6Folder("Template Images");
		MediaPlaylist = FindPro6File(string.Empty, "Media.pro6pl");
		AudioPlaylist = FindPro6File(string.Empty, "Audio.pro6pl");
		Messages = FindPro6File(string.Empty, "messageData.pro6data");
		Props = FindPro6File(string.Empty, "Props.pro6");
		Stage = FindPro6File(string.Empty, "stageDisplayLayouts.pro6data");
		Timers = FindPro6File(string.Empty, "countdownTimers.pro6data");
		CCLI = FindPro6File(string.Empty, "CCLI.pro6data");
		MediaFolder = GeneralPref?.MediaFolder;
		PurchasedMediaFolder = FindPro6Folder("PurchasedMedia");
		Masks = FindPro6File(string.Empty, "Mask.pro6");
		return true;
	}

	private T? LoadPrefFile<T>(string filename)
	{
		if (!XHelper.TryReadFile<T>(filename, out T data))
		{
			return default(T);
		}
		return data;
	}

	private string FindPro6File(string folder, string filename)
	{
		if (_pro6AppDataFolders == null)
		{
			return string.Empty;
		}
		foreach (string pro6AppDataFolder in _pro6AppDataFolders)
		{
			string text = Path.Combine(pro6AppDataFolder, folder, filename);
			if (File.Exists(text))
			{
				Log.Info("Found Pro6 AppData in \"{0}\"", pro6AppDataFolder);
				return text;
			}
			Log.Warning("Failed to find Pro6 AppData in \"{0}\"", pro6AppDataFolder);
		}
		return string.Empty;
	}

	private string FindPro6Folder(string folder)
	{
		if (_pro6AppDataFolders == null)
		{
			return string.Empty;
		}
		foreach (string pro6AppDataFolder in _pro6AppDataFolders)
		{
			string text = Path.Combine(pro6AppDataFolder, folder);
			if (Directory.Exists(text))
			{
				Log.Info("Found Pro6 AppData in \"{0}\"", pro6AppDataFolder);
				return text;
			}
			Log.Warning("Failed to find Pro6 AppData in \"{0}\"", pro6AppDataFolder);
		}
		return string.Empty;
	}
}
