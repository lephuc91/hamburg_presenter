using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public static class PlaylistCreateTypeExtensions
{
	public static Playlist.Types.Type ToProto(this PlaylistCreateType type)
	{
		return type switch
		{
			PlaylistCreateType.General => Playlist.Types.Type.Presentation, 
			PlaylistCreateType.PCO => Playlist.Types.Type.PlanningCenter, 
			PlaylistCreateType.Group => Playlist.Types.Type.Folder, 
			PlaylistCreateType.Template => Playlist.Types.Type.TemplatePlaylist, 
			_ => Playlist.Types.Type.Unknown, 
		};
	}
}
