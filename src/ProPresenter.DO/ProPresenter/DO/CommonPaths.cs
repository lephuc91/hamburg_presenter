using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Pro.Common.Collections;
using Pro.Common.DataStore;
using Pro.DO.Storage;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO;

public static class CommonPaths
{
	private sealed class PathSettings : StoreBase
	{
		public const string SettingsFile = "PathSettings.proPaths";

		public string Preferences
		{
			get
			{
				return GetValue("Preferences", DefaultPreferences);
			}
			set
			{
				SetValue("Preferences", value);
			}
		}

		public string Bibles
		{
			get
			{
				return GetValue("Bibles", DefaultBibles);
			}
			set
			{
				SetValue("Bibles", value);
			}
		}

		public string Base
		{
			get
			{
				return GetValue("Base", LoadingDefaultShowDirectoryBase);
			}
			set
			{
				SetValue("Base", value);
			}
		}

		public string Logs
		{
			get
			{
				return GetValue("Logs", DefaultLogs);
			}
			set
			{
				SetValue("Logs", value);
			}
		}

		public string CrashReports
		{
			get
			{
				return GetValue("CrashReports", DefaultCrashReports);
			}
			set
			{
				SetValue("CrashReports", value);
			}
		}

		public WorkspaceCollection Workspaces { get; }

		public string Temp
		{
			get
			{
				return GetValue("Temp", DefaultTemp);
			}
			set
			{
				SetValue("Temp", value);
			}
		}

		public string WebCache
		{
			get
			{
				return GetValue("WebCache", DefaultWebCache);
			}
			set
			{
				SetValue("WebCache", value);
			}
		}

		public string ThumbnailCache
		{
			get
			{
				return GetValue("ThumbnailCache", DefaultThumbnailCache);
			}
			set
			{
				SetValue("ThumbnailCache", value);
			}
		}

		public string Downloads
		{
			get
			{
				return GetValue("Downloads", DefaultDownloads);
			}
			set
			{
				SetValue("Downloads", value);
			}
		}

		public PathSettings(string baseDirectory)
			: base(Path.Combine(baseDirectory, "PathSettings.proPaths"))
		{
			RegisterCustomType(Workspace.Encode, Workspace.Decode);
			RegisterListType(delegate(IWorkspace w, WorkspaceCollection wc)
			{
				wc.Add(w);
			});
			Workspaces = GetValue("Workspaces", new WorkspaceCollection());
			Workspaces.DataModified += delegate
			{
				WorkspaceCollection workspaceCollection = new WorkspaceCollection();
				foreach (IWorkspace item in Workspaces.Where((IWorkspace w) => w.WorkspaceType != WorkspaceType.Cloud))
				{
					workspaceCollection.Add(item);
				}
				SetValue("Workspaces", workspaceCollection);
				UpdateSettingsFile();
			};
			ValidateAndRemoveInvalidOrDuplicateWorkspaces();
		}

		private void ValidateAndRemoveInvalidOrDuplicateWorkspaces()
		{
			HashSet<string> seenPaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			string basePath = Path.GetFullPath(Base.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
			bool basePathSeen = false;
			foreach (IWorkspace item in Workspaces.Where(delegate(IWorkspace w)
			{
				if (string.IsNullOrWhiteSpace(w.Path))
				{
					return true;
				}
				string fullPath = Path.GetFullPath(w.Path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
				if (string.Equals(fullPath, basePath, StringComparison.OrdinalIgnoreCase))
				{
					if (!basePathSeen)
					{
						basePathSeen = true;
						return false;
					}
					return true;
				}
				if (!Directory.Exists(fullPath))
				{
					return true;
				}
				return !seenPaths.Add(fullPath);
			}).ToList())
			{
				Workspaces.Remove(item);
			}
			if (Workspaces.Empty())
			{
				Workspaces.Add("ProPresenter", Base, WorkspaceType.Local, makeActive: true);
			}
		}
	}

	private const string RVPostfix = "RenewedVision";

	private const string ProPostfix = "ProPresenter";

	private const string LocalWorkspacesPostfix = "LocalWorkspaces";

	public const string LibraryPostfix = "Libraries";

	public const string MediaPostfix = "Media";

	public const string ThemesPostfix = "Themes";

	public const string ConfigurationPostfix = "Configuration";

	public const string PlaylistPostfix = "Playlists";

	public const string TemplatesPostfix = "Templates";

	public const string PresetsPostFix = "Presets";

	public const string EffectsPostFix = "Effect";

	public const string TransitionPostFix = "Transition";

	private const string RegistrationPostfix = "Registration";

	private const string PreferencesPostfix = "Preferences";

	private const string BiblesPostfix = "Bibles";

	private const string MediaAssetsPostfix = "Assets";

	private const string ProContentAssetsPostfix = "ProContent";

	private const string MediaImportPostfix = "Import";

	private const string MediaImportedPostfix = "Imported";

	private const string MediaDownloadPostfix = "Downloads";

	private const string LogsPostfix = "Logs";

	private const string CrashReportsPostfix = "Crash Reports";

	private const string TempPostfix = "Temp";

	private const string WebCachePostfix = "Web Cache";

	private const string ThumbnailCachePostfix = "Thumbnail Cache";

	private const string DownloadsPostfix = "Downloads";

	private const string ResiPostFix = "Resi";

	private static readonly string SystemWideStorage;

	private static readonly string UserSpecificStorage;

	private static readonly string UserSpecificLocalStorage;

	private static readonly string UserDocumentStorage;

	private static readonly string SharedDocumentStorage;

	private static readonly string TempStorage;

	private static readonly string LegacyPathSettingsStorage;

	private static readonly string PathSettingsStorage;

	public static readonly string DefaultRegistration;

	public static readonly string DefaultPreferences;

	public static readonly string DefaultBibles;

	public static readonly string DefaultLogs;

	public static readonly string DefaultCrashReports;

	public static readonly string DefaultTemp;

	public static readonly string DefaultWebCache;

	public static readonly string DefaultThumbnailCache;

	public static readonly string DefaultDownloads;

	public static readonly string DefaultSyncData;

	public static readonly string DefaultResiTemp;

	public static readonly string DefaultBaseSystemWide;

	public static readonly string DefaultLocalWorkspaces;

	public static readonly string DefaultShowDirectoryBase;

	private static readonly string LegacyDefaultShowDirectoryBase;

	private static readonly string LoadingDefaultShowDirectoryBase;

	private static readonly PathSettings _pathSettings;

	public static string Base
	{
		get
		{
			return _pathSettings.Base;
		}
		set
		{
			_pathSettings.Base = value;
			OnPropertyChanged("Libraries");
			OnPropertyChanged("Media");
			OnPropertyChanged("MediaAssets");
			OnPropertyChanged("MediaImport");
			OnPropertyChanged("MediaImported");
			OnPropertyChanged("MediaDownload");
			OnPropertyChanged("Themes");
			OnPropertyChanged("EffectsPresets");
			OnPropertyChanged("Downloads");
			OnPropertyChanged("Configuration");
			RefreshAllCommonPaths();
			CommonPaths.BaseFolderChanged?.Invoke(value);
			OnPropertyChanged("Base");
		}
	}

	public static IWorkspaceCollection Workspaces => _pathSettings.Workspaces;

	public static string Registration { get; }

	public static string Preferences => _pathSettings.Preferences;

	public static string Bibles => _pathSettings.Bibles;

	public static string Libraries => Path.Combine(Base, "Libraries");

	public static string Media => Path.Combine(Base, "Media");

	public static string MediaAssets => Path.Combine(Media, "Assets") + Path.DirectorySeparatorChar;

	public static string ProContentAssets => Path.Combine(Media, "ProContent") + Path.DirectorySeparatorChar;

	public static string MediaImport => Path.Combine(Media, "Import") + Path.DirectorySeparatorChar;

	public static string MediaImported => Path.Combine(Media, "Imported") + Path.DirectorySeparatorChar;

	public static string MediaDownload => Path.Combine(Media, "Downloads") + Path.DirectorySeparatorChar;

	public static string Playlists => Path.Combine(Base, "Playlists") + Path.DirectorySeparatorChar;

	public static string PlaylistTemplates => Path.Combine(Base, "Playlists", "Templates") + Path.DirectorySeparatorChar;

	public static string Themes => Path.Combine(Base, "Themes") + Path.DirectorySeparatorChar;

	public static string EffectsPresets => Path.Combine(Base, "Presets", "Effect") + Path.DirectorySeparatorChar;

	public static string TransitionPresetsRelative => Path.Combine("Presets", "Transition");

	public static string TransitionPresets => Path.Combine(Base, TransitionPresetsRelative) + Path.DirectorySeparatorChar;

	public static string Configuration => Path.Combine(Base, "Configuration") + Path.DirectorySeparatorChar;

	public static string Logs => _pathSettings.Logs;

	public static string CrashReports => _pathSettings.CrashReports;

	public static string Temp => _pathSettings.Temp;

	public static string WebCache => _pathSettings.WebCache;

	public static string ThumbnailCache => _pathSettings.ThumbnailCache;

	public static string Downloads => _pathSettings.Downloads;

	public static string DocumentsFolder => Environment.GetFolderPath(Environment.SpecialFolder.Personal);

	public static string DesktopFolder => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

	public static string VideosFolder => Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

	public static string[] RequiredCommonPaths { get; private set; }

	public static string InstallLocation
	{
		get
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if ((object)entryAssembly == null)
			{
				return string.Empty;
			}
			return Path.GetFullPath(Path.GetDirectoryName(entryAssembly.Location) ?? string.Empty);
		}
	}

	public static event Action<string>? PropertyChanged;

	public static event Action<string>? BaseFolderChanged;

	static CommonPaths()
	{
		SystemWideStorage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "RenewedVision");
		UserSpecificStorage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RenewedVision");
		UserSpecificLocalStorage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RenewedVision");
		UserDocumentStorage = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		SharedDocumentStorage = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
		TempStorage = Path.Combine(Path.GetTempPath(), "RenewedVision");
		LegacyPathSettingsStorage = Path.Combine(UserDocumentStorage, "ProPresenter");
		PathSettingsStorage = Path.Combine(UserSpecificStorage, "ProPresenter");
		DefaultRegistration = Path.Combine(SystemWideStorage, "ProPresenter", "Registration") + Path.DirectorySeparatorChar;
		DefaultPreferences = Path.Combine(UserSpecificStorage, "ProPresenter", "Preferences") + Path.DirectorySeparatorChar;
		DefaultBibles = Path.Combine(SystemWideStorage, "ProPresenter", "Bibles") + Path.DirectorySeparatorChar;
		DefaultLogs = Path.Combine(UserSpecificLocalStorage, "ProPresenter", "Logs") + Path.DirectorySeparatorChar;
		DefaultCrashReports = Path.Combine(UserSpecificLocalStorage, "ProPresenter", "Crash Reports") + Path.DirectorySeparatorChar;
		DefaultTemp = Path.Combine(TempStorage, "ProPresenter", "Temp") + Path.DirectorySeparatorChar;
		DefaultWebCache = Path.Combine(TempStorage, "ProPresenter", "Web Cache") + Path.DirectorySeparatorChar;
		DefaultThumbnailCache = Path.Combine(TempStorage, "ProPresenter", "Thumbnail Cache") + Path.DirectorySeparatorChar;
		DefaultDownloads = Path.Combine(TempStorage, "ProPresenter", "Downloads") + Path.DirectorySeparatorChar;
		DefaultSyncData = Path.Combine(UserSpecificStorage, "ProPresenter") + Path.DirectorySeparatorChar;
		DefaultResiTemp = Path.Combine(TempStorage, "ProPresenter", "Resi") + Path.DirectorySeparatorChar;
		DefaultBaseSystemWide = Path.Combine(SharedDocumentStorage, "ProPresenter") + Path.DirectorySeparatorChar;
		DefaultLocalWorkspaces = Path.Combine(UserSpecificStorage, "ProPresenter", "LocalWorkspaces") + Path.DirectorySeparatorChar;
		DefaultShowDirectoryBase = Path.Combine(DefaultLocalWorkspaces, "ProPresenter") + Path.DirectorySeparatorChar;
		LegacyDefaultShowDirectoryBase = Path.Combine(UserDocumentStorage, "ProPresenter") + Path.DirectorySeparatorChar;
		LoadingDefaultShowDirectoryBase = (Directory.Exists(LegacyDefaultShowDirectoryBase) ? LegacyDefaultShowDirectoryBase : DefaultShowDirectoryBase);
		Registration = DefaultRegistration;
		RequiredCommonPaths = Array.Empty<string>();
		try
		{
			string text = Path.Combine(LegacyPathSettingsStorage, "PathSettings.proPaths");
			string text2 = Path.Combine(PathSettingsStorage, "PathSettings.proPaths");
			if (File.Exists(text) && !File.Exists(text2))
			{
				Directory.CreateDirectory(PathSettingsStorage);
				File.Move(text, text2);
			}
		}
		catch
		{
		}
		_pathSettings = new PathSettings(PathSettingsStorage);
		RefreshAllCommonPaths();
		RelativePath.SetShowRootProvider(() => Base ?? string.Empty);
	}

	private static void OnPropertyChanged(string propertyName)
	{
		CommonPaths.PropertyChanged?.Invoke(propertyName);
	}

	public static void Reload()
	{
		_pathSettings.Reload();
	}

	public static void UpdateSettingsFile()
	{
		_pathSettings.UpdateSettingsFile();
	}

	private static void RefreshAllCommonPaths()
	{
		RequiredCommonPaths = new string[24]
		{
			Registration, Preferences, Bibles, Libraries, MediaAssets, ProContentAssets, MediaImport, MediaImported, MediaDownload, Playlists,
			PlaylistTemplates, Themes, EffectsPresets, TransitionPresets, Configuration, Logs, CrashReports, Temp, WebCache, ThumbnailCache,
			Downloads, DesktopFolder, VideosFolder, DefaultLocalWorkspaces
		};
	}
}
