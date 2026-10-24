using System;
using Pro.Common.Versioning;
using Pro.DO.Utility;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Application;

public class ApplicationData
{
	public ApplicationType ApplicationType { get; }

	public PlatformType PlatformType { get; }

	public System.Version? ApplicationVersion { get; }

	public System.Version? OSVersion { get; }

	public ApplicationData(ApplicationType applicationType)
		: this(applicationType, PlatformType.Win32, VersionInfo.AppVersion, VersionInfo.OSVersion)
	{
	}

	public ApplicationData(ApplicationType applicationType, PlatformType platformType, System.Version applicationVersion, System.Version osVersion)
	{
		ApplicationType = applicationType;
		PlatformType = platformType;
		ApplicationVersion = applicationVersion;
		OSVersion = osVersion;
	}

	public ApplicationInfo Serialize()
	{
		return new ApplicationInfo
		{
			Application = GetProtoApplicationType(ApplicationType),
			ApplicationVersion = ApplicationVersion?.ToProtoVersion(),
			PlatformVersion = OSVersion?.ToProtoVersion(),
			Platform = GetProtoPlatformType(PlatformType)
		};
	}

	public static ApplicationData? Deserialize(ApplicationInfo? protoApplicationInfo)
	{
		if (protoApplicationInfo == null)
		{
			return null;
		}
		return new ApplicationData(GetApplicationType(protoApplicationInfo.Application), GetPlatformType(protoApplicationInfo.Platform), protoApplicationInfo.ApplicationVersion.ToVersion(), protoApplicationInfo.PlatformVersion.ToVersion());
	}

	private static ApplicationInfo.Types.Application GetProtoApplicationType(ApplicationType applicationType)
	{
		return applicationType switch
		{
			ApplicationType.ProPresenter => ApplicationInfo.Types.Application.Propresenter, 
			ApplicationType.Unknown => ApplicationInfo.Types.Application.Undefined, 
			_ => throw new NotSupportedException(), 
		};
	}

	private static ApplicationType GetApplicationType(ApplicationInfo.Types.Application protoApplicationType)
	{
		if (protoApplicationType != 0 && protoApplicationType == ApplicationInfo.Types.Application.Propresenter)
		{
			return ApplicationType.ProPresenter;
		}
		return ApplicationType.Unknown;
	}

	public static ApplicationInfo.Types.Platform GetProtoPlatformType(PlatformType platformType)
	{
		return platformType switch
		{
			PlatformType.MacOS => ApplicationInfo.Types.Platform.Macos, 
			PlatformType.Win32 => ApplicationInfo.Types.Platform.Windows, 
			_ => ApplicationInfo.Types.Platform.Undefined, 
		};
	}

	public static PlatformType GetPlatformType(ApplicationInfo.Types.Platform protoPlatformType)
	{
		return protoPlatformType switch
		{
			ApplicationInfo.Types.Platform.Macos => PlatformType.MacOS, 
			ApplicationInfo.Types.Platform.Windows => PlatformType.Win32, 
			ApplicationInfo.Types.Platform.Undefined => PlatformType.Unknown, 
			_ => throw new NotSupportedException(), 
		};
	}
}
