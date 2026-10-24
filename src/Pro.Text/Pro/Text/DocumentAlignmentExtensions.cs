using System;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Entity;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.MapEnum(typeof(DocumentAlignment), typeof(IGraphics.Types.IText.Types.VerticalAlignment), SourceToDestinationMethodName = "ToEntityDocumentAlignment", DestinationToSourceMethodName = "ToDocumentAlignment")]
public static class DocumentAlignmentExtensions
{
	public static IGraphics.Types.IText.Types.VerticalAlignment ToEntityDocumentAlignment(this DocumentAlignment source)
	{
		return source switch
		{
			DocumentAlignment.Top => IGraphics.Types.IText.Types.VerticalAlignment.Top, 
			DocumentAlignment.Middle => IGraphics.Types.IText.Types.VerticalAlignment.Middle, 
			DocumentAlignment.Bottom => IGraphics.Types.IText.Types.VerticalAlignment.Bottom, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}

	public static DocumentAlignment ToDocumentAlignment(this IGraphics.Types.IText.Types.VerticalAlignment source)
	{
		return source switch
		{
			IGraphics.Types.IText.Types.VerticalAlignment.Top => DocumentAlignment.Top, 
			IGraphics.Types.IText.Types.VerticalAlignment.Middle => DocumentAlignment.Middle, 
			IGraphics.Types.IText.Types.VerticalAlignment.Bottom => DocumentAlignment.Bottom, 
			_ => throw new ArgumentOutOfRangeException("source", source, "Value not found"), 
		};
	}
}
