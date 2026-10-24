using System;

namespace Pro.Common.Versioning;

public static class VersionInfo
{
	private static IVersionInfoProvider? _versionInfoProvider;

	public static Version AppVersion => _versionInfoProvider?.AppVersion ?? new Version();

	public static string ShortDisplayAppVersion => _versionInfoProvider?.ShortDisplayAppVersion ?? string.Empty;

	public static string FullDisplayAppVersion => _versionInfoProvider?.FullDisplayAppVersion ?? string.Empty;

	public static string CommitHash => _versionInfoProvider?.CommitHash ?? string.Empty;

	public static Version OSVersion => _versionInfoProvider?.OSVersion ?? new Version();

	public static DateTime BuildDate => _versionInfoProvider?.BuildDate ?? DateTime.MaxValue;

	public static bool EnableAnalytics => _versionInfoProvider?.EnableAnalytics ?? false;

	public static bool EnableCrashReporting => _versionInfoProvider?.EnableCrashReporting ?? false;

	public static DateTime InstallDate => _versionInfoProvider?.InstallDate ?? DateTime.MaxValue;

	public static void SetVersionInfoProvider(IVersionInfoProvider versionInfoProvider)
	{
		_versionInfoProvider = versionInfoProvider;
	}
}
