using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackMarkerIdentifierDestination), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination), SourceToDestinationMethodName = "ToProtoPlaybackMarkerIdentifierDestination", DestinationDefaultValue = "PlaybackMarkerDestinationPresentation", DestinationToSourceMethodName = "ToPlaybackMarkerIdentifierDestination", SourceDefaultValue = "Presentation", UnmatchedSourceNames = new string[] { "Presentation", "Announcement", "Audio" }, UnmatchedDestinationNames = new string[] { "PlaybackMarkerDestinationPresentation", "PlaybackMarkerDestinationAnnouncement", "PlaybackMarkerDestinationAudio" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackMarkerIdentifierDestination), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination), SourceToDestinationMethodName = "ToEntityPlaybackMarkerIdentificationDestination", DestinationDefaultValue = "PlaybackMarkerDestinationPresentation", DestinationToSourceMethodName = "ToPlaybackMarkerIdentifierDestination", SourceDefaultValue = "Presentation", UnmatchedSourceNames = new string[] { "Presentation", "Announcement", "Audio" }, UnmatchedDestinationNames = new string[] { "PlaybackMarkerDestinationPresentation", "PlaybackMarkerDestinationAnnouncement", "PlaybackMarkerDestinationAudio" })]
public static class PlaybackMarkerIdentifierDestinationHelpers
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination ToProtoPlaybackMarkerIdentifierDestination(this PlaybackMarkerIdentifierDestination source)
	{
		return source switch
		{
			PlaybackMarkerIdentifierDestination.Presentation => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation, 
			PlaybackMarkerIdentifierDestination.Announcement => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAnnouncement, 
			PlaybackMarkerIdentifierDestination.Audio => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAudio, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation, 
		};
	}

	public static PlaybackMarkerIdentifierDestination ToPlaybackMarkerIdentifierDestination(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation => PlaybackMarkerIdentifierDestination.Presentation, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAnnouncement => PlaybackMarkerIdentifierDestination.Announcement, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAudio => PlaybackMarkerIdentifierDestination.Audio, 
			_ => PlaybackMarkerIdentifierDestination.Presentation, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination ToEntityPlaybackMarkerIdentificationDestination(this PlaybackMarkerIdentifierDestination source)
	{
		return source switch
		{
			PlaybackMarkerIdentifierDestination.Presentation => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation, 
			PlaybackMarkerIdentifierDestination.Announcement => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAnnouncement, 
			PlaybackMarkerIdentifierDestination.Audio => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAudio, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation, 
		};
	}

	public static PlaybackMarkerIdentifierDestination ToPlaybackMarkerIdentifierDestination(this ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationPresentation => PlaybackMarkerIdentifierDestination.Presentation, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAnnouncement => PlaybackMarkerIdentifierDestination.Announcement, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Destination.PlaybackMarkerDestinationAudio => PlaybackMarkerIdentifierDestination.Audio, 
			_ => PlaybackMarkerIdentifierDestination.Presentation, 
		};
	}
}
