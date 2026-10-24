using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RssFeedContentMode), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType), SourceToDestinationMethodName = "ToProtoRSSContentType", DestinationDefaultValue = "TitleAndDescription", DestinationToSourceMethodName = "ToRssFeedContentMode", SourceDefaultValue = "TextAndDescription", UnmatchedSourceNames = new string[] { "TextAndDescription", "TextOnly" }, UnmatchedDestinationNames = new string[] { "TitleAndDescription", "TitleOnly" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(RssFeedContentMode), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType), SourceToDestinationMethodName = "ToEntityRssContentType", DestinationDefaultValue = "TitleAndDescription", DestinationToSourceMethodName = "ToRssFeedContentMode", SourceDefaultValue = "TextAndDescription", UnmatchedSourceNames = new string[] { "TextAndDescription", "TextOnly" }, UnmatchedDestinationNames = new string[] { "TitleAndDescription", "TitleOnly" })]
public static class RssFeedContentModeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType ToProtoRSSContentType(this RssFeedContentMode source)
	{
		return source switch
		{
			RssFeedContentMode.TextAndDescription => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType.TitleAndDescription, 
			RssFeedContentMode.TextOnly => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType.TitleOnly, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType.TitleAndDescription, 
		};
	}

	public static RssFeedContentMode ToRssFeedContentMode(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType.TitleOnly => RssFeedContentMode.TextOnly, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.RSSFeed.Types.ContentType.TitleAndDescription => RssFeedContentMode.TextAndDescription, 
			_ => RssFeedContentMode.TextAndDescription, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType ToEntityRssContentType(this RssFeedContentMode source)
	{
		return source switch
		{
			RssFeedContentMode.TextAndDescription => ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType.TitleAndDescription, 
			RssFeedContentMode.TextOnly => ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType.TitleOnly, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType.TitleAndDescription, 
		};
	}

	public static RssFeedContentMode ToRssFeedContentMode(this ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType.TitleOnly => RssFeedContentMode.TextOnly, 
			ISlide.Types.IElement.Types.IDataLink.Types.IRssFeed.Types.ContentType.TitleAndDescription => RssFeedContentMode.TextAndDescription, 
			_ => RssFeedContentMode.TextAndDescription, 
		};
	}
}
