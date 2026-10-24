using Pro.Common.Cache;

namespace Pro.Text;

internal class GlyphCache : Cache<uint, Glyph>
{
	private Font _font;

	public GlyphCache(Font font)
	{
		_font = font;
	}

	protected override Glyph GenerateValue(uint target)
	{
		using GlyphInfo glyphInfo = _font.LoadGlyphFromIndex(target);
		return new Glyph(glyphInfo);
	}
}
