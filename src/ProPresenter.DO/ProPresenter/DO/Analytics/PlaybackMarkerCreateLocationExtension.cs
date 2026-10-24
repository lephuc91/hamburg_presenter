using Pro.SerializationInterop.RVProtoData.Analytics.PlaybackMarker;

namespace ProPresenter.DO.Analytics;

public static class PlaybackMarkerCreateLocationExtension
{
	public static CreateMarker.Types.Location ToProtoPlaybackMarkerCreateLocation(this PlaybackMarkerCreateLocation location)
	{
		return location switch
		{
			PlaybackMarkerCreateLocation.Inspector => CreateMarker.Types.Location.Inspector, 
			PlaybackMarkerCreateLocation.Sidebar => CreateMarker.Types.Location.Sidebar, 
			_ => CreateMarker.Types.Location.Inspector, 
		};
	}
}
