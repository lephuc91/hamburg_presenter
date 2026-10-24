using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.Versioning;
using Pro.Localization.Services;
using Pro.Reporting;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Registration.Model;
using ProPresenter.DO.Registration.State;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Analytics;

public class ApplicationLaunchEventPublisher(IRegistrationStateProvider registrationStateProvider, ISystemInfoProvider systemInfoProvider, IApp app, IVersionInfoProvider versionInfoProvider, ILocalization localization, IFlagService flagService) : IApplicationLaunchEventPublisher
{
	public async Task PublishApplicationLaunchEvent()
	{
		Task<SystemData> systemDataTask = systemInfoProvider.CreateSystemDataAsync();
		Task<string?> blackmagicDesktopVideoVersionTask = GetBlackMagicDesktopVideoVersionAsync();
		global::_003C_003Ey__InlineArray2<Task> buffer = default(global::_003C_003Ey__InlineArray2<Task>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task>, Task>(ref buffer, 0) = systemDataTask;
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task>, Task>(ref buffer, 1) = blackmagicDesktopVideoVersionTask;
		await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<Task>, Task>(in buffer, 2));
		SystemData systemData = await systemDataTask;
		string hardwareFingerprint = registrationStateProvider.HardwareInformation.HardwareFingerprint;
		string shortDisplayAppVersion = versionInfoProvider.ShortDisplayAppVersion;
		string osVersion = Environment.OSVersion.Version.ToString();
		string buildNumber = versionInfoProvider.AppVersion.Build.ToString();
		UpdateChannel updateChannel = app.UpdateChannel;
		string hardwareModel = systemData.Manufacturer + " " + systemData.Model;
		ulong totalPhysicalMemoryBytes = systemData.TotalPhysicalMemoryBytes;
		string gpuName = systemData.GpuName;
		ulong gpuRamBytes = systemData.GpuRamBytes;
		ApplicationLaunchEvent.Publish(hardwareFingerprint, shortDisplayAppVersion, osVersion, buildNumber, updateChannel, hardwareModel, totalPhysicalMemoryBytes, gpuName, gpuRamBytes, (await blackmagicDesktopVideoVersionTask) ?? string.Empty, localization.LoadedCulture, flagService.LaunchEnabledKeys, registrationStateProvider.OrganizationId);
	}

	private static Task<string?> GetBlackMagicDesktopVideoVersionAsync()
	{
		return Task.Run(delegate
		{
			try
			{
				string[] array = new string[2] { "SOFTWARE\\Blackmagic Design\\Blackmagic Desktop Video", "SOFTWARE\\WOW6432Node\\Blackmagic Design\\Blackmagic Desktop Video" };
				foreach (string name in array)
				{
					using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name);
					string text = registryKey?.GetValue("Version") as string;
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
				array = new string[3] { "SOFTWARE\\Blackmagic Design\\DeckLink", "SOFTWARE\\Blackmagic Design\\Blackmagic Desktop Video", "SOFTWARE\\WOW6432Node\\Blackmagic Design\\Blackmagic Desktop Video" };
				foreach (string name2 in array)
				{
					using RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(name2);
					if (registryKey2?.GetValue("Location") is string path)
					{
						string text2 = Path.Combine(path, "DeckLink64.dll");
						if (File.Exists(text2))
						{
							FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text2);
							return versionInfo.ProductVersion ?? versionInfo.FileVersion;
						}
					}
				}
				array = new string[2]
				{
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Blackmagic Design", "Blackmagic Desktop Video", "DeckLink64.dll"),
					Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Blackmagic Design", "Blackmagic Desktop Video", "DeckLink.dll")
				};
				foreach (string text3 in array)
				{
					if (File.Exists(text3))
					{
						FileVersionInfo versionInfo2 = FileVersionInfo.GetVersionInfo(text3);
						return versionInfo2.ProductVersion ?? versionInfo2.FileVersion ?? string.Empty;
					}
				}
			}
			catch (Exception value)
			{
				Log.Error($"{"GetBlackMagicDesktopVideoVersionAsync"} : {value}");
			}
			return string.Empty;
		});
	}
}
