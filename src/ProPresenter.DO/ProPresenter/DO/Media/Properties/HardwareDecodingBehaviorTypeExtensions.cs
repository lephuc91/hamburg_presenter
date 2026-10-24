using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media.Properties;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(HardwareDecodingBehaviorType), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType), SourceToDestinationMethodName = "ToProtoVideoHardwareDecodingBehavior", DestinationToSourceMethodName = "ToHardwareDecodingBehavior", DestinationDefaultValue = "Automatic", SourceDefaultValue = "Automatic")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(HardwareDecodingBehaviorType), typeof(IMedia.Types.IVideoProperties.Types.HardwareDecodingType), SourceToDestinationMethodName = "ToEntityVideoHardwareDecodingBehavior", DestinationToSourceMethodName = "ToHardwareDecodingBehavior", DestinationDefaultValue = "Automatic", SourceDefaultValue = "Automatic")]
public static class HardwareDecodingBehaviorTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType ToProtoVideoHardwareDecodingBehavior(this HardwareDecodingBehaviorType source)
	{
		return source switch
		{
			HardwareDecodingBehaviorType.Automatic => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType.Automatic, 
			HardwareDecodingBehaviorType.Disabled => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType.Disabled, 
			_ => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType.Automatic, 
		};
	}

	public static HardwareDecodingBehaviorType ToHardwareDecodingBehavior(this Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType.Automatic => HardwareDecodingBehaviorType.Automatic, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.HardwareDecodingType.Disabled => HardwareDecodingBehaviorType.Disabled, 
			_ => HardwareDecodingBehaviorType.Automatic, 
		};
	}

	public static IMedia.Types.IVideoProperties.Types.HardwareDecodingType ToEntityVideoHardwareDecodingBehavior(this HardwareDecodingBehaviorType source)
	{
		return source switch
		{
			HardwareDecodingBehaviorType.Automatic => IMedia.Types.IVideoProperties.Types.HardwareDecodingType.Automatic, 
			HardwareDecodingBehaviorType.Disabled => IMedia.Types.IVideoProperties.Types.HardwareDecodingType.Disabled, 
			_ => IMedia.Types.IVideoProperties.Types.HardwareDecodingType.Automatic, 
		};
	}

	public static HardwareDecodingBehaviorType ToHardwareDecodingBehavior(this IMedia.Types.IVideoProperties.Types.HardwareDecodingType source)
	{
		return source switch
		{
			IMedia.Types.IVideoProperties.Types.HardwareDecodingType.Automatic => HardwareDecodingBehaviorType.Automatic, 
			IMedia.Types.IVideoProperties.Types.HardwareDecodingType.Disabled => HardwareDecodingBehaviorType.Disabled, 
			_ => HardwareDecodingBehaviorType.Automatic, 
		};
	}
}
