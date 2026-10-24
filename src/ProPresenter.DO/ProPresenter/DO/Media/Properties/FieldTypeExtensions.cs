using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media.Properties;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FieldType), typeof(Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType), SourceToDestinationMethodName = "ToProtoVideoFieldType", DestinationToSourceMethodName = "ToFieldType")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(FieldType), typeof(IMedia.Types.IVideoProperties.Types.FieldType), SourceToDestinationMethodName = "ToEntityVideoFieldType", DestinationToSourceMethodName = "ToFieldType")]
public static class FieldTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType ToProtoVideoFieldType(this FieldType source)
	{
		return source switch
		{
			FieldType.Unknown => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.Unknown, 
			FieldType.Progressive => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.Progressive, 
			FieldType.InterlacedUpperFirst => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.InterlacedUpperFirst, 
			FieldType.InterlacedLowerFirst => Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.InterlacedLowerFirst, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static FieldType ToFieldType(this Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.Unknown => FieldType.Unknown, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.Progressive => FieldType.Progressive, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.InterlacedUpperFirst => FieldType.InterlacedUpperFirst, 
			Pro.SerializationInterop.RVProtoData.Media.Types.VideoProperties.Types.FieldType.InterlacedLowerFirst => FieldType.InterlacedLowerFirst, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IMedia.Types.IVideoProperties.Types.FieldType ToEntityVideoFieldType(this FieldType source)
	{
		return source switch
		{
			FieldType.Unknown => IMedia.Types.IVideoProperties.Types.FieldType.Unknown, 
			FieldType.Progressive => IMedia.Types.IVideoProperties.Types.FieldType.Progressive, 
			FieldType.InterlacedUpperFirst => IMedia.Types.IVideoProperties.Types.FieldType.InterlacedUpperFirst, 
			FieldType.InterlacedLowerFirst => IMedia.Types.IVideoProperties.Types.FieldType.InterlacedLowerFirst, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static FieldType ToFieldType(this IMedia.Types.IVideoProperties.Types.FieldType source)
	{
		return source switch
		{
			IMedia.Types.IVideoProperties.Types.FieldType.Unknown => FieldType.Unknown, 
			IMedia.Types.IVideoProperties.Types.FieldType.Progressive => FieldType.Progressive, 
			IMedia.Types.IVideoProperties.Types.FieldType.InterlacedUpperFirst => FieldType.InterlacedUpperFirst, 
			IMedia.Types.IVideoProperties.Types.FieldType.InterlacedLowerFirst => FieldType.InterlacedLowerFirst, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
