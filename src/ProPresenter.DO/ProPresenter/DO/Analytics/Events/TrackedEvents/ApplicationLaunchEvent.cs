using System;
using System.Collections.Generic;
using System.Globalization;
using Google.Protobuf;
using Pro.DO.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics;
using Pro.SerializationInterop.RVProtoData.Analytics.TrackedEvents;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents;

public record ApplicationLaunchEvent(string HardwareId, string AppVersion, string OsVersion, string BuildNumber, UpdateChannel UpdateChannel, string HardwareModel, ulong PhysicalMemory, string VideoController, ulong VideoControllerRam, string BlackmagicDesktopVersion, CultureInfo? LoadedLanguage, IReadOnlyCollection<string> EnabledFeatureFlags, string OrganizationId) : IAnalyticEvent
{
	public static void Publish(string hardwareId, string appVersion, string osVersion, string buildNumber, UpdateChannel updateChannel, string hardwareModel, ulong physicalMemory, string videoController, ulong videoControllerRam, string blackmagicDesktopVersion, CultureInfo? loadedLanguage, IReadOnlyCollection<string> enabledFeatureFlags, string organizationId)
	{
		EventPublisher.Publish(new ApplicationLaunchEvent(hardwareId, appVersion, osVersion, buildNumber, updateChannel, hardwareModel, physicalMemory, videoController, videoControllerRam, blackmagicDesktopVersion, loadedLanguage, enabledFeatureFlags, organizationId));
	}

	public IMessage Serialize()
	{
		return ProtoEventExtensions.Build(delegate(Event e)
		{
			ApplicationLaunch applicationLaunch = new ApplicationLaunch
			{
				HardwareId = HardwareId,
				AppVersion = AppVersion,
				OsVersion = OsVersion,
				BuildNumber = BuildNumber,
				Platform = ApplicationLaunch.Types.Platform.Windows,
				Language = (LoadedLanguage?.EnglishName ?? "(not loaded)"),
				Location = RegionInfo.CurrentRegion.EnglishName,
				HardwareModel = HardwareModel,
				PhysicalMemory = PhysicalMemory,
				VideoController = VideoController,
				VideoControllerRam = VideoControllerRam,
				BlackmagicDesktopVersion = BlackmagicDesktopVersion
			};
			ApplicationLaunch applicationLaunch2 = applicationLaunch;
			applicationLaunch2.Channel = UpdateChannel switch
			{
				UpdateChannel.Beta => ApplicationLaunch.Types.Channel.Beta, 
				UpdateChannel.Production => ApplicationLaunch.Types.Channel.Release, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			ApplicationLaunch applicationLaunch3 = applicationLaunch;
			foreach (string enabledFeatureFlag in EnabledFeatureFlags)
			{
				applicationLaunch3.EnabledFeatureFlags.Add(enabledFeatureFlag);
			}
			if (!string.IsNullOrEmpty(OrganizationId))
			{
				applicationLaunch3.OrganizationId = OrganizationId;
			}
			e.ApplicationLaunch = applicationLaunch3;
		});
	}
}
