using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements.Strokes;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(StrokeStyle), typeof(Graphics.Types.Stroke.Types.Style), SourceToDestinationMethodName = "ToProtoStrokeStyle", DestinationDefaultValue = "SolidLine", DestinationToSourceMethodName = "ToStrokeStyle", SourceDefaultValue = "SolidLine")]
[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(StrokeStyle), typeof(IGraphics.Types.IStroke.Types.Style), SourceToDestinationMethodName = "ToEntityStrokeStyle", DestinationDefaultValue = "SolidLine", DestinationToSourceMethodName = "ToStrokeStyle", SourceDefaultValue = "SolidLine")]
public static class StrokeHelper
{
	public static IStroke DeserializeStroke(this Graphics.Types.Stroke protoStroke)
	{
		Stroke stroke = new Stroke();
		stroke.Deserialize(protoStroke);
		return stroke;
	}

	public static Graphics.Types.Stroke.Types.Style ToProtoStrokeStyle(this StrokeStyle source)
	{
		return source switch
		{
			StrokeStyle.SolidLine => Graphics.Types.Stroke.Types.Style.SolidLine, 
			StrokeStyle.SquareDash => Graphics.Types.Stroke.Types.Style.SquareDash, 
			StrokeStyle.ShortDash => Graphics.Types.Stroke.Types.Style.ShortDash, 
			StrokeStyle.LongDash => Graphics.Types.Stroke.Types.Style.LongDash, 
			_ => Graphics.Types.Stroke.Types.Style.SolidLine, 
		};
	}

	public static StrokeStyle ToStrokeStyle(this Graphics.Types.Stroke.Types.Style source)
	{
		return source switch
		{
			Graphics.Types.Stroke.Types.Style.SolidLine => StrokeStyle.SolidLine, 
			Graphics.Types.Stroke.Types.Style.SquareDash => StrokeStyle.SquareDash, 
			Graphics.Types.Stroke.Types.Style.ShortDash => StrokeStyle.ShortDash, 
			Graphics.Types.Stroke.Types.Style.LongDash => StrokeStyle.LongDash, 
			_ => StrokeStyle.SolidLine, 
		};
	}

	public static IGraphics.Types.IStroke.Types.Style ToEntityStrokeStyle(this StrokeStyle source)
	{
		return source switch
		{
			StrokeStyle.SolidLine => IGraphics.Types.IStroke.Types.Style.SolidLine, 
			StrokeStyle.SquareDash => IGraphics.Types.IStroke.Types.Style.SquareDash, 
			StrokeStyle.ShortDash => IGraphics.Types.IStroke.Types.Style.ShortDash, 
			StrokeStyle.LongDash => IGraphics.Types.IStroke.Types.Style.LongDash, 
			_ => IGraphics.Types.IStroke.Types.Style.SolidLine, 
		};
	}

	public static StrokeStyle ToStrokeStyle(this IGraphics.Types.IStroke.Types.Style source)
	{
		return source switch
		{
			IGraphics.Types.IStroke.Types.Style.SolidLine => StrokeStyle.SolidLine, 
			IGraphics.Types.IStroke.Types.Style.SquareDash => StrokeStyle.SquareDash, 
			IGraphics.Types.IStroke.Types.Style.ShortDash => StrokeStyle.ShortDash, 
			IGraphics.Types.IStroke.Types.Style.LongDash => StrokeStyle.LongDash, 
			_ => StrokeStyle.SolidLine, 
		};
	}
}
