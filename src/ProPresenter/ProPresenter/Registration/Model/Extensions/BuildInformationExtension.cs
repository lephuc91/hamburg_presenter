using System;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.Registration.Model.Extensions;

public static class BuildInformationExtension
{
	public static ProPresenter.DO.Registration.Model.BuildInformation ToBuildInformation(this Pro.SerializationInterop.RVProtoData.Registration.BuildInformation buildInformation, Version? currentVersion)
	{
		return new ProPresenter.DO.Registration.Model.BuildInformation(buildInformation.BuildNumber, buildInformation.Version, buildInformation.MinOsVersion, buildInformation.DownloadUrl, buildInformation.IsBeta, buildInformation.IsAvailable, (object)currentVersion != null && buildInformation.BuildNumber < currentVersion.Build);
	}

	public static ProPresenter.DO.Registration.Model.BuildInformation ToBuildInformation(this Pro.SerializationInterop.RVProtoData.Registration.BuildInformation buildInformation, bool isDowngrade)
	{
		return new ProPresenter.DO.Registration.Model.BuildInformation(buildInformation.BuildNumber, buildInformation.Version, buildInformation.MinOsVersion, buildInformation.DownloadUrl, buildInformation.IsBeta, buildInformation.IsAvailable, isDowngrade);
	}
}
