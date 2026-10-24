using System;

namespace Pro.Common.Versioning;

public interface IVersionInfoProvider
{
	Version AppVersion { get; }

	string ShortDisplayAppVersion { get; }

	string FullDisplayAppVersion { get; }

	string CommitHash { get; }

	Version OSVersion { get; }

	DateTime BuildDate { get; }

	bool EnableAnalytics { get; }

	bool EnableCrashReporting { get; }

	DateTime InstallDate { get; }
}
