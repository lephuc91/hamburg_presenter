using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(TextTransform), typeof(IGraphics.Types.IText.Types.Transform), SourceToDestinationMethodName = "ToEntityTextTransform", DestinationToSourceMethodName = "ToTextTransform", UnmatchedSourceNames = new string[] { "RemoveLineReturns", "SingleWordPerLine", "SingleCharacterPerLine" }, UnmatchedDestinationNames = new string[] { "SingleLine", "OneWordPerLine", "OneCharacterPerLine" })]
public static class TextTransformExtensions
{
	public static bool TransformsLineReturns(this TextTransform textTransform)
	{
		if ((uint)(textTransform - 1) <= 1u)
		{
			return true;
		}
		return false;
	}

	public static bool IsSupportedByDeprecatedTextTransformOptions(this TextTransform textTransform)
	{
		return textTransform != TextTransform.ReplaceLineReturns;
	}

	public static IGraphics.Types.IText.Types.Transform ToEntityTextTransform(this TextTransform source)
	{
		return source switch
		{
			TextTransform.None => IGraphics.Types.IText.Types.Transform.None, 
			TextTransform.RemoveLineReturns => IGraphics.Types.IText.Types.Transform.SingleLine, 
			TextTransform.ReplaceLineReturns => IGraphics.Types.IText.Types.Transform.ReplaceLineReturns, 
			TextTransform.SingleWordPerLine => IGraphics.Types.IText.Types.Transform.OneWordPerLine, 
			TextTransform.SingleCharacterPerLine => IGraphics.Types.IText.Types.Transform.OneCharacterPerLine, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static TextTransform ToTextTransform(this IGraphics.Types.IText.Types.Transform source)
	{
		return source switch
		{
			IGraphics.Types.IText.Types.Transform.None => TextTransform.None, 
			IGraphics.Types.IText.Types.Transform.SingleLine => TextTransform.RemoveLineReturns, 
			IGraphics.Types.IText.Types.Transform.OneWordPerLine => TextTransform.SingleWordPerLine, 
			IGraphics.Types.IText.Types.Transform.OneCharacterPerLine => TextTransform.SingleCharacterPerLine, 
			IGraphics.Types.IText.Types.Transform.ReplaceLineReturns => TextTransform.ReplaceLineReturns, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
