using Pro.SerializationInterop.RVProtoData.Analytics.Create;

namespace ProPresenter.DO.Analytics;

public static class PlaylistCreateSourceExtensions
{
	public static Playlist.Types.Source ToProto(this PlaylistCreateSource source)
	{
		return source switch
		{
			PlaylistCreateSource.ApplicationMenu => Playlist.Types.Source.ApplicationMenu, 
			PlaylistCreateSource.OutlineAddButton => Playlist.Types.Source.LibraryOutlineAddButton, 
			_ => Playlist.Types.Source.Unknown, 
		};
	}
}
