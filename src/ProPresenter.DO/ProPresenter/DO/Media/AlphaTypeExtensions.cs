using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Media;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AlphaType), typeof(Pro.SerializationInterop.RVProtoData.AlphaType), SourceToDestinationMethodName = "ToProtoAlphaType", DestinationToSourceMethodName = "ToAlphaType", SourceDefaultValue = "Straight", DestinationDefaultValue = "Straight", ExcludeDestinationNames = new string[] { "Unknown" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(AlphaType), typeof(Pro.Entity.AlphaType), SourceToDestinationMethodName = "ToEntityAlphaType", DestinationToSourceMethodName = "ToAlphaType", SourceDefaultValue = "Straight", DestinationDefaultValue = "Straight", ExcludeDestinationNames = new string[] { "Unknown" })]
public static class AlphaTypeExtensions
{
	public static Pro.SerializationInterop.RVProtoData.AlphaType ToProtoAlphaType(this AlphaType source)
	{
		return source switch
		{
			AlphaType.Unknown => Pro.SerializationInterop.RVProtoData.AlphaType.Unknown, 
			AlphaType.Straight => Pro.SerializationInterop.RVProtoData.AlphaType.Straight, 
			AlphaType.Premultiplied => Pro.SerializationInterop.RVProtoData.AlphaType.Premultiplied, 
			_ => Pro.SerializationInterop.RVProtoData.AlphaType.Straight, 
		};
	}

	public static AlphaType ToAlphaType(this Pro.SerializationInterop.RVProtoData.AlphaType source)
	{
		return source switch
		{
			Pro.SerializationInterop.RVProtoData.AlphaType.Straight => AlphaType.Straight, 
			Pro.SerializationInterop.RVProtoData.AlphaType.Premultiplied => AlphaType.Premultiplied, 
			_ => AlphaType.Straight, 
		};
	}

	public static Pro.Entity.AlphaType ToEntityAlphaType(this AlphaType source)
	{
		return source switch
		{
			AlphaType.Unknown => Pro.Entity.AlphaType.Unknown, 
			AlphaType.Straight => Pro.Entity.AlphaType.Straight, 
			AlphaType.Premultiplied => Pro.Entity.AlphaType.Premultiplied, 
			_ => Pro.Entity.AlphaType.Straight, 
		};
	}

	public static AlphaType ToAlphaType(this Pro.Entity.AlphaType source)
	{
		return source switch
		{
			Pro.Entity.AlphaType.Straight => AlphaType.Straight, 
			Pro.Entity.AlphaType.Premultiplied => AlphaType.Premultiplied, 
			_ => AlphaType.Straight, 
		};
	}
}
