using System.Collections.Generic;
using Pro.Text;

namespace ProPresenter.Rendering;

public class TextLayerInfo
{
	public IReadOnlyDictionary<TextRenderOptions, Range[]> Ranges { get; }

	public TextLayerType Type { get; }

	public TextFillBase? Fill { get; }

	public int BuildIndex { get; }

	public TextLayerInfo(Range range, TextLayerType type, TextFillBase? fill, int buildIndex)
		: this(new Range[1] { range }, type, fill, buildIndex)
	{
	}

	public TextLayerInfo(Range[] ranges, TextLayerType type, TextFillBase? fill, int buildIndex)
		: this(ranges, TextRenderOptions.None, type, fill, buildIndex)
	{
	}

	public TextLayerInfo(Range range, TextRenderOptions flags, TextLayerType type, TextFillBase? fill, int buildIndex)
		: this(new Range[1] { range }, flags, type, fill, buildIndex)
	{
	}

	public TextLayerInfo(Range[] ranges, TextRenderOptions flags, TextLayerType type, TextFillBase? fill, int buildIndex)
		: this(new Dictionary<TextRenderOptions, Range[]> { { flags, ranges } }, type, fill, buildIndex)
	{
	}

	public TextLayerInfo(IReadOnlyDictionary<TextRenderOptions, Range[]> ranges, TextLayerType type, TextFillBase? fill, int buildIndex)
	{
		Ranges = ranges;
		Type = type;
		Fill = fill;
		BuildIndex = buildIndex;
	}
}
