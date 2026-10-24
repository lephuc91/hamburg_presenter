using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace Pro.Text;

public static class ParagraphAlignmentExtensions
{
	public static Graphics.Types.Text.Types.Attributes.Types.Alignment ToProtoParagraphAlignment(this ParagraphAlignment paragraphAlignment)
	{
		return paragraphAlignment switch
		{
			ParagraphAlignment.Left => Graphics.Types.Text.Types.Attributes.Types.Alignment.Left, 
			ParagraphAlignment.Right => Graphics.Types.Text.Types.Attributes.Types.Alignment.Right, 
			ParagraphAlignment.Justified => Graphics.Types.Text.Types.Attributes.Types.Alignment.Justified, 
			_ => Graphics.Types.Text.Types.Attributes.Types.Alignment.Center, 
		};
	}

	public static ParagraphAlignment ToParagraphAlignment(this Graphics.Types.Text.Types.Attributes.Types.Alignment protoParagraphAlignment)
	{
		switch (protoParagraphAlignment)
		{
		case Graphics.Types.Text.Types.Attributes.Types.Alignment.Left:
		case Graphics.Types.Text.Types.Attributes.Types.Alignment.Natural:
			return ParagraphAlignment.Left;
		default:
			return ParagraphAlignment.Center;
		case Graphics.Types.Text.Types.Attributes.Types.Alignment.Right:
			return ParagraphAlignment.Right;
		case Graphics.Types.Text.Types.Attributes.Types.Alignment.Justified:
			return ParagraphAlignment.Justified;
		}
	}

	public static IGraphics.Types.IText.Types.IAttributes.Types.Alignment ToEntityParagraphAlignment(this ParagraphAlignment paragraphAlignment)
	{
		return paragraphAlignment switch
		{
			ParagraphAlignment.Left => IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Left, 
			ParagraphAlignment.Right => IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Right, 
			ParagraphAlignment.Justified => IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Justified, 
			_ => IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Center, 
		};
	}

	public static ParagraphAlignment ToParagraphAlignment(this IGraphics.Types.IText.Types.IAttributes.Types.Alignment protoParagraphAlignment)
	{
		switch (protoParagraphAlignment)
		{
		case IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Left:
		case IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Natural:
			return ParagraphAlignment.Left;
		default:
			return ParagraphAlignment.Center;
		case IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Right:
			return ParagraphAlignment.Right;
		case IGraphics.Types.IText.Types.IAttributes.Types.Alignment.Justified:
			return ParagraphAlignment.Justified;
		}
	}
}
