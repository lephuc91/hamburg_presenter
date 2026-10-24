using System.Windows.Media;

namespace Pro.Text;

public class TextRenderParams
{
	public static readonly TextRenderParams Default = new TextRenderParams(null, null, null, null, renderShadow: true, renderFill: true, useStandardMaskBrush: false, null, translateOverrideMaskBrush: true, null);

	public TextRenderOptions Flags { get; }

	public Range Range { get; } = Range.All;

	public Brush? OverrideFillBrush { get; }

	public Brush? OverrideStrokeBrush { get; }

	public Brush? OverrideUnderlineBrush { get; }

	public Brush? OverrideStrikeBrush { get; }

	public bool RenderShadow { get; } = true;

	public bool RenderFill { get; } = true;

	public bool RenderStroke { get; } = true;

	public bool RenderLines { get; } = true;

	public bool UseFullSizeMedia { get; set; }

	public bool UseStandardMaskBrush { get; }

	public Brush? OverrideMaskBrush { get; }

	public bool TranslateOverrideMaskBrush { get; } = true;

	public TextRenderParams(Range range)
	{
		Range = range;
	}

	public TextRenderParams(TextRenderOptions flags, Range range, bool renderShadow = true, bool renderFill = true, bool renderStroke = true, bool renderLines = true, bool useStandardMaskBrush = false, Brush? overrideMaskBrush = null, bool translateOverrideMaskBrush = true, bool useFullSizeMedia = false)
	{
		Flags = flags;
		Range = range;
		RenderShadow = renderShadow;
		RenderFill = renderFill;
		RenderStroke = renderStroke;
		RenderLines = renderLines;
		UseFullSizeMedia = useFullSizeMedia;
		UseStandardMaskBrush = useStandardMaskBrush;
		OverrideMaskBrush = overrideMaskBrush;
		TranslateOverrideMaskBrush = translateOverrideMaskBrush;
	}

	public TextRenderParams(Brush? overrideFillBrush = null, Brush? overrideStrokeBrush = null, Brush? overrideUnderlineBrush = null, Brush? overrideStrikeBrush = null, bool renderShadow = true, bool renderFill = true, bool useStandardMaskBrush = false, Brush? overrideMaskBrush = null, bool translateOverrideMaskBrush = true, Range? range = null, bool useFullSizeMedia = false)
	{
		Range = range ?? Range;
		OverrideFillBrush = overrideFillBrush;
		OverrideStrokeBrush = overrideStrokeBrush;
		OverrideUnderlineBrush = overrideUnderlineBrush;
		OverrideStrikeBrush = overrideStrikeBrush;
		RenderShadow = renderShadow;
		RenderFill = renderFill;
		UseFullSizeMedia = useFullSizeMedia;
		UseStandardMaskBrush = useStandardMaskBrush;
		OverrideMaskBrush = overrideMaskBrush;
		TranslateOverrideMaskBrush = translateOverrideMaskBrush;
	}

	public TextRenderParams(TextRenderOptions flags, Range range, Brush overrideFillBrush, Brush overrideStrokeBrush, Brush overrideUnderlineBrush, Brush overrideStrikeBrush, bool renderShadow, bool renderFill, bool renderStroke, bool renderLines, bool useStandardMaskBrush, Brush overrideMaskBrush, bool translateOverrideMaskBrush, bool useFullSizeMedia)
	{
		Flags = flags;
		Range = range;
		OverrideFillBrush = overrideFillBrush;
		OverrideStrokeBrush = overrideStrokeBrush;
		OverrideUnderlineBrush = overrideUnderlineBrush;
		OverrideStrikeBrush = overrideStrikeBrush;
		RenderShadow = renderShadow;
		RenderFill = renderFill;
		RenderStroke = renderStroke;
		RenderLines = renderLines;
		UseFullSizeMedia = useFullSizeMedia;
		UseStandardMaskBrush = useStandardMaskBrush;
		OverrideMaskBrush = overrideMaskBrush;
		TranslateOverrideMaskBrush = translateOverrideMaskBrush;
	}
}
