using Pro.Common.SourceGenerator.Attributes;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaybackMarkerTextType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase), SourceToDestinationMethodName = "ToProtoPlaybackMarkerTextType", DestinationDefaultValue = "Name", DestinationToSourceMethodName = "ToPlaybackMarkerTextType", SourceDefaultValue = "Name", UnmatchedSourceNames = new string[] { "Name" }, UnmatchedDestinationNames = new string[] { "None" })]
public static class PlaybackMarkerTextTypeHelpers
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase ToProtoPlaybackMarkerTextType(this PlaybackMarkerTextType source)
	{
		return source switch
		{
			PlaybackMarkerTextType.Name => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.None, 
			PlaybackMarkerTextType.Time => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.Time, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.Name, 
		};
	}

	public static PlaybackMarkerTextType ToPlaybackMarkerTextType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.None => PlaybackMarkerTextType.Name, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.Name => PlaybackMarkerTextType.Name, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaybackMarkerText.TextTypeOneofCase.Time => PlaybackMarkerTextType.Time, 
			_ => PlaybackMarkerTextType.Name, 
		};
	}
}
