using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Links;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource), SourceToDestinationMethodName = "ToProtoAutoAdvanceSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource), SourceToDestinationMethodName = "ToProtoVideoCountdownSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource), SourceToDestinationMethodName = "ToProtoPresentationSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource), SourceToDestinationMethodName = "ToEntityAutoAdvanceSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource), SourceToDestinationMethodName = "ToEntityPresentationSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(SourceType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource), SourceToDestinationMethodName = "ToEntityVideoCountdownSource", DestinationDefaultValue = "Presentation", DestinationToSourceMethodName = "ToSourceType", SourceDefaultValue = "Presentation")]
public static class AudioAdvanceSourceExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource ToProtoAutoAdvanceSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation, 
			SourceType.Announcement => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Announcement, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation => SourceType.Presentation, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.AutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource ToProtoVideoCountdownSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource.Presentation, 
			SourceType.Announcement => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource.Announcement, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource.Presentation => SourceType.Presentation, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.VideoCountdown.Types.VideoCountdownSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}

	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource ToProtoPresentationSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource.Presentation, 
			SourceType.Announcement => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource.Announcement, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource.Presentation => SourceType.Presentation, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.Presentation.Types.PresentationSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource ToEntityAutoAdvanceSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation, 
			SourceType.Announcement => ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Announcement, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Presentation => SourceType.Presentation, 
			ISlide.Types.IElement.Types.IDataLink.Types.IAutoAdvanceTimeRemaining.Types.AutoAdvanceSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource ToEntityPresentationSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource.Presentation, 
			SourceType.Announcement => ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource.Announcement, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource.Presentation => SourceType.Presentation, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPresentation.Types.PresentationSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource ToEntityVideoCountdownSource(this SourceType source)
	{
		return source switch
		{
			SourceType.Presentation => ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource.Presentation, 
			SourceType.Announcement => ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource.Announcement, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource.Presentation, 
		};
	}

	public static SourceType ToSourceType(this ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource.Presentation => SourceType.Presentation, 
			ISlide.Types.IElement.Types.IDataLink.Types.IVideoCountdown.Types.VideoCountdownSource.Announcement => SourceType.Announcement, 
			_ => SourceType.Presentation, 
		};
	}
}
