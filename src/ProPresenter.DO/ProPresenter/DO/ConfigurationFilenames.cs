using System.IO;
using System.Linq;

namespace ProPresenter.DO;

public static class ConfigurationFilenames
{
	public const string LibraryData = "LibraryData";

	public const string Timers = "Timers";

	public const string Calendar = "Calendar";

	public const string Messages = "Messages";

	public const string Workspace = "Workspace";

	public const string CCLI = "CCLI";

	public const string Props = "Props";

	public const string Stage = "Stage";

	public const string Theme = "Theme";

	public const string LibraryPlaylist = "Library";

	public const string MediaPlaylist = "Media";

	public const string AudioPlaylist = "Audio";

	public const string Groups = "Groups";

	public const string Labels = "Labels";

	public const string Macros = "Macros";

	public const string ClearGroups = "ClearGroups";

	public const string KeyMappings = "KeyMappings";

	public const string PlaylistTemplates = "PlaylistTemplates";

	public const string TestPatterns = "TestPatterns";

	public static bool IsLibraryFile(this string filename)
	{
		return IsFileSupported(filename, "LibraryData");
	}

	public static bool IsConfigurationFile(this string filename)
	{
		return IsFileSupported(filename, "Timers", "Calendar", "Messages", "Workspace", "CCLI", "Props", "Stage", "Groups", "Labels", "Macros", "ClearGroups", "KeyMappings");
	}

	public static bool IsThemeFile(this string filename)
	{
		return IsFileSupported(filename, "Theme");
	}

	public static bool IsPlaylistFile(this string filename)
	{
		return IsFileSupported(filename, "Library", "Media", "Audio", "PlaylistTemplates");
	}

	private static bool IsFileSupported(string filename, params string[] targetnames)
	{
		try
		{
			string name = Path.GetFileNameWithoutExtension(filename);
			return targetnames.Any((string n) => name == n);
		}
		catch
		{
			return false;
		}
	}
}
