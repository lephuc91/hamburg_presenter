namespace ProPresenter.DO.Settings.AdvancedSettings;

public class LocalFolderRequestParameters
{
	public CloudFolder CloudLibrary { get; }

	public string Path { get; }

	public LocalFolderRequestParameters(string path, CloudFolder cloudLibrary)
	{
		Path = path;
		CloudLibrary = cloudLibrary;
	}
}
