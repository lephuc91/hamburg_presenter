using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Pro.Common.Versioning;

public class VersionInfoProvider : IVersionInfoProvider
{
	public Version AppVersion { get; }

	public string ShortDisplayAppVersion { get; }

	public string FullDisplayAppVersion { get; }

	public string CommitHash { get; }

	public Version OSVersion { get; }

	public DateTime BuildDate { get; }

	public bool EnableAnalytics { get; }

	public bool EnableCrashReporting { get; }

	public DateTime InstallDate { get; }

	public VersionInfoProvider(IAssemblyInfoProvider assembly, Version osVersion)
	{
		AppVersion = GetAppVersion(assembly);
		FullDisplayAppVersion = GetFullDisplayAppVersion(AppVersion, assembly);
		BuildDate = GetBuildDate(assembly);
		ShortDisplayAppVersion = AppVersion.ToShortDisplayAppString();
		CommitHash = assembly.GetCustomAttribute<GitCommitAttribute>()?.Hash ?? "4b825dc642cb6eb9a060e54bf8d69288fbee4904";
		OSVersion = osVersion;
		ReportingAttribute customAttribute = assembly.GetCustomAttribute<ReportingAttribute>();
		EnableAnalytics = customAttribute?.EnableAnalytics ?? false;
		EnableCrashReporting = customAttribute?.EnableCrashReporting ?? false;
		try
		{
			if (File.Exists(assembly.Location))
			{
				InstallDate = File.GetLastWriteTime(assembly.Location);
			}
		}
		catch
		{
		}
	}

	private static string GetFullDisplayAppVersion(Version appVersion, IAssemblyInfoProvider assembly)
	{
		return assembly?.GetCustomAttribute<DisplayVersionAttribute>()?.Text ?? assembly?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"{appVersion.Major}.{appVersion.Minor}{((appVersion.Revision <= 0) ? "" : $".{appVersion.Revision}")} ({appVersion.Build})";
	}

	private static Version GetAppVersion(IAssemblyInfoProvider assembly)
	{
		Version version = assembly.Version ?? new Version();
		return new Version(version.Major, version.Minor, assembly.GetCustomAttribute<BuildNumberAttribute>()?.Value ?? Math.Max(version.Revision, 0), Math.Max(version.Build, 0));
	}

	private static DateTime GetBuildDate(IAssemblyInfoProvider assembly)
	{
		if (!DateTime.TryParse(assembly.GetCustomAttribute<BuildDateAttribute>()?.Date, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
		{
			return DateTime.MaxValue;
		}
		return result;
	}
}
