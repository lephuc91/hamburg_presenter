using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(DeviceType), typeof(OutputDisplay.Types.Type), SourceToDestinationMethodName = "ToProtoDisplayType", DestinationToSourceMethodName = "ToDeviceType", SourceDefaultValue = "Unknown", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "BlackmagicCard", "NDI", "Placeholder", "Unknown" }, UnmatchedDestinationNames = new string[] { "Card", "Ndi", "Custom", "Syphon" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(DeviceType), typeof(IOutputDisplay.Types.Type), SourceToDestinationMethodName = "ToEntityDisplayType", DestinationToSourceMethodName = "ToDeviceType", SourceDefaultValue = "Unknown", DestinationDefaultValue = "Unknown", UnmatchedSourceNames = new string[] { "BlackmagicCard", "NDI", "Placeholder", "Unknown" }, UnmatchedDestinationNames = new string[] { "Card", "Ndi", "Custom", "Syphon" })]
public static class DeviceTypeExtensions
{
	public static bool IsPhysicalDevice(this DeviceType deviceType)
	{
		if (deviceType != DeviceType.Screen)
		{
			return deviceType == DeviceType.BlackmagicCard;
		}
		return true;
	}

	public static OutputDisplay.Types.Type ToProtoDisplayType(this DeviceType source)
	{
		return source switch
		{
			DeviceType.Unknown => OutputDisplay.Types.Type.Syphon, 
			DeviceType.Screen => OutputDisplay.Types.Type.Screen, 
			DeviceType.BlackmagicCard => OutputDisplay.Types.Type.Card, 
			DeviceType.NDI => OutputDisplay.Types.Type.Ndi, 
			DeviceType.Placeholder => OutputDisplay.Types.Type.Custom, 
			_ => OutputDisplay.Types.Type.Unknown, 
		};
	}

	public static DeviceType ToDeviceType(this OutputDisplay.Types.Type source)
	{
		return source switch
		{
			OutputDisplay.Types.Type.Unknown => DeviceType.Unknown, 
			OutputDisplay.Types.Type.Screen => DeviceType.Screen, 
			OutputDisplay.Types.Type.Card => DeviceType.BlackmagicCard, 
			OutputDisplay.Types.Type.Ndi => DeviceType.NDI, 
			OutputDisplay.Types.Type.Syphon => DeviceType.Unknown, 
			OutputDisplay.Types.Type.Custom => DeviceType.Placeholder, 
			_ => DeviceType.Unknown, 
		};
	}

	public static IOutputDisplay.Types.Type ToEntityDisplayType(this DeviceType source)
	{
		return source switch
		{
			DeviceType.Unknown => IOutputDisplay.Types.Type.Syphon, 
			DeviceType.Screen => IOutputDisplay.Types.Type.Screen, 
			DeviceType.BlackmagicCard => IOutputDisplay.Types.Type.Card, 
			DeviceType.NDI => IOutputDisplay.Types.Type.Ndi, 
			DeviceType.Placeholder => IOutputDisplay.Types.Type.Custom, 
			_ => IOutputDisplay.Types.Type.Unknown, 
		};
	}

	public static DeviceType ToDeviceType(this IOutputDisplay.Types.Type source)
	{
		return source switch
		{
			IOutputDisplay.Types.Type.Unknown => DeviceType.Unknown, 
			IOutputDisplay.Types.Type.Screen => DeviceType.Screen, 
			IOutputDisplay.Types.Type.Card => DeviceType.BlackmagicCard, 
			IOutputDisplay.Types.Type.Ndi => DeviceType.NDI, 
			IOutputDisplay.Types.Type.Syphon => DeviceType.Unknown, 
			IOutputDisplay.Types.Type.Custom => DeviceType.Placeholder, 
			_ => DeviceType.Unknown, 
		};
	}
}
