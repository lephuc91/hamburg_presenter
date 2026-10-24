using System;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.DO.Import;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.MissingFonts;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ReplacementFontSource), typeof(MissingFontContext), SourceToDestinationMethodName = "ReplacementFontSourceToMissingFontDestination", DestinationToSourceMethodName = "MissingFontDestinationToReplacementFontSource", UnmatchedSourceNames = new string[] { "Banner" }, UnmatchedDestinationNames = new string[] { "Standalone" })]
public static class ReplacementFontSourceExtensions
{
	public static MissingFontContext ReplacementFontSourceToMissingFontDestination(this ReplacementFontSource source)
	{
		return source switch
		{
			ReplacementFontSource.Import => MissingFontContext.Import, 
			ReplacementFontSource.Banner => MissingFontContext.Standalone, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ReplacementFontSource MissingFontDestinationToReplacementFontSource(this MissingFontContext source)
	{
		return source switch
		{
			MissingFontContext.Import => ReplacementFontSource.Import, 
			MissingFontContext.Standalone => ReplacementFontSource.Banner, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
