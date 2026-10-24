using System.Collections.Generic;
using System.Linq;

namespace Pro.Common.FeatureFlag;

public static class FlagExtensions
{
	public static bool GetDefaultValue(this Flag flag)
	{
		return flag switch
		{
			Flag.ServerDrivenFeatureFlags => true, 
			Flag.TestDefaultEnabled => true, 
			_ => false, 
		};
	}

	public static IReadOnlyList<string> Serialize(this IReadOnlyList<Flag> flags)
	{
		return (from s in flags.Select(GetSerializationKey)
			where !string.IsNullOrWhiteSpace(s)
			select s).ToArray();
	}

	public static string GetSerializationKey(this Flag flag)
	{
		return flag switch
		{
			Flag.CreateFullMemoryDumps => "create-full-memory-dumps", 
			Flag.StagingApiEndpoints => "use-staging-api", 
			Flag.ResiTestApis => "use-resi-test-api", 
			Flag.SimulateCrashOnStartup => "crash-on-startup", 
			Flag.ShowCrashUiOnStartup => "show-crash-ui-on-startup", 
			Flag.LogExternalBrowserUrls => "log-urls-opened-in-external-browser", 
			Flag.ShowLocalizationKeys => "show-localization-keys", 
			Flag.CoreNetworkapiPlaylist => "core-networkapi-playlist", 
			Flag.CoreNetworkapiPresentation => "core-networkapi-presentation", 
			Flag.RegistrationInteractionLogging => "enable-core-registration-logging", 
			Flag.ServerDrivenFeatureFlags => "server-driven-feature-flags", 
			Flag.FontSync => "font-sync", 
			Flag.Cloud => "cloud", 
			Flag.CloudWorkspaces => "cloud-workspaces", 
			Flag.CloudComingSoon => "cloud-coming-soon", 
			Flag.CloudDiagnostics => "collaboration-debug-mode", 
			Flag.TestDefaultEnabled => "test-default-enabled", 
			_ => string.Empty, 
		};
	}

	public static IReadOnlyList<Flag> Deserialize(this IReadOnlyList<string> flags)
	{
		return flags.Select(Deserialize).Distinct().ToArray();
	}

	private static Flag Deserialize(this string flag)
	{
		return flag switch
		{
			"create-full-memory-dumps" => Flag.CreateFullMemoryDumps, 
			"use-staging-api" => Flag.StagingApiEndpoints, 
			"use-resi-test-api" => Flag.ResiTestApis, 
			"crash-on-startup" => Flag.SimulateCrashOnStartup, 
			"show-crash-ui-on-startup" => Flag.ShowCrashUiOnStartup, 
			"log-urls-opened-in-external-browser" => Flag.LogExternalBrowserUrls, 
			"show-localization-keys" => Flag.ShowLocalizationKeys, 
			"core-networkapi-playlist" => Flag.CoreNetworkapiPlaylist, 
			"core-networkapi-presentation" => Flag.CoreNetworkapiPresentation, 
			"enable-core-registration-logging" => Flag.RegistrationInteractionLogging, 
			"server-driven-feature-flags" => Flag.ServerDrivenFeatureFlags, 
			"font-sync" => Flag.FontSync, 
			"cloud" => Flag.Cloud, 
			"cloud-workspaces" => Flag.CloudWorkspaces, 
			"cloud-coming-soon" => Flag.CloudComingSoon, 
			"collaboration-debug-mode" => Flag.CloudDiagnostics, 
			"test-default-enabled" => Flag.TestDefaultEnabled, 
			_ => Flag.CreateFullMemoryDumps, 
		};
	}

	public static IReadOnlyList<string> GetEnabledKeys(this IEnumerable<string> flags)
	{
		return flags.SelectMany(GetEnabledKeysForKey).Distinct().ToArray();
	}

	private static string[] GetEnabledKeysForKey(this string flag)
	{
		if (flag == "cloud")
		{
			return new string[2] { "cloud", "cloud-workspaces" };
		}
		return new string[1] { flag };
	}

	public static IEnumerable<Flag> GetOverwrittenFlags(this IEnumerable<string> flags)
	{
		return flags.SelectMany(GetOverwrittenFlagsFor).Distinct();
	}

	private static IEnumerable<Flag> GetOverwrittenFlagsFor(this string flag)
	{
		if (flag == "cloud")
		{
			return new string[1] { "cloud-workspaces" }.Select(Deserialize);
		}
		return Enumerable.Empty<Flag>();
	}
}
