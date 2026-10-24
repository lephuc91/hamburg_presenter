using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

public static class PlaybackMarkerIdentifierHelpers
{
	public static PlaybackMarkerIdentifier Deserialize(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier proto)
	{
		return new PlaybackMarkerIdentifier(proto.Destination.ToPlaybackMarkerIdentifierDestination(), proto.Type.ToPlaybackMarkerIdentifierType(), proto.Name);
	}
}
