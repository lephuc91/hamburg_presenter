using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProPresenter.DO.Registration.Model;

public record AvailableSoftware(string ReleaseNotes, bool IsNonProductionActive, BuildInformation[] BuildInformation)
{
	public static AvailableSoftware Empty { get; } = new AvailableSoftware(string.Empty, IsNonProductionActive: false, Array.Empty<BuildInformation>());

	public override string ToString()
	{
		return $"{"AvailableSoftware"} {{ {"ReleaseNotes"} = {ReleaseNotes}, {"IsNonProductionActive"} = {IsNonProductionActive}, {"BuildInformation"} = [{string.Join(", ", BuildInformation.Select((BuildInformation b) => b.ToString()))}] }}";
	}

	[CompilerGenerated]
	protected AvailableSoftware(AvailableSoftware original)
	{
		ReleaseNotes = original.ReleaseNotes;
		IsNonProductionActive = original.IsNonProductionActive;
		BuildInformation = original.BuildInformation;
	}
}
