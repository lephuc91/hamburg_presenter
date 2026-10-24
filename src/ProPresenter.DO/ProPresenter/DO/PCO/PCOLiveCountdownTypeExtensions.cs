using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.PCO;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOLiveCountdownType), typeof(Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType), SourceToDestinationMethodName = "ToProtoPCOLiveCountdownType", DestinationDefaultValue = "FullItemLength", DestinationToSourceMethodName = "ToPCOLiveCountdownType", SourceDefaultValue = "FullItemLength")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(PCOLiveCountdownType), typeof(ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType), SourceToDestinationMethodName = "ToEntityPCOLiveCountdownType", DestinationDefaultValue = "FullItemLength", DestinationToSourceMethodName = "ToPCOLiveCountdownType", SourceDefaultValue = "FullItemLength")]
public static class PCOLiveCountdownTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType ToProtoPCOLiveCountdownType(this PCOLiveCountdownType source)
	{
		return source switch
		{
			PCOLiveCountdownType.FullItemLength => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.FullItemLength, 
			PCOLiveCountdownType.EndItemOnTime => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.EndItemOnTime, 
			PCOLiveCountdownType.EndServiceOnTime => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.EndServiceOnTime, 
			_ => Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.FullItemLength, 
		};
	}

	public static PCOLiveCountdownType ToPCOLiveCountdownType(this Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.FullItemLength => PCOLiveCountdownType.FullItemLength, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.EndItemOnTime => PCOLiveCountdownType.EndItemOnTime, 
			Pro.SerializationInterop.RVProtoData.Slide.Types.Element.Types.DataLink.Types.PCOLive.Types.CountdownType.EndServiceOnTime => PCOLiveCountdownType.EndServiceOnTime, 
			_ => PCOLiveCountdownType.FullItemLength, 
		};
	}

	public static ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType ToEntityPCOLiveCountdownType(this PCOLiveCountdownType source)
	{
		return source switch
		{
			PCOLiveCountdownType.FullItemLength => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.FullItemLength, 
			PCOLiveCountdownType.EndItemOnTime => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.EndItemOnTime, 
			PCOLiveCountdownType.EndServiceOnTime => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.EndServiceOnTime, 
			_ => ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.FullItemLength, 
		};
	}

	public static PCOLiveCountdownType ToPCOLiveCountdownType(this ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType source)
	{
		return source switch
		{
			ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.FullItemLength => PCOLiveCountdownType.FullItemLength, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.EndItemOnTime => PCOLiveCountdownType.EndItemOnTime, 
			ISlide.Types.IElement.Types.IDataLink.Types.IPcoLive.Types.CountdownType.EndServiceOnTime => PCOLiveCountdownType.EndServiceOnTime, 
			_ => PCOLiveCountdownType.FullItemLength, 
		};
	}
}
