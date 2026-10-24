using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.OutputConfiguration;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(HdrFormats), typeof(OutputDisplay.Types.RenderFormat), SourceToDestinationMethodName = "Serialize", DestinationDefaultValue = "Sdr", DestinationToSourceMethodName = "Deserialize", SourceDefaultValue = "Sdr", UnmatchedSourceNames = new string[] { "Rec2100HLG", "Rec2100PQ" }, UnmatchedDestinationNames = new string[] { "Rec2100Hlg", "Rec2100Pq" })]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(HdrFormats), typeof(IOutputDisplay.Types.RenderFormat), SourceToDestinationMethodName = "ToEntityRenderFormat", DestinationDefaultValue = "Sdr", DestinationToSourceMethodName = "ToHdrFormats", SourceDefaultValue = "Sdr", UnmatchedSourceNames = new string[] { "Rec2100HLG", "Rec2100PQ" }, UnmatchedDestinationNames = new string[] { "Rec2100Hlg", "Rec2100Pq" })]
public static class HdrFormatsExtensions
{
	public static OutputDisplay.Types.RenderFormat Serialize(this HdrFormats source)
	{
		return source switch
		{
			HdrFormats.Sdr => OutputDisplay.Types.RenderFormat.Sdr, 
			HdrFormats.Rec2100PQ => OutputDisplay.Types.RenderFormat.Rec2100Pq, 
			HdrFormats.Rec2100HLG => OutputDisplay.Types.RenderFormat.Rec2100Hlg, 
			_ => OutputDisplay.Types.RenderFormat.Sdr, 
		};
	}

	public static HdrFormats Deserialize(this OutputDisplay.Types.RenderFormat source)
	{
		return source switch
		{
			OutputDisplay.Types.RenderFormat.Sdr => HdrFormats.Sdr, 
			OutputDisplay.Types.RenderFormat.Rec2100Pq => HdrFormats.Rec2100PQ, 
			OutputDisplay.Types.RenderFormat.Rec2100Hlg => HdrFormats.Rec2100HLG, 
			_ => HdrFormats.Sdr, 
		};
	}

	public static IOutputDisplay.Types.RenderFormat ToEntityRenderFormat(this HdrFormats source)
	{
		return source switch
		{
			HdrFormats.Sdr => IOutputDisplay.Types.RenderFormat.Sdr, 
			HdrFormats.Rec2100PQ => IOutputDisplay.Types.RenderFormat.Rec2100Pq, 
			HdrFormats.Rec2100HLG => IOutputDisplay.Types.RenderFormat.Rec2100Hlg, 
			_ => IOutputDisplay.Types.RenderFormat.Sdr, 
		};
	}

	public static HdrFormats ToHdrFormats(this IOutputDisplay.Types.RenderFormat source)
	{
		return source switch
		{
			IOutputDisplay.Types.RenderFormat.Sdr => HdrFormats.Sdr, 
			IOutputDisplay.Types.RenderFormat.Rec2100Pq => HdrFormats.Rec2100PQ, 
			IOutputDisplay.Types.RenderFormat.Rec2100Hlg => HdrFormats.Rec2100HLG, 
			_ => HdrFormats.Sdr, 
		};
	}
}
