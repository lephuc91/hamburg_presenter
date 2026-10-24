using System;

namespace Pro.DO;

public static class MediaContainerIds
{
	public const string Ccli = "CCLI";

	public const string Placeholder = "";

	public const string PlaylistTemplate = "PlaylistTemplate";

	public const string Stage = "Stage";

	public const string Unused = "";

	public const string VideoInput = "VideoInput";

	public const string Workspace = "Workspace";

	public static string Macro(Guid macroCollectionId)
	{
		return $"Macro-{macroCollectionId}";
	}

	public static string Playlist(Guid playlistId)
	{
		return $"Playlist-{playlistId}";
	}

	public static string Prop(Guid propCollectionId)
	{
		return $"Prop-{propCollectionId}";
	}

	public static string Theme(string themeName)
	{
		return "Theme-" + themeName;
	}
}
