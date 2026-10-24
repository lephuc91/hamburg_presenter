using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackMarkerIdentifierType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type), SourceToDestinationMethodName = "ToProtoPlaybackMarkerIdentifierType", DestinationDefaultValue = "PlaybackMarkerIdentifierFirst", DestinationToSourceMethodName = "ToPlaybackMarkerIdentifierType", SourceDefaultValue = "First", UnmatchedSourceNames = new string[] { "First", "Previous", "Next", "Last", "Name" }, UnmatchedDestinationNames = new string[] { "PlaybackMarkerIdentifierFirst", "PlaybackMarkerIdentifierPrevious", "PlaybackMarkerIdentifierNext", "PlaybackMarkerIdentifierLast", "PlaybackMarkerIdentifierName" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackMarkerIdentifierType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type), SourceToDestinationMethodName = "ToEntityPlaybackMarkerIdentifierType", DestinationDefaultValue = "PlaybackMarkerIdentifierFirst", DestinationToSourceMethodName = "ToPlaybackMarkerIdentifierType", SourceDefaultValue = "First", UnmatchedSourceNames = new string[] { "First", "Previous", "Next", "Last", "Name" }, UnmatchedDestinationNames = new string[] { "PlaybackMarkerIdentifierFirst", "PlaybackMarkerIdentifierPrevious", "PlaybackMarkerIdentifierNext", "PlaybackMarkerIdentifierLast", "PlaybackMarkerIdentifierName" })]
public static class PlaybackMarkerIdentifierTypeHelpers
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type ToProtoPlaybackMarkerIdentifierType(this PlaybackMarkerIdentifierType source)
	{
		return source switch
		{
			PlaybackMarkerIdentifierType.First => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst, 
			PlaybackMarkerIdentifierType.Previous => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierPrevious, 
			PlaybackMarkerIdentifierType.Next => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierNext, 
			PlaybackMarkerIdentifierType.Last => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierLast, 
			PlaybackMarkerIdentifierType.Name => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierName, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst, 
		};
	}

	public static PlaybackMarkerIdentifierType ToPlaybackMarkerIdentifierType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst => PlaybackMarkerIdentifierType.First, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierPrevious => PlaybackMarkerIdentifierType.Previous, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierNext => PlaybackMarkerIdentifierType.Next, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierLast => PlaybackMarkerIdentifierType.Last, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierName => PlaybackMarkerIdentifierType.Name, 
			_ => PlaybackMarkerIdentifierType.First, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type ToEntityPlaybackMarkerIdentifierType(this PlaybackMarkerIdentifierType source)
	{
		return source switch
		{
			PlaybackMarkerIdentifierType.First => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst, 
			PlaybackMarkerIdentifierType.Previous => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierPrevious, 
			PlaybackMarkerIdentifierType.Next => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierNext, 
			PlaybackMarkerIdentifierType.Last => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierLast, 
			PlaybackMarkerIdentifierType.Name => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierName, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst, 
		};
	}

	public static PlaybackMarkerIdentifierType ToPlaybackMarkerIdentifierType(this ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierFirst => PlaybackMarkerIdentifierType.First, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierPrevious => PlaybackMarkerIdentifierType.Previous, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierNext => PlaybackMarkerIdentifierType.Next, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierLast => PlaybackMarkerIdentifierType.Last, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaybackMarkerIdentifier.Types.Type.PlaybackMarkerIdentifierName => PlaybackMarkerIdentifierType.Name, 
			_ => PlaybackMarkerIdentifierType.First, 
		};
	}
}
