using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(ScaleMode), typeof(IGraphics.Types.IText.Types.ScaleBehavior), SourceToDestinationMethodName = "ToEntityScaleBehavior", DestinationToSourceMethodName = "ToScaleMode", UnmatchedSourceNames = new string[] { "Down", "Up", "UpOrDown" }, UnmatchedDestinationNames = new string[] { "ScaleFontDown", "ScaleFontUp", "ScaleFontUpDown" })]
public static class ScaleModeExtensions
{
	public static IGraphics.Types.IText.Types.ScaleBehavior ToEntityScaleBehavior(this ScaleMode source)
	{
		return source switch
		{
			ScaleMode.None => IGraphics.Types.IText.Types.ScaleBehavior.None, 
			ScaleMode.AdjustContainerHeight => IGraphics.Types.IText.Types.ScaleBehavior.AdjustContainerHeight, 
			ScaleMode.Up => IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontUp, 
			ScaleMode.Down => IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontDown, 
			ScaleMode.UpOrDown => IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontUpDown, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static ScaleMode ToScaleMode(this IGraphics.Types.IText.Types.ScaleBehavior source)
	{
		return source switch
		{
			IGraphics.Types.IText.Types.ScaleBehavior.None => ScaleMode.None, 
			IGraphics.Types.IText.Types.ScaleBehavior.AdjustContainerHeight => ScaleMode.AdjustContainerHeight, 
			IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontDown => ScaleMode.Down, 
			IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontUp => ScaleMode.Up, 
			IGraphics.Types.IText.Types.ScaleBehavior.ScaleFontUpDown => ScaleMode.UpOrDown, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
