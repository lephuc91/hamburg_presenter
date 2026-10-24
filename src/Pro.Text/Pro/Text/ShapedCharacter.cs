using Pro.Common.Mathematics;

namespace Pro.Text;

internal class ShapedCharacter
{
	public uint GlyphIndex { get; }

	public uint Cluster { get; }

	public int IndexOffset { get; }

	public int Index => (int)Cluster + IndexOffset;

	public bool IsRTL { get; }

	public int BIDILevel { get; }

	public Vector2<double> Advance { get; }

	public Vector2<double> Offset { get; }

	public double LineHeight { get; }

	public Font? Font { get; }

	public Vector2<double> BaseScalar { get; }

	public Vector2<double> ScriptScalar { get; }

	public Vector2<double> FinalScalar { get; }

	public ShapedCharacter(uint glyphIndex, uint cluster, int indexOffset, bool isRTL, int bidiLevel, Vector2<double> advance, Vector2<double> offset, double lineHeight, Font? font, double baseScalar, Vector2<double> scriptScalar)
	{
		GlyphIndex = glyphIndex;
		Cluster = cluster;
		IndexOffset = indexOffset;
		IsRTL = isRTL;
		BIDILevel = bidiLevel;
		Advance = advance;
		Offset = offset;
		LineHeight = lineHeight;
		Font = font;
		BaseScalar = new Vector2<double>(baseScalar);
		ScriptScalar = scriptScalar;
		FinalScalar = BaseScalar.ComponentwiseProduct(ScriptScalar);
		Advance = Advance.ComponentwiseProduct(FinalScalar);
		Offset = Offset.ComponentwiseProduct(FinalScalar);
	}
}
