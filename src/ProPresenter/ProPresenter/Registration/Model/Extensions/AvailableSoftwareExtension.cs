using System;
using System.Linq;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.Model;

namespace ProPresenter.Registration.Model.Extensions;

public static class AvailableSoftwareExtension
{
	public static AvailableSoftware ToAvailableSoftware(this UpgradesAvailable upgrade, Version? currentVersion = null)
	{
		return new AvailableSoftware(upgrade.ReleaseNotes, upgrade.IsNonProductionActive, (from u in upgrade.Upgrades
			orderby u.BuildNumber descending
			select u into build
			select build.ToBuildInformation(currentVersion)).ToArray());
	}
}
