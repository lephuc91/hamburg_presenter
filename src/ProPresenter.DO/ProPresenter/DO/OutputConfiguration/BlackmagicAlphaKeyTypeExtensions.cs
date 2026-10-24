using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(BlackmagicAlphaKeyType), typeof(OutputDisplay.Types.Blackmagic.Types.KeyMode), SourceToDestinationMethodName = "ToProtoKeyMode", DestinationToSourceMethodName = "ToBlackmagicAlphaKeyType")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(BlackmagicAlphaKeyType), typeof(IOutputDisplay.Types.IBlackmagic.Types.KeyMode), SourceToDestinationMethodName = "ToEntityKeyMode", DestinationToSourceMethodName = "ToBlackmagicAlphaKeyType")]
public static class BlackmagicAlphaKeyTypeExtensions
{
	public static OutputDisplay.Types.Blackmagic.Types.KeyMode ToProtoKeyMode(this BlackmagicAlphaKeyType source)
	{
		return source switch
		{
			BlackmagicAlphaKeyType.External => OutputDisplay.Types.Blackmagic.Types.KeyMode.External, 
			BlackmagicAlphaKeyType.Internal => OutputDisplay.Types.Blackmagic.Types.KeyMode.Internal, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static BlackmagicAlphaKeyType ToBlackmagicAlphaKeyType(this OutputDisplay.Types.Blackmagic.Types.KeyMode source)
	{
		return source switch
		{
			OutputDisplay.Types.Blackmagic.Types.KeyMode.Internal => BlackmagicAlphaKeyType.Internal, 
			OutputDisplay.Types.Blackmagic.Types.KeyMode.External => BlackmagicAlphaKeyType.External, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IOutputDisplay.Types.IBlackmagic.Types.KeyMode ToEntityKeyMode(this BlackmagicAlphaKeyType source)
	{
		return source switch
		{
			BlackmagicAlphaKeyType.External => IOutputDisplay.Types.IBlackmagic.Types.KeyMode.External, 
			BlackmagicAlphaKeyType.Internal => IOutputDisplay.Types.IBlackmagic.Types.KeyMode.Internal, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static BlackmagicAlphaKeyType ToBlackmagicAlphaKeyType(this IOutputDisplay.Types.IBlackmagic.Types.KeyMode source)
	{
		return source switch
		{
			IOutputDisplay.Types.IBlackmagic.Types.KeyMode.Internal => BlackmagicAlphaKeyType.Internal, 
			IOutputDisplay.Types.IBlackmagic.Types.KeyMode.External => BlackmagicAlphaKeyType.External, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
