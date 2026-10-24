using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(BlendMode), typeof(EdgeBlend.Types.Mode), SourceToDestinationMethodName = "ToProtoEdgeBlendMode", DestinationToSourceMethodName = "ToBlendMode")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(BlendMode), typeof(IEdgeBlend.Types.Mode), SourceToDestinationMethodName = "ToEntityEdgeBlendMode", DestinationToSourceMethodName = "ToBlendMode")]
public static class BlendModeExtensions
{
	public static EdgeBlend.Types.Mode ToProtoEdgeBlendMode(this BlendMode source)
	{
		return source switch
		{
			BlendMode.Linear => EdgeBlend.Types.Mode.Linear, 
			BlendMode.Cubic => EdgeBlend.Types.Mode.Cubic, 
			BlendMode.Quadratic => EdgeBlend.Types.Mode.Quadratic, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static BlendMode ToBlendMode(this EdgeBlend.Types.Mode source)
	{
		return source switch
		{
			EdgeBlend.Types.Mode.Linear => BlendMode.Linear, 
			EdgeBlend.Types.Mode.Cubic => BlendMode.Cubic, 
			EdgeBlend.Types.Mode.Quadratic => BlendMode.Quadratic, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static IEdgeBlend.Types.Mode ToEntityEdgeBlendMode(this BlendMode source)
	{
		return source switch
		{
			BlendMode.Linear => IEdgeBlend.Types.Mode.Linear, 
			BlendMode.Cubic => IEdgeBlend.Types.Mode.Cubic, 
			BlendMode.Quadratic => IEdgeBlend.Types.Mode.Quadratic, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static BlendMode ToBlendMode(this IEdgeBlend.Types.Mode source)
	{
		return source switch
		{
			IEdgeBlend.Types.Mode.Linear => BlendMode.Linear, 
			IEdgeBlend.Types.Mode.Cubic => BlendMode.Cubic, 
			IEdgeBlend.Types.Mode.Quadratic => BlendMode.Quadratic, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
