using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.DO.Extensions.ProtoEntityConversion;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(Pro.Entity.AlphaType), typeof(Pro.SerializationInterop.RVProtoData.AlphaType), SourceToDestinationMethodName = "ToProto", DestinationDefaultValue = "Unknown", DestinationToSourceMethodName = "ToEntity", SourceDefaultValue = "Unknown")]
public static class AlphaTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.AlphaType ToProto(this Pro.Entity.AlphaType source)
	{
		return source switch
		{
			Pro.Entity.AlphaType.Unknown => Pro.SerializationInterop.RVProtoData.AlphaType.Unknown, 
			Pro.Entity.AlphaType.Straight => Pro.SerializationInterop.RVProtoData.AlphaType.Straight, 
			Pro.Entity.AlphaType.Premultiplied => Pro.SerializationInterop.RVProtoData.AlphaType.Premultiplied, 
			_ => Pro.SerializationInterop.RVProtoData.AlphaType.Unknown, 
		};
	}

	public static Pro.Entity.AlphaType ToEntity(this Pro.SerializationInterop.RVProtoData.AlphaType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.AlphaType.Unknown => Pro.Entity.AlphaType.Unknown, 
			Pro.SerializationInterop.RVProtoData.AlphaType.Straight => Pro.Entity.AlphaType.Straight, 
			Pro.SerializationInterop.RVProtoData.AlphaType.Premultiplied => Pro.Entity.AlphaType.Premultiplied, 
			_ => Pro.Entity.AlphaType.Unknown, 
		};
	}
}
