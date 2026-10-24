using System;

namespace Pro.Common.Versioning;

[AttributeUsage(AttributeTargets.Assembly)]
public class ReportingAttribute : Attribute
{
	public bool EnableAnalytics { get; }

	public bool EnableCrashReporting { get; }

	public ReportingAttribute(bool enableAnalytics, bool enableCrashReporting)
	{
		EnableAnalytics = enableAnalytics;
		EnableCrashReporting = enableCrashReporting;
	}
}
