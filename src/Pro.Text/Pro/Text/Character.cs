using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Text;

internal class Character
{
	public ShapedCharacter CharInfo { get; }

	public bool IsSelectable { get; }

	public int Index { get; }

	public bool IsWhitespace { get; }

	public Glyph? Glyph { get; }

	public Rect<double> GlyphBounds { get; }

	public double? Baseline { get; }

	public Vector2<double> BaselineOffset { get; }

	public Vector2<double> Position { get; set; }

	public Vector2<double> AdditionalAdvance { get; set; } = Vector2<double>.Zero;

	public Vector2<double> Advance => CharInfo.Advance + AdditionalAdvance;

	public TextFillBase? Fill { get; }

	public Rect<double> FillGroupBounds { get; set; }

	public Color StrokeColor { get; }

	public TextFillBase? LineFill { get; }

	public TextFillBase? UnderlineFill { get; }

	public Color? HighlightColor { get; }

	public double StrokeThickness { get; }

	public bool IsStroked
	{
		get
		{
			if (StrokeThickness != 0.0)
			{
				return StrokeColor.A > 0;
			}
			return false;
		}
	}

	public bool IsStrickenthrough { get; }

	public double StrikethroughOffset { get; }

	public double StrikethroughThickness { get; }

	public bool IsUnderlined { get; }

	public double UnderlineOffset { get; }

	public double UnderlineThickness { get; }

	public double LineHeight { get; }

	public bool IsAnnotation { get; }

	public bool EndOfParagraph { get; }

	public TabStopType TabStopType { get; set; }

	public bool IsTab { get; set; }

	public bool IsDecimal { get; set; }

	public double TabAdvance { get; set; }

	public Character(ShapedCharacter charInfo, bool isSelectable, int indexOffset, bool isWhitespace, int scriptLevel, Vector2<double> position, TextFillBase? fill, Color strokeColor, Color? underlineColor, Color? highlightColor, double strokeThickness, bool isStrickenthrough, bool isUnderlined, double lineHeight, bool isAnnotation, bool endOfParagraph)
	{
		CharInfo = charInfo;
		IsSelectable = isSelectable;
		Index = (IsSelectable ? (indexOffset + charInfo.Index) : indexOffset);
		IsWhitespace = isWhitespace;
		Glyph = charInfo.Font?.GetGlyph(charInfo.GlyphIndex);
		GlyphBounds = Glyph?.Bounds.Scale(charInfo.FinalScalar) ?? Rect<double>.Empty;
		Baseline = Glyph?.Baseline * charInfo.BaseScalar.Y;
		BaselineOffset = charInfo.Font?.ScriptInfo.GetBaselineOffset(scriptLevel).ComponentwiseProduct(charInfo.BaseScalar) ?? Vector2<double>.Zero;
		Position = position;
		Fill = fill;
		StrokeColor = strokeColor;
		StrokeThickness = strokeThickness.Clamp(0.0, 1000.0) / ((charInfo.FinalScalar.X + charInfo.FinalScalar.Y) / 2.0) * 2.0;
		IsStrickenthrough = isStrickenthrough;
		StrikethroughOffset = (charInfo.Font?.StrikethroughOffset ?? 0.0) * charInfo.FinalScalar.Y + BaselineOffset.Y;
		StrikethroughThickness = (charInfo.Font?.StrikethroughThickness ?? 0.0) * charInfo.FinalScalar.Y;
		IsUnderlined = isUnderlined;
		LineFill = (IsStroked ? new SolidTextFill(StrokeColor) : Fill);
		UnderlineFill = (underlineColor.HasValue ? new SolidTextFill(underlineColor.Value) : LineFill);
		HighlightColor = highlightColor;
		UnderlineOffset = (charInfo.Font?.UnderlineOffset ?? 0.0) * charInfo.FinalScalar.Y + BaselineOffset.Y;
		UnderlineThickness = (charInfo.Font?.UnderlineThickness ?? 0.0) * charInfo.FinalScalar.Y;
		LineHeight = lineHeight;
		IsAnnotation = isAnnotation;
		EndOfParagraph = endOfParagraph;
	}
}
