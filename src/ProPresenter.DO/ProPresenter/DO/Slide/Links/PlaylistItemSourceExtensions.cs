using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaylistItemSource), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType), SourceToDestinationMethodName = "ToProtoPlaylistItemSource", DestinationDefaultValue = "Current", DestinationToSourceMethodName = "ToPlaylistItemSource", SourceDefaultValue = "Current")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PlaylistItemSource), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType), SourceToDestinationMethodName = "ToEntityPlaylistitemSource", DestinationDefaultValue = "Current", DestinationToSourceMethodName = "ToPlaylistItemSource", SourceDefaultValue = "Current")]
public static class PlaylistItemSourceExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType ToProtoPlaylistItemSource(this PlaylistItemSource source)
	{
		return source switch
		{
			PlaylistItemSource.ParentPlaylist => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.ParentPlaylist, 
			PlaylistItemSource.Current => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.Current, 
			PlaylistItemSource.Next => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.Next, 
			PlaylistItemSource.CurrentHeader => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.CurrentHeader, 
			PlaylistItemSource.NextHeader => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.NextHeader, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.Current, 
		};
	}

	public static PlaylistItemSource ToPlaylistItemSource(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.Current => PlaylistItemSource.Current, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.Next => PlaylistItemSource.Next, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.CurrentHeader => PlaylistItemSource.CurrentHeader, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.NextHeader => PlaylistItemSource.NextHeader, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PlaylistItem.Types.PlaylistItemSourceType.ParentPlaylist => PlaylistItemSource.ParentPlaylist, 
			_ => PlaylistItemSource.Current, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType ToEntityPlaylistitemSource(this PlaylistItemSource source)
	{
		return source switch
		{
			PlaylistItemSource.ParentPlaylist => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.ParentPlaylist, 
			PlaylistItemSource.Current => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.Current, 
			PlaylistItemSource.Next => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.Next, 
			PlaylistItemSource.CurrentHeader => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.CurrentHeader, 
			PlaylistItemSource.NextHeader => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.NextHeader, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.Current, 
		};
	}

	public static PlaylistItemSource ToPlaylistItemSource(this ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.Current => PlaylistItemSource.Current, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.Next => PlaylistItemSource.Next, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.CurrentHeader => PlaylistItemSource.CurrentHeader, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.NextHeader => PlaylistItemSource.NextHeader, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPlaylistItem.Types.PlaylistItemSourceType.ParentPlaylist => PlaylistItemSource.ParentPlaylist, 
			_ => PlaylistItemSource.Current, 
		};
	}
}
