using System;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.Win32;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Versioning;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data;

public class ApplicationDataFileBuilder : IBuildAppMetaDataFile
{
	private readonly IOutputService _outputService;

	private readonly ILogger _logger;

	private readonly IGeneral _generalSettings;

	private readonly IVersionInfoProvider _versionInfoProvider;

	private readonly IAssemblyInfoProvider _assemblyInfoProvider;

	private readonly IFileSystem _fileSystem;

	private readonly IFlagService _flagService;

	private readonly string _filePath;

	private const string FILE_NAME = "AppMetadata.json";

	public string FileName => _fileSystem.Path.Combine(_filePath, "AppMetadata.json");

	public ApplicationDataFileBuilder(IOutputService outputService, IFileSystem fileSystem, ILogger logger, IGeneral generalSettings, IVersionInfoProvider versionInfoProvider, IAssemblyInfoProvider assemblyInfoProvider, IFlagService flagService)
	{
		_outputService = outputService;
		_fileSystem = fileSystem;
		_logger = logger;
		_generalSettings = generalSettings;
		_versionInfoProvider = versionInfoProvider;
		_assemblyInfoProvider = assemblyInfoProvider;
		_flagService = flagService;
		_filePath = _fileSystem.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RenewedVision", "ProPresenter");
	}

	public async Task BuildAppMetaDataFile()
	{
		await Task.Run(delegate
		{
			try
			{
				UserFeedback.Types.ApplicationMetadata applicationMetadata = new UserFeedback.Types.ApplicationMetadata
				{
					OsVersion = GetOsName(),
					ApplicationVersion = _versionInfoProvider.FullDisplayAppVersion
				};
				applicationMetadata.ApplicationInstances.Add(new UserFeedback.Types.ApplicationMetadata.Types.ApplicationInstance
				{
					Path = _assemblyInfoProvider.Location,
					Version = _versionInfoProvider.FullDisplayAppVersion
				});
				applicationMetadata.CrashReportingEnabled = _generalSettings.EnableCrashReporting;
				applicationMetadata.AnalyticsReportingEnabled = _generalSettings.EnableAnalytics;
				applicationMetadata.EnabledFeatureFlags.AddRange(_flagService.LaunchEnabledKeys);
				AddBMDData(applicationMetadata);
				AddDisplayData(applicationMetadata, _outputService);
				SaveDataToFile(applicationMetadata);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}
		});
	}

	private void AddDisplayData(UserFeedback.Types.ApplicationMetadata proto, IOutputService outputService)
	{
		if (outputService == null)
		{
			return;
		}
		var source = outputService.OutputConfiguration.ArrangementScreens.SelectMany((ScreenArrangementBase s) => s.Screens.Select((ProPresenter.DO.OutputConfiguration.Screen o) => new
		{
			Screen = s,
			Output = o
		}));
		proto.Screens.AddRange(source.Select(item => new UserFeedback.Types.ApplicationMetadata.Types.Screen
		{
			Name = item.Screen.Name,
			OutputName = item.Output.OutputName,
			Resolution = new UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Resolution
			{
				Height = (uint)item.Output.OutputSize.Y,
				Width = (uint)item.Output.OutputSize.X
			},
			Type = ((item.Screen.ScreenTargetType == ScreenTargetType.Audience) ? UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Type.Audience : UserFeedback.Types.ApplicationMetadata.Types.Screen.Types.Type.Stage)
		}));
	}

	private void AddBMDData(UserFeedback.Types.ApplicationMetadata proto)
	{
		string text = string.Empty;
		using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Blackmagic Design\\DeckLink", writable: false))
		{
			text = registryKey?.GetValue("Location")?.ToString();
		}
		if (!string.IsNullOrEmpty(text))
		{
			text = Path.Combine(text, "Decklink64.dll");
			if (File.Exists(text))
			{
				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text);
				proto.BlackmagicDesktopVideoInstances.Add(new UserFeedback.Types.ApplicationMetadata.Types.ApplicationInstance
				{
					Path = text,
					Version = versionInfo.ProductVersion + " (" + versionInfo.FileVersion + ")"
				});
			}
		}
	}

	private void SaveDataToFile(UserFeedback.Types.ApplicationMetadata proto)
	{
		JsonFormatter.Settings settings = JsonFormatter.Settings.Default.WithPreserveProtoFieldNames(preserveProtoFieldNames: true).WithIndentation("\t");
		_fileSystem.Directory.CreateDirectory(_filePath);
		_fileSystem.File.WriteAllText(FileName, new JsonFormatter(settings).Format(proto));
	}

	private string GetOsName()
	{
		string value = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>().First()["Caption"].ToString();
		return $"{value} {(Environment.Is64BitProcess ? "64 bit" : "32 bit")} ({_versionInfoProvider.OSVersion.Major}.{_versionInfoProvider.OSVersion.Minor}, Build {_versionInfoProvider.OSVersion.Build})";
	}
}
