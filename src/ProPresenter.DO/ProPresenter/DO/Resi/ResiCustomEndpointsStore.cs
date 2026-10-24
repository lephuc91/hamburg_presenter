using System.IO.Abstractions;
using Pro.Common.DataStore;

namespace ProPresenter.DO.Resi;

public class ResiCustomEndpointsStore : StoreBase, IResiCustomEndpointsStore
{
	private const string SettingsFile = "ResiCustomEndpoints.proPref";

	public string? MoreInfo => GetValue<string>("MoreInfo");

	public string? Support => GetValue<string>("Support");

	public string? HomePage => GetValue<string>("HomePage");

	public string? ManageAccount => GetValue<string>("ManageAccount");

	public string? Login => GetValue<string>("Login");

	public string? Logout => GetValue<string>("Logout");

	public string? DownloadPlugin => GetValue<string>("DownloadPlugin");

	public ResiCustomEndpointsStore(IFileSystem fileSystem, string preferencesPath)
		: base(fileSystem.Path.Combine(preferencesPath, "ResiCustomEndpoints.proPref"))
	{
	}
}
