using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.DO;
using Pro.DO.Audio;
using Pro.DO.Label;
using Pro.ssAPI.Devices;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Label;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Looks;
using ProPresenter.DO.Migration.RVData;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Migration;

public class MigrationProcess : LinkedNotifyPropertyChangedBase
{
	private const string AudioPostfix = "Audio";

	private const string ImagePostfix = "Images";

	private const string VideoPostfix = "Video";

	private const string DualHead2Go = "DualHead2Go";

	private const string TripleHead2Go = "TripleHead2Go";

	private readonly IApp _app;

	private readonly INetwork _network;

	private readonly IImportProcessFactory _importProcessFactory;

	private IImportProcess? _importProcess;

	private double _completedPercentage;

	public MigrationLibraryCollection Libraries { get; } = new MigrationLibraryCollection();

	private Pro6Settings Pro6Settings { get; }

	public bool Pro6Available { get; set; }

	public double CompletedPercentage
	{
		get
		{
			return _completedPercentage;
		}
		set
		{
			SetValue("CompletedPercentage", ref _completedPercentage, value);
		}
	}

	public event Action? MigrateComplete;

	public MigrationProcess(IApp app, INetwork network, IImportProcessFactory importProcessFactory)
	{
		_app = app;
		_network = network;
		_importProcessFactory = importProcessFactory;
		Pro6Settings = new Pro6Settings();
		LinkAction("CompletedPercentage", delegate
		{
			CompletedPercentage = _importProcess?.CompletedPercentage ?? 0.0;
		});
	}

	public void RefreshFolders()
	{
		Pro6Available = Pro6Settings.Load();
		Libraries.RemoveAll();
		Libraries.AddFolders(LoadLibraries());
	}

	private MigrationLibrary[] LoadLibraries()
	{
		List<MigrationLibrary> list = new List<MigrationLibrary>();
		RVPreferencesGeneral generalPref = Pro6Settings.GeneralPref;
		if (generalPref != null && generalPref.Folders != null)
		{
			foreach (RVLibraryFolder folder in generalPref.Folders)
			{
				if (!list.Any((MigrationLibrary l) => l.SourceFolder.IsPathEqual(folder.Location ?? string.Empty)))
				{
					list.Add(new MigrationLibrary(folder, folder.Name ?? string.Empty));
				}
			}
		}
		return list.ToArray();
	}

	public void StartMigration(bool addToCloud, bool migratePlaylistLibrary, bool migrateMediaBin, bool migrateAudioBin, bool migrateSettings, IOutputConfiguration outputConfiguration, bool showProgressDialog = true)
	{
		if (_importProcess != null)
		{
			_importProcess.ImportComplete -= ImportComplete;
		}
		General.Settings.UpdateSettingsFile();
		ProPresenter.DO.Settings.Import.Settings.UpdateSettingsFile();
		_network.UpdateSettingsFile();
		ProPresenter.DO.Settings.Sync.Settings.UpdateSettingsFile();
		StoredPcoOptions.Settings.UpdateSettingsFile();
		Advanced.Settings.UpdateSettingsFile();
		_app.UpdateSettingsFile();
		Advanced.Settings.UpdateSettingsFile();
		List<FileImportRequest> requests = new List<FileImportRequest>();
		foreach (MigrationLibrary item in Libraries.Where((MigrationLibrary d) => d.ShouldImport))
		{
			if (!Directory.Exists(item.SourceFolder))
			{
				continue;
			}
			string[] files = Directory.GetFiles(item.SourceFolder, string.Format("*{0}", ".pro6"));
			if (migratePlaylistLibrary)
			{
				string text = Path.Combine(Pro6Settings.PlaylistFolder ?? string.Empty, item.SourceName + ".pro6pl");
				if (File.Exists(text))
				{
					requests.Add(new FileImportRequest(text, new PlaylistImportData(PlaylistLocation.Library))
					{
						TargetFolder = Path.Combine(CommonPaths.Libraries, item.TargetName)
					});
				}
			}
			ILibrary targetLibrary = DataVault.LibraryCollection?.Add(item.SourceName);
			requests.AddRange(files.Select((string f) => new FileImportRequest(f)
			{
				TargetFolder = Path.Combine(CommonPaths.Libraries, targetLibrary?.Name ?? string.Empty),
				TargetLibrary = targetLibrary
			}));
		}
		if (migrateSettings)
		{
			MigrateSettings(outputConfiguration);
			string templatesFolder = Pro6Settings.TemplatesFolder;
			if (Directory.Exists(templatesFolder))
			{
				string[] files2 = Directory.GetFiles(templatesFolder, "*.pro6Template", SearchOption.AllDirectories);
				foreach (string file in files2)
				{
					requests.Add(new FileImportRequest(file));
				}
			}
			string messages = Pro6Settings.Messages;
			if (File.Exists(messages))
			{
				requests.Add(new FileImportRequest(messages)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
			string props = Pro6Settings.Props;
			if (File.Exists(props))
			{
				requests.Add(new FileImportRequest(props)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
			string stage = Pro6Settings.Stage;
			if (File.Exists(stage))
			{
				requests.Add(new FileImportRequest(stage)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
			string timers = Pro6Settings.Timers;
			if (File.Exists(timers))
			{
				requests.Add(new FileImportRequest(timers)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
			string cCLI = Pro6Settings.CCLI;
			if (File.Exists(cCLI))
			{
				requests.Add(new FileImportRequest(cCLI)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
			string masks = Pro6Settings.Masks;
			if (File.Exists(masks))
			{
				requests.Add(new FileImportRequest(masks)
				{
					TargetFolder = CommonPaths.Configuration
				});
			}
		}
		if (migrateMediaBin)
		{
			if (Directory.Exists(Pro6Settings.MediaFolder))
			{
				List<string> list = new List<string>();
				string path = Path.Combine(Pro6Settings.MediaFolder, "Images");
				string path2 = Path.Combine(Pro6Settings.MediaFolder, "Video");
				if (Directory.Exists(path))
				{
					list.AddRange(Directory.GetFiles(path));
				}
				if (Directory.Exists(path2))
				{
					list.AddRange(Directory.GetFiles(path2));
				}
				if (Directory.Exists(Pro6Settings.PurchasedMediaFolder))
				{
					list.AddRange(Directory.GetFiles(Pro6Settings.PurchasedMediaFolder));
				}
				list.ForEach(delegate(string m)
				{
					requests.Add(new FileImportRequest(m)
					{
						TargetFolder = CommonPaths.MediaAssets
					});
				});
			}
			string mediaPlaylist = Pro6Settings.MediaPlaylist;
			if (File.Exists(mediaPlaylist))
			{
				DataVault.VisualPlaylistCollection?.RemovePlaylists(DataVault.VisualPlaylistCollection.ToArray());
				requests.Add(new FileImportRequest(mediaPlaylist, new PlaylistImportData(PlaylistLocation.MediaBin)));
			}
		}
		if (migrateAudioBin)
		{
			if (Directory.Exists(Pro6Settings.MediaFolder))
			{
				List<string> list2 = new List<string>();
				string path3 = Path.Combine(Pro6Settings.MediaFolder, "Audio");
				if (Directory.Exists(path3))
				{
					list2.AddRange(Directory.GetFiles(path3));
				}
				list2.ForEach(delegate(string m)
				{
					requests.Add(new FileImportRequest(m)
					{
						TargetFolder = CommonPaths.MediaAssets
					});
				});
			}
			string audioPlaylist = Pro6Settings.AudioPlaylist;
			if (File.Exists(audioPlaylist))
			{
				DataVault.AudioPlaylistCollection?.RemovePlaylists(DataVault.AudioPlaylistCollection.ToArray());
				requests.Add(new FileImportRequest(audioPlaylist, new PlaylistImportData(PlaylistLocation.AudioBin)));
			}
		}
		if (_importProcess != null)
		{
			_importProcess.PropertyChanged -= base.RaiseLinkedValues;
		}
		_importProcess = _importProcessFactory.Create(requests);
		_importProcess.ShowProgressDialog = showProgressDialog;
		_importProcess.ImportComplete += ImportComplete;
		_importProcess.PropertyChanged += base.RaiseLinkedValues;
		_importProcess.StartImport();
		if (requests.Empty())
		{
			ImportComplete(_importProcess);
		}
	}

	private void ImportComplete(IImportProcess process)
	{
		CompletedPercentage = 1.0;
		this.MigrateComplete?.Invoke();
	}

	public void MigrateSettings(IOutputConfiguration outputConfiguration)
	{
		RVPreferencesGeneral generalPref = Pro6Settings.GeneralPref;
		RVPreferencesAdvanced advancedPref = Pro6Settings.AdvancedPref;
		RVPreferencesDisplay displayPref = Pro6Settings.DisplayPref;
		RVPreferencesLabels labelsPref = Pro6Settings.LabelsPref;
		RVPreferencesLiveVideo liveVideoPref = Pro6Settings.LiveVideoPref;
		RVPreferencesMultiScreen multiScreenPref = Pro6Settings.MultiScreenPref;
		RVPreferencesNetwork networkPref = Pro6Settings.NetworkPref;
		RVPreferencesSynchronization syncPref = Pro6Settings.SyncPref;
		RVPreferencesSDI sDIPref = Pro6Settings.SDIPref;
		if (advancedPref != null)
		{
			MigrateAdvanced(advancedPref, outputConfiguration);
		}
		int screenCount = 1;
		if (multiScreenPref != null && multiScreenPref.IsMultiScreenEnabled)
		{
			string? selectedMultiScreenLayout = multiScreenPref.SelectedMultiScreenLayout;
			if (selectedMultiScreenLayout != null && selectedMultiScreenLayout.Equals("DualHead2Go"))
			{
				screenCount = 2;
			}
			else
			{
				string? selectedMultiScreenLayout2 = multiScreenPref.SelectedMultiScreenLayout;
				if (selectedMultiScreenLayout2 != null && selectedMultiScreenLayout2.Equals("TripleHead2Go"))
				{
					screenCount = 3;
				}
			}
		}
		if (displayPref != null)
		{
			MigrateDisplay(displayPref, outputConfiguration, screenCount);
		}
		if (generalPref != null)
		{
			MigrateGeneral(generalPref);
		}
		if (labelsPref != null)
		{
			MigrateLabel(labelsPref);
		}
		if (liveVideoPref != null)
		{
			MigrateLiveVideo(liveVideoPref);
		}
		MigrateMultiScreen(multiScreenPref, outputConfiguration);
		if (networkPref != null)
		{
			MigrateNetwork(networkPref);
		}
		if (syncPref != null)
		{
			MigrateSync(syncPref);
		}
		if (sDIPref != null)
		{
			MigrateSDI(sDIPref);
		}
	}

	private static void MigrateAdvanced(RVPreferencesAdvanced advancedPref, IOutputConfiguration outputConfiguration)
	{
		if (advancedPref != null)
		{
			if (advancedPref.AudioChannels > 2)
			{
				outputConfiguration.DigitalAudioSettings.BusCount = advancedPref.AudioChannels;
			}
			TimeSlice audioDelay = TimeSlice.FromSeconds(advancedPref.AudioDelay);
			outputConfiguration.DigitalAudioSettings.MainOutputDestination.Routing.ChannelSet.ForEach(delegate(DeviceChannel c)
			{
				c.Delay = audioDelay;
			});
			ProPresenter.DO.Settings.Import.Settings.BackgroundScaleBehavior = advancedPref.BackgroundScaleBehavior;
			ProPresenter.DO.Settings.Import.Settings.ForegroundScaleBehavior = advancedPref.ForegroundScaleBehavior;
			Advanced.Settings.SuppressVideoStart = advancedPref.KeyClickSuppressVideo;
		}
	}

	private static void MigrateDisplay(RVPreferencesDisplay displayPref, IOutputConfiguration outputConfiguration, int screenCount)
	{
		if (displayPref == null || outputConfiguration == null)
		{
			return;
		}
		General.Settings.ShowOutputAtLaunch = displayPref.ShowOutputAtLaunch;
		Vector2<int> screenSize = displayPref.ScreenSize;
		DeviceBase deviceBase = PhysicalDevice.AttachedPhysicalDevices.ElementAtOrDefault(displayPref.SelectedScreen);
		Vector2<int>? vector = deviceBase?.Bounds.Size.Cast<int>();
		if (!vector.HasValue || screenSize.X > vector.Value.X || screenSize.Y > vector.Value.Y)
		{
			deviceBase = new PlaceholderDevice(displayPref.ScreenSize);
		}
		PhysicalDevice physicalDevice = PhysicalDevice.AttachedPhysicalDevices.ElementAtOrDefault(displayPref.StageDisplayScreen);
		if (deviceBase != null)
		{
			for (int i = 0; i < screenCount; i++)
			{
				SingleScreenArrangement singleScreenArrangement = new SingleScreenArrangement(ScreenTargetType.Audience, null, 1, null)
				{
					BackgroundColor = displayPref?.ScreenColor,
					Name = outputConfiguration.AudienceArrangementScreens.DefaultScreenArrangementName
				};
				ScreenCornerPins screenCornerPins = null;
				switch (screenCount)
				{
				case 1:
					screenCornerPins = displayPref?.SingleScreenCornerPins?.SingleScreen;
					break;
				case 2:
					switch (i)
					{
					case 0:
						screenCornerPins = displayPref?.DualScreenCornerPins?.LeftScreen;
						break;
					case 1:
						screenCornerPins = displayPref?.DualScreenCornerPins?.RightScreen;
						break;
					}
					break;
				case 3:
					switch (i)
					{
					case 0:
						screenCornerPins = displayPref?.TripleScreenCornerPins?.LeftScreen;
						break;
					case 1:
						screenCornerPins = displayPref?.TripleScreenCornerPins?.CenterScreen;
						break;
					case 2:
						screenCornerPins = displayPref?.TripleScreenCornerPins?.RightScreen;
						break;
					}
					break;
				}
				Screen[] screens = singleScreenArrangement.Screens;
				foreach (Screen screen in screens)
				{
					screen.MainOutput.OutputDevice = deviceBase;
					Vector2<double> zero = Vector2<double>.Zero;
					double x = screen.Bounds.Size.X;
					double y = screen.Bounds.Size.Y;
					switch (displayPref?.ScreenPosition)
					{
					case ScreenPosition.TopLeft:
					case ScreenPosition.MidLeft:
					case ScreenPosition.BottomLeft:
						zero.X = 0.0;
						break;
					case ScreenPosition.TopCenter:
					case ScreenPosition.MidCenter:
					case ScreenPosition.BottomCenter:
						zero.X = (x - (double)displayPref.ScreenWidth) / 2.0;
						break;
					case ScreenPosition.TopRight:
					case ScreenPosition.MidRight:
					case ScreenPosition.BottomRight:
						zero.X = x - (double)displayPref.ScreenWidth;
						break;
					}
					switch (displayPref?.ScreenPosition)
					{
					case ScreenPosition.TopLeft:
					case ScreenPosition.TopCenter:
					case ScreenPosition.TopRight:
						zero.Y = 0.0;
						break;
					case ScreenPosition.MidLeft:
					case ScreenPosition.MidCenter:
					case ScreenPosition.MidRight:
						zero.Y = (y - (double)displayPref.ScreenHeight) / 2.0;
						break;
					case ScreenPosition.BottomLeft:
					case ScreenPosition.BottomCenter:
					case ScreenPosition.BottomRight:
						zero.Y = y - (double)displayPref.ScreenHeight;
						break;
					}
					Vector2<double>? vector2 = displayPref?.ScreenSize.Cast<double>();
					if (vector2.HasValue)
					{
						screen.MainOutput.Subrect = new Rect<double>(zero, vector2.Value);
					}
					screen.CornerPinning.IsEnabled = displayPref?.IsCornerPinningEnabled ?? false;
					if (screenCornerPins != null)
					{
						screen.CornerPinning.TopLeft = Vector2<double>.Zero - screenCornerPins.TopLeft.Cast<double>();
						screen.CornerPinning.TopRight = new Vector2<double>((double)screenCornerPins.TopRight.X - (vector2?.X ?? 0.0), -screenCornerPins.TopRight.Y);
						screen.CornerPinning.BottomLeft = new Vector2<double>(-screenCornerPins.BottomLeft.X, (double)screenCornerPins.BottomLeft.Y - (vector2?.Y ?? 0.0));
						screen.CornerPinning.BottomRight = new Vector2<double>((double)screenCornerPins.TopRight.X - (vector2?.X ?? 0.0), (double)screenCornerPins.BottomLeft.Y - (vector2?.Y ?? 0.0));
					}
				}
				outputConfiguration.AudienceArrangementScreens.AddScreenArrangement(singleScreenArrangement);
				outputConfiguration.AudienceArrangementScreens.Reverse().Skip(1).AsEnumerable()
					.ForEach(outputConfiguration.AudienceArrangementScreens.RemoveScreen);
			}
		}
		if (physicalDevice != null)
		{
			SingleScreenArrangement singleScreenArrangement2 = new SingleScreenArrangement(ScreenTargetType.Stage, null, 1, null)
			{
				Name = outputConfiguration.StageArrangementScreens.DefaultScreenArrangementName
			};
			Screen[] screens = singleScreenArrangement2.Screens;
			for (int j = 0; j < screens.Length; j++)
			{
				screens[j].MainOutput.OutputDevice = physicalDevice;
			}
			outputConfiguration.StageArrangementScreens.AddScreenArrangement(singleScreenArrangement2);
			outputConfiguration.StageArrangementScreens.Reverse().Skip(1).AsEnumerable()
				.ForEach(outputConfiguration.StageArrangementScreens.RemoveScreen);
		}
	}

	private static void MigrateGeneral(RVPreferencesGeneral generalPref)
	{
		if (generalPref != null)
		{
			General.Settings.EnableCrashReporting = !generalPref.DisableCrashReport;
			General.Settings.LogoFilename = generalPref.LogoPath ?? string.Empty;
			General.Settings.PreserveLogoAspect = generalPref.LogoPreserveAspectRatio;
			if (DataVault.CCLIPresentation != null)
			{
				DataVault.CCLIPresentation.Display = generalPref.EnableCCLIDisplay;
				DataVault.CCLIPresentation.DisplayType = generalPref.CCLIDisplayPosition.ToCCLIDisplayType();
				DataVault.CCLIPresentation.License = generalPref.CCLINumber ?? string.Empty;
			}
			Advanced.Settings.ManageMediaAutomatically = generalPref.ManageMediaAutomatically;
		}
	}

	private static void MigrateLabel(RVPreferencesLabels labelPref)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (labelPref == null)
		{
			return;
		}
		GroupLabelCollection groupLabels = DataVault.GroupLabels;
		SlideLabelCollection slideLabels = DataVault.SlideLabels;
		IEnumerable<KeyValuePair<string, Color>> defaultGroupLabels = MigrationHelper.DefaultGroupLabels;
		IEnumerable<KeyValuePair<string, Color>> defaultSlideLabels = MigrationHelper.DefaultSlideLabels;
		groupLabels?.Reset();
		slideLabels?.Reset();
		string text;
		Color color;
		Key key;
		if (labelPref.GroupLabels != null)
		{
			foreach (RVColoredLabel groupLabel2 in labelPref.GroupLabels)
			{
				groupLabel2.Deconstruct(out text, out color, out key);
				string text2 = text;
				Color color2 = color;
				Key key2 = key;
				if (!defaultGroupLabels.Any((KeyValuePair<string, Color> l) => l.Key.Equals(text2, StringComparison.OrdinalIgnoreCase) && l.Value == color2 && (int)key2 == 0))
				{
					GroupLabel newLabel = new GroupLabel(text2, color2, new Pro.DO.Hotkey(key2));
					GroupLabel groupLabel = groupLabels?.FirstOrDefault((GroupLabel l) => l.Text?.Equals(text2, StringComparison.OrdinalIgnoreCase) ?? false);
					if (groupLabel != null)
					{
						groupLabels.Replace(groupLabel, newLabel);
					}
				}
			}
		}
		if (labelPref.SlideLabels == null)
		{
			return;
		}
		foreach (RVColoredLabel slideLabel in labelPref.SlideLabels)
		{
			slideLabel.Deconstruct(out text, out color, out key);
			string text3 = text;
			Color color3 = color;
			if (!defaultSlideLabels.Any((KeyValuePair<string, Color> l) => l.Key.Equals(text3, StringComparison.OrdinalIgnoreCase) && l.Value == color3))
			{
				ActionLabel newLabel2 = new ActionLabel(text3, color3);
				ActionLabel actionLabel = slideLabels?.FirstOrDefault((ActionLabel l) => l.Text?.Equals(text3, StringComparison.OrdinalIgnoreCase) ?? false);
				if (actionLabel != null)
				{
					slideLabels.Replace(actionLabel, newLabel2);
				}
			}
		}
	}

	private static void MigrateLiveVideo(RVPreferencesLiveVideo liveVideoPref)
	{
		if (liveVideoPref != null && OutputVault.AvailableLiveVideoInputs != null)
		{
			OutputVault.AvailableLiveVideoInputs.InputCount = 1;
			LiveVideoInput liveVideoInput = OutputVault.AvailableLiveVideoInputs[0];
			liveVideoInput.VideoDevice = OutputVault.VideoInputDeviceCollection?.FirstOrDefault((IVideoInputDevice d) => d.Name.Equals(liveVideoPref.SelectedSSVideoInputDevice?.DeviceName));
			liveVideoInput.VideoMode = liveVideoInput.VideoDevice?.Modes?.ElementAtOrDefault(liveVideoInput.VideoDevice.Modes.ClampIndexExclusive(liveVideoPref.SelectedSSVideoInputDevice?.ModeIndex ?? 0));
		}
	}

	private static void MigrateMultiScreen(RVPreferencesMultiScreen? multiScreenPref, IOutputConfiguration outputConfiguration)
	{
		if (multiScreenPref == null || outputConfiguration == null)
		{
			return;
		}
		outputConfiguration.AudienceLooks.ToArray().ForEach(outputConfiguration.AudienceLooks.Remove);
		if (multiScreenPref.Configurations == null)
		{
			return;
		}
		foreach (RVMultiScreenConfiguration configuration in multiScreenPref.Configurations)
		{
			AudienceLook audienceLook = outputConfiguration.AudienceLooks.Add(configuration.Name ?? string.Empty);
			bool[] array = ParseScreenPosition(configuration.LiveVideoScreenPosition ?? string.Empty);
			bool[] array2 = ParseScreenPosition(configuration.PropScreenPosition ?? string.Empty);
			bool[] array3 = ParseScreenPosition(configuration.SlideScreenPosition ?? string.Empty);
			bool[] array4 = ParseScreenPosition(configuration.VideoImageScreenPosition ?? string.Empty);
			Guid[] array5 = new Guid[3] { configuration.LeftScreenTemplateId, configuration.CenterScreenTemplateId, configuration.RightScreenTemplateId };
			for (int i = 0; i < audienceLook.ScreenLooks.Count; i++)
			{
				ScreenLook screenLook = audienceLook.ScreenLooks[i];
				screenLook.LiveVideoEnabled = array[i];
				screenLook.PropsEnabled = array2[i];
				screenLook.ForegroundEnabled = array3[i];
				screenLook.BackgroundEnabled = array4[i];
				TemplateSlide templateSlide = DataVault.Themes?.FindTemplate(array5[i]);
				if (templateSlide != null)
				{
					screenLook.UpdateTemplate(templateSlide);
				}
				else
				{
					screenLook.UpdateTemplate(null);
				}
			}
		}
	}

	private static bool[] ParseScreenPosition(string positionStr)
	{
		if (!positionStr.Equals("All"))
		{
			string[] array = positionStr.Split(' ');
			if (array.Length == 1)
			{
				if (array[0].Equals("Left"))
				{
					return new bool[3] { true, false, false };
				}
				if (array[0].Equals("Center"))
				{
					return new bool[3] { false, true, false };
				}
				if (array[0].Equals("Right"))
				{
					return new bool[3] { false, false, true };
				}
			}
			else if (array.Length == 2)
			{
				bool[] array2 = new bool[3];
				foreach (string text in array)
				{
					if (text.Equals("Left"))
					{
						array2[0] = true;
					}
					else if (text.Equals("Center"))
					{
						array2[1] = true;
					}
					else if (text.Equals("Right"))
					{
						array2[2] = true;
					}
				}
				return array2;
			}
			return new bool[3] { true, true, true };
		}
		return new bool[3] { true, true, true };
	}

	private void MigrateNetwork(RVPreferencesNetwork network)
	{
		if (network != null)
		{
			StoredPcoOptions.Settings.AutoPlanUpdate = network.CheckPlanUpdatesMode?.Equals("Auto") ?? false;
			StoredPcoOptions.Settings.AutoDownload = network.DownloadDocumentsMode?.Equals("Auto") ?? false;
			StoredPcoOptions.Settings.AutoUpload = network.UploadDocumentsMode?.Equals("Auto") ?? false;
			StoredPcoOptions.Settings.ShowHistoricalPlans = network.ShowHistoricalPlans;
			StoredPcoOptions.Settings.MatchSongs = network.MatchSongsInLibrary;
			StoredPcoOptions.Settings.ArrangementFromSequences = network.MakeArrangementsFromSeq;
			_network.EnableNetwork = network.IsProNetworkEnabled;
			_network.NetworkName = network.ProNetworkName ?? string.Empty;
			_network.NetworkPort = network.ProNetworkPort;
			_network.EnableMasterControl = network.IsMasterControlEnabled;
			_network.EnableRemoteStageDisplay = network.RemoteStageDisplayEnable;
			_network.RemoteStageDisplayPassword = network.RemoteStageDisplayPassword ?? string.Empty;
		}
	}

	private static void MigrateSync(RVPreferencesSynchronization sync)
	{
		if (sync != null)
		{
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncSource = sync.Source ?? string.Empty;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeLibraryDoc = sync.SyncLibrary;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeMedia = sync.SyncMedia;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludePlaylists = sync.SyncPlaylists;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncIncludeTemplates = sync.SyncTemplates;
			ProPresenter.DO.Settings.Sync.Settings.ReplaceFiles = sync.ReplaceFiles;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncDown = sync.SyncMode?.Equals("UpdateClient") ?? false;
			ProPresenter.DO.Settings.Sync.Settings.LocalSyncUp = sync.SyncMode?.Equals("UpdateServer") ?? false;
		}
	}

	private static void MigrateSDI(RVPreferencesSDI sdi)
	{
		if (sdi != null)
		{
			Advanced.Settings.IgnoreBackgroundColors = sdi.IgnoreBackgroundColors;
		}
	}

	public void AbortMigration()
	{
		_importProcess?.CancelImport();
	}
}
